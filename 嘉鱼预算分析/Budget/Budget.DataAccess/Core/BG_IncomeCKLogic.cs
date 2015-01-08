using BudgetWeb.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BudgetWeb.BLL
{
    /// <summary>
    /// 月度收入分析--自选查询业务逻辑类
    /// </summary>
    public class BG_IncomeCKLogic
    {
        /// <summary>
        /// 通过月度联合查询[月度收入分析表]
        /// </summary>
        /// <param name="stime">起始时间</param>
        /// <param name="etime">截止时间</param>
        /// <returns>DataTable</returns>
        public static DataTable GeDtVaicdmByInterval(string stime, string etime)
        {
            DataTable vdt = new DataTable();
            string sqlStr = "select * from vAnalyseIncCkDataMonth where  IATime BETWEEN '{0}' AND '{1}'";
            sqlStr = string.Format(sqlStr, stime, etime);
            vdt = DBUnity.AdapterToTab(sqlStr);
            return vdt;
        }



        /// <summary>
        /// 通过月度联合查询[月度收入分析表]---EICoding
        /// </summary>
        /// <param name="stime">起始时间</param>
        /// <param name="etime">截止时间</param>
        /// <param name="codingStrs">EICoding</param>
        /// <returns>DataTable</returns>
        public static DataTable GeDtVaicdmByIntervalEICoding(string stime, string etime, string codingStrs)
        {
            DataTable vdt = new DataTable();
            string sqlStr = "select * from vAnalyseIncCkDataMonth where  IATime BETWEEN '{0}' AND '{1}' AND EICoding in ({2})";
            sqlStr = string.Format(sqlStr, stime, etime, codingStrs);
            vdt = DBUnity.AdapterToTab(sqlStr);
            return vdt;
        }

        public static string DealVal(decimal d1, decimal d2)
        {
            string reStr = string.Empty;
            if ((int)d1 == 0 || (int)d2 == 0)
            {
                reStr = "--";
            }
            else
            {
                reStr = Decimal.Round((d1 / d2) * 100, 2).ToString() + "%";
            }
            return reStr;
        }

        public static DataTable IncFilterDt(DataTable dtSum, DataTable dtfilter)
        {
            if (dtfilter.Rows.Count > 0)
            {
                for (int i = 0; i < dtfilter.Rows.Count; i++)
                {
                    DataRow dr = dtSum.NewRow();
                    //科目编码
                    dr["KMCodeing"] = dtfilter.Rows[i]["EICoding"].ToString();
                    //科目名称
                    dr["KMName"] = dtfilter.Rows[i]["EIName"].ToString();
                    //核算本期数
                    dr["HSBQMon"] = dtfilter.Rows[i]["IACkMon"].ToString();
                    //核算同期数
                    dr["HSTQMon"] = dtfilter.Rows[i]["HSTQMon"].ToString();
                    //人均系数
                    dr["RJXS"] = dtfilter.Rows[i]["RJXS"].ToString();
                    dtSum.Rows.Add(dr);
                }
            }
            return dtSum;
        }

        /// <summary>
        /// 月度收入数据过滤
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DataTable IncomeDtFilter(DataTable dt, List<string> list)
        {
            if (dt.Rows.Count > 0 && list != null && list.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!list.Contains(dt.Rows[i]["EICoding"].ToString().Trim()))
                    {
                        dt.Rows[i].Delete();
                    }
                }
                dt.AcceptChanges();
            }
            return dt;
        }



        /// <summary>
        /// 获取年度收入数据
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DataTable GetIncomeCKDtByInterval(string stime, string etime, string codingStrs, int perNum)
        {
            DataTable dt = new DataTable();
            if (codingStrs.Length <= 0)
            {
                dt = GeDtVaicdmByInterval(stime, etime);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                string[] arr = codingStrs.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    string stmp = arr[i];
                    if (!string.IsNullOrEmpty(stmp))
                    {
                        sb.Append("'" + stmp + "',");
                    }
                }

                dt = GeDtVaicdmByIntervalEICoding(stime, etime, sb.ToString().Trim(','));
            }

            dt.Columns.Add("HSTQMon");
            dt.Columns.Add("RJXS");
            string stTmp = DateTime.Parse(stime).AddYears(-1).ToString("yyyy-MM-dd");
            string etTmp = DateTime.Parse(etime).AddYears(-1).ToString("yyyy-MM-dd");
            DataTable dtAfter = GeDtVaicdmByInterval(stTmp, etTmp);

            if (dt.Rows.Count > 0 && dtAfter.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal iackmon = decimal.Parse(dt.Rows[i]["IACkMon"].ToString());
                    dt.Rows[i]["RJXS"] = Decimal.Round((iackmon / perNum), 2);
                    for (int j = 0; j < dtAfter.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["EICoding"].ToString() == dtAfter.Rows[j]["EICoding"].ToString())
                        {
                            dt.Rows[i]["HSTQMon"] = dtAfter.Rows[j]["IACkMon"];
                        }
                    }
                }
            }
            return dt;
        }
    }
}
