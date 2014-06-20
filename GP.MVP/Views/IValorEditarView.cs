using System;

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
