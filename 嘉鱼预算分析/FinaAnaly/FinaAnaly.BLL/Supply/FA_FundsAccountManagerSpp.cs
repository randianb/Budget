using FinaAnaly.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinaAnaly.BLL
{
    public static partial  class FA_FundsAccountManager
    {
        public static DataTable GetFundsAccountByName(string name)
        {
            return FA_FundsAccountService.GetFundsAccountByName(name);
        }
    }
}
