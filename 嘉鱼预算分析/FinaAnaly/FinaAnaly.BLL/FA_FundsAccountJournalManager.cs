//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-22 10:36:36
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{

    public static partial class FA_FundsAccountJournalManager
    {
        public static FA_FundsAccountJournal AddFA_FundsAccountJournal(FA_FundsAccountJournal fA_FundsAccountJournal)
        {
            return FA_FundsAccountJournalService.AddFA_FundsAccountJournal(fA_FundsAccountJournal);
        }

        public static bool DeleteFA_FundsAccountJournal(FA_FundsAccountJournal fA_FundsAccountJournal)
        {
            return FA_FundsAccountJournalService.DeleteFA_FundsAccountJournal(fA_FundsAccountJournal);
        }

        public static bool DeleteFA_FundsAccountJournalByID(int fAUDID)
        {
            return FA_FundsAccountJournalService.DeleteFA_FundsAccountJournalByFAUDID(fAUDID);
        }

		public static bool ModifyFA_FundsAccountJournal(FA_FundsAccountJournal fA_FundsAccountJournal)
        {
            return FA_FundsAccountJournalService.ModifyFA_FundsAccountJournal(fA_FundsAccountJournal);
        }
        
        public static DataTable GetAllFA_FundsAccountJournal()
        {
            return FA_FundsAccountJournalService.GetAllFA_FundsAccountJournal();
        }

        public static FA_FundsAccountJournal GetFA_FundsAccountJournalByFAUDID(int fAUDID)
        {
            return FA_FundsAccountJournalService.GetFA_FundsAccountJournalByFAUDID(fAUDID);
        }

    }
}
