using System.Linq;
using Dominio.Models;
using Repositorio.Interfaces;

namespace Repositorio.Repositories
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
