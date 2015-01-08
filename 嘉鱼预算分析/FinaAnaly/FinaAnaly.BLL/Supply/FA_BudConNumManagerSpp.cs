using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial  class FA_BudConNumManager
    {
        /// <summary>
        /// 根据年度查询到一条记录
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>FA_SysSetting</returns>
        public static FA_BudConNum GetBudConNumByYear(int bcnyear)
        {
            return FA_BudConNumService.GetBudConNumByYear(bcnyear);
        }

         /// <summary>
        /// 根据年度获取对应记录数
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>int</returns>
        public static int GetBudConNumCountByYear(int bcnyear)
        {
            return FA_BudConNumService.GetBudConNumCountByYear(bcnyear);
        }
    }
}
