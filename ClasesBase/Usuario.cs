using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    public class Usuario
    {
        private static int NEXTID = 0;
        private int Usu_ID {  get; set; }
        public string? Usu_Name { get; set; }
        public string? Usu_Password { get; set; }
        public string? Usu_FullName { get; set; }
        public int Rol_Code { get; set; }

        public Usuario() {
            NEXTID++;
            this.Usu_ID =NEXTID;
        }
    }
}
