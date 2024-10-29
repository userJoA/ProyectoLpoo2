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
    /// Lógica de interacción para UCFormUpdatePart.xaml
    /// </summary>
    public partial class UCFormUpdatePart : UserControl
    {
        public Atleta oAtleta { get; set; }
        public UCFormUpdatePart()
        {
            InitializeComponent();
            oAtleta = new Atleta();
            this.DataContext = oAtleta;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string ID = txtBuscarID.Text;
            if (string.IsNullOrEmpty(ID) || !int.TryParse(ID, out _))
            {
                MessageBox.Show("Debe ingresar un numero.");
                return;
            }

            int atlid=Convert.ToInt32(ID);
            Atleta? oAtlEncontrado = TrabajarAtletas.GetAtlById(atlid);
            if (oAtlEncontrado == null)
            {
                MessageBox.Show("No se encontro ningun participante con el ID ingresado.");
                return;
            }

            cargarFormulario(oAtlEncontrado);

        }

        private void cargarFormulario(Atleta atleta)
        {
            txtName.Text = atleta.Atl_Name ?? string.Empty;
            txtLastName.Text = atleta.Atl_LastName ?? string.Empty;
            txtDNI.Text = atleta.Atl_DNI.ToString();
            txtHeight.Text = atleta.Atl_Weight.HasValue ? atleta.Atl_Weight.Value.ToString() : string.Empty;
            txtWeight.Text = atleta.Atl_Height.HasValue ? atleta.Atl_Height.Value.ToString() : string.Empty;
            dtpBirthDate.SelectedDate = atleta.Atl_BirthDate ?? DateTime.Now;
            cmbNationality.Text = atleta.Atl_Nationality ?? string.Empty;
            cmbGender.Text = atleta.Atl_Gender ?? string.Empty;
            txtCoach.Text = atleta.Atl_Coach ?? string.Empty;
            txtAddress.Text = atleta.Atl_Address ?? string.Empty;
            txtEmail.Text = atleta.Atl_Email ?? string.Empty;
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

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

            if(!ValidarFormulario())
            {
                return;
            }
            if (txtBuscarID.Text == "")
            {
                return ;
            }

            oAtleta.Atl_ID=Convert.ToInt32(txtBuscarID.Text);
            oAtleta.ToString();
            TrabajarAtletas.updateAtl(oAtleta);
            MessageBox.Show("datos modificados");
        }
    }
}
