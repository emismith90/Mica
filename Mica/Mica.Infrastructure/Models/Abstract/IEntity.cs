namespace Mica.Infrastructure.Models.Abstract
{
    public interface IEntity<T>
    {
        T Id { get; set; }

        bool Equals(object obj);
        
        int GetHashCode();

        string ToString();
    }
}
