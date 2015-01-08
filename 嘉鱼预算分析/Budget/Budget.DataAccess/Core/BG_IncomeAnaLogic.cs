using System;
using System.Collections.Generic;
using System.Data;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using Common;
using System.Text;

namespace BudgetWeb.BLL
{
    public class BG_IncomeAnaLogic
    {
        /// <summary>
        /// 通过年度联合查询[年度收入分析表]
        /// </summary>
        /// <param name="year">年度</param>
        /// <returns>DataTable</returns>
        public static DataTable GetAnalyseIncDataYearByYear(int year)
        {
            DataTable vdt = new DataTable();
            string sqlStr = "select * from vAnalyseIncDataYear where  IAYear = {0}";
            sqlStr = string.Format(sqlStr, year);
            vdt = DBUnity.AdapterToTab(sqlStr);
            return vdt;
        }


        /// <summary>
        /// 通过年度联合查询科目编码[年度收入分析表]----EICoding
        /// </summary>
        /// <param name="year">年度</param>
        /// <returns>DataTable</returns>
        public static DataTable GetAnalyseIncDataYearByYearAndEcoding(int year, string codingList)
        {
            DataTable vdt = new DataTable();
            try
            {
                string sqlStr = string.Format("select * from dbo.vAnalyseIncDataYear where IAYear={0} and EICoding in ({1})", year, codingList);
                vdt = DBUnity.AdapterToTab(sqlStr);
            }
            catch
            {
            }
            return vdt;
        }

        /// <summary>
        /// 通过月度联合查询[月度收入分析表]
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="month">月度</param>
        /// <returns>DataTable</returns>
        public static DataTable GetAnalyIncCkDataMonth(int year, int month)
        {
            DataTable vdt = new DataTable();
            string sqlStr = "select * from vAnalyseIncCkDataMonth where  year(IATime) = {0} and month(IATime) = {1}";
            sqlStr = string.Format(sqlStr, year, month);
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
                    //预算金额
                    dr["YSMon"] = dtfilter.Rows[i]["IABudMon"].ToString();
                    //决算金额
                    dr["JSMon"] = dtfilter.Rows[i]["IAAudMon"].ToString();
                    //核算本期数
                    dr["HSBQMon"] = dtfilter.Rows[i]["IACkMon"].ToString();
                    //核算同期数
                    dr["HSTQMon"] = dtfilter.Rows[i]["HSTQMon"].ToString();
                    //与预算比
                    dr["YYSBit"] = dtfilter.Rows[i]["YYSBit"].ToString();
                    //与决算比
                    dr["YJSBit"] = dtfilter.Rows[i]["YJSBit"].ToString();
                    //人均系数
                    dr["RJXS"] = dtfilter.Rows[i]["RJXS"].ToString();
                    dtSum.Rows.Add(dr);
                }
            }
            return dtSum;
        }

        /// <summary>
        /// 年度收入数据过滤
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
        public static DataTable GetIncomeDtByYeat(int year, string str, int perNum)
        {
            DataTable dt = new DataTable();
            if (str.Length <= 0)
            {
                dt = GetAnalyseIncDataYearByYear(year);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                string[] arr = str.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    string stmp = arr[i];
                    if (!string.IsNullOrEmpty(stmp))
                    {
                        sb.Append("'" + stmp + "',");
                    }
                }

                dt = GetAnalyseIncDataYearByYearAndEcoding(year, sb.ToString().Trim(','));
            }

            dt.Columns.Add("HSTQMon");
            dt.Columns.Add("YYSBit");
            dt.Columns.Add("YJSBit");
            dt.Columns.Add("RJXS");
            DataTable dtAfter = GetAnalyseIncDataYearByYear(year - 1);

            if (dt.Rows.Count > 0 && dtAfter.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal iackmon = GetDecimal(dt.Rows[i]["IACkMon"].ToString());
                    decimal iabudmon = GetDecimal(dt.Rows[i]["IABudMon"].ToString());
                    decimal iaaudmon = GetDecimal(dt.Rows[i]["IAAudMon"].ToString());
                    dt.Rows[i]["YYSBit"] = DealVal(iackmon, iabudmon);
                    dt.Rows[i]["YJSBit"] = DealVal(iackmon, iaaudmon);
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
        private static decimal GetDecimal(string str)
        {
            decimal dem = 0;
            if (string.IsNullOrEmpty(str))
            {
                dem = 0;
            }
            else
            {
                dem = decimal.Parse(str);
            }
            return dem;
        }
    }
}
