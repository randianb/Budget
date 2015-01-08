using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using Common;

namespace BudgetWeb.BLL
{
    public class BG_PayIncomeLogic
    {
        /// <summary>
        /// 获取全部支出经济科目
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPayIncomeDt()
        {
            DataTable dt = null;
            try
            {
                string sqlStr = "select * from BG_PayIncome";
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch
            {
                dt = null;
            }
            return dt;

        }


        public static DataTable DtDeal()
        {
            DataTable dt = GetPayIncomeDt();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["PIEcoSubCoding"] = dt.Rows[i]["PIEcoSubCoding"].ToString().Replace("\t", string.Empty);
                }
            }
            return dt;
        }
        public static DataTable GetDtPayIncome(string PIType, string type, int tem)
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
                    string str = string.Format("select * from BG_PayIncome where PIType='{0}' and PIEcoSubCoding like '{1}%' and PIEcoSubLev={2}", PIType, tt, tem);
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
                    string str = string.Format("select * from BG_PayIncome where PIType='{0}' and PIEcoSubCoding like '{1}%' and PIEcoSubParID={2}", PIType, tt, tem);
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
            string sql = string.Format("select * from BG_PayIncome where PIType='{0}' and PIEcoSubCoding like '{1}%' and PIEcoSubParID={2}", incomeinfo, tt, tem);
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

        public static DataTable GetAllBG_PayIncome()
        {
            DataTable dt = null;
            try
            {
                string sql = "select PIEcoSubName from dbo.BG_PayIncome group by PIEcoSubName";
                dt = DBUnity.AdapterToTab(sql);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable GetBG_PayIncomeByname(string p)
        {
            DataTable dt = null;
            try
            {
                string sql = string.Format("select PIID from dbo.BG_PayIncome where PIEcoSubName='{0}'", p);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static int GetPIIDbycoding(int Subcoding, string ARExpSub)
        {
            int piid = 0;
            try
            {
                string sql = string.Format("select PIID from dbo.BG_PayIncome where PIEcoSubCoding like '{0}%' and PIEcoSubName='{1}'", Subcoding, ARExpSub);
                piid = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch
            {
                piid = 0;
            }
            return piid;
        }

        public static DataTable GetDtPayIncomeByPIID(int piid)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format("select * from BG_PayIncome where PIEcoSubParID={0}", piid);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static bool GetBoolPayIncomeByPIID(int piid)
        {
            bool flag = false;
            int t = 0;
            try
            {
                string sql = string.Format("select count(*) from BG_PayIncome where PIEcoSubParID={0}", piid);
                t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
                if (t > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (System.Exception ex)
            {
                flag = false;
            }

            return flag;
        }

        public static DataTable GetDtPayIncome()
        { 
            DataTable dt = null;
            try
            {
                string sql = string.Format("select PIID, PIEcoSubName , ISSign from BG_PayIncome where PIEcoSubParID=0 ");
                dt = DBUnity.AdapterToTab(sql);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static bool ISSign(int piid)
        {
            bool flag = false;
            int t = 0;
            try
            {
                string sql = string.Format("select count(*) from BG_PayIncome where ISSign=1 and piid={0}", piid);
                t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
                if (t > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (System.Exception ex)
            {
                flag = false;
            }

            return flag;
        }

        public static bool GetLever(int g)
        {
            bool flag = false;
            int t = 0;
            try
            {
                string sql = string.Format("select count(*) from BG_PayIncome where PIEcoSubLev={0}", g);
                t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
                if (t > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }

            return flag;
        }
        public static bool GetLeverByPIID(int piid)
        {
            bool flag = false;
            int t = 0;
            try
            {
                string sql = string.Format("select count(*) from BG_PayIncome where PIEcoSubParID={0} and PIEcoSubLev=3", piid);
                t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
                if (t > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }

            return flag;
        }

        public static bool GetBoolByPiid(int piid)
        {
            bool flag = false;
            int t = 0;
            try
            {
                string sql = string.Format("select count(*) from BG_PayIncome where piid={0}", piid);
                t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
                if (t > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }

            return flag;
        }
    }
}
