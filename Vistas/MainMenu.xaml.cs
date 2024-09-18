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
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimizeMenu_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new CategoriesView();
        }

        private void btnSystem_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new SystemView();
        }

        private void btnCompetition_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content= new CompetitionsView();
        }

        private void btnParticipants_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new ParticipantsView();
        }

        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new EventsView();
        }

        private void btnDiscplines_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new DisciplinesView();
        }
    }
}
