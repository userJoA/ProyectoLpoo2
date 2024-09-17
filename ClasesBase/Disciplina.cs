using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    public class Disciplina
    {
        private static int NEXTID = 0;
        private int Dis_ID { get; set; }
        private string? Dis_Name { get; set; }
        private string? Dis_Description { get; set; }
        public Disciplina() 
        {
            NEXTID++;
            this.Dis_ID = NEXTID;
        }
    }
}
