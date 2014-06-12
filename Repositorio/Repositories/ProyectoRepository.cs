using System.Linq;
using Dominio.Models;
using Repositorio.Interfaces;

namespace Repositorio.Repositories
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