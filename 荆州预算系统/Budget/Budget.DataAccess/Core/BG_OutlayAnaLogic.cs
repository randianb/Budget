using System;
using System.Collections.Generic;
using System.Data;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using System.Text;

namespace BudgetWeb.BLL
{
    public class BG_OutlayAnaLogic
    {
        /// <summary>
        /// 通过年度联合查询[年度支出分析表]
        /// </summary>
        /// <param name="year">年度</param>
        /// <returns>DataTable</returns>
        public static DataTable GetAnalyseOutDataByYear(int year)
        {
            DataTable vdt = new DataTable();
            string sqlStr = "select * from vAnalyseOutDataYear where  OAYear = {0}";
            sqlStr = string.Format(sqlStr, year);
            vdt = DBUnity.AdapterToTab(sqlStr);
            return vdt;
        }


        /// <summary>
        /// 通过年度联合查询科目编码[年度支出分析表]
        /// </summary>
        /// <param name="year">年度</param>
        /// <returns>DataTable</returns>
        public static DataTable GetAnalyseOutDataYearByYearAndEcoding(int year, string codingList)
        {
            DataTable vdt = new DataTable();
            try
            {
                string sqlStr = string.Format("select * from vAnalyseOutDataYear where OAYear={0} and PIEcoSubCoding in ({1})",year,codingList);
                vdt = DBUnity.AdapterToTab(sqlStr);
            }
            catch
            {
            }
            return vdt;
        }
        /// <summary>
        /// 通过月度联合查询[月度支出分析表]
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="month">月度</param>
        /// <returns>DataTable</returns>
        public static DataTable GetvAnalyOutCkMonth(int year, int month)
        {
            DataTable vdt = new DataTable();
            string sqlStr = "select * from vAnalyseOutCkDataMonth where  year(OATime) = {0} and  month(OATime) = {1} ";
            sqlStr = string.Format(sqlStr, year, month);
            vdt = DBUnity.AdapterToTab(sqlStr);
            return vdt;
        }

        public static DataTable OutlayFilterDt(DataTable dtSum, DataTable dtfilter)
        {
            if (dtfilter.Rows.Count > 0)
            {
                for (int i = 0; i < dtfilter.Rows.Count; i++)
                {
                    DataRow dr = dtSum.NewRow();
                    //科目编码
                    dr["KMCodeing"] = dtfilter.Rows[i]["PIEcoSubCoding"].ToString();
                    //科目名称
                    dr["KMName"] = dtfilter.Rows[i]["PIEcoSubName"].ToString();
                    //预算金额
                    dr["YSMon"] = dtfilter.Rows[i]["OABudMon"].ToString();
                    //决算金额
                    dr["JSMon"] = dtfilter.Rows[i]["OAAudMon"].ToString();
                    //核算本期数
                    dr["HSBQMon"] = dtfilter.Rows[i]["OACkMon"].ToString();
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
        /// 获取年度支出数据
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DataTable GetOutDtByYeat(int year,string str, int perNum)
        {
            DataTable dt = new DataTable();
            if (str.Length<=0 )
            {
                dt = GetAnalyseOutDataByYear(year);
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

                dt = GetAnalyseOutDataYearByYearAndEcoding(year, sb.ToString().Trim(','));
            }

            dt.Columns.Add("HSTQMon");
            dt.Columns.Add("YYSBit");
            dt.Columns.Add("YJSBit");
            dt.Columns.Add("RJXS");
            DataTable dtAfter = GetAnalyseOutDataByYear(year - 1);
          
            if (dt.Rows.Count > 0 && dtAfter.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal iackmon = GetDecimal(dt.Rows[i]["OACkMon"].ToString());
                    decimal iabudmon = GetDecimal(dt.Rows[i]["OABudMon"].ToString());
                    decimal iaaudmon = GetDecimal(dt.Rows[i]["OAAudMon"].ToString());
                    dt.Rows[i]["YYSBit"] = DealVal(iackmon, iabudmon);
                    dt.Rows[i]["YJSBit"] = DealVal(iackmon, iaaudmon);
                    dt.Rows[i]["RJXS"] = Decimal.Round((iackmon / perNum), 2);
                    for (int j = 0; j < dtAfter.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["PIEcoSubCoding"].ToString() == dtAfter.Rows[j]["PIEcoSubCoding"].ToString())
                        {
                            dt.Rows[i]["HSTQMon"] = dtAfter.Rows[j]["OACkMon"];
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
    }
}
