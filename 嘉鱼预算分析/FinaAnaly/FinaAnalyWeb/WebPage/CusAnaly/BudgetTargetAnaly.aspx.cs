using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using Common;
using FinaAnaly.Model;

public partial class WebPage_CusAnaly_BudgetTargetAnaly : System.Web.UI.Page
{
    int uselim = 0;
    int depid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //获取本月
    private decimal GetBudgetDataThis(string str,string type)
    {
        decimal dclBudThis = 0;
        int year = Convert.ToDateTime(tbDate.Text).Year;
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int piid = 0;
                    if (dt.Rows[i]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[i]["PIID"]);
                    }
                    DateTime time = Convert.ToDateTime(tbDate.Text);
                    FA_XOutlayIncomeCK oick1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                    if (oick1 != null)
                    {
                        if (ddlType.SelectedValue == "0")
                        {
                            dclBudThis = dclBudThis + oick1.ODCKAreaMon + oick1.ODCKZeroMon;
                        }
                        if (ddlType.SelectedValue == "1")
                        {
                            dclBudThis = dclBudThis + oick1.ODCKZeroMon;
                        }
                        if (ddlType.SelectedValue == "2")
                        {
                            dclBudThis = dclBudThis + oick1.ODCKAreaMon;
                        }
                    }
                }
            }
        return dclBudThis;
    }

    private decimal GetBudgetDataThisL(string str, string type,int length)
    {
        decimal dclBudThis = 0;
        int year = Convert.ToDateTime(tbDate.Text).Year;
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int piid = 0;
                string piestr=dt.Rows[i]["PIEcoSubCoding"].ToString();
                if (dt.Rows[i]["PIType"].ToString() == type && piestr.Length==length)
                {
                    piid = common.IntSafeConvert(dt.Rows[i]["PIID"]);
                }
                DateTime time = Convert.ToDateTime(tbDate.Text);
                FA_XOutlayIncomeCK oick1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                if (oick1 != null)
                {
                    if (ddlType.SelectedValue == "0")
                    {
                        dclBudThis = dclBudThis + oick1.ODCKAreaMon + oick1.ODCKZeroMon;
                    }
                    if (ddlType.SelectedValue == "1")
                    {
                        dclBudThis = dclBudThis + oick1.ODCKZeroMon;
                    }
                    if (ddlType.SelectedValue == "2")
                    {
                        dclBudThis = dclBudThis + oick1.ODCKAreaMon;
                    }
                }
            }
        }
        return dclBudThis;
    }

    //获取预算经费指标
    private decimal GetBudgetData(string str,string type)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        decimal dclBud = 0;
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int piid = 0;
                if (dt.Rows[i]["PIType"].ToString() == type)
                {
                    piid = common.IntSafeConvert(dt.Rows[i]["PIID"]);
                }
                dclBud = dclBud + FA_XIncomeBudAllocatManager.GetXIncomeBudAllocatByPIIDYear(piid, year);
            }
        }
        return dclBud;
    }

    //获取累计
    private decimal GetBudgetDataTatol(string str,string type)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        decimal dclTatol = 0;
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    decimal dclBudTatol = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    for (int i = mon; i > 0; i--)
                    {
                        DateTime time1 = Convert.ToDateTime(year.ToString() + "-" + i.ToString());
                        FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                        if (oick11 != null)
                        {
                            if (ddlType.SelectedValue == "0")
                            {
                                dclBudTatol = dclBudTatol + oick11.ODCKAreaMon + oick11.ODCKZeroMon;
                            }
                            if (ddlType.SelectedValue == "1")
                            {
                                dclBudTatol = dclBudTatol + oick11.ODCKZeroMon;
                            }
                            if (ddlType.SelectedValue == "2")
                            {
                                dclBudTatol = dclBudTatol + oick11.ODCKAreaMon;
                            }
                        }
                    }
                    dclTatol = dclTatol + dclBudTatol;
                }
            }
        return dclTatol;
    }

    private decimal GetBudgetDataTatolL(string str, string type,int length)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        decimal dclTatol = 0;
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = 0;
                decimal dclBudTatol = 0;
                string piestr=dt.Rows[j]["PIEcoSubCoding"].ToString();
                if (dt.Rows[j]["PIType"].ToString() == type && piestr.Length==length)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                }
                for (int i = mon; i > 0; i--)
                {
                    DateTime time1 = Convert.ToDateTime(year.ToString() + "-" + i.ToString());
                    FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                    if (oick11 != null)
                    {
                        if (ddlType.SelectedValue == "0")
                        {
                            dclBudTatol = dclBudTatol + oick11.ODCKAreaMon + oick11.ODCKZeroMon;
                        }
                        if (ddlType.SelectedValue == "1")
                        {
                            dclBudTatol = dclBudTatol + oick11.ODCKZeroMon;
                        }
                        if (ddlType.SelectedValue == "2")
                        {
                            dclBudTatol = dclBudTatol + oick11.ODCKAreaMon;
                        }
                    }
                }
                dclTatol = dclTatol + dclBudTatol;
            }
        }
        return dclTatol;
    }

    //private void BudDataBind()
    //{
    //    int year = Convert.ToDateTime(tbDate.Text).Year;
    //    DateTime time = Convert.ToDateTime(tbDate.Text);

    //    decimal dc1 = GetBudgetData("基本工资") + GetBudgetData("津补贴") + GetBudgetData("奖金") + GetBudgetData("医疗保险") + GetBudgetData("其他社会保障费");
    //    decimal dc11 = GetBudgetDataThis("基本工资") + GetBudgetDataThis("津补贴") + GetBudgetDataThis("奖金") + GetBudgetDataThis("医疗保险") + GetBudgetDataThis("其他社会保障费");
    //    decimal dc111 = GetBudgetDataTatol("基本工资") + GetBudgetDataTatol("津补贴") + GetBudgetDataTatol("奖金") + GetBudgetDataTatol("医疗保险") + GetBudgetDataTatol("其他社会保障费");
    //    decimal dc2 = GetBudgetData("医疗费") + GetBudgetData("离退休人员经费") + GetBudgetData("住房公积金") + GetBudgetData("提租补贴") + GetBudgetData("货币化补贴") + GetBudgetData("其他补助");
    //    decimal dc22 = GetBudgetDataThis("医疗费") + GetBudgetDataThis("离退休人员经费") + GetBudgetDataThis("住房公积金") + GetBudgetDataThis("提租补贴") + GetBudgetDataThis("货币化补贴") + GetBudgetDataThis("其他补助");
    //    decimal dc222 = GetBudgetDataTatol("医疗费") + GetBudgetDataTatol("离退休人员经费") + GetBudgetDataTatol("住房公积金") + GetBudgetDataTatol("提租补贴") + GetBudgetDataTatol("货币化补贴") + GetBudgetDataTatol("其他补助");
    //    decimal dc3 = GetBudgetData("办公费") + GetBudgetData("水电费") + GetBudgetData("邮电费") + GetBudgetData("差旅费") + GetBudgetData("印刷费") + GetBudgetData("福利费") + GetBudgetData("一般培训费") + GetBudgetData("一般会议费") + GetBudgetData("一般设备购置费") + GetBudgetData("日常维修费") + GetBudgetData("物业管理费") + GetBudgetData("交通费") + GetBudgetData("工会经费") + GetBudgetData("招待费") + GetBudgetData("其他费用");
    //    decimal dc33 = GetBudgetDataThis("办公费") + GetBudgetDataThis("水电费") + GetBudgetDataThis("邮电费") + GetBudgetDataThis("差旅费") + GetBudgetDataThis("印刷费") + GetBudgetDataThis("福利费") + GetBudgetDataThis("一般培训费") + GetBudgetDataThis("一般会议费") + GetBudgetDataThis("一般设备购置费") + GetBudgetDataThis("日常维修费") + GetBudgetDataThis("物业管理费") + GetBudgetDataThis("交通费") + GetBudgetDataThis("工会经费") + GetBudgetDataThis("招待费") + GetBudgetDataThis("其他费用");
    //    decimal dc333 = GetBudgetDataTatol("办公费") + GetBudgetDataTatol("水电费") + GetBudgetDataTatol("邮电费") + GetBudgetDataTatol("差旅费") + GetBudgetDataTatol("印刷费") + GetBudgetDataTatol("福利费") + GetBudgetDataTatol("一般培训费") + GetBudgetDataTatol("一般会议费") + GetBudgetDataTatol("一般设备购置费") + GetBudgetDataTatol("日常维修费") + GetBudgetDataTatol("物业管理费") + GetBudgetDataTatol("交通费") + GetBudgetDataTatol("工会经费") + GetBudgetDataTatol("招待费") + GetBudgetDataTatol("其他费用");
    //    decimal dc4 = GetBudgetData("计算机及设备购置费") + GetBudgetData("办公设备购置费") + GetBudgetData("图书资料购置费") + GetBudgetData("其他设备购置费") + GetBudgetData("印刷费") + GetBudgetData("交通设备购置费") + GetBudgetData("大型会议费")
    //                  + GetBudgetData("大型修缮费") + GetBudgetData("业务费") + GetBudgetData("税法宣传费") + GetBudgetData("出国经费") + GetBudgetData("专项培训费") + GetBudgetData("协税费") + GetBudgetData("联合办案费") + GetBudgetData("党团活动费")
    //                  + GetBudgetData("专项印刷费") + GetBudgetData("工会经费") + GetBudgetData("服装费") + GetBudgetData("妇代会") + GetBudgetData("发票经费") + GetBudgetData("征管业务费") + GetBudgetData("计算机应用经费") + GetBudgetData("“三代”手续费支出") + GetBudgetData("其他") + GetBudgetData("专项公用经费") + GetBudgetData("其他项目支出");
    //    decimal dc44 = GetBudgetDataThis("计算机及设备购置费") + GetBudgetDataThis("办公设备购置费") + GetBudgetDataThis("图书资料购置费") + GetBudgetDataThis("其他设备购置费") + GetBudgetDataThis("印刷费") + GetBudgetDataThis("交通设备购置费") + GetBudgetDataThis("大型会议费")
    //                 + GetBudgetDataThis("大型修缮费") + GetBudgetDataThis("业务费") + GetBudgetDataThis("税法宣传费") + GetBudgetDataThis("出国经费") + GetBudgetDataThis("专项培训费") + GetBudgetDataThis("协税费") + GetBudgetDataThis("联合办案费") + GetBudgetDataThis("党团活动费")
    //                 + GetBudgetDataThis("专项印刷费") + GetBudgetDataThis("工会经费") + GetBudgetDataThis("服装费") + GetBudgetDataThis("妇代会") + GetBudgetDataThis("发票经费") + GetBudgetDataThis("征管业务费") + GetBudgetDataThis("计算机应用经费") + GetBudgetDataThis("“三代”手续费支出") + GetBudgetDataThis("其他") + GetBudgetDataThis("专项公用经费") + GetBudgetDataThis("其他项目支出");
    //    decimal dc444 = GetBudgetDataTatol("计算机及设备购置费") + GetBudgetDataTatol("办公设备购置费") + GetBudgetDataTatol("图书资料购置费") + GetBudgetDataTatol("其他设备购置费") + GetBudgetDataTatol("印刷费") + GetBudgetDataTatol("交通设备购置费") + GetBudgetDataTatol("大型会议费")
    //          + GetBudgetDataTatol("大型修缮费") + GetBudgetDataTatol("业务费") + GetBudgetDataTatol("税法宣传费") + GetBudgetDataTatol("出国经费") + GetBudgetDataTatol("专项培训费") + GetBudgetDataTatol("协税费") + GetBudgetDataTatol("联合办案费") + GetBudgetDataTatol("党团活动费")
    //          + GetBudgetDataTatol("专项印刷费") + GetBudgetDataTatol("工会经费") + GetBudgetDataTatol("服装费") + GetBudgetDataTatol("妇代会") + GetBudgetDataTatol("发票经费") + GetBudgetDataTatol("征管业务费") + GetBudgetDataTatol("计算机应用经费") + GetBudgetDataTatol("“三代”手续费支出") + GetBudgetDataTatol("其他") + GetBudgetDataTatol("专项公用经费") + GetBudgetDataTatol("其他项目支出");

    //    DataTable dt = new DataTable();
    //    dt.Columns.Add("column1");
    //    dt.Columns.Add("column2");
    //    dt.Columns.Add("column3");
    //    dt.Columns.Add("column4");
    //    dt.Columns.Add("column5");
    //    dt.Columns.Add("column6");
    //    dt.Columns.Add("column7");
    //    DataRow dr1 = dt.NewRow();
    //    dr1["column1"] = "一、基本支出";
    //    dr1["column2"] = dc1 + dc2 + dc3 + dc4;
    //    if (dc11 + dc22 + dc33 + dc44 != 0)
    //    {
    //        dr1["column3"] = (dc11 + dc22 + dc33 + dc44).ToString("f2");
    //    }
    //    if (dc111 + dc222 + dc333 + dc444 != 0)
    //    {
    //        dr1["column4"] = (dc111 + dc222 + dc333 + dc444).ToString("f2");
    //    }
    //    if (dc1 + dc2 + dc3 + dc4 != 0)
    //    {
    //        dr1["column5"] = (((dc111 + dc222 + dc333 + dc444) / ((dc1 + dc2 + dc3 + dc4) * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    dr1["column6"] = (dc1 + dc2 + dc3 + dc4) * 10000 - (dc111 + dc222 + dc333 + dc444);
    //    dt.Rows.Add(dr1);

    //    DataRow dr2 = dt.NewRow();
    //    dr2["column1"] = "（一）工资福利支出";
    //    dr2["column2"] = dc1 + dc2 + dc3;
    //    if (dc11 + dc22 + dc33 != 0)
    //    {
    //        dr2["column3"] = (dc11 + dc22 + dc33).ToString("f2");
    //    }
    //    if (dc111 + dc222 + dc333 != 0)
    //    {
    //        dr2["column4"] = (dc111 + dc222 + dc333).ToString("f2");
    //    }
    //    if (dc1 + dc2 + dc3 != 0)
    //    {
    //        dr2["column5"] = (((dc111 + dc222 + dc333) / ((dc1 + dc2 + dc3) * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    dr2["column6"] = (dc1 + dc2 + dc3) * 10000 - (dc111 + dc222 + dc333);
    //    dt.Rows.Add(dr2);

    //    DataRow dr3 = dt.NewRow();
    //    dr3["column1"] = "（一）人员经费支出";
    //    dr3["column2"] = dc1;
    //    if (dc11 != 0)
    //    {
    //        dr3["column3"] = (dc11).ToString("f2");
    //    }
    //    if (dc111 != 0)
    //    {
    //        dr3["column4"] = (dc111).ToString("f2");
    //    }
    //    if (common.IntSafeConvert(dr3["column2"]) != 0)
    //    {
    //        dr3["column5"] = ((dc111 / (dc1 * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    dr3["column6"] = (dc1 * 10000) - dc111;
    //    dt.Rows.Add(dr3);

    //    DataRow dr4 = dt.NewRow();
    //    dr4["column1"] = "基本工资";
    //    if (GetBudgetData("基本工资") != 0)
    //    {
    //        dr4["column2"] = GetBudgetData("基本工资");
    //    }
    //    if (GetBudgetDataThis("基本工资") != 0)
    //    {
    //        dr4["column3"] = (GetBudgetDataThis("基本工资")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("基本工资") != 0)
    //    {
    //        dr4["column4"] = (GetBudgetDataTatol("基本工资")).ToString("f2");
    //    }
    //    if (GetBudgetData("基本工资") != 0)
    //    {
    //        dr4["column5"] = ((GetBudgetDataTatol("基本工资") / (GetBudgetData("基本工资") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("基本工资") * 10000 - GetBudgetDataTatol("基本工资") != 0)
    //    {
    //        dr4["column6"] = GetBudgetData("基本工资") * 10000 - GetBudgetDataTatol("基本工资");
    //    }
    //    dt.Rows.Add(dr4);

    //    DataRow dr5 = dt.NewRow();
    //    dr5["column1"] = "津补贴";
    //    if (GetBudgetData("津补贴") != 0)
    //    {
    //        dr5["column2"] = GetBudgetData("津补贴");
    //    }
    //    if (GetBudgetDataThis("津补贴") != 0)
    //    {
    //        dr5["column3"] = (GetBudgetDataThis("津补贴")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("津补贴") != 0)
    //    {
    //        dr5["column4"] = (GetBudgetDataTatol("津补贴")).ToString("f2");
    //    }
    //    if (GetBudgetData("津补贴") != 0)
    //    {
    //        dr5["column5"] = ((GetBudgetDataTatol("津补贴") / (GetBudgetData("津补贴") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("津补贴") * 10000 - GetBudgetDataTatol("津补贴") != 0)
    //    {
    //        dr5["column6"] = GetBudgetData("津补贴") * 10000 - GetBudgetDataTatol("津补贴");
    //    }
    //    dt.Rows.Add(dr5);

    //    DataRow dr6 = dt.NewRow();
    //    dr6["column1"] = "其中：（1）中央省市津补贴";
    //    dt.Rows.Add(dr6);
    //    DataRow dr7 = dt.NewRow();
    //    dr7["column1"] = "（ 2）特岗补贴";
    //    dt.Rows.Add(dr7);
    //    DataRow dr8 = dt.NewRow();
    //    dr8["column1"] = "（3）其他津补贴";
    //    dt.Rows.Add(dr8);

    //    DataRow dr9 = dt.NewRow();
    //    dr9["column1"] = "奖金";
    //    if (GetBudgetData("奖金") != 0)
    //    {
    //        dr9["column2"] = GetBudgetData("奖金");
    //    }
    //    if (GetBudgetDataThis("奖金") != 0)
    //    {
    //        dr9["column3"] = (GetBudgetDataThis("奖金")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("奖金") != 0)
    //    {
    //        dr9["column4"] = (GetBudgetDataTatol("奖金").ToString("f2"));
    //    }
    //    if (GetBudgetData("奖金") != 0)
    //    {
    //        dr9["column5"] = ((GetBudgetDataTatol("奖金") / (GetBudgetData("奖金") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("奖金") * 10000 - GetBudgetDataTatol("奖金") != 0)
    //    {
    //        dr9["column6"] = GetBudgetData("奖金") * 10000 - GetBudgetDataTatol("奖金");
    //    }
    //    dt.Rows.Add(dr9);
    //    DataRow dr10 = dt.NewRow();
    //    dr10["column1"] = "其中：（1）月度目标奖";
    //    dt.Rows.Add(dr10);
    //    DataRow dr11 = dt.NewRow();
    //    dr11["column1"] = " （2）第十三月奖";
    //    dt.Rows.Add(dr11);
    //    DataRow dr12 = dt.NewRow();
    //    dr12["column1"] = "（3）其他奖金";
    //    dt.Rows.Add(dr12);
    //    DataRow dr13 = dt.NewRow();
    //    dr13["column1"] = "医疗保险";
    //    if (GetBudgetData("医疗保险") != 0)
    //    {
    //        dr13["column2"] = GetBudgetData("医疗保险");
    //    } if (GetBudgetDataThis("医疗保险") != 0)
    //    {
    //        dr13["column3"] = (GetBudgetDataThis("医疗保险")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("医疗保险") != 0)
    //    {
    //        dr13["column4"] = (GetBudgetDataTatol("医疗保险")).ToString("f2");
    //    }
    //    if (GetBudgetData("医疗保险") != 0)
    //    {
    //        dr13["column5"] = ((GetBudgetDataTatol("医疗保险") / (GetBudgetData("医疗保险") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("医疗保险") * 10000 - GetBudgetDataTatol("医疗保险") != 0)
    //    {
    //        dr13["column6"] = GetBudgetData("医疗保险") * 10000 - GetBudgetDataTatol("医疗保险");
    //    }
    //    dt.Rows.Add(dr13);

    //    DataRow dr14 = dt.NewRow();
    //    dr14["column1"] = "其他社会保障费";
    //    if (GetBudgetData("其他社会保障费") != 0)
    //    {
    //        dr14["column2"] = GetBudgetData("其他社会保障费");
    //    }
    //    if (GetBudgetDataThis("其他社会保障费") != 0)
    //    {
    //        dr14["column3"] = (GetBudgetDataThis("其他社会保障费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("其他社会保障费") != 0)
    //    {
    //        dr14["column4"] = (GetBudgetDataTatol("其他社会保障费")).ToString("f2");
    //    }
    //    if (GetBudgetData("其他社会保障费") != 0)
    //    {
    //        dr14["column5"] = ((GetBudgetDataTatol("其他社会保障费") / (GetBudgetData("其他社会保障费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("其他社会保障费") * 10000 - GetBudgetDataTatol("其他社会保障费") != 0)
    //    {
    //        dr14["column6"] = GetBudgetData("其他社会保障费") * 10000 - GetBudgetDataTatol("其他社会保障费");
    //    }
    //    dt.Rows.Add(dr14);

    //    DataRow dr15 = dt.NewRow();
    //    dr15["column1"] = "（二）对个人和家庭补助";
    //    dr15["column2"] = dc2;
    //    if (dc22 != 0)
    //    {
    //        dr15["column3"] = (dc22).ToString("f2");
    //    }
    //    if (dc222 != 0)
    //    {
    //        dr15["column4"] = (dc222).ToString("f2");
    //    }
    //    if (common.IntSafeConvert(dr3["column2"]) != 0)
    //    {
    //        dr15["column5"] = ((dc222 / (dc2 * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    dr15["column6"] = dc2 * 10000 - dc222;
    //    dt.Rows.Add(dr15);

    //    DataRow dr16 = dt.NewRow();
    //    dr16["column1"] = "医疗费";
    //    if (GetBudgetData("医疗费") != 0)
    //    {
    //        dr16["column2"] = GetBudgetData("医疗费");
    //    }
    //    if (GetBudgetDataThis("医疗费") != 0)
    //    {
    //        dr16["column3"] = (GetBudgetDataThis("医疗费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("医疗费") != 0)
    //    {
    //        dr16["column4"] = (GetBudgetDataTatol("医疗费")).ToString("f2");
    //    }
    //    if (GetBudgetData("医疗费") != 0)
    //    {
    //        dr16["column5"] = ((GetBudgetDataTatol("医疗费") / (GetBudgetData("医疗费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("医疗费") * 10000 - GetBudgetDataTatol("医疗费") != 0)
    //    {
    //        dr16["column6"] = GetBudgetData("医疗费") * 10000 - GetBudgetDataTatol("医疗费");
    //    }
    //    dt.Rows.Add(dr16);

    //    DataRow dr17 = dt.NewRow();
    //    dr17["column1"] = "离退休人员经费";
    //    if (GetBudgetData("离退休人员经费") != 0)
    //    {
    //        dr17["column2"] = GetBudgetData("离退休人员经费");
    //    }
    //    if (GetBudgetDataThis("离退休人员经费") != 0)
    //    {
    //        dr17["column3"] = (GetBudgetDataThis("离退休人员经费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("离退休人员经费") != 0)
    //    {
    //        dr17["column4"] = (GetBudgetDataTatol("离退休人员经费")).ToString("f2");
    //    }
    //    if (GetBudgetData("离退休人员经费") != 0)
    //    {
    //        dr17["column5"] = ((GetBudgetDataTatol("离退休人员经费") / (GetBudgetData("离退休人员经费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("离退休人员经费") * 10000 - GetBudgetDataTatol("离退休人员经费") != 0)
    //    {
    //        dr17["column6"] = GetBudgetData("离退休人员经费") * 10000 - GetBudgetDataTatol("离退休人员经费");
    //    }
    //    dt.Rows.Add(dr17);

    //    DataRow dr18 = dt.NewRow();
    //    dr18["column1"] = "住房公积金";
    //    if (GetBudgetData("住房公积金") != 0)
    //    {
    //        dr18["column2"] = GetBudgetData("住房公积金");
    //    }
    //    if (GetBudgetDataThis("住房公积金") != 0)
    //    {
    //        dr18["column3"] = (GetBudgetDataThis("住房公积金")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("住房公积金") != 0)
    //    {
    //        dr18["column4"] = (GetBudgetDataTatol("住房公积金")).ToString("f2");
    //    }
    //    if (GetBudgetData("住房公积金") != 0)
    //    {
    //        dr18["column5"] = ((GetBudgetDataTatol("住房公积金") / (GetBudgetData("住房公积金") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("住房公积金") * 10000 - GetBudgetDataTatol("住房公积金") != 0)
    //    {
    //        dr18["column6"] = GetBudgetData("住房公积金") * 10000 - GetBudgetDataTatol("住房公积金");
    //    }
    //    dt.Rows.Add(dr18);

    //    DataRow dr19 = dt.NewRow();
    //    dr19["column1"] = "提租补贴";
    //    if (GetBudgetData("提租补贴") != 0)
    //    {
    //        dr19["column2"] = GetBudgetData("提租补贴");
    //    }
    //    if (GetBudgetDataThis("提租补贴") != 0)
    //    {
    //        dr19["column3"] = (GetBudgetDataThis("提租补贴")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("提租补贴") != 0)
    //    {
    //        dr19["column4"] = (GetBudgetDataTatol("提租补贴")).ToString("f2");
    //    }
    //    if (GetBudgetData("提租补贴") != 0)
    //    {
    //        dr19["column5"] = ((GetBudgetDataTatol("提租补贴") / (GetBudgetData("提租补贴") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("提租补贴") * 10000 - GetBudgetDataTatol("提租补贴") != 0)
    //    {
    //        dr19["column6"] = GetBudgetData("提租补贴") * 10000 - GetBudgetDataTatol("提租补贴");
    //    }
    //    dt.Rows.Add(dr19);


    //    DataRow dr20 = dt.NewRow();

    //    dr20["column1"] = "货币化补贴";
    //    if (GetBudgetData("货币化补贴") != 0)
    //    {
    //        dr20["column2"] = GetBudgetData("货币化补贴");
    //    }
    //    if (GetBudgetDataThis("货币化补贴") != 0)
    //    {
    //        dr20["column3"] = (GetBudgetDataThis("货币化补贴")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("货币化补贴") != 0)
    //    {
    //        dr20["column4"] = (GetBudgetDataTatol("货币化补贴")).ToString("f2");
    //    }
    //    if (GetBudgetData("货币化补贴") != 0)
    //    {
    //        dr20["column5"] = ((GetBudgetDataTatol("货币化补贴") / (GetBudgetData("货币化补贴") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("货币化补贴") * 10000 - GetBudgetDataTatol("货币化补贴") != 0)
    //    {
    //        dr20["column6"] = GetBudgetData("货币化补贴") * 10000 - GetBudgetDataTatol("货币化补贴");
    //    }
    //    dt.Rows.Add(dr20);

    //    DataRow dr21 = dt.NewRow();
    //    dr21["column1"] = "其他补助";
    //    if (GetBudgetData("其他补助") != 0)
    //    {
    //        dr21["column2"] = GetBudgetData("其他补助");
    //    }
    //    if (GetBudgetDataThis("其他补助") != 0)
    //    {
    //        dr21["column3"] = (GetBudgetDataThis("其他补助")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("其他补助") != 0)
    //    {
    //        dr21["column4"] = (GetBudgetDataTatol("其他补助")).ToString("f2");
    //    }
    //    if (GetBudgetData("其他补助") != 0)
    //    {
    //        dr21["column5"] = ((GetBudgetDataTatol("其他补助") / (GetBudgetData("其他补助") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("其他补助") * 10000 - GetBudgetDataTatol("其他补助") != 0)
    //    {
    //        dr21["column6"] = GetBudgetData("其他补助") * 10000 - GetBudgetDataTatol("其他补助");
    //    }
    //    dt.Rows.Add(dr21);

    //    DataRow dr22 = dt.NewRow();
    //    dr22["column1"] = "（三）日常公用支出";
    //    dr22["column2"] = dc3;
    //    if (dc33 != 0)
    //    {
    //        dr22["column3"] = (dc33).ToString("f2");
    //    }
    //    if (dc333 != 0)
    //    {
    //        dr22["column4"] = (dc333).ToString("f2");
    //    }
    //    if (common.IntSafeConvert(dr3["column2"]) != 0)
    //    {
    //        dr22["column5"] = ((dc333 / (dc3 * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    dr22["column6"] = dc3 * 10000 - dc333;
    //    dt.Rows.Add(dr22);

    //    DataRow dr23 = dt.NewRow();
    //    dr23["column1"] = "办公费";
    //    if (GetBudgetData("办公费") != 0)
    //    {
    //        dr23["column2"] = GetBudgetData("办公费");
    //    }
    //    if (GetBudgetDataThis("办公费") != 0)
    //    {
    //        dr23["column3"] = (GetBudgetDataThis("办公费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("办公费") != 0)
    //    {
    //        dr23["column4"] = (GetBudgetDataTatol("办公费")).ToString("f2");
    //    }
    //    if (GetBudgetData("办公费") != 0)
    //    {
    //        dr23["column5"] = ((GetBudgetDataTatol("办公费") / (GetBudgetData("办公费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("办公费") * 10000 - GetBudgetDataTatol("办公费") != 0)
    //    {
    //        dr23["column6"] = GetBudgetData("办公费") * 10000 - GetBudgetDataTatol("办公费");
    //    }
    //    dt.Rows.Add(dr23);

    //    DataRow dr24 = dt.NewRow();
    //    dr24["column1"] = "水电费";
    //    if (GetBudgetData("水电费") != 0)
    //    {
    //        dr24["column2"] = GetBudgetData("水电费");
    //    }
    //    if (GetBudgetDataThis("水电费") != 0)
    //    {
    //        dr24["column3"] = (GetBudgetDataThis("水电费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("水电费") != 0)
    //    {
    //        dr24["column4"] = (GetBudgetDataTatol("水电费")).ToString("f2");
    //    }
    //    if (GetBudgetData("水电费") != 0)
    //    {
    //        dr24["column5"] = ((GetBudgetDataTatol("水电费") / (GetBudgetData("水电费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("水电费") * 10000 - GetBudgetDataTatol("水电费") != 0)
    //    {
    //        dr24["column6"] = GetBudgetData("水电费") * 10000 - GetBudgetDataTatol("水电费");
    //    }
    //    dt.Rows.Add(dr24);

    //    DataRow dr25 = dt.NewRow();
    //    dr25["column1"] = "邮电费";
    //    if (GetBudgetData("邮电费") != 0)
    //    {
    //        dr25["column2"] = GetBudgetData("邮电费");
    //    }
    //    if (GetBudgetDataThis("邮电费") != 0)
    //    {
    //        dr25["column3"] = (GetBudgetDataThis("邮电费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("邮电费") != 0)
    //    {
    //        dr25["column4"] = (GetBudgetDataTatol("邮电费")).ToString("f2");
    //    }
    //    if (GetBudgetData("邮电费") != 0)
    //    {
    //        dr25["column5"] = ((GetBudgetDataTatol("邮电费") / (GetBudgetData("邮电费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("邮电费") * 10000 - GetBudgetDataTatol("邮电费") != 0)
    //    {
    //        dr25["column6"] = GetBudgetData("邮电费") * 10000 - GetBudgetDataTatol("邮电费");
    //    }
    //    dt.Rows.Add(dr25);

    //    DataRow dr26 = dt.NewRow();
    //    dr26["column1"] = "差旅费";
    //    if (GetBudgetData("差旅费") != 0)
    //    {
    //        dr26["column2"] = GetBudgetData("差旅费");
    //    }
    //    if (GetBudgetData("差旅费") != 0)
    //    {
    //        dr26["column3"] = (GetBudgetDataThis("差旅费")).ToString("f2");
    //    }
    //    if (GetBudgetData("差旅费") != 0)
    //    {
    //        dr26["column4"] = (GetBudgetDataTatol("差旅费")).ToString("f2");
    //    }
    //    if (GetBudgetData("差旅费") != 0)
    //    {
    //        dr26["column5"] = ((GetBudgetDataTatol("差旅费") / (GetBudgetData("差旅费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("差旅费") * 10000 - GetBudgetDataTatol("差旅费") != 0)
    //    {
    //        dr26["column6"] = GetBudgetData("差旅费") * 10000 - GetBudgetDataTatol("差旅费");
    //    }
    //    dt.Rows.Add(dr26);

    //    DataRow dr27 = dt.NewRow();
    //    dr27["column1"] = "印刷费";
    //    if (GetBudgetData("印刷费") != 0)
    //    {
    //        dr27["column2"] = GetBudgetData("印刷费");
    //    }
    //    if (GetBudgetDataThis("印刷费") != 0)
    //    {
    //        dr27["column3"] = (GetBudgetDataThis("印刷费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("印刷费") != 0)
    //    {
    //        dr27["column4"] = (GetBudgetDataTatol("印刷费")).ToString("f2");
    //    }
    //    if (GetBudgetData("印刷费") != 0)
    //    {
    //        dr27["column5"] = ((GetBudgetDataTatol("印刷费") / (GetBudgetData("印刷费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("印刷费") * 10000 - GetBudgetDataTatol("印刷费") != 0)
    //    {
    //        dr27["column6"] = GetBudgetData("印刷费") * 10000 - GetBudgetDataTatol("印刷费");
    //    }
    //    dt.Rows.Add(dr27);

    //    DataRow dr28 = dt.NewRow();
    //    dr28["column1"] = "福利费";
    //    if (GetBudgetData("福利费") != 0)
    //    {
    //        dr28["column2"] = GetBudgetData("福利费");
    //    }
    //    if (GetBudgetDataThis("福利费") != 0)
    //    {
    //        dr28["column3"] = (GetBudgetDataThis("福利费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("福利费") != 0)
    //    {
    //        dr28["column4"] = (GetBudgetDataTatol("福利费")).ToString("f2");
    //    }
    //    if (GetBudgetData("福利费") != 0)
    //    {
    //        dr28["column5"] = ((GetBudgetDataTatol("福利费") / (GetBudgetData("福利费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("福利费") * 10000 - GetBudgetDataTatol("福利费") != 0)
    //    {
    //        dr28["column6"] = GetBudgetData("福利费") * 10000 - GetBudgetDataTatol("福利费");
    //    }
    //    dt.Rows.Add(dr28);

    //    DataRow dr29 = dt.NewRow();
    //    dr29["column1"] = "一般培训费";
    //    if (GetBudgetData("一般培训费") != 0)
    //    {
    //        dr29["column2"] = GetBudgetData("一般培训费");
    //    }
    //    if (GetBudgetDataThis("一般培训费") != 0)
    //    {
    //        dr29["column3"] = (GetBudgetDataThis("一般培训费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("一般培训费") != 0)
    //    {
    //        dr29["column4"] = (GetBudgetDataTatol("一般培训费")).ToString("f2");
    //    }
    //    if (GetBudgetData("一般培训费") != 0)
    //    {
    //        dr29["column5"] = ((GetBudgetDataTatol("一般培训费") / (GetBudgetData("一般培训费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("一般培训费") * 10000 - GetBudgetDataTatol("一般培训费") != 0)
    //    {
    //        dr29["column6"] = GetBudgetData("一般培训费") * 10000 - GetBudgetDataTatol("一般培训费");
    //    }
    //    dt.Rows.Add(dr29);

    //    DataRow dr30 = dt.NewRow();
    //    dr30["column1"] = "一般会议费";
    //    if (GetBudgetData("一般会议费") != 0)
    //    {
    //        dr30["column2"] = GetBudgetData("一般会议费");
    //    }
    //    if (GetBudgetDataThis("一般会议费") != 0)
    //    {
    //        dr30["column3"] = (GetBudgetDataThis("一般会议费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("一般会议费") != 0)
    //    {
    //        dr30["column4"] = (GetBudgetDataTatol("一般会议费")).ToString("f2");
    //    }
    //    if (GetBudgetData("一般会议费") != 0)
    //    {
    //        dr30["column5"] = ((GetBudgetDataTatol("一般会议费") / (GetBudgetData("一般会议费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("一般会议费") * 10000 - GetBudgetDataTatol("一般培训费") != 0)
    //    {
    //        dr30["column6"] = GetBudgetData("一般会议费") * 10000 - GetBudgetDataTatol("一般会议费");
    //    }
    //    dt.Rows.Add(dr30);

    //    DataRow dr31 = dt.NewRow();
    //    dr31["column1"] = "一般设备购置费";
    //    if (GetBudgetData("一般设备购置费") != 0)
    //    {
    //        dr31["column2"] = GetBudgetData("一般设备购置费");
    //    }
    //    if (GetBudgetDataThis("一般设备购置费") != 0)
    //    {
    //        dr31["column3"] = (GetBudgetDataThis("一般设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("一般设备购置费") != 0)
    //    {
    //        dr31["column4"] = (GetBudgetDataTatol("一般设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetData("一般设备购置费") != 0)
    //    {
    //        dr31["column5"] = ((GetBudgetDataTatol("一般设备购置费") / (GetBudgetData("一般设备购置费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("一般设备购置费") * 10000 - GetBudgetDataTatol("一般设备购置费") != 0)
    //    {
    //        dr31["column6"] = GetBudgetData("一般设备购置费") * 10000 - GetBudgetDataTatol("一般设备购置费");
    //    }
    //    dt.Rows.Add(dr31);

    //    DataRow dr32 = dt.NewRow();
    //    dr32["column1"] = "日常维修费";
    //    if (GetBudgetData("日常维修费") != 0)
    //    {
    //        dr32["column2"] = GetBudgetData("日常维修费");
    //    }
    //    if (GetBudgetDataThis("日常维修费") != 0)
    //    {
    //        dr32["column3"] = (GetBudgetDataThis("日常维修费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("日常维修费") != 0)
    //    {
    //        dr32["column4"] = (GetBudgetDataTatol("日常维修费")).ToString("f2");
    //    }
    //    if (GetBudgetData("日常维修费") != 0)
    //    {
    //        dr32["column5"] = ((GetBudgetDataTatol("日常维修费") / (GetBudgetData("日常维修费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("日常维修费") * 10000 - GetBudgetDataTatol("日常维修费") != 0)
    //    {
    //        dr32["column6"] = GetBudgetData("日常维修费") * 10000 - GetBudgetDataTatol("日常维修费");
    //    }
    //    dt.Rows.Add(dr32);

    //    DataRow dr33 = dt.NewRow();
    //    dr33["column1"] = "物业管理费";
    //    if (GetBudgetData("物业管理费") != 0)
    //    {
    //        dr33["column2"] = GetBudgetData("物业管理费");
    //    }
    //    if (GetBudgetDataThis("物业管理费") != 0)
    //    {
    //        dr33["column3"] = (GetBudgetDataThis("物业管理费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("物业管理费") != 0)
    //    {
    //        dr33["column4"] = (GetBudgetDataTatol("物业管理费")).ToString("f2");
    //    }
    //    if (GetBudgetData("物业管理费") != 0)
    //    {
    //        dr33["column5"] = ((GetBudgetDataTatol("物业管理费") / (GetBudgetData("物业管理费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("物业管理费") * 10000 - GetBudgetDataTatol("物业管理费") != 0)
    //    {
    //        dr33["column6"] = GetBudgetData("物业管理费") * 10000 - GetBudgetDataTatol("物业管理费");
    //    }
    //    dt.Rows.Add(dr33);

    //    DataRow dr34 = dt.NewRow();
    //    dr34["column1"] = "交通费";
    //    if (GetBudgetData("交通费") != 0)
    //    {
    //        dr34["column2"] = GetBudgetData("交通费");
    //    }
    //    if (GetBudgetData("交通费") != 0)
    //    {
    //        dr34["column3"] = (GetBudgetDataThis("交通费")).ToString("f2");
    //    }
    //    if (GetBudgetData("交通费") != 0)
    //    {
    //        dr34["column4"] = (GetBudgetDataTatol("交通费")).ToString("f2");
    //    }
    //    if (GetBudgetData("交通费") != 0)
    //    {
    //        dr34["column5"] = ((GetBudgetDataTatol("交通费") / (GetBudgetData("交通费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("交通费") * 10000 - GetBudgetDataTatol("交通费") != 0)
    //    {
    //        dr34["column6"] = GetBudgetData("交通费") * 10000 - GetBudgetDataTatol("交通费");
    //    }
    //    dt.Rows.Add(dr34);

    //    DataRow dr35 = dt.NewRow();
    //    dr35["column1"] = "其中（1）车燃费";
    //    dt.Rows.Add(dr35);
    //    DataRow dr36 = dt.NewRow();
    //    dr36["column1"] = "（2）车修费";
    //    dt.Rows.Add(dr36);
    //    DataRow dr37 = dt.NewRow();
    //    dr37["column1"] = "（3）汽车保险费";
    //    dt.Rows.Add(dr37);
    //    DataRow dr38 = dt.NewRow();
    //    dr38["column1"] = "（4）过路过桥费";
    //    dt.Rows.Add(dr38);
    //    DataRow dr39 = dt.NewRow();
    //    dr39["column1"] = "（5）其他";
    //    dt.Rows.Add(dr39);

    //    DataRow dr40 = dt.NewRow();
    //    dr40["column1"] = "工会经费";
    //    if (GetBudgetData("工会经费") != 0)
    //    {
    //        dr40["column2"] = GetBudgetData("工会经费");
    //    }
    //    if (GetBudgetDataThis("工会经费") != 0)
    //    {
    //        dr40["column3"] = (GetBudgetDataThis("工会经费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("工会经费") != 0)
    //    {
    //        dr40["column4"] = (GetBudgetDataTatol("工会经费")).ToString("f2");
    //    }
    //    if (GetBudgetData("工会经费") != 0)
    //    {
    //        dr40["column5"] = ((GetBudgetDataTatol("工会经费") / (GetBudgetData("工会经费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("工会经费") * 10000 - GetBudgetDataTatol("工会经费") != 0)
    //    {
    //        dr40["column6"] = GetBudgetData("工会经费") * 10000 - GetBudgetDataTatol("工会经费");
    //    }
    //    dt.Rows.Add(dr40);

    //    DataRow dr41 = dt.NewRow();
    //    dr41["column1"] = "招待费";
    //    if (GetBudgetData("招待费") != 0)
    //    {
    //        dr41["column2"] = GetBudgetData("招待费");
    //    }
    //    if (GetBudgetDataThis("招待费") != 0)
    //    {
    //        dr41["column3"] = (GetBudgetDataThis("招待费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("招待费") != 0)
    //    {
    //        dr41["column4"] = (GetBudgetDataTatol("招待费")).ToString("f2");
    //    }
    //    if (GetBudgetData("招待费") != 0)
    //    {
    //        dr41["column5"] = ((GetBudgetDataTatol("招待费") / (GetBudgetData("招待费") * 10000)) * 100).ToString("f2") + "%";

    //    }
    //    if (GetBudgetData("招待费") * 10000 - GetBudgetDataTatol("招待费") != 0)
    //    {
    //        dr41["column6"] = GetBudgetData("招待费") * 10000 - GetBudgetDataTatol("招待费");
    //    }
    //    dt.Rows.Add(dr41);

    //    DataRow dr42 = dt.NewRow();
    //    dr42["column1"] = "其他费用";
    //    if (GetBudgetData("其他费用") != 0)
    //    {
    //        dr42["column2"] = GetBudgetData("其他费用");
    //    }
    //    if (GetBudgetDataThis("其他费用") != 0)
    //    {
    //        dr42["column3"] = (GetBudgetDataThis("其他费用")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("其他费用") != 0)
    //    {
    //        dr42["column4"] = (GetBudgetDataTatol("其他费用")).ToString("f2");
    //    }
    //    if (GetBudgetData("其他费用") != 0)
    //    {
    //        dr42["column5"] = ((GetBudgetDataTatol("其他费用") / (GetBudgetData("其他费用") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("其他费用") * 10000 - GetBudgetDataTatol("其他费用") != 0)
    //    {
    //        dr42["column6"] = GetBudgetData("其他费用") * 10000 - GetBudgetDataTatol("其他费用");
    //    }
    //    dt.Rows.Add(dr42);

    //    DataRow dr43 = dt.NewRow();
    //    dr43["column1"] = "二、项目支出合计";
    //    dr43["column2"] = dc4;
    //    if (dc44 != 0)
    //    {
    //        dr43["column3"] = (dc44).ToString("f2");
    //    }
    //    if (dc444 != 0)
    //    {
    //        dr43["column4"] = (dc444).ToString("f2");
    //    }
    //    if (dc4 != 0)
    //    {
    //        dr43["column5"] = (dc444 / (dc4 * 10000) * 100).ToString("f2") + "%";
    //    }
    //    dr43["column6"] = dc4 * 10000 - dc444;
    //    dt.Rows.Add(dr43);

    //    DataRow dr44 = dt.NewRow();
    //    dr44["column1"] = "（一）专项项目支出";
    //    if (dc44 != 0)
    //    {
    //        dr43["column3"] = (dc44).ToString("f2");
    //    }
    //    if (dc444 != 0)
    //    {
    //        dr43["column4"] = (dc444).ToString("f2");
    //    }
    //    dr44["column4"] = dc444;
    //    if (dc4 != 0)
    //    {
    //        dr44["column5"] = (dc444 / (dc4 * 10000) * 100).ToString("f2") + "%";
    //    }
    //    dr44["column6"] = dc4 * 10000 - dc444;
    //    dt.Rows.Add(dr44);

    //    DataRow dr45 = dt.NewRow();
    //    dr45["column1"] = "计算机及设备购置费";
    //    if (GetBudgetData("计算机及设备购置费") != 0)
    //    {
    //        dr45["column2"] = GetBudgetData("计算机及设备购置费");
    //    }
    //    if (GetBudgetDataThis("计算机及设备购置费") != 0)
    //    {
    //        dr45["column3"] = (GetBudgetDataThis("计算机及设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("计算机及设备购置费") != 0)
    //    {
    //        dr45["column4"] = (GetBudgetDataTatol("计算机及设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetData("计算机及设备购置费") != 0)
    //    {
    //        dr45["column5"] = ((GetBudgetDataTatol("计算机及设备购置费") / (GetBudgetData("计算机及设备购置费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("计算机及设备购置费") * 10000 - GetBudgetDataTatol("计算机及设备购置费") != 0)
    //    {
    //        dr45["column6"] = GetBudgetData("计算机及设备购置费") * 10000 - GetBudgetDataTatol("计算机及设备购置费");
    //    }
    //    dt.Rows.Add(dr45);

    //    DataRow dr46 = dt.NewRow();
    //    dr46["column1"] = "办公设备购置费";
    //    if (GetBudgetData("办公设备购置费") != 0)
    //    {
    //        dr46["column2"] = GetBudgetData("办公设备购置费");
    //    }
    //    if (GetBudgetDataThis("办公设备购置费") != 0)
    //    {
    //        dr46["column3"] = (GetBudgetDataThis("办公设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("办公设备购置费") != 0)
    //    {
    //        dr46["column4"] = (GetBudgetDataTatol("办公设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetData("办公设备购置费") != 0)
    //    {
    //        dr46["column5"] = ((GetBudgetDataTatol("办公设备购置费") / (GetBudgetData("办公设备购置费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("办公设备购置费") * 10000 - GetBudgetDataTatol("办公设备购置费") != 0)
    //    {
    //        dr46["column6"] = GetBudgetData("办公设备购置费") * 10000 - GetBudgetDataTatol("办公设备购置费");
    //    }
    //    dt.Rows.Add(dr46);

    //    DataRow dr47 = dt.NewRow();
    //    dr47["column1"] = "图书资料购置费";
    //    if (GetBudgetData("图书资料购置费") != 0)
    //    {
    //        dr47["column2"] = GetBudgetData("图书资料购置费");
    //    }
    //    if (GetBudgetDataThis("图书资料购置费") != 0)
    //    {
    //        dr47["column3"] = (GetBudgetDataThis("图书资料购置费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("图书资料购置费") != 0)
    //    {
    //        dr47["column4"] = (GetBudgetDataTatol("图书资料购置费")).ToString("f2");
    //    }
    //    if (GetBudgetData("图书资料购置费") != 0)
    //    {
    //        dr47["column5"] = ((GetBudgetDataTatol("图书资料购置费") / (GetBudgetData("图书资料购置费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("图书资料购置费") * 10000 - GetBudgetDataTatol("图书资料购置费") != 0)
    //    {
    //        dr47["column6"] = GetBudgetData("图书资料购置费") * 10000 - GetBudgetDataTatol("图书资料购置费");
    //    }
    //    dt.Rows.Add(dr47);

    //    DataRow dr48 = dt.NewRow();
    //    dr48["column1"] = "其他设备购置费";
    //    if (GetBudgetData("其他设备购置费") != 0)
    //    {
    //        dr48["column2"] = GetBudgetData("其他设备购置费");
    //    }
    //    if (GetBudgetDataThis("其他设备购置费") != 0)
    //    {
    //        dr48["column3"] = (GetBudgetDataThis("其他设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("其他设备购置费") != 0)
    //    {
    //        dr48["column4"] = (GetBudgetDataTatol("其他设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetData("其他设备购置费") != 0)
    //    {
    //        dr48["column5"] = ((GetBudgetDataTatol("其他设备购置费") / (GetBudgetData("其他设备购置费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("其他设备购置费") * 10000 - GetBudgetDataTatol("其他设备购置费") != 0)
    //    {
    //        dr48["column6"] = GetBudgetData("其他设备购置费") * 10000 - GetBudgetDataTatol("其他设备购置费");
    //    }
    //    dt.Rows.Add(dr48);

    //    DataRow dr49 = dt.NewRow();
    //    dr49["column1"] = "交通设备购置费";
    //    if (GetBudgetData("交通设备购置费") != 0)
    //    {
    //        dr49["column2"] = GetBudgetData("交通设备购置费");
    //    }
    //    if (GetBudgetDataThis("交通设备购置费") != 0)
    //    {
    //        dr49["column3"] = (GetBudgetDataThis("交通设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("交通设备购置费") != 0)
    //    {
    //        dr49["column4"] = (GetBudgetDataTatol("交通设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetData("交通设备购置费") != 0)
    //    {
    //        dr49["column5"] = ((GetBudgetDataTatol("交通设备购置费") / (GetBudgetData("交通设备购置费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("交通设备购置费") * 10000 - GetBudgetDataTatol("交通设备购置费") != 0)
    //    {
    //        dr49["column6"] = GetBudgetData("交通设备购置费") * 10000 - GetBudgetDataTatol("交通设备购置费");
    //    }
    //    dt.Rows.Add(dr49);

    //    DataRow dr50 = dt.NewRow();
    //    dr50["column1"] = "大型会议费";
    //    if (GetBudgetData("大型会议费") != 0)
    //    {
    //        dr50["column2"] = GetBudgetData("大型会议费");
    //    }
    //    if (GetBudgetDataThis("大型会议费") != 0)
    //    {
    //        dr50["column3"] = (GetBudgetDataThis("大型会议费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("大型会议费") != 0)
    //    {
    //        dr50["column4"] = (GetBudgetDataTatol("大型会议费")).ToString("f2");
    //    }
    //    if (GetBudgetData("大型会议费") != 0)
    //    {
    //        dr50["column5"] = ((GetBudgetDataTatol("大型会议费") / (GetBudgetData("大型会议费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("大型会议费") * 10000 - GetBudgetDataTatol("大型会议费") != 0)
    //    {
    //        dr50["column6"] = GetBudgetData("大型会议费") * 10000 - GetBudgetDataTatol("大型会议费");
    //    }
    //    dt.Rows.Add(dr50);

    //    DataRow dr51 = dt.NewRow();
    //    dr51["column1"] = "大型修缮费";
    //    if (GetBudgetData("大型修缮费") != 0)
    //    {
    //        dr51["column2"] = GetBudgetData("大型修缮费");
    //    }
    //    if (GetBudgetDataThis("大型修缮费") != 0)
    //    {
    //        dr51["column3"] = (GetBudgetDataThis("大型修缮费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("大型修缮费") != 0)
    //    {
    //        dr51["column4"] = (GetBudgetDataTatol("大型修缮费")).ToString("f2");
    //    }
    //    if (GetBudgetData("大型修缮费") != 0)
    //    {
    //        dr51["column5"] = ((GetBudgetDataTatol("大型修缮费") / (GetBudgetData("大型修缮费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("大型修缮费") * 10000 - GetBudgetDataTatol("大型修缮费") != 0)
    //    {
    //        dr51["column6"] = GetBudgetData("大型修缮费") * 10000 - GetBudgetDataTatol("大型修缮费");
    //    }
    //    dt.Rows.Add(dr51);

    //    DataRow dr52 = dt.NewRow();
    //    dr52["column1"] = "业务费";
    //    if (GetBudgetData("业务费") != 0)
    //    {
    //        dr52["column2"] = GetBudgetData("业务费");
    //    }
    //    if (GetBudgetDataThis("业务费") != 0)
    //    {
    //        dr52["column3"] = (GetBudgetDataThis("业务费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("业务费") != 0)
    //    {
    //        dr52["column4"] = (GetBudgetDataTatol("业务费")).ToString("f2");
    //    }
    //    if (GetBudgetData("业务费") != 0)
    //    {
    //        dr52["column5"] = ((GetBudgetDataTatol("业务费") / (GetBudgetData("业务费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("业务费") * 10000 - GetBudgetDataTatol("业务费") != 0)
    //    {
    //        dr52["column6"] = GetBudgetData("业务费") * 10000 - GetBudgetDataTatol("业务费");
    //    }
    //    dt.Rows.Add(dr52);

    //    DataRow dr53 = dt.NewRow();
    //    dr53["column1"] = "（1）税法宣传费";
    //    if (GetBudgetData("税法宣传费") != 0)
    //    {
    //        dr53["column2"] = GetBudgetData("税法宣传费");
    //    }
    //    if (GetBudgetDataThis("税法宣传费") != 0)
    //    {
    //        dr53["column3"] = (GetBudgetDataThis("税法宣传费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("税法宣传费") != 0)
    //    {
    //        dr53["column4"] = (GetBudgetDataTatol("税法宣传费")).ToString("f2");
    //    }
    //    if (GetBudgetData("税法宣传费") != 0)
    //    {
    //        dr53["column5"] = ((GetBudgetDataTatol("税法宣传费") / (GetBudgetData("税法宣传费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("税法宣传费") * 10000 - GetBudgetDataTatol("税法宣传费") != 0)
    //    {
    //        dr53["column6"] = GetBudgetData("税法宣传费") * 10000 - GetBudgetDataTatol("税法宣传费");
    //    }
    //    dt.Rows.Add(dr53);

    //    DataRow dr54 = dt.NewRow();
    //    dr54["column1"] = "（2）出国经费";
    //    if (GetBudgetData("出国经费") != 0)
    //    {
    //        dr54["column2"] = GetBudgetData("出国经费");
    //    }
    //    if (GetBudgetDataThis("出国经费") != 0)
    //    {
    //        dr54["column3"] = (GetBudgetDataThis("出国经费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("出国经费") != 0)
    //    {
    //        dr54["column4"] = (GetBudgetDataTatol("出国经费")).ToString("f2");
    //    }
    //    if (GetBudgetData("出国经费") != 0)
    //    {
    //        dr54["column5"] = ((GetBudgetDataTatol("出国经费") / (GetBudgetData("出国经费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("出国经费") * 10000 - GetBudgetDataTatol("出国经费") != 0)
    //    {
    //        dr54["column6"] = GetBudgetData("出国经费") * 10000 - GetBudgetDataTatol("出国经费");
    //    }
    //    dt.Rows.Add(dr54);

    //    DataRow dr55 = dt.NewRow();
    //    dr55["column1"] = "（3）专项培训费";
    //    if (GetBudgetData("专项培训费") != 0)
    //    {
    //        dr55["column2"] = GetBudgetData("专项培训费");
    //    }
    //    if (GetBudgetDataThis("专项培训费") != 0)
    //    {
    //        dr55["column3"] = (GetBudgetDataThis("专项培训费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("专项培训费") != 0)
    //    {
    //        dr55["column4"] = (GetBudgetDataTatol("专项培训费")).ToString("f2");
    //    }
    //    if (GetBudgetData("专项培训费") != 0)
    //    {
    //        dr55["column5"] = ((GetBudgetDataTatol("专项培训费") / (GetBudgetData("专项培训费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("专项培训费") * 10000 - GetBudgetDataTatol("专项培训费") != 0)
    //    {
    //        dr55["column6"] = GetBudgetData("专项培训费") * 10000 - GetBudgetDataTatol("专项培训费");
    //    }
    //    dt.Rows.Add(dr55);

    //    DataRow dr56 = dt.NewRow();
    //    dr56["column1"] = "（4）协税费";
    //    if (GetBudgetData("协税费") != 0)
    //    {
    //        dr56["column2"] = GetBudgetData("协税费");
    //    }
    //    if (GetBudgetDataThis("协税费") != 0)
    //    {
    //        dr56["column3"] = (GetBudgetDataThis("协税费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("协税费") != 0)
    //    {
    //        dr56["column4"] = (GetBudgetDataTatol("协税费")).ToString("f2");
    //    }
    //    if (GetBudgetData("协税费") != 0)
    //    {
    //        dr56["column5"] = ((GetBudgetDataTatol("协税费") / (GetBudgetData("协税费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("协税费") * 10000 - GetBudgetDataTatol("协税费") != 0)
    //    {
    //        dr56["column6"] = GetBudgetData("协税费") * 10000 - GetBudgetDataTatol("协税费");
    //    }
    //    dt.Rows.Add(dr56);

    //    DataRow dr57 = dt.NewRow();
    //    dr57["column1"] = "（5）联合办案费";
    //    if (GetBudgetData("联合办案费") != 0)
    //    {
    //        dr57["column2"] = GetBudgetData("联合办案费");
    //    }
    //    if (GetBudgetDataThis("联合办案费") != 0)
    //    {
    //        dr57["column3"] = (GetBudgetDataThis("联合办案费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("联合办案费") != 0)
    //    {
    //        dr57["column4"] = (GetBudgetDataTatol("联合办案费")).ToString("f2");
    //    }
    //    if (GetBudgetData("联合办案费") != 0)
    //    {
    //        dr57["column5"] = ((GetBudgetDataTatol("联合办案费") / (GetBudgetData("联合办案费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("联合办案费") * 10000 - GetBudgetDataTatol("联合办案费") != 0)
    //    {
    //        dr57["column6"] = GetBudgetData("联合办案费") * 10000 - GetBudgetDataTatol("联合办案费");
    //    }
    //    dt.Rows.Add(dr57);

    //    DataRow dr58 = dt.NewRow();
    //    dr58["column1"] = "（6）党团活动费";
    //    if (GetBudgetData("党团活动费") != 0)
    //    {
    //        dr58["column2"] = GetBudgetData("党团活动费");
    //    }
    //    if (GetBudgetDataThis("党团活动费") != 0)
    //    {
    //        dr58["column3"] = (GetBudgetDataThis("党团活动费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("党团活动费") != 0)
    //    {
    //        dr58["column4"] = (GetBudgetDataTatol("党团活动费")).ToString("f2");
    //    }
    //    if (GetBudgetData("党团活动费") != 0)
    //    {
    //        dr58["column5"] = ((GetBudgetDataTatol("党团活动费") / (GetBudgetData("党团活动费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("党团活动费") * 10000 - GetBudgetDataTatol("党团活动费") != 0)
    //    {
    //        dr58["column6"] = GetBudgetData("党团活动费") * 10000 - GetBudgetDataTatol("党团活动费");
    //    }
    //    dt.Rows.Add(dr58);

    //    DataRow dr59 = dt.NewRow();
    //    dr59["column1"] = "交通设备购置费";
    //    if (GetBudgetData("交通设备购置费") != 0)
    //    {
    //        dr59["column2"] = GetBudgetData("交通设备购置费");
    //    }
    //    if (GetBudgetDataThis("交通设备购置费") != 0)
    //    {
    //        dr59["column3"] = (GetBudgetDataThis("交通设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("交通设备购置费") != 0)
    //    {
    //        dr59["column4"] = (GetBudgetDataTatol("交通设备购置费")).ToString("f2");
    //    }
    //    if (GetBudgetData("交通设备购置费") != 0)
    //    {
    //        dr59["column5"] = ((GetBudgetDataTatol("交通设备购置费") / (GetBudgetData("交通设备购置费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("交通设备购置费") * 10000 - GetBudgetDataTatol("交通设备购置费") != 0)
    //    {
    //        dr59["column6"] = GetBudgetData("交通设备购置费") * 10000 - GetBudgetDataTatol("交通设备购置费");
    //    }
    //    dt.Rows.Add(dr59);

    //    DataRow dr60 = dt.NewRow();
    //    dr60["column1"] = "（7）专项印刷费";
    //    if (GetBudgetData("专项印刷费") != 0)
    //    {
    //        dr60["column2"] = GetBudgetData("专项印刷费");
    //    }
    //    if (GetBudgetDataThis("专项印刷费") != 0)
    //    {
    //        dr60["column3"] = (GetBudgetDataThis("专项印刷费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("专项印刷费") != 0)
    //    {
    //        dr60["column4"] = (GetBudgetDataTatol("专项印刷费")).ToString("f2");
    //    }
    //    if (GetBudgetData("专项印刷费") != 0)
    //    {
    //        dr60["column5"] = ((GetBudgetDataTatol("专项印刷费") / (GetBudgetData("专项印刷费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("专项印刷费") * 10000 - GetBudgetDataTatol("专项印刷费") != 0)
    //    {
    //        dr60["column6"] = GetBudgetData("专项印刷费") * 10000 - GetBudgetDataTatol("专项印刷费");
    //    }
    //    dt.Rows.Add(dr60);

    //    DataRow dr61 = dt.NewRow();
    //    dr61["column1"] = "（8）工会经费";
    //    if (GetBudgetData("工会经费") != 0)
    //    {
    //        dr61["column2"] = GetBudgetData("工会经费");
    //    }
    //    if (GetBudgetDataThis("工会经费") != 0)
    //    {
    //        dr61["column3"] = (GetBudgetDataThis("工会经费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("工会经费") != 0)
    //    {
    //        dr61["column4"] = (GetBudgetDataTatol("工会经费")).ToString("f2");
    //    }
    //    if (GetBudgetData("工会经费") != 0)
    //    {
    //        dr61["column5"] = ((GetBudgetDataTatol("工会经费") / (GetBudgetData("工会经费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("工会经费") * 10000 - GetBudgetDataTatol("工会经费") != 0)
    //    {
    //        dr61["column6"] = GetBudgetData("工会经费") * 10000 - GetBudgetDataTatol("工会经费");
    //    }
    //    dt.Rows.Add(dr61);

    //    DataRow dr62 = dt.NewRow();
    //    dr62["column1"] = "（9）服装费";
    //    if (GetBudgetData("服装费") != 0)
    //    {
    //        dr62["column2"] = GetBudgetData("服装费");
    //    }
    //    if (GetBudgetDataThis("服装费") != 0)
    //    {
    //        dr62["column3"] = (GetBudgetDataThis("服装费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("服装费") != 0)
    //    {
    //        dr62["column4"] = (GetBudgetDataTatol("服装费")).ToString("f2");
    //    }
    //    if (GetBudgetData("服装费") != 0)
    //    {
    //        dr62["column5"] = ((GetBudgetDataTatol("服装费") / (GetBudgetData("服装费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("服装费") * 10000 - GetBudgetDataTatol("服装费") != 0)
    //    {
    //        dr62["column6"] = GetBudgetData("服装费") * 10000 - GetBudgetDataTatol("服装费");
    //    }
    //    dt.Rows.Add(dr62);

    //    DataRow dr63 = dt.NewRow();
    //    dr63["column1"] = "（10）妇代会";
    //    if (GetBudgetData("妇代会") != 0)
    //    {
    //        dr63["column2"] = GetBudgetData("妇代会");
    //    }
    //    if (GetBudgetDataThis("妇代会") != 0)
    //    {
    //        dr63["column3"] = (GetBudgetDataThis("妇代会")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("妇代会") != 0)
    //    {
    //        dr63["column4"] = (GetBudgetDataTatol("妇代会")).ToString("f2");
    //    }
    //    if (GetBudgetData("妇代会") != 0)
    //    {
    //        dr63["column5"] = ((GetBudgetDataTatol("妇代会") / (GetBudgetData("妇代会") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("妇代会") * 10000 - GetBudgetDataTatol("妇代会") != 0)
    //    {
    //        dr63["column6"] = GetBudgetData("妇代会") * 10000 - GetBudgetDataTatol("妇代会");
    //    }
    //    dt.Rows.Add(dr63);

    //    DataRow dr64 = dt.NewRow();
    //    dr64["column1"] = "（11）发票经费";
    //    if (GetBudgetData("发票经费") != 0)
    //    {
    //        dr64["column2"] = (GetBudgetData("发票经费")).ToString("f2");
    //    }
    //    if (GetBudgetDataThis("发票经费") != 0)
    //    {
    //        dr64["column3"] = (GetBudgetDataThis("发票经费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("发票经费") != 0)
    //    {
    //        dr64["column4"] = GetBudgetDataTatol("发票经费");
    //    }
    //    if (GetBudgetData("发票经费") != 0)
    //    {
    //        dr64["column5"] = ((GetBudgetDataTatol("发票经费") / (GetBudgetData("发票经费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("发票经费") * 10000 - GetBudgetDataTatol("发票经费") != 0)
    //    {
    //        dr64["column6"] = GetBudgetData("发票经费") * 10000 - GetBudgetDataTatol("发票经费");
    //    }
    //    dt.Rows.Add(dr64);

    //    DataRow dr65 = dt.NewRow();
    //    dr65["column1"] = "（12）征管业务费";
    //    if (GetBudgetData("征管业务费") != 0)
    //    {
    //        dr65["column2"] = GetBudgetData("征管业务费");
    //    }
    //    if (GetBudgetDataThis("征管业务费") != 0)
    //    {
    //        dr65["column3"] = (GetBudgetDataThis("征管业务费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("征管业务费") != 0)
    //    {
    //        dr65["column4"] = (GetBudgetDataTatol("征管业务费")).ToString("f2");
    //    }
    //    if (GetBudgetData("征管业务费") != 0)
    //    {
    //        dr65["column5"] = ((GetBudgetDataTatol("征管业务费") / (GetBudgetData("征管业务费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("征管业务费") * 10000 - GetBudgetDataTatol("征管业务费") != 0)
    //    {
    //        dr65["column6"] = GetBudgetData("征管业务费") * 10000 - GetBudgetDataTatol("征管业务费");
    //    }
    //    dt.Rows.Add(dr65);

    //    DataRow dr66 = dt.NewRow();
    //    dr66["column1"] = "（13）计算机应用经费";
    //    if (GetBudgetData("计算机应用经费") != 0)
    //    {
    //        dr66["column2"] = GetBudgetData("计算机应用经费");
    //    }
    //    if (GetBudgetDataThis("计算机应用经费") != 0)
    //    {
    //        dr66["column3"] = (GetBudgetDataThis("计算机应用经费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("计算机应用经费") != 0)
    //    {
    //        dr66["column4"] = (GetBudgetDataTatol("计算机应用经费")).ToString("f2");
    //    }
    //    if (GetBudgetData("计算机应用经费") != 0)
    //    {
    //        dr66["column5"] = ((GetBudgetDataTatol("计算机应用经费") / (GetBudgetData("计算机应用经费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("计算机应用经费") * 10000 - GetBudgetDataTatol("计算机应用经费") != 0)
    //    {
    //        dr66["column6"] = GetBudgetData("计算机应用经费") * 10000 - GetBudgetDataTatol("计算机应用经费");
    //    }
    //    dt.Rows.Add(dr66);

    //    DataRow dr67 = dt.NewRow();
    //    dr67["column1"] = "（14）“三代”手续费支出";
    //    if (GetBudgetData("“三代”手续费支出") != 0)
    //    {
    //        dr67["column2"] = GetBudgetData("“三代”手续费支出");
    //    }
    //    if (GetBudgetDataThis("“三代”手续费支出") != 0)
    //    {
    //        dr67["column3"] = (GetBudgetDataThis("“三代”手续费支出")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("“三代”手续费支出") != 0)
    //    {
    //        dr67["column4"] = (GetBudgetDataTatol("“三代”手续费支出")).ToString("f2");
    //    }
    //    if (GetBudgetData("“三代”手续费支出") != 0)
    //    {
    //        dr67["column5"] = ((GetBudgetDataTatol("“三代”手续费支出") / (GetBudgetData("“三代”手续费支出") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("“三代”手续费支出") * 10000 - GetBudgetDataTatol("“三代”手续费支出") != 0)
    //    {
    //        dr67["column6"] = GetBudgetData("“三代”手续费支出") * 10000 - GetBudgetDataTatol("“三代”手续费支出");
    //    }
    //    dt.Rows.Add(dr67);

    //    DataRow dr68 = dt.NewRow();
    //    dr68["column1"] = "（15）其他";
    //    if (GetBudgetData("其他") != 0)
    //    {
    //        dr68["column2"] = GetBudgetData("其他");
    //    }
    //    if (GetBudgetDataThis("其他") != 0)
    //    {
    //        dr68["column3"] = (GetBudgetDataThis("其他")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("其他") != 0)
    //    {
    //        dr68["column4"] = (GetBudgetDataTatol("其他")).ToString("f2");
    //    }
    //    if (GetBudgetData("其他") != 0)
    //    {
    //        dr68["column5"] = ((GetBudgetDataTatol("其他") / (GetBudgetData("其他") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("其他") * 10000 - GetBudgetDataTatol("其他") != 0)
    //    {
    //        dr68["column6"] = GetBudgetData("其他") * 10000 - GetBudgetDataTatol("其他");
    //    }
    //    dt.Rows.Add(dr68);

    //    DataRow dr69 = dt.NewRow();
    //    dr69["column1"] = "专项公用经费";
    //    if (GetBudgetData("专项公用经费") != 0)
    //    {
    //        dr69["column2"] = GetBudgetData("专项公用经费");
    //    }
    //    if (GetBudgetDataThis("专项公用经费") != 0)
    //    {
    //        dr69["column3"] = (GetBudgetDataThis("专项公用经费")).ToString("f2");
    //    }
    //    if (GetBudgetDataTatol("专项公用经费") != 0)
    //    {
    //        dr69["column4"] = (GetBudgetDataTatol("专项公用经费")).ToString("f2");
    //    }
    //    if (GetBudgetData("专项公用经费") != 0)
    //    {
    //        dr69["column5"] = ((GetBudgetDataTatol("专项公用经费") / (GetBudgetData("专项公用经费") * 10000)) * 100).ToString("f2") + "%";
    //    }
    //    if (GetBudgetData("专项公用经费") * 10000 - GetBudgetDataTatol("专项公用经费") != 0)
    //    {
    //        dr69["column6"] = GetBudgetData("专项公用经费") * 10000 - GetBudgetDataTatol("专项公用经费");
    //    }
    //    dt.Rows.Add(dr69);


    //    RepBugetTarget.DataSource = dt;
    //    RepBugetTarget.DataBind();
    //}

    private void AddDataRow(DataTable dt, string name1, string name,string type)
    {
        DataRow dr = dt.NewRow();
        dr["column1"] = name1;
        if (GetBudgetData(name,type) != 0)
        {
            dr["column2"] = (GetBudgetData(name, type)).ToString("f2");
        }
        if (GetBudgetDataThis(name, type) != 0)
        {
            dr["column3"] = (GetBudgetDataThis(name, type)).ToString("f2");
        }
        if (GetBudgetDataTatol(name, type) != 0)
        {
            dr["column4"] = (GetBudgetDataTatol(name, type)).ToString("f2");
        }
        if (GetBudgetData(name, type) != 0 && GetBudgetDataTatol(name, type)!=0)
        {
            dr["column5"] = (GetBudgetDataTatol(name, type) / (GetBudgetData(name, type) * 10000) * 100).ToString("f2") + "%";
        }
        if (GetBudgetData(name, type) * 10000 - GetBudgetDataTatol(name, type) != 0)
        {
            dr["column6"] = (GetBudgetData(name, type) * 10000 - GetBudgetDataTatol(name, type)).ToString("f2");
        }

        dt.Rows.Add(dr);
    }

    private void AddDataRow2(DataTable dt, string name1, string name, string type, int length)
    {
        DataRow dr = dt.NewRow();
        dr["column1"] = name1;
        if (GetBudgetData(name, type) != 0)
        {
            dr["column2"] = (GetBudgetData(name, type)).ToString("f2");
        }
        if (GetBudgetDataThisL(name, type, length) != 0)
        {
            dr["column3"] = (GetBudgetDataThisL(name, type, length)).ToString("f2");
        }
        if (GetBudgetDataTatolL(name, type, length) != 0)
        {
            dr["column4"] = (GetBudgetDataTatolL(name, type, length)).ToString("f2");
        }
        if (ToDec(dr["column4"]) != 0 && ToDec(dr["column2"]) != 0)
        {
            dr["column5"] = (ToDec(dr["column4"]) / (ToDec(dr["column2"]) * 10000) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr["column2"]) * 10000 - ToDec(dr["column4"]) != 0)
        {
            dr["column6"] = (ToDec(dr["column2"]) * 10000 - ToDec(dr["column4"])).ToString("f2");
        }

        dt.Rows.Add(dr);
    }

    private void AddDataRow1(DataTable dt, string name1, string name2, string name3, string name4, string type)
    {
        DataRow dr = dt.NewRow();
        dr["column1"] = name1;
        if (GetBudgetData(name2, type) + GetBudgetData(name3, type) + GetBudgetData(name4, type) != 0)
        {
            dr["column2"] = (GetBudgetData(name2, type) + GetBudgetData(name3, type) + GetBudgetData(name4, type)).ToString("f2");
        }
        if (GetBudgetDataThis(name2, type) + GetBudgetDataThis(name3, type) + GetBudgetDataThis(name4, type) != 0)
        {
            dr["column3"] = (GetBudgetDataThis(name2, type) + GetBudgetDataThis(name3, type) + GetBudgetDataThis(name4, type)).ToString("f2");
        }
        if (GetBudgetDataTatol(name2, type) + GetBudgetDataTatol(name3, type) + GetBudgetDataTatol(name4, type) != 0)
        {
            dr["column4"] = (GetBudgetDataTatol(name2, type) + GetBudgetDataTatol(name3, type) + GetBudgetDataTatol(name4, type)).ToString("f2");
        }
        if (ToDec(dr["column4"]) != 0 && ToDec(dr["column2"]) != 0)
        {
            dr["column5"] = (ToDec(dr["column4"]) / (ToDec(dr["column2"]) * 10000) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr["column2"]) * 10000 - ToDec(dr["column4"]) != 0)
        {
            dr["column6"] = (ToDec(dr["column2"]) * 10000 - ToDec(dr["column4"])).ToString("f2");
        }

        dt.Rows.Add(dr);
    }

    private void AddDataRow3(DataTable dt, string name1, string name2, string name3, string name4,string name5, string type)
    {
        DataRow dr = dt.NewRow();
        dr["column1"] = name1;
        if (GetBudgetData(name2, type) + GetBudgetData(name3, type) + GetBudgetData(name4, type) + GetBudgetData(name5, type) != 0)
        {
            dr["column2"] = (GetBudgetData(name2, type) + GetBudgetData(name3, type) + GetBudgetData(name4, type) + GetBudgetData(name5, type)).ToString("f2");
        }
        if (GetBudgetDataThis(name2, type) + GetBudgetDataThis(name3, type) + GetBudgetDataThis(name4, type) + GetBudgetDataThis(name5, type) != 0)
        {
            dr["column3"] = (GetBudgetDataThis(name2, type) + GetBudgetDataThis(name3, type) + GetBudgetDataThis(name4, type) + GetBudgetDataThis(name5, type)).ToString("f2");
        }
        if (GetBudgetDataTatol(name2, type) + GetBudgetDataTatol(name3, type) + GetBudgetDataTatol(name4, type) + GetBudgetDataTatol(name5, type) != 0)
        {
            dr["column4"] = (GetBudgetDataTatol(name2, type) + GetBudgetDataTatol(name3, type) + GetBudgetDataTatol(name4, type) + GetBudgetDataTatol(name5, type)).ToString("f2");
        }
        if (ToDec(dr["column4"]) != 0 && ToDec(dr["column2"]) != 0)
        {
            dr["column5"] = (ToDec(dr["column4"]) / (ToDec(dr["column2"]) * 10000) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr["column2"]) * 10000 - ToDec(dr["column4"]) != 0)
        {
            dr["column6"] = (ToDec(dr["column2"]) * 10000 - ToDec(dr["column4"])).ToString("f2");
        }

        dt.Rows.Add(dr);
    }

    private void BudgetDataBind()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Columns.Add("column3");
        dt.Columns.Add("column4");
        dt.Columns.Add("column5");
        dt.Columns.Add("column6");
        dt.Columns.Add("column7");

        GetRows(dt);
        RepBugetTarget.DataSource = dt;
        RepBugetTarget.DataBind();
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

    private void GetRows(DataTable dt)
    {
        decimal BudData1 = GetBudgetData("工资福利支出", "基本支出") + GetBudgetData("商品和服务支出", "基本支出") + GetBudgetData("对个人和家庭补助支出", "基本支出");
        decimal DataThis1 = GetBudgetDataThis("工资福利支出", "基本支出") + GetBudgetDataThis("商品和服务支出", "基本支出") + GetBudgetDataThis("对个人和家庭补助支出", "基本支出");
        decimal DataTatol1 = GetBudgetDataTatol("工资福利支出", "基本支出") + GetBudgetDataTatol("商品和服务支出", "基本支出") + GetBudgetDataTatol("对个人和家庭补助支出", "基本支出");

        decimal BudData2 = GetBudgetData("工资福利支出", "项目支出") + GetBudgetData("其他商品和服务支出", "项目支出") + GetBudgetData("其他资本性支出", "项目支出");
        decimal DataThis2 = GetBudgetDataThis("工资福利支出", "项目支出") + GetBudgetDataThis("其他商品和服务支出", "项目支出") + GetBudgetDataThis("其他资本性支出", "项目支出");
        decimal DataTatol2 = GetBudgetDataTatol("工资福利支出", "项目支出") + GetBudgetDataTatol("其他商品和服务支出", "项目支出") + GetBudgetDataTatol("其他资本性支出", "项目支出");


        DataRow dr1 = dt.NewRow();
        dr1["column1"] = "一、基本支出";
        if (BudData1 != 0)
        {
            dr1["column2"] = BudData1;
        }
        if (DataThis1 != 0)
        {
            dr1["column3"] = (DataThis1).ToString("f2");
        }
        if (DataTatol1 != 0)
        {
            dr1["column4"] = (DataTatol1).ToString("f2");
        }
        if (ToDec(dr1["column4"]) != 0 && ToDec(dr1["column2"]) != 0)
        {
            dr1["column5"] = ((ToDec(dr1["column4"]) / (ToDec(dr1["column2"]) * 10000)) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr1["column2"]) * 10000 - ToDec(dr1["column4"]) != 0)
        {
            dr1["column6"] = ToDec(dr1["column2"]) * 10000 - ToDec(dr1["column4"]);
        }
        dt.Rows.Add(dr1);

        //DataRow dr2 = dt.NewRow();
        //dr2["column1"] = "（一）工资福利支出";
        //if (BudData1 != 0)
        //{
        //    dr2["column2"] = BudData1;
        //}
        //if (DataThis1 != 0)
        //{
        //    dr2["column3"] = (DataThis1).ToString("f2");
        //}
        //if (DataTatol1 != 0)
        //{
        //    dr2["column4"] = (DataTatol1).ToString("f2");
        //}
        //if (ToDec(dr2["column4"]) != 0 && ToDec(dr2["column2"]) != 0)
        //{
        //    dr2["column5"] = ((ToDec(dr2["column4"]) / (ToDec(dr2["column2"]) * 10000)) * 100).ToString("f2") + "%";
        //}
        //if (ToDec(dr2["column2"]) * 10000 - ToDec(dr2["column4"]) != 0)
        //{
        //    dr2["column6"] = ToDec(dr2["column2"]) * 10000 - ToDec(dr2["column4"]);
        //}
        //dt.Rows.Add(dr2);
        AddDataRow(dt, "　（一）工资福利支出", "工资福利支出", "基本支出");
        AddDataRow(dt, "　　　1、基本工资", "基本工资", "基本支出");
        AddDataRow(dt, "　　　2、津贴补贴", "津贴补贴", "基本支出");
        AddDataRow(dt, "　　　3、奖金", "奖金", "基本支出");
        AddDataRow(dt, "　　　4、社会保障缴费", "社会保障缴费", "基本支出");
        AddDataRow(dt, "　　　5、伙食补助费", "伙食补助费", "基本支出");
        AddDataRow(dt, "　　　6、其他工资福利支出", "其他工资福利支出", "基本支出");

        //DataRow dr3 = dt.NewRow();
        //dr3["column1"] = "（二）商品和服务支出";
        //if (BudData2 != 0)
        //{
        //    dr3["column2"] = BudData2;
        //}
        //if (DataThis2 != 0)
        //{
        //    dr3["column3"] = (DataThis2).ToString("f2");
        //}
        //if (DataTatol2 != 0)
        //{
        //    dr3["column4"] = (DataTatol2).ToString("f2");
        //}
        //if (ToDec(dr3["column4"]) != 0 && ToDec(dr3["column2"]) != 0)
        //{
        //    dr3["column5"] = ((ToDec(dr3["column4"]) / (ToDec(dr3["column2"]) * 10000)) * 100).ToString("f2") + "%";
        //}
        //if (ToDec(dr3["column2"]) * 10000 - ToDec(dr3["column4"]) != 0)
        //{
        //    dr3["column6"] = ToDec(dr3["column2"]) * 10000 - ToDec(dr3["column4"]);
        //}
        //dt.Rows.Add(dr3);
        AddDataRow(dt, "　（二）商品和服务支出", "商品和服务支出", "基本支出");
        AddDataRow(dt, "　　　1、办公费", "办公费", "基本支出");
        AddDataRow(dt, "　　　2、印刷费", "印刷费", "基本支出");
        AddDataRow(dt, "　　　3、咨询费", "咨询费", "基本支出");
        AddDataRow(dt, "　　　4、手续费", "手续费", "基本支出");
        AddDataRow(dt, "　　　5、水费", "水费", "基本支出");
        AddDataRow(dt, "　　　6、电费", "电费", "基本支出");
        AddDataRow(dt, "　　　7、邮电费", "邮电费", "基本支出");
        AddDataRow(dt, "　　　8、取暖费", "取暖费", "基本支出");
        AddDataRow(dt, "　　　9、物业管理费", "物业管理费", "基本支出");
        AddDataRow(dt, "　　　10、差旅费", "差旅费", "基本支出");
        AddDataRow(dt, "　　　11、因公出国（境）费用", "因公出国（境）费用", "基本支出");
        AddDataRow(dt, "　　　12、维修（护）费", "维修（护）费", "基本支出");
        AddDataRow(dt, "　　　13、租赁费", "租赁费", "基本支出");
        AddDataRow(dt, "　　　14、会议费", "会议费", "基本支出");
        AddDataRow(dt, "　　　15、培训费", "培训费", "基本支出");
        AddDataRow(dt, "　　　16、公务接待费", "公务接待费", "基本支出");
        AddDataRow(dt, "　　　17、被装购置费", "被装购置费", "基本支出");
        AddDataRow(dt, "　　　18、劳务费", "劳务费", "基本支出");
        AddDataRow(dt, "　　　19、委托业务费", "委托业务费", "基本支出");
        AddDataRow(dt, "　　　20、工会经费", "工会经费", "基本支出");
        AddDataRow(dt, "　　　21、福利费", "福利费", "基本支出");
        AddDataRow(dt, "　　　22、公务用车运行维护费", "公务用车运行维护费", "基本支出");
        AddDataRow(dt, "　　　23、其他交通费用", "其他交通费用", "基本支出");
        AddDataRow(dt, "　　　24、其他商品和服务支出", "其他商品和服务支出", "基本支出");

        //DataRow dr4 = dt.NewRow();
        //dr4["column1"] = "（三）对个人和家庭补助支出";
        //if (BudData3 != 0)
        //{
        //    dr4["column2"] = BudData3;
        //}
        //if (DataThis3 != 0)
        //{
        //    dr4["column3"] = (DataThis3).ToString("f2");
        //}
        //if (DataTatol3 != 0)
        //{
        //    dr4["column4"] = (DataTatol3).ToString("f2");
        //}
        //if (ToDec(dr4["column4"]) != 0 && ToDec(dr4["column2"]) != 0)
        //{
        //    dr4["column5"] = ((ToDec(dr4["column4"]) / (ToDec(dr4["column2"]) * 10000)) * 100).ToString("f2") + "%";
        //}
        //if (ToDec(dr4["column2"]) * 10000 - ToDec(dr4["column4"]) != 0)
        //{
        //    dr4["column6"] = ToDec(dr4["column2"]) * 10000 - ToDec(dr4["column4"]);
        //}
        //dt.Rows.Add(dr4);
        AddDataRow(dt, "　（三）对个人和家庭补助支出", "对个人和家庭补助支出", "基本支出");
        AddDataRow1(dt, "　　　1、离退休费", "离休费", "退休费", "退职(役)费", "基本支出");
        AddDataRow(dt, "　　　2、抚恤金", "抚恤金", "基本支出");
        AddDataRow(dt, "　　　3、生活补助", "生活补助", "基本支出");
        AddDataRow(dt, "　　　4、医疗费", "医疗费", "基本支出");
        AddDataRow(dt, "　　　5、住房公积金", "住房公积金", "基本支出");
        AddDataRow(dt, "　　　6、提租补贴", "提租补贴", "基本支出");
        AddDataRow(dt, "　　　7、住房补贴", "住房补贴", "基本支出");
        AddDataRow3(dt, "　　　8、其他对个人和家庭补助支出", "其他对个人和家庭补助支出", "救济费", "助学金", "奖励金", "基本支出");

        DataRow dr5 = dt.NewRow();
        dr5["column1"] = "二、项目支出";
        if (BudData2 != 0)
        {
            dr5["column2"] = BudData2;
        }
        if (DataThis2 != 0)
        {
            dr5["column3"] = (DataThis2).ToString("f2");
        }
        if (DataTatol2 != 0)
        {
            dr5["column4"] = (DataTatol2).ToString("f2");
        }
        if (ToDec(dr5["column4"]) != 0 && ToDec(dr5["column2"]) != 0)
        {
            dr5["column5"] = ((ToDec(dr5["column4"]) / (ToDec(dr5["column2"]) * 10000)) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr5["column2"]) * 10000 - ToDec(dr5["column4"]) != 0)
        {
            dr5["column6"] = ToDec(dr5["column2"]) * 10000 - ToDec(dr5["column4"]);
        }
        dt.Rows.Add(dr5);

        //DataRow dr6 = dt.NewRow();
        //dr6["column1"] = "（一）工资福利支出";
        //if (BudData4 != 0)
        //{
        //    dr6["column2"] = BudData4;
        //}
        //if (DataThis4 != 0)
        //{
        //    dr6["column3"] = (DataThis4).ToString("f2");
        //}
        //if (DataTatol4 != 0)
        //{
        //    dr6["column4"] = (DataTatol4).ToString("f2");
        //}
        //if (ToDec(dr6["column4"]) != 0 && ToDec(dr6["column2"]) != 0)
        //{
        //    dr6["column5"] = ((ToDec(dr6["column4"]) / (ToDec(dr6["column2"]) * 10000)) * 100).ToString("f2") + "%";
        //}
        //if (ToDec(dr6["column2"]) * 10000 - ToDec(dr6["column4"]) != 0)
        //{
        //    dr6["column6"] = ToDec(dr6["column2"]) * 10000 - ToDec(dr6["column4"]);
        //}
        //dt.Rows.Add(dr6);
        AddDataRow(dt, "　（一）工资福利支出 ", "工资福利支出", "项目支出");
        AddDataRow(dt, "　　　1、津贴补贴 ", "津贴补贴", "项目支出");
        AddDataRow(dt, "　　　2、奖励性补贴", "奖励性补贴", "项目支出");

        //DataRow dr7 = dt.NewRow();
        //dr7["column1"] = "（二）其他商品和服务支出";
        //if (BudData5 != 0)
        //{
        //    dr7["column2"] = BudData5;
        //}
        //if (DataThis5 != 0)
        //{
        //    dr7["column3"] = (DataThis5).ToString("f2");
        //}
        //if (DataTatol5 != 0)
        //{
        //    dr7["column4"] = (DataTatol5).ToString("f2");
        //}
        //if (ToDec(dr7["column4"]) != 0 && ToDec(dr7["column2"]) != 0)
        //{
        //    dr7["column5"] = ((ToDec(dr7["column4"]) / (ToDec(dr7["column2"]) * 10000)) * 100).ToString("f2") + "%";
        //}
        //if (ToDec(dr7["column2"]) * 10000 - ToDec(dr7["column4"]) != 0)
        //{
        //    dr7["column6"] = ToDec(dr7["column2"]) * 10000 - ToDec(dr7["column4"]);
        //}
        //dt.Rows.Add(dr7);
        AddDataRow(dt, "　（二）其他商品和服务支出", "其他商品和服务支出", "项目支出");
        AddDataRow(dt, "　　　1、税法宣传费", "税法宣传费", "项目支出");
        AddDataRow(dt, "　　　2、稽查办案费", "稽查办案费", "项目支出");
        AddDataRow(dt, "　　　3、税务工作经费", "税务工作经费", "项目支出");
        AddDataRow(dt, "　　　4、发票工作经费", "发票工作经费", "项目支出");
        AddDataRow(dt, "　　　5、协税护税费", "协税护税费", "项目支出");
        AddDataRow(dt, "　　　6、党团工会活动经费", "党团工会活动经费", "项目支出");
        AddDataRow(dt, "　　　7、妇代会", "妇代会", "项目支出");
        AddDataRow(dt, "　　　8、三代手续费", "三代手续费", "项目支出");
        AddDataRow(dt, "　　　9、计算机应用经费", "计算机应用经费", "项目支出");
        AddDataRow(dt, "　　　10、其他", "其他", "项目支出");

        //DataRow dr8 = dt.NewRow();
        //dr8["column1"] = "（三）其他资本性支出";
        //if (BudData6 != 0)
        //{
        //    dr8["column2"] = BudData6;
        //}
        //if (DataThis6 != 0)
        //{
        //    dr8["column3"] = (DataThis6).ToString("f2");
        //}
        //if (DataTatol6 != 0)
        //{
        //    dr8["column4"] = (DataTatol6).ToString("f2");
        //}
        //if (ToDec(dr8["column4"]) != 0 && ToDec(dr8["column2"]) != 0)
        //{
        //    dr8["column5"] = ((ToDec(dr8["column4"]) / (ToDec(dr8["column2"]) * 10000)) * 100).ToString("f2") + "%";
        //}
        //if (ToDec(dr8["column2"]) * 10000 - ToDec(dr8["column4"]) != 0)
        //{
        //    dr8["column6"] = ToDec(dr8["column2"]) * 10000 - ToDec(dr8["column4"]);
        //}
        //dt.Rows.Add(dr8);
        AddDataRow2(dt, "　（三）其他资本性支出", "其他资本性支出", "项目支出", 10);
        AddDataRow(dt, "　　　1、房屋建筑物购建", "房屋建筑物购建", "项目支出");
        AddDataRow(dt, "　　　2、办公设备购置费", "办公设备购置费", "项目支出");
        AddDataRow(dt, "　　　3、专用设备购置费", "专用设备购置费", "项目支出");
        AddDataRow(dt, "　　　4、交通工具购置费", "交通工具购置费", "项目支出");
        AddDataRow(dt, "　　　5、大型修缮", "大型修缮", "项目支出");
        AddDataRow(dt, "　　　6、信息网络购建", "信息网络购建", "项目支出");
        AddDataRow2(dt, "　　 7、其他资本性支出", "其他资本性支出", "项目支出", 12);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        HidSearchFlag.Value = "0";
        //BudDataBind();
        BudgetDataBind();
        HidSearchFlag.Value = "1";
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string title = string.Empty;        
        title ="(" +tbDate.Text+  ")经费预算指标.xls";
        DataTable dt = new DataTable();
        dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Columns.Add("column3");
        dt.Columns.Add("column4");
        dt.Columns.Add("column5");
        dt.Columns.Add("column6");
        dt.Columns.Add("column7");
        GetRows(dt);
        TableCell[] header = new TableCell[9];
        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }
        header[0].Text = "经费预算指标支出统计表</th></tr><tr>";
        header[0].ColumnSpan = 7;
        header[1].RowSpan=2;
        header[1].Text = "支出项目";
        header[2].RowSpan=2;
        header[2].Text = "经费预算指标(万元)";
        header[3].ColumnSpan=2;
        header[3].Text = "经费支出(元)";
        header[4].RowSpan=2;
        header[4].Text = "累计支出占预算%";
        header[5].RowSpan=2;
        header[5].Text = "结余+、-额";
        header[6].RowSpan=2;
        header[6].Text = "备   注</th></tr><tr>";

        header[7].Text = "本月";
        header[8].Text = "累计</th>";

        

        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();
        for (int i = 0; i < dt.Columns.Count; i++)
        {
           mergeCellNums.Add(i, 0);
        }
        
        common.DataTable2Excel(dt, header, title, mergeCellNums, 0); 
        //ExcelRender.RenderToExcel(dt,Context,title);
        
    }
}