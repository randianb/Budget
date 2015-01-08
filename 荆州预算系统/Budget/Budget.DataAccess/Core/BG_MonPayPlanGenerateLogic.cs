using BudgetWeb.DAL;
using BudgetWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;

namespace BudgetWeb.BLL
{
    public class BG_MonPayPlanGenerateLogic
    {
        public static DataTable GetMonPay(int year, int depid)
        {
            DataTable dt = new DataTable();
            string sqlStr =
                "select a.PIEcoSubName,sum (b.BAAMon) as BAAMon ,sum(b.SuppMon) as SuppMon from dbo.BG_PayIncome as a right join dbo.BG_BudgetAllocation as b on a.PIID=b.PIID  Where b.BAAYear={0} and b.DepID={1} group by a.PIEcoSubName ";
            sqlStr = string.Format(sqlStr, year, depid);
            dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        public static DataTable GetMonPayTime(string yearMonth, int depid, int Times)
        {
            DataTable dt = new DataTable();
            string sqlStr = "select * from  dbo.BG_MonPayPlan where deptid={0} and Convert(varchar(7),MPTime,120)='{1}' and MPFundingAddTimes<={2}";
            sqlStr = string.Format(sqlStr, depid, yearMonth,Times);
            dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }
        public static DataTable GetMonPayTime1(string yearMonth, int depid, int Times)
        {
            DataTable dt = new DataTable();
            string sqlStr = "select * from  dbo.BG_MonPayPlan where deptid={0} and Convert(varchar(7),MPTime,120)='{1}' and MPFundingAddTimes={2}";
            sqlStr = string.Format(sqlStr, depid, yearMonth, Times);
            dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }
        public static DataTable GetMonPayTimepici(string yearMonth, int depid, int Times)
        {
            DataTable dt = new DataTable();
            string sqlStr = "select * from  dbo.BG_MonPayPlan where deptid={0} and Convert(varchar(7),MPTime,120)='{1}' and MPFundingAddTimes={2}";
            sqlStr = string.Format(sqlStr, depid, yearMonth, Times);
            dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        public static decimal GetMonPayYear(int PPID, int depid, int year)
        {
            DataTable dt = new DataTable();
            string sqlStr =
                "select sum(MPFunding) as mon from  dbo.BG_MonPayPlan where deptid={0} and PIID={1} and Year(MPTime)={2}";
            sqlStr = string.Format(sqlStr, depid, PPID, year);
            decimal t = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            return t;
        }

        //public static bool IsMonPay(string yearMonth, int depid)
        //{
        //    bool flag = false;
        //    string sqlStr = "select count(*) from dbo.BG_MonPayPlanRemark where Convert(varchar(7),MATime,120)='{0}' and DeptID={1} and  MASta in ('提交','审核通过','审核不通过')";
        //    sqlStr = string.Format(sqlStr, yearMonth, depid);
        //    if (DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null)=="0")
        //        flag = false;
        //    else
        //        flag = true;
        //    return flag;
        //}

        public static bool IsAuditMonPay(string yearMonth, int depid,int pici)
        {
            bool flag = false;
            string sqlStr =
                "select count(*) from dbo.BG_MonPayPlanRemark where Convert(varchar(7),MATime,120)='{0}' and DeptID={1} and MATimes={2} and  MASta in ('审核通过')";
            sqlStr = string.Format(sqlStr, yearMonth, depid,pici);
            if (DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null) == "0")
                flag = false;
            else
                flag = true;
            return flag;
        }

        public static bool IsSubmitMonPay(string yearMonth, int depid,int pici)
        {
            bool flag = false;
            string sqlStr =
                "select count(*) from dbo.BG_MonPayPlanRemark where Convert(varchar(7),MATime,120)='{0}' and DeptID={1} and MATimes={2} and  MASta in ('提交')";
            sqlStr = string.Format(sqlStr, yearMonth, depid,pici);
            if (DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null) == "0")
                flag = false;
            else
                flag = true;
            return flag;
        }

