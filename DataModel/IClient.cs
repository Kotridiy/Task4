using System.Collections.Generic;

namespace DataModel
{
    public interface IClient
    {
        int Id { get; }
        string Name { get; }
        ICollection<ISoldProduct> BoughtProducts { get; }
    }
}
