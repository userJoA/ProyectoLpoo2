using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClasesBase
{
    public class Usuario: IDataErrorInfo
    {
        
        private int Usu_ID {  get; set; }
        public string? Usu_Name { get; set; }
        public string? Usu_Password { get; set; }
        public string? Usu_FullName { get; set; }
        public int Rol_Code { get; set; }

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

        public Usuario() {}
    }
}
