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
    /// Lógica de interacción para CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControl
    {
        public CategoriesView()
        {
            InitializeComponent();         
        }

        public void clear() 
        {
            txtDescription.Clear();
            txtName.Clear();    
        }
        private void btnCreateCat_Click(object sender, RoutedEventArgs e)
        {
            Categoria oCat = new Categoria();
            oCat.Cat_Name=txtDescription.Text;
            oCat.Cat_Description=txtDescription.Text;
            oCat.ToString();
            clear();
        }
    }
}
