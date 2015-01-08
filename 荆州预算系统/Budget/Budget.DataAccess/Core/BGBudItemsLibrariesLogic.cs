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
     public  class BGBudItemsLibrariesLogic
    {
        public static DataTable GetBudItemsByPz(string StrPz)
        {
            DataTable dt = null;
            try
            {
                string sql = string.Format("SELECT * FROM BG_BudItemsLibraries WHERE BILPlanHz='{0}' ", StrPz);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }
    }
}
