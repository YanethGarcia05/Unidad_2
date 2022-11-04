using Datos;

namespace Vista
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //Alba
        private async void AceptarButton_Click(object sender, EventArgs e)
        {
            if (CodigoUsuarioTextBox.Text==String.Empty)
            { 
                errorProvider1.SetError(CodigoUsuarioTextBox, "Ingrese un codigo de usuario");
                CodigoUsuarioTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (ClaveTextBox.Text==String.Empty)
            {
                errorProvider1.SetError(ClaveTextBox, "Ingrese una clave");
                ClaveTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            UsuarioDatos userDatos=new UsuarioDatos();

            bool valido = await userDatos.LoginAsync(CodigoUsuarioTextBox.Text, ClaveTextBox.Text);
            if (valido)
            {
                Menu formulario = new Menu();
                Hide();//se oculte formulario login
                formulario.Show();
            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}