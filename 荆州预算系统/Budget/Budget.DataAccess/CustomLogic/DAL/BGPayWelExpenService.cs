using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Common;
using BudgetWeb.Model;
using System.Data.SqlClient;

namespace BudgetWeb.DAL
{
    public class BGPayWelExpenService
    {
        /// <summary>
        /// 工资福利支出表
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBGPayExpByDepID(int depid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_PayWelExpen  where  DepID ={0}";
                sqlStr = string.Format(sqlStr, depid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "BGPayWelExpenService--GetBGPayExpByDepID");
            }
            return dt;
        }



        /// <summary>
        /// 通过pweid删除BG_PayWelExpen
        /// </summary>
        /// <param name="dpbid">PWEID</param>
        /// <returns>bool</returns>
        public static bool DelPayWelExpenByPweid(int pweid)
        {
            bool flag = false;
            try
            {
                string sqlStr = "delete from BG_PayWelExpen where  PWEID ={0}";
                sqlStr = string.Format(sqlStr, pweid);
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, null) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGPayWelExpenService--DelPayWelExpenByPweid");
            }
            return flag;
        }

        /// <summary>
        /// 添加一条【工资福利支出】记录 BG_PayWelExpen 
        /// </summary>
        /// <param name="dpb">BGPayWelExpen</param>
        /// <returns>bool</returns>
        public static bool AddPWE(BG_PayWelExpen pwe)
        {
            bool falg = false;
            try
            {
                string sqlStr = @"insert into BG_PayWelExpen(PWEYear,DepID,PWESubTotal,PWEBasWage,PWEAlloSub,PWEPrize,PWEPerWage,PWESafePay,PWEOth)
                   values(@PWEYear,@DepID,@PWESubTotal,@PWEBasWage,@PWEAlloSub,@PWEPrize,@PWEPerWage,@PWESafePay,@PWEOth)";
                SqlParameter[] Pars = new SqlParameter[] { 
                        new SqlParameter("@PWEYear",pwe.PWEYear),
                        new SqlParameter("@DepID",pwe.DepID),
                        new SqlParameter("@PWESubTotal",pwe.PWESubTotal),
                        new SqlParameter("@PWEBasWage",pwe.PWEBasWage),
                        new SqlParameter("@PWEAlloSub",pwe.PWEAlloSub),
                        new SqlParameter("@PWEPrize",pwe.PWEPrize),
                        new SqlParameter("@PWEPerWage",pwe.PWEPerWage),
                        new SqlParameter("@PWEOth",pwe.PWEOth),
                        new SqlParameter("@PWESafePay",pwe.PWESafePay)
                };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BGPayWelSupplyService--AddPWS");
            }
            return falg;
        }
    }
}
