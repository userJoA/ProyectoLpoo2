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

        private void btnCrateAtl_Click(object sender, RoutedEventArgs e)
        {
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
