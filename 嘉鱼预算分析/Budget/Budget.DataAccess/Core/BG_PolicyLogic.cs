using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;
using System.Data.SqlClient;

namespace BudgetWeb.BLL
{
    public class BG_PolicyLogic
    {
        /// <summary>
        /// 获取编报口径
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUniformRulesDT()
        {
            string sqlStr = "select * from BG_Policy where PType='口径'";
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        /// <summary>
        /// 获取所有政策性文章(管理员端编辑部分)
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllPolicy()
        {
            string sqlStr = "select * from BG_Policy where PType <>'口径' order by POrder";
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }


        /// <summary>
        /// 获取所有已发布政策性文章(用户端查看)
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllPublishPolicy()
        {
            string sqlStr = "select * from BG_Policy where PType ='政策' order by POrder";
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }


        /// <summary>
        /// 更改政策文章发布状态
        /// </summary>
        /// <param name="PLID"></param>
        /// <returns></returns>
        public static bool PublishAppointPolicy(int PLID)
        {
            BG_Policy bg_policy = BG_PolicyService.GetBG_PolicyByPLID(PLID);
            if (bg_policy.PStatus == "已发布")
            {
                bg_policy.PStatus = "未发布";
            }
            else
            {
                bg_policy.PStatus = "已发布";
            }
            bool flag = BG_PolicyService.ModifyBG_Policy(bg_policy);
            return flag;
        }
        ///// <summary>
        ///// 添加信息
        ///// </summary>
        ///// <param name="bG_Policy"></param>
        ///// <returns></returns>
        //public static BG_Policy AddBG_Policy(BG_Policy bG_Policy)
        //{
        //    string sql =
        //        "INSERT BG_Policy (PTitle,PContent, PTime, PFrom, POrder, PType, PStatus)" +
        //        "VALUES (@PTitle, @PContent, @PTime, @PFrom, @POrder, @PType, @PStatus)";

        //    sql += " ; SELECT @@IDENTITY";

        //    try
        //    {
        //        SqlParameter[] para = new SqlParameter[]
        //        {
        //            new SqlParameter("@PTitle", bG_Policy.PTitle ),
        //            new SqlParameter("@PContent", bG_Policy.PContent ),
        //            new SqlParameter("@PTime", bG_Policy.PTime ),
        //            new SqlParameter("@PFrom", bG_Policy.PFrom ),
        //            new SqlParameter("@POrder", bG_Policy.POrder ),
        //            new SqlParameter("@PType", bG_Policy.PType ),
        //            new SqlParameter("@PStatus",bG_Policy.PStatus)
        //        };

        //        string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
        //        int newId = Convert.ToInt32(IdStr);
        //        return 
        //        return GetBG_ApplyReimburByARID(newId);

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw e;
        //    }
        //}
    }
}
