using FinaAnaly.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinaAnaly.BLL
{
    public static partial  class FA_FundsAccountJournalManager
    {
        public static DataTable GetFundsAccountJournalByName(string name)
        {
            return FA_FundsAccountJournalService.GetFundsAccountJournalByName(name);
        }

        public static DataTable GetFundsAccountJournalByNameZFLX(string name, string zflx)
        {
            return FA_FundsAccountJournalService.GetFundsAccountJournalByNameZFLX(name,zflx);
        }
    }
}
