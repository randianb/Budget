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
    public static partial  class FA_OutlayDepCKService
    {
        public static DataTable GetOutlayDepCKByTimedepid(DateTime time, int depid)
        {
            DataTable dt = null;
            try
            {
                string sql = " select SUM(ODCkAreaMon) as ODCkAreaMon,SUM(ODCkZeroMon) as ODCkZeroMon   from dbo.FA_OutlayDepCK where ODCkTime = '{0}' and DepID={1}";
                sql = string.Format(sql, time, depid);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_OutlayDepCKService--GetOutlayDepCKByTimedepid");
            }
            return dt;
        }

        public static FA_OutlayDepCK GetOutlayDepCKByTime(DateTime time, int piid)
        {
            string sql = "SELECT * FROM FA_OutlayDepCK WHERE ODCkTime = @ODCkTime and PIID=@PIID";

            try
            {
                SqlParameter[] para = new SqlParameter[]{
                new SqlParameter ("@ODCkTime",time),
                new SqlParameter ("@PIID",piid)
                };
                DataTable dt = DBUnity.AdapterToTab(sql, para);

                if (dt.Rows.Count > 0)
                {
                    FA_OutlayDepCK fA_OutlayDepCK = new FA_OutlayDepCK();

                    fA_OutlayDepCK.ODID = dt.Rows[0]["ODID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ODID"];
                    fA_OutlayDepCK.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_OutlayDepCK.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    fA_OutlayDepCK.ODCkAreaMon = dt.Rows[0]["ODCkAreaMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCkAreaMon"];
                    fA_OutlayDepCK.ODCkZeroMon = dt.Rows[0]["ODCkZeroMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ODCkZeroMon"];
                    fA_OutlayDepCK.ODCkTime = dt.Rows[0]["ODCkTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["ODCkTime"];

                    return fA_OutlayDepCK;
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
