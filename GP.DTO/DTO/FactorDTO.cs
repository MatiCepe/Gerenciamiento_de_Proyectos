using System.Collections.Generic;
using Dominio.Models;

namespace GP.DTO.DTO
{
    public class FactorDTO: BaseDTO
    {
        public int FactorId { get; set; }
        public virtual List<ValorDTO> ValoresSeleccionados { get; set; }
    }
}