        public static bool IsnotAuditMonPay(string yearMonth, int depid)
        {
            bool flag = false;
            string sqlStr =
                "select count(*) from dbo.BG_MonPayPlanRemark where Convert(varchar(7),MATime,120)='{0}' and DeptID={1} and  MASta in ('审核不通过')";
            sqlStr = string.Format(sqlStr, yearMonth, depid);
            if (DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null) == "0")
                flag = false;
            else
                flag = true;
            return flag;
        }

        public static bool IsnotSubmitMonPay(string yearMonth, int depid)
        {
            bool flag = false;
            string sqlStr =
                "select count(*) from dbo.BG_MonPayPlanRemark where Convert(varchar(7),MATime,120)='{0}' and DeptID={1} and  MASta in ('未提交','提交','审核通过','审核不通过','退回')";
            sqlStr = string.Format(sqlStr, yearMonth, depid);
            if (DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null) == "0")
                flag = false;
            else
                flag = true;
            return flag;
        }

        public static int GetSubmitMonPayremarkID(string yearMonth, int depid,int pici)
        {
            int id = 0;
            string sqlStr =
                "select PRID from dbo.BG_MonPayPlanRemark where Convert(varchar(7),MATime,120)='{0}' and DeptID={1} and MATimes={2} and  MASta in ('未提交','提交','审核通过','审核不通过','退回')";
            sqlStr = string.Format(sqlStr, yearMonth, depid,pici);
            id = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            return id;
        }

        public static decimal GetMonauditPay(string YearMonth)
        {
            decimal t = 0;
            string sqlStr =
                "select sum(Armon) as armon from dbo.BG_ApplyReimbur where Convert(varchar(7),ARTime,120)='{0}' and  ARListSta='审核通过'";
            sqlStr = string.Format(sqlStr, YearMonth);
            try
            {
                t = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
                if (t <= 0)
                {
                    t = 0;
                }
            }
            catch (System.Exception ex)
            {
                t = 0;
            }

            return t;
        }

        public static DataTable GetMonlatePay(int year, int depid)
        {
            DataTable dt = new DataTable();
            string sqlStr =
                "select ppid,sum(Armon) as armon from dbo.BG_ApplyReimbur where year(ARTime)={0} and  ARListSta='审核通过' and depid={1} group by ppid";
            sqlStr = string.Format(sqlStr, year, depid);
            dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        //修改
        public static bool ISMonlatePay(string yearmonth, int depid,int pici)
        {
            bool flag = false;
            string sqlStr =
                "select count(*) from dbo.BG_MonPayPlanRemark where Convert(varchar(7),MATime,120)='{0}' and  MASta='退回' or MASta='审核不通过'   and deptid={1} and MATimes={2}";
            sqlStr = string.Format(sqlStr, yearmonth, depid,pici);
            int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
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

        public static string MonlatePayCause(string yearmonth, int depid)
        {
            string sqlStr =
                "select MACause from dbo.BG_MonPayPlanRemark where Convert(varchar(7),MATime,120)='{0}' and  MASta='退回' or MASta='审核不通过'   and deptid={1}";
            sqlStr = string.Format(sqlStr, yearmonth, depid);
            string t = DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null);
            if (t.Length > 0)
            {
                return t;
            }
            else
            {
                t = "未说明退回理由";
            }
            return t;
        }

        public static bool IsPIEName(int fppid)
        {
            bool flag = false;
            string sql = string.Format("select count(*) from BG_PayIncome where PIID={0}", fppid);
            int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
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

        public static DataTable GetPIEName(int fppid)
        {
            DataTable dt = null;
            string sqlStr = string.Format("select * from BG_PayIncome where PIID={0}", fppid);
            dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }


        public static int IsMonplanByPIIDDepID(int PIID, int depid, string yearMonth)
        {
            //bool flag = false;
            string sqlStr =
                "select count(*) from  dbo.BG_MonPayPlan where deptid={0} and Convert(varchar(7),MPTime,120)='{1}'and PIID={2}";
            sqlStr = string.Format(sqlStr, depid, yearMonth, PIID);
            int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            //if (t > 0)
            //{
            //    flag = true;
            //}
            //else
            //{
            //    flag = false;
            //}
            return t;
        }

        public static decimal GetbxMon(string yearMonth, int DepID)
        {
            decimal tt = 0;
            try
            {
                string sql =
                    "select count(Armon) as Armon ,DepID from dbo.BG_ApplyReimbur where Convert(varchar(7),ARTime,120)<='{0}' and  ARListSta='审核通过' Where Depid ={1} group by DepID";
                sql = string.Format(sql, yearMonth, DepID);
                tt = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (Exception)
            {
                tt = 0;
            }
            return tt;
        }

        public static DataTable GetMonByTime(string yearMonth)
        {
            DataTable dt = null;
            try
            {
                string sql = "select DeptID from BG_MonPayPlanRemark where Convert(varchar(7),MATime,120)='{0}' ";
                sql = string.Format(sql, yearMonth);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }
        public static decimal GetsqMon(string yearMonth, int Depid)
        {
            decimal tt = 0;
            try
            {
                string sql =
                    "select sum(MPFunding) as MPFunding from BG_MonPayPlan where Convert(varchar(7),MPTime,120)='{0}' and deptid={1}";
                sql = string.Format(sql, yearMonth, Depid);
                tt = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (Exception)
            {
                tt = 0;
            }
            return tt;
        }
        public static decimal GetsqMon(string yearMonth, int Depid,int pici)
        {
            decimal tt = 0;
            try
            {
                string sql =
                    "select sum(MPFunding) as MPFunding from BG_MonPayPlan where Convert(varchar(7),MPTime,120)='{0}' and deptid={1} and MPFundingAddTimes={2} ";
                sql = string.Format(sql, yearMonth, Depid,pici);
                tt = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (Exception)
            {
                tt = 0;
            }
            return tt;
        }

        public static decimal GetsqMont(string yearMonth, int Depid)
        {
            decimal tt = 0;
            try
            {
                string sql =
                    "select sum(MPFunding) as MPFunding from BG_MonPayPlan where Convert(varchar(7),MPTime,120)<='{0}' and deptid={1} ";
                sql = string.Format(sql, yearMonth, Depid);
                tt = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (Exception)
            {
                tt = 0;
            }
            return tt;
        }

        public static void DelMonPay(string yearMonth, int depid)
        {
            string sql = "delete from BG_MonPayPlan where Convert(varchar(7),MPTime,120)={0} and deptid={1}";
            sql = string.Format(sql, yearMonth, depid);
            DBUnity.ExecuteNonQuery(CommandType.Text, sql, null);
        }

        public static decimal GetYearMon(string CurrentYear, int p, int piid)
        {
            int t = 0;
            try
            {
                string sql =
                    "select sum(MPFunding) from BG_MonPayPlan where Year(MPTime)={0} and deptid={1} and piid={2}";
                sql = string.Format(sql, CurrentYear, p, piid);
                t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (System.Exception ex)
            {
                t = 0;
            }

            return t;
        }

        public static decimal getAllMon(int depid,string YearMonth)
        {
            decimal t = 0;
            try
            {
                string sql = string.Format("select sum([MPFunding]) as Mon from [dbo].[BG_MonPayPlan] where Convert(varchar(7),MPTime,120)='{0}' and DeptID={1}", YearMonth, depid);
                t =ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (System.Exception ex)
            {
                t = 0;
            }

            return t;
        }

        public static int GetSubmitMonPayremarkTimes(string yearMonth, int depId)
        {
            int t = 0;
            try
            {
                string sql = string.Format("select max(MATimes)as MATimes from [dbo].[BG_MonPayPlanRemark] where Convert(varchar(7),MATime,120)='{0}' and DeptID={1}", yearMonth, depId);
                t =common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (System.Exception ex)
            {
                t = 0;
            }

            return t;
        }
    }
}

#region sssss

//        public static BG_MonPayPlanGenerate GetMonPayPlanGenerateByyeardepid(int year, int depid)
//        {
//            try
//            {
//                DataTable dt = new DataTable();
//                string sqlStr = "select BG_PayIncome.*,BG_BudgetAllocation.* from  dbo.BG_PayIncome  left join BG_BudgetAllocation on BG_PayIncome.PIID=BG_BudgetAllocation.PIID where (BAAYear={0} or BAAYear is null) and (DepID={1} or DepId is null)";
//                sqlStr = string.Format(sqlStr, depid, year);
//                dt = DBUnity.AdapterToTab(sqlStr);
//                if (dt.Rows.Count > 0)
//                {
//                    BG_MonPayPlanGenerate Bm = new BG_MonPayPlanGenerate();
//                    Bm.PIEcoSubCoding = dt.Rows[0]["PIEcoSubCoding"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubCoding"];
//                    Bm.PIEcoSublev = dt.Rows[0]["PIEcoSubCoding"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubCoding"];
//                    Bm.PIEcoSubParID = dt.Rows[0]["PIEcoSubParID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubParID"];
//                    Bm.PIEcoSubName = dt.Rows[0]["PIEcoSubName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubName"];
//                    Bm.PPID = dt.Rows[0]["PPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PPID"];
//                    Bm.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
//                    Bm.BAAID = dt.Rows[0]["BAAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BAAID"];
//                    Bm.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
//                    Bm.BAAMon = dt.Rows[0]["bAAMon"] == DBNull.Value ? 0.00 : (double)dt.Rows[0]["bAAMon"];
//                    Bm.BAAYear = dt.Rows[0]["BAAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BAAYear"];
//                    return Bm;
//                }
//                else
//                {
//                    return null;
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                throw e;
//            }
//        }
//        public static BG_MonPayPlanArmon GetMonPayPlanArmonByyeardepid(int year, int depid)
//        {
//            try
//            {
//                DataTable dt = new DataTable();
//                string sqlStr = "select ppid,sum(Armon) as armon from dbo.BG_ApplyReimbur where year(ARTime)={0} and  ARListSta='审核通过' and depid={1} group by ppid";
//                sqlStr = string.Format(sqlStr, depid, year);
//                dt = DBUnity.AdapterToTab(sqlStr);
//                if (dt.Rows.Count > 0)
//                {
//                    BG_MonPayPlanArmon Bm = new BG_MonPayPlanArmon();
//                    Bm.Armon = dt.Rows[0]["BAAYear"] == DBNull.Value ? 0.00 : (double)dt.Rows[0]["BAAYear"];
//                    Bm.Ppid = dt.Rows[0]["Ppid"] == DBNull.Value ? 0 : (int)dt.Rows[0]["Ppid"];
//                    return Bm;
//                }
//                else
//                {
//                    return null;
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                throw e;
//            }
//        }
//    }
//    public class BG_MonPayPlanArmon
//    {
//        private int ppid;
//        private double armon;

//        public int Ppid
//        {
//            get { return ppid; }
//            set { ppid = value; }
//        }

//        public double Armon
//        {
//            get { return armon; }
//            set { armon = value; }
//        }
//    }

//    public class BG_MonPayPlanGenerate
//    {

//        private string pIEcoSubCoding;
//        private int pIEcoSublev;
//        private int pIEcoSubParID;
//        private string pIEcoSubName;
//        private int pPID;
//        private int pIID;
//        private int bAAID;
//        private int depID;
//        private double bAAMon;
//        private int bAAYear;

//        public string PIEcoSubCoding
//        {
//            get { return pIEcoSubCoding; }
//            set { pIEcoSubCoding = value; }
//        }

//        public int PIEcoSublev
//        {
//            get { return pIEcoSublev; }
//            set { pIEcoSublev = value; }
//        }

//        public int PIEcoSubParID
//        {
//            get { return pIEcoSubParID; }
//            set { pIEcoSubParID = value; }
//        }

//        public string PIEcoSubName
//        {
//            get { return pIEcoSubName; }
//            set { pIEcoSubName = value; }
//        }

//        public int PPID
//        {
//            get { return pPID; }
//            set { pPID = value; }
//        }


//        public int PIID
//        {
//            get { return pIID; }
//            set { pIID = value; }
//        }


//        public int BAAID
//        {
//            get { return bAAID; }
//            set { bAAID = value; }
//        }


//        public int DepID
//        {
//            get { return depID; }
//            set { depID = value; }
//        }


//        public double BAAMon
//        {
//            get { return bAAMon; }
//            set { bAAMon = value; }
//        }


//        public int BAAYear
//        {
//            get { return bAAYear; }
//            set { bAAYear = value; }
//        }

//        public BG_MonPayPlanGenerate() { }

//    }
//}

#endregion