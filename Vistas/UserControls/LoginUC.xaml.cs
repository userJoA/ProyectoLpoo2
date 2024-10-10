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
    /// Lógica de interacción para LoginUC.xaml
    /// </summary>
    public partial class LoginUC : UserControl
    {
        public bool logginSuccess { get; private set; }
        public Usuario oUser { get; private set; }
        public LoginUC()
        {
            InitializeComponent();
            logginSuccess = false;
            oUser = new Usuario();
        }

        public void Clear()
        {
            txtPassword.Clear();
            txtUser.Clear();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Usuario oAud = new Usuario();
            Usuario oAdmin = new Usuario();
            Usuario oOpe = new Usuario();
            oAud.Usu_Name = "auditor";
            oAud.Usu_Password = "auditor";
            oAud.Rol_Code = 1;

            oAdmin.Usu_Name = "admin";
            oAdmin.Usu_Password = "admin";
            oAdmin.Rol_Code = 2;

            oOpe.Usu_Name = "operador";
            oOpe.Usu_Password = "operador";
            oOpe.Rol_Code = 3;
            if (txtUser.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Ningun campo puede estar vacio");
                Clear();
                return;
            }

            if (txtUser.Text == "auditor" && txtPassword.Password == "auditor")
            {
                logginSuccess = true;
                oUser.Usu_Name = "auditor";
                oUser.Usu_Password = "auditor";
                oUser.Rol_Code = 1;
                MainMenu vMain = new MainMenu();
                vMain.Show();
                Application.Current.MainWindow = vMain;
                CloseParentWindow();
            }
            if (txtUser.Text == "admin" && txtPassword.Password == "admin")
            {
                logginSuccess = true;
                oUser.Usu_Name = "admin";
                oUser.Usu_Password = "admin";
                oUser.Rol_Code = 2;
                MainMenu vMain = new MainMenu();
                vMain.Show();
                Application.Current.MainWindow = vMain;
                CloseParentWindow();
            }
            if (txtUser.Text == "operador" && txtPassword.Password == "operador")
            {
                logginSuccess = true;
                oUser.Usu_Name = "operador";
                oUser.Usu_Password = "operador";
                oUser.Rol_Code = 3;
                MainMenu vMain = new MainMenu();
                vMain.Show();
                Application.Current.MainWindow = vMain;
                CloseParentWindow();
            }

            if (logginSuccess == false)
            {
                MessageBox.Show("No se encontro al usuario");
                Clear();
                return;
            }
        }

        // Método para cerrar la ventana padre
        private void CloseParentWindow()
        {
            Window parentWindow = Window.GetWindow(this);  // Obtiene la ventana que contiene el control de usuario
            if (parentWindow != null)
            {
                parentWindow.Close();  // Cierra la ventana
            }
        }
    }
}
