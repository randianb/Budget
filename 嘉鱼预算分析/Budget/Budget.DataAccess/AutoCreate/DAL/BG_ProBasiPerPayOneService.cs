//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:02
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_ProBasiPerPayOneService
	{
        public static BG_ProBasiPerPayOne AddBG_ProBasiPerPayOne(BG_ProBasiPerPayOne bG_ProBasiPerPayOne)
		{
            string sql =
				"INSERT BG_ProBasiPerPayOne (DepID, POYear, POBS, POAS, POBonus, POPS, POSE, POOther, POTitol)" +
				"VALUES (@DepID, @POYear, @POBS, @POAS, @POBonus, @POPS, @POSE, @POOther, @POTitol)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_ProBasiPerPayOne.DepID),
					new SqlParameter("@POYear", bG_ProBasiPerPayOne.POYear),
					new SqlParameter("@POBS", bG_ProBasiPerPayOne.POBS),
					new SqlParameter("@POAS", bG_ProBasiPerPayOne.POAS),
					new SqlParameter("@POBonus", bG_ProBasiPerPayOne.POBonus),
					new SqlParameter("@POPS", bG_ProBasiPerPayOne.POPS),
					new SqlParameter("@POSE", bG_ProBasiPerPayOne.POSE),
					new SqlParameter("@POOther", bG_ProBasiPerPayOne.POOther),
					new SqlParameter("@POTitol", bG_ProBasiPerPayOne.POTitol)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_ProBasiPerPayOneByPOID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_ProBasiPerPayOne(BG_ProBasiPerPayOne bG_ProBasiPerPayOne)
		{
			return DeleteBG_ProBasiPerPayOneByPOID( bG_ProBasiPerPayOne.POID );
		}

        public static bool DeleteBG_ProBasiPerPayOneByPOID(int pOID)
		{
            string sql = "DELETE BG_ProBasiPerPayOne WHERE POID = @POID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@POID", pOID)
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
					


        public static bool ModifyBG_ProBasiPerPayOne(BG_ProBasiPerPayOne bG_ProBasiPerPayOne)
        {
            string sql =
                "UPDATE BG_ProBasiPerPayOne " +
                "SET " +
	                "DepID = @DepID, " +
	                "POYear = @POYear, " +
	                "POBS = @POBS, " +
	                "POAS = @POAS, " +
	                "POBonus = @POBonus, " +
	                "POPS = @POPS, " +
	                "POSE = @POSE, " +
	                "POOther = @POOther, " +
	                "POTitol = @POTitol " +
                "WHERE POID = @POID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@POID", bG_ProBasiPerPayOne.POID),
					new SqlParameter("@DepID", bG_ProBasiPerPayOne.DepID),
					new SqlParameter("@POYear", bG_ProBasiPerPayOne.POYear),
					new SqlParameter("@POBS", bG_ProBasiPerPayOne.POBS),
					new SqlParameter("@POAS", bG_ProBasiPerPayOne.POAS),
					new SqlParameter("@POBonus", bG_ProBasiPerPayOne.POBonus),
					new SqlParameter("@POPS", bG_ProBasiPerPayOne.POPS),
					new SqlParameter("@POSE", bG_ProBasiPerPayOne.POSE),
					new SqlParameter("@POOther", bG_ProBasiPerPayOne.POOther),
					new SqlParameter("@POTitol", bG_ProBasiPerPayOne.POTitol)
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


        public static DataTable GetAllBG_ProBasiPerPayOne()
        {
            string sqlAll = "SELECT * FROM BG_ProBasiPerPayOne";
			return GetBG_ProBasiPerPayOneBySql( sqlAll );
        }
		

        public static BG_ProBasiPerPayOne GetBG_ProBasiPerPayOneByPOID(int pOID)
        {
            string sql = "SELECT * FROM BG_ProBasiPerPayOne WHERE POID = @POID";

            try
            {
                SqlParameter para = new SqlParameter("@POID", pOID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_ProBasiPerPayOne bG_ProBasiPerPayOne = new BG_ProBasiPerPayOne();

                    bG_ProBasiPerPayOne.POID = dt.Rows[0]["POID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["POID"];
                    bG_ProBasiPerPayOne.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_ProBasiPerPayOne.POYear = dt.Rows[0]["POYear"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["POYear"];
                    bG_ProBasiPerPayOne.POBS = dt.Rows[0]["POBS"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["POBS"];
                    bG_ProBasiPerPayOne.POAS = dt.Rows[0]["POAS"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["POAS"];
                    bG_ProBasiPerPayOne.POBonus = dt.Rows[0]["POBonus"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["POBonus"];
                    bG_ProBasiPerPayOne.POPS = dt.Rows[0]["POPS"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["POPS"];
                    bG_ProBasiPerPayOne.POSE = dt.Rows[0]["POSE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["POSE"];
                    bG_ProBasiPerPayOne.POOther = dt.Rows[0]["POOther"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["POOther"];
                    bG_ProBasiPerPayOne.POTitol = dt.Rows[0]["POTitol"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["POTitol"];
                    
                    return bG_ProBasiPerPayOne;
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
	

      

        private static DataTable GetBG_ProBasiPerPayOneBySql(string safeSql)
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
		
        private static DataTable GetBG_ProBasiPerPayOneBySql(string sql, params SqlParameter[] values)
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
