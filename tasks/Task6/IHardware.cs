using System;

namespace Task6
{
    public interface IHardware
    {
        string Hostname { get; set; }
        int HE { get; set; }

        void Print();
    }
}