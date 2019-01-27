using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

/*
 * Error Codes
 * 
 * 100: Parse line: Unrecognized keyword
 * 101: Invalid variable name
 * 102: Eval comparison: Invalid comparison
 * 103: Parse block: Missing end statement
 * 104: Convert to int: Invalid amount given
 * 105: Parse line: Statement incomplete
 * 106: Convert to double: Not a valid number
 * 107: Parse resource: Invalid resource name
 * 108: Eval comparison: Invalid comparison operator
 * 109: Infinite loop detected
 * 110: Variable is not a boolean
 * 111: Function not found
 * 112: Variable not found
 * 113: Variable operation: given value types are not the same
 * 114: Variable operation: missing assignment operator '='
 * 115: Function call: expected X parameters, found < X
 * 116: Not allowed to build wonders
 * 117: Unknown dance
 * 118: Civ can't dance
 * 119: No fire pit to dance at
 * 120: Set colony property: value types are not the same
 * 121: Set colony property: property is read-only
 * 122: Godmode not enabled
 * 123: Function file not found
 */

namespace BuildOrders
{
    public abstract class CommandParser : IVariableManipulator
    {
        public List<string> lines = new List<string>();
        public List<Function> functions = new List<Function>();
        public List<Variable> variables = new List<Variable>();
        public string returnable = "";

        public int linecursor;
        public ColonyBuilder colonyBuilder;

        public abstract void While(string line);
        public abstract void If(List<string> words);
        public abstract void Log(string message);
        public abstract void Abort(int exitcode);

        public void ParseLines()
        {
            while (linecursor < lines.Count)
            {
                ParseLine();
                linecursor++;
            }
        }

        public void ParseLine()
        {
            var words = new List<string>(lines[linecursor].Split(' '));

            if (words[0].StartsWith("$"))
            {
                VariableAssignment(words);
                return;
            }
            ReplaceVariablesAndFunctions(words);

            if (words[0] == "" || words[0].Substring(0, 1) == "#")
                return;

            switch (words[0])
            {
                case "shipment":
                    ValidateWordCount(words.Count, 2);
                    Shipment(words[1]);
                    break;
                case "continue":
                    Continue(words);
                    break;
                case "while":
                    While(lines[linecursor]);
                    break;
                case "if":
                    If(words);
                    break;
                case "newvillsto":
                    ValidateWordCount(words.Count, 2);
                    NewVillsTo(words[1]);
                    break;
                case "newboatsto":
                    ValidateWordCount(words.Count, 2);
                    NewBoatsTo(words[1]);
                    break;
                case "switchvills":
                    SwitchVills(words);
                    break;
                case "allocatevills":
                    AllocateVills(words);
                    break;
                case "allocateboats":
                    AllocateBoats(words);
                    break;
                case "allocatebuildings":
                    ValidateWordCount(words.Count, 2);
                    AllocateBuildings(words[1]);
                    break;
                case "make":
                    MakeStatement(words);
                    break;
                case "autovills":
                    AutoVills(words);
                    break;
                case "autoboats":
                    AutoBoats(words);
                    break;
                case "import":
                    Import(words);
                    break;
                case "return":
                    Return(words);
                    break;
                case "dance":
                    Dance(words);
                    break;
                case "travoisbuilding":
                    ValidateWordCount(words.Count, 2);
                    TravoisBuilding(words[1]);
                    break;
                case "godmode":
                    colonyBuilder.godmode = true;
                    break;
                case "set":
                    Set(words);
                    break;

                default:
                    Log("ERROR 100: Unrecognized keyword '" + words[0] + "'");
                    Abort(100);
                    break;
            }
        }

        public void ReplaceVariablesAndFunctions(List<string> words)
        {
            ParseVariables(words);
            CallFunctions(words);
            for (var i = 0; i < words.Count; i++)
            {
                if (i > 0 && words[i] == "")
                    words.RemoveAt(i);
            }
        }

        public void ParseVariables(List<string> words)
        {
            for (var i = 0; i < words.Count; i++)
            {
                if (!words[i].StartsWith("$"))
                    continue;

                var varname = words[i].Substring(1);
                var variable = FindVariableByName(varname);
                if (variable != null)
                    words[i] = variable.value;
                else
                {
                    Log("ERROR 112: Variable '" + varname + "' not found");
                    Abort(112);
                }
            }
        }

