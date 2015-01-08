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

    public static partial class BG_ProBasiPerPayOneManager
    {
        public static BG_ProBasiPerPayOne AddBG_ProBasiPerPayOne(BG_ProBasiPerPayOne bG_ProBasiPerPayOne)
        {
            return BG_ProBasiPerPayOneService.AddBG_ProBasiPerPayOne(bG_ProBasiPerPayOne);
        }

        public static bool DeleteBG_ProBasiPerPayOne(BG_ProBasiPerPayOne bG_ProBasiPerPayOne)
        {
            return BG_ProBasiPerPayOneService.DeleteBG_ProBasiPerPayOne(bG_ProBasiPerPayOne);
        }

        public static bool DeleteBG_ProBasiPerPayOneByID(int pOID)
        {
            return BG_ProBasiPerPayOneService.DeleteBG_ProBasiPerPayOneByPOID(pOID);
        }

		public static bool ModifyBG_ProBasiPerPayOne(BG_ProBasiPerPayOne bG_ProBasiPerPayOne)
        {
            return BG_ProBasiPerPayOneService.ModifyBG_ProBasiPerPayOne(bG_ProBasiPerPayOne);
        }
        
        public static DataTable GetAllBG_ProBasiPerPayOne()
        {
            return BG_ProBasiPerPayOneService.GetAllBG_ProBasiPerPayOne();
        }

        public static BG_ProBasiPerPayOne GetBG_ProBasiPerPayOneByPOID(int pOID)
        {
            return BG_ProBasiPerPayOneService.GetBG_ProBasiPerPayOneByPOID(pOID);
        }

    }
}
