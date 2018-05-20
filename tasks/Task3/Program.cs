using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            IHardware[] h1 = new IHardware[5];
            h1[0] = new Server("Intel Xeon E7-8855 v4", 2400, 128, 4959.90m, "serv01", 2);
            h1[1] = new Switch("Juniper Junos", 36, 5800.00m, "Juniper EX4550", "coreswitch01", 1);
            h1[2] = new Server("Intel Xeon E7-8855 v4", 2400, 192, 5659.90m, "serv02", 2);
            h1[3] = new Switch("Juniper Junos", 48, 500.00m, "Juniper EX4200", "accessswitch01", 1);
            h1[4] = new Server("Intel Xeon E7-8855 v4", 40000, 128, 6959.90m, "serv03", 2);

            for(int i = 0; i < h1.Length; i++)
            {
                h1[i].Print();
            }

        }
    }
}
