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
   public class BG_BudItemsLogic
    {
       public static DataTable GetBudItem(int year)
       {
           string sqlStr = "select BIProType,sum(BIMon) as Mon  from dbo.BG_BudItems where year(BIStaTime)={0} and BudSta='审核通过' group by BIProType";
           sqlStr = string.Format(sqlStr, year);
           DataTable dt = DBUnity.AdapterToTab(sqlStr);
           return dt;
       }



       public static DataTable GetPayOne(int year)
       {
           string sqlStr = "select POTitol FROM dbo.BG_ProBasiPerPayOne WHERE year(POYear)={0}";
           sqlStr = string.Format(sqlStr, year);
           DataTable dt = DBUnity.AdapterToTab(sqlStr);
           return dt;
       }


       public static DataTable GetPayTwo(int year)
       {
           string sqlStr = "select PTTitol FROM dbo.BG_ProBasiPerPayTwo  WHERE year(PTYear)={0}";
           sqlStr = string.Format(sqlStr, year);
           DataTable dt = DBUnity.AdapterToTab(sqlStr);
           return dt;
       }

       public static DataTable GetPubPay(int year)
       {
           string sqlStr = "select PBIDTitol FROM  dbo.BG_ProBasiPubPay WHERE year(PBYear)={0}";
           sqlStr = string.Format(sqlStr, year);
           DataTable dt = DBUnity.AdapterToTab(sqlStr);
           return dt;
       }

       public static DataTable GetProPay(int year)
       {
           string sqlStr = "select sum(ProPA0M) as ProPA0M  FROM dbo.BG_ProPay WHERE year(ProPYear)={0} Group by ProPYear";
           sqlStr = string.Format(sqlStr, year);
           DataTable dt = DBUnity.AdapterToTab(sqlStr);
           return dt;
       }

       public static DataTable GetAllProPay(int year)
       {
           string sqlStr = "select * FROM dbo.BG_ProPay WHERE year(ProPYear)={0}";
           sqlStr = string.Format(sqlStr, year);
           DataTable dt = DBUnity.AdapterToTab(sqlStr);
           return dt;
       }

       public static DataTable GetBAA(int depid ,int year)
       {
           string sqlStr = "select PIID, DepID,sum(BAAMon) as BAAMon , sum(SuppMon) as SuppMon FROM dbo.BG_BudgetAllocation WHERE DepID = {0} and BAAYear={1}  group by DepID,PIID";
           sqlStr = string.Format(sqlStr, depid, year);
           DataTable dt = DBUnity.AdapterToTab(sqlStr);
           return dt;
       }

       public static DataTable GetBEA(int depid, int year)
       {
           string sqlStr = "select PIID, DepID,sum(BEAMon) as BEAMon FROM dbo.BG_EstimatesAllocation WHERE DepID = {0} and BEAYear={1}  group by DepID,PIID";
           sqlStr = string.Format(sqlStr, depid, year);
           DataTable dt = DBUnity.AdapterToTab(sqlStr);
           return dt;
       }

       public static DataTable GetBudgetAllocation(int year)
       {
           string sqlStr = "select BAAMon FROM dbo.BG_BudgetAllocation WHERE BAAYear={0}";
           sqlStr = string.Format(sqlStr, year);
           DataTable dt = DBUnity.AdapterToTab(sqlStr);
           return dt;
       }


       //public static BG_PayIncome GetBG_PayIncomeByname(string name)
       //{
       //    string sql = "SELECT * FROM BG_PayIncome WHERE PIEcoSubName = @PIEcoSubName";

       //    try
       //    {
       //        SqlParameter para = new SqlParameter("@PIEcoSubName", name);
       //        DataTable dt = DBUnity.AdapterToTab(sql, para);

       //        if (dt.Rows.Count > 0)
       //        {
       //            BG_PayIncome bG_PayIncome = new BG_PayIncome();

       //            bG_PayIncome.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
       //            bG_PayIncome.PIEcoSubCoding = dt.Rows[0]["PIEcoSubCoding"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubCoding"];
       //            bG_PayIncome.PIEcoSubLev = dt.Rows[0]["PIEcoSubLev"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubLev"];
       //            bG_PayIncome.PIEcoSubParID = dt.Rows[0]["PIEcoSubParID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIEcoSubParID"];
       //            bG_PayIncome.PIEcoSubName = dt.Rows[0]["PIEcoSubName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PIEcoSubName"];

       //            return bG_PayIncome;
       //        }
       //        else
       //        {
       //            return null;
       //        }
       //    }
       //    catch (Exception e)
       //    {
       //        Console.WriteLine(e.Message);
       //        throw e;
       //    }
       //}

       public static string  GetBG_PayIncomeByname(string name)
       {
           string sql = "SELECT PIID FROM BG_PayIncome WHERE PIEcoSubName = '{0}'";
           string sqlStr = string.Format(sql, name);
           DataTable dt = DBUnity.AdapterToTab(sqlStr);
           string slist = "";
           if (dt.Rows.Count > 0)
           {
               for (int i = 0; i < dt.Rows.Count ; i++)
               {
                   string ss = dt.Rows[i][0].ToString() + ",";
                   slist += ss;
               } 
           }
           slist.TrimEnd(',');
           return slist;
       }

       public static decimal GetTotal(int year)
       {
           string sql = string.Format("select PBIDTitol  from [dbo].[BG_ProBasiPubPay] where Year(PBYear)={0}",year);
           decimal t= ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text,sql,null));
           return t;
       }

       public static bool GetAllMonByDepID(int DepID,string year)
       {
           string sql = string.Format("select  Sum(BAAMon)+Sum(SuppMon)  from [dbo].[BG_BudgetAllocation]  where DepID={0} and BAAYear='{1}'", DepID,year);
           decimal t=ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
           if (t > 0)
           {
               return true;
           }
           else { return false; }
       }
    }
}
