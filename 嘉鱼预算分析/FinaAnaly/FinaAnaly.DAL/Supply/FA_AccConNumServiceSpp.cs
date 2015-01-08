using System;
using System.Data;
using System.Data.SqlClient;
using Common;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
    public static partial class FA_AccConNumService
    {
        /// <summary>
        /// 根据年度查询到一条记录
        /// </summary>
        /// <param name="ACNYear">年度</param>
        /// <returns>FA_AccConNum</returns>
        public static FA_AccConNum GetAccConNumByYear(int ACNYear)
        {
            try
            {
                string sqlStr = "select * from FA_AccConNum where ACNYear=@ACNYear";
                SqlParameter para = new SqlParameter("@ACNYear", ACNYear);
                DataTable dt = DBUnity.AdapterToTab(sqlStr, para);
                if (dt.Rows.Count > 0)
                {
                    FA_AccConNum fA_AccConNum = new FA_AccConNum();

                    fA_AccConNum.ACID = dt.Rows[0]["ACID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ACID"];
                    fA_AccConNum.ACNBasExpBudMon = dt.Rows[0]["ACNBasExpBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ACNBasExpBudMon"];
                    fA_AccConNum.ACNProExpBudMon = dt.Rows[0]["ACNProExpBudMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ACNProExpBudMon"];
                    fA_AccConNum.ACNYear = dt.Rows[0]["ACNYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ACNYear"];

                    return fA_AccConNum;
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
        /// <param name="acnyear">年度</param>
        /// <returns>int</returns>
        public static int GetAccConNumCountByYear(int acnyear)
        {
            int tmp = 0;
            try
            {
                string sqlStr = "select count(*) from FA_AccConNum where ACNYear={0}";
                sqlStr = string.Format(sqlStr, acnyear);
                tmp = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_AccConNumService.GetFA_AccConNum");
            }
            return tmp;
        }


    }
}
