using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClasesBase
{
    public class ValidationC
    {

        public ValidationC() { }

        public static bool CanConvertToInt(string value)
        {
            int number;
            return int.TryParse(value, out number);
        }

        public static bool CanConvertToDouble(string valor)
        {
            double numero;
            return double.TryParse(valor, out numero);
        }
    }

}