        public void CallFunctions(List<string> words)
        {
            for (var i = 0; i < words.Count; i++)
            {
                if (!words[i].StartsWith("&"))
                    continue;

                var funcname = words[i].Substring(1);
                var function = functions.Find(func => func.name == funcname);
                if (function == null)
                {
                    Log("ERROR 111: Function " + funcname + " not found");
                    Abort(111);
                }
                if (words.Count - (i + 1) < function.localVariables.Count)
                {
                    Log("ERROR 115: Expected " + function.localVariables.Count + " parameter(s), " + (words.Count - (i + 1)) + " were given");
                    Abort(115);
                }

                for (var param = 0; param < function.localVariables.Count; param++)
                {
                    var paramvalue = words[i + param + 1];
                    function.localVariables[param].value = paramvalue;
                }
                for (var param = 0; param < function.localVariables.Count; param++)
                    words[i + param + 1] = "";

                var returnvalue = function.Execute(this);
                if (returnvalue != null)
                    words[i] = returnvalue;
                else
                    words[i] = "";
            }
        }

        public ColonyBuilder GetColonyFromUserInput(string line)
        {
            var words = new List<string>(line.Split(' '));
            var civ = words[0];
            var randomcrate = Resource.Food;
            var tpstart = false;

            if (words.Count == 2 && words[1] == "tpstart")
            {
                randomcrate = Resource.Wood;
                tpstart = true;
            }
            else
            {
                try
                {
                    randomcrate = TryParseResource(words[1]);
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("'" + words[1] + "' is not a valid crate start. Defauled to food");
                    randomcrate = Resource.Food;
                }

                if (words.Count >= 3 && words[2] == "tpstart")
                {
                    if (randomcrate != Resource.Wood)
                    {
                        Console.WriteLine("A TP start is only available with wood starts");
                        return null;
                    }
                    else
                        tpstart = true;
                }
            }

            switch (civ.ToLower())
            {
                case "aztecs":
                    return new AztecColonyBuilder(randomcrate, tpstart);
                case "british":
                    return new BritishColonyBuilder(randomcrate, tpstart);
                case "chinese":
                    return new ChineseColonyBuilder(tpstart);
                case "dutch":
                    return new DutchColonyBuilder(randomcrate, tpstart);
                case "french":
                    return new FrenchColonyBuilder(randomcrate, tpstart);
                case "germans":
                    return new GermanColonyBuilder(randomcrate, tpstart);
                case "indians":
                    return new IndiansColonyBuilder(randomcrate, tpstart);
                case "iroquois":
                    return new IroquoisColonyBuilder(randomcrate, tpstart);
                case "japanese":
                    return new JapaneseColonyBuilder(randomcrate, tpstart);
                case "ottomans":
                    return new OttomanColonyBuilder(randomcrate, tpstart);
                case "portuguese":
                    return new PortugueseColonyBuilder(randomcrate, tpstart);
                case "russians":
                    return new RussianColonyBuilder(randomcrate, tpstart);
                case "sioux":
                    return new SiouxColonyBuilder(randomcrate, tpstart);
                case "spanish":
                    return new SpanishColonyBuilder(randomcrate, tpstart);
            }
            return null;
        }

        public Resource ParseCrate(List<string> words)
        {
            if (words.Count == 2)
                return TryParseResource(words[1]);

            return Resource.Wood;
        }

