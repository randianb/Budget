//============================================================
// Coded by: WD  At: 2013/10/28 16:28
// Coded by: WD  At: 2013/12/30 18:28 增加AdapterToTab(string SqlStr, params SqlParameter[] commandParameters)
//============================================================
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace BudgetWeb.DAL
{ 
    /// <summary>
    /// DBUnity 的摘要说明
    /// </summary>
    public class DBUnity
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();//"Data Source=PC-ZGW;Initial Catalog=DeclareDB1;User ID=sa";

        #region SqlDataAdapter操作

        /// <summary>
        /// 默认连接community 获取数据表 1
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <returns>返回数据表</returns>
        public static DataTable AdapterToTab(string SqlStr)
        {
            return AdapterToTab(connectionString, SqlStr);
        }

        /// <summary>
        /// 获取数据表2
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <returns>返回数据表</returns>
        public static DataTable AdapterToTab(string connectionString, string SqlStr)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }

                SqlDataAdapter da = new SqlDataAdapter(SqlStr, conn);
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// 默认连接community 由Adapter填充DataTable指定起始
        /// 位置的和长度的数据并返回.3
        /// </summary>
        public static DataTable AdapterToTab(string SqlStr, int startRecord, int maxRecords)
        {
            return AdapterToTab(connectionString, SqlStr, startRecord, maxRecords);
        }

        /// <summary>
        /// 由Adapter填充DataTable指定起始位置的
        /// 和长度的数据并返回.4
        /// </summary>
        public static DataTable AdapterToTab(string connectionString, string SqlStr, int startRecord, int maxRecords)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(SqlStr, conn);
                da.Fill(ds, startRecord, maxRecords, "srcTable");
                dt = ds.Tables["srcTable"];
                conn.Close();
            }
            return dt;
        }


        /// <summary>
        /// 获取数据表5
        /// </summary>
        /// <param name="SqlStrparams"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataTable AdapterToTab(string SqlStr, params SqlParameter[] commandParameters)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }

                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, null, CommandType.Text, SqlStr, commandParameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Parameters.Clear();
                conn.Close();
            }
            return dt;
        }


        /// <summary>
        /// 默认连接community 由Adapter填充DataTable指定起
        /// 始位置的和长度的数据并返回.3
        /// </summary>
        public static DataTable AdapterToTabProc(string ProcName, int startRecord, int maxRecords,SqlParameter[] para)
        {
            return AdapterToTabProc(connectionString, ProcName, startRecord, maxRecords,para);
        }

        /// <summary>
        /// 由Adapter填充DataTable指定起始位置的和
        /// 长度的数据并返回.4
        /// </summary>
        public static DataTable AdapterToTabProc(string connectionString, string ProcName, int startRecord, int maxRecords,SqlParameter[] para)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(ProcName, conn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddRange(para);
                    da.Fill(ds, startRecord, maxRecords, "procTable");
                    dt = ds.Tables["procTable"];

                }
               
            }
            return dt;
        }



      

        #endregion

        #region SqlDataReader操作

        /// <summary>
        /// 打开默认数据库,通过执行Command返回结果
        /// 使用提供的参数
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandPararmeters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandPararmeters)
        {
            return ExecuteReader(connectionString, cmdType, cmdText, commandPararmeters);
        }

        /// <summary>
        /// 打开数据库连接字符串指定的数据库,通过执行Command返回结果集
        /// 使用提供的参数
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            //使用try-catch 因为使用了CommandBehavior关闭连接，如果此处抛出异常
            //则SqlDataReader不存在，CommandBehavior.CloseConnection将不能执行
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 预处理一个Command对象便于后面的操作
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            //System.Web.HttpContext.Current.Response.Write(conn.ConnectionString);

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #endregion

        #region 其他数据库操作

        /// <summary>
        /// 执行sql操作
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;            
            }
        }

        /// <summary>
        /// 打开默认数据库链接，执行sql操作
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(connectionString, cmdType, cmdText, commandParameters);
        }

        /// <summary>
        /// 打开一个已经存在的数据库连接，通过执行SqlCommand语句返回第一行第一列的值
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static string ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            //System.Web.HttpContext.Current.Response.Write(connectionString);
            //return "";
            SqlCommand cmd = new SqlCommand();
            object val = null;
            string s = string.Empty;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                val = cmd.ExecuteScalar();
                if (val != null)
                {
                    s = val.ToString();
                }
                cmd.Parameters.Clear();
                return s;
            }
            
        }

        /// <summary>
        /// 打开默认数据库连接，通过执行SqlCommand语句返回第一行第一列的值
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static string ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(connectionString, cmdType, cmdText, commandParameters);
        }

        #endregion

        #region 分页方法
        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public static DataTable GetAspNetPager(string sqlStr, int PageIndex, int PageSize)
        {
            int startRecord = PageIndex * PageSize;
            return DBUnity.AdapterToTab(sqlStr, startRecord, PageSize);
        }

        /// <summary>
        /// 分页方法(存储过程)
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public static DataTable GetAspNetPagerProc(string procName, int PageIndex, int PageSize, SqlParameter[] para)
        {
            int startRecord = PageIndex * PageSize;
            return DBUnity.AdapterToTabProc(procName, startRecord, PageSize, para);
        }
        #endregion

    }
}

