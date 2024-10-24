
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClasesBase
{
    public class Atleta:IDataErrorInfo
    {
        private static int NEXTID = 0;
        private int Atl_ID { get; set; }
        public string? Atl_Name { get; set; }
        public string? Atl_LastName { get; set; }
        public int Atl_DNI { get;set; }
        public string? Atl_Email { get;set;}
        public string? Atl_Nationality { get; set; }
        public string? Atl_Coach { get; set; }
        public string? Atl_Gender { get; set; }
        public double Atl_Height { get; set; }
        public DateTime Atl_BirthDate { get;set ;}
        public double Atl_Weight { get; set; }
        public string? Atl_Address { get; set; }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        
        public string this[string columnName]
        { 
            get 
            {
                string msg_error = null;
                switch (columnName)
                {
                    case "Atl_DNI":
                            msg_error = validate_DNI();
                        break;
                    case "Atl_Name":
                            msg_error = validate_name();
                        break;
                    case "Atl_LastName":
                            msg_error = validate_lastname();
                        break;
                    case "Atl_Height":
                            msg_error = validate_height();
                        break;
                    case "Atl_Weight":
                            msg_error = validate_weight();
                        break;
                }
                return msg_error;

            } 
        }

        private string validate_DNI() 
        {
            if(Atl_DNI <= 0)
            {
                return "El DNI es obligatorio.";
            }
            else if(Atl_DNI < 1000000)
            {
                return "Debe tener como minimo 7 digitos";
            }
            return null;
        }

        private string validate_name() 
        {
            if (string.IsNullOrEmpty(Atl_Name)) 
            { 
                return "El Nombre es obligatorio.";
            }

            return null;
        }

        private string validate_lastname()
        {
            if (string.IsNullOrEmpty(Atl_LastName))
            {
                return "El Apellido es obligatorio.";
            }

            return null;
        }

        private string validate_height()
        {
            if (Atl_Height <= 0)
            {
                return "La altura debe ser mayor a 0.";
            }

            return null;
        }

        private string validate_weight()
        {
            if (Atl_Weight <= 0)
            {
                return "El peso debe ser mayor a 0.";
            }

            return null;
        }

        public Atleta(string atl_Name, string atl_LastName, int atl_DNI, string atl_Email, string atl_Nationality, string atl_Coach, string atl_Gender, double atl_Height, DateTime atl_BirthDate, double atl_Weight, string atl_Address)
        {
            NEXTID++;
            this.Atl_ID = NEXTID;
            Atl_Name = atl_Name;
            Atl_LastName = atl_LastName;
            Atl_DNI = atl_DNI;
            Atl_Email = atl_Email;
            Atl_Nationality = atl_Nationality;
            Atl_Coach = atl_Coach;
            Atl_Gender = atl_Gender;
            Atl_Height = atl_Height;
            Atl_BirthDate = atl_BirthDate;
            Atl_Weight = atl_Weight;
            Atl_Address = atl_Address;
        }

        public Atleta() 
        {
            NEXTID++;
            this.Atl_ID = NEXTID;
        }

        public void ToString()
        {
            MessageBox.Show("Nombre: " + this.Atl_Name + "\n" +
                            "Apellido: " + this.Atl_LastName + "\n" +
                            "DNI: " + this.Atl_DNI + "\n" +
                            "Nacionalidad: " + this.Atl_Nationality + "\n" +
                            "Entrenador: " + this.Atl_Coach + "\n" +
                            "Genero: " + this.Atl_Gender + "\n" +
                            "Altura: " + this.Atl_Height + "\n" +
                            "Peso: " + this.Atl_Weight + "\n" +
                            "Fecha de Nacimiento: " + this.Atl_BirthDate + "\n" +
                            "Direccion: " + this.Atl_Address + "\n" +
                            "Email: " + this.Atl_Email + "\n" +
                            "ID: " + this.Atl_ID + "\n");
        }

    }
}
