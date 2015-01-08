using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial  class FA_PayIncomeManager
    {
        public static DataTable GetPayIncomeByPItype(string pitype)
        {
            return FA_PayIncomeService.GetPayIncomeByPItype(pitype);
        }

        public static FA_PayIncome GetPayIncomeByPIecosubname(string piecosubname)
        {
            return FA_PayIncomeService.GetPayIncomeByPIecosubname(piecosubname);
        }

        public static DataTable GetGroupFA_PayIncome(string incomeinfo, string ftype, int tem)
        {
            return FA_PayIncomeService.GetGroupFA_PayIncome(incomeinfo, ftype, tem);
        }

        public static bool GetBoolPayIncome(string incomeinfo, string ftype, int piid)
        {
            return FA_PayIncomeService.GetBoolPayIncome(incomeinfo, ftype, piid);
        }

        public static DataTable GetGroupFA_PayIncome(int tem)
        {
            return FA_PayIncomeService.GetGroupFA_PayIncome(tem);
        }

        public static bool GetBoolPayIncome(int piid)
        {
            return FA_PayIncomeService.GetBoolPayIncome(piid);
        }
    }
}
