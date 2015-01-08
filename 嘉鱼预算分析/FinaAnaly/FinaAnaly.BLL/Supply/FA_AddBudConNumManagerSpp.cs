using FinaAnaly.DAL;
using FinaAnaly.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinaAnaly.BLL
{
    public static partial class FA_AddBudConNumManager
    {
        public static FA_AddBudConNum GetFA_AddBudConNumByYear(int year)
        {
            return FA_AddBudConNumService.GetFA_AddBudConNumByYear(year);
        }
    }
}
