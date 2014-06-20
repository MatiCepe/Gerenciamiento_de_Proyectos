using GP.MVP.ServicioValor;
using GP.MVP.Views;

namespace GP.MVP.Presenters
{
    public class ValorListarPresenter: BasePresenter<IValorListarView>
    {
        private readonly IValorListarView _view;
        private readonly ServicioValorClient _servicioValor;

        public ValorListarPresenter(IValorListarView view, ServicioValorClient servicioValor):
            base(view)
        {
            this._view = view;
            this._servicioValor = servicioValor;
        }

        public override void  Init()
        {
            var valores = this._servicioValor.ObtainAll();

            this._view.ListarValores(valores);
            this._view.Seleccionar += OnValorSeleccionadoEvent;
        }

        public void OnValorSeleccionadoEvent()
        {
            var id = this._view.ValorSeleccionado;
            if (id !=0 )
            {
                var valor = this._servicioValor.ObtainId(id);
                this._view.MostrarValor(valor);
            }
        }
    }
}
