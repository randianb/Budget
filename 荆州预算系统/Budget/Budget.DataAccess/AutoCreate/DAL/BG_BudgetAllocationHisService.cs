//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:43
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_BudgetAllocationHisService
	{
        public static BG_BudgetAllocationHis AddBG_BudgetAllocationHis(BG_BudgetAllocationHis bG_BudgetAllocationHis)
		{
            string sql =
				"INSERT BG_BudgetAllocationHis (BAAID, DepID, PIID, AddBAAMon, AddSuppMon, UserOp, Crtime, OldBAAMon, OldSuppMon, NewBAAMon, NewSuppMon, DepName)" +
				"VALUES (@BAAID, @DepID, @PIID, @AddBAAMon, @AddSuppMon, @UserOp, @Crtime, @OldBAAMon, @OldSuppMon, @NewBAAMon, @NewSuppMon, @DepName)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BAAID", bG_BudgetAllocationHis.BAAID),
					new SqlParameter("@DepID", bG_BudgetAllocationHis.DepID),
					new SqlParameter("@PIID", bG_BudgetAllocationHis.PIID),
					new SqlParameter("@AddBAAMon", bG_BudgetAllocationHis.AddBAAMon),
					new SqlParameter("@AddSuppMon", bG_BudgetAllocationHis.AddSuppMon),
					new SqlParameter("@UserOp", bG_BudgetAllocationHis.UserOp),
					new SqlParameter("@Crtime", bG_BudgetAllocationHis.Crtime),
					new SqlParameter("@OldBAAMon", bG_BudgetAllocationHis.OldBAAMon),
					new SqlParameter("@OldSuppMon", bG_BudgetAllocationHis.OldSuppMon),
					new SqlParameter("@NewBAAMon", bG_BudgetAllocationHis.NewBAAMon),
					new SqlParameter("@NewSuppMon", bG_BudgetAllocationHis.NewSuppMon),
					new SqlParameter("@DepName", bG_BudgetAllocationHis.DepName)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_BudgetAllocationHisByBAAHisID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_BudgetAllocationHis(BG_BudgetAllocationHis bG_BudgetAllocationHis)
		{
			return DeleteBG_BudgetAllocationHisByBAAHisID( bG_BudgetAllocationHis.BAAHisID );
		}

        public static bool DeleteBG_BudgetAllocationHisByBAAHisID(int bAAHisID)
		{
            string sql = "DELETE BG_BudgetAllocationHis WHERE BAAHisID = @BAAHisID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BAAHisID", bAAHisID)
				};
			
                int t = DBUnity.ExecuteNonQuery(CommandType.Text, sql, para);
                
                if(t>0)
                {
                    return true;
                }
                else
                {
                    return false;    
                }
            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
				throw e;
            }
		}
					


        public static bool ModifyBG_BudgetAllocationHis(BG_BudgetAllocationHis bG_BudgetAllocationHis)
        {
            string sql =
                "UPDATE BG_BudgetAllocationHis " +
                "SET " +
	                "BAAID = @BAAID, " +
	                "DepID = @DepID, " +
	                "PIID = @PIID, " +
	                "AddBAAMon = @AddBAAMon, " +
	                "AddSuppMon = @AddSuppMon, " +
	                "UserOp = @UserOp, " +
	                "Crtime = @Crtime, " +
	                "OldBAAMon = @OldBAAMon, " +
	                "OldSuppMon = @OldSuppMon, " +
	                "NewBAAMon = @NewBAAMon, " +
	                "NewSuppMon = @NewSuppMon, " +
	                "DepName = @DepName " +
                "WHERE BAAHisID = @BAAHisID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BAAHisID", bG_BudgetAllocationHis.BAAHisID),
					new SqlParameter("@BAAID", bG_BudgetAllocationHis.BAAID),
					new SqlParameter("@DepID", bG_BudgetAllocationHis.DepID),
					new SqlParameter("@PIID", bG_BudgetAllocationHis.PIID),
					new SqlParameter("@AddBAAMon", bG_BudgetAllocationHis.AddBAAMon),
					new SqlParameter("@AddSuppMon", bG_BudgetAllocationHis.AddSuppMon),
					new SqlParameter("@UserOp", bG_BudgetAllocationHis.UserOp),
					new SqlParameter("@Crtime", bG_BudgetAllocationHis.Crtime),
					new SqlParameter("@OldBAAMon", bG_BudgetAllocationHis.OldBAAMon),
					new SqlParameter("@OldSuppMon", bG_BudgetAllocationHis.OldSuppMon),
					new SqlParameter("@NewBAAMon", bG_BudgetAllocationHis.NewBAAMon),
					new SqlParameter("@NewSuppMon", bG_BudgetAllocationHis.NewSuppMon),
					new SqlParameter("@DepName", bG_BudgetAllocationHis.DepName)
				};

                int t = DBUnity.ExecuteNonQuery(CommandType.Text, sql, para);
                if(t>0)
                {
                    return true;
                }
                else
                {
                    return false;    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
				throw e;
            }

        }		


        public static DataTable GetAllBG_BudgetAllocationHis()
        {
            string sqlAll = "SELECT * FROM BG_BudgetAllocationHis";
			return GetBG_BudgetAllocationHisBySql( sqlAll );
        }
		

        public static BG_BudgetAllocationHis GetBG_BudgetAllocationHisByBAAHisID(int bAAHisID)
        {
            string sql = "SELECT * FROM BG_BudgetAllocationHis WHERE BAAHisID = @BAAHisID";

            try
            {
                SqlParameter para = new SqlParameter("@BAAHisID", bAAHisID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_BudgetAllocationHis bG_BudgetAllocationHis = new BG_BudgetAllocationHis();

                    bG_BudgetAllocationHis.BAAHisID = dt.Rows[0]["BAAHisID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BAAHisID"];
                    bG_BudgetAllocationHis.BAAID = dt.Rows[0]["BAAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BAAID"];
                    bG_BudgetAllocationHis.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_BudgetAllocationHis.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_BudgetAllocationHis.AddBAAMon = dt.Rows[0]["AddBAAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["AddBAAMon"];
                    bG_BudgetAllocationHis.AddSuppMon = dt.Rows[0]["AddSuppMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["AddSuppMon"];
                    bG_BudgetAllocationHis.UserOp = dt.Rows[0]["UserOp"] == DBNull.Value ? "" : (string)dt.Rows[0]["UserOp"];
                    bG_BudgetAllocationHis.Crtime = dt.Rows[0]["Crtime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["Crtime"];
                    bG_BudgetAllocationHis.OldBAAMon = dt.Rows[0]["OldBAAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OldBAAMon"];
                    bG_BudgetAllocationHis.OldSuppMon = dt.Rows[0]["OldSuppMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OldSuppMon"];
                    bG_BudgetAllocationHis.NewBAAMon = dt.Rows[0]["NewBAAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["NewBAAMon"];
                    bG_BudgetAllocationHis.NewSuppMon = dt.Rows[0]["NewSuppMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["NewSuppMon"];
                    bG_BudgetAllocationHis.DepName = dt.Rows[0]["DepName"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepName"];
                    
                    return bG_BudgetAllocationHis;
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
	

      

        private static DataTable GetBG_BudgetAllocationHisBySql(string safeSql)
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
		
        private static DataTable GetBG_BudgetAllocationHisBySql(string sql, params SqlParameter[] values)
        {

			try
			{
				DataTable dt = DBUnity.AdapterToTab(sql, values);
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
