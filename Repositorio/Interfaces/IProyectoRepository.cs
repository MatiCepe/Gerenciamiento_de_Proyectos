using GP.Dominio.Models;

namespace GP.Repositorio.Interfaces
{
    public interface IProyectoRepository
    {
        Proyecto GetByID(int id);
    }
}