        public object TryParseColonyField(string name)
        {
            try
            {
                return colonyBuilder.colony.GetFieldValueByName(name);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public int? TryParseCount(string name)
        {
            if (cUnit.GetFieldByName(name) != null)
                return colonyBuilder.colony.GetCountByUnitName(name);

            if (cBuilding.GetFieldByName(name) != null)
                return colonyBuilder.colony.GetCountByBuildingName(name);

            return null;
        }

        public double? TryParseProperty(string propertyname)
        {
            if (propertyname == "score")
                return colonyBuilder.colony.Score();

            object parsedproperty = null;
            if (propertyname.EndsWith("count"))
            {
                parsedproperty = TryParseCount(propertyname.Substring(0, propertyname.Length - 5));
                if (parsedproperty != null)
                    return Convert.ToDouble(parsedproperty);
            }

            try
            {
                parsedproperty = TryParseColonyField(propertyname);
                if (parsedproperty != null)
                    return Convert.ToDouble(parsedproperty);
            }
            catch (FormatException)
            {
                Log("ERROR 106: Colony property '" + propertyname + "' value is not a valid number");
                Abort(106);
            }

            return null;
        }

        public Resource TryParseResource(string sresource)
        {
            sresource = FirstCharToUpper(sresource);
            try
            {
                return (Resource)Enum.Parse(typeof(Resource), sresource);
            }
            catch (ArgumentException)
            {
                Log("ERROR 107: Invalid resource '" + sresource + "'");
                Abort(107);
            }
            return Resource.Food;
        }

        public void Set(List<string> words)
        {
            ValidateWordCount(words.Count, 3);
            var colony = colonyBuilder.colony;

            if (!colonyBuilder.godmode)
            {
                Log("ERROR 122: Enable godmode using the 'godmode' command in order to modify colony properties");
                Abort(122);
            }

            FieldInfo field = null;
            field = colony.GetType().GetField(words[1], BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

            if (field == null)
            {
                Log("ERROR 101: Unrecognized colony property");
                Abort(101);
            }

            if (field.FieldType == typeof(bool))
            {
                if (words[2] == "true")
                    field.SetValue(colony, true);
                else if (words[2] == "false")
                    field.SetValue(colony, false);
                else
                {
                    Log("ERROR 120: Colony property " + words[1] + " can only be set to 'true' or 'false'");
                    Abort(120);
                }
            }
            else if (field.FieldType == typeof(int))
            {
                int parsedint;
                if (int.TryParse(words[2], out parsedint))
                    field.SetValue(colony, parsedint);
                else
                {
                    Log("ERROR 120: Colony property " + words[1] + " can only be set to a whole number");
                    Abort(120);
                }
            }
            else if (field.FieldType == typeof(double))
            {
                double parseddouble;
                if (double.TryParse(words[2], out parseddouble))
                    field.SetValue(colony, parseddouble);
                else
                {
                    Log("ERROR 120: Colony property " + words[1] + " can only be set to a number");
                    Abort(120);
                }
            }
            else
            {
                Log("ERROR 121: Colony property " + words[1] + " cannot be modified");
                Abort(121);
            }
        }

        public void Continue(List<string> words)
        {
            if (words.Count > 2)
                ContinueWhile(words);
            else if (words.Count == 2)
            {
                int amount;
                if (int.TryParse(words[1], out amount))
                    for (int i = 0; i < amount; i++)
                        colonyBuilder.Continue();
                else
                {
                    Log("ERROR 104: Invalid amount of seconds '" + words[1] + "'");
                    Abort(104);
                }
            }
            else
                colonyBuilder.Continue();
        }

        public bool EvalBoolStatement(List<string> words)
        {
            var w = new List<string>(words);
            w.RemoveAt(0);
            if (w.Contains("make"))
            {
                if (w[0] == "not")
                {
                    w.RemoveAt(0);
                    return !MakeStatement(w);
                }
                return MakeStatement(w);
            }
            if (w.Count == 3)
            {
                switch (w[1])
                {
                    case "=":
                        return EvalEquals(w[0], w[2]);
                    case "!=":
                        return !EvalEquals(w[0], w[2]);
                    case ">":
                        return EvalGreaterThan(w[0], w[2]);
                    case "<":
                        return EvalLessThan(w[0], w[2]);

                    default:
                        Log("ERROR 108: Invalid comparison operator '" + w[1] + "'");
                        Abort(108);
                        break;
                }
            }
            else
            {
                try
                {
                    object result;
                    if (w[0] == "not")
                    {
                        w.RemoveAt(0);
                        result = TryParseColonyField(w[0]);
                        if (result != null)
                            return !(bool)result;
                    }
                    else
                    {
                        result = TryParseColonyField(w[0]);
                        if (result != null)
                            return (bool)result;
                    }
                }
                catch (InvalidCastException)
                {
                    Log("ERROR 110: Property '" + words[1] + "' is not true/false");
                    Abort(110);
                }
                Log("ERROR 101: Couldn't resolve property name '" + w[0] + "'");
                Abort(101);
            }
            return false;
        }

        public void NewVillsTo(string sresource)
        {
            colonyBuilder.colony.newVillstoResource = TryParseResource(sresource);
        }

        public void NewBoatsTo(string sresource)
        {
            colonyBuilder.colony.newBoatstoResource = TryParseResource(sresource);
        }

        public void AutoVills(List<string> words)
        {
            if (words[1] == "on")
                colonyBuilder.autoVills = true;
            else if (words[1] == "off")
                colonyBuilder.autoVills = false;
            else
            {
                Log("ERROR 109: Invalid input '" + words[1] + "'. AutoVills accepts either 'on' or 'off'");
                Abort(109);
            }
        }

        public void AutoBoats(List<string> words)
        {
            if (words[1] == "on")
                colonyBuilder.autoBoats = true;
            else if (words[1] == "off")
                colonyBuilder.autoBoats = false;
            else
            {
                Log("ERROR 109: Invalid input '" + words[1] + "'. AutoBoats accepts either 'on' or 'off'");
                Abort(109);
            }
        }

        public bool MakeStatement(List<string> words)
        {
            switch (words[1])
            {
                case "unit":
                    ValidateWordCount(words.Count, 3);
                    return MakeUnit(words[2]);
                case "building":
                    ValidateWordCount(words.Count, 3);
                    return MakeBuilding(words);
                case "tech":
                    ValidateWordCount(words.Count, 3);
                    return MakeTech(words[2]);
                case "wonder":
                    ValidateWordCount(words.Count, 4);
                    return MakeWonder(words);

                default:
                    Log("ERROR 100: Unrecognized keyword '" + words[1] + "' in make statement. Valid are 'tech', 'unit', 'building' and 'wonder'");
                    return false;
            }
        }

        public bool MakeUnit(string sunit)
        {
            ConstUnit unit = null;
            unit = cUnit.GetFieldByName(sunit);

            if (unit == null)
            {
                Log("ERROR 101: Couldn't resolve unit name '" + sunit + "'");
                Abort(101);
            }
            return colonyBuilder.MakeUnit(unit);
        }

        public bool MakeBuilding(List<string> words)
        {
            var sbuilding = words[2];
            int numvills = 1;

            if (words.Count == 4)
            {
                if (!int.TryParse(words[3], out numvills))
                {
                    Log("ERROR 104: Number of vills given was not a valid number");
                    Abort(104);
                }
            }

            ConstBuilding building = null;
            building = cBuilding.GetFieldByName(sbuilding);

            if (building == null)
            {
                Log("ERROR 101: Couldn't resolve building name '" + sbuilding + "'");
                Abort(101);
            }
            return colonyBuilder.MakeBuilding(building, numvills);
        }

        public bool MakeTech(string stech)
        {
            ConstTech tech = null;
            tech = cTech.GetFieldByName(stech);

            if (tech == null)
            {
                Log("ERROR 101: Couldn't resolve tech name '" + stech + "'");
                Abort(101);
            }
            return colonyBuilder.MakeTech(tech);
        }

        public bool MakeWonder(List<string> words)
        {
            string swonder = words[2];
            int numvills = 1;

            if (!(colonyBuilder is AsianColonyBuilder))
                return false;

            if (words.Count == 4)
            {
                if (!int.TryParse(words[3], out numvills))
                {
                    Log("ERROR 104: Invalid number of villagers given");
                    Abort(104);
                }
            }

            ConstBuilding wonder = null;
            wonder = cBuilding.GetFieldByName(swonder);

            if (wonder == null)
            { 
                Log("ERROR 101: Couldn't resolve wonder name '" + swonder + "'");
                Abort(101);
            }
            return ((AsianColonyBuilder)colonyBuilder).MakeWonder(wonder, numvills);
        }

        public void Shipment(string sshipment)
        {
            if (!colonyBuilder.shipmentsReset || sshipment == "reset")
            {
                colonyBuilder.shipmentsToSend.Clear();
                colonyBuilder.shipmentsReset = true;
                if (sshipment == "reset")
                    return;
            }

            ConstShipment shipment = null;
            shipment = cShipment.GetFieldByName(sshipment);

            if (shipment == null)
            {
                Log("ERROR 101: Couldn't resolve shipment name '" + sshipment + "'");
                Abort(101);
            }
            colonyBuilder.shipmentsToSend.Add(shipment);
        }

        public bool EvalEquals(string value1, string value2)
        {
            double? converteddouble = null;
            int parsedvalue1, parsedvalue2;
            if (int.TryParse(value1, out parsedvalue1))
            {
                converteddouble = TryParseProperty(value2);
                if (converteddouble != null)
                    return converteddouble == parsedvalue1;
                if (int.TryParse(value2, out parsedvalue2))
                    return parsedvalue1 == parsedvalue2;
            }
            else if (int.TryParse(value2, out parsedvalue2))
            {
                converteddouble = TryParseProperty(value1);
                if (converteddouble != null)
                    return converteddouble == parsedvalue2;
            }
            Log("ERROR 102: Invalid comparison between '" + value1 + "' and '" + value2 +
                "'. Make sure one is a number and the other a property name");
            Abort(102);
            return true;
        }

        public bool EvalGreaterThan(string value1, string value2)
        {
            double? converteddouble = null;
            int parsedvalue1, parsedvalue2;
            if (int.TryParse(value1, out parsedvalue1))
            {
                converteddouble = TryParseProperty(value2);
                if (converteddouble != null)
                    return converteddouble < parsedvalue1;
                if (int.TryParse(value2, out parsedvalue2))
                    return parsedvalue1 > parsedvalue2;
            }
            if (int.TryParse(value2, out parsedvalue2))
            {
                converteddouble = TryParseProperty(value2);
                if (converteddouble != null)
                    return converteddouble > parsedvalue2;
            }
            Log("ERROR 102: Invalid comparison between '" + value1 + "' and '" + value2 +
                "'. Make sure one is a number and the other a property name");
            Abort(102);
            return true;
        }

        public bool EvalLessThan(string value1, string value2)
        {
            double? converteddouble = null;
            int parsedvalue1, parsedvalue2;
            if (int.TryParse(value1, out parsedvalue1))
            {
                converteddouble = TryParseProperty(value2);
                if (converteddouble != null)
                    return converteddouble > parsedvalue1;
                if (int.TryParse(value2, out parsedvalue2))
                    return parsedvalue1 < parsedvalue2;
            }
            if (int.TryParse(value2, out parsedvalue2))
            {
                converteddouble = TryParseProperty(value1);
                if (converteddouble != null)
                    return converteddouble < parsedvalue2;
            }
            Log("ERROR 102: Invalid comparison between '" + value1 + "' and '" + value2 +
                "'. Make sure one is a number and the other a property name");
            Abort(102);
            return true;
        }

        public void ContinueWhile(List<string> words)
        {
            int loops = 0;
            ValidateWordCount(words.Count, 3);
            words.RemoveAt(0);
            while (EvalBoolStatement(words))
            {
                loops++;
                if (loops > 1000)
                {
                    Log("ERROR 109: Infinite loop detected");
                    Abort(109);
                    return;
                }
                colonyBuilder.Continue();
            }
        }

        public void SwitchVills(List<string> words)
        {
            ValidateWordCount(words.Count, 4);
            Resource fromresource = TryParseResource(words[1]);
            Resource toresource = TryParseResource(words[2]);
            int amount;
            if (!int.TryParse(words[3], out amount))
            {
                Log("ERROR 104: Invalid amount given");
                Abort(104);
            }
            colonyBuilder.colony.SwitchVills(fromresource, toresource, amount);
        }

        public void AllocateVills(List<string> words)
        {
            ValidateWordCount(words.Count, 4);
            int food, wood, coin;
            if (int.TryParse(words[1], out food)
                && int.TryParse(words[2], out wood) 
                && int.TryParse(words[3], out coin))
            {
                colonyBuilder.colony.AllocateVills(food, wood, coin);
            }
            else
            {
                Log("ERROR 104: Invalid ratio given for vills to allocate");
                Abort(104);
            }
        }

        public void AllocateBoats(List<string> words)
        {
            ValidateWordCount(words.Count, 3);
            int food, coin;
            if (int.TryParse(words[1], out food)
                && int.TryParse(words[2], out coin))
            {
                colonyBuilder.colony.AllocateBoats(food, coin);
            }
            else
            {
                Log("ERROR 104: Invalid ratio given for vills to allocate");
                Abort(104);
            }
        }

        public void AllocateBuildings(string sresource)
        {
            colonyBuilder.colony.buildingsGathering = TryParseResource(sresource);
        }

        public void Dance(List<string> words)
        {
            if (colonyBuilder.GetType() != typeof(NativeColonyBuilder))
            {
                Log("This civ can't dance");
                Abort(118);
            }

            var fp = ((NativeColony)colonyBuilder.colony).firePit;
            if (fp == null)
            {
                Log("We don't have a fire pit to dance at");
                Abort(119);
            }

            ValidateWordCount(words.Count, 2);

            int amountofvills;
            if (int.TryParse(words[1], out amountofvills))
            {
                ((NativeColonyBuilder)colonyBuilder).AddDancers(amountofvills);
                return;
            }

            Dance dance;
            if (Enum.TryParse(words[1], out dance) && fp.allowedDances.Contains(dance))
                fp.dance = dance;
            else
            {
                Log("Unknown dance '" + words[1] + "'");
                Abort(117);
            }
        }

        public void TravoisBuilding(string buildingname)
        {
            if (colonyBuilder.colony is Iroquois)
            {
                if (cBuilding.GetFieldByName(buildingname) == null)
                {
                    Log("Travois can't build '" + buildingname + "' because it is not a valid building");
                    return;
                }
                ((Iroquois)colonyBuilder.colony).travoisBuilding = buildingname;
            }
        }

        public void Import(List<string> words)
        {
            ValidateWordCount(words.Count, 2);
            var importer = new FunctionImporter(words[1]);

            if (importer.reader == null)
            {
                Log("Function file '" + words[1] + "' not found. Make sure it's in [app directory]/import/");
                Abort(123);
            }

            foreach (Function function in importer.ImportFunctions())
            {
                if (functions.Find(func => func.name == function.name) == null)
                    functions.Add(function);
                else
                    Log("Failed to import function with name '" + function.name + "' because a function by that name was already imported");
            }
        }

        public void VariableAssignment(List<string> words)
        {
            ValidateWordCount(words.Count, 3);

            if (words[1] != "=")
            {
                Log("ERROR 114: Missing assignment operator '='");
                Abort(114);
            }

            var varname = words[0].Substring(1);
            words.RemoveAt(0);
            var variable = FindVariableByName(varname);
            if (variable == null)
            {
                variables.Add(new Variable(varname));
                variable = variables[variables.Count - 1];
            }
            ParseVariables(words);

            if (words.Count == 2)
            {
                double? parsedproperty = TryParseProperty(words[1]);
                if (parsedproperty != null)
                    variable.value = parsedproperty.ToString();
                else
                variable.value = words[1];
            }
            else if (words.Count >= 4)
                VariableOperation(variable, words);
            else
            {
                Log("ERROR 105: Incomplete statement");
                Abort(105);
            }
        }

        public void VariableOperation(Variable variable, List<string> words)
        {
            double? value1, value2;
            try
            {
                value1 = Convert.ToDouble(words[1]);
            }
            catch (FormatException)
            {
                value1 = TryParseProperty(words[1]);
                if (value1 == null)
                {
                    variable.value = words[1] + words[3];
                    return;
                }
            }
            try
            {
                value2 = Convert.ToDouble(words[3]);
            }
            catch (FormatException)
            {
                value2 = TryParseProperty(words[3]);
                if (value2 == null)
                {
                    Log("ERROR 113: Can't resolve operation: given value types are not the same");
                    Abort(113);
                }
            }
            switch (words[2])
            {
                case "+":
                    variable.value = (value1 + value2).ToString();
                    break;
                case "-":
                    variable.value = (value1 - value2).ToString();
                    break;
                case "*":
                    variable.value = (value1 * value2).ToString();
                    break;
                case "/":
                    variable.value = (value1 / value2).ToString();
                    break;
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

        public void Return(List<string> words)
        {
            if (words.Count == 1)
                returnable = "";
            else
                returnable = words[1];
            linecursor = lines.Count - 1;
        }

        public static string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public void ValidateWordCount(int wordcount, int expectedwordcount)
        {
            if (wordcount < expectedwordcount)
            {
                Log("ERROR 105: Incomplete statement");
                Abort(105);
            }
        }
    }
}
