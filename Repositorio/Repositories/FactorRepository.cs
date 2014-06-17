using System.Linq;
using GP.Dominio.Models;
using GP.Repositorio.Interfaces;

namespace GP.Repositorio.Repositories
{
    public class FactorRepository : BaseRepository<Factor>, IFactorRepository
    {
        public Factor GetByID(int id)
        {
            return GerenciamientoProyectosContext.Set<Factor>()
                .FirstOrDefault(x => x.FactorId == id);
        }
    }
}
