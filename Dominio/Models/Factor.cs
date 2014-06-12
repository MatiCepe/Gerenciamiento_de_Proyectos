using System.Collections.Generic;

namespace Dominio.Models
{
    public class Factor : BaseModel
    {
        public int FactorId { get; set; }

        public virtual ICollection<Valor> ValoresSeleccionados { get; set; }
    }

}