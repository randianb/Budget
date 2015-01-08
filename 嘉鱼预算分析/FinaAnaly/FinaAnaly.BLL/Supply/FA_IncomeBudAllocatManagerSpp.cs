using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial class FA_IncomeBudAllocatManager
    {
        public static decimal GetIncomeBudAllocat()
        {
            return FA_IncomeBudAllocatService.GetIncomeBudAllocat();
        }

        public static FA_IncomeBudAllocat GetIncomeBudAllocatByIncome(int piid)
        {
            return FA_IncomeBudAllocatService.GetIncomeBudAllocatByIncome(piid);
        }
        public static bool GetIncomeBudAllocatBypiid(int piid)
        {
            return FA_IncomeBudAllocatService.GetIncomeBudAllocatBypiid(piid);
        }

        /// <summary>
        /// 根据ID字符串查询总预算金额
        /// </summary>
        /// <param name="idStrs"></param>
        /// <param name="ibyaer"></param>
        /// <returns></returns>
        public static decimal GetIncomeBudAllocatByIBAIDYear(string idStrs, int ibyaer)
        {
            return FA_IncomeBudAllocatService.GetIncomeBudAllocatByIBAIDYear(idStrs, ibyaer);
        }

        public static decimal GetIncomeBudAllocatByPIIDYear(int piid, int ibyaer)
        {
            return FA_IncomeBudAllocatService.GetIncomeBudAllocatByPIIDYear(piid, ibyaer);
        }

        public static DataTable GetIncomeMonAll()
        {
            return FA_IncomeBudAllocatService.GetIncomeMonAll();
        }
    }
}
