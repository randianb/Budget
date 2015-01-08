using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial  class FA_OutlayDepCKManager
    {
        public static DataTable GetOutlayDepCKByTimedepid(DateTime time, int depid)
        {
            return FA_OutlayDepCKService.GetOutlayDepCKByTimedepid(time, depid);
        }

        public static FA_OutlayDepCK GetOutlayDepCKByTime(DateTime time, int piid)
        {
            return FA_OutlayDepCKService.GetOutlayDepCKByTime(time, piid);
        }
    }
}
