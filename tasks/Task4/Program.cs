using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
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

            Console.WriteLine("\nPrinting Objects...\n");
            for(int i = 0; i < h1.Length; i++)
            {
                h1[i].Print();
            }

            Console.WriteLine("\nSerializing Objects...\n");
            JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            string serial = JsonConvert.SerializeObject(h1, settings);
            Console.WriteLine("\n-----------");
            Console.WriteLine(serial);
            Console.WriteLine("-----------");

            Console.WriteLine("\nWriting Objects to File...\n");
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktopPath, "hardware.json");
            File.WriteAllText(filename, serial);

            Console.WriteLine("\nReading Objects from File...\n");
            string textFromFile = File.ReadAllText(filename);
            Console.WriteLine(textFromFile);


            Console.WriteLine("\nPrinting Read Objects from File...\n");
            IHardware[] h2 = JsonConvert.DeserializeObject<IHardware[]>(textFromFile, settings);
            for (int i = 0; i < h1.Length; i++)
            {
                h2[i].Print();
            }
        }   
    }
}
