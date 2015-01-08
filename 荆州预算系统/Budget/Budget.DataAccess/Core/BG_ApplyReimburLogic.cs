using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace BudgetWeb.BLL
{
    public class BG_ApplyReimburLogic
    {
        //public static DataTable GetARMon(int ppid, int DepID, string ARTime)
        //{
        //    DataTable dt = null;
        //    try
        //    {
        //        string str = string.Format("select sum(ARMon) as ARMon from BG_ApplyReimbur where ppid={0} and DepId={1} and  convert(varchar(7),ARTime,120)='{2}' and ARListSta='审核通过'", ppid, DepID, ARTime);
        //        dt = DBUnity.AdapterToTab(str);
        //    }
        //    catch
        //    {
        //        dt = null;
        //    }
        //    return dt;
        //}

        public static decimal GetARMon(int ppid, int DepID, string YearMonth)
        {
            decimal tt = 0;
            try
            {
                string str = string.Format("select BQMon from V_Cashier_PayIncome where piid={0} and Depid={1} and Convert(varchar(7),Ctime,120)<'{2}'", ppid, DepID, YearMonth);
                tt = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, str, null));
                 
            }
            catch
            {
                tt = 0;
            }
            return tt;
        }

        public static DataTable GetARMonByARTime(string ARTime, int depid)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format("select sum(ARMon) as ARMon from  dbo.BG_ApplyReimbur  where ARListSta='审核通过' and  Convert(varchar(7),ARTime,120)='{0}' and DepId={1}  ", ARTime, depid);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }
        public static decimal  GetARUseMon(int ppid, int DepID, int Year)
        { 
            string str = string.Format("select sum(ARMon) as ARMon from BG_ApplyReimbur where ppid={0} and DepId={1} and  Year(ARTime)={2} and ARListSta='审核通过'", ppid, DepID, Year);
             decimal t = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, str, null));
            return t;
        }

        public static bool ISApplyBackMon(string ARTime, int DepID)
        {
            bool flag = false;
            try
            {
                string str = string.Format("select sum(ARMon) as ARMon from BG_ApplyReimbur where ppid={0} and DepId={1} and  convert(varchar(7),ARTime,120)='{2}'  and ARListSta='退回'", DepID, ARTime);
                int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text,str,null));
                if (t>0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public static decimal ApplyMon(string ARTime, int DepID)
        {
            decimal t = 0;
            try
            {
                string str = string.Format("select sum(ARMon) as ARMon from BG_ApplyReimbur where DepId={0} and  convert(varchar(7),ARTime,120)<='{1}'", DepID, ARTime);
                t =ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, str, null).ToString());
            }
            catch
            {
                t = 0;
            }
            return t;
        }

        public static decimal ApplyBackMon(string ARTime, int DepID)
        {
            decimal t = 0;
            try
            {
                string str = string.Format("select sum(ARMon) as ARMon from BG_ApplyReimbur where DepId={0} and  convert(varchar(7),ARTime,120)<='{1}' and ARListSta='退回'", DepID, ARTime);
                t = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, str, null).ToString());
            }
            catch
            {
                t = 0;
            }
            return t;
        }
    }
}
