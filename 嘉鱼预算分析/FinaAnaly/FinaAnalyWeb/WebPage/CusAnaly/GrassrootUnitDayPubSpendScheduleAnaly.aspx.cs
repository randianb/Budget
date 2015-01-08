using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using Common;
using FinaAnaly.DAL;
using FinaAnaly.Model;

public partial class WebPage_CusAnaly_GrassrootUnitDayPubSpendScheduleAnaly : System.Web.UI.Page
{
    int year = 0;
    int uselim = 0;
    int depid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["uselim"] != null && Request.QueryString["depid"] != null)
        {
            uselim = common.IntSafeConvert(Request.QueryString["uselim"]);
            depid = common.IntSafeConvert(Request.QueryString["depid"]);
        }
    }

    private void GetPIID()
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        DateTime time = Convert.ToDateTime(tbDate.Text);

        //办公费
        FA_PayIncome fa1 = FA_PayIncomeManager.GetPayIncomeByPIecosubname("办公费");
        int piid1 = 0;
        if (fa1 != null)
        {
            piid1 = fa1.PIID;
        }
        FA_OutlayIncomeCK oick1 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time, piid1);
        decimal dcl1 = 0;
        if (oick1 != null)
        {
            dcl1 = oick1.OICkAreaMon + oick1.OICkZeroMon;
        }

        //水电费
        FA_PayIncome fa2 = FA_PayIncomeManager.GetPayIncomeByPIecosubname("水费");
        int piid2 = 0;
        if (fa2 != null)
        {
            piid2 = fa2.PIID;
        }
        FA_OutlayIncomeCK oick2 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time, piid2);
        decimal dcl2 = 0;
        if (oick2 != null)
        {
            dcl2 = oick2.OICkAreaMon + oick2.OICkZeroMon;
        }
        FA_PayIncome fa3 = FA_PayIncomeManager.GetPayIncomeByPIecosubname("电费");
        int piid3 = 0;
        if (fa3 != null)
        {
            piid3 = fa3.PIID;
        }
        FA_OutlayIncomeCK oick3 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time, piid3);
        decimal dcl3 = 0;
        if (oick3 != null)
        {
            dcl3 = oick3.OICkAreaMon + oick3.OICkZeroMon;
        }
        decimal dcl23 = dcl2 + dcl3;

        //印刷费
        FA_PayIncome fa4 = FA_PayIncomeManager.GetPayIncomeByPIecosubname("印刷费");
        int piid4 = 0;
        if (fa4 != null)
        {
            piid4 = fa4.PIID;
        }
        FA_OutlayIncomeCK oick4 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time, piid4);
        decimal dcl4 = 0;
        if (oick4 != null)
        {
            dcl4 = oick4.OICkAreaMon + oick4.OICkZeroMon;
        }

        //邮电费
        FA_PayIncome fa5 = FA_PayIncomeManager.GetPayIncomeByPIecosubname("邮电费");
        int piid5 = 0;
        if (fa5 != null)
        {
            piid5 = fa5.PIID;
        }
        FA_OutlayIncomeCK oick5 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time, piid5);
        decimal dcl5 = 0;
        if (oick5 != null)
        {
            dcl5 = oick5.OICkAreaMon + oick5.OICkZeroMon;
        }

        //差旅费
        FA_PayIncome fa6 = FA_PayIncomeManager.GetPayIncomeByPIecosubname("差旅费");
        int piid6 = 0;
        if (fa6 != null)
        {
            piid6 = fa6.PIID;
        }
        FA_OutlayIncomeCK oick6 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time, piid6);
        decimal dcl6 = 0;
        if (oick6 != null)
        {
            dcl6 = oick6.OICkAreaMon + oick6.OICkZeroMon;
        }

        //公务用车运行维护费
        FA_PayIncome fa7 = FA_PayIncomeManager.GetPayIncomeByPIecosubname("公务用车运行维护费");
        int piid7 = 0;
        if (fa7 != null)
        {
            piid7 = fa7.PIID;
        }
        FA_OutlayIncomeCK oick7 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time, piid7);
        decimal dcl7 = 0;
        if (oick7 != null)
        {
            dcl7 = oick7.OICkAreaMon + oick7.OICkZeroMon;
        }

        //其他商品和服务支出
        FA_PayIncome fa8 = FA_PayIncomeManager.GetPayIncomeByPIecosubname("其他商品和服务支出");
        int piid8 = 0;
        if (fa8 != null)
        {
            piid8 = fa8.PIID;

        }
        FA_OutlayIncomeCK oick8 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time, piid8);
        decimal dcl8 = 0;
        if (oick8 != null)
        {
            dcl8 = oick8.OICkAreaMon + oick8.OICkZeroMon;
        }


        string idStrs = piid1 + "," + piid2 + "," + piid3 + "," + piid4 + "," + piid5 + "," + piid6 + "," + piid7 + "," + piid8;
        decimal dcl = FA_IncomeBudAllocatManager.GetIncomeBudAllocatByIBAIDYear(idStrs, year);

        int mon = Convert.ToDateTime(tbDate.Text).Month;
        decimal dcl11 = 0;
        decimal dcl12 = 0;
        decimal dcl13 = 0;
        decimal dcl123 = 0;
        decimal dcl14 = 0;
        decimal dcl15 = 0;
        decimal dcl16 = 0;
        decimal dcl17 = 0;
        decimal dcl18 = 0;
        for (int i = mon; i > 0; i--)
        {
            DateTime time1 = Convert.ToDateTime(year.ToString() + "-" + mon.ToString());
            FA_OutlayIncomeCK oick11 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time1, piid1);
            if (oick11 != null)
            {
                dcl11 = dcl11 + oick11.OICkZeroMon + oick11.OICkAreaMon;
            }
            FA_OutlayIncomeCK oick12 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time1, piid2);
            if (oick12 != null)
            {
                dcl12 = dcl12 + oick12.OICkZeroMon + oick12.OICkAreaMon;
            }
            FA_OutlayIncomeCK oick13 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time1, piid3);
            if (oick13 != null)
            {
                dcl13 = dcl13 + oick13.OICkZeroMon + oick13.OICkAreaMon;
            }
            dcl123 = dcl123 + dcl12 + dcl13;

            FA_OutlayIncomeCK oick14 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time1, piid4);
            if (oick14 != null)
            {
                dcl14 = dcl14 + oick14.OICkZeroMon + oick14.OICkAreaMon;
            }

            FA_OutlayIncomeCK oick15 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time1, piid5);
            if (oick15 != null)
            {
                dcl15 = dcl15 + oick15.OICkZeroMon + oick15.OICkAreaMon;
            }

            FA_OutlayIncomeCK oick16 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time1, piid6);
            if (oick16 != null)
            {
                dcl16 = dcl16 + oick16.OICkZeroMon + oick16.OICkAreaMon;
            }

            FA_OutlayIncomeCK oick17 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time1, piid7);
            if (oick17 != null)
            {
                dcl17 = dcl17 + oick17.OICkZeroMon + oick17.OICkAreaMon;
            }

            FA_OutlayIncomeCK oick18 = FA_OutlayIncomeCKManager.GetOutlayIncomeCKByTime(time1, piid8);
            if (oick18 != null)
            {
                dcl18 = dcl18 + oick18.OICkZeroMon + oick18.OICkAreaMon;
            }
        }

        decimal dcltatolThis = dcl1 + dcl23 + dcl4 + dcl5 + dcl6 + dcl7 + dcl8;
        decimal dcltatolAddup = dcl11 + dcl123 + dcl14 + dcl15 + dcl16 + dcl17 + dcl18;

        decimal dclBanlance = dcl * 10000 - dcltatolAddup;

        DataTable dt = new DataTable();
        dt.Columns.Add("TheOther");
        dt.Columns.Add("PlanNum");
        dt.Columns.Add("AdminExpThis");
        dt.Columns.Add("AdminExpTatol");
        dt.Columns.Add("PrintCostThis");
        dt.Columns.Add("PrintCostTatol");
        dt.Columns.Add("UtilitThis");
        dt.Columns.Add("UtilitTatol");
        dt.Columns.Add("PostFeesThis");
        dt.Columns.Add("PostFeesTatol");
        dt.Columns.Add("TravelThis");
        dt.Columns.Add("TravelTatol");
        dt.Columns.Add("VehicleFeeThis");
        dt.Columns.Add("VehicleFeeTatol");
        dt.Columns.Add("OtherThis");
        dt.Columns.Add("OtherTatol");
        dt.Columns.Add("SumThis");
        dt.Columns.Add("SumTatol");
        dt.Columns.Add("Balance");
        DataRow dr = dt.NewRow();
        dr["PlanNum"] = dcl.ToString();
        dr["AdminExpThis"] = dcl1;
        dr["AdminExpTatol"] = dcl11;
        dr["PrintCostThis"] = dcl4;
        dr["PrintCostTatol"] = dcl14;
        dr["UtilitThis"] = dcl23;
        dr["UtilitTatol"] = dcl123;
        dr["PostFeesThis"] = dcl5;
        dr["PostFeesTatol"] = dcl15;
        dr["TravelThis"] = dcl6;
        dr["TravelTatol"] = dcl16;
        dr["VehicleFeeThis"] = dcl7;
        dr["VehicleFeeTatol"] = dcl17;
        dr["OtherThis"] = dcl8;
        dr["OtherTatol"] = dcl18;
        dr["SumThis"] = dcltatolThis;
        dr["SumTatol"] = dcltatolAddup;
        dr["Balance"] = dclBanlance;
        dt.Rows.Add(dr);

        RepLeaderQuery.DataSource = dt;
        RepLeaderQuery.DataBind();
    }

    private Decimal ToDec(object obj)
    {
        Decimal decTmp = 0;
        if (obj != null)
        {
            string objStr = obj.ToString();
            if (!string.IsNullOrEmpty(objStr))
            {
                decTmp = ParseUtil.ToDecimal(objStr, decTmp);
            }
        }
        return decTmp;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        HidSearchFlag.Value = "0";
        MBindData();
        HidSearchFlag.Value = "1";
    }

    private void MBindData()
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        string sql = string.Empty;
        DataTable dt =new DataTable();
        DataTable dt1 = new DataTable();
        if (uselim == 1001)
        {
            sql = string.Format(" select * from dbo.FA_Department  where DepID={0}", depid);
            
            dt1 = DBUnity.AdapterToTab(sql);
        }
        else
        {
            sql = " select * from dbo.FA_Department ";//as a left join dbo.FA_DepBudAllocat as b on a.DepID=b.DepID  where b.DBAYear=  + year.ToString()
            dt1 = DBUnity.AdapterToTab(sql);
        }
        dt.Columns.Add("TheOther");
        dt.Columns.Add("PlanNum");
        dt.Columns.Add("AdminExpThis");
        dt.Columns.Add("AdminExpTatol");
        dt.Columns.Add("PrintCostThis");
        dt.Columns.Add("PrintCostTatol");
        dt.Columns.Add("UtilitThis");
        dt.Columns.Add("UtilitTatol");
        dt.Columns.Add("PostFeesThis");
        dt.Columns.Add("PostFeesTatol");
        dt.Columns.Add("TravelThis");
        dt.Columns.Add("TravelTatol");
        dt.Columns.Add("VehicleFeeThis");
        dt.Columns.Add("VehicleFeeTatol");
        dt.Columns.Add("TrainThis");
        dt.Columns.Add("TrainTatol");
        dt.Columns.Add("MeetingThis");
        dt.Columns.Add("MeetingTatol");
        dt.Columns.Add("OtherThis");
        dt.Columns.Add("OtherTatol");
        dt.Columns.Add("SumThis");
        dt.Columns.Add("SumTatol");
        dt.Columns.Add("Balance");
        GetRows(dt,dt1);
        
        RepLeaderQuery.DataSource = dt;
        RepLeaderQuery.DataBind();
    }

    private void GetRows(DataTable dt,DataTable dt1)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            DataRow dr = dt.NewRow();
            dr["TheOther"] = dt1.Rows[i]["DepName"].ToString();
            int depid = common.IntSafeConvert(dt1.Rows[i]["DepID"]);
            FA_DepBudAllocat fa = FA_DepBudAllocatManager.GetDepMonBydepiddbayear(depid, year);
            if (fa != null)
            {
                dr["PlanNum"] = fa.DBAMon;
            }

            if (ddlType.SelectedValue == "1")
            {
                if (LHThisBindData("办公费", depid) != 0)
                {
                    dr["AdminExpThis"] = LHThisBindData("办公费", depid);
                }
                if (LHTatolBindData("办公费", depid) != 0)
                {
                    dr["AdminExpTatol"] = LHTatolBindData("办公费", depid);
                }
                if (LHThisBindData("印刷费", depid) != 0)
                {
                    dr["PrintCostThis"] = LHThisBindData("印刷费", depid);
                }
                if (LHTatolBindData("印刷费", depid) != 0)
                {
                    dr["PrintCostTatol"] = LHTatolBindData("印刷费", depid);
                }
                if ((LHThisBindData("水费", depid) + LHThisBindData("电费", depid)) != 0)
                {
                    dr["UtilitThis"] = (LHThisBindData("水费", depid) + LHThisBindData("电费", depid));
                }
                if ((LHTatolBindData("水费", depid) + LHTatolBindData("电费", depid)) != 0)
                {
                    dr["UtilitTatol"] = (LHTatolBindData("水费", depid) + LHTatolBindData("电费", depid));
                }
                if (LHThisBindData("邮电费", depid) != 0)
                {
                    dr["PostFeesThis"] = LHThisBindData("邮电费", depid);
                }
                if (LHTatolBindData("邮电费", depid) != 0)
                {
                    dr["PostFeesTatol"] = LHTatolBindData("邮电费", depid);
                }
                if (LHThisBindData("差旅费", depid) != 0)
                {
                    dr["TravelThis"] = LHThisBindData("差旅费", depid);
                }
                if (LHTatolBindData("差旅费", depid) != 0)
                {
                    dr["TravelTatol"] = LHTatolBindData("差旅费", depid);
                }
                if (LHThisBindData("公务用车运行维护费", depid) != 0)
                {
                    dr["VehicleFeeThis"] = LHThisBindData("公务用车运行维护费", depid);
                }
                if (LHTatolBindData("公务用车运行维护费", depid) != 0)
                {
                    dr["VehicleFeeTatol"] = LHTatolBindData("公务用车运行维护费", depid);
                }
                if (LHThisBindData("培训费", depid) != 0)
                {
                    dr["TrainThis"] = LHThisBindData("培训费", depid);
                }
                if (LHTatolBindData("培训费", depid) != 0)
                {
                    dr["TrainTatol"] = LHTatolBindData("培训费", depid);
                }
                if (LHThisBindData("会议费", depid) != 0)
                {
                    dr["MeetingThis"] = LHThisBindData("会议费", depid);
                }
                if (LHTatolBindData("会议费", depid) != 0)
                {
                    dr["MeetingTatol"] = LHTatolBindData("会议费", depid);
                }
                decimal sumthis = thisBindData(depid, ddlType.SelectedValue) - (ToDec(dr["AdminExpThis"].ToString()) + ToDec(dr["PrintCostThis"].ToString()) + ToDec(dr["UtilitThis"].ToString()) + ToDec(dr["PostFeesThis"].ToString()) + ToDec(dr["TravelThis"].ToString()) + ToDec(dr["VehicleFeeThis"].ToString()));
                decimal SumTatol = TatolBindData(depid, ddlType.SelectedValue) - (ToDec(dr["AdminExpTatol"].ToString()) + ToDec(dr["PrintCostTatol"].ToString()) + ToDec(dr["UtilitTatol"].ToString()) + ToDec(dr["PostFeesTatol"].ToString()) + ToDec(dr["TravelTatol"].ToString()) + ToDec(dr["VehicleFeeTatol"].ToString()));
                if (sumthis != 0)
                {
                    dr["OtherThis"] = sumthis;
                }

                if (SumTatol != 0)
                {
                    dr["OtherTatol"] = SumTatol;
                }
                if (thisBindData(depid, ddlType.SelectedValue) != 0)
                {
                    dr["SumThis"] = thisBindData(depid, ddlType.SelectedValue);
                }
                if (TatolBindData(depid, ddlType.SelectedValue) != 0)
                {
                    dr["SumTatol"] = TatolBindData(depid, ddlType.SelectedValue);
                }
                decimal Balance = ToDec(dr["PlanNum"]) * 10000 - ToDec(dr["SumTatol"]);
                if (Balance != 0)
                {
                    dr["Balance"] = Balance;
                }
            }
            if (ddlType.SelectedValue == "0")
            {
                if (SYThisBindData("办公费", depid) != 0)
                {
                    dr["AdminExpThis"] = SYThisBindData("办公费", depid);
                }
                if (SYTatolBindData("办公费", depid) != 0)
                {
                    dr["AdminExpTatol"] = SYTatolBindData("办公费", depid);
                }
                if (SYThisBindData("印刷费", depid) != 0)
                {
                    dr["PrintCostThis"] = SYThisBindData("印刷费", depid);
                }
                if (SYTatolBindData("印刷费", depid) != 0)
                {
                    dr["PrintCostTatol"] = SYTatolBindData("印刷费", depid);
                }
                if ((SYThisBindData("水费", depid) + SYThisBindData("电费", depid)) != 0)
                {
                    dr["UtilitThis"] = (SYThisBindData("水费", depid) + SYThisBindData("电费", depid));
                }
                if ((SYTatolBindData("水费", depid) + SYTatolBindData("电费", depid)) != 0)
                {
                    dr["UtilitTatol"] = (SYTatolBindData("水费", depid) + SYTatolBindData("电费", depid));
                }
                if (SYThisBindData("邮电费", depid) != 0)
                {
                    dr["PostFeesThis"] = SYThisBindData("邮电费", depid);
                }
                if (SYTatolBindData("邮电费", depid) != 0)
                {
                    dr["PostFeesTatol"] = SYTatolBindData("邮电费", depid);
                }
                if (SYThisBindData("差旅费", depid) != 0)
                {
                    dr["TravelThis"] = SYThisBindData("差旅费", depid);
                }
                if (SYTatolBindData("差旅费", depid) != 0)
                {
                    dr["TravelTatol"] = SYTatolBindData("差旅费", depid);
                }
                if (SYThisBindData("公务用车运行维护费", depid) != 0)
                {
                    dr["VehicleFeeThis"] = SYThisBindData("公务用车运行维护费", depid);
                }
                if (SYTatolBindData("公务用车运行维护费", depid) != 0)
                {
                    dr["VehicleFeeTatol"] = SYTatolBindData("公务用车运行维护费", depid);
                }
                if (SYThisBindData("培训费", depid) != 0)
                {
                    dr["TrainThis"] = SYThisBindData("培训费", depid);
                }
                if (SYTatolBindData("培训费", depid) != 0)
                {
                    dr["TrainTatol"] = SYTatolBindData("培训费", depid);
                }
                if (SYThisBindData("会议费", depid) != 0)
                {
                    dr["MeetingThis"] = SYThisBindData("会议", depid);
                }
                if (SYTatolBindData("会议费", depid) != 0)
                {
                    dr["MeetingTatol"] = SYTatolBindData("会议费", depid);
                }
                decimal sumthis = thisBindData(depid, ddlType.SelectedValue) - (ToDec(dr["AdminExpThis"].ToString()) + ToDec(dr["PrintCostThis"].ToString()) + ToDec(dr["UtilitThis"].ToString()) + ToDec(dr["PostFeesThis"].ToString()) + ToDec(dr["TravelThis"].ToString()) + ToDec(dr["VehicleFeeThis"].ToString()));
                decimal SumTatol = TatolBindData(depid, ddlType.SelectedValue) - (ToDec(dr["AdminExpTatol"].ToString()) + ToDec(dr["PrintCostTatol"].ToString()) + ToDec(dr["UtilitTatol"].ToString()) + ToDec(dr["PostFeesTatol"].ToString()) + ToDec(dr["TravelTatol"].ToString()) + ToDec(dr["VehicleFeeTatol"].ToString()));
                if (sumthis != 0)
                {
                    dr["OtherThis"] = sumthis;
                }
                if (SumTatol != 0)
                {
                    dr["OtherTatol"] = SumTatol;
                }
                if (thisBindData(depid, ddlType.SelectedValue) != 0)
                {
                    dr["SumThis"] = thisBindData(depid, ddlType.SelectedValue);
                }
                if (TatolBindData(depid, ddlType.SelectedValue) != 0)
                {
                    dr["SumTatol"] = TatolBindData(depid, ddlType.SelectedValue);
                }
                decimal Balance = ToDec(dr["PlanNum"]) * 10000 - ToDec(dr["SumTatol"]);
                if (Balance != 0)
                {
                    dr["Balance"] = Balance;
                }
            }
            if (ddlType.SelectedValue == "2")
            {
                if (QJThisBindData("办公费", depid) != 0)
                {
                    dr["AdminExpThis"] = QJThisBindData("办公费", depid);
                }
                if (QJTatolBindData("办公费", depid) != 0)
                {
                    dr["AdminExpTatol"] = QJTatolBindData("办公费", depid);
                }
                if (QJThisBindData("印刷费", depid) != 0)
                {
                    dr["PrintCostThis"] = QJThisBindData("印刷费", depid);
                }
                if (QJTatolBindData("印刷费", depid) != 0)
                {
                    dr["PrintCostTatol"] = QJTatolBindData("印刷费", depid);
                }
                if ((QJThisBindData("水费", depid) + QJThisBindData("电费", depid)) != 0)
                {
                    dr["UtilitThis"] = (QJThisBindData("水费", depid) + QJThisBindData("电费", depid));
                }
                if ((QJTatolBindData("水费", depid) + QJTatolBindData("电费", depid)) != 0)
                {
                    dr["UtilitTatol"] = (QJTatolBindData("水费", depid) + QJTatolBindData("电费", depid));
                }
                if (QJThisBindData("邮电费", depid) != 0)
                {
                    dr["PostFeesThis"] = QJThisBindData("邮电费", depid);
                }
                if (QJTatolBindData("邮电费", depid) != 0)
                {
                    dr["PostFeesTatol"] = QJTatolBindData("邮电费", depid);
                }
                if (QJThisBindData("差旅费", depid) != 0)
                {
                    dr["TravelThis"] = QJThisBindData("差旅费", depid);
                }
                if (QJTatolBindData("差旅费", depid) != 0)
                {
                    dr["TravelTatol"] = QJTatolBindData("差旅费", depid);
                }
                if (QJThisBindData("公务用车运行维护费", depid) != 0)
                {
                    dr["VehicleFeeThis"] = QJThisBindData("公务用车运行维护费", depid);
                }
                if (QJTatolBindData("公务用车运行维护费", depid) != 0)
                {
                    dr["VehicleFeeTatol"] = QJTatolBindData("公务用车运行维护费", depid);
                }
                if (QJThisBindData("培训费", depid) != 0)
                {
                    dr["TrainThis"] = QJThisBindData("培训费", depid);
                }
                if (QJTatolBindData("培训费", depid) != 0)
                {
                    dr["TrainTatol"] = QJTatolBindData("培训费", depid);
                }
                if (QJThisBindData("会议费", depid) != 0)
                {
                    dr["MeetingThis"] = QJThisBindData("会议费", depid);
                }
                if (QJTatolBindData("会议费", depid) != 0)
                {
                    dr["MeetingTatol"] = QJTatolBindData("会议费", depid);
                }
                decimal sumthis = thisBindData(depid, ddlType.SelectedValue) - (ToDec(dr["AdminExpThis"].ToString()) + ToDec(dr["PrintCostThis"].ToString()) + ToDec(dr["UtilitThis"].ToString()) + ToDec(dr["PostFeesThis"].ToString()) + ToDec(dr["TravelThis"].ToString()) + ToDec(dr["VehicleFeeThis"].ToString()));
                decimal SumTatol = TatolBindData(depid, ddlType.SelectedValue) - (ToDec(dr["AdminExpTatol"].ToString()) + ToDec(dr["PrintCostTatol"].ToString()) + ToDec(dr["UtilitTatol"].ToString()) + ToDec(dr["PostFeesTatol"].ToString()) + ToDec(dr["TravelTatol"].ToString()) + ToDec(dr["VehicleFeeTatol"].ToString()));
                if (sumthis != 0)
                {
                    dr["OtherThis"] = sumthis;
                }
                if (SumTatol != 0)
                {
                    dr["OtherTatol"] = SumTatol;
                }
                if (thisBindData(depid, ddlType.SelectedValue) != 0)
                {
                    dr["SumThis"] = thisBindData(depid, ddlType.SelectedValue);
                }
                if (TatolBindData(depid, ddlType.SelectedValue) != 0)
                {
                    dr["SumTatol"] = TatolBindData(depid, ddlType.SelectedValue);
                }
                decimal Balance = ToDec(dr["PlanNum"]) * 10000 - ToDec(dr["SumTatol"]);
                if (Balance != 0)
                {
                    dr["Balance"] = Balance;
                }
            }
            dt.Rows.Add(dr);
        }
    }

    private decimal LHThisBindData(string str, int depid)
    {
        DataTable dt = null;
        decimal dcthis = 0;
        string time = tbDate.Text + "-" + "01";
        if (str == "公务用车运行维护费")
        {
            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from  FA_XOutlayDepCK  WHERE (PIID IN (SELECT   PIID   FROM   FA_XPayIncome   WHERE  (  PIEcoSubParID IN (SELECT   PIID  FROM  FA_XPayIncome WHERE   (PIEcoSubName = '{0}'))))) AND (ODCkTime = '{1}'  AND (DepID = {2}))", str, time, depid);
            dt = DBUnity.AdapterToTab(sqlStr1);
        }
        else
        {                        
            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from  FA_XOutlayDepCK  WHERE (PIID IN (SELECT   PIID  FROM  FA_XPayIncome WHERE   (PIEcoSubName = '{0}'))) AND (ODCkTime = '{1}'  AND (DepID = {2}))", str, time, depid);
            dt = DBUnity.AdapterToTab(sqlStr1);           
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dt.Rows[0]["ODCkZeroMon"].ToString()))
            {
                dcthis = ToDec(dt.Rows[0]["ODCkZeroMon"].ToString());
            }
        }
        return dcthis;
    }

    private decimal QJThisBindData(string str, int depid)
    {
        DataTable dt = null;
        decimal dcthis = 0;
        string time = tbDate.Text + "-" + "01";
        if (str == "公务用车运行维护费")
        {
            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from  FA_XOutlayDepCK  WHERE (PIID IN (SELECT   PIID   FROM   FA_XPayIncome   WHERE  (  PIEcoSubParID IN (SELECT   PIID  FROM  FA_XPayIncome WHERE   (PIEcoSubName = '{0}'))))) AND (ODCkTime = '{1}'  AND (DepID = {2}))", str, time, depid);
            dt = DBUnity.AdapterToTab(sqlStr1);
        }
        else
        {
            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from  FA_XOutlayDepCK  WHERE (PIID IN (SELECT   PIID  FROM  FA_XPayIncome  WHERE   (PIEcoSubName = '{0}'))) AND  ODCkTime = '{1}'  AND DepID = {2}", str, time, depid);
            dt = DBUnity.AdapterToTab(sqlStr1);
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dt.Rows[0]["ODCkAreaMon"].ToString()))
            {
                dcthis = ToDec(dt.Rows[0]["ODCkAreaMon"].ToString());
            }
        }
        return dcthis;
    }

    private decimal SYThisBindData(string str, int depid)
    {
        DataTable dt = null;
        decimal dcthis = 0;
        string time = tbDate.Text + "-" + "01";
        if (str == "公务用车运行维护费")
        {
            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from  FA_XOutlayDepCK  WHERE (PIID IN (SELECT   PIID   FROM   FA_XPayIncome   WHERE  (  PIEcoSubParID IN (SELECT   PIID  FROM  FA_XPayIncome WHERE   (PIEcoSubName = '{0}'))))) AND (ODCkTime = '{1}'  AND (DepID = {2}))", str, time, depid);
            dt = DBUnity.AdapterToTab(sqlStr1);
        }
        else
        {
            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from  FA_XOutlayDepCK  WHERE (PIID IN (SELECT   PIID  FROM  FA_XPayIncome WHERE   (PIEcoSubName = '{0}'))) AND (ODCkTime = '{1}'  AND (DepID = {2}))", str, time, depid);
            dt = DBUnity.AdapterToTab(sqlStr1);
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dt.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt.Rows[0]["ODCkAreaMon"].ToString()))
            {
                dcthis = ToDec(dt.Rows[0]["ODCkZeroMon"]) + ToDec(dt.Rows[0]["ODCkAreaMon"]);
            }
        }
        return dcthis;
    }

    private decimal LHTatolBindData(string str, int depid)
    {
         DataTable dt = null;
        decimal dctatol = 0;
        if (str == "公务用车运行维护费")
        {
            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from  FA_XOutlayDepCK  WHERE (PIID IN (SELECT   PIID   FROM   FA_XPayIncome   WHERE  (  PIEcoSubParID IN (SELECT   PIID  FROM  FA_XPayIncome WHERE   (PIEcoSubName = '{0}'))))) AND (Convert(varchar(7),ODCkTime,120) between '{1}' And '{2}'  AND (DepID = {3}))", str, Convert.ToDateTime(tbDate.Text).Year.ToString() + "-" + "01", tbDate.Text, depid);
            dt = DBUnity.AdapterToTab(sqlStr1);
        }
        else
        {
            string sqlStr = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from  FA_XOutlayDepCK  WHERE (PIID IN (SELECT   PIID  FROM  FA_XPayIncome WHERE   (PIEcoSubName = '{0}'))) AND (Convert(varchar(7),ODCkTime,120) between '{1}' And '{2}'  AND (DepID = {3}))", str, Convert.ToDateTime(tbDate.Text).Year.ToString() + "-" + "01", tbDate.Text, depid);
            dt = DBUnity.AdapterToTab(sqlStr);
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dt.Rows[0]["ODCkZeroMon"].ToString()))
            {
                dctatol = ToDec(dt.Rows[0]["ODCkZeroMon"].ToString());
            }
        }
        return dctatol;
    }

    private decimal QJTatolBindData(string str, int depid)
    {
        DataTable dt = null;
        decimal dctatol = 0;
        if (str == "公务用车运行维护费")
        {
            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from  FA_XOutlayDepCK  WHERE (PIID IN (SELECT   PIID   FROM   FA_XPayIncome   WHERE  (  PIEcoSubParID IN (SELECT   PIID  FROM  FA_XPayIncome WHERE   (PIEcoSubName = '{0}'))))) AND (Convert(varchar(7),ODCkTime,120) between '{1}' And '{2}'  AND (DepID = {3}))", str, Convert.ToDateTime(tbDate.Text).Year.ToString() + "-" + "01", tbDate.Text, depid);
            dt = DBUnity.AdapterToTab(sqlStr1);
        }
        else
        {
            string sqlStr = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from  FA_XOutlayDepCK  WHERE (PIID IN (SELECT   PIID  FROM  FA_XPayIncome WHERE   (PIEcoSubName = '{0}'))) AND (Convert(varchar(7),ODCkTime,120) between '{1}' And '{2}'  AND (DepID = {3}))", str, Convert.ToDateTime(tbDate.Text).Year.ToString() + "-" + "01", tbDate.Text, depid);
            dt = DBUnity.AdapterToTab(sqlStr);
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dt.Rows[0]["ODCkAreaMon"].ToString()))
            {
                dctatol = ToDec(dt.Rows[0]["ODCkAreaMon"].ToString());
            }
        }
        return dctatol;
    }

    private decimal SYTatolBindData(string str, int depid)
    {
        DataTable dt = null;
        decimal dctatol = 0;
        if (str == "公务用车运行维护费")
        {
            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from  FA_XOutlayDepCK  WHERE (PIID IN (SELECT   PIID   FROM   FA_XPayIncome   WHERE  (  PIEcoSubParID IN (SELECT   PIID  FROM  FA_XPayIncome WHERE   (PIEcoSubName = '{0}'))))) AND (Convert(varchar(7),ODCkTime,120) between '{1}' And '{2}'  AND (DepID = {3}))", str, Convert.ToDateTime(tbDate.Text).Year.ToString() + "-" + "01", tbDate.Text, depid);
            dt = DBUnity.AdapterToTab(sqlStr1);
        }
        else
        {
            string sqlStr = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from  FA_XOutlayDepCK WHERE  (PIID IN (SELECT   PIID  FROM  FA_XPayIncome WHERE   (PIEcoSubName = '{0}'))) AND (Convert(varchar(7),ODCkTime,120) between '{1}' And '{2}'  AND (DepID = {3}))", str, Convert.ToDateTime(tbDate.Text).Year.ToString() + "-" + "01", tbDate.Text, depid);
            dt = DBUnity.AdapterToTab(sqlStr);
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dt.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt.Rows[0]["ODCkAreaMon"].ToString()))
            {
                dctatol = ToDec(dt.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt.Rows[0]["ODCkAreaMon"].ToString());
            }
        }
        return dctatol;
    }

    private decimal thisBindData(int depid, string type)
    {
        decimal dec = 0;
        string time = tbDate.Text + "-" + "01";
        string sqlStr = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from  FA_XOutlayDepCK  WHERE  (ODCkTime = '{0}'  AND (DepID = {1}))", time, depid);
        DataTable dt = DBUnity.AdapterToTab(sqlStr);
        if (dt != null && dt.Rows.Count > 0)
        {
            if (type == "0")
            {
                dec = ToDec(dt.Rows[0]["ODCkZeroMon"]) + ToDec(dt.Rows[0]["ODCkAreaMon"]);
            }
            if (type == "1")
            {
                dec = ToDec(dt.Rows[0]["ODCkZeroMon"]);
            }
            if (type == "2")
            {
                dec = ToDec(dt.Rows[0]["ODCkAreaMon"]);
            }
        }
        return dec;
    }

    private decimal TatolBindData(int depid, string type)
    {
        decimal dctatol = 0;
        string sqlStr = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from  FA_XOutlayDepCK WHERE  (Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}'  AND (DepID = {2}))", Convert.ToDateTime(tbDate.Text).Year.ToString() + "-" + "01", tbDate.Text, depid);
        DataTable dt = DBUnity.AdapterToTab(sqlStr);
        if (dt != null && dt.Rows.Count > 0)
        {
            if (type == "0")
            {
                dctatol = ToDec(dt.Rows[0]["ODCkZeroMon"]) + ToDec(dt.Rows[0]["ODCkAreaMon"]);
            }
            if (type == "1")
            {
                dctatol = ToDec(dt.Rows[0]["ODCkZeroMon"]);
            }
            if (type == "2")
            {
                dctatol = ToDec(dt.Rows[0]["ODCkAreaMon"]);
            }
        }
        return dctatol;
    }

    private void BindData()
    {
        string sql = " select * from dbo.FA_Department as a left join dbo.FA_DepBudAllocat as b on a.DepID=b.DepID  where b.DBAYear= " + year.ToString();
        DataTable dt = DBUnity.AdapterToTab(sql);
        dt.Columns.Add("TheOther");
        dt.Columns.Add("PlanNum");
        dt.Columns.Add("AdminExpThis");
        dt.Columns.Add("AdminExpTatol");
        dt.Columns.Add("PrintCostThis");
        dt.Columns.Add("PrintCostTatol");
        dt.Columns.Add("UtilitThis");
        dt.Columns.Add("UtilitTatol");
        dt.Columns.Add("PostFeesThis");
        dt.Columns.Add("PostFeesTatol");
        dt.Columns.Add("TravelThis");
        dt.Columns.Add("TravelTatol");
        dt.Columns.Add("VehicleFeeThis");
        dt.Columns.Add("VehicleFeeTatol");
        dt.Columns.Add("OtherThis");
        dt.Columns.Add("OtherTatol");
        dt.Columns.Add("SumThis");
        dt.Columns.Add("SumTatol");
        dt.Columns.Add("Balance");
        string sql1 = string.Format("select * from dbo.FA_OutlayDepCK where PIID in (1010,1011,1014,1015,1016,1018,1031,1032,1033) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}'", year.ToString() + "-" + "01", tbDate.Text);
        DataTable dt1 = DBUnity.AdapterToTab(sql1);
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            dt.Rows[i]["TheOther"] = dt.Rows[i]["DepName"].ToString();
            dt.Rows[i]["PlanNum"] = dt.Rows[i]["DBAMon"].ToString();

            DataRow[] arr = dt1.Select("DepID=" + dt.Rows[i]["DepID"].ToString());
            if (arr.Length == 0)
            {
                dt.Rows[i]["AdminExpThis"] = "0.0";
                dt.Rows[i]["AdminExpTatol"] = "0.0";
                dt.Rows[i]["PrintCostThis"] = "0.0";
                dt.Rows[i]["PrintCostTatol"] = "0.0";
                dt.Rows[i]["UtilitThis"] = "0.0";
                dt.Rows[i]["UtilitTatol"] = "0.0";
                dt.Rows[i]["PostFeesThis"] = "0.0";
                dt.Rows[i]["PostFeesTatol"] = "0.0";
                dt.Rows[i]["TravelThis"] = "0.0";
                dt.Rows[i]["TravelTatol"] = "0.0";
                dt.Rows[i]["VehicleFeeThis"] = "0.0";
                dt.Rows[i]["VehicleFeeTatol"] = "0.0";
                dt.Rows[i]["OtherThis"] = "0.0";
                dt.Rows[i]["OtherTatol"] = "0.0";

                dt.Rows[i]["SumThis"] = "0.0";
                dt.Rows[i]["SumTatol"] = "0.0";
                dt.Rows[i]["Balance"] = ToDec(dt.Rows[i]["PlanNum"]) * 10000 - ToDec(dt.Rows[i]["SumTatol"]);
            }
            for (int j = 0; j < arr.Length; j++)
            {
                if (ddlType.SelectedValue == "1")
                {
                    if (arr[j]["PIID"].ToString() == "1010")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["AdminExpThis"] = arr[j]["ODCkZeroMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["AdminExpThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1010) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["AdminExpTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["AdminExpTatol"].ToString()))
                            {
                                dt.Rows[i]["AdminExpTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["AdminExpThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1010) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["AdminExpTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["AdminExpTatol"].ToString()))
                            {
                                dt.Rows[i]["AdminExpTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1011")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["PrintCostThis"] = arr[j]["ODCkZeroMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["PrintCostThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1011) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["PrintCostTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["PrintCostTatol"].ToString()))
                            {
                                dt.Rows[i]["PrintCostTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["PrintCostThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1011) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["PrintCostTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["PrintCostTatol"].ToString()))
                            {
                                dt.Rows[i]["PrintCostTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1015")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["UtilitThis"] = arr[j]["ODCkZeroMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["UtilitThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1015) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["UtilitTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["UtilitTatol"].ToString()))
                            {
                                dt.Rows[i]["UtilitTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["UtilitThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1015) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["UtilitTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["UtilitTatol"].ToString()))
                            {
                                dt.Rows[i]["UtilitTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1016")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["PostFeesThis"] = arr[j]["ODCkZeroMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["PostFeesThis"] = "0.0";
                        }
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1016) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["PostFeesTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["PostFeesTatol"].ToString()))
                            {
                                dt.Rows[i]["PostFeesTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["PostFeesThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1016) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["PostFeesTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["PostFeesTatol"].ToString()))
                            {
                                dt.Rows[i]["PostFeesTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1018")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["TravelThis"] = arr[j]["ODCkZeroMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["TravelThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1018) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["TravelTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["TravelTatol"].ToString()))
                            {
                                dt.Rows[i]["TravelTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["TravelThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1018) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["TravelTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["TravelTatol"].ToString()))
                            {
                                dt.Rows[i]["TravelTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1031")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["VehicleFeeThis"] = arr[j]["ODCkZeroMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["VehicleFeeThis"] = "0.0";
                        }
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1031) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["VehicleFeeTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["VehicleFeeTatol"].ToString()))
                            {
                                dt.Rows[i]["VehicleFeeTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["VehicleFeeThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1031) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["VehicleFeeTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["VehicleFeeTatol"].ToString()))
                            {
                                dt.Rows[i]["VehicleFeeTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1033")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["OtherThis"] = arr[j]["ODCkZeroMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["OtherThis"] = "0.0";
                        }
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1033) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["OtherTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["OtherTatol"].ToString()))
                            {
                                dt.Rows[i]["OtherTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["OtherThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkZeroMon) as ODCkZeroMon from dbo.FA_OutlayDepCK where PIID in (1033) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["OtherTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["OtherTatol"].ToString()))
                            {
                                dt.Rows[i]["OtherTatol"] = "0.0";
                            }
                        }
                    }
                    if (j == arr.Length - 1)
                    {
                        dt.Rows[i]["SumThis"] = ToDec(dt.Rows[i]["AdminExpThis"].ToString()) + ToDec(dt.Rows[i]["PrintCostThis"].ToString()) + ToDec(dt.Rows[i]["UtilitThis"].ToString()) + ToDec(dt.Rows[i]["PostFeesThis"].ToString()) + ToDec(dt.Rows[i]["TravelThis"].ToString()) + ToDec(dt.Rows[i]["VehicleFeeThis"].ToString()) + ToDec(dt.Rows[i]["OtherThis"].ToString());
                        dt.Rows[i]["SumTatol"] = ToDec(dt.Rows[i]["AdminExpTatol"].ToString()) + ToDec(dt.Rows[i]["PrintCostTatol"].ToString()) + ToDec(dt.Rows[i]["UtilitTatol"].ToString()) + ToDec(dt.Rows[i]["PostFeesTatol"].ToString()) + ToDec(dt.Rows[i]["TravelTatol"].ToString()) + ToDec(dt.Rows[i]["VehicleFeeTatol"].ToString()) + ToDec(dt.Rows[i]["OtherTatol"].ToString());
                        dt.Rows[i]["Balance"] = ToDec(dt.Rows[i]["PlanNum"]) * 10000 - ToDec(dt.Rows[i]["SumTatol"]);
                    }
                }
                if (ddlType.SelectedValue == "0")
                {
                    if (arr[j]["PIID"].ToString() == "1010")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["AdminExpThis"] = arr[j]["ODCkZeroMon"].ToString() + arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["AdminExpThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1010) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["AdminExpTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["AdminExpTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["AdminExpThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1010) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["AdminExpTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["AdminExpTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1011")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["PrintCostThis"] = arr[j]["ODCkZeroMon"].ToString() + arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["PrintCostThis"] = "0.0";
                        }
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1011) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["PrintCostTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["PrintCostTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["PrintCostThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1011) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["PrintCostTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["PrintCostTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1015")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["UtilitThis"] = arr[j]["ODCkZeroMon"].ToString() + arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["UtilitThis"] = "0.0";
                        }
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1015) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["UtilitTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["UtilitTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["UtilitThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1015) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["UtilitTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["UtilitTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1016")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["PostFeesThis"] = arr[j]["ODCkZeroMon"].ToString() + arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["PostFeesThis"] = "0.0";
                        }
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1016) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["PostFeesTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["PostFeesTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["PostFeesThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1016) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["PostFeesTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["PostFeesTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1018")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["TravelThis"] = arr[j]["ODCkZeroMon"].ToString() + arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["TravelThis"] = "0.0";
                        }
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1018) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["TravelTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["TravelTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["TravelThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1018) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["TravelTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["TravelTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1031")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["VehicleFeeThis"] = arr[j]["ODCkZeroMon"].ToString() + arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["VehicleFeeThis"] = "0.0";
                        }
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1031) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["VehicleFeeTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["VehicleFeeTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["VehicleFeeThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1031) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["VehicleFeeTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["VehicleFeeTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1033")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["OtherThis"] = arr[j]["ODCkZeroMon"].ToString() + arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["OtherThis"] = "0.0";
                        }
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1033) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["OtherTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["OtherTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["OtherThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select  SUM(ODCkZeroMon) as ODCkZeroMon,SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1033) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            DataTable dt3 = DBUnity.AdapterToTab(sqlStr1);
                            if (dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkZeroMon"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[0]["ODCkAreaMon"].ToString()))
                            {
                                dt.Rows[i]["OtherTatol"] = ToDec(dt3.Rows[0]["ODCkZeroMon"].ToString()) + ToDec(dt3.Rows[0]["ODCkAreaMon"].ToString());
                            }
                            else
                            {
                                dt.Rows[i]["OtherTatol"] = "0.0";
                            }
                        }
                    }
                    if (j == arr.Length - 1)
                    {
                        dt.Rows[i]["SumThis"] = ToDec(dt.Rows[i]["AdminExpThis"].ToString()) + ToDec(dt.Rows[i]["PrintCostThis"].ToString()) + ToDec(dt.Rows[i]["UtilitThis"].ToString()) + ToDec(dt.Rows[i]["PostFeesThis"].ToString()) + ToDec(dt.Rows[i]["TravelThis"].ToString()) + ToDec(dt.Rows[i]["VehicleFeeThis"].ToString()) + ToDec(dt.Rows[i]["OtherThis"].ToString());
                        dt.Rows[i]["SumTatol"] = ToDec(dt.Rows[i]["AdminExpTatol"].ToString()) + ToDec(dt.Rows[i]["PrintCostTatol"].ToString()) + ToDec(dt.Rows[i]["UtilitTatol"].ToString()) + ToDec(dt.Rows[i]["PostFeesTatol"].ToString()) + ToDec(dt.Rows[i]["TravelTatol"].ToString()) + ToDec(dt.Rows[i]["VehicleFeeTatol"].ToString()) + ToDec(dt.Rows[i]["OtherTatol"].ToString());
                        dt.Rows[i]["Balance"] = ToDec(dt.Rows[i]["PlanNum"]) * 10000 - ToDec(dt.Rows[i]["SumTatol"]);
                    }
                }
                if (ddlType.SelectedValue == "2")
                {
                    if (arr[j]["PIID"].ToString() == "1010")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["AdminExpThis"] = arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["AdminExpThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1010) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["AdminExpTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["AdminExpTatol"].ToString()))
                            {
                                dt.Rows[i]["AdminExpTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["AdminExpThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1010) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["AdminExpTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["AdminExpTatol"].ToString()))
                            {
                                dt.Rows[i]["AdminExpTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1011")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["PrintCostThis"] = arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["PrintCostThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1011) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["PrintCostTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["PrintCostTatol"].ToString()))
                            {
                                dt.Rows[i]["PrintCostTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["PrintCostThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1011) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["PrintCostTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["PrintCostTatol"].ToString()))
                            {
                                dt.Rows[i]["PrintCostTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1015")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["UtilitThis"] = arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["UtilitThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1015) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["UtilitTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["UtilitTatol"].ToString()))
                            {
                                dt.Rows[i]["UtilitTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["UtilitThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1015) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["UtilitTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["UtilitTatol"].ToString()))
                            {
                                dt.Rows[i]["UtilitTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1016")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["PostFeesThis"] = arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["PostFeesThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1016) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["PostFeesTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["PostFeesTatol"].ToString()))
                            {
                                dt.Rows[i]["PostFeesTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["PostFeesThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1016) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["PostFeesTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["PostFeesTatol"].ToString()))
                            {
                                dt.Rows[i]["PostFeesTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1018")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["TravelThis"] = arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["TravelThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1018) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["TravelTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["TravelTatol"].ToString()))
                            {
                                dt.Rows[i]["TravelTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["TravelThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1018) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["TravelTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["TravelTatol"].ToString()))
                            {
                                dt.Rows[i]["TravelTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1031")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["VehicleFeeThis"] = arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["VehicleFeeThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1031) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["VehicleFeeTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["VehicleFeeTatol"].ToString()))
                            {
                                dt.Rows[i]["VehicleFeeTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["VehicleFeeThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1031) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["VehicleFeeTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["VehicleFeeTatol"].ToString()))
                            {
                                dt.Rows[i]["VehicleFeeTatol"] = "0.0";
                            }
                        }
                    }
                    if (arr[j]["PIID"].ToString() == "1033")
                    {
                        if (Convert.ToDateTime(arr[j]["ODCkTime"].ToString()).ToString("yyyy-MM") == tbDate.Text)
                        {
                            dt.Rows[i]["OtherThis"] = arr[j]["ODCkAreaMon"].ToString();
                        }
                        else
                        {
                            dt.Rows[i]["OtherThis"] = "0.0";
                        }

                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1033) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["OtherTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["OtherTatol"].ToString()))
                            {
                                dt.Rows[i]["OtherTatol"] = "0.0";
                            }
                        }
                    }
                    else
                    {
                        dt.Rows[i]["OtherThis"] = "0.0";
                        if (j == arr.Length - 1)
                        {
                            string sqlStr1 = string.Format("select SUM(ODCkAreaMon) as ODCkAreaMon from dbo.FA_OutlayDepCK where PIID in (1033) and Convert(varchar(7),ODCkTime,120) between '{0}' And '{1}' and DepID={2}", year.ToString() + "-" + "01", tbDate.Text, arr[j]["DepID"].ToString());
                            dt.Rows[i]["OtherTatol"] = DBUnity.ExecuteScalar(CommandType.Text, sqlStr1, null);
                            if (string.IsNullOrEmpty(dt.Rows[i]["OtherTatol"].ToString()))
                            {
                                dt.Rows[i]["OtherTatol"] = "0.0";
                            }
                        }
                    }
                    if (j == arr.Length - 1)
                    {
                        dt.Rows[i]["SumThis"] = ToDec(dt.Rows[i]["AdminExpThis"].ToString()) + ToDec(dt.Rows[i]["PrintCostThis"].ToString()) + ToDec(dt.Rows[i]["UtilitThis"].ToString()) + ToDec(dt.Rows[i]["PostFeesThis"].ToString()) + ToDec(dt.Rows[i]["TravelThis"].ToString()) + ToDec(dt.Rows[i]["VehicleFeeThis"].ToString()) + ToDec(dt.Rows[i]["OtherThis"].ToString());
                        dt.Rows[i]["SumTatol"] = ToDec(dt.Rows[i]["AdminExpTatol"].ToString()) + ToDec(dt.Rows[i]["PrintCostTatol"].ToString()) + ToDec(dt.Rows[i]["UtilitTatol"].ToString()) + ToDec(dt.Rows[i]["PostFeesTatol"].ToString()) + ToDec(dt.Rows[i]["TravelTatol"].ToString()) + ToDec(dt.Rows[i]["VehicleFeeTatol"].ToString()) + ToDec(dt.Rows[i]["OtherTatol"].ToString());
                        dt.Rows[i]["Balance"] = ToDec(dt.Rows[i]["PlanNum"]) * 10000 - ToDec(dt.Rows[i]["SumTatol"]);
                    }
                }



            }
        }

        RepLeaderQuery.DataSource = dt;
        RepLeaderQuery.DataBind();
    }


    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string title = "(" + tbDate.Text + ")基层单位日常公用支出明细表.xls";
        int year = Convert.ToDateTime(tbDate.Text).Year;
        string sql = string.Empty;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        if (uselim == 1001)
        {
            sql = string.Format(" select * from dbo.FA_Department  where DepID={0}", depid);

            dt1 = DBUnity.AdapterToTab(sql);
        }
        else
        {
            sql = " select * from dbo.FA_Department ";//as a left join dbo.FA_DepBudAllocat as b on a.DepID=b.DepID  where b.DBAYear=  + year.ToString()
            dt1 = DBUnity.AdapterToTab(sql);
        }
        dt.Columns.Add("TheOther");
        dt.Columns.Add("PlanNum");
        dt.Columns.Add("AdminExpThis");
        dt.Columns.Add("AdminExpTatol");
        dt.Columns.Add("PrintCostThis");
        dt.Columns.Add("PrintCostTatol");
        dt.Columns.Add("UtilitThis");
        dt.Columns.Add("UtilitTatol");
        dt.Columns.Add("PostFeesThis");
        dt.Columns.Add("PostFeesTatol");
        dt.Columns.Add("TravelThis");
        dt.Columns.Add("TravelTatol");
        dt.Columns.Add("VehicleFeeThis");
        dt.Columns.Add("VehicleFeeTatol");
        dt.Columns.Add("TrainThis");
        dt.Columns.Add("TrainTatol");
        dt.Columns.Add("MeetingThis");
        dt.Columns.Add("MeetingTatol");
        dt.Columns.Add("OtherThis");
        dt.Columns.Add("OtherTatol");
        dt.Columns.Add("SumThis");
        dt.Columns.Add("SumTatol");
        dt.Columns.Add("Balance");
        GetRows(dt,dt1);

        TableCell[] header = new TableCell[35];
        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }
        header[0].Text = "基层单位日常公用支出明细表</th></tr><tr>";
        header[0].ColumnSpan = 23;
        header[1].Text = "所别";
        header[1].RowSpan = 3;
        header[2].Text = "预算数(万元)";
        header[2].RowSpan = 3;
        header[3].Text = "支出类（元）";
        header[3].ColumnSpan = 18;
        header[4].Text = "合计";
        header[4].ColumnSpan = 2;
        header[5].Text = "结余余额</th></tr><tr>";
        header[5].RowSpan = 3;

        header[6].Text = "办公费";
        header[6].ColumnSpan = 2;
        header[7].Text = "印刷费";
        header[7].ColumnSpan = 2;
        header[8].Text = "水电费";
        header[8].ColumnSpan = 2;
        header[9].Text = "邮电费";
        header[9].ColumnSpan = 2;
        header[10].Text = "差旅费";
        header[10].ColumnSpan = 2;
        header[11].Text = "公务用车运行维护费";
        header[11].ColumnSpan = 2;
        header[12].Text = "培训费";
        header[12].ColumnSpan = 2;
        header[13].Text = "会议费";
        header[13].ColumnSpan = 2;
        header[14].Text = "其他";
        header[14].ColumnSpan = 2;
        header[15].Text = "本月";
        header[15].RowSpan = 2;
        header[16].Text = "累计</th></tr><tr>";
        header[16].RowSpan = 2;


        header[17].Text = "本月";
        header[18].Text = "累计";
        header[19].Text = "本月";
        header[20].Text = "累计";
        header[21].Text = "本月";
        header[22].Text = "累计";
        header[23].Text = "本月";
        header[24].Text = "累计";
        header[25].Text = "本月";
        header[26].Text = "累计";
        header[27].Text = "本月";
        header[28].Text = "累计";
        header[29].Text = "本月";
        header[30].Text = "累计";
        header[31].Text = "本月";
        header[32].Text = "累计";
        header[33].Text = "本月";
        header[34].Text = "累计</th>";

        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            mergeCellNums.Add(i, 0);
        }
        common.DataTable2Excel(dt, header, title, mergeCellNums, 0);
    }
}