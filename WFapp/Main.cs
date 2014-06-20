using System;
using System.Windows.Forms;

namespace GP.WFapp
{
    public partial class Main : Form
    {
        private frmValorEditar _frmValorEditar;
        private FrmFactorEditar _frmFactorEditar;
        private FrmFactorListar _frmFactorListar;
        private FrmValorListar _frmValorListar;

        public Main()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmFactorEditar == null)
                _frmFactorEditar = new FrmFactorEditar(0,this);

            _frmFactorEditar.Show();
            this.Hide();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmFactorListar == null)
                _frmFactorListar = new FrmFactorListar(this);

            _frmFactorListar.Show();
            this.Hide();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_frmValorEditar == null)
                _frmValorEditar = new frmValorEditar(0,this);

            _frmValorEditar.Show();
            this.Hide();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_frmValorListar == null)
                _frmValorListar = new FrmValorListar(this);

            _frmValorListar.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

    }
}
