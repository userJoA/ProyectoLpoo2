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
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ParticipantsView.xaml
    /// </summary>
    public partial class ParticipantsView : UserControl
    {
        public ParticipantsView()
        {
            InitializeComponent();
            List<string> listGender = new List<string>();
            listGender.Add("MASCULINO");
            listGender.Add("FEMENINO");
            listGender.Add("NO RESP");
            listGender.Add("NO BINARIO");

            List<string> listCountries = new List<string>();
            listCountries.Add("Argentina");
            listCountries.Add("Bolivia");
            listCountries.Add("Chile");
            listCountries.Add("Colombia");
            listCountries.Add("Paraguay");
            listCountries.Add("Uruguay");
            listCountries.Add("Peru");
            listCountries.Add("Ecuador");
            cbxGenders.ItemsSource = listGender;
            cbxCountries.ItemsSource = listCountries;
        }
        public void clear() 
        { 
            txtName.Clear();
            txtLastName.Clear();
            cbxCountries.SelectedIndex = 0;
            cbxGenders.SelectedIndex = 0;
            txtHeigh.Clear();
            txtWeight.Clear();
            txtEmail.Clear();
            txtDNI.Clear();
            txtAddress.Clear();
        }

        private void btnCreatePart_Click(object sender, RoutedEventArgs e)
        {
            if (!validateFields()) 
            {
                MessageBox.Show("algunos campos estan vacios o en el formato incorrecto");
                return;
            }
            Atleta oAtl = new Atleta();
            oAtl.Atl_Name = txtName.Text;
            oAtl.Atl_LastName = txtLastName.Text;
            oAtl.Atl_Nationality=cbxCountries.SelectedItem.ToString();
            oAtl.Atl_Gender=cbxGenders.SelectedItem.ToString();
            oAtl.Atl_Heigth = Convert.ToDouble(txtHeigh.Text) ;
            oAtl.Atl_Weight= Convert.ToDouble(txtWeight.Text) ;
            oAtl.Atl_Email= txtEmail.Text;
            oAtl.Atl_DNI=Convert.ToInt32 (txtDNI.Text) ;
            oAtl.Atl_Address= txtAddress.Text;
            oAtl.Atl_BirthDate =Convert.ToDateTime (dtpBirthDate.SelectedDate);

            oAtl.ToString();
            clear();

        }
        public bool validateFields()
        {
            bool validate = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                validate = false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                validate = false;
            }

            if (string.IsNullOrEmpty(txtDNI.Text) || ValidationC.CanConvertToInt(txtDNI.Text)==false)
            {
                validate = false;
            }

            if (string.IsNullOrEmpty(txtHeigh.Text) || ValidationC.CanConvertToDouble(txtHeigh.Text)==false)
            {
                validate = false;
            }

            if (string.IsNullOrEmpty(txtWeight.Text) || ValidationC.CanConvertToDouble(txtWeight.Text)==false)
            {
                validate = false;
            }

            if (cbxCountries.SelectedItem == null)
            {
                validate = false;
            }

            if (cbxGenders.SelectedItem == null)
            {
                validate = false;
            }
            return validate;
        }
    }
}
