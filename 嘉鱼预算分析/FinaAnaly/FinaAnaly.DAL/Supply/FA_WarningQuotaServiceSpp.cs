using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FinaAnaly.Model;
using System.Data.SqlClient;
using Common;

namespace FinaAnaly.DAL
{
    public static partial class FA_WarningQuotaService
    {
        /// <summary>
        /// 根据年度查询到一条记录
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>FA_SysSetting</returns>
        public static FA_WarningQuota GetWarningQuotaByYear(int wqyear)
        {
            try
            {
                string sqlStr = "select * from FA_WarningQuota where WQYear=@WQYear";
                SqlParameter para = new SqlParameter("@WQYear", wqyear);
                DataTable dt = DBUnity.AdapterToTab(sqlStr, para);
                if (dt.Rows.Count > 0)
                {
                    FA_WarningQuota fA_WarningQuota = new FA_WarningQuota();
                    fA_WarningQuota.WQID = dt.Rows[0]["WQID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["WQID"];
                    fA_WarningQuota.YellowWarning = dt.Rows[0]["YellowWarning"] == DBNull.Value ? "" : (string)dt.Rows[0]["YellowWarning"];
                    fA_WarningQuota.RedWarning = dt.Rows[0]["RedWarning"] == DBNull.Value ? "" : (string)dt.Rows[0]["RedWarning"];
                    fA_WarningQuota.WQYear = dt.Rows[0]["WQYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["WQYear"];
                    return fA_WarningQuota;
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

        /// <summary>
        /// 根据年度获取对应记录数
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>int</returns>
        public static int GetWarningQuotaCountByYear(int wqyear)
        {
            int tmp = 0;
            try
            {
                string sqlStr = "select count(*) from FA_WarningQuota where WQYear={0}";
                sqlStr = string.Format(sqlStr, wqyear);
                tmp = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_SysSettingService.GetFA_SysSetting");
            }
            return tmp;
        }
    }
}
