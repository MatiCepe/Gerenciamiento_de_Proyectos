using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GP.DTO.DTO;
using GP.Gestores.Gestores;
using GP.MVP.Presenters;
using GP.MVP.Views;

namespace GP.WFapp
{
    public partial class FrmFactorEditar : Form, IFactorEditarView
    {
        private readonly FactorEditarPresenter _presenter;
        private FactorDTO _factorDto;
        private Main _main;

        public FrmFactorEditar(int factorId, Main main) : this(factorId)
        {
            _main = main;
        }

        public FrmFactorEditar(int factorId)
        {
            InitializeComponent();

            _presenter = new FactorEditarPresenter(this, new FactorGestor(), new ValorGestor());

            IdFactor = factorId;

            ObtenerValoresNoSeleccionados();
        }

        public event Action Guardar;


        public int IdFactor { get; set; }

        public List<ValorDTO> ValoresNoSeleccionados
        {
            set
            {
                lbNoSeleccionados.DataSource = value.ToList();

                lbNoSeleccionados.Columns["Deshabilitado"].Visible = false;
                lbNoSeleccionados.Columns["ValorId"].Visible = false;
                lbNoSeleccionados.Columns["Influencia"].Width = 22;
            }
        }

        public FactorDTO Factor
        {
            get
            {
                _factorDto.Nombre = txtNombre.Text.Trim();

                return _factorDto;
            } 
            set
            {
                txtNombre.Text = value.Nombre;
                lbSeleccionados.DataSource = value.ValoresSeleccionados.ToList();

                lbSeleccionados.Columns["Deshabilitado"].Visible = false;
                lbSeleccionados.Columns["ValorId"].Visible = false;
                lbSeleccionados.Columns["Influencia"].Width = 22;

                _factorDto = value;
            }
        }

        public void ObtenerValoresNoSeleccionados()
        {
            _presenter.ObtenerValoresNoSeleccionados();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void frmFactorEditar_Load(object sender, EventArgs e)
        {
            _presenter.Init();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbNoSeleccionados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbSeleccionados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
