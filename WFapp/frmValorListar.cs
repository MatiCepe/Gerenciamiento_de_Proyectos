using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GP.DTO.DTO;
using GP.MVP.Presenters;
using GP.MVP.Views;
using GP.Gestores.Gestores;

namespace WFapp
{
    public partial class FrmValorListar : Form,IValorListarView
    {
        private readonly ValorListarPresenter _presenter;
        private int _idValor;

        public FrmValorListar()
        {
            _presenter = new ValorListarPresenter(this, new ValorGestor());
            InitializeComponent();
        }

        public IList<ValorDTO> Valores
        {
            get { return this.dataGridListaValores.DataSource as IList<ValorDTO>; }
        }

        private void FrmValorListarLoad(object sender, EventArgs e)
        {
            _presenter.Init();
            this.dataGridListaValores.CellClick += OnCellSelected;
        }

        public void OnCellSelected(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                 _idValor = (int)dataGridListaValores.Rows[e.RowIndex].Cells["ValorId"].Value;
                this._presenter.OnValorSeleccionadoEvent();
            }
        }

        public void ListarValores(IList<ValorDTO> valores)
        {
            dataGridListaValores.DataSource = valores.ToList();
            dataGridListaValores.Columns["ValorId"].Visible = false;
            dataGridListaValores.Columns["Deshabilitado"].Visible = false;
            dataGridListaValores.Columns["Nombre"].DisplayIndex = 0;
        }

        public event Action Seleccionar;

        public int ValorSeleccionado
        {
            get { return _idValor; }
        }

        public void MostrarValor(ValorDTO valor)
        {
            labelNombre.Text = valor.Nombre;
            labelInfluencia.Text = valor.Influencia.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmValorEditar formValorEditar = new frmValorEditar(0,this);
            formValorEditar.MdiParent = this.ParentForm;
            formValorEditar.Show();
            this.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmValorEditar formValorEditar = new frmValorEditar(_idValor, this);
            formValorEditar.MdiParent = this.ParentForm;
            formValorEditar.Show();
            this.Enabled = false;
        }

        private void FrmValorListar_Load(object sender, EventArgs e)
        {
            _presenter.Init();
            this.dataGridListaValores.CellClick += OnCellSelected;
        }

        public void dataGridListaValoresRefresh()
        {

        }

    }
}
