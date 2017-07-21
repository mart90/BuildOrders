using System;
using System.IO;
using System.Collections.Generic;

namespace BuildOrders
{
    public class ScriptParser
    {
        public ScriptParser(string filename)
        {
            logger = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/logs/" + filename + ".log");
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/scripts/" + filename + ".txt");
            while (!reader.EndOfStream)
                lines.Add(reader.ReadLine());
            reader.Close();
            RemoveTabsAndSpaces();
        }

        public List<string> lines = new List<string>();
        public StreamWriter logger;

        public void RemoveTabsAndSpaces()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i] != "")
                {
                    while (lines[i].Substring(0, 1) == "\t" || lines[i].Substring(0, 1) == " ")
                        lines[i] = lines[i].Remove(0, 1);
                }
            }
        }

        public void ExecuteScript()
        {
            CommandParser parser = new ScriptCommandParser(lines, logger, new List<Variable>(), new List<Function>());
            parser.ParseLines();
            parser.colonyBuilder.ShowAll();
            Console.Write("\nFinished script execution. Press any key to exit");
            Console.Read();
        }
    }
}
