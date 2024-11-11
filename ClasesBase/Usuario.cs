using System.ComponentModel;
using System.Windows;


namespace ClasesBase
{
    public class Usuario : IDataErrorInfo, INotifyPropertyChanged
    {
        private int usu_ID;
        private string? usu_Name;
        private string? usu_Password;
        private string? usu_FullName;
        private string? usu_LastName;
        private string? usu_NameO;
        private Roles? rol;

        public int Usu_ID
        {
            get => usu_ID;
            set
            {
                if (usu_ID != value)
                {
                    usu_ID = value;
                }
            }
        }

        public string? Usu_Name
        {
            get => usu_Name;
            set
            {
                if (usu_Name != value)
                {
                    usu_Name = value;
                    Notificador(Usu_Name);
                }
            }
        }

        public string? Usu_Password
        {
            get => usu_Password;
            set
            {
                if (usu_Password != value)
                {
                    usu_Password = value;
                    Notificador(usu_Password);
                }
            }
        }

        public string? Usu_FullName
        {
            get => usu_FullName;
            set
            {
                if (usu_FullName != value)
                {
                    usu_FullName = value;
                    Notificador(usu_FullName);
                }
            }
        }

        public string? Usu_LastName 
        { 
            get => usu_LastName;
            set
            {   
                if(usu_LastName != value)
                {
                    usu_LastName = value;
                    UpdateFullName();
                    Notificador(usu_LastName);
                }
                
            } 
        }

        public string? Usu_NameO 
        { 
            get => usu_NameO;
            set 
            {
                if(usu_NameO != value)
                {
                    usu_NameO = value;
                    UpdateFullName();
                    Notificador(usu_NameO);
                }
               
            } 
        }

        public Roles? Rol  // Propiedad de tipo Roles
        {
            get => rol;
            set
            {
                if (rol != value)
                {
                    rol = value;
                    Notificador(nameof(Rol));
                }
            }
        }

        // Método que actualiza el FullName
        private void UpdateFullName()
        {
            Usu_FullName = $"{Usu_LastName} {Usu_NameO}".Trim();
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }


        public string this[string columnName]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void ToString()
        {
            MessageBox.Show("Usuario: " + Usu_Name + "\n" +
                            "Contraseña: " + Usu_Password + "\n" +
                            "Nombre y Apellido: " + Usu_FullName + "\n" +
                            "ID: " + Usu_ID + "\n" +
                            "Apellido: " + Usu_LastName + "\n" +
                            "Nombre: " + Usu_NameO + "\n" +
                            "Rol: " + (Rol?.Rol_Description ?? "Sin rol") + "\n");
        }

        // Constructor
        public Usuario() 
        {   
            this.rol = new Roles();
        }

        // Implementación de INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Notificador(String pop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pop));
            }
        }
    }
}
