using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.DTO.DTO;
using GP.Gestores.Gestores;
using GP.MVP.Views;

namespace GP.MVP.Presenters
{
    public class ValorListarPresenter: BasePresenter<IValorListarView>
    {
        private readonly IValorListarView _view;
        private readonly ValorGestor _valorGestor;

        public ValorListarPresenter(IValorListarView view, ValorGestor valorGestor):
            base(view)
        {
            this._view = view;
            this._valorGestor = valorGestor;

        }

        public override void  Init()
        {
            var valores = this._valorGestor.ObtainAll();

            this._view.ListarValores(valores);
            this._view.Seleccionar += OnValorSeleccionadoEvent;
        }

        public void OnValorSeleccionadoEvent()
        {
            var id = this._view.ValorSeleccionado;
            if (id !=0 )
            {
                var valor = this._valorGestor.ObtainId(id);
                this._view.MostrarValor(valor);
            }
        }
    }
}
