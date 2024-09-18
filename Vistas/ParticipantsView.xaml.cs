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
            Genders.ItemsSource = listGender;
            Countries.ItemsSource = listCountries;
        }
    }
}
