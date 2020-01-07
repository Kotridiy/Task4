using System.Collections.Generic;

namespace DataModel
{
    public interface IManager
    {
        int Id { get; }
        string Name { get; }
        ICollection<ISoldProduct> SoldProducts { get; }
    }
}
