using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial class FA_XIncomeBudAllocatManager
    {
        /// <summary>
        /// 获取所有已分配的金额
        /// </summary>
        /// <returns></returns>
        public static decimal GetXIncomeBudAllocat()
        {
            return FA_XIncomeBudAllocatService.GetXIncomeBudAllocat();
        }

        /// <summary>
        /// 根据xpiid来查询
        /// </summary>
        /// <param name="xpiid">xpiid</param>
        /// <returns></returns>
        public static FA_XIncomeBudAllocat GetXIncomeBudAllocatByIncome(int xpiid,int year)
        {
            return FA_XIncomeBudAllocatService.GetXIncomeBudAllocatByIncome(xpiid,year);
        }


        public static decimal GetXIncomeBudAllocatByPIIDYear(int piid, int ibyaer)
        {
            return FA_XIncomeBudAllocatService.GetXIncomeBudAllocatByPIIDYear(piid, ibyaer);
        }

        public static FA_XIncomeBudAllocat GetXIncomeBudAllocatBypiidyear(int piid, int ibyaer)
        {
            return FA_XIncomeBudAllocatService.GetXIncomeBudAllocatBypiidyear(piid, ibyaer);
        }

        public static DataTable GetXIncomeMonAll()
        {
            return FA_XIncomeBudAllocatService.GetXIncomeMonAll();
        }

        public static bool GetXIncomeBudAllocatBypiid(int piid)
        {
            return FA_XIncomeBudAllocatService.GetXIncomeBudAllocatBypiid(piid);
        }

        public static DataTable GetXIncomeBudAllocatByYear(int year)
        {
            return FA_XIncomeBudAllocatService.GetXIncomeBudAllocatByYear(year);

        }

        public static decimal GetSumIBAMon(int piid, int year)
        {
            return FA_XIncomeBudAllocatService.GetSumIBAMon(piid, year);
        }
        public static DataTable GetGroupPIID(int piid, int year)
        {
            return FA_XIncomeBudAllocatService.GetGroupPIID(piid, year);
        }

        public static decimal GetIBAMonByPIID(int tempiid, int year)
        {
            return FA_XIncomeBudAllocatService.GetIBAMonByPIID(tempiid, year);
        } 
    }
}
