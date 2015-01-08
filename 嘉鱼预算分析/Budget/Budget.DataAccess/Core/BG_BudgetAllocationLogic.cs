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
    public class BG_BudgetAllocationLogic
    {
        public static DataTable GetARMonByBAAYear(string BAAYear)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format(" select DepID, Sum(BAAMon) as BAAMon from dbo.BG_BudgetAllocation where BAAYear={0}   group by DepID", BAAYear);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable GetAAMon(int depid, int piid, int year)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format(" select sum(BEAMon) as BAAMon  ,sum(SuppMon) as SuppMon  from dbo.BG_BudgetAllocation where BAAYear={0} and DepID={1} and PIID={2}", year, depid, piid);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable GetALLAAMon(int year)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format(" select DepID,PIID,sum(BAAMon) as BAAMon ,sum(SuppMon) as SuppMon  from dbo.BG_BudgetAllocation where BAAYear={0}  group by DepID,PIID", year);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable GetAAMonDTbyDepID(int year, int depid)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format(" select PIID , sum(BAAMon) as BAAMon ,sum(SuppMon) as SuppMon  from dbo.BG_BudgetAllocation where BAAYear={0} and DepID={1} group by piid", year, depid);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable GetAAMonDTbyPIID(int year, int piid)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format(" select DepID , sum(BAAMon) as BAAMon ,sum(SuppMon) as SuppMon  from dbo.BG_BudgetAllocation where BAAYear={0} and PIID={1} group by depid", year, piid);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static BG_BudgetAllocation GetMonDT(int year, int PIID, int depID)
        {
            string sql = "SELECT * FROM BG_BudgetAllocation WHERE PIID = @PIID and DepID = @DepID and BAAYear=@BAAYear";

            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
                    new SqlParameter("@DepID", depID),
					new SqlParameter("@PIID", PIID),
                    new SqlParameter("@BAAYear", year)
                };
                DataTable dt = DBUnity.AdapterToTab(sql, para);

                if (dt.Rows.Count > 0)
                {
                    BG_BudgetAllocation bG_BudgetAllocation = new BG_BudgetAllocation();

                    bG_BudgetAllocation.BAAID = dt.Rows[0]["BAAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BAAID"];
                    bG_BudgetAllocation.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_BudgetAllocation.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_BudgetAllocation.BAAMon = dt.Rows[0]["BAAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BAAMon"];
                    bG_BudgetAllocation.SuppMon = dt.Rows[0]["SuppMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["SuppMon"];
                    bG_BudgetAllocation.BAAYear = dt.Rows[0]["BAAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BAAYear"];

                    return bG_BudgetAllocation;
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

        public static decimal GetMon(int year, int piid, int depid)
        {
            decimal tt = 0;
            string sql = string.Format("SELECT sum(BAAMon)+sum(SuppMon) FROM BG_BudgetAllocation WHERE PIID = {0} and DepID = {1} and BAAYear={2}", piid, depid, year);
            try
            {
                tt = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (Exception ex)
            {

                tt = 0;
            }
            return tt;
        }

        public static bool DelByYear(string CurrentYear)
        {
            bool flag = false;
            int t = 0;
            string sql = string.Format("delete from BG_BudgetAllocation where BAAYear='{0}'", CurrentYear);
            try
            {
                t = DBUnity.ExecuteNonQuery(CommandType.Text, sql, null);
                if (t > 0)
                {
                    flag = true;
                }
                else
                { flag = false; }
            }
            catch (Exception)
            {

                flag = false;
            }
            return flag;
        }
    }
}
