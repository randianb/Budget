using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
   public static partial class FA_AccConNumManager
    {
        public static FA_AccConNum GetAccConNumByYear(int acnyear)
        {
            return FA_AccConNumService.GetAccConNumByYear(acnyear);
        }

        public static int GetAccConNumCountByYear(int acnyear)
        {
            return FA_AccConNumService.GetAccConNumCountByYear(acnyear);
        }
    }
}
