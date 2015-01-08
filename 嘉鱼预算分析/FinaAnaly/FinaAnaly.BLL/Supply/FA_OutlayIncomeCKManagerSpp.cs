using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FinaAnaly.DAL;
using FinaAnaly.Model;

namespace FinaAnaly.BLL
{
    public static partial  class FA_OutlayIncomeCKManager
    {
        public static FA_OutlayIncomeCK GetOutlayIncomeCKByTime(DateTime time, int piid)
        {
            return FA_OutlayIncomeCKService.GetOutlayIncomeCKByTime(time, piid);
        }

        public static DataTable GetOutlayIncomeCKByTimeRange(DateTime time1, DateTime time2, int piid)
        {
            return FA_OutlayIncomeCKService.GetOutlayIncomeCKByTimeRange(time1,time2, piid);
        }

        public static DataTable GetOutlayIncomeCKByTimeRangeType(string  time1, string  time2, string Str)
        {
            return FA_OutlayIncomeCKService.GetOutlayIncomeCKByTimeRangeType(time1, time2, Str);
        }

        public static DataTable GetOutlayIncomeCKByTimePIID(int year, string Str)
        {
            return FA_OutlayIncomeCKService.GetOutlayIncomeCKByTimePIID(year , Str);
        }
    }
}
