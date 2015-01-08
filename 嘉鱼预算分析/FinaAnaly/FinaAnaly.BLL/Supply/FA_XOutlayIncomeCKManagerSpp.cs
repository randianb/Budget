using FinaAnaly.DAL;
using FinaAnaly.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinaAnaly.BLL
{
    public static partial class FA_XOutlayIncomeCKManager
    {
        public static FA_XOutlayIncomeCK GetXOutlayIncomeCKByTime(DateTime time, int piid)
        {
            return FA_XOutlayIncomeCKService.GetXOutlayIncomeCKByTime(time, piid);
        }

        public static DataTable GetXOutlayIncomeCKByTimeRange(DateTime time1, DateTime time2, int piid)
        {
            return FA_XOutlayIncomeCKService.GetXOutlayIncomeCKByTimeRange(time1, time2, piid);
        }

        public static DataTable GetXOutlayIncomeCKByTimePIEcoSubName(DateTime time1, DateTime time2, string PIEcoSubName)
        {
            return FA_XOutlayIncomeCKService.GetXOutlayIncomeCKByTimePIEcoSubName(time1, time2, PIEcoSubName);
        }

        public static DataTable GetXOutlayIncomeCKByTimeRangeType(string time1, string time2, string Str)
        {
            return FA_XOutlayIncomeCKService.GetXOutlayIncomeCKByTimeRangeType(time1, time2, Str);
        }

        public static DataTable GetXOutlayIncomeCKByTimePIID(int year, string Str)
        {
            return FA_XOutlayIncomeCKService.GetXOutlayIncomeCKByTimePIID(year, Str);
        }

        public static DataTable GetXOutlayIncomeCKByTimesPIID(int year, int lyear, string Str)
        {
            return FA_XOutlayIncomeCKService.GetXOutlayIncomeCKByTimesPIID(year, lyear, Str);
        }

        public static DataTable GetXOutlayIncomeCKByYearPIID(int year, int piid)
        {
            return FA_XOutlayIncomeCKService.GetXOutlayIncomeCKByYearPIID(year, piid);
        }
    }
}
