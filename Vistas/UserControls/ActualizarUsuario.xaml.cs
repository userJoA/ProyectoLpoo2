using ClasesBase;
using System.Windows;
using System.Windows.Controls;

namespace Vistas.UserControls
{
    /// <summary>
    /// Lógica de interacción para ActualizarUsuario.xaml
    /// </summary>
    public partial class ActualizarUsuario : UserControl
    {
        public Usuario? oUser { get; set; }
        public ActualizarUsuario(int idUsuario)
        {
            InitializeComponent();     
            oUser = new Usuario();
            oUser = TrabajarUsuarios.traerUsuarioPorID(idUsuario);
            this.DataContext = oUser;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void cargarUsuario(int Id)
        {
            oUser=TrabajarUsuarios.traerUsuarioPorID(Id);          
        }


        private bool ValidarFormulario()
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El campo Apellido es obligatorio.");
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("El campo Nombre de usuario es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("El campo password es obligatorio.");
                return false;
            }


            return true;
        }


        private void btnActualizarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            TrabajarUsuarios.updateUsuario(oUser);
            MessageBox.Show("datos modificados");
            Content = new ABMUsuarios();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            Content=new ABMUsuarios();
        }
    }
}
