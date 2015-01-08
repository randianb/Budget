using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using System.Data;
using System.Data.SqlClient;

namespace BudgetWeb.BLL
{
    public class BG_DepartmentLogic
    {
        public static BG_Department GetBG_DepartmentByName(string name)
        {
            string sql = "SELECT * FROM BG_Department WHERE DepName = @DepName";

            try
            {
                SqlParameter para = new SqlParameter("@DepName", name);
                DataTable dt = DBUnity.AdapterToTab(sql, para);

                if (dt.Rows.Count > 0)
                {
                    BG_Department bG_Department = new BG_Department();

                    bG_Department.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_Department.DepLev = dt.Rows[0]["DepLev"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepLev"];
                    bG_Department.FaDepID = dt.Rows[0]["FaDepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FaDepID"];
                    bG_Department.DepCode = dt.Rows[0]["DepCode"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepCode"];
                    bG_Department.DepName = dt.Rows[0]["DepName"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepName"];
                    bG_Department.DepQua = dt.Rows[0]["DepQua"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepQua"];
                    bG_Department.DepSta = dt.Rows[0]["DepSta"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepSta"];
                    bG_Department.DepRem = dt.Rows[0]["DepRem"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepRem"];

                    return bG_Department;
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





        public static DataTable GetDepidByName(string depname)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format("select * from BG_Department where DepName='{0}'", depname);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }


        public static BG_Department GetBG_DepartmentByFaDepID(int depID)
        {
            string sql = "SELECT * FROM BG_Department WHERE FaDepID = @FaDepID";

            try
            {
                SqlParameter para = new SqlParameter("@DepID", depID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);

                if (dt.Rows.Count > 0)
                {
                    BG_Department bG_Department = new BG_Department();

                    bG_Department.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_Department.DepLev = dt.Rows[0]["DepLev"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepLev"];
                    bG_Department.FaDepID = dt.Rows[0]["FaDepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FaDepID"];
                    bG_Department.DepCode = dt.Rows[0]["DepCode"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepCode"];
                    bG_Department.DepName = dt.Rows[0]["DepName"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepName"];
                    bG_Department.DepQua = dt.Rows[0]["DepQua"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepQua"];
                    bG_Department.DepSta = dt.Rows[0]["DepSta"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepSta"];
                    bG_Department.DepRem = dt.Rows[0]["DepRem"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepRem"];

                    return bG_Department;
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

        public static DataTable GetAllBG_DepartmentMon(int year, int deptid)
        {
            string sqlAll = string.Format(
                 "SELECT a.DepID , a.DepName  ,b.BAAMon ,b.SuppMon  FROM BG_Department as a "
 + "left join  (SELECT c.DepID , sum(d.BAAMon) as BAAMon ,sum(d.SuppMon) as SuppMon FROM BG_Department as c "
 + "left join BG_BudgetAllocation as d "
 + "on c.FaDepID in  (select  FaDepID from   [dbo].[BG_Department] where DepID ={1}) AND c.DepID=d.DepID  where d.BAAYear={0} "
 + "group by c.DepName ,c.DepID)   as b "
 + "on a.DepID=b.DepID "
 + "where a.FaDepID in  (select  FaDepID from   [dbo].[BG_Department] where DepID ={1})", year, deptid);
            return GetBG_DepartmentBySql(sqlAll);
        }
        public static DataTable GetAllBG_EstimateDepartmentMon(int year, int deptid)
        {
            string sqlAll = string.Format(
                 "SELECT a.DepID , a.DepName  ,b.BEAMon  FROM BG_Department as a "
 + "left join  (SELECT c.DepID , sum(d.BEAMon) as BEAMon  FROM BG_Department as c "
 + "left join BG_EstimatesAllocation as d "
 + "on c.FaDepID in  (select  FaDepID from   [dbo].[BG_Department] where DepID ={1}) AND c.DepID=d.DepID  where d.BEAYear={0} "
 + "group by c.DepName ,c.DepID)   as b "
 + "on a.DepID=b.DepID "
 + "where  a.FaDepID in  (select  FaDepID from   [dbo].[BG_Department] where DepID ={1})", year, deptid);
            return GetBG_DepartmentBySql(sqlAll);
        }
        public static DataTable GetAllBG_Department(int deptid)
        {
            string sqlAll = string.Format("SELECT * FROM BG_Department where FaDepID={0}", deptid);
            return GetBG_DepartmentBySql(sqlAll);
        }

        /// <summary>
        /// 获取部门
        /// </summary>
        /// <param name="faid"></param>
        /// <returns></returns>
        public static DataTable GetBG_Department(int faid)
        {
            string sqlAll = string.Format("SELECT * FROM BG_Department where FaDepID={0}", faid);
            return GetBG_DepartmentBySql(sqlAll);
        }


        public static DataTable GetBG_DepartmentBydepid(int depid)
        {
            string sqlAll = string.Format("SELECT * FROM BG_Department where DepID={0}", depid);
            return GetBG_DepartmentBySql(sqlAll);
        }


        private static DataTable GetBG_DepartmentBySql(string safeSql)
        {

            try
            {
                DataTable dt = DBUnity.AdapterToTab(safeSql);
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }


        public static DataTable GetAllBG_PreviewData()
        {
            string sqlAll = "SELECT * FROM BG_PreviewData";
            return GetBG_PreviewDataBySql(sqlAll);
        }

        private static DataTable GetBG_PreviewDataBySql(string safeSql)
        {

            try
            {
                DataTable dt = DBUnity.AdapterToTab(safeSql);
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }
    }
}
