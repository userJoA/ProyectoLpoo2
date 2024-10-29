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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para UCFormCreatePart.xaml
    /// </summary>
    public partial class UCFormCreatePart : UserControl
    {
        public UCFormCreatePart()
        {
            InitializeComponent();
            Atleta oAtl= new Atleta();
            this.DataContext = oAtl;
        }
        private bool ValidarFormulario()
        {

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("El campo Apellido es obligatorio.");
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtDNI.Text) || !int.TryParse(txtDNI.Text, out _))
            {
                MessageBox.Show("El campo DNI es obligatorio y debe contener solo números.");
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtWeight.Text) || !double.TryParse(txtWeight.Text, out _))
            {
                MessageBox.Show("El campo Peso es obligatorio y debe contener solo números.");
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtHeight.Text) || !double.TryParse(txtHeight.Text, out _))
            {
                MessageBox.Show("El campo Altura es obligatorio y debe contener solo números.");
                return false;
            }


            return true;
        }
        private void btnCrateAtl_Click(object sender, RoutedEventArgs e)
        {
            if(ValidarFormulario())
            {
                Atleta oAtl = new Atleta();
                oAtl.Atl_Name = txtName.Text;
                oAtl.Atl_LastName = txtLastName.Text;
                oAtl.Atl_DNI = Convert.ToInt32(txtDNI.Text);
                oAtl.Atl_Height = Convert.ToDouble(txtHeight.Text);
                oAtl.Atl_Weight = Convert.ToDouble(txtWeight.Text);
                oAtl.ToString();
                TrabajarAtletas.addAtl(oAtl);
                MessageBox.Show("Participante agregado correctamente.");
            }
        }
    }
}
