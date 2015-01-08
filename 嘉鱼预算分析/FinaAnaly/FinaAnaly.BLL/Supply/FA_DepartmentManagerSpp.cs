using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial class FA_DepartmentManager
    {
        /// <summary>
        /// 获取部门分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns>DataTable</returns>
        public static DataTable GetDepartPager(int pageSize, int pageIndex, out int RecordCount)
        {
            return FA_DepartmentService.GetDepartPager(pageSize, pageIndex, out RecordCount);
        }

        public static FA_Department GetXPayIncomeByDepName(string depname)
        {
            return FA_DepartmentService.GetXPayIncomeByDepName(depname);
        }
    }
}
