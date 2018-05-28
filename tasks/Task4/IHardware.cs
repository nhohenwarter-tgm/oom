using System;

namespace Task4
{
    public interface IHardware
    {
        string Hostname { get; set; }
        int HE { get; set; }

        void Print();
    }
}