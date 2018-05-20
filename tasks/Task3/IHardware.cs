using System;

namespace Task3
{
    public interface IHardware
    {
        string Hostname { get; set; }
        int HE { get; set; }

        void Print();
    }
}