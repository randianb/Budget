using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial class FA_SysSettingManager
    {
           /// <summary>
        /// 根据年度获取对应记录数
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>int</returns>
        public static int GetSysSettingCountByYear(int ssyear)
        {
            return FA_SysSettingService.GetSysSettingCountByYear(ssyear);
        }


           /// <summary>
        /// 根据年度查询到一条记录
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>FA_SysSetting</returns>
        public static FA_SysSetting GetSysSettingByYear(int ssyear)
        {
            return FA_SysSettingService.GetSysSettingByYear(ssyear);
        }
      
         /// <summary>
        /// 获取最后一条对应记录
        /// </summary>
        /// <returns>FA_SysSetting</returns>
        public static FA_SysSetting GetSysSettingByMaxYear()
        {
            return FA_SysSettingService.GetSysSettingByMaxYear();
        }
    }
}
