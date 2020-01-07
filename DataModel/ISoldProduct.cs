using System;

namespace DataModel
{
    public interface ISoldProduct
    {
        int Id { get; }
        DateTime Date { get; }
        IClient Client { get; }
        IManager Manager { get; }
        IProduct Product { get; }
    }
}
