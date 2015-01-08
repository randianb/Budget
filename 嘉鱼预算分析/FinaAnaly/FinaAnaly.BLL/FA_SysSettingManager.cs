//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{

    public static partial class FA_SysSettingManager
    {
        public static FA_SysSetting AddFA_SysSetting(FA_SysSetting fA_SysSetting)
        {
            return FA_SysSettingService.AddFA_SysSetting(fA_SysSetting);
        }

        public static bool DeleteFA_SysSetting(FA_SysSetting fA_SysSetting)
        {
            return FA_SysSettingService.DeleteFA_SysSetting(fA_SysSetting);
        }

        public static bool DeleteFA_SysSettingByID(int sSID)
        {
            return FA_SysSettingService.DeleteFA_SysSettingBySSID(sSID);
        }

		public static bool ModifyFA_SysSetting(FA_SysSetting fA_SysSetting)
        {
            return FA_SysSettingService.ModifyFA_SysSetting(fA_SysSetting);
        }
        
        public static DataTable GetAllFA_SysSetting()
        {
            return FA_SysSettingService.GetAllFA_SysSetting();
        }

        public static FA_SysSetting GetFA_SysSettingBySSID(int sSID)
        {
            return FA_SysSettingService.GetFA_SysSettingBySSID(sSID);
        }

    }
}
