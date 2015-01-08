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
    public static partial  class FA_XOutlayDepCKService
    {
        public static FA_XOutlayDepCK GetXOutlayDepCKByTime(DateTime time, int piid)
        {
            string sql = "SELECT * FROM FA_XOutlayDepCK WHERE ODCkTime = @ODCkTime and PIID=@PIID";

            try
            {
                SqlParameter[] para = new SqlParameter[]{
                new SqlParameter ("@ODCkTime",time),
                new SqlParameter ("@PIID",piid)
                };
                DataTable dt = DBUnity.AdapterToTab(sql, para);

                if (dt.Rows.Count > 0)
                {
                    FA_XOutlayDepCK fA_XOutlayDepCK = new FA_XOutlayDepCK();

                    fA_XOutlayDepCK.ODID = dt.Rows[0]["ODID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ODID"];
                    fA_XOutlayDepCK.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XOutlayDepCK.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    fA_XOutlayDepCK.ODCkAreaMon = dt.Rows[0]["ODCkAreaMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCkAreaMon"];
                    fA_XOutlayDepCK.ODCkZeroMon = dt.Rows[0]["ODCkZeroMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCkZeroMon"];
                    fA_XOutlayDepCK.ODCkTime = dt.Rows[0]["ODCkTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ODCkTime"];

                    return fA_XOutlayDepCK;
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


        public static DataTable GetXOutlayDepCKByTimeRange(DateTime time1, DateTime time2, int piid)
        {
            DataTable dt = null;
            try
            {
                string sql = " select * from FA_XOutlayDepCK where ODCkTime between '{0}' And '{1}' and PIID={2}";
                sql = string.Format(sql, time1, time2, piid);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XOutlayDepCKService--GetXOutlayDepCKByTimeRange");
            }
            return dt;
        }

        public static DataTable GetXOutlayDepCKByTimeRangepiiddepid(DateTime time1, DateTime time2, int piid,int depid)
        {
            DataTable dt = null;
            try
            {
                string sql = " select * from FA_XOutlayDepCK where ODCkTime between '{0}' And '{1}' and PIID={2} and  DepID={3}";
                sql = string.Format(sql, time1, time2, piid,depid);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XOutlayDepCKService--GetXOutlayDepCKByTimeRange");
            }
            return dt;
        }

        public static DataTable GetXOutlayDepCKByTimedepid(DateTime time, int depid)
        {
            DataTable dt = null;
            try
            {
                string sql = " select SUM(ODCkAreaMon) as ODCkAreaMon,SUM(ODCkZeroMon) as ODCkZeroMon   from dbo.FA_XOutlayDepCK where ODCkTime = '{0}' and DepID={1}";
                sql = string.Format(sql, time, depid);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XOutlayDepCKService--GetXOutlayDepCKByTimedepid");
            }
            return dt;
        }

        public static FA_XOutlayDepCK GetXOutlayDepCKByTimepiiddepid(DateTime time, int piid,int depid)
        {
            string sql = "SELECT * FROM FA_XOutlayDepCK WHERE ODCkTime = @ODCkTime and PIID=@PIID and DepID=@DepID";

            try
            {
                SqlParameter[] para = new SqlParameter[]{
                new SqlParameter ("@ODCkTime",time),
                new SqlParameter ("@PIID",piid),
                new SqlParameter ("@DepID",depid)
                };
                DataTable dt = DBUnity.AdapterToTab(sql, para);

                if (dt.Rows.Count > 0)
                {
                    FA_XOutlayDepCK fA_XOutlayDepCK = new FA_XOutlayDepCK();

                    fA_XOutlayDepCK.ODID = dt.Rows[0]["ODID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ODID"];
                    fA_XOutlayDepCK.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XOutlayDepCK.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    fA_XOutlayDepCK.ODCkAreaMon = dt.Rows[0]["ODCkAreaMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCkAreaMon"];
                    fA_XOutlayDepCK.ODCkZeroMon = dt.Rows[0]["ODCkZeroMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCkZeroMon"];
                    fA_XOutlayDepCK.ODCkTime = dt.Rows[0]["ODCkTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ODCkTime"];

                    return fA_XOutlayDepCK;
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
