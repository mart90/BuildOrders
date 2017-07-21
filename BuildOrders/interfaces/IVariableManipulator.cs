using System.Collections.Generic;

namespace BuildOrders
{
    interface IVariableManipulator
    {
        void UpdateVariables(List<Variable> variables);
        Variable FindVariableByName(string name);
    }
}
