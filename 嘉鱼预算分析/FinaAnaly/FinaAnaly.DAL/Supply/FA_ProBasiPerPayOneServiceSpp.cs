using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;

namespace FinaAnaly.DAL
{
    public static partial class FA_ProBasiPerPayOneService
    {
        public static bool IsProBasiPerPayOneByYear(int year)
        {
            bool flag = false;
            try
            {
                string sqlStr = "select count(*) from FA_ProBasiPerPayOne where year(POYear)={0}";
                sqlStr = string.Format(sqlStr, year);
                int t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr));
                if (t > 0)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_ProBasiPerPayOneService--IsProBasiPerPayOneByYear");
            }
            return flag;

        }
    }
}
