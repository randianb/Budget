using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using FinaAnaly.BLL;
using FinaAnaly.Model;
using FinaAnaly.DAL;

public partial class WebPage_SysSetting_ImpAccData : System.Web.UI.Page
{
    int year = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //ImpDataBind();
        AccDataBind();
    }

    private void ImpDataBind()
    {
        DataTable dt = null;
        dt = FA_XIncomeAccAllocatManager.GetXIncomeAccAllocatAll();
        repIncomeMon.DataSource = dt;
        repIncomeMon.DataBind();
    }

    private decimal BasicMon(string name, string type)
    {
        decimal mon = 0;
        year = DateTime.Now.Year;
        string sql = "SELECT   a.PIID, a.PIType, a.PIEcoSubName, b.IAAMon, b.IAAYear FROM  dbo.FA_XPayIncome AS a INNER JOIN dbo.FA_XIncomeAccAllocat AS b ON a.PIID = b.PIID  where a.PIEcoSubName='{0}' and a.PIType='{1}' and b.IAAYear={2}";
        sql = string.Format(sql, name, type, year);
        DataTable dt = DBUnity.AdapterToTab(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            mon = ToDec(dt.Rows[0]["IAAMon"]);
        }
        return mon;
    }

    private int BasicpiidData(string name,string type)
    {
        int piid = 0;
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(name);
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            string subcode = dt.Rows[j]["PIEcoSubCoding"].ToString();
            if (subcode.Substring(0, 8) == "50010101")
            {
                piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
            }
        }
        return piid;
    }

    private int PropiidData(string name,string type)
    {
        int piid = 0;
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(name);
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            string subcode = dt.Rows[j]["PIEcoSubCoding"].ToString();
            if (subcode.Substring(0, 8) == "50010102")
            {
                piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
            }
        }
        return piid;
    }

    private void AddDataRow(DataTable dt, string name1, string name)
    {

        DataRow dr = dt.NewRow();
        dr["column1"] = name1;
        dr["column2"] = BasicMon(name, "基本支出").ToString("f2");
        dr["column3"] = BasicMon(name, "项目支出").ToString("f2");
        dr["BPIID"] = BasicpiidData(name, "基本支出");
        dr["PPIID"] = PropiidData(name, "项目支出");
        dt.Rows.Add(dr);
    }

    private void AccDataBind()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Columns.Add("column3");
        dt.Columns.Add("BPIID");
        dt.Columns.Add("PPIID");
        AddDataRow(dt, "　　　　　　　　　(一)工资福利支出", "工资福利支出");
        AddDataRow(dt, "　　　　　　　　　　　　　1、基本工资", "基本工资");
        AddDataRow(dt, "　　　　　　　　　　　　　2、津贴补贴", "津贴补贴");
        AddDataRow(dt, "　　　　　　　　　　　　　3、奖金", "奖金");
        AddDataRow(dt, "　　　　　　　　　　　　　4、社会保障缴费", "社会保障缴费");
        AddDataRow(dt, "　　　　　　　　　　　　　5、其他工资福利支出", "其他工资福利支出");
        AddDataRow(dt, "　　　　　　　　　(二)商品和服务支出", "商品和服务支出");
        AddDataRow(dt, "　　　　　　　　　　　　　1、办公费", "办公费");
        AddDataRow(dt, "　　　　　　　　　　　　　2、印刷费", "印刷费");
        AddDataRow(dt, "　　　　　　　　　　　　　3、咨询费", "咨询费");
        AddDataRow(dt, "　　　　　　　　　　　　　4、手续费", "手续费");
        AddDataRow(dt, "　　　　　　　　　　　　　5、水费", "水费");
        AddDataRow(dt, "　　　　　　　　　　　　　6、电费", "电费");
        AddDataRow(dt, "　　　　　　　　　　　　　7、邮电费", "邮电费");
        AddDataRow(dt, "　　　　　　　　　　　　　8、取暖费", "取暖费");
        AddDataRow(dt, "　　　　　　　　　　　　　9、物业管理费", "物业管理费");
        AddDataRow(dt, "　　　　　　　　　　　　　10、差旅费", "差旅费");
        AddDataRow(dt, "　　　　　　　　　　　　　11、因公出国（境）费用", "因公出国（境）费用");
        AddDataRow(dt, "　　　　　　　　　　　　　12、维修（护）费", "维修（护）费");
        AddDataRow(dt, "　　　　　　　　　　　　　13、租赁费", "租赁费");
        AddDataRow(dt, "　　　　　　　　　　　　　14、会议费", "会议费");
        AddDataRow(dt, "　　　　　　　　　　　　　15、培训费", "培训费");
        AddDataRow(dt, "　　　　　　　　　　　　　16、公务接待费", "公务接待费");
        AddDataRow(dt, "　　　　　　　　　　　　　17、被装购置费", "被装购置费");
        AddDataRow(dt, "　　　　　　　　　　　　　18、劳务费", "劳务费");
        AddDataRow(dt, "　　　　　　　　　　　　　19、委托业务费", "委托业务费");
        AddDataRow(dt, "　　　　　　　　　　　　　20、工会经费", "工会经费");
        AddDataRow(dt, "　　　　　　　　　　　　　21、福利费", "福利费");
        AddDataRow(dt, "　　　　　　　　　　　　　22、公务用车运行维护费", "公务用车运行维护费");
        AddDataRow(dt, "　　　　　　　　　　　　　23、其他交通费用", "其他交通费用");
        AddDataRow(dt, "　　　　　　　　　　　　　24、其他商品和服务支出", "其他商品和服务支出");
        AddDataRow(dt, "　　　　　　　　   (三)对个人和家庭补助支出", "对个人和家庭补助支出");
        AddDataRow(dt, "　　　　　　　　　　　　　1、离休费", "离休费");
        AddDataRow(dt, "　　　　　　　　　　　　　2、退休费", "退休费");
        AddDataRow(dt, "　　　　　　　　　　　　　3、退职(役)费", "退职(役)费");
        AddDataRow(dt, "　　　　　　　　　　　　　4、抚恤金", "抚恤金");
        AddDataRow(dt, "　　　　　　　　　　　　　5、生活补助", "生活补助");
        AddDataRow(dt, "　　　　　　　　　　　　　6、救济费", "救济费");
        AddDataRow(dt, "　　　　　　　　　　　　　7、医疗费", "医疗费");
        AddDataRow(dt, "　　　　　　　　　　　　　8、助学金", "助学金");
        AddDataRow(dt, "　　　　　　　　　　　　　9、奖励金", "奖励金");
        AddDataRow(dt, "　　　　　　　　　　　　　10、住房公积金", "住房公积金");
        AddDataRow(dt, "　　　　　　　　　　　　　11、提租补贴", "提租补贴");
        AddDataRow(dt, "　　　　　　　　　　　　　12、住房补贴", "住房补贴");
        AddDataRow(dt, "　　　　　　　　　　　　　13、其他对个人和家庭补助支出", "其他对个人和家庭补助支出");
        AddDataRow(dt, "　　　　　　　　　(四)其他资本性支出", "其他资本性支出");
        AddDataRow(dt, "　　　　　　　　　　　　　1、房屋建筑购建", "房屋建筑购建");
        AddDataRow(dt, "　　　　　　　　　　　　　2、办公设备购置", "办公设备购置");
        AddDataRow(dt, "　　　　　　　　　　　　　3、专用设备购建", "专用设备购建");
        AddDataRow(dt, "　　　　　　　　　　　　　4、大型修缮", "大型修缮");
        AddDataRow(dt, "　　　　　　　　　　　　　5、信息网络建设", "信息网络建设");
        AddDataRow(dt, "　　　　　　　　　　　　　6、其他资本性支出", "其他资本性支出");

        repIncomeMon.DataSource = dt;
        repIncomeMon.DataBind();
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

    protected void btnImport_Click(object sender, EventArgs e)
    {
        DataTable dt1 = null;
        DataTable dt2 = null;
        if (FileUpload1.HasFile)
        {
            byte[] fileBytes = FileUpload1.FileBytes;
            if (ExcelRender.HasData(new MemoryStream(fileBytes)))
            {
                dt1 = ExcelRender.RenderFromExcel(new MemoryStream(fileBytes), 2, 2);
                dt2 = ExcelRender.RenderFromExcel(new MemoryStream(fileBytes), 3, 2);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    FA_SysSetting fa = FA_SysSettingManager.GetSysSettingByMaxYear();
                    if (fa != null)
                    {
                        year = fa.SSYear;
                    }
                    for (int i = 5; i < 82; i++)
                    {
                        if (i != 5 && i != 14 && i != 42 && i != 57 && i != 68)
                        {
                            int piid = 0;
                            string str = dt1.Rows[2][i].ToString();
                            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                string subcode = dt.Rows[j]["PIEcoSubCoding"].ToString();
                                if (subcode.Substring(0, 8) == "50010101")
                                {
                                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                                }
                                if (FA_XIncomeAccAllocatManager.GetXIncomeAccAllocatBypiid(piid))
                                {
                                    lblShowResult.Text = "已导入，不能导入第二次";
                                }
                                else
                                {
                                    FA_XIncomeAccAllocat faiaa = new FA_XIncomeAccAllocat();
                                    faiaa.PIID = piid;
                                    faiaa.IAAMon = ToDec(dt1.Rows[6][i].ToString());
                                    faiaa.IAAYear = year;
                                    if (FA_XIncomeAccAllocatManager.AddFA_XIncomeAccAllocat(faiaa).IAAID > 0)
                                    {
                                        //ImpDataBind();
                                        AccDataBind();
                                        lblShowResult.Text = "导入成功";
                                    }
                                    else
                                    {
                                        lblShowResult.Text = "操作失败，请重试";
                                    }
                                }
                            }
                        }
                        else
                        {
                            int piid = 0;
                            string str = dt1.Rows[1][i].ToString();
                            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                string subcode = dt.Rows[j]["PIEcoSubCoding"].ToString();
                                if (subcode.Substring(0, 8) == "50010101")
                                {
                                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                                }
                                if (FA_XIncomeAccAllocatManager.GetXIncomeAccAllocatBypiid(piid))
                                {
                                    lblShowResult.Text = "已导入，不能导入第二次";
                                }
                                else
                                {
                                    FA_XIncomeAccAllocat faiaa = new FA_XIncomeAccAllocat();
                                    faiaa.PIID = piid;
                                    faiaa.IAAMon = ToDec(dt1.Rows[6][i].ToString());
                                    faiaa.IAAYear = year;
                                    if (FA_XIncomeAccAllocatManager.AddFA_XIncomeAccAllocat(faiaa).IAAID > 0)
                                    {
                                        //ImpDataBind();
                                        AccDataBind();
                                        lblShowResult.Text = "导入成功";
                                    }
                                    else
                                    {
                                        lblShowResult.Text = "操作失败，请重试";
                                    }
                                }
                            }
                        }
                    }
                }
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    FA_SysSetting fa = FA_SysSettingManager.GetSysSettingByMaxYear();
                    if (fa != null)
                    {
                        year = fa.SSYear;
                    }
                    for (int i = 5; i < 82; i++)
                    {
                        if (i != 5 && i != 14 && i != 42 && i != 57 && i != 68)
                        {
                            int piid = 0;
                            string str = dt2.Rows[2][i].ToString();
                            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                string subcode = dt.Rows[j]["PIEcoSubCoding"].ToString();
                                if (subcode.Substring(0, 8) == "50010102")
                                {
                                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                                }
                                if (FA_XIncomeAccAllocatManager.GetXIncomeAccAllocatBypiid(piid))
                                {
                                    lblShowResult.Text = "已导入，不能导入第二次";
                                }
                                else
                                {
                                    FA_XIncomeAccAllocat faiaa = new FA_XIncomeAccAllocat();
                                    faiaa.PIID = piid;
                                    faiaa.IAAMon = ToDec(dt2.Rows[6][i].ToString());
                                    faiaa.IAAYear = year;
                                    if (FA_XIncomeAccAllocatManager.AddFA_XIncomeAccAllocat(faiaa).IAAID > 0)
                                    {
                                        //ImpDataBind();
                                        AccDataBind();
                                        lblShowResult.Text = "导入成功";
                                    }
                                    else
                                    {
                                        lblShowResult.Text = "操作失败，请重试";
                                    }
                                }
                            }
                        }
                        else
                        {
                            int piid = 0;
                            string str = dt2.Rows[1][i].ToString();
                            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                string subcode = dt.Rows[j]["PIEcoSubCoding"].ToString();
                                if (subcode.Substring(0, 8) == "50010102")
                                {
                                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                                }
                                if (FA_XIncomeAccAllocatManager.GetXIncomeAccAllocatBypiid(piid))
                                {
                                    lblShowResult.Text = "已导入，不能导入第二次";
                                }
                                else
                                {
                                    FA_XIncomeAccAllocat faiaa = new FA_XIncomeAccAllocat();
                                    faiaa.PIID = piid;
                                    faiaa.IAAMon = ToDec(dt2.Rows[6][i].ToString());
                                    faiaa.IAAYear = year;
                                    if (FA_XIncomeAccAllocatManager.AddFA_XIncomeAccAllocat(faiaa).IAAID > 0)
                                    {
                                        //ImpDataBind();
                                        AccDataBind();
                                        lblShowResult.Text = "导入成功";
                                    }
                                    else
                                    {
                                        lblShowResult.Text = "操作失败，请重试";
                                    }
                                }
                            }
                        }
                    }
                }

            }

        }
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        int year = DateTime.Now.Year;
        string bpiidStrs = HidBasicPIIDStrs.Value.TrimEnd(',');
        string bmonStrs = HidBasicMonStrs.Value.TrimEnd(',');
        string ppiidStrs =HidProPIIDStrs.Value.TrimEnd(',');
        string pmonStrs = HidProMonStrs.Value.TrimEnd(',');
        string[] bpiidArr = bpiidStrs.Split(',');
        string[] bmonArr = bmonStrs.Split(',');
        string[] ppiidArr = ppiidStrs.Split(',');
        string[] pmonArr = pmonStrs.Split(',');
        if (bpiidArr.Length == bmonArr.Length)
        {
            for (int i = 0; i < bpiidArr.Length; i++)
            {
                int piid = common.IntSafeConvert(bpiidArr[i]);
                Decimal monTmp = ToDec(bmonArr[i]);
                FA_XIncomeAccAllocat  fa= FA_XIncomeAccAllocatManager.GetXIncomeAccAllocatByIncome(piid, year);
                if (fa != null)
                {
                    fa.IAAMon = monTmp;
                    FA_XIncomeAccAllocatManager.ModifyFA_XIncomeAccAllocat(fa);
                }
                else
                {
                    FA_XIncomeAccAllocat xaaAdd = new FA_XIncomeAccAllocat();
                    xaaAdd.IAAMon = monTmp;
                    xaaAdd.IAAYear = year;
                    xaaAdd.PIID = piid;
                    FA_XIncomeAccAllocatManager.AddFA_XIncomeAccAllocat(xaaAdd);
                }
            }
        }
        if (ppiidArr.Length == pmonArr.Length)
        {
            for (int i = 0; i < ppiidArr.Length; i++)
            {
                int piid = common.IntSafeConvert(ppiidArr[i]);
                Decimal monTmp = ToDec(pmonArr[i]);
                FA_XIncomeAccAllocat fa = FA_XIncomeAccAllocatManager.GetXIncomeAccAllocatByIncome(piid, year);
                if (fa != null)
                {
                    fa.IAAMon = monTmp;
                    FA_XIncomeAccAllocatManager.ModifyFA_XIncomeAccAllocat(fa);
                }
                else
                {
                    FA_XIncomeAccAllocat xaaAdd = new FA_XIncomeAccAllocat();
                    xaaAdd.IAAMon = monTmp;
                    xaaAdd.IAAYear = year;
                    xaaAdd.PIID = piid;
                    FA_XIncomeAccAllocatManager.AddFA_XIncomeAccAllocat(xaaAdd);
                }
            }
        }
        AccDataBind();
    }
}