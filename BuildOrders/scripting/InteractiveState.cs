using System;
using System.Collections.Generic;

namespace BuildOrders
{
    [Serializable]
    public class InteractiveState
    {
        public InteractiveState(ColonyBuilder colonybuilder, List<Variable> variables, List<Function> functions, List<InteractiveState> savegames)
        {
            colonyBuilder = colonybuilder;
            this.variables = variables;
            this.functions = functions;
        }

        public ColonyBuilder colonyBuilder;
        public List<Variable> variables = new List<Variable>();
        public List<Function> functions = new List<Function>();
    }
}
