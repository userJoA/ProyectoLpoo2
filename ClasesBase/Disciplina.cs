using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClasesBase
{
    public class Disciplina
    {
        private static int NEXTID = 0;
        private int Dis_ID { get; set; }
        public string? Dis_Name { get; set; }
        public string? Dis_Description { get; set; }
        public Disciplina() 
        {
            NEXTID++;
            this.Dis_ID = NEXTID;
        }
        public void ToString()
        {
            MessageBox.Show("Nombre: " + this.Dis_Name + "\n" +
                            "Descripcion: " + this.Dis_Description + "\n" +
                            "ID: " + this.Dis_ID + "\n");
        }
    }
}
