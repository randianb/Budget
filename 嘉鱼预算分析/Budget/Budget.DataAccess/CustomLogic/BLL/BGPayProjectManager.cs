using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;


namespace BudgetWeb.BLL
{
    public class BGPayProjectManager
    {
        /// <summary>
        /// 获取全部支出项目表记录
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetAllPayProject()
        {
            return BGPayProjectService.GetAllPayProject();
        }
        /// <summary>
        /// 获取全部支出项目表记录
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetPayProjectByPPID(int ppid)
        {
            return BGPayProjectService.GetAllPayProjectPPID(ppid);
        }
    }
}
