using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
    public class BGBudItemHisService
    {
        /// <summary>
        /// 添加一条预算项目历史信息
        /// </summary>
        /// <param name="budItems">一条预算项目历史实例</param>
        /// <returns>bool</returns>
        public static bool InsertBudItemHis(BG_BudItems budItems)
        {
            bool flag = false;
            try
            {
                string sqlStr = @"insert into BG_BudItemHis(BudID,BIProType,BIFunSub,BICode,PPID,PIID,BIPlanHz,BIStaTime,BIEndTime,BICharger,BIAttr,BIAppReaCon,BIExpGistExp,BILongGoal,BIYearGoal,
                BIMon,BIAppConMon,BIMonSou,BIFinAllo,BILastYearCarry,BIOthFun,BIOthExpProb,BIBudSta,BudSta,BICause,DepID,BIProName,BIReportTime,BIConNum,BIProDescrip,BIProCategory) 
                values(@BudID,@BIProType,@BIFunSub,@BICode,@PPID,@PIID,@BIPlanHz,@BIStaTime,@BIEndTime,@BICharger,@BIAttr,@BIAppReaCon,@BIExpGistExp,@BILongGoal,@BIYearGoal,@BIMon,@BIAppConMon,
                @BIMonSou,@BIFinAllo,@BILastYearCarry,@BIOthFun,@BIOthExpProb,@BIBudSta,@BudSta,@BICause,@DepID,@BIProName,@BIReportTime,@BIConNum,@BIProDescrip,@BIProCategory)";
                SqlParameter[] Pars = new SqlParameter[]{
                        new SqlParameter("@BudID",budItems.BudID),
                        new SqlParameter("@BIProType",budItems.BIProType),
                        new SqlParameter("@BIFunSub",budItems.BIFunSub),
                        new SqlParameter("@BICode",budItems.BICode),
                        new SqlParameter("@PPID",budItems.PPID),
                        new SqlParameter("@PIID",budItems.PIID),
                        new SqlParameter("@BIPlanHz",budItems.BIPlanHz),
                        new SqlParameter("@BIStaTime",budItems.BIStaTime),
                        new SqlParameter("@BIEndTime",budItems.BIEndTime),
                        new SqlParameter("@BICharger",budItems.BICharger),
                        new SqlParameter("@BIAttr",budItems .BIAttr ),
                        new SqlParameter("@BIAppReaCon",budItems.BIAppReaCon),
                        new SqlParameter("@BIExpGistExp",budItems.BIExpGistExp),
                        new SqlParameter("@BILongGoal",budItems.BILongGoal),
                        new SqlParameter("@BIYearGoal",budItems.BIYearGoal),
                        new SqlParameter("@BIMon",budItems.BIMon),
                        new SqlParameter("@BIAppConMon",budItems.BIAppConMon),
                        new SqlParameter("@BIMonSou",budItems .BIMonSou ),
                        new SqlParameter("@BIFinAllo",budItems .BIFinAllo ),
                        new SqlParameter("@BILastYearCarry",budItems.BILastYearCarry),
                        new SqlParameter("@BIOthFun",budItems.BIOthFun),
                        new SqlParameter("@BIOthExpProb",budItems.BIOthExpProb),
                        new SqlParameter("@BIBudSta",budItems.BIBudSta),
                        new SqlParameter("@BudSta",budItems.BudSta),
                        new SqlParameter("@BICause",budItems.BICause),
                        new SqlParameter("@DepID",budItems.DepID),
                        new SqlParameter("@BIProName",budItems.BIProName),
                        new SqlParameter("@BIReportTime",budItems.BIReportTime),
                        new SqlParameter("@BIConNum",budItems.BIConNum),
                        new SqlParameter("@BIProDescrip",budItems.BIProDescrip),
                        new SqlParameter("@BIProCategory",budItems.BIProCategory)
                        };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "BG_BudItemHisService--InsertBudItemHis");
            }
            return flag;
        }

        /// <summary>
        /// 查询指定BudID的所有历史操作轨迹
        /// </summary>
        /// <param name="budid"></param>
        /// <returns></returns>
        public static DataTable GetDtBIHisByBudid(int budid, int PageSize, int pageIndex, out int RecordCount)
        {
            DataTable dt =null;
            RecordCount = 0;
            string sqlStr = "select * from BG_BudItemHis";
            string filter = " where BudID ={0} order by BudID asc";
            filter = string.Format(filter, budid);
            sqlStr += filter;
            try
            {
                string sql_bc = "select count(*) from BG_BudItemHis  where BudID = "+budid.ToString();
                string CountStr = DBUnity.ExecuteScalar(CommandType.Text, sql_bc, null);
                RecordCount = common.IntSafeConvert(CountStr);
                dt = DBUnity.GetAspNetPager(sqlStr, pageIndex, PageSize);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BG_BudItemHisService--GetDtBIHisByBudid");
            }
            return dt;
        }


        /// <summary>
        /// 查询指定BudID的退回次数
        /// </summary>
        /// <param name="budid"></param>
        /// <returns></returns>
        public static int GetBIReportNumByBudid(int budid)
        {
            int Num = 0;

            string sqlStr = string.Format("select count(*) from BG_BudItemHis where BudID ={0} and BudSta='退回'", budid);

            try
            {
                Num = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "BG_BudItemHisService--GetBIReportNumByBudid");
            }
            return Num;
        }
    }
}
