using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.MVP.Views
{
    public interface IValorEditarView: IView
    {
        event Action Guardar;
        event Action Limpiar;
        event Action Volver;
        void MostrarValor(int id);
    }
}
