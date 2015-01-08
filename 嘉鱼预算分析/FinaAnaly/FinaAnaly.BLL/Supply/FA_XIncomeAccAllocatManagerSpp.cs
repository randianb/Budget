using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial  class FA_XIncomeAccAllocatManager
    {
        public static DataTable GetXIncomeAccAllocatAll()
        {
            return FA_XIncomeAccAllocatService.GetXIncomeAccAllocatAll();
        }

        public static bool GetXIncomeAccAllocatBypiid(int piid)
        {
            return FA_XIncomeAccAllocatService.GetXIncomeAccAllocatBypiid(piid);
        }

        public static FA_XIncomeAccAllocat GetXIncomeAccAllocatByIncome(int piid,int year)
        {
            return FA_XIncomeAccAllocatService.GetXIncomeAccAllocatByIncome(piid,year);
        }
    }
}
