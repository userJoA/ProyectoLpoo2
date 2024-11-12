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

namespace Vistas.UserControls.vistasUsuario
{
    /// <summary>
    /// Lógica de interacción para ListaDeUsuario.xaml
    /// </summary>
    public partial class ListaDeUsuario : UserControl
    {
        private CollectionViewSource vistaColeccionFiltrada;
        public ListaDeUsuario()
        {
            InitializeComponent();

            vistaColeccionFiltrada = Resources["VISTA_USER"] as CollectionViewSource;
        }

        private void txtUsuarioBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
            {
                vistaColeccionFiltrada.Filter += eventVistaUsuario_Filter;
            }
        }

        private void eventVistaUsuario_Filter(object sender, FilterEventArgs e) 
        {
            Usuario usuario = e.Item as Usuario;
            if(usuario.Usu_Name.StartsWith(txtUsuarioBusqueda.Text,StringComparison.CurrentCultureIgnoreCase))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted &= false;
            }

        }
    }
}
