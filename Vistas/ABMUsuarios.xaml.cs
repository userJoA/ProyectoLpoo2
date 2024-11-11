using ClasesBase;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Vistas.UserControls;
using Vistas.UserControls.vistasUsuario;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ABMUsuarios.xaml
    /// </summary>
    public partial class ABMUsuarios : UserControl
    {
        public ABMUsuarios()
        {
            InitializeComponent();
        }

        CollectionView Vista;
        ObservableCollection<Usuario> listaUsuarios;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cargarDatosUsuarios();
        }

        public void cargarDatosUsuarios()
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USER"];

            listaUsuarios = odp.Data as ObservableCollection<Usuario>;

            if (listaUsuarios != null && listaUsuarios.Count > 0)
            {
                Vista = (CollectionView)CollectionViewSource.GetDefaultView(listaUsuarios);
            }
            else
            {
                MessageBox.Show("No se encontraron usuarios en la base de datos.");
                panelNavegacion.IsEnabled = false;
            }
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
        }

        private void btnPrevius_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst)
            {
                Vista.MoveCurrentToLast();
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
            if (Vista.IsCurrentAfterLast)
            {
                Vista.MoveCurrentToFirst();
            }
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
             NuevoUsuario nUser = new NuevoUsuario();
             Content = nUser;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Vista.CurrentItem is Usuario usuarioActual)
            {
                int idUsuario = usuarioActual.Usu_ID;

                TrabajarUsuarios.deleteUsuario(idUsuario);

                // Elimina el usuario de la lista en memoria
                listaUsuarios.Remove(usuarioActual);

                // Mueve el cursor al último elemento (o actualiza la vista de alguna manera)
                Vista.Refresh();

                MessageBox.Show("Se eliminó el usuario correctamente.");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el usuario.");
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            int idUsuario = Convert.ToInt32(txtbId.Text);   
            ActualizarUsuario aUser = new ActualizarUsuario(idUsuario);
            Content = aUser;
        }

        private void btnListaUsuarios_Click(object sender, RoutedEventArgs e)
        {
            Content = new ListaDeUsuario();
        }
    }
}
