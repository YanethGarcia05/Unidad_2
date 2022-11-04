using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void listaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosForm usuariosForm = new UsuariosForm();
            usuariosForm.Show();
        }

        private void listaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductosForm productosForm = new ProductosForm();
            productosForm.Show();
        }
    }
}
