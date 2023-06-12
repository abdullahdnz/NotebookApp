namespace MyNotebook.Data.Abstract
{
    public interface IGenericService<T>
    {
        bool Add(T entity);
        bool Edit(T entity);
        bool Delete(int id);
        T FindByID(int id);
        IEnumerable<T> GetAll();
    }
}
