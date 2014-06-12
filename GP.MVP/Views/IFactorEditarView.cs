using System;
using System.Collections.Generic;

using GP.DTO.DTO;

namespace GP.MVP.Views
{
    public interface IFactorEditarView: IView
    {
        event Action Guardar;

        int IdFactor { set; get; }
        List<ValorDTO> ValoresNoSeleccionados { set; }
        FactorDTO Factor { set; get; }

        void ObtenerValoresNoSeleccionados();
    }
}
