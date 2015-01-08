using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FinaAnaly.Model;
using FinaAnaly.DAL;

namespace FinaAnaly.BLL
{
    public static partial class FA_WarningQuotaManager
    {
         /// <summary>
        /// 根据年度查询到一条记录
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>FA_SysSetting</returns>
        public static FA_WarningQuota GetWarningQuotaByYear(int wqyear)
        {
            return FA_WarningQuotaService.GetWarningQuotaByYear(wqyear);
        }

        
        /// <summary>
        /// 根据年度获取对应记录数
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>int</returns>
        public static int GetWarningQuotaCountByYear(int wqyear)
        {
            return FA_WarningQuotaService.GetWarningQuotaCountByYear(wqyear);
        }
    }
}
