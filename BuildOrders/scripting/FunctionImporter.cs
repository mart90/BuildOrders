using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace BuildOrders
{
    class FunctionImporter
    {
        public FunctionImporter(string filename)
        {
            try
            {
                reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/import/" + filename + ".txt");
            }
            catch (IOException)
            {
                reader = null;
            }
        }

        public StreamReader reader;

        public List<Function> ImportFunctions()
        {
            var functions = new List<Function>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line.Substring(0, 8) != "function")
                    continue;
                var words = line.Split(' ').OfType<string>().ToList();
                if (words.Count <= 1)
                    continue;

                var function = new Function(words[1]);
                if (words.Count > 2)
                    function.AddParametersByString(words.GetRange(2, words.Count - 2));
                BuildFunction(ref function);

                if (functions.Find(func => func.name == function.name) == null)
                    functions.Add(function);
            }
            reader.Close();
            return functions;
        }

        public void BuildFunction(ref Function function)
        {
            while (true)
            {
                if (reader.EndOfStream)
                    break;

                var funcline = reader.ReadLine();
                if (funcline == "" || funcline.Substring(0, 1) != "\t")
                    break;
                while (funcline.StartsWith("\t"))
                    funcline = funcline.Substring(1);

                function.lines.Add(funcline);
            }
        }
    }
}
