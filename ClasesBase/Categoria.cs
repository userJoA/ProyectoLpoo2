using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClasesBase
{
    public class Categoria
    {
        private static int NEXTID = 0;
        public int Cat_ID { get; set; }
        public string? Cat_Name { get; set; }
        public string? Cat_Description { get;set; }

        public Categoria(int cat_ID, string cat_Name, string cat_Description)
        {
            Cat_ID = cat_ID;
            Cat_Name = cat_Name;
            Cat_Description = cat_Description;
        }

        public Categoria() 
        {
            NEXTID++;
            this.Cat_ID = NEXTID;
        }
        
        public void ToString()
        {
            MessageBox.Show("Nombre: " + this.Cat_Name + "\n" +
                            "Descripcion: " + this.Cat_Description + "\n" +
                            "ID: " + this.Cat_ID + "\n");
        }
    }
}
