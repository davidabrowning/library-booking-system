namespace LibraryBookingSystem
{
    public interface IRepository<T> where T : IEntity
    {
        bool Exists(int id);
        T? Get(int id);
        IEnumerable<T> GetAll();
        void Add(T t);
        void Update(T t);
        void Delete(T t);
    }

    public interface IEntity
    {
        int Id { get; }
    }
}
