using FinaAnaly.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FinaAnaly.DAL
{
    public static partial class FA_AddBudConNumService
    {
        /// <summary>
        /// 根据年度查询到一条记录
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>FA_SysSetting</returns>
        public static FA_AddBudConNum GetFA_AddBudConNumByYear(int year)
        {
            try
            {
                string sqlStr = "select * from FA_AddBudConNum where AddYear=@AddYear";
                SqlParameter para = new SqlParameter("@AddYear", year);
                DataTable dt = DBUnity.AdapterToTab(sqlStr, para);
                if (dt.Rows.Count > 0)
                {
                    FA_AddBudConNum fA_AddBudConNum = new FA_AddBudConNum();

                    fA_AddBudConNum.AddID = dt.Rows[0]["AddID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["AddID"];
                    fA_AddBudConNum.TUserMon = dt.Rows[0]["TUserMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["TUserMon"];
                    fA_AddBudConNum.TPubMon = dt.Rows[0]["TPubMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["TPubMon"];
                    fA_AddBudConNum.TFamMon = dt.Rows[0]["TFamMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["TFamMon"];
                    fA_AddBudConNum.AddUserMon = dt.Rows[0]["AddUserMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["AddUserMon"];
                    fA_AddBudConNum.AddPubMon = dt.Rows[0]["AddPubMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["AddPubMon"];
                    fA_AddBudConNum.AddFamMon = dt.Rows[0]["AddFamMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["AddFamMon"];
                    fA_AddBudConNum.AddYear = dt.Rows[0]["AddYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["AddYear"];

                    return fA_AddBudConNum;
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
