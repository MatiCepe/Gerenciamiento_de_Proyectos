using GP.Dominio.Models;

namespace GP.Repositorio.Interfaces

{
    public interface IFactorRepository
    {
        Factor GetByID(int id);
    }
}