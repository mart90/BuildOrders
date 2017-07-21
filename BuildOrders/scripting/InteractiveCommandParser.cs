using System;
using System.Collections.Generic;

namespace BuildOrders
{
    public class InteractiveCommandParser : CommandParser
    {
        public InteractiveCommandParser(List<string> lines, ColonyBuilder colonybuilder, 
            List<Variable> variables, List<Function> functions)
        {
            this.lines = lines;
            this.variables = variables;
            this.functions = functions;
            colonyBuilder = colonybuilder;
        }

        public InteractiveCommandParser() { }

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

            var blockparser = new InteractiveCommandParser(blocklines, colonyBuilder, variables, functions);
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

            var blockparser = new InteractiveCommandParser(blocklines, colonyBuilder, variables, functions);
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
            Console.WriteLine(message);
        }

        public override void Abort(int exitcode)
        {
            throw new InvalidOperationException();
        }
    }
}
