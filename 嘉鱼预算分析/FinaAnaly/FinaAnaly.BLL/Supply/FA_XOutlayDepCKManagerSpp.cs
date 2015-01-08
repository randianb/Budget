using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial class FA_XOutlayDepCKManager
    {
        public static FA_XOutlayDepCK GetXOutlayDepCKByTime(DateTime time, int piid)
        {
            return FA_XOutlayDepCKService.GetXOutlayDepCKByTime(time, piid);
        }

        public static DataTable GetXOutlayDepCKByTimeRange(DateTime time1, DateTime time2, int piid)
        {
            return FA_XOutlayDepCKService.GetXOutlayDepCKByTimeRange(time1, time2, piid);
        }

        public static DataTable GetXOutlayDepCKByTimeRangepiiddepid(DateTime time1, DateTime time2, int piid, int depid)
        {
            return FA_XOutlayDepCKService.GetXOutlayDepCKByTimeRangepiiddepid(time1, time2, piid,depid);
        }

        public static DataTable GetXOutlayDepCKByTimedepid(DateTime time, int depid)
        {
            return FA_XOutlayDepCKService.GetXOutlayDepCKByTimedepid(time, depid);
        }

        public static FA_XOutlayDepCK GetXOutlayDepCKByTimepiiddepid(DateTime time, int piid, int depid)
        {
            return FA_XOutlayDepCKService.GetXOutlayDepCKByTimepiiddepid(time,piid, depid);
        }
    }
}
