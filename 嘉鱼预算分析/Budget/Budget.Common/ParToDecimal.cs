using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class ParToDecimal
    {
        public static decimal ParToDel(string str)
        {
            decimal del = 0;
            if (!string.IsNullOrEmpty(str))
            {
                del = Convert.ToDecimal(str);
            }
            else
            {
                del = 0;
            }
            return del;
        }
    }
}
