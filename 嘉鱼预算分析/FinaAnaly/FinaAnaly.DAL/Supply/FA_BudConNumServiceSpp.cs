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
    public static partial  class FA_BudConNumService
    {
        /// <summary>
        /// 根据年度查询到一条记录
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>FA_SysSetting</returns>
        public static FA_BudConNum GetBudConNumByYear(int bcnyear)
        {
            try
            {
                string sqlStr = "select * from FA_BudConNum where BCNYear=@BCNYear";
                SqlParameter para = new SqlParameter("@BCNYear", bcnyear);
                DataTable dt = DBUnity.AdapterToTab(sqlStr, para);
                if (dt.Rows.Count > 0)
                {
                    FA_BudConNum fA_BudConNum = new FA_BudConNum();

                    fA_BudConNum.BCID = dt.Rows[0]["BCID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BCID"];
                    fA_BudConNum.BCNBasExpBudMon = dt.Rows[0]["BCNBasExpBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCNBasExpBudMon"];
                    fA_BudConNum.BCNProExpBudMon = dt.Rows[0]["BCNProExpBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCNProExpBudMon"];
                    fA_BudConNum.BCNBasAddBudMon = dt.Rows[0]["BCNBasAddBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCNBasAddBudMon"];
                    fA_BudConNum.BCNProAddBudMon = dt.Rows[0]["BCNProAddBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCNProAddBudMon"];
                    fA_BudConNum.BCNYear = dt.Rows[0]["BCNYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BCNYear"];

                    return fA_BudConNum;
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
        public static int GetBudConNumCountByYear(int bcnyear)
        {
            int tmp = 0;
            try
            {
                string sqlStr = "select count(*) from FA_BudConNum where BCNYear={0}";
                sqlStr = string.Format(sqlStr, bcnyear);
                tmp = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_BudConNumService.GetBudConNumCountByYear");
            }
            return tmp;
        }
    }
}
