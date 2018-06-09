using System;

namespace Task6
{
    class Switch : IHardware
    {
        private string _os;
        private int _ports;
        private decimal _price;
        private string _model;
        private int _he;
        private string _hostname;

        public string OS
        {
            get
            {
                return this._os;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("OS must not be empty.", nameof(value));
                this._os = value;
            }
        }

        public int Ports
        {
            get
            {
                return this._ports;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("Ports must be >0", nameof(value));
                this._ports = value;
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

        public string Model
        {
            get
            {
                return this._model;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Model must not be empty.", nameof(value));
                this._model = value;
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

        public Switch(string os, int ports, decimal price, string model, string hostname, int he)
        {
            this.OS = os;
            this.Ports = ports;
            this.Price = price;
            this.Model = model;
            this.Hostname = hostname;
            this.HE = he;
        }

        public void Print()
        {
            Console.WriteLine("\n-----------");
            Console.WriteLine("Model: \t\t" + this.Model);
            Console.WriteLine("OS: \t\t" + this.OS);
            Console.WriteLine("Ports: \t\t" + this.Ports);
            Console.WriteLine("Price: \t\t" + this.Price + " Euro");
            Console.WriteLine("Hostname: \t" + this.Hostname);
            Console.WriteLine("HE: \t\t" + this.HE);
            Console.WriteLine("-----------\n");
        }
    }
}