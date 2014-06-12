using System.Linq;
using Dominio.Models;
using Repositorio.Interfaces;

namespace Repositorio.Repositories
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