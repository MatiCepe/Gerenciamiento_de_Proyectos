using GP.Dominio.Models;

namespace GP.Repositorio.Interfaces
{
    public interface IGerenteRepository
    {
        Gerente GetByID(int id);
    }
}