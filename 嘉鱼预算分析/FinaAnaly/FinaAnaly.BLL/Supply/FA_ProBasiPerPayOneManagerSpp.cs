using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;

namespace FinaAnaly.BLL
{
   public static partial class FA_ProBasiPerPayOneManager
    {
       public static bool IsProBasiPerPayOneByYear(int year)
       {
           return FA_ProBasiPerPayOneService.IsProBasiPerPayOneByYear(year);
       }
    }
}
