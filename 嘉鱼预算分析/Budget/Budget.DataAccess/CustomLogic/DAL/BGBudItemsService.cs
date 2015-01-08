//============================================================
// Coded by: PF  At: 2013/10/31 10:30
//============================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using Common;
using System.Configuration;


namespace BudgetWeb.DAL
{
    public class BGBudItemsService
    {

        /// <summary>
        /// 获取项目自增编号
        /// </summary>
        /// <returns></returns>
        public static string GetBICode(string year)
        {
            string ac = ConfigurationManager.AppSettings["AreaCode"].ToString();
            //string year = DateTime.Now.Year.ToString();
            //string codeTwo = ac + year;
            int bicode =common.IntSafeConvert(year+"0001");
            try
            {
                string sqlStr = "select max(BudID) from BG_BudItems";
                string budidStr = DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null);
                int budid = common.IntSafeConvert(budidStr);
                if (budid > 0)
                {
                    BG_BudItems bi = GetBudItemsByBudid(budid);
                    bicode = common.IntSafeConvert(bi.BICode.Replace(ac, string.Empty)) + 1;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "BGBudItemsService--GetBICode");
            }
            ac += bicode.ToString();
            return ac;
        }

        #region 按项目类型汇总(分页)
        /// <summary>
        /// 按项目类型汇总
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetSummaryBudInfoPager(string sta, int pageIndex, int pageSize, out int RecordCount, int CurrentYear)
        {
            DataTable dt = new DataTable();
            RecordCount = 0;
            try
            {
                string sqlStr = string.Format("select *, year(BIStaTime) as StaYear  from BG_BudItems where  BudSta='{0}'and year(BIStaTime)={1} order by  biprotype,BudID desc", sta, CurrentYear);
                string sqlRecord = string.Format("select count(*)  from BG_BudItems where  BudSta='{0}'", sta);
                RecordCount = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlRecord, null));
                dt = DBUnity.GetAspNetPager(sqlStr, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudItemsService--GetSummaryBudInfo");
            }
            return dt;
        }
        #endregion



        #region 添加一条预算项目信息
        /// <summary>
        /// 添加一条预算项目信息
        /// </summary>
        /// <param name="budItems">一条预算项目实例</param>
        /// <returns>bool</returns>
        public static bool AddbudItems(BG_BudItems budItems)
        {
            bool flag = false;
            try
            {
                string sqlStr = @"insert into BG_BudItems(BIProType,BIFunSub,BICode,PPID,PIID,BIPlanHz,BIStaTime,BIEndTime,BICharger,BIAttr,BIAppReaCon,
                                 BIExpGistExp,BILongGoal,BIYearGoal,BIMon,BIAppConMon,BIMonSou,BIFinAllo,BILastYearCarry,BIOthFun,BIOthExpProb,BIBudSta,BudSta,BICause,DepID,BIProName,BIReportTime,BIConNum,BIProDescrip,BIProCategory) 
                                values(@BIProType,@BIFunSub,@BICode,@PPID,@PIID,@BIPlanHz,@BIStaTime,@BIEndTime,@BICharger,@BIAttr,@BIAppReaCon,@BIExpGistExp,@BILongGoal,
                                 @BIYearGoal,@BIMon,@BIAppConMon,@BIMonSou,@BIFinAllo,@BILastYearCarry,@BIOthFun,@BIOthExpProb,@BIBudSta,@BudSta,@BICause,@DepID,@BIProName,@BIReportTime,@BIConNum,@BIProDescrip,@BIProCategory)";

                SqlParameter[] Pars = new SqlParameter[]{
                        new SqlParameter("@BIProType",budItems.BIProType),
                        new SqlParameter("@BIFunSub",budItems.BIFunSub),
                        new SqlParameter("@BICode",budItems.BICode),
                        new SqlParameter("@PPID",budItems.PPID),
                        new SqlParameter("@PIID",budItems.PIID),
                        new SqlParameter("@BIPlanHz",budItems.BIPlanHz),
                        new SqlParameter("@BIStaTime",budItems.BIStaTime),
                        new SqlParameter("@BIEndTime",budItems.BIEndTime),
                        new SqlParameter("@BICharger",budItems.BICharger),
                        new SqlParameter("@BIAttr",budItems .BIAttr ),
                        new SqlParameter("@BIAppReaCon",budItems.BIAppReaCon),
                        new SqlParameter("@BIExpGistExp",budItems.BIExpGistExp),
                        new SqlParameter("@BILongGoal",budItems.BILongGoal),
                        new SqlParameter("@BIYearGoal",budItems.BIYearGoal),
                        new SqlParameter("@BIMon",budItems.BIMon),
                        new SqlParameter("@BIAppConMon",budItems.BIAppConMon),
                        new SqlParameter("@BIMonSou",budItems .BIMonSou ),
                        new SqlParameter("@BIFinAllo",budItems .BIFinAllo ),
                        new SqlParameter("@BILastYearCarry",budItems.BILastYearCarry),
                        new SqlParameter("@BIOthFun",budItems.BIOthFun),
                        new SqlParameter("@BIOthExpProb",budItems.BIOthExpProb),
                        new SqlParameter("@BIBudSta",budItems.BIBudSta),
                        new SqlParameter("@BudSta",budItems.BudSta),
                        new SqlParameter("@BICause",budItems.BICause),
                        new SqlParameter("@DepID",budItems.DepID),
                        new SqlParameter("@BIProName",budItems.BIProName),
                        new SqlParameter("@BIReportTime",budItems.BIReportTime),
                        new SqlParameter("@BIConNum",budItems.BIConNum),
                        new SqlParameter("@BIProDescrip",budItems.BIProDescrip),
                        new SqlParameter("@BIProCategory",budItems.BIProCategory)
                        };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGBudItemsService--AddbudItems");
            }
            return flag;
        }

        /// <summary>
        /// 根据Budid获取单条BGBudItems记录
        /// </summary>
        /// <param name="biid"></param>
        /// <returns></returns>
        public static BG_BudItems GetBudItemsByBudid(int Budid)
        {
            BG_BudItems budItems = new BG_BudItems();
            string sqlStr = "select * from BG_BudItems where BudID=@BudID";
            SqlParameter[] Pars = new SqlParameter[]{
                   new SqlParameter("@BudID",Budid)};
            try
            {
                SqlDataReader dr = DBUnity.ExecuteReader(CommandType.Text, sqlStr, Pars);
                while (dr.Read())
                {
                    budItems.BudID = common.IntSafeConvert(dr["BudID"]);
                    budItems.BIProType = dr["BIProType"].ToString();
                    budItems.BIFunSub = dr["BIFunSub"].ToString();
                    budItems.BICode = dr["BICode"].ToString();
                    budItems.PPID = common.IntSafeConvert(dr["PPID"]);
                    budItems.PIID = common.IntSafeConvert(dr["PIID"]);
                    budItems.BIPlanHz = dr["BIPlanHz"].ToString();
                    budItems.BIStaTime = ParseUtil.ToDateTime(dr["BIStaTime"].ToString(), DateTime.Now);
                    budItems.BIEndTime = ParseUtil.ToDateTime(dr["BIEndTime"].ToString(), DateTime.Now);
                    budItems.BICharger = dr["BICharger"].ToString();
                    budItems.BIAttr = dr["BIAttr"].ToString();
                    budItems.BIAppReaCon = dr["BIAppReaCon"].ToString();
                    budItems.BIExpGistExp = dr["BIExpGistExp"].ToString();
                    budItems.BILongGoal = dr["BILongGoal"].ToString();
                    budItems.BIYearGoal = dr["BIYearGoal"].ToString();
                    budItems.BIMon = ParseUtil.ToDecimal(dr["BIMon"].ToString(),0);
                    budItems.BIAppConMon = ParseUtil.ToDecimal(dr["BIAppConMon"].ToString(),0);
                    budItems.BIMonSou = dr["BIMonSou"].ToString();
                    budItems.BIFinAllo = ParseUtil.ToDecimal(dr["BIFinAllo"].ToString(),0);
                    budItems.BILastYearCarry = ParseUtil.ToDecimal(dr["BILastYearCarry"].ToString(),0);
                    budItems.BIOthFun = ParseUtil.ToDecimal(dr["BIOthFun"].ToString(),0);
                    budItems.BIOthExpProb = dr["BIOthExpProb"].ToString();
                    budItems.BIBudSta = dr["BIBudSta"].ToString();
                    budItems.BudSta = dr["BudSta"].ToString();
                    budItems.BICause = dr["BICause"].ToString();
                    budItems.DepID =common.IntSafeConvert(dr["DepID"]);
                    budItems.BIProName = dr["BIProName"].ToString();
                    budItems.BIReportTime = ParseUtil.ToDateTime(dr["BIReportTime"].ToString(),DateTime.Now);
                    budItems.BIConNum = ParseUtil.ToDecimal(dr["BIConNum"].ToString(),0);
                    budItems.BIProDescrip = dr["BIProDescrip"].ToString();
                    budItems.BIProCategory = dr["BIProCategory"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                budItems = null;
                Log.WriteLog(ex.Message, "BGBudItemsService--GetBudItemsByBiid");
            }
            return budItems;
        }


        /// <summary>
        /// 添加BGBudItems并返回其ID
        /// </summary>
        /// <param name="budItems"></param>
        /// <returns>int</returns>
        public static int AddBudItemsBackbuid(BG_BudItems budItems)
        {
            int biid = 0;
            try
            {
                string sqlStr = @"insert into BG_BudItems(BIProType,BIFunSub,BICode,PPID,PIID,BIPlanHz,BIStaTime,BIEndTime,BICharger,BIAttr,BIAppReaCon,
                                 BIExpGistExp,BILongGoal,BIYearGoal,BIMon,BIAppConMon,BIMonSou,BIFinAllo,BILastYearCarry,BIOthFun,BIOthExpProb,BIBudSta,BudSta,BICause,DepID,BIProName,BIReportTime,BIConNum,BIProDescrip,BIProCategory) 
                                values(@BIProType,@BIFunSub,@BICode,@PPID,@PIID,@BIPlanHz,@BIStaTime,@BIEndTime,@BICharger,@BIAttr,@BIAppReaCon,@BIExpGistExp,@BILongGoal,
                                 @BIYearGoal,@BIMon,@BIAppConMon,@BIMonSou,@BIFinAllo,@BILastYearCarry,@BIOthFun,@BIOthExpProb,@BIBudSta,@BudSta,@BICause,@DepID,@BIProName,@BIReportTime,@BIConNum,@BIProDescrip,@BIProCategory);SELECT SCOPE_IDENTITY()";

                SqlParameter[] Pars = new SqlParameter[]{
                        new SqlParameter("@BIProType",budItems.BIProType),
                        new SqlParameter("@BIFunSub",budItems.BIFunSub),
                        new SqlParameter("@BICode",budItems.BICode),
                        new SqlParameter("@PPID",budItems.PPID),
                        new SqlParameter("@PIID",budItems.PIID),
                        new SqlParameter("@BIPlanHz",budItems.BIPlanHz),
                        new SqlParameter("@BIStaTime",budItems.BIStaTime),
                        new SqlParameter("@BIEndTime",budItems.BIEndTime),
                        new SqlParameter("@BICharger",budItems.BICharger),
                        new SqlParameter("@BIAttr",budItems .BIAttr ),
                        new SqlParameter("@BIAppReaCon",budItems.BIAppReaCon),
                        new SqlParameter("@BIExpGistExp",budItems.BIExpGistExp),
                        new SqlParameter("@BILongGoal",budItems.BILongGoal),
                        new SqlParameter("@BIYearGoal",budItems.BIYearGoal),
                        new SqlParameter("@BIMon",budItems.BIMon),
                        new SqlParameter("@BIAppConMon",budItems.BIAppConMon),
                        new SqlParameter("@BIMonSou",budItems .BIMonSou ),
                        new SqlParameter("@BIFinAllo",budItems .BIFinAllo ),
                        new SqlParameter("@BILastYearCarry",budItems.BILastYearCarry),
                        new SqlParameter("@BIOthFun",budItems.BIOthFun),
                        new SqlParameter("@BIOthExpProb",budItems.BIOthExpProb),
                        new SqlParameter("@BIBudSta",budItems.BIBudSta),
                        new SqlParameter("@BudSta",budItems.BudSta),
                        new SqlParameter("@BICause",budItems.BICause),
                        new SqlParameter("@DepID",budItems.DepID),
                        new SqlParameter("@BIProName",budItems.BIProName),
                        new SqlParameter("@BIReportTime",budItems.BIReportTime),
                        new SqlParameter("@BIConNum",budItems.BIConNum),
                        new SqlParameter("@BIProDescrip",budItems.BIProDescrip),
                         new SqlParameter("@BIProCategory",budItems.BIProCategory)
                        };
                biid = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, Pars));
            }
            catch (Exception ex)
            {
                biid = 0;
                Log.WriteLog(ex.Message, "BGBudItemsService--AddbudItems");
            }
            return biid;
        }

        #endregion

        #region  查询一条预算项目信息
        /// <summary>
        /// 通过预算项目ID查询信息
        /// </summary>
        /// <param name="budItems">项目ID</param>
        /// <returns>BGBudItems</returns>
        public static DataTable GetBudItemsListByBudid(int Budid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_BudItems where BudID={0}";
                sqlStr = string.Format(sqlStr, Budid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudItemsService--GetBudItemsListByBudid");
            }
            return dt;
        }
        #endregion

        #region 根据部门ID查询BudItemsList(未提交、退回)
        /// <summary>
        /// 根据部门ID查询BudItemsList(未提交、退回)
        /// </summary>
        /// <param name="Depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBudItemsListByDepid(int Depid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = string.Format("select *,year(BIStaTime) as BIYear from BG_BudItems where DepID={0} and BudSta in ('未提交','退回')", Depid);
                if (Depid == 0)
                {
                    sqlStr = "select *,year(BIStaTime) as BIYear from BG_BudItems where  BudSta in ('未提交','退回')";
                }
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudItemsService--GetBudItemsListByDepid");
            }
            return dt;
        }
        #endregion

        #region 根据部门ID查询BudItemsList(未提交、退回)分页
        /// <summary>
        /// 根据部门ID查询BudItemsList(未提交、退回)
        /// </summary>
        /// <param name="Depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBudItemsListByDepidPager(int Depid,int pageIndex,int PageSize,out int RecordCount)
        {
            DataTable dt = new DataTable();
            RecordCount = 0;
            try
            {
                string sqlStr = string.Format("select * from BG_BudItems where DepID={0} and BudSta in ('未提交','退回') order by BudID desc", Depid);
                string sqlRecord = string.Format("select count(*) from BG_BudItems where DepID={0} and BudSta in ('未提交','退回')", Depid);
                if (Depid == 0)
                {
                    sqlStr = "select * from BG_BudItems where  BudSta in ('未提交','退回')  order by BudID desc";
                    sqlRecord = "select count(*) from BG_BudItems where  BudSta in ('未提交','退回')";
                }
                RecordCount =common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlRecord, null));
                dt = DBUnity.GetAspNetPager(sqlStr, pageIndex, PageSize);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudItemsService--GetBudItemsListByDepid");
            }
            return dt;
        }
        #endregion

        

        #region  修改指定预算项目信息
        /// <summary>
        /// 修改指定预算项目信息
        /// </summary>
        /// <param name="budItems">BGBudItems</param>
        /// <returns>bool</returns>
        public static bool UpdBudItems(BG_BudItems budItems)
        {
            bool flag = false;
            try
            {
                string sqlStr = @"update BG_BudItems set BIProType=@BIProType,BIFunSub=@BIFunSub,
                BICode=@BICode,PPID=@PPID,PIID=@PIID,BIPlanHz=@BIPlanHz,BIStaTime=@BIStaTime,BIEndTime=@BIEndTime,
                BICharger=@BICharger,BIAttr=@BIAttr,BIAppReaCon=@BIAppReaCon,BIExpGistExp=@BIExpGistExp,BILongGoal=@BILongGoal,
                BIYearGoal=@BIYearGoal,BIMon=@BIMon,BIAppConMon=@BIAppConMon,BIMonSou=@BIMonSou,BIFinAllo=@BIFinAllo,
                BILastYearCarry=@BILastYearCarry,BIOthFun=@BIOthFun,BIOthExpProb=@BIOthExpProb,BIBudSta=@BIBudSta,
                BudSta=@BudSta,BICause=@BICause ,BIProName=@BIProName,BIReportTime=@BIReportTime,BIConNum=@BIConNum,BIProDescrip=@BIProDescrip,BIProCategory =@BIProCategory  where BudID = @BudID";
                SqlParameter[] Pars = new SqlParameter[]{
                       new SqlParameter("@BudID",budItems.BudID),
                        new SqlParameter("@BIProType",budItems.BIProType),
                        new SqlParameter("@BIFunSub",budItems.BIFunSub),
                        new SqlParameter("@BICode",budItems.BICode),
                        new SqlParameter("@PPID",budItems.PPID),
                        new SqlParameter("@PIID",budItems.PIID),
                        new SqlParameter("@BIPlanHz",budItems.BIPlanHz),
                        new SqlParameter("@BIStaTime",budItems.BIStaTime),
                        new SqlParameter("@BIEndTime",budItems.BIEndTime),
                        new SqlParameter("@BICharger",budItems.BICharger),
                        new SqlParameter("@BIAttr",budItems .BIAttr ),
                        new SqlParameter("@BIAppReaCon",budItems.BIAppReaCon),
                        new SqlParameter("@BIExpGistExp",budItems.BIExpGistExp),
                        new SqlParameter("@BILongGoal",budItems.BILongGoal),
                        new SqlParameter("@BIYearGoal",budItems.BIYearGoal),
                        new SqlParameter("@BIMon",budItems.BIMon),
                        new SqlParameter("@BIAppConMon",budItems.BIAppConMon),
                        new SqlParameter("@BIMonSou",budItems .BIMonSou ),
                        new SqlParameter("@BIFinAllo",budItems .BIFinAllo ),
                        new SqlParameter("@BILastYearCarry",budItems.BILastYearCarry),
                        new SqlParameter("@BIOthFun",budItems.BIOthFun),
                        new SqlParameter("@BIOthExpProb",budItems.BIOthExpProb),
                        new SqlParameter("@BIBudSta",budItems.BIBudSta),
                        new SqlParameter("@BudSta",budItems.BudSta),
                        new SqlParameter("@BICause",budItems.BICause),
                        new SqlParameter("@BIProName",budItems.BIProName),
                        new SqlParameter("@BIReportTime",budItems.BIReportTime),
                        new SqlParameter("@BIConNum",budItems.BIConNum),
                        new SqlParameter("@BIProDescrip",budItems.BIProDescrip),
                         new SqlParameter("@BIProCategory",budItems.BIProCategory)
                       };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "BGBudItemsService--UpdBudItems");
            }
            return flag;
        }
        #endregion

        #region 删除指定预算项目信息
        /// <summary>
        /// 删除指定预算项目信息
        /// </summary>
        /// <param name="budID">BudID</param>
        /// <returns>bool</returns>
        public static bool DelBud(int budID)
        {
            bool flag = false;
            try
            {
                string sqlStr = "delete from BG_BudItems where BudID=@BudID";
                SqlParameter[] pars = new SqlParameter[]{
                          new SqlParameter("@BudID",budID)    
                                };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, pars) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGBudItemsService--DelBud");
            }
            return flag;
        }
        #endregion

        #region 更改预算项目状态
        /// <summary>
        /// 更改预算项目状态
        /// </summary>
        /// <param name="budid">预算项目ID</param>
        /// <param name="status">预算项目状态</param>
        /// <returns>bool</returns>
        public static bool UpdBudSta(int budid, string budsta)
        {
            bool flag = false;
            try
            {
                string sqlStr = "update  BG_BudItems set BudSta =@BudSta where BudID = @BudID";
                SqlParameter[] Pars = new SqlParameter[]{
                        new SqlParameter("@BudID",budid),
                        new SqlParameter("@BudSta",budsta)
                       };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGBudItemsService--UpdBudSta");
            }
            return flag;
        }
        #endregion

        #region  填写审核不通过原因

        /// <summary>
        ///填写审核不通过原因
        /// </summary>
        /// <param name="budItems">BICause</param>
        /// <returns>BGBudItems</returns>
        public static bool SelBi(string bICause)
        {
            bool flag = false;
            try
            {
                string sqlStr = "select from BG_BudItems set BICause=@BICause  where BudID=@BudID";
                SqlParameter[] pars = new SqlParameter[]{                          
                          new SqlParameter("@BICause",bICause)    
                                };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, pars) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGBudItemsService--SelBi");
            }
            return flag;
        }
        #endregion

        #region 查询指定部门下所有预算(按状态查询的)信息
        /// <summary>
        /// 查询指定部门下所有预算(按状态查询的)信息
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburByDepID(int DepID, string sta)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = string.Format("select *,year(BIStaTime) as BIYear from BG_BudItems where DepID={0} and BudSta='{1}'", DepID, sta);
                if (DepID == 0)
                {
                    sqlStr = string.Format("select *,year(BIStaTime) as BIYear  from BG_BudItems where BudSta='{0}'", sta);
                }
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudItemsService--GetApplyReimburByDepID");
            }
            return dt;
        }
        #endregion

        #region 查询指定部门下所有预算(按状态查询的)信息分页
        /// <summary>
        /// 查询指定部门下所有预算(按状态查询的)信息
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburByDepIDPager(int DepID, string sta, int pageIndex, int PageSize, out int RecordCount, int CurrentYear)
        {
            DataTable dt = new DataTable();
            RecordCount = 0;
            try
            {
                string sqlStr = string.Format("select * from BG_BudItems where DepID={0} and BudSta='{1}' and year(BIStaTime)={2} order by BudID desc", DepID,sta,CurrentYear);
                string sqlRecord = string.Format("select count(*) from BG_BudItems where DepID={0} and BudSta='{1}'", DepID, sta);
                if (DepID == 0)
                {
                    sqlStr = string.Format("select * from BG_BudItems where BudSta='{0}' order by BudID desc", sta);
                    sqlRecord = string.Format("select count(*) from BG_BudItems where BudSta='{0}'", sta);
                }
                RecordCount = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlRecord, null));
                dt = DBUnity.GetAspNetPager(sqlStr, pageIndex, PageSize);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudItemsService--GetApplyReimburByDepID");
            }
            return dt;
        }
        #endregion

        


        public static DataTable GetBIPagerByProtypeYear(string protype, string year, int pageIndex, int PageSize, out int RecordCount)
        {
            DataTable dt = new DataTable();
            RecordCount = 0;
            try
            {
                string sqlStr = "SELECT BG_BudItems.*, BG_Department.DepName FROM BG_BudItems INNER JOIN BG_Department ON BG_BudItems.DepID = BG_Department.DepID";
                string filter = " WHERE  (BG_BudItems.BudSta = '审核通过') AND (BG_BudItems.BIProType = '{0}') AND (YEAR(BG_BudItems.BIStaTime) = {1})";
                string oderStr=" ORDER BY BG_BudItems.BudID DESC";
                filter = string.Format(filter, protype, year);
                sqlStr += filter;
                sqlStr += oderStr;
                string sqlRecord = "SELECT count(*) FROM BG_BudItems INNER JOIN BG_Department ON BG_BudItems.DepID = BG_Department.DepID";
                sqlRecord+=filter;
                RecordCount = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlRecord, null));
                dt = DBUnity.GetAspNetPager(sqlStr, pageIndex, PageSize);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudItemsService--GetBIPagerByProtypeYear");
            }
            return dt;
        }


        #region 按项目类型汇总
        /// <summary>
        /// 按项目类型汇总
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetSummaryBudInfo(string sta)
        {
            DataTable dt = new DataTable();
            try
            {
              
                string sqlStr = string.Format("select *  from BG_BudItems where  BudSta='{0}' order by  biprotype, BudID desc", sta);

                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudItemsService--GetSummaryBudInfo");
            }
            return dt;
        }
        #endregion

      

        #region 查询指定部门下所有预算信息分页
        /// <summary>
        /// 查询指定部门下所有预算信息
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburByDepIDPager(int DepID,  int pageIndex, int PageSize, out int RecordCount)
        {
            DataTable dt = new DataTable();
            RecordCount = 0;
            try
            {
                string sqlStr = string.Format("select * from BG_BudItems where DepID={0} order by BudID desc", DepID);
                string sqlRecord = string.Format("select count(*) from BG_BudItems where DepID={0} ", DepID);
                if (DepID == 0)
                {
                    sqlStr = string.Format("select * from BG_BudItems order by BudID desc");
                    sqlRecord = string.Format("select count(*) from BG_BudItems");
                }
                RecordCount = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlRecord, null));
                dt = DBUnity.GetAspNetPager(sqlStr, pageIndex, PageSize);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudItemsService--GetApplyReimburByDepID");
            }
            return dt;
        }
        #endregion

        #region 查询指定部门下所有预算信息
        /// <summary>
        /// 查询指定部门下所有预算信息
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburByDepID(int DepID)
        {
            DataTable dt = new DataTable();
           
            try
            {
                string sqlStr = string.Format("select * from BG_BudItems where DepID={0} order by BudID desc", DepID);
               
                if (DepID == 0)
                {
                    sqlStr = string.Format("select * from BG_BudItems order by BudID desc");
                  
                }

                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudItemsService--GetApplyReimburByDepID");
            }
            return dt;
        }
        #endregion

        public static int Isba(int year, int PIID, int depid)
        {
            string sqlStr = string.Format("select BAAID from  BG_BudgetAllocation where BAAYear={0} and PIID={1} and DepID={2}", year, PIID, depid);
            int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            return t;
        }
        public static int IsBEAba(int year, int PIID, int depid)
        {
            string sqlStr = string.Format("select BEAID from  BG_EstimatesAllocation where BEAYear={0} and PIID={1} and DepID={2}", year, PIID, depid);
            int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            return t;
        } 
    }
}