using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Common.Extentions

{
  public static  class PadValues
    {
        public static string PadZeros( this string zero)
        {
            
            int lenght = 6;
            string pad = "";
            for (var i = zero.Length; i < lenght; i++)
            {
                pad += "0";
            }

            return pad + zero.ToString();
        }

        public static string PadZeros(this string zero, int lenght)
        {
            string pad = "";
            for (var i = zero.Length; i < lenght; i++)
            {
                pad += "0";
            }

            return pad + zero.ToString();
        }
    }
}
