using System;

namespace BuildOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/scripts/");
            System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/logs/");
            System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/import/");

            new InteractiveParser().InputLoop();
        }
    }
}
