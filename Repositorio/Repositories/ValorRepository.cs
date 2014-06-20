using System.Linq;
using GP.Dominio.Models;
using GP.Repositorio.Interfaces;

namespace GP.Repositorio.Repositories
{
    public class ValorRepository : BaseRepository<Valor>, IValorRepository
    {
        public Valor GetByID(int id)
        {
            return GerenciamientoProyectosContext.Set<Valor>()
                .FirstOrDefault(x => x.ValorId == id);
        }
    }
}