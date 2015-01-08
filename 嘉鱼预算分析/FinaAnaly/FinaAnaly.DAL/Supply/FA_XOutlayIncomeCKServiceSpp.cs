using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinaAnaly.Model;
using System.Data.SqlClient;
using System.Data;
using Common;

namespace FinaAnaly.DAL
{
    public static partial class FA_XOutlayIncomeCKService
    {
        public static FA_XOutlayIncomeCK GetXOutlayIncomeCKByTime(DateTime time, int piid)
        {
            string sql = "SELECT * FROM FA_XOutlayIncomeCK WHERE ODCkTime = @ODCkTime and PIID=@PIID";

            try
            {
                SqlParameter[] para = new SqlParameter[]{
                new SqlParameter ("@ODCkTime",time),
                new SqlParameter ("@PIID",piid)
                };
                DataTable dt = DBUnity.AdapterToTab(sql, para);

                if (dt.Rows.Count > 0)
                {
                    FA_XOutlayIncomeCK fA_XOutlayIncomeCK = new FA_XOutlayIncomeCK();

                    fA_XOutlayIncomeCK.ODID = dt.Rows[0]["ODID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ODID"];
                    fA_XOutlayIncomeCK.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XOutlayIncomeCK.ODCKAreaMon = dt.Rows[0]["ODCKAreaMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCKAreaMon"];
                    fA_XOutlayIncomeCK.ODCKZeroMon = dt.Rows[0]["ODCKZeroMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCKZeroMon"];
                    fA_XOutlayIncomeCK.ODCKTime = dt.Rows[0]["ODCKTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ODCKTime"];

                    return fA_XOutlayIncomeCK;
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

        public static DataTable GetXOutlayIncomeCKByTimeRange(DateTime time1, DateTime time2, int piid)
        {
            DataTable dt = null;
            try
            {
                string sql = " select * from FA_XOutlayIncomeCK where ODCkTime between '{0}' And '{1}' and PIID={2}";
                sql = string.Format(sql, time1, time2, piid);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XOutlayIncomeCKService--GetXOutlayIncomeCKByTimeRange");
            }
            return dt;
        }

        public static DataTable GetXOutlayIncomeCKByTimePIEcoSubName(DateTime time1, DateTime time2, string PIEcoSubName)
        {
            DataTable dt = null;
            try
            {
                string sql = " select sum(ODCkAreaMon) as ODCkAreaMon, sum(ODCkZeroMon) as ODCkZeroMon from FA_XOutlayIncomeCK where ODCkTime between '{0}' And '{1}' and PIEcoSubName='{2}' group by  PIEcoSubName";
                sql = string.Format(sql, time1, time2, PIEcoSubName);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XOutlayIncomeCKService--GetXOutlayIncomeCKByTimeRange");
            }
            return dt;
        }

        public static DataTable GetXOutlayIncomeCKByTimeRangeType(string time1, string time2, string Str)
        {
            DataTable dt = null;
            try
            {
                string sql = "  SELECT sum(a.ODCkAreaMon) as ODCkAreaMon, sum(a.ODCkZeroMon) as ODCkZeroMon, b.PIEcoSubName  FROM  FA_XOutlayIncomeCK AS a LEFT OUTER JOIN  FA_XPayIncome AS b ON a.PIID = b.PIID  WHERE (CONVERT(nvarchar(7), a.ODCkTime, 120) BETWEEN '{0}' AND '{1}') AND (a.PIID IN ({2})) group by  b.PIEcoSubName ";
                sql = string.Format(sql, time1, time2, Str);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XOutlayIncomeCKService--GetXOutlayIncomeCKByTimeRangeType");
            }
            return dt;
        }

        public static DataTable GetXOutlayIncomeCKByTimePIID(int year, string Str)
        {
            DataTable dt = null;
            try
            {
                string sql = "SELECT  PIID, SUM(ODCkAreaMon) AS ODCkAreaMon, SUM(ODCkZeroMon) AS ODCkZeroMon FROM  FA_XOutlayIncomeCK  WHERE (YEAR(ODCkTime) = {0}) AND (PIID IN ({1})) GROUP BY PIID";
                sql = string.Format(sql, year, Str);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XOutlayIncomeCKService--GetXOutlayIncomeCKByTimePIID");
            }
            return dt;
        }

        public static DataTable GetXOutlayIncomeCKByTimesPIID(int year,int lyear, string Str)
        {
            DataTable dt = null;
            try
            {
                string sql = "SELECT  PIID,ODCkTime, SUM(ODCkAreaMon) AS ODCkAreaMon, SUM(ODCkZeroMon) AS ODCkZeroMon FROM  FA_XOutlayIncomeCK  WHERE (YEAR(ODCkTime) in({0},{1})) AND (PIID IN ({2})) GROUP BY PIID";
                sql = string.Format(sql, year, lyear, Str);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XOutlayIncomeCKService--GetXOutlayIncomeCKByTimesPIID");
            }
            return dt;
        }

        public static DataTable GetXOutlayIncomeCKByYearPIID(int year, int piid)
        {
            DataTable dt = null;
            try
            {
                string sql = "SELECT  * FROM  FA_XOutlayIncomeCK  WHERE (YEAR(ODCkTime) = {0}) AND (PIID = ({1}))";
                sql = string.Format(sql, year, piid);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XOutlayIncomeCKService--GetXOutlayIncomeCKByYearPIID");
            }
            return dt;
        }
    }
}
