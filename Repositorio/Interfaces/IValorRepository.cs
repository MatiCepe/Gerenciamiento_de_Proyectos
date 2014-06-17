using GP.Dominio.Models;

namespace GP.Repositorio.Interfaces
{
    interface IValorRepository
    {
        Valor GetByID(int id);
    }
}