using System;
using System.Collections.Generic;

using GP.DTO.DTO;

namespace GP.MVP.Views
{
    public interface IFactorListarView: IView
    {
        event Action BuscarFactores;
        event Action Seleccionado;

        IList<FactorDTO> Factores { set; }

        int FactorSeleccionado { get; }

        string FiltroNombre { get; }

        void MostrarDetalleFactor(FactorDTO factor);
    }
}
