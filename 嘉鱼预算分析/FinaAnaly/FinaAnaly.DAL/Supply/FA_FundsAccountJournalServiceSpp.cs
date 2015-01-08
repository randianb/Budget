using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinaAnaly.DAL
{
    public static partial  class FA_FundsAccountJournalService
    {
        public static DataTable GetFundsAccountJournalByName(string name)
        {
            DataTable tmp = new DataTable();
            try
            {
                string sqlStr = "select * from FA_FundsAccountJournal where BM='{0}' order by BXRQ";
                sqlStr = string.Format(sqlStr, name);
                tmp = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_FundsAccountJournalService.GetFundsAccountJournalByName");
            }
            return tmp;
        }

        public static DataTable GetFundsAccountJournalByNameZFLX(string name,string zflx)
        {
            DataTable tmp = new DataTable();
            try
            {
                string sqlStr = "select * from FA_FundsAccountJournal where BM='{0}' and ZFLX='{1}' order by BXRQ";
                sqlStr = string.Format(sqlStr, name, zflx);
                tmp = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_FundsAccountJournalService.GetFundsAccountJournalByNameZFLX");
            }
            return tmp;
        }
    }
}
