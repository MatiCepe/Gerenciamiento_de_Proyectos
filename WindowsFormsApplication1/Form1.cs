using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GP.MVP.Views;

namespace WindowsFormsApplication1
{
    public partial class frmValorListar : Form, IValorListarView
    {
        public frmValorListar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ListarValores(IList valores)
        {
            throw new NotImplementedException();
        }

    }
}
