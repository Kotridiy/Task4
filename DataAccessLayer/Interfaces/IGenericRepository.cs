namespace DataAccessLayer.Interfaces
{
    public interface IGenericRepository<T>
    {
        T Get(string name);
        void AddAndSave(T entity);
    }
}
