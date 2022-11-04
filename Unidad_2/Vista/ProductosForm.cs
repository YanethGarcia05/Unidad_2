using Datos;
using Entidades;
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
    public partial class ProductosForm : Form
    {
        public ProductosForm()
        {
            InitializeComponent();
        }
        //objeto que permite traer los datos de nuestro producto
        ProductoDatos proDatos=new ProductoDatos();
        //luego objeto de la clase producto
        Producto producto;
        string tipoOperacion=string.Empty;

        private void ProductosForm_Load(object sender, EventArgs e)
        {
            LlenarProductos();
        }

        private async void LlenarProductos()
        {
            ProductosDataGridView.DataSource=await proDatos.DevolverListaAsync();
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            DescripcionTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            ExistenciaTextBox.Enabled = true;
            FechaDateTimePicker.Enabled = true;
            ImagenPictureBox.Enabled = true;
            AdjuntarImagenButton.Enabled = true;
        }

        private void DesabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            DescripcionTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            ExistenciaTextBox.Enabled = false;
            FechaDateTimePicker.Enabled = false;
            ImagenPictureBox.Enabled = false;
            AdjuntarImagenButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            DescripcionTextBox.Clear();
            PrecioTextBox.Clear();
            ExistenciaTextBox.Clear();
            FechaDateTimePicker.Value = DateTime.Now;
            ImagenPictureBox.Image = null;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Nuevo";
            HabilitarControles();
        }

        
        private void AdjuntarImagenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ImagenPictureBox.Image = Image.FromFile(dialog.FileName);
            }
        }
        
        private void AdjuntarImagenPictureBox_Click(object sender, EventArgs e)
        {
        }

        private async void ModificarButton_Click(object sender, EventArgs e)
        {
                if (ProductosDataGridView.SelectedRows.Count > 0)
                {
                    tipoOperacion = "Modificar";
                    HabilitarControles();
                    CodigoTextBox.ReadOnly = true;
                    CodigoTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                    DescripcionTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                    ExistenciaTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Existencia"].Value.ToString();
                    PrecioTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Precio"].Value.ToString();
                    FechaDateTimePicker.Value = Convert.ToDateTime(ProductosDataGridView.CurrentRow.Cells["FechaCreacion"].Value);

                    //consultar imagen si existe
                    byte[] imagenDeBaseDatos = await proDatos.SeleccionarImagen(ProductosDataGridView.CurrentRow.Cells["Codigo"]. Value.ToString());

                    if(imagenDeBaseDatos.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(imagenDeBaseDatos);
                        ImagenPictureBox.Image=System.Drawing.Bitmap.FromStream(ms);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
        }

        private async void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = await proDatos.EliminarAsync(ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());

                if (elimino)
                {
                    LlenarProductos();
                    MessageBox.Show("Producto eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Producto no se pudo eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty(CodigoTextBox.Text))
            {
                errorProvider1.SetError(CodigoTextBox, "Ingrese el codigo");
                CodigoTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                errorProvider1.SetError(DescripcionTextBox, "Ingrese una descripcion");
                DescripcionTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(ExistenciaTextBox.Text))
            {
                errorProvider1.SetError(ExistenciaTextBox, "Ingrese una existencia");
                ExistenciaTextBox.Focus();
                return;
            }


            if (string.IsNullOrEmpty(PrecioTextBox.Text))
            {
                errorProvider1.SetError(PrecioTextBox, "Ingrese un precio");
                PrecioTextBox.Focus();
                return;
            }

            producto = new Producto();
            //validar imagen
            if (ImagenPictureBox.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                ImagenPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                producto.Imagen = ms.GetBuffer();
            }
            else
            {
                producto.Imagen = null;
            }
            producto.Codigo = Convert.ToInt32(CodigoTextBox.Text);
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            producto.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            producto.FechaCreacion = FechaDateTimePicker.Value;

            //validar si esta creando un nuevo producto o modificanco
            if (tipoOperacion == "Nuevo")
            {
                bool inserto = await proDatos.InsertarAsync(producto);
                if (inserto)
                {
                    LlenarProductos();
                    LimpiarControles();
                    DesabilitarControles();
                    MessageBox.Show("Producto Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Producto no se pudo guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (tipoOperacion == "Modificar")
            {
                bool modifico = await proDatos.ActualizarAsync(producto);
                if (modifico)
                {
                    LlenarProductos();
                    LimpiarControles();
                    DesabilitarControles();
                    MessageBox.Show("Producto Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Producto no se pudo guardar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExistenciaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&& !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&& !char.IsControl(e.KeyChar) && (e.KeyChar !=  '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
