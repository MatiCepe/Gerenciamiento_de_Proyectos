using GP.DTO.DTO;
using GP.Gestores.Gestores;
using GP.MVP.Presenters;
using GP.MVP.Views;
using System;
using System.Windows.Forms;

namespace GP.WFapp
{
    public partial class frmValorEditar : Form, IValorEditarView
    {
        private readonly ValorEditarPresenter _editarPresenter;
        private FrmValorListar _frmValorListar;
        private Main _main;

        public frmValorEditar(int valorId, FrmValorListar main)
            : this(valorId)
        {
            _frmValorListar = main;
        }

        public frmValorEditar(int valorId, Main main) : this(valorId)
        {
            _main = main;
        }

        public frmValorEditar(int valorId)
        {
            _editarPresenter = new ValorEditarPresenter(this, new ValorGestor());
            _editarPresenter.ValorId = valorId;
            InitializeComponent();
        }

        private void frmValorEditar_Load(object sender, EventArgs e)
        {
            _editarPresenter.Init();
            this.btnLimpiar.Click += OnClickLimpiar;
            this.btnGuardar.Click += OnClickGuardar;
        }

        public event Action Guardar;
        public event Action Limpiar;
        public event Action Volver;

        public void MostrarValor(int id)
        {
           if (id > 0)
           {
               this.txtNombre.Text = _editarPresenter.ValorDTO.Nombre;
               this.txtInfluencia.Text = _editarPresenter.ValorDTO.Influencia.ToString();
           }
           else
           {
               this.OnClickLimpiar(null, null);
           }
        }

        private void OnClickLimpiar(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.txtInfluencia.Text = "";

        }

        private void OnClickGuardar(object sender, EventArgs e)
        {
            try
            {

                ValorDTO valorDto = new ValorDTO();
                valorDto.ValorId = _editarPresenter.ValorId;
                valorDto.Deshabilitado = Convert.ToInt16(0);
                valorDto.Nombre = this.txtNombre.Text;
                valorDto.Influencia = Convert.ToInt16(this.txtInfluencia.Text);
                _editarPresenter.ValorDTO = valorDto;
                this.Guardar();
                MessageBox.Show("Se Guardó con éxito el Valor");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Existe un error al guardar");
            }
            this.Hide();
            _frmValorListar.Show();
        }

        private void frmValorEditar_FormClosing(object sender, EventArgs e)
        {
            this.Hide();
            _frmValorListar.Show();
        }
    }
}
