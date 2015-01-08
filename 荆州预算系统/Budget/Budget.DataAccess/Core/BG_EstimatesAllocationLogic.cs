using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using System.Data;
using System.Data.SqlClient;
using Common;
namespace BudgetWeb.BLL
{
    public class BG_EstimatesAllocationLogic
    {
        public static decimal GetEAMon(int depid, int piid, int year)
        {
            decimal del = 0;
            string str = string.Format(" select sum(BEAMon) as BEAMon  from dbo.BG_EstimatesAllocation where BEAYear={0} and DepID={1} and PIID={2} ", year, depid, piid);
            del = ParToDecimal.ParToDel(DBUnity.ExecuteScalar(CommandType.Text, str, null));

            return del;
        }

        public static DataTable GetALLEAMon(int year)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format(" select DepID,PIID,sum(BEAMon) as BEAMon  from dbo.BG_EstimatesAllocation where BEAYear={0}  group by DepID,PIID", year);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable GetEAMonDTbyDepID(int year, int depid)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format(" select PIID , sum(BEAMon) as BEAMon  from dbo.BG_EstimatesAllocation where BEAYear={0} and DepID={1} group by piid", year, depid);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable GetEAMonDTbyPIID(int year, int piid)
        {
            DataTable dt = null;
            try
            {
                string str = string.Format(" select DepID , sum(BEAMon) as BEAMon  from dbo.BG_EstimatesAllocation where BEAYear={0} and PIID={1} group by depid", year, piid);
                dt = DBUnity.AdapterToTab(str);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }
    }
}
