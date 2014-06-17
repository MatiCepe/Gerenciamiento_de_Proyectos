using System.Linq;
using GP.Dominio.Models;
using GP.Repositorio.Interfaces;

namespace GP.Repositorio.Repositories
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
