using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ClasesBase
{
    public class ConversorDeEstados : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Recibimos el estado como un string
            string? estado = value as string;

            // Según el estado, devolvemos un Brush (color)
            switch (estado)
            {
                case "programado":
                    return Brushes.Green;
                case "postergado":
                    return Brushes.Yellow;
                case "reprogramado":
                    return Brushes.Orange;
                case "cancelado":
                    return Brushes.Red;
                default:
                    return Brushes.Transparent; // Por defecto un color neutral
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
