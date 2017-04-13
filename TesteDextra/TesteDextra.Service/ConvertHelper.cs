using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDextra.Service
{
    public static class ConvertHelper
    {
        /// <summary>
        ///     Converte o objeto para Int32, caso o objeto seja nulo ou não possa ser convertido volta 0
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public static int ToInt32(this object input)
        {
            if (input != null && input != DBNull.Value)
            {
                int valor;

                input = (int)input.ToFloat();

                Int32.TryParse(input.ToString(), out valor);
                return valor;
            }
            return 0;
        }

        /// <summary>
        ///     Converte o objeto para Int32, caso o objeto seja nulo ou não possa ser convertido volta 0
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public static Int64 ToInt64(this object input)
        {
            if (input != null && input != DBNull.Value)
            {
                Int64 valor;

                input = (Int64)input.ToFloat();

                Int64.TryParse(input.ToString(), out valor);
                return valor;
            }
            return 0;
        }

        public static float ToFloat(this object input)
        {
            if (input != null && input != DBNull.Value)
            {
                float valor;
                float.TryParse(input.ToString(), out valor);
                return valor;
            }
            return 0;
        }

        /// <summary>
        ///     Converte o objeto para Decimal, caso o objeto seja nulo ou não possa ser convertido volta 0
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public static decimal ToDecimal(this object input)
        {
            if (input != null && input != DBNull.Value)
            {
                decimal valor;
                decimal.TryParse(input.ToString(), out valor);
                return valor;
            }
            return 0;
        }

        public static T ConvertTo<T>(this object value)
        {
            return value.ConvertTo(default(T));
        }

        public static T ConvertTo<T>(this object value, T defaultValue)
        {
            if (value != null && value != DBNull.Value)
            {
                try
                {
                    var destinationType = typeof(T);
                    if (value.GetType() == destinationType)
                    {
                        return (T)value;
                    }
                    var converter = TypeDescriptor.GetConverter(value);
                    if (converter.CanConvertTo(destinationType))
                    {
                        return (T)converter.ConvertTo(value, destinationType);
                    }
                    converter = TypeDescriptor.GetConverter(destinationType);
                    if (converter.CanConvertFrom(value.GetType()))
                    {
                        return (T)converter.ConvertFrom(value);
                    }

                    var cultura = new CultureInfo("pt-BR");
                    return (T)Convert.ChangeType(Math.Round(value.ConvertTo<double>(), 2), destinationType, cultura);
                }
                catch
                {
                    return defaultValue;
                }
            }
            return defaultValue;
        }
    }
}
