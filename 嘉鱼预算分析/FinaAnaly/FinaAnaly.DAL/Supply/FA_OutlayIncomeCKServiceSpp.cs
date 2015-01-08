using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
    public static partial  class FA_OutlayIncomeCKService
    {
        public static FA_OutlayIncomeCK GetOutlayIncomeCKByTime(DateTime time,int piid)
        {
            string sql = "SELECT * FROM FA_OutlayIncomeCK WHERE OICkTime = @OICkTime and PIID=@PIID";

            try
            {
                SqlParameter[] para = new SqlParameter[]{
                new SqlParameter ("@OICkTime",time),
                new SqlParameter ("@PIID",piid)
                };
                DataTable dt = DBUnity.AdapterToTab(sql, para);

                if (dt.Rows.Count > 0)
                {
                    FA_OutlayIncomeCK fA_OutlayIncomeCK = new FA_OutlayIncomeCK();

                    fA_OutlayIncomeCK.OIID = dt.Rows[0]["OIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["OIID"];
                    fA_OutlayIncomeCK.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_OutlayIncomeCK.OICkAreaMon = dt.Rows[0]["OICkAreaMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OICkAreaMon"];
                    fA_OutlayIncomeCK.OICkZeroMon = dt.Rows[0]["OICkZeroMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OICkZeroMon"];
                    fA_OutlayIncomeCK.OICkTime = dt.Rows[0]["OICkTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["OICkTime"];

                    return fA_OutlayIncomeCK;
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

        public static DataTable   GetOutlayIncomeCKByTimeRange(DateTime time1,DateTime time2, int piid)
        {
            DataTable dt = null;            
            try
            {
                string sql = " select * from FA_OutlayIncomeCK where OICkTime between '{0}' And '{1}' and PIID={2}";
                sql = string.Format(sql, time1, time2, piid);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_OutlayIncomeCKService--GetOutlayIncomeCKByTimeRange");
            }
            return dt;
        }

        public static DataTable GetOutlayIncomeCKByTimeRangeType(string  time1, string  time2, string Str)
        {
            DataTable dt = null;
            try
            {
                string sql = "  SELECT sum(a.OICkAreaMon) as OICkAreaMon, sum(a.OICkZeroMon) as OICkZeroMon,  b.PIEcoSubName  FROM  FA_OutlayIncomeCK AS a LEFT OUTER JOIN  FA_PayIncome AS b ON a.PIID = b.PIID  WHERE (CONVERT(nvarchar(7), a.OICkTime, 120) BETWEEN '{0}' AND '{1}') AND (a.PIID IN ({2})) group by  b.PIEcoSubName ";
                sql = string.Format(sql, time1, time2, Str);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_OutlayIncomeCKService--GetOutlayIncomeCKByTimeRangeType");
            }
            return dt;
        }

        public static DataTable GetOutlayIncomeCKByTimePIID(int year, string Str)
        {
            DataTable dt = null;
            try
            {
                string sql = "SELECT  PIID, SUM(OICkAreaMon) AS OICkAreaMon, SUM(OICkZeroMon) AS OICkZeroMon FROM  FA_OutlayIncomeCK  WHERE (YEAR(OICkTime) = {0}) AND (PIID IN ({1})) GROUP BY PIID";
                sql = string.Format(sql, year, Str);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_OutlayIncomeCKService--GetOutlayIncomeCKByTimeRangeType");
            }
            return dt;
        }
    }
}
