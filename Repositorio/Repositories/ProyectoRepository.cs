using System.Linq;
using GP.Dominio.Models;
using GP.Repositorio.Interfaces;

namespace GP.Repositorio.Repositories
{
    public class ProyectoRepository : BaseRepository<Proyecto>, IProyectoRepository
    {
        public Proyecto GetByID(int id)
        {
                return GerenciamientoProyectosContext.Set<Proyecto>()
                    .FirstOrDefault(x => x.ProyectoId == id);
        }
    }
}