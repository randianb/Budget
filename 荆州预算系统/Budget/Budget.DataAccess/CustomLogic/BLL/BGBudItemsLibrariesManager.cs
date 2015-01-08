using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;

namespace BudgetWeb.BLL
{
    public class BGBudItemsLibrariesManager
    {
        /// <summary>
        /// 根据部门查询
        /// </summary>
        /// <param name="depid"></param>
        /// <returns></returns>
        public static DataTable GetBGBudItemsLibraries(int depid)
        {
            return BGBudItemsLibrariesService.GetBGBudItemsLibraries(depid);
        }

        public static DataTable GetExamineBG_BudItemsLibrariesByDept(int depid)
        {
            return BGBudItemsLibrariesService.GetExamineBG_BudItemsLibrariesByDept(depid);
        }
        public static DataTable GetExamineBG_BudItemsLibrariesByDept(int depid,int year)
        {
            return BGBudItemsLibrariesService.GetExamineBG_BudItemsLibrariesByDept(depid,year);
        }

        public static DataTable GetBGBudItemsLibrariesBybudID(int budid)
        {
            return BGBudItemsLibrariesService.GetBGBudItemsLibrariesbudID(budid);
        }

        /// <summary>
        /// 根据项目查询
        /// </summary>
        /// <param name="depid"></param>
        /// <returns></returns>
        public static DataTable GetBGBudItemsLibrariesProject(int pPID)
        {
            return BGBudItemsLibrariesService.GetBGBudItemsLibrariesProject(pPID);
        }

        /// <summary>
        /// 根据项目名称查询
        /// </summary>
        /// <param name="depid"></param>
        /// <returns></returns>
        public static DataTable GetBGBudItemsLibrariesProjectName(string bILProName)
        {
            return BGBudItemsLibrariesService.GetBGBudItemsLibrariesProjectName(bILProName);

        }

        /// <summary>
        /// 根据经济科目查询
        /// </summary>
        /// <param name="depid"></param>
        /// <returns></returns>
        public static DataTable GetBGBudItemsLibrariesPayIncome(int pIID)
        {
            return BGBudItemsLibrariesService.GetBGBudItemsLibrariesPayIncome(pIID);
        }

        public static DataTable GetAllBG_BudItemsLibrariesDept()
        {
            return BGBudItemsLibrariesService.GetAllBG_BudItemsLibrariesDept();
        }
    }
}
