using System;

namespace DataModel
{
    public interface ICsvRecord
    {
        string Client { get; }
        DateTime Date { get; }
        string Manager { get; }
        int Price { get; }
        string Product { get; }
    }
}