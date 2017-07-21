using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class Function : IVariableManipulator
    {
        public Function(string name)
        {
            this.name = name;
        }

        public string name;
        public List<Variable> localVariables = new List<Variable>();
        public List<Variable> allVariables = new List<Variable>();
        public List<string> lines = new List<string>();

        public void AddParametersByString(List<string> parameters)
        {
            foreach (string str in parameters)
                localVariables.Add(new Variable(str));
        }

        public string Execute(CommandParser lp)
        {
            allVariables.AddRange(lp.variables);
            allVariables.AddRange(localVariables);

            CommandParser parser;
            if (lp.GetType() == typeof(InteractiveCommandParser))
                parser = new InteractiveCommandParser(lines, lp.colonyBuilder, allVariables, lp.functions);
            else
                parser = new ScriptCommandParser(lines, ((ScriptCommandParser)lp).logger, allVariables, lp.functions, lp.colonyBuilder);

            while (true)
            {
                if (parser.linecursor >= lines.Count)
                    break;
                parser.ParseLine();
                parser.linecursor++;
            }
            UpdateVariables(parser.variables);
            return parser.returnable;
        }

        public Variable FindVariableByName(string name)
        {
            return allVariables.Find(var => var.name == name);
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
    }
}
