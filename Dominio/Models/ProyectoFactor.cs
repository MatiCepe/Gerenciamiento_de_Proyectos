namespace Dominio.Models
{
    public class ProyectoFactor
    {
        public int ProyectoFactorId { get; set; }

        public virtual Factor Factor { get; set; }

        public virtual Valor ValorSeleccionado { get; set; }
    }
}
