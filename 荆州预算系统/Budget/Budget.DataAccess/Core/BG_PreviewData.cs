using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BudgetWeb.DAL;

namespace BudgetWeb.BLL
{
    public class BG_PreviewDataLogic
    {

        /// <summary>
        /// 1.人员部分
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPersonPart()
        {
            DataTable dt = GetCommonDataTble("人员部分");
            return dt;
        }

        /// <summary>
        /// 2.公用部分
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPublicPart()
        {
            DataTable dt = GetCommonDataTble("公用部分");
            return dt;
        }


        /// <summary>
        /// 3.资本支出
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCapitalPart()
        {
            DataTable dt = GetCommonDataTble("资本支出");
            return dt;
        }



        #region 科目分类

        /// <summary>
        /// 1.办公费类
        /// </summary>
        /// <returns></returns>
        public static DataTable GetOfficePart()
        {
            DataTable dt = GetCommonTypeDataTable("办公费类");
            return dt;
        }

        /// <summary>
        /// 2.三公经费类
        /// </summary>
        /// <returns></returns>
        public static DataTable GetToPublishPart()
        {
            DataTable dt = GetCommonTypeDataTable("三公经费类");
            return dt;
        }

        /// <summary>
        /// 3.物业费类
        /// </summary>
        /// <returns></returns>
        public static DataTable GetHousePart()
        {
            DataTable dt = GetCommonTypeDataTable("物业费类");
            return dt;
        }

        /// <summary>
        /// 4.会议费类
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMeetingPart()
        {
            DataTable dt = GetCommonTypeDataTable("会议费类");
            return dt;
        }

        /// <summary>
        /// 5.培训费类
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTrainPart()
        {
            DataTable dt = GetCommonTypeDataTable("培训费类");
            return dt;
        }

        /// <summary>
        /// 6.福利费类
        /// </summary>
        /// <returns></returns>
        public static DataTable GetWelfarePart()
        {
            DataTable dt = GetCommonTypeDataTable("福利费类");
            return dt;
        }

        /// <summary>
        /// 7.其他类
        /// </summary>
        /// <returns></returns>
        public static DataTable GetOtherPart()
        {
            DataTable dt = GetCommonTypeDataTable("其它类");
            return dt;
        }

        #endregion

        #region 通用方法
        /// <summary>
        /// 获取各种类型预算经费的DataTable
        /// </summary>
        /// <param name="type1"></param>
        /// <param name="type2"></param>
        /// <returns></returns>
        public static DataTable GetCommonDataTble(string type1)
        {
            string sqlStr = "select * from BG_PreviewData where PSType1='{0}' Order by  PSID ASC";
            sqlStr = string.Format(sqlStr, type1);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        /// <summary>
        /// 获取科目分类的经费
        /// </summary>
        /// <param name="type1"></param>
        /// <returns></returns>
        public static DataTable GetCommonTypeDataTable(string type2)
        {
            string sqlStr = "select * from BG_PreviewData where PSType2='{0}' Order by PSID ASC";
            sqlStr = string.Format(sqlStr, type2);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }
        #endregion
    }
} 
