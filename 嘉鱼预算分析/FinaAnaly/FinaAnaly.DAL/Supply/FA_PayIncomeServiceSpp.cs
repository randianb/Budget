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
    public static partial class FA_PayIncomeService
    {
        public static DataTable GetPayIncomeByPItype(string pitype)
        {
            DataTable dt = null;
            try
            {
                string sql = string.Format("SELECT * FROM FA_PayIncome WHERE PIType = '{0}'", pitype);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_PayIncomeService--GetPayIncomeByPItype");
            }
            return dt;
        }

        public static FA_PayIncome GetPayIncomeByPIecosubname(string piecosubname)
        {
            string sql = "SELECT * FROM FA_PayIncome WHERE PIEcoSubName = @PIEcoSubName";

            try
            {
                SqlParameter para = new SqlParameter("@PIEcoSubName", piecosubname);
                DataTable dt = DBUnity.AdapterToTab(sql, para);

                if (dt.Rows.Count > 0)
                {
                    FA_PayIncome fA_PayIncome = new FA_PayIncome();

                    fA_PayIncome.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_PayIncome.PIEcoSubCoding = dt.Rows[0]["PIEcoSubCoding"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubCoding"];
                    fA_PayIncome.PIEcoSubLev = dt.Rows[0]["PIEcoSubLev"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubLev"];
                    fA_PayIncome.PIEcoSubParID = dt.Rows[0]["PIEcoSubParID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubParID"];
                    fA_PayIncome.PIEcoSubName = dt.Rows[0]["PIEcoSubName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubName"];
                    fA_PayIncome.PIType = dt.Rows[0]["PIType"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIType"];

                    return fA_PayIncome;
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

        public static DataTable GetGroupFA_PayIncome(string PIType, string type, int tem)
        {
            int tt = 0;
            if (type == "财政拨款")
            {
                tt = 500101;
            }
            else
            {
                tt = 500102;
            }
            DataTable dt = null;
            if (tem == 1)
            {
                try
                {
                    string str = string.Format("select * from FA_XPayIncome where PIType='{0}' and PIEcoSubCoding like '{1}%' and PIEcoSubLev={2}", PIType, tt, tem);
                    dt = DBUnity.AdapterToTab(str);
                }
                catch
                {
                    dt = null;
                }
                return dt;
            }
            else
            {
                try
                {
                    string str = string.Format("select * from FA_XPayIncome where PIType='{0}' and PIEcoSubCoding like '{1}%' and PIEcoSubParID={2}", PIType, tt, tem);
                    dt = DBUnity.AdapterToTab(str);
                }
                catch
                {
                    dt = null;
                }
                return dt;
            }
        }

        public static bool GetBoolPayIncome(string incomeinfo, string ftype, int tem)
        {
            int tt = 0;
            if (ftype == "财政拨款")
            {
                tt = 500101;
            }
            else
            {
                tt = 500102;
            }
            bool flag = false;
            int t = 0;
            string sql = string.Format("select * from FA_XPayIncome where PIType='{0}' and PIEcoSubCoding like '{1}%' and PIEcoSubParID={2}", incomeinfo, tt, tem);
            t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            if (t > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public static DataTable GetGroupFA_PayIncome(int tem)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format("select * from FA_XPayIncome where  PIEcoSubParID={0}", tem);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static bool GetBoolPayIncome(int piid)
        {
            bool flag = false;
            int t = 0;
            string sql = string.Format("select * from FA_XPayIncome where PIEcoSubParID={0}", piid);
            t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            if (t > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
    }
}
