using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
    public static partial  class FA_XIncomeAccAllocatService
    {
        public static DataTable GetXIncomeAccAllocatAll()
        {
            DataTable dt = null;
            try
            {
                string sql = string.Format("  select a.IAAMon,b.PIEcoSubName,b.PIType from  dbo.FA_XIncomeAccAllocat as a left join  dbo.FA_XPayIncome as b on a.PIID=b.PIID");
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XIncomeAccAllocatService--GetXIncomeAccAllocatAll");
            }

            return dt;
        }

        public static bool GetXIncomeAccAllocatBypiid(int piid)
        {
            bool flag = false;
            try
            {
                string sqlStr = string.Format("select count(*) from FA_XIncomeAccAllocat where PIID={0} ", piid);
                flag = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null)) > 0;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XIncomeAccAllocatService--GetXIncomeAccAllocatBypiid");
            }
            return flag;
        }

        public static FA_XIncomeAccAllocat GetXIncomeAccAllocatByIncome(int piid,int year)
        {
            try
            {
                string sqlStr = "select * from FA_XIncomeAccAllocat where PIID={0} and IAAYear={1}";
                sqlStr = string.Format(sqlStr, piid, year);
                DataTable dt = DBUnity.AdapterToTab(sqlStr);
                if (dt.Rows.Count > 0)
                {
                    FA_XIncomeAccAllocat fA_XIncomeAccAllocat = new FA_XIncomeAccAllocat();

                    fA_XIncomeAccAllocat.IAAID = dt.Rows[0]["IAAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IAAID"];
                    fA_XIncomeAccAllocat.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XIncomeAccAllocat.IAAMon = dt.Rows[0]["IAAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IAAMon"];
                    fA_XIncomeAccAllocat.IAAYear = dt.Rows[0]["IAAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IAAYear"];

                    return fA_XIncomeAccAllocat;
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
    }
}
