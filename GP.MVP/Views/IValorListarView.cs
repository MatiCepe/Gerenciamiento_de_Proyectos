using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.DTO.DTO;

namespace GP.MVP.Views
{
    public interface IValorListarView: IView
    {
        event Action Seleccionar;
        IList<ValorDTO> Valores { get; }
        int ValorSeleccionado { get;  }
        void ListarValores(IList<ValorDTO> valores);
        void MostrarValor(ValorDTO valor);
    }
}
