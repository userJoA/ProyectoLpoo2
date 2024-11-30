using ClasesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vistas.UserControls
{
    /// <summary>
    /// Lógica de interacción para NuevoUsuario.xaml
    /// </summary>
    public partial class NuevoUsuario : UserControl
    {
        public Usuario? oUser {  get; set; }
        public NuevoUsuario()
        {
            InitializeComponent();
            oUser = new Usuario();
            this.DataContext = oUser;
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            Content=new ABMUsuarios();
        }

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (txtApellido.Text == "" || txtNombre.Text == "" || txtNombreUsuario.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Todos los campos deben estar completos.");
                return;
            }

            if (oUser.Rol.Rol_Description == "")
            {
                MessageBox.Show("Por favor, selecciona un rol para el usuario.", "Rol no seleccionado", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (TrabajarUsuarios.NuevoUsuario(oUser))
            {
                MessageBox.Show("Se agrego un nuevo usuario.");
                Content = new ABMUsuarios();
            }
            else
            {
                MessageBox.Show("Error al agregar un nuevo usuario.");
                Content = new ABMUsuarios();    
            }

        }
    }
}
