using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    internal class Atleta
    {
        private int Atl_ID { get; set; }
        private string Atl_Name { get; set; }
        private string Atl_LastName { get; set; }
        private int Atl_DNI { get;set; }
        private string Atl_Email { get;set;}
        private string Atl_Nationality { get; set; }
        private string Atl_Coach { get; set; }
        private string Atl_Gender { get; set; }
        private double Atl_Heigth { get; set; }
        private DateTime Atl_BirthDate { get;set ;}
        private double Atl_Weight { get; set; }
        private string Atl_Address { get; set; }

        public Atleta(int atl_ID, string atl_Name, string atl_LastName, int atl_DNI, string atl_Email, string atl_Nationality, string atl_Coach, string atl_Gender, double atl_Heigth, DateTime atl_BirthDate, double atl_Weight, string atl_Address)
        {
            Atl_ID = atl_ID;
            Atl_Name = atl_Name;
            Atl_LastName = atl_LastName;
            Atl_DNI = atl_DNI;
            Atl_Email = atl_Email;
            Atl_Nationality = atl_Nationality;
            Atl_Coach = atl_Coach;
            Atl_Gender = atl_Gender;
            Atl_Heigth = atl_Heigth;
            Atl_BirthDate = atl_BirthDate;
            Atl_Weight = atl_Weight;
            Atl_Address = atl_Address;
        }

        public Atleta() { }
    }
}
