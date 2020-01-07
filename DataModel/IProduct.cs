using System.Collections.Generic;

namespace DataModel
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; }
        ICollection<ISoldProduct> SoldProducts { get; }
    }
}
