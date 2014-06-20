using System;
using System.Collections.Generic;
using GP.DTO.DTO;
using GP.MVP.ServicioValor;

namespace GP.MVP.Views
{
    public interface IValorListarView: IView
    {
        event Action Seleccionar;
        IList<ValorDTO> Valores { get; }
        int ValorSeleccionado { get;  }
        void ListarValores(IList<ValorDataContract> valores);
        void MostrarValor(ValorDataContract valor);
    }
}
