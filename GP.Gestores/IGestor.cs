using System.Collections.Generic;

namespace GP.Gestores
{
    public interface IGestor<T> where T : class
    {
        void Save(T entity);

        void Edit(T entity);

        void Enable(T entity);

        void Disable(T entity);

        T ObtainId(int id);

        IList<T> ObtainAll();

        string Validate(T entidad);
    }
}
