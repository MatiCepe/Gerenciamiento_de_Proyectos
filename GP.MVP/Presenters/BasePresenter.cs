using GP.MVP.Views;

namespace GP.MVP.Presenters
{
    public abstract class BasePresenter <T> where T: class, IView
    {
        private T _vista;
        
        public BasePresenter(T vista)
        {
            _vista = vista;
        }

        public IView Vista
        {
            get
            {
                return _vista;
            }
        }

        public abstract void Init();
    }
}
