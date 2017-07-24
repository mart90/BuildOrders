using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BuildOrders
{
    public class InteractiveParser : IVariableManipulator
    {
        public InteractiveParser() { }

        public ColonyBuilder colonyBuilder;
        public List<InteractiveState> saveGames = new List<InteractiveState>();
        public List<Variable> variables = new List<Variable>();
        public List<Function> functions = new List<Function>();

        public void InputLoop()
        {
            string input = "";
            try
            {
                while (true)
                {
                    Console.Write("\n: ");
                    input = Console.ReadLine();
                    ReadLine(input);
                }
            }
            catch (Exception e)
            {
                if (colonyBuilder != null)
                    Save(new List<string> { "save", "error" });

                var writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/scripts/error.txt", true);
                writer.Write("\nCommand: " + input);
                writer.Write("\nErrMessage: " + e.Message);
                writer.Close();

                Console.WriteLine("Whoops! Something unexpected went wrong.\nError message: " + e.Message +
                    "\nYour script and the error message have been saved to [app directory]/scripts/error.txt. Please send this file to Goodspeed.");
                Console.ReadLine();
            }
        }

        public void ReadLine(string input)
        {
            if (input == "")
                return;
            var words = new List<string>(input.Split(' '));

            switch (words[0])
            {
                case "?":
                    ListPossibleCommands();
                    break;
                case "load":
                    Load(words);
                    break;
                case "save":
                    Save(words);
                    break;
                case "show":
                    Show(words);
                    break;
                case "undo":
                    Undo();
                    break;
                case "new":
                    NewColony();
                    break;
                case "eval":
                    Eval(input, words);
                    break;
                case "print":
                    Print(words);
                    break;
                case "history":
                    History();
                    break;
                case "savelog":
                    SaveLog(words);
                    break;

                default:
                    BuildOrderCommand(input);
                    break;
            }
        }

        public void NewColony()
        {
            if (colonyBuilder != null)
                AutosaveToDisk();

            Console.Write("Input civilization and randomcrate\n: ");
            string input = Console.ReadLine();
            var newColonyBuilder = NewLineParser().GetColonyFromUserInput(input);

            if (newColonyBuilder == null)
            {
                Console.WriteLine("Invalid input. Expects format [civ name] [random crate]");
                return;
            }

            colonyBuilder = newColonyBuilder;
            AutoSave(input);
        }

        public void Eval(string input, List<string> words)
        {
            bool result;
            try
            {
                var parser = NewLineParser(input);
                parser.ReplaceVariablesAndFunctions(words);
                result = parser.EvalBoolStatement(words);
            }
            catch (CommandParseError)
            {
                return;
            }

            if (result)
            {
                Console.WriteLine("true");
                if (words.Contains("make"))
                {
                    AutoSave(input.Substring(5));
                }
            }
            else
                Console.WriteLine("false");
        }

        public void Print(List<string> words)
        {
            if (words.Count != 2)
            {
                Console.WriteLine("Incomplete statement. Missing variable or colony field to print");
                return;
            }

            if (words[1].StartsWith("$"))
            {
                var variable = FindVariableByName(words[1].Substring(1));
                if (variable == null)
                    Console.WriteLine("Variable '" + words[1].Substring(1) + "' not found");
                else
                    Console.WriteLine(variable.value);
            }
            else
            {
                var propertyvalue = NewLineParser().TryParseProperty(words[1]);
                if (propertyvalue == null)
                    Console.WriteLine("Property '" + words[1] + "' not found");
                else
                    Console.WriteLine(propertyvalue);
            }
        }

        public void BuildOrderCommand(string input)
        {
            if (colonyBuilder != null)
            {
                ParseBuildOrderCommand(input);
                colonyBuilder.QuickShow();
            }
            else
                Console.WriteLine("Invalid input. Use 'new' to start a new colony");
        }

        public void Revert()
        {
            var savegame = saveGames[saveGames.Count - 1];
            LoadSaveGame(savegame);
        }

        public void Undo()
        {
            Load(new List<string> { "load", (saveGames.Count - 1).ToString() });
        }

        public void LoadSaveGame(InteractiveState savegame)
        {
            colonyBuilder = savegame.colonyBuilder;
            variables = savegame.variables;
            functions = savegame.functions;
        }

        public void Show(List<string> words)
        {
            if (colonyBuilder != null)
            {
                if (words.Count > 1)
                {
                    colonyBuilder.ShowTimeAndScore();
                    switch (words[1])
                    {
                        case "eco":
                            colonyBuilder.ShowEco();
                            break;
                        case "queue":
                            colonyBuilder.ShowQueue();
                            break;
                        case "shipments":
                            colonyBuilder.ShowShipments();
                            break;
                        case "military":
                            colonyBuilder.ShowMilitary();
                            break;
                    }
                }
                else
                    colonyBuilder.ShowAll();
            }
            else
                Console.WriteLine("Invalid input. Use 'new' to start a new colony");
        }

        public void Save(List<string> words)
        {
            if (words.Count > 1)
            {
                var writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/scripts/" + words[1] + ".txt");
                foreach (string line in colonyBuilder.commandHistory)
                {
                    writer.WriteLine(line);
                }
                writer.Close();
            }
            else
                Console.WriteLine("Invalid command. Enter a filename");
        }

        public void Load(List<string> words)
        {
            if (colonyBuilder != null && words[1] != "autosave")
            {
                AutosaveToDisk();
                Console.WriteLine("State autosaved to disk before loading");
            }

            if (words.Count > 1)
            {
                int index = 0;
                if (int.TryParse(words[1], out index))
                {
                    try
                    {
                        LoadSaveGame(saveGames[index - 1]);
                        saveGames.RemoveRange(index, saveGames.Count - index);
                        var history = colonyBuilder.commandHistory;
                        Console.WriteLine("Rolled back to state after command '" + history[history.Count - 1] + "'");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Invalid history index to load '" + index + "'");
                    }
                }
                else
                    LoadScriptFromDisk(words[1]);
            }
            else
                Console.WriteLine("Invalid command. Enter a history index (found by using 'history') or a script filename to load");
        }

        public void AutosaveToDisk()
        {
            Save(new List<string> { "save", "autosave" });
        }

        public void LoadScriptFromDisk(string sscript)
        {
            var savegamebackup = new List<InteractiveState>(saveGames);
            saveGames.Clear();
            ScriptParser scriptparser;
            try
            {
                scriptparser = new ScriptParser(sscript);
            }
            catch (IOException)
            {
                Console.WriteLine("File not found. Make sure it is in [App directory]/scripts/");
                saveGames = savegamebackup;
                return;
            }

            var firstline = scriptparser.lines[0];
            int linecursor = 0;
            try
            {
                colonyBuilder = NewLineParser().GetColonyFromUserInput(firstline);
                AutoSave(firstline);
                scriptparser.lines.RemoveAt(0);
                for (; linecursor < scriptparser.lines.Count; linecursor++)
                {
                    var line = scriptparser.lines[linecursor];
                    if (line == "break")
                    {
                        scriptparser.logger.Close();
                        InputLoop();
                    }
                    if (line.StartsWith("while") || line.StartsWith("if"))
                        linecursor = ParseBlock(scriptparser, linecursor);
                    else
                        ParseBuildOrderCommand(line);
                }
            }
            catch (CommandParseError)
            {
                Console.WriteLine("\nThe script was loaded up to line " + (linecursor + 1) + ", then failed due to the above error");
            }

            scriptparser.logger.Close();
            InputLoop();
        }

        public void SaveLog(List<string> words)
        {
            if (words.Count > 1)
            {
                var logger = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/logs/" + words[1] + ".log");
                foreach (string line in colonyBuilder.colony.logger)
                {
                    logger.WriteLine(line);
                }
                logger.Close();
            }
        }

        public int ParseBlock(ScriptParser scriptparser, int linecursor)
        {
            var blocktype = scriptparser.lines[linecursor].Split(' ')[0];
            var endstatement = "end" + blocktype;
            var endblockstoignore = 0;
            var blocklines = new List<string>();
            while (scriptparser.lines[linecursor] != endstatement || endblockstoignore != -1)
            {
                if (scriptparser.lines[linecursor] == blocktype)
                    endblockstoignore++;
                blocklines.Add(scriptparser.lines[linecursor]);
                linecursor++;
                if (scriptparser.lines[linecursor] == endstatement)
                    endblockstoignore--;
            }
            blocklines.Add(scriptparser.lines[linecursor]);
            linecursor++;
            var parser = new InteractiveCommandParser(blocklines, colonyBuilder, variables, functions);
            parser.ParseLines();
            UpdateVariables(parser.variables);
            SaveBlockstring(parser);
            return linecursor;
        }

        public void ParseBuildOrderCommand(string line)
        {
            var words = new List<string>(line.Split(' '));

            if (words[0] == "while")
                While(line);
            else if (words[0] == "if")
                If(line);
            else
            {
                try
                {
                    var lp = NewLineParser(line);
                    lp.ParseLines();
                    UpdateVariables(lp.variables);
                }
                catch (CommandParseError)
                {
                    Revert();
                    return;
                }
                AutoSave(line);
            }
        }

        public void While(string line)
        {
            var blocklines = new List<string>();
            blocklines.Add(line);
            int ignoreendwhiles = 0;
            string input;
            
            while (true)
            {
                Console.Write("... ");
                input = Console.ReadLine();
                blocklines.Add(input);
                if (input.Split(' ')[0] == "while")
                {
                    ignoreendwhiles++;
                }
                if (input == "endwhile")
                {
                    if (ignoreendwhiles == 0)
                        break;
                    ignoreendwhiles--;
                }
            }

            var blockparser = new InteractiveCommandParser(blocklines, colonyBuilder, variables, functions);
            try
            {
                blockparser.ParseLines();
                UpdateVariables(blockparser.variables);
            }
            catch (CommandParseError)
            {
                Revert();
                return;
            }

            SaveBlockstring(blockparser);
        }

        public void If(string line)
        {
            var blocklines = new List<string>();
            blocklines.Add(line);
            int ignoreendwhiles = 0;
            string input;

            while (true)
            {
                Console.Write("... ");
                input = Console.ReadLine();
                blocklines.Add(input);
                if (input.Split(' ')[0] == "if")
                {
                    ignoreendwhiles++;
                }
                if (input == "endif")
                {
                    if (ignoreendwhiles == 0)
                        break;
                    ignoreendwhiles--;
                }
            }

            var blockparser = new InteractiveCommandParser(blocklines, colonyBuilder, variables, functions);
            try
            {
                blockparser.ParseLines();
                UpdateVariables(blockparser.variables);
            }
            catch (CommandParseError)
            {
                Revert();
                return;
            }

            SaveBlockstring(blockparser);
        }

        public void SaveBlockstring(InteractiveCommandParser blockparser)
        {
            var blockstring = "";
            foreach (string blockline in blockparser.lines)
            {
                blockstring += blockline + "\n";
            }
            AutoSave(blockstring);
        }

        public InteractiveCommandParser NewLineParser(string line = null)
        {
            var lines = new List<string>();
            if (line != null)
                lines.Add(line);
            return new InteractiveCommandParser(lines, colonyBuilder, variables, functions);
        }

        public InteractiveState CopyParserState(InteractiveState source)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, source);
            stream.Seek(0, SeekOrigin.Begin);
            return (InteractiveState)formatter.Deserialize(stream);
        }

        public void AutoSave(string line)
        {
            colonyBuilder.commandHistory.Add(line);
            saveGames.Add(CopyParserState(new InteractiveState(colonyBuilder, variables, functions, saveGames)));
        }

        public void History()
        {
            var history = colonyBuilder.commandHistory;
            string writestr = "";
            var lineindex = 1;
            foreach (string line in history)
            {
                if (line.Contains("\n"))
                {
                    using (StringReader reader = new StringReader(line))
                    {
                        while (true)
                        {
                            var readline = reader.ReadLine();
                            if (readline == null)
                                break;
                            writestr += readline;
                            writestr += "\n.... ";
                        }
                        writestr = writestr.Substring(0, writestr.Length - 6);
                    }
                    Console.WriteLine(lineindex + ". " + writestr);
                    writestr = "";
                }
                else
                    Console.WriteLine(lineindex + ". " + line);
                lineindex++;
            }
        }

        public Variable FindVariableByName(string name)
        {
            return variables.Find(var => var.name == name);
        }

        public void UpdateVariables(List<Variable> variables)
        {
            foreach (var var in variables)
            {
                var localvar = FindVariableByName(var.name);
                if (localvar != null)
                    localvar.value = var.value;
            }
        }

        public void ListPossibleCommands()
        {
            Console.WriteLine("new");
            Console.WriteLine("load [filename or history index]");

            if (colonyBuilder != null)
            {
                Console.WriteLine("save [filename]");
                Console.WriteLine("savelog [filename]");
                Console.WriteLine("import [filename]");
                Console.WriteLine("undo");
                Console.WriteLine("history");
                Console.WriteLine("show [keyword]\n");

                Console.WriteLine("eval (not) [true/false statement]");
                Console.WriteLine("print [variable or number colony field]\n");

                Console.WriteLine("continue [optional amount of seconds]");
                Console.WriteLine("continue while (not) [true/false statement]");
                Console.WriteLine("continue while [number colony variable name] [comparison operator] [number]\n");

                Console.WriteLine("if (not) [true/false statement]");
                Console.WriteLine("if [number colony variable name] [comparison operator] [number]\n");

                Console.WriteLine("while (not) [true/false statement]");
                Console.WriteLine("while [number colony variable name] [comparison operator] [number]\n");

                Console.WriteLine("newvillsto [resource]");
                Console.WriteLine("switchvills [from resource] [to resource] [amount]");
                Console.WriteLine("allocatevills [food] [wood] [coin]");
                Console.WriteLine("allocatebuildings [resource]");
                Console.WriteLine("autovills [on or off]\n");

                Console.WriteLine("$[variable name]");
                Console.WriteLine("$[variable name] = [value or operation]");
                Console.WriteLine("&[function name] [parameters separated by spaces]");

                Console.WriteLine("\nmake building [building]");
                Console.WriteLine("  TradingPost");
                foreach (ConstBuilding building in colonyBuilder.colony.villagers[0].allowedBuildings)
                {
                    if (building.ageavailable <= colonyBuilder.colony.age && building.ageavailable != 0)
                        Console.WriteLine("  " + building.name);
                }

                Console.Write("\nmake tech [tech]\n  ");
                var i = 1;
                foreach (Building building in colonyBuilder.colony.AllBuildings())
                {
                    foreach (ConstTech tech in building.allowedTechs)
                    {
                        if (tech.ageavailable > colonyBuilder.colony.age)
                            continue;
                        Console.Write(tech.name);
                        for (var j = 0; j < 20 - tech.name.Length; j++)
                            Console.Write(" ");
                        Console.Write("\t");
                        if (i % 4 == 0)
                            Console.Write("\n  ");
                        i++;
                    }
                }

                Console.Write("\n\nmake unit [unit] [amount]\n  ");
                i = 1;
                foreach (UnitBuilding building in colonyBuilder.colony.unitBuildings)
                {
                    foreach (ConstUnit unit in building.allowedUnits)
                    {
                        if (unit.ageavailable > colonyBuilder.colony.age)
                            continue;
                        Console.Write(unit.name);
                        for (var j = 0; j < 20 - unit.name.Length; j++)
                            Console.Write(" ");
                        Console.Write("\t");
                        if (i % 4 == 0)
                            Console.Write("\n  ");
                        i++;
                    }
                }

                Console.Write("\n\nshipment [shipment]\n  ");
                i = 1;
                foreach (ConstShipment shipment in colonyBuilder.colony.allowedShipments)
                {
                    Console.Write(shipment.name);
                    for (var j = 0; j < 20 - shipment.name.Length; j++)
                        Console.Write(" ");
                    Console.Write("\t");
                    if (i % 4 == 0)
                        Console.Write("\n  ");
                    i++;
                }

                Console.WriteLine("\n\nmake wonder [wonder] [amount of villagers]");
                foreach (ConstBuilding building in colonyBuilder.colony.villagers[0].allowedBuildings)
                {
                    if (building.ageavailable == 0)
                        Console.WriteLine("  " + building.name);
                }
            }
            Console.WriteLine();
        }
    }
}
