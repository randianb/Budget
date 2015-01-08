using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using System.Data;

namespace BudgetWeb.BLL
{
    public class BGFixAssetPurchaseManager
    {
    

        /// <summary>
        /// 添加固定资产采购情况
        /// </summary>
        /// <param name="bfp"></param>
        /// <returns>bool</returns>
        public static bool AddFix(BG_FixAssetPurchase bfp)
        {
            return BGFixAssetPurchaseService.AddFix(bfp); 
        }

        /// <summary>
        /// 查询固定资产情况
        /// </summary>
        /// <param name="budid"></param>
        /// <returns>DataTable</returns>
        public static DataTable GetFixByFaid(int faid)
        {
            return BGFixAssetPurchaseService.GetFixByFaid(faid);
        }

        /// <summary>
        /// 查询固定资产的FAName,FAModel,FABrand,FAPrice,FANum,FATime
        /// </summary>
        /// <param name="budid"></param>
        /// <returns>DataTable</returns>
        public static DataTable GetFix(int budid)
        {
            return BGFixAssetPurchaseService.GetFix(budid);
        }

         /// <summary>
        /// 修改一条固定资产
        /// </summary>
        /// <param name="fa"></param>
        /// <returns>bool</returns>
        public static bool UpdFix(BG_FixAssetPurchase fa)
        {
            return BGFixAssetPurchaseService.UpdFix(fa);
        }

        /// <summary>
        /// 删除一条固定资产情况
        /// </summary>
        /// <param name="faid"></param>
        /// <returns>bool</returns>
        public static bool DelFix(int faid)
        {
            return BGFixAssetPurchaseService.DelFix(faid);
        }

        /// <summary>
        /// 根据Faid查询到一条BGFixAssetPurchase记录
        /// </summary>
        /// <param name="faid">FAID</param>
        /// <returns>BGFixAssetPurchase</returns>
        public static BG_FixAssetPurchase GetFAPByFaid(int faid)
        {
            return BGFixAssetPurchaseService.GetFAPByFaid(faid);
        }
    }

}
