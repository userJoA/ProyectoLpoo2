﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClasesBase
{
    public class Atleta
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
        public double Atl_Heigth { get; set; }
        public DateTime Atl_BirthDate { get;set ;}
        public double Atl_Weight { get; set; }
        public string? Atl_Address { get; set; }

        public Atleta(string atl_Name, string atl_LastName, int atl_DNI, string atl_Email, string atl_Nationality, string atl_Coach, string atl_Gender, double atl_Heigth, DateTime atl_BirthDate, double atl_Weight, string atl_Address)
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
            Atl_Heigth = atl_Heigth;
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
                            "Altura: " + this.Atl_Heigth + "\n" +
                            "Peso: " + this.Atl_Weight + "\n" +
                            "Fecha de Nacimiento: " + this.Atl_BirthDate + "\n" +
                            "Direccion: " + this.Atl_Address + "\n" +
                            "Email: " + this.Atl_Email + "\n" +
                            "ID: " + this.Atl_ID + "\n");
        }

    }
}
