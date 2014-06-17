using System;
using System.Collections.Generic;

namespace GP.Dominio.Models
{
    public class Proyecto : BaseModel
    {
        public int ProyectoId { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public short Caracterizacion { get; set; }

        public virtual Gerente Gerente { get; set; }

        public virtual ICollection<ProyectoFactor> ProyectoFactor { get; set; }
    }
}
