using System;

namespace BuildOrders
{
    [Serializable]
    public class Variable
    {
        public Variable(string name, string initialvalue = null)
        {
            this.name = name;
            value = initialvalue;
        }

        public Variable() { }
        
        public string name;
        public string value;
    }
}
