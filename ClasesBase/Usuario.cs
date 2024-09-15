using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    public class Usuario
    {
        private int Usu_ID {  get; set; }
        private string Usu_Name { get; set; }
        private string Usu_Password { get; set; }
        private string Usu_FullName { get; set; }
        private int Rol_Code { get; set; }

        public Usuario() { }
    }
}
