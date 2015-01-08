using FinaAnaly.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinaAnaly.BLL
{
    public static partial  class FA_FundsAccountUDetailManager
    {
        public static DataTable GetFundsAccountUDetailByName(string name)
        {
            return FA_FundsAccountUDetailService.GetFundsAccountUDetailByName(name);
        }
    }
}
