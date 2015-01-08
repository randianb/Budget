using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BudgetWeb.Model;
using BudgetWeb.DAL;

namespace BudgetWeb.BLL
{
    public class BG_EcoIncomeLogic
    {

        /// <summary>
        /// 获取全部收入经济科目
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetEcoIncomeDt()
        {
            DataTable dt = null;
            try
            {
                string sqlStr = "select * from BG_EcoIncome";
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        //public static List<EINameModel> GetEIList()
        //{
        //    List<EINameModel> list = new List<EINameModel>();
        //    DataTable dt = GetEcoIncomeDt();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            if (dt.Rows[i]["EIID"] != null && dt.Rows[i]["EIName"] != null)
        //            {
        //                EINameModel em = new EINameModel();
        //                em.EIID = dt.Rows[i]["EIID"].ToString();
        //                em.EIName = dt.Rows[i]["EIName"].ToString();
        //                list.Add(em);
        //            }
        //        }
        //    }
        //    return list;
        //}
    }
}
