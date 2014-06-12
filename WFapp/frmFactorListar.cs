using System;
using System.Collections.Generic;
using System.Windows.Forms;

using GP.DTO.DTO;
using GP.Gestores.Gestores;
using GP.MVP.Presenters;
using GP.MVP.Views;

namespace WFapp
{
    public partial class FrmFactorListar : Form, IFactorListarView
    {
        private readonly FactorListarPresenter _presenter;

        public FrmFactorListar()
        {
            InitializeComponent();

            _presenter = new FactorListarPresenter(this, new FactorGestor());
        }

        public event Action BuscarFactores;
        public event Action Seleccionado;

        public IList<FactorDTO> Factores
        {
            set
            {
                dgvFactores.DataSource = null;
                dgvFactores.Rows.Clear();

                dgvFactores.DataSource = value;

                dgvFactores.Columns["Deshabilitado"].Visible = false;
                dgvFactores.Columns["ValoresSeleccionados"].Visible = false;
            }
        }

        public int FactorSeleccionado
        {
            get{
               return (dgvFactores.SelectedRows.Count > 0) ? (int) dgvFactores.SelectedRows[0].Cells[0].Value : 0;
            }
        }

        public string FiltroNombre { 
            get { return txtNombre.Text.Trim(); }
        }

        public void MostrarDetalleFactor(FactorDTO factor)
        {
            dgValores.DataSource = factor.ValoresSeleccionados;

            dgValores.Columns["Deshabilitado"].Visible = false;
            dgValores.Columns["ValorId"].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarFactores();
        }

        private void FrmFactorListar_Load(object sender, EventArgs e)
        {
            _presenter.Init();
        }

        private void dgvFactores_SelectionChanged(object sender, EventArgs e)
        {
            Seleccionado();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var form = new FrmFactorEditar(this.FactorSeleccionado);
            form.Show();
        }

        private void FrmFactorListar_Activated(object sender, EventArgs e)
        {
            BuscarFactores();
        }
    }
}
