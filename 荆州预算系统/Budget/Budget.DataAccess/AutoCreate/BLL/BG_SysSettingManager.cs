//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:45
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{

    public static partial class BG_SysSettingManager
    {
        public static BG_SysSetting AddBG_SysSetting(BG_SysSetting bG_SysSetting)
        {
            return BG_SysSettingService.AddBG_SysSetting(bG_SysSetting);
        }

        public static bool DeleteBG_SysSetting(BG_SysSetting bG_SysSetting)
        {
            return BG_SysSettingService.DeleteBG_SysSetting(bG_SysSetting);
        }

        public static bool DeleteBG_SysSettingByID(int sSID)
        {
            return BG_SysSettingService.DeleteBG_SysSettingBySSID(sSID);
        }

		public static bool ModifyBG_SysSetting(BG_SysSetting bG_SysSetting)
        {
            return BG_SysSettingService.ModifyBG_SysSetting(bG_SysSetting);
        }
        
        public static DataTable GetAllBG_SysSetting()
        {
            return BG_SysSettingService.GetAllBG_SysSetting();
        }

        public static BG_SysSetting GetBG_SysSettingBySSID(int sSID)
        {
            return BG_SysSettingService.GetBG_SysSettingBySSID(sSID);
        }

    }
}
