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
    /// Lógica de interacción para DisciplinesView.xaml
    /// </summary>
    public partial class DisciplinesView : UserControl
    {
        public DisciplinesView()
        {
            InitializeComponent();
        }

        public void clear() 
        {
            txtDescription.Clear();
            txtName.Clear();    
        }

        private void btnCreateDisc_Click(object sender, RoutedEventArgs e)
        {
           Disciplina oDisc= new Disciplina();
            oDisc.Dis_Name = txtName.Text;
            oDisc.Dis_Description = txtDescription.Text;
            oDisc.ToString();
            clear();
        }
    }
}
