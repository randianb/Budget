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
    public class BGPayWelSupplyService
    {
        /// <summary>
        /// 对个人和家庭的补助支出表
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBGPayWelSupplyByDepID(int depid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_PayWelSupply where  DepID ={0}";
                sqlStr = string.Format(sqlStr, depid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "BGPayWelSupplyService--GetBGPayWelSupplyByDepID");
            }
            return dt;
        }

        /// <summary>
        /// 通过gseid删除BG_PayWelExpen
        /// </summary>
        /// <param name="dpbid">GSEID</param>
        /// <returns>bool</returns>
        public static bool DelPayWelSupplyByPweid(int gseid)
        {
            bool flag = false;
            try
            {
                string sqlStr = "delete from BG_PayWelSupply where GSEID ={0}";
                sqlStr = string.Format(sqlStr, gseid);
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, null) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGPayWelSupplyService--DelPayWelSupplyByPweid");
            }
            return flag;
        }

        /// <summary>
        /// 添加一条【对个人和家庭的补助支出】记录 BG_PayWelSupply
        /// </summary>
        /// <param name="dpb">BGPayWelSupply</param>
        /// <returns>bool</returns>
        public static bool AddPWS(BG_PayWelSupply pws)
        {
            bool falg = false;
            try
            {
                string sqlStr = @"insert into BG_PayWelSupply(GSEYear,DepID,GSETotal,OffSubTot,OffPerPart,OffPubPart,EbbSubTot,
                EbbPerPart,EbbPubPart,GSEHouPro,GSEMedChar,LifeAllo,GSEOther)values(@GSEYear,@DepID,@GSETotal,@OffSubTot,
                @OffPerPart,@OffPubPart,@EbbSubTot,@EbbPerPart,@EbbPubPart,@GSEHouPro,@GSEMedChar,@LifeAllo,@GSEOther)";
                SqlParameter[] Pars = new SqlParameter[] { 
                        new SqlParameter("@GSEYear",pws.GSEYear),
                        new SqlParameter("@DepID",pws.DepID),
                        new SqlParameter("@GSETotal",pws.GSETotal),
                        new SqlParameter("@OffSubTot",pws.OffSubTot),
                        new SqlParameter("@OffPerPart",pws.OffPerPart),
                        new SqlParameter("@OffPubPart",pws.OffPubPart),
                        new SqlParameter("@EbbSubTot",pws.EbbSubTot),
                        new SqlParameter("@EbbPerPart",pws.EbbPerPart),
                        new SqlParameter("@EbbPubPart",pws.EbbPubPart),
                        new SqlParameter("@GSEHouPro",pws.GSEHouPro),
                        new SqlParameter("@GSEMedChar",pws.GSEMedChar),
                        new SqlParameter("@LifeAllo",pws.LifeAllo),
                        new SqlParameter("@GSEOther",pws.GSEOther)
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
