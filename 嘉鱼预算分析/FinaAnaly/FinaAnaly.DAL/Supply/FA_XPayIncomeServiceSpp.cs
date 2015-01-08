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
    public static partial class FA_XPayIncomeService
    {
        public static DataTable GetXPayIncomeByXPItype(string xpitype)
        {
            DataTable dt = null;
            try
            {
                string sql = string.Format("SELECT * FROM FA_XPayIncome WHERE PIType = '{0}'", xpitype);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XPayIncomeService--GetXPayIncomeByPItype");
            }
            return dt;
        }

        public static DataTable GetXPayIncomeByPIecosubnamedt(string piecosubname)
        {
            DataTable dt = null;
            try
            {
                string sql = string.Format("SELECT * FROM FA_XPayIncome WHERE PIEcoSubName ='{0}'", piecosubname);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XPayIncomeService--GetXPayIncomeByPIecosubnamedt");
            }
            return dt;
        }

        public static FA_XPayIncome GetXPayIncomeByPIecosubname(string piecosubname)
        {
            string sql = "SELECT * FROM FA_XPayIncome WHERE PIEcoSubName = @PIEcoSubName";

            try
            {
                SqlParameter para = new SqlParameter("@PIEcoSubName", piecosubname);
                DataTable dt = DBUnity.AdapterToTab(sql, para);

                if (dt.Rows.Count > 0)
                {
                    FA_XPayIncome fA_XPayIncome = new FA_XPayIncome();

                    fA_XPayIncome.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XPayIncome.PIEcoSubCoding = dt.Rows[0]["PIEcoSubCoding"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubCoding"];
                    fA_XPayIncome.PIEcoSubLev = dt.Rows[0]["PIEcoSubLev"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubLev"];
                    fA_XPayIncome.PIEcoSubParID = dt.Rows[0]["PIEcoSubParID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubParID"];
                    fA_XPayIncome.PIEcoSubName = dt.Rows[0]["PIEcoSubName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubName"];
                    fA_XPayIncome.PIType = dt.Rows[0]["PIType"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIType"];

                    return fA_XPayIncome;
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

        public static FA_XPayIncome GetXPayIncomeByPIecosubcoding(string piecosubcoding)
        {
            string sql = "SELECT * FROM FA_XPayIncome WHERE PIEcoSubCoding = @PIEcoSubCoding";

            try
            {
                SqlParameter para = new SqlParameter("@PIEcoSubCoding", piecosubcoding);
                DataTable dt = DBUnity.AdapterToTab(sql, para);

                if (dt.Rows.Count > 0)
                {
                    FA_XPayIncome fA_XPayIncome = new FA_XPayIncome();

                    fA_XPayIncome.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XPayIncome.PIEcoSubCoding = dt.Rows[0]["PIEcoSubCoding"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubCoding"];
                    fA_XPayIncome.PIEcoSubLev = dt.Rows[0]["PIEcoSubLev"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubLev"];
                    fA_XPayIncome.PIEcoSubParID = dt.Rows[0]["PIEcoSubParID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubParID"];
                    fA_XPayIncome.PIEcoSubName = dt.Rows[0]["PIEcoSubName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubName"];
                    fA_XPayIncome.PIType = dt.Rows[0]["PIType"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIType"];

                    return fA_XPayIncome;
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
        /// 根据字符串piecosubcoding前八位来取数据
        /// </summary>
        /// <param name="piecosubcoding">piecosubcoding</param>
        /// <returns></returns>
        public static DataTable GetXPayIncomeByPIecosubcod(string piecosubcoding)
        {
            DataTable dt = null;            
            try
            {
                string sql = "SELECT * FROM  FA_XPayIncome WHERE (LEFT(PIEcoSubCoding, 8) = '{0}')";
                sql = string.Format(sql, piecosubcoding);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XPayIncomeService--GetXPayIncomeByPIecosubcod");
            }
            return dt;
        }

        public static int GetPIEcoSubParID(int piid)
        {
            string sql = string.Format("select PIEcoSubParID from FA_XPayIncome where PIID={0}", piid);
            int t = 0;
            try
            {
                t = Common.common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (Exception e)
            {
                t = 0;
            }
            return t;
        }


    }
}
