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
    public class BGDayPubBudgetService
    {
        /// <summary>
        /// 日常公用支出预算表
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBGDayPubBudgetByDepID(int depid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_DayPubBudget where  DepID ={0}";
                sqlStr = string.Format(sqlStr, depid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "BGDayPubBudgetService--GetBGDayPubBudgetByDepID");
            }
            return dt;
        }

        /// <summary>
        /// 通过dpbid删除BG_DayPubBudget
        /// </summary>
        /// <param name="dpbid">DPBID</param>
        /// <returns>bool</returns>
        public static bool DelDayPubBudByDpbid(int dpbid)
        {
            bool flag = false;
            try
            {
                string sqlStr = "delete from BG_DayPubBudget where  DPBID ={0}";
                sqlStr = string.Format(sqlStr, dpbid);
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, null) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGDayPubBudgetService--DelDayPubBudByDpbid");
            }
            return flag;
        }

        /// <summary>
        /// 添加一条【日常公用支出预算】记录BG_DayPubBudget
        /// </summary>
        /// <param name="dpb">BGDayPubBudget</param>
        /// <returns>bool</returns>
        public static bool AddDPB(BG_DayPubBudget dpb)
        {
            bool falg = false;
            try
            {
                string sqlStr = @"insert into BG_DayPubBudget(DPBYear,DepID ,DPBTotal,DPBSubTotal,DPBOffCost,DPBWatEleCost,DPBPostCost,DPBCarMaiCost,DPBTraCost,DPBMaiCost,
                DPBMeetCost,DPBCulCost,DPBOffRecCost,DPBOffAbrCost,DPBTraUniCost,DPBWelCost,DPBComOther,DPBOffSubTotal,DPBOffEquAcqExp,DPBCapOther) 
                values(@DPBYear,@DepID ,@DPBTotal,@DPBSubTotal,@DPBOffCost,@DPBWatEleCost,@DPBPostCost,@DPBCarMaiCost,@DPBTraCost,@DPBMaiCost,@DPBMeetCost,
                @DPBCulCost,@DPBOffRecCost,@DPBOffAbrCost,@DPBTraUniCost,@DPBWelCost,@DPBComOther,@DPBOffSubTotal,@DPBOffEquAcqExp,@DPBCapOther)";
                SqlParameter[] Pars = new SqlParameter[] { 
                        new SqlParameter("@DPBYear",dpb.DPBYear),
                        new SqlParameter("@DepID",dpb.DepID),
                        new SqlParameter("@DPBTotal",dpb.DPBTotal),
                        new SqlParameter("@DPBSubTotal",dpb.DPBSubTotal),
                        new SqlParameter("@DPBOffCost",dpb.DPBOffCost),
                        new SqlParameter("@DPBWatEleCost",dpb.DPBWatEleCost),
                        new SqlParameter("@DPBPostCost",dpb.DPBPostCost),
                        new SqlParameter("@DPBCarMaiCost",dpb.DPBCarMaiCost),
                        new SqlParameter("@DPBTraCost",dpb.DPBTraCost),
                        new SqlParameter("@DPBMaiCost",dpb.DPBMaiCost),
                        new SqlParameter("@DPBMeetCost",dpb.DPBMeetCost),
                        new SqlParameter("@DPBCulCost",dpb.DPBCulCost),
                        new SqlParameter("@DPBOffRecCost",dpb.DPBOffRecCost),
                        new SqlParameter("@DPBOffAbrCost",dpb.DPBOffAbrCost),
                        new SqlParameter("@DPBTraUniCost",dpb.DPBTraUniCost),
                        new SqlParameter("@DPBWelCost",dpb.DPBWelCost),
                        new SqlParameter("@DPBComOther",dpb.DPBComOther),
                        new SqlParameter("@DPBOffSubTotal",dpb.DPBOffSubTotal),
                        new SqlParameter("@DPBOffEquAcqExp",dpb.DPBOffEquAcqExp),
                        new SqlParameter("@DPBCapOther",dpb.DPBCapOther)
                };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BGDayPubBudgetService--AddDPB");
            }
            return falg;
        }
    }
}
