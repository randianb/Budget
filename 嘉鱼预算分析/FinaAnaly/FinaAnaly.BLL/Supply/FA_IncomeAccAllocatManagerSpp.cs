using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial  class FA_IncomeAccAllocatManager
    {
        public static FA_IncomeAccAllocat GetIncomeAccAllocatByIncome(int piid)
        {
            return FA_IncomeAccAllocatService.GetIncomeAccAllocatByIncome(piid);
        }

        public static bool GetIncomeAccAllocatBypiid(int piid)
        {
            return FA_IncomeAccAllocatService.GetIncomeAccAllocatBypiid(piid);
        }

        public static DataTable GetIncomeAccAllocatAll()
        {
            return FA_IncomeAccAllocatService.GetIncomeAccAllocatAll();
        }

        public static decimal GetIncomeAccAllocat()
        {
            return FA_IncomeAccAllocatService.GetIncomeAccAllocat();
        }

        public static DataTable GetIncomeMonAll()
        {
            return FA_IncomeAccAllocatService.GetIncomeMonAll();
        }
    }
}
