//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_ReimDocumentsService
	{
        public static BG_ReimDocuments AddBG_ReimDocuments(BG_ReimDocuments bG_ReimDocuments)
		{
            string sql =
				"INSERT BG_ReimDocuments (ARID, RDType, RDCont, RDTime)" +
				"VALUES (@ARID, @RDType, @RDCont, @RDTime)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ARID", bG_ReimDocuments.ARID),
					new SqlParameter("@RDType", bG_ReimDocuments.RDType),
					new SqlParameter("@RDCont", bG_ReimDocuments.RDCont),
					new SqlParameter("@RDTime", bG_ReimDocuments.RDTime)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_ReimDocumentsByRDID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_ReimDocuments(BG_ReimDocuments bG_ReimDocuments)
		{
			return DeleteBG_ReimDocumentsByRDID( bG_ReimDocuments.RDID );
		}

        public static bool DeleteBG_ReimDocumentsByRDID(int rDID)
		{
            string sql = "DELETE BG_ReimDocuments WHERE RDID = @RDID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@RDID", rDID)
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
					


        public static bool ModifyBG_ReimDocuments(BG_ReimDocuments bG_ReimDocuments)
        {
            string sql =
                "UPDATE BG_ReimDocuments " +
                "SET " +
	                "ARID = @ARID, " +
	                "RDType = @RDType, " +
	                "RDCont = @RDCont, " +
	                "RDTime = @RDTime " +
                "WHERE RDID = @RDID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@RDID", bG_ReimDocuments.RDID),
					new SqlParameter("@ARID", bG_ReimDocuments.ARID),
					new SqlParameter("@RDType", bG_ReimDocuments.RDType),
					new SqlParameter("@RDCont", bG_ReimDocuments.RDCont),
					new SqlParameter("@RDTime", bG_ReimDocuments.RDTime)
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


        public static DataTable GetAllBG_ReimDocuments()
        {
            string sqlAll = "SELECT * FROM BG_ReimDocuments";
			return GetBG_ReimDocumentsBySql( sqlAll );
        }
		

        public static BG_ReimDocuments GetBG_ReimDocumentsByRDID(int rDID)
        {
            string sql = "SELECT * FROM BG_ReimDocuments WHERE RDID = @RDID";

            try
            {
                SqlParameter para = new SqlParameter("@RDID", rDID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_ReimDocuments bG_ReimDocuments = new BG_ReimDocuments();

                    bG_ReimDocuments.RDID = dt.Rows[0]["RDID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["RDID"];
                    bG_ReimDocuments.ARID = dt.Rows[0]["ARID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["ARID"];
                    bG_ReimDocuments.RDType = dt.Rows[0]["RDType"] == DBNull.Value ? "" : (string)dt.Rows[0]["RDType"];
                    bG_ReimDocuments.RDCont = dt.Rows[0]["RDCont"] == DBNull.Value ? "" : (string)dt.Rows[0]["RDCont"];
                    bG_ReimDocuments.RDTime = dt.Rows[0]["RDTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["RDTime"];
                    
                    return bG_ReimDocuments;
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
	

      

        private static DataTable GetBG_ReimDocumentsBySql(string safeSql)
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
		
        private static DataTable GetBG_ReimDocumentsBySql(string sql, params SqlParameter[] values)
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
