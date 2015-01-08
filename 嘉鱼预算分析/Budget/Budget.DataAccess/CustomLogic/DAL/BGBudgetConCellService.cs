using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace BudgetWeb.DAL
{
    public class BGBudgetConCellService
    {
        #region 查询指定预算项目下的所有控制单元
        /// <summary>
        /// 通过控制单元ID查询控制单元(测试成功！)
        /// </summary>
        /// <param name="depid">单元ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBudgetConCellListByPIID(string piid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_BudgetConCell where PIID={0}";//BCCID
                sqlStr = string.Format(sqlStr, piid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudgetConCellService--GetBudgetConCellListByBudid");
            }
            return dt;
        }
        #endregion

        
        public static bool AddSingleBudgetConCell(BG_BudgetConCell cell)
        {
            //添加单条记录
//       
            bool flag = false;
            try
            {
                string sqlstr = @"insert into BG_BudgetConCell(PIID,BCCName,BCCStan,BCCUseSta)
               values(@PIID,@BCCName,@BCCStan,@BCCUseSta)";
                SqlParameter[] Pars = new SqlParameter[] { 
                    new SqlParameter("@PIID",cell.PIID),
                    new SqlParameter("@BCCName",cell.BCCName),
                    new SqlParameter("@BCCStan",cell.BCCStan),
                    new SqlParameter("@BCCUseSta",cell.BCCUseSta)
                };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlstr, Pars) > 0;
            }
            catch (Exception ex)
            {

                flag = false;
                Log.WriteLog(ex.Message, "BGBudgetConCellService--AddSingleBudgetConCell");
            }
            return flag;
        }

        /// <summary>
        /// 删除指定PIID的所有控制单元
        /// </summary>
        /// <param name="piid"></param>
        /// <returns></returns>
        public static bool DelAppPIIDConCell(string piid)
        {

            
            //
            //del  from  BG_BudgetConCell      where   PIID = PIID
            bool flag = false;
            try
            {
                string sqlStr = "delete from BG_BudgetConCell where PIID=@PIID";
                SqlParameter[] Pars = new SqlParameter[]{
                    new SqlParameter ("@PIID",piid ) 

                };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;

            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGBudgetConCellService--DelAppPIIDConCell");
                 
            }

            return flag ;
        }


        /// <summary>
        /// 批量添加
        /// </summary>
        public static bool AddBudgetConCell(List<BG_BudgetConCell> list)
        {
            //string pName = "";
            //List<SqlParameter> pList = new List<SqlParameter>()
            //{
            //    //DBHelper.CreateSqlParemeterStructured("@Dt",dt)
            //};
            //try
            //{
            //    //DBHelper.RunProcedure(pName, pList);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}

            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    AddSingleBudgetConCell(list[i]);
                }
                return true;
            }
            catch(Exception ex)
            {
                Log.WriteLog(ex.Message, "BGBudgetConCellService--AddBudgetConCell");
                return false;
            }
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        public static bool UpdateBantch(List<BG_BudgetConCell> list, string piid)
        {

            


            //string pName = "";
            //List<SqlParameter> pList = new List<SqlParameter>()
            //{
            //    //DbHelper.CreateSqlParemeterStructured("@Dt",dt)
            //};
            //try
            //{
            //    //DbHelper.RunProcedure(pName, pList);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}



            //先删除
            DelAppPIIDConCell(piid);
            //后更新
            AddBudgetConCell(list);

            return true;
        }

    }

}
