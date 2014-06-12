using System.Linq;
using GP.Gestores.Gestores;
using GP.MVP.Views;

namespace GP.MVP.Presenters
{
    public class FactorEditarPresenter: BasePresenter<IFactorEditarView>
    {
        private readonly IFactorEditarView _view;
        private readonly FactorGestor _factorGestor;
        private readonly ValorGestor _valorGestor;

        public FactorEditarPresenter(IFactorEditarView view, FactorGestor factorGestor, ValorGestor valorGestor) :
            base(view)
        {
            this._view = view;
            this._factorGestor = factorGestor;
            this._valorGestor = valorGestor;
        }

        public override void  Init()
        {
            _view.Guardar += OnGuardarFactor;

            GetFactor();
        }

        public void OnGuardarFactor()
        {
            if (_view.IdFactor>0)
            {
                _factorGestor.Edit(_view.Factor);
            }
        }

        public void ObtenerValoresNoSeleccionados()
        {
            _view.ValoresNoSeleccionados = _valorGestor.ObtainAll().ToList();
        }

        private void GetFactor()
        {
            _view.Factor = _factorGestor.ObtainId(_view.IdFactor);
        }

    }
}
