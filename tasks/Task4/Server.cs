using System;

namespace Task4
{
    class Server : IHardware
    {
        private string _cpuType;
        private int _diskSpace;
        private int _ram;
        private decimal _price;
        private int _he;
        private string _hostname;

        public string CPUType
        {
            get
            {
                return this._cpuType;
            }
            set
            {
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
            get
            {
                return _price;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("Price must be >0", nameof(value));
                this._price = value;
            }
        }

        public string Hostname
        {
            get
            {
                return _hostname;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Hostname must not be empty.", nameof(value));
                this._hostname = value;
            }
        }

        public int HE
        {
            get
            {
                return _he;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("HE must be >0", nameof(value));
                this._he = value;
            }
        }

        public Server(string cpuType, int diskSpace, int ram, decimal price, string hostname, int he)
        {
            this.CPUType = cpuType;
            this.DiskSpace = diskSpace;
            this.RAM = ram;
            this.Price = price;
            this.Hostname = hostname;
            this.HE = he;
        }

        public void Print()
        {
            Console.WriteLine("\n-----------");
            Console.WriteLine("CPU Type: \t" + this.CPUType);
            Console.WriteLine("Disk Space: \t" + this.DiskSpace + " GB");
            Console.WriteLine("RAM: \t\t" + this.RAM + " GB");
            Console.WriteLine("Price: \t\t" + this.Price + " Euro");
            Console.WriteLine("Hostname: \t" + this.Hostname);
            Console.WriteLine("HE: \t\t" + this.HE);
            Console.WriteLine("-----------\n");
        }
    }
}