using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial  class FA_DepBudAllocatManager
    {
        public static decimal GetDepBudAllocat()
        {
            return FA_DepBudAllocatService.GetDepBudAllocat();
        }

         /// <summary>
        /// 查询该年全部部门瞀预算金额 
        /// </summary>
        /// <returns>decimal</returns>
        public static decimal GetDepBudAllocatByYear(int year)
        {
            return FA_DepBudAllocatService.GetDepBudAllocatByYear(year);
        }

        public static bool GetDepBudAllocatByDepid(int depid)
        {
            return FA_DepBudAllocatService.GetDepBudAllocatByDepid(depid);
        }

        public static FA_DepBudAllocat GetDepMonByDepid(int depid)
        {
            return FA_DepBudAllocatService.GetDepMonByDepid(depid);
        }

        public static decimal GetDepMonBydepidYear(int depid, int ibyaer)
        {
            return FA_DepBudAllocatService.GetDepMonBydepidYear(depid,ibyaer);
        }

        public static FA_DepBudAllocat GetDepMonBydepiddbayear(int depid, int ibyaer)
        {
            return FA_DepBudAllocatService.GetDepMonBydepiddbayear(depid, ibyaer);
        }

        public static DataTable GetDepMonAll(int year)
        {
            return FA_DepBudAllocatService.GetDepMonAll(year);
        }
    }
}
