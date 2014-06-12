using System.Linq;
using Dominio.Models;
using Repositorio.Interfaces;

namespace Repositorio.Repositories
{
    public class GerenteRepository : BaseRepository<Gerente>, IGerenteRepository
    {
        public Gerente GetByID(int id)
        {
            return GerenciamientoProyectosContext.Set<Gerente>()
                .FirstOrDefault(x => x.GerenteId == id);
            
        }
    }
}
