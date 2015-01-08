using FinaAnaly.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinaAnaly.BLL
{
    public static partial class FA_PUCIssNumManager
    {
        public static DataTable GetPUCIssNumByYearName(string name, int year)
        {
            return FA_PUCIssNumService.GetPUCIssNumByYearName(name, year);
        }
    }
}
