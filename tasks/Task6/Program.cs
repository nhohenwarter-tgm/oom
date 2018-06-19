using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace Task6
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
            for (int i = 0; i < h1.Length; i++)
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

            var source = new Subject<Server>();
            source.Timestamp().Where(x => x.Value.DiskSpace >= 4242).Subscribe(x => Console.WriteLine($"Storage Server {x.Value.Hostname} started to boot at {x.Timestamp}"));
            Random rnd = new Random();

            var t = new Thread(() =>
            {
                for (int i = 1; i <= 30; i++)
                {
                    Server s = new Server("Intel Xeon E7-8855 v4", rnd.Next(1000, 10000), rnd.Next(128, 512), rnd.Next(1000, 100000), "serv" + i, 2);
                    Thread.Sleep(400);
                    source.OnNext(s);
                    Console.WriteLine($"Powered Up Server {s.Hostname}");
                }
            });
            t.Start();
            t.Join();

            Server[] server = new Server[10];
            for (int i = 0; i < 10; i++)
            {
                server[i] = new Server("Intel Xeon E7-8855 v4", rnd.Next(1000, 10000), rnd.Next(128, 512), rnd.Next(1000, 100000), "serv" + (i + 1), 2);
            }
            var stask = new List<Task>();

            foreach (Server s in server)
            {
                stask.Add(s.Maintenance());
            }

            foreach (Task st in stask)
            {
                st.ContinueWith(a => { Console.WriteLine("Completed!"); });
            }

            foreach (Task st in stask)
            {
                st.Wait();
            }
        }
    }
}
