using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial class FA_XPayIncomeManager
    {
        public static DataTable GetXPayIncomeByXPItype(string xpitype)
        {
            return FA_XPayIncomeService.GetXPayIncomeByXPItype(xpitype);
        }

        public static FA_XPayIncome GetXPayIncomeByPIecosubname(string xpiecosubname)
        {
            return FA_XPayIncomeService.GetXPayIncomeByPIecosubname(xpiecosubname);
        }

        public static FA_XPayIncome GetXPayIncomeByPIecosubcoding(string piecosubcoding)
        {
            return FA_XPayIncomeService.GetXPayIncomeByPIecosubcoding(piecosubcoding);
        }

        public static DataTable GetXPayIncomeByPIecosubnamedt(string piecosubname)
        {
            return FA_XPayIncomeService.GetXPayIncomeByPIecosubnamedt(piecosubname);
        }

         /// <summary>
        /// 根据字符串piecosubcoding前八位来取数据
        /// </summary>
        /// <param name="piecosubcoding">piecosubcoding</param>
        /// <returns></returns>
        public static DataTable GetXPayIncomeByPIecosubcod(string piecosubcoding)
        {
            return FA_XPayIncomeService.GetXPayIncomeByPIecosubcod(piecosubcoding);
        }

        public static int GetPIEcoSubParID(int piid)
        {
            return FA_XPayIncomeService.GetPIEcoSubParID(piid);
        }


    }
}
