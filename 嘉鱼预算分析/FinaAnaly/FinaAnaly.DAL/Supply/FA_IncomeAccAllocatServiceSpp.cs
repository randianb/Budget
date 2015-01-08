using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using FinaAnaly.Model;

namespace FinaAnaly.DAL 
{
    public static partial  class FA_IncomeAccAllocatService
    {
        public static FA_IncomeAccAllocat GetIncomeAccAllocatByIncome(int piid)
        {
            try
            {
                string sqlStr = "select * from FA_IncomeAccAllocat where PIID=" + piid;
                DataTable dt = DBUnity.AdapterToTab(sqlStr);
                if (dt.Rows.Count > 0)
                {
                    FA_IncomeAccAllocat fA_IncomeAccAllocat = new FA_IncomeAccAllocat();

                    fA_IncomeAccAllocat.IAAID = dt.Rows[0]["IAAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IAAID"];
                    fA_IncomeAccAllocat.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_IncomeAccAllocat.IAAMon = dt.Rows[0]["IAAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IAAMon"];
                    fA_IncomeAccAllocat.IAAYear = dt.Rows[0]["IAAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IAAYear"];

                    return fA_IncomeAccAllocat;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public static bool GetIncomeAccAllocatBypiid(int piid)
        {
            bool flag = false;
            try
            {
                string sqlStr = string.Format("select count(*) from FA_IncomeAccAllocat where PIID={0} ", piid);
                flag = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null)) > 0;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_IncomeAccAllocatService--GetIncomeAccAllocatBypiid");
            }
            return flag;
        }

        public static DataTable GetIncomeAccAllocatAll()
        {
            DataTable dt = null;
            try
            {
                string sql = string.Format("select a.IAAMon,b.PIEcoSubName,b.PIType from  dbo.FA_IncomeAccAllocat as a left join  dbo.FA_PayIncome as b on a.PIID=b.PIID");
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_IncomeAccAllocatService--GetIncomeAccAllocatAll");
            }
            
            return dt;
        }


        public static decimal GetIncomeAccAllocat()
        {
            decimal dcl = 0;
            try
            {
                string sqlStr = "select SUM(IAAMon)as IBAMon from FA_IncomeAccAllocat";
                string strTmp = DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null);
                dcl = ParseUtil.ToDecimal(strTmp, 0);

            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_IncomeAccAllocatService--GetIncomeAccAllocat");
            }
            return dcl;
        }

        public static DataTable GetIncomeMonAll()
        {
            DataTable dt = null;
            try
            {
                string sql = "SELECT  b.IAAMon  , a.PIEcoSubName ,a.PIType  FROM  FA_PayIncome as a INNER JOIN FA_IncomeAccAllocat as b ON a.PIID  = b.PIID ";
                sql = string.Format(sql);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_IncomeAccAllocatService--GetIncomeMonAll");
            }
            return dt;
        }
    }
}
