﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    class Server
    {
        private string _cpuType;
        private int _diskSpace;
        private int _ram;
        private decimal _price;

        public string CPUType {
            get
            {
                return this._cpuType;
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("CPUType must not be empty.", nameof(value));
                this._cpuType = value;
            }
        }

        public int DiskSpace
        {
            get
            {
                return this._diskSpace;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("DiskSpace must be >0", nameof(value));
                this._diskSpace = value;
            }
        }

        public int RAM
        {
            get
            {
                return this._ram;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("RAM must be >0", nameof(value));
                this._ram = value;
            }
        }

        public decimal Price
        {
            get{
                return _price;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("Price must be >0", nameof(value));
                this._price = value;
            }
        }

        public Server(string cpuType, int diskSpace, int ram, decimal price)
        {
            this.CPUType = cpuType;
            this.DiskSpace = diskSpace;
            this.RAM = ram;
            this.Price = price;
        }

        public void PrintServer()
        {
            Console.WriteLine("\n-----------");
            Console.WriteLine("CPU Type: \t" + this.CPUType);
            Console.WriteLine("Disk Space: \t" + this.DiskSpace + " GB");
            Console.WriteLine("RAM: \t\t" + this.RAM + " GB");
            Console.WriteLine("Price: \t\t" + this.Price + " Euro");
            Console.WriteLine("-----------\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Server s1 = new Server("Intel Xeon E7-8855 v4", 2400, 128, 4959.90m);

            s1.PrintServer();
            try
            {
                s1.Price = 0;
            }catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            s1.PrintServer();

            s1.Price = 1337.0m;
            s1.PrintServer();

        }
    }
}
