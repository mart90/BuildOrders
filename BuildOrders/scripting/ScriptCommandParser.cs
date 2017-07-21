using System;
using System.IO;
using System.Collections.Generic;

namespace BuildOrders
{
    class ScriptCommandParser : CommandParser
    {
        public ScriptCommandParser(List<string> lines, StreamWriter logger, 
            List<Variable> variables, List<Function> functions, ColonyBuilder colonybuilder = null)
        {
            this.lines = lines;
            this.logger = logger;
            this.variables = variables;
            if (colonybuilder != null)
                colonyBuilder = colonybuilder;
            else
                colonyBuilder = GetColonyFromUserInput(lines[0]);
        }

        public StreamWriter logger;

        public override void While(string line)
        {
            var words = new List<string>(line.Split(' '));
            ValidateWordCount(words.Count, 3);
            var blocklines = new List<string>();
            int ignoreendwhiles = 0;

            linecursor++;
            while (true)
            {
                if (lines.Count == linecursor)
                {
                    Log("ERROR 103: Missing endwhile");
                    Abort(103);
                }
                if (lines[linecursor].Split(' ')[0] == "while")
                {
                    ignoreendwhiles++;
                }
                if (lines[linecursor] == "endwhile")
                {
                    if (ignoreendwhiles == 0)
                        break;
                    ignoreendwhiles--;
                }
                blocklines.Add(lines[linecursor]);
                linecursor++;
            }

            var blockparser = new ScriptCommandParser(blocklines, logger, variables, functions, colonyBuilder);
            int loops = 0;
            while (true)
            {
                words = new List<string>(line.Split(' '));
                ReplaceVariablesAndFunctions(words);
                if (!EvalBoolStatement(words))
                    break;
                loops++;
                if (loops > 1000)
                {
                    Log("ERROR 109: Infinite loop detected");
                    Abort(109);
                }
                blockparser.ParseLines();
                UpdateVariables(blockparser.variables);
                if (blockparser.returnable != "")
                {
                    returnable = blockparser.returnable;
                    linecursor = lines.Count - 1;
                    break;
                }
                blockparser.linecursor = 0;
            }
        }

        public override void If(List<string> words)
        {
            ValidateWordCount(words.Count, 3);
            var blocklines = new List<string>();
            int ignoreendifs = 0;

            linecursor++;
            while (true)
            {
                if (lines.Count == linecursor)
                {
                    Log("ERROR 103: Missing endif");
                    Abort(103);
                }
                if (lines[linecursor].Split(' ')[0] == "if")
                {
                    ignoreendifs++;
                }
                if (lines[linecursor] == "endif")
                {
                    if (ignoreendifs == 0)
                        break;
                    ignoreendifs--;
                }
                blocklines.Add(lines[linecursor]);
                linecursor++;
            }

            var blockparser = new ScriptCommandParser(blocklines, logger, variables, functions, colonyBuilder);
            if (EvalBoolStatement(words))
            {
                blockparser.ParseLines();
                UpdateVariables(blockparser.variables);
                if (blockparser.returnable != "")
                {
                    returnable = blockparser.returnable;
                    linecursor = lines.Count - 1;
                }
            }
        }

        public override void Log(string message)
        {
            string time = colonyBuilder.colony.Time();
            if (time.Length < 5)
            {
                time = time.Insert(0, "0");
            }
            logger.WriteLine(time + " | " + lines[linecursor] + " | " + message);
            logger.Flush();
        }

        public override void Abort(int exitcode)
        {
            colonyBuilder.ShowAll();
            Console.WriteLine("Invalid input. Errorcode " + exitcode);
            Console.ReadLine();
            logger.Close();
            Environment.Exit(exitcode);
        }
    }
}
