//============================================================
// Coded by: bh  At: 2013/10/31 17:14
//============================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using Common;

namespace BudgetWeb.DAL
{
    public class BGReimAppendixService
    {
        #region 添加一条附件信息(通过测试)
        /// <summary>
        /// 添加一条附件信息
        /// </summary>
        /// <param name="radid">附件</param>
        /// <returns>bool</returns>
        public static bool AddAccessories(BG_ReimAppendix radid)
        {

            bool falg = false;
            try
            {
                string sqlStr = @"insert into BG_ReimAppendix(ARID,ARType,ARName,ARContent,ARTime) 
            values(@ARID,@ARType,@ARName,@ARContent,@ARTime)";

                SqlParameter[] Pars = new SqlParameter[] {
                        
                        new SqlParameter("@ARID",radid.ARID),
                        new SqlParameter("@ARType",radid.ARType),
                        new SqlParameter("@ARName",radid.ARName),
                        new SqlParameter("@ARContent",radid.ARContent),
                        new SqlParameter("@ARTime",radid.ARTime)
                       
                        };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch 
            {
              
            }
            return falg;
        }

        #endregion

        #region 查询一条指定报销单据
        /// <summary>
        /// 查询一条指定附件信息
        /// </summary>
        /// <param name="arid">附件信息ID</param>
        /// <returns>BG_ReimAppendix</returns>
        public static BG_ReimAppendix GetAcc(string arid)
        {
            BG_ReimAppendix rm = new BG_ReimAppendix();
            try
            {
                string sqlStr = "select * from BG_ReimAppendix where ARID={0} ";
                sqlStr = string.Format(sqlStr, arid);
                DataTable dt = DBUnity.AdapterToTab(sqlStr);
                if (dt.Rows.Count > 0)
                {
                    rm.RADID = common.IntSafeConvert(dt.Rows[0]["RADID"]);
                    rm.ARID = common.IntSafeConvert(dt.Rows[0]["ARID"]);
                    rm.ARType = dt.Rows[0]["ARType"].ToString();
                    rm.ARTime = DateTime.Parse(dt.Rows[0]["ARTime"].ToString());
                    rm.ARContent = dt.Rows[0]["ARContent"].ToString();
                }
            }
            catch 
            {
                
            }

            return rm;
        }
        #endregion

        #region 查询一条附件信息
        /// <summary>
        /// 查询一条附件信息
        /// </summary>
        /// <param name="radid">附件信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetAccessories(string radid)
        {
            DataTable dt = new DataTable();
            try
            {
                 string sqlStr = "select * from BG_ReimAppendix where ARID={0} ";
                 sqlStr = string.Format(sqlStr, radid);
                 dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch
            {
               
            }
            
            return dt;
        }
        #endregion

        #region 修改指定报销附件信息
        /// <summary>
        /// 修改指定报销附件信息
        /// </summary>
        /// <param name="radid">附件信息</param>
        /// <returns>bool</returns>
        public static bool UpdAccessories(BG_ReimAppendix radid)
        {
            bool flag = false;
            try
            {
                string sqlStr = @"update  BG_ReimAppendix set ARID=@ARID,ARType=@ARType,ARName=@ARName,ARContent=@ARContent,ARTime=@ARTime  where RADID = @RADID";
                SqlParameter[] Pars = new SqlParameter[]{
                        new SqlParameter("@RADID",radid.RADID),
                        new SqlParameter("@ARID",radid.ARID),
                        new SqlParameter("@ARType",radid.ARType),
                        new SqlParameter("@ARName",radid.ARName),
                        new SqlParameter("@ARContent",radid.ARContent),
                        new SqlParameter("@ARTime",radid.ARTime)
                        };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch 
            {
            
            }

            return flag;
        }
        #endregion

        #region 删除指定报销附件信息
        /// <summary>
        ///删除指定报销附件信息
        /// </summary>
        /// <param name="radid">附件信息</param>
        /// <returns>bool</returns>
        public static bool DelAccessories(int   radid)
        { 
            bool falg = false;
            try
            {
                string sqlStr = "delete from  BG_ReimAppendix where RADID = @RADID";

                SqlParameter[] Pars = new SqlParameter[] {
                       new SqlParameter("@RADID",radid)
                        };
                falg = DBUnity.ExecuteNonQuery
                    (CommandType.Text, sqlStr, Pars) > 0;
            }
            catch 
            {
            
            }
            return falg;
        }
        #endregion
    }

}
