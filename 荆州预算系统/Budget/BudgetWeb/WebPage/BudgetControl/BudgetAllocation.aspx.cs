using System;
using System.Data;
using System.Xml;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Common;
using Ext.Net;
using DataView = System.Data.DataView;
using MessageBox = Ext.Net.MessageBox;

public partial class WebPage_BudgetControl_BudgetAllocation : BudgetBasePage
{
    private int depID;
    public string listallocationstr = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            listallocationstr = Listallocationstr;
        }
        catch (Exception)
        {
            listallocationstr = "";
        }

        depID = DepID;
        if (!ExtNet.IsAjaxRequest && !IsPostBack)
        {
            if (listallocationstr == "")
            {
                GetMSG();
            }
            GetYear();
            DtDataBind();
        }
        Label4.Style.Add("color", "red");
        Label5.Style.Add("color", "red");
    }

    private void GetYear()
    {
//        DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
//        if (dt.Rows.Count > 0)
//        {
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                int a = Convert.ToInt32(dt.Rows.Count) - 1;
//                HidYear.Value = dt.Rows[a]["DefaultYear"].ToString();
//            }
//        }
        HidYear.Value = CurrentYear;
        Label6.Text = HidYear.Value.ToString();
    }

    /// <summary>
    ///     绑定数据
    /// </summary>
    private void DtDataBind()
    {
        decimal txt = 0;
        decimal txt1 = 0;
        int year = Convert.ToInt32(HidYear.Value);
        int bgmonid = BG_MonLogic.GEtIDisEditMon(common.IntSafeConvert(CurrentYear));
        BG_Mon bgMon = BG_MonManager.GetBG_MonByBGID(bgmonid);

        if (bgMon != null && bgMon.IsEditMon == 1)
        {
            txt = bgMon.BGMon;
        }
        else
        {
            DataTable dt1 = BG_BudItemsLogic.GetPayOne(year);
            if (dt1.Rows.Count > 0)
            {
                txt += ParToDecimal.ParToDel(dt1.Rows[0]["POTitol"].ToString());
            }
            DataTable dt2 = BG_BudItemsLogic.GetPayTwo(year);
            if (dt1.Rows.Count > 0)
            {
                if (dt2.Rows.Count > 0)
                {
                    txt += ParToDecimal.ParToDel(dt2.Rows[0]["PTTitol"].ToString());
                }
            }
            DataTable dt3 = BG_BudItemsLogic.GetPubPay(year);
            if (dt1.Rows.Count > 0)
            {
                if (dt3.Rows.Count > 0)
                {
                    txt += ParToDecimal.ParToDel(dt3.Rows[0]["PBIDTitol"].ToString());
                }
            }
            DataTable dt4 = BG_BudItemsLogic.GetProPay(year);
            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    txt += Convert.ToDecimal(dt4.Rows[i]["ProPA0M"]);
                }
            }
        }
        txt1 = txt;
        DataTable dt5 = BG_BudItemsLogic.GetBudgetAllocation(year);
        if (dt5.Rows.Count > 0)
        {
            for (int i = 0; i < dt5.Rows.Count; i++)
            {
                txt -= ParToDecimal.ParToDel(dt5.Rows[i]["BAAMon"].ToString());
            }
        }
        DataTable dtpre = BG_PreLogic.GetBG_PreByyear(common.IntSafeConvert(CurrentYear));
        decimal premon = 0;
        if (dtpre == null || dtpre.Rows.Count == 0)
        {
            premon = 0;
        }
        else
        {
            premon = ParToDecimal.ParToDel(dtpre.Rows[0]["PreMon"].ToString());
        }
        Label4.Text = (txt + premon).ToString("f2");
        //tatal.Value = txt.ToString();
        //Label4.Text = txt.ToString();
        baa.Value = txt.ToString();
        DataTable dt = BG_DepartmentLogic.GetAllBG_DepartmentMon(year, DepID);
        DataTable dt6 = BG_SupplementaryLogic.GetBG_SupplementaryByyear(year);
        decimal sutxt = 0;
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sutxt += ParToDel(dt.Rows[i]["SuppMon"].ToString());
            }
        }

        if (dt6.Rows.Count <= 0)
        {
            Label5.Text = "0.00";
        }
        else
        {
            Label5.Text = (ParToDecimal.ParToDel(dt6.Rows[0]["SuppMon"].ToString()) - sutxt).ToString("f2");
        }
        supp.Value = Convert.ToDecimal(Label5.Text);

        dt.Columns.Add("DepNum");
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["DepNum"] = (i + 1).ToString();
            }
            Store1.DataSource = dt;
            Store1.DataBind();
        }
        else
        {
            ExtNet.Msg.Show(new MessageBoxConfig
            {
                Title = "提示",
                Message = "本年度还没有添加预算，请先添加预算。",
                Width = 300,
                Buttons = MessageBox.Button.OK,
                //Multiline = true,
                //AnimEl = this.Button3.ClientID,
                //Fn = new JFunction { Fn = "showResultText" }
            });
            Store1.DataSource = dt;
            Store1.DataBind();
        }
        if ((txt1 - txt) == 0 && sutxt == 0)
        {
        }
        DataTable bgmp = BG_MonPayPlanManager.GetAllBG_MonPayPlan();
        DataView dv = bgmp.DefaultView;
        dv.RowFilter = string.Format("convert(MPTime,'System.String') LIKE '{0}%'", CurrentYear);
        DataTable newbgmp = dv.ToTable(true);
        if (newbgmp != null)
        {
            if (newbgmp.Rows.Count == 0)
            {
                BtnSettingPayIncome.Hidden = false;
            }
        }
    }

    [DirectMethod(Namespace = "CompanyXX")]
    public void DooYes()
    {
        DataTable dt = BG_BudgetAllocationManager.GetAllBG_BudgetAllocation();
        if (dt.Rows.Count > 0)
        {
            if (BG_BudgetAllocationLogic.DelByYear(CurrentYear))
            {
                Windows.Show();
                btnDivde.Hide();
                btnsave.Show();
                StoreSelectIncomeBind();
                DtDataBind();
            }
        }
        else
        {
            Windows.Show();
            btnDivde.Hide();
            btnsave.Show();
            StoreSelectIncomeBind();
            DtDataBind();
        }
    }

    private decimal ParToDel(string str)
    {
        decimal del = 0;
        if (!string.IsNullOrEmpty(str))
        {
            del = Convert.ToDecimal(str);
        }
        else
        {
            del = 0;
        }
        return del;
    }

    [DirectMethod(Namespace = "CompanyX")]
    public void DoYes(string depID)
    {
        Windows.Show();
        Session["ID"] = depID;
        StoreSelectIncomeBind();
    }

    [DirectMethod(Namespace = "CompanyX")]
    public void DoNo(string depID)
    {
        Response.Redirect(@"PayIncomeAllocation.aspx?Depid=" + depID, true);
    }

    [DirectMethod(Namespace = "Company")]
    public void DoXXYes()
    {
        Windows.Show();
        btnDivde.Hide();
        btnsave.Show();
        StoreSelectIncomeBind();
    }

    [DirectMethod(Namespace = "Company")]
    public void DoXXNo()
    {
        ExtNet.Msg.Alert("提示", "您未设置分配，您将无法分配数据").Show();
    }

    [DirectMethod]
    public void DivideData(string depID)
    {
        int tem = 1;
        if (listallocationstr == "")
        {
            GetMSG(depID);
        }
        else
        {
            Response.Redirect(@"PayIncomeAllocation.aspx?Depid=" + depID, true);
        }
    }

    private void GetMSG(string depID)
    {
        ExtNet.Msg.Confirm("温馨提示", "是否设置分配数据？", new MessageBoxButtonsConfig
        {
            Yes = new MessageBoxButtonConfig
            {
                Handler = string.Format("CompanyX.DoYes({0})", depID),
                Text = "是"
            },
            No = new MessageBoxButtonConfig
            {
                Handler = string.Format("CompanyX.DoNo({0})", depID),
                Text = "否"
            }
        }).Show();
    }

    private void GetMSG()
    {
        ExtNet.Msg.Confirm("温馨提示", "是否设置分配数据？", new MessageBoxButtonsConfig
        {
            Yes = new MessageBoxButtonConfig
            {
                Handler = "Company.DoXXYes()",
                Text = "是"
            },
            No = new MessageBoxButtonConfig
            {
                Handler = "Company.DoXXNo()",
                Text = "否"
            }
        }).Show();
    }

    protected void btnsave_DirectClick(object sender, DirectEventArgs e)
    {
        AllSetting();
        Windows.Hide();
    }

    protected void btnDivde_DirectClick(object sender, DirectEventArgs e)
    {
        AllSetting();
        Response.Redirect(@"PayIncomeAllocation.aspx?Depid=" + depID, true);
    }

    [DirectMethod]
    public void insertSign(string piid, string issign)
    {
        string pname = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(piid)).PIEcoSubName;
        DataTable dtpiid = BG_PayIncomeLogic.GetBG_PayIncomeByname(pname);
        int tempiid = 0;
        for (int i = 0; i < dtpiid.Rows.Count; i++)
        {
            tempiid = common.IntSafeConvert(dtpiid.Rows[i]["PIID"]);
            if (issign == "1")
            {
                BG_PayIncome ba = BG_PayIncomeManager.GetBG_PayIncomeByPIID(tempiid);
                ba.ISSign = 0;
                BG_PayIncomeManager.ModifyBG_PayIncome(ba);
            }
            else
            {
                BG_PayIncome ba = BG_PayIncomeManager.GetBG_PayIncomeByPIID(tempiid);
                ba.ISSign = 1;
                BG_PayIncomeManager.ModifyBG_PayIncome(ba);
            }
        }
    }

    private void AllSetting()
    {
        var depID = (string) Session["ID"];
        string tmpStr = "";
        //string cmball = cmballocation.Text;
        //string cmbpay = cmbpayincome.Text;
        string cmball = "财政拨款,其他资金";
        string cmbpay = "基本支出，项目支出";
        string cmbsel = Hidselector.Value.ToString();
        tmpStr = cmball + "*" + cmbpay + "*" + cmbsel;
        Application.UnLock();
        listallocationstr = tmpStr;
        InsertXML(tmpStr);
        Application.Lock();
        FPCMB.Reset();
    }

    //public string GetValue()
    //{
    //    string str = "";
    //    System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
    //    SiteMapPath path = new SiteMapPath();
    //    xDoc.Load(Server.MapPath("~/Settings/") + "Settings.xml");

    //    System.Xml.XmlNode xNode;
    //    System.Xml.XmlElement xElem1;
    //    System.Xml.XmlElement xElem2;
    //    xNode = xDoc.SelectSingleNode("//appSettings");

    //    xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + "Setting']");
    //    if (xElem1 != null)
    //    {
    //       str= xElem1.GetAttribute("value");
    //    }
    //    else
    //    {
    //        xElem2 = xDoc.CreateElement("add");
    //        xElem2.SetAttribute("key", "Setting");
    //        xElem2.SetAttribute("value", "");
    //        xNode.AppendChild(xElem2);
    //    }
    //    xDoc.Save(Server.MapPath("~/Settings/") + "Settings.xml");
    //    return str;
    //} 

    public void InsertXML(string value)
    {
        //string xmlPath = Server.MapPath("~/Settings/") + "Settings.xml";
        //XmlDocument xmlDoc = new XmlDocument();
        //xmlDoc.Load(xmlPath);

        ////获取根节点
        //XmlNode root = xmlDoc.SelectSingleNode("members");
        //foreach (XmlNode node in root)
        //{

        //    //验证是否登录通过
        //    if (UserName.ToLower() == node.ChildNodes[1].InnerText.ToLower())
        //    { 

        //    }
        //}
        //XmlElement xment = xmlDoc.CreateElement("Person");

        ////创建节点


        //XmlElement xmlid = xmlDoc.CreateElement("id");
        //xmlid.InnerText = UserID.ToString();
        //xment.AppendChild(xmlid);


        //XmlElement xmlname = xmlDoc.CreateElement("name");
        //xmlname.InnerText = UserName;
        //xment.AppendChild(xmlname);

        //XmlElement xmlset = xmlDoc.CreateElement("setting");
        //xmlset.InnerText = value;
        //xment.AppendChild(xmlset);
        //xmlDoc.Save(xmlPath);

        ///每个用户信息存在Person元素中 
        ///用户名、密码、年龄、邮箱均为Person的子元素
        bool isOK = false;
        try
        {
            //-----用户信息父元素--------子元素---------文档根元素-----
            XmlElement thePerson = null, theElem = null, root = null;
            var xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/Settings/") + "Settings.xml");
            root = xmldoc.DocumentElement;

            String strTemp = "/members/Person[uid='" + "设置" + "']";
            thePerson = (XmlElement) root.SelectSingleNode(strTemp);

            if (thePerson != null)
            {
                //////
            }
            else
            {
                isOK = true;
            }
            if (isOK) //用户名可用
            {
                thePerson = xmldoc.CreateElement("Person");
                theElem = xmldoc.CreateElement("uid");
                theElem.InnerText = UserID.ToString();
                thePerson.AppendChild(theElem); //theElem作为thePerson的子元素

                theElem = xmldoc.CreateElement("uname");
                theElem.InnerText = UserName;
                thePerson.AppendChild(theElem);

                theElem = xmldoc.CreateElement("setting");
                theElem.InnerText = value;
                thePerson.AppendChild(theElem);

                theElem = xmldoc.CreateElement("time");
                theElem.InnerText = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
                thePerson.AppendChild(theElem);

                root.AppendChild(thePerson); //thePerson作为root子元素

                xmldoc.Save(Server.MapPath("~/Settings/") + "Settings.xml");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    //public void SetValue(string AppValue)
    //{
    //    System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
    //    SiteMapPath path = new SiteMapPath();
    //    xDoc.Load(Server.MapPath("~/Settings/") + "Settings.xml");

    //    System.Xml.XmlNode xNode;
    //    System.Xml.XmlElement xElem1;
    //    System.Xml.XmlElement xElem2;
    //    xNode = xDoc.SelectSingleNode("//appSettings");

    //    xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + "Setting']");
    //    if (xElem1 != null)
    //    {
    //        xElem1.SetAttribute("value", AppValue);
    //    }
    //    else
    //    {
    //        xElem2 = xDoc.CreateElement("add");
    //        xElem2.SetAttribute("key", "Setting");
    //        xElem2.SetAttribute("value", AppValue);
    //        xNode.AppendChild(xElem2);
    //    }
    //    xDoc.Save(Server.MapPath("~/Settings/") + "Settings.xml");
    //    //XmlDocument doc = new XmlDocument();
    //    //doc.Load(Server.MapPath("~/Settings/") + "Settings.xml");
    //    //System.Xml.XmlElement xElem1; 
    //    //XmlNode tmp = doc.SelectSingleNode("Root/appSettings"); // 查找节点  Root是根
    //    //xElem1 = (System.Xml.XmlElement)tmp.SelectSingleNode("//add[@key='" + AppKey + "']");
    //    //if (tmp != null)
    //    //{
    //    //    tmp.InnerText = AppValue;
    //    //}
    //    //doc.Save(Server.MapPath("~/Settings/") + "Settings.xml");
    //}
    public void StoreSelectIncome_ReadData(object sender, StoreReadDataEventArgs e)
    {
        int tem = 1;
        //string an = cmballocation.SelectedItem.Value;
        //string pe = cmbpayincome.SelectedItem.Value;
        //string an = "财政拨款,其他资金";
        //string pe = "基本支出，项目支出";
        //DataTable dt = BG_PayIncomeLogic.GetDtPayIncome(pe, an, tem);
        DataTable dt = BG_PayIncomeLogic.GetDtPayIncome();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["ISSign"] = dt.Rows[i]["ISSign"] == DBNull.Value ? 0 : (int) dt.Rows[i]["ISSign"];
        }
        StoreSelectIncome.DataSource = dt;
        StoreSelectIncome.DataBind();
    }

    private void StoreSelectIncomeBind()
    {
        string an = "财政拨款";
        string pe = "基本支出";
        DataTable dt = BG_PayIncomeLogic.GetDtPayIncome(pe, an, 1);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["ISSign"] = dt.Rows[i]["ISSign"] == DBNull.Value ? 0 : (int) dt.Rows[i]["ISSign"];
            dt.Rows[i]["ISSign"] = 0;
        }
        StoreSelectIncome.DataSource = dt;
        StoreSelectIncome.DataBind();
    }

    //private DataTable GETNEW(DataTable dt)
    //{
    //    DataTable newdt = new DataTable();
    //    newdt.Columns.Add("PIID");
    //    newdt.Columns.Add("PIID");
    //    for (int i = 0; i < newdt.Rows.Count; i++)
    //    {

    //    }
    //}

    protected void BtnSettingPayIncome_DirectClick(object sender, DirectEventArgs e)
    {
        ExtNet.Msg.Confirm("提示", "是您已存在分配设置,重新分配将会清除分配数据.是否执行此次操作?", new MessageBoxButtonsConfig
        {
            Yes = new MessageBoxButtonConfig
            {
                Handler = string.Format("CompanyXX.DooYes()"),
                Text = "是"
            },
            No = new MessageBoxButtonConfig
            {
                Handler = string.Format("CompanyXX.DooNo()"),
                Text = "否"
            }
        }).Show();
    }
}