using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using FinaAnaly.Model;
using Common;
using FinaAnaly.DAL;
using System.IO;

public partial class WebPage_BraFundInquiry_BraFundJournal : System.Web.UI.Page
{
    int uselim = 0;
    int depid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        rdCash.Hidden = false;
        rdNoCash.Hidden = false;
        STMem.Hidden = false;
        btnAdd.Hidden = false;
        Panel4.Hidden = false;
        CheckboxGroup1.Hidden = false;
        if (Request.QueryString["uselim"] != null && Request.QueryString["depid"] != null)
        {
            uselim = common.IntSafeConvert(Request.QueryString["uselim"]);
            depid = common.IntSafeConvert(Request.QueryString["depid"]);
            if (uselim == 1001)
            {
                CheckboxGroup1.Hidden = true;
                rdCash.Hidden = true;
                rdNoCash.Hidden = true;
                STMem.Hidden = true;
                btnAdd.Hidden = true;
                BookSave.Hidden = true;
                Button2.Hidden = true;
                btnDel.Hidden = true;
                Panel4.Hidden = true;
                ComboBox1.Text = Hididstr.Text;
            }
        }
        if (!IsPostBack)
        {
            GetDataBind();
        }
        DataTable dt = new DataTable();
        if (uselim == 1001)
        {
            FA_Department fa = FA_DepartmentManager.GetFA_DepartmentByDepID(depid);
            ComboBox1.Items.Add(new Ext.Net.ListItem(fa.DepName, depid.ToString()));
        }
        else
        {
            dt = FA_DepartmentManager.GetAllFA_Department();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ComboBox1.Items.Add(new Ext.Net.ListItem(dt.Rows[i]["DepName"].ToString(), dt.Rows[i]["DepID"].ToString()));
                }
            }
        }
    }

    [DirectMethod]
    public string NodeLoad(string nodeID)
    {
        NodeCollection nodes = new Ext.Net.NodeCollection();
        if (nodeID == "root")
        {
            Node Nodeju = new Node();
            Nodeju.NodeID = "0";
            Nodeju.Text = "江岸地方税务局";
            Nodeju.Icon = Icon.Folder;
            nodes.Add(Nodeju);
            Getson(Nodeju);
        }
        return nodes.ToJson();
    }

    private void Getson(Node Node)
    {
        DataTable dtpark = FA_DepartmentManager.GetAllFA_Department();
        for (int i = 0; i < dtpark.Rows.Count; i++)
        {
            Node Nodeju = new Node();
            Nodeju.NodeID = dtpark.Rows[i]["DepID"].ToString();
            Nodeju.Text = dtpark.Rows[i]["DepName"].ToString();
            Nodeju.Icon = Icon.UserHome;
            Nodeju.Leaf = true;
            Node.Children.Add(Nodeju);
        }
    }

    private void GetDataBind()
    {
        DataTable dt = new DataTable();
        if (uselim == 1001)
        {
            FA_Department fa = FA_DepartmentManager.GetFA_DepartmentByDepID(depid);
            if (fa != null)
            {
                string name = fa.DepName;
                Hididstr.Text = name;
                string sql = string.Format("select * from FA_FundsAccountJournal where BM='{0}'", name);
                dt = DBUnity.AdapterToTab(sql);
            }
        }
        else
        {
            dt = FA_FundsAccountJournalManager.GetAllFA_FundsAccountJournal();
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            Store1.DataSource = GetNewDt(dt);
            Store1.DataBind();
        }
        else
        {
            dt = new DataTable();
            Store1.DataSource = dt;
            Store1.DataBind();
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "flagred", "flagred();", true);
    }

    private void GetDepDataBind(string name, string zflx)
    {
        DataTable dt = FA_FundsAccountJournalManager.GetFundsAccountJournalByNameZFLX(name, zflx);
        if (dt != null && dt.Rows.Count > 0)
        {
            Store1.DataSource = GetNewDt(dt);
            Store1.DataBind();
        }
        else
        {
            dt = new DataTable();
            Store1.DataSource = dt;
            Store1.DataBind();
        }
    }

    private void GetDepDataBind1(string name, string zflx)
    {
        DataTable dt = FA_FundsAccountJournalManager.GetFundsAccountJournalByNameZFLX(name, zflx);
        if (dt != null && dt.Rows.Count > 0)
        {
            Store1.DataSource = GetNewDt1(dt);
            Store1.DataBind();
        }
        else
        {
            dt = new DataTable();
            Store1.DataSource = dt;
            Store1.DataBind();
        }
    }

    private void GetEDepDataBind(string name)
    {
        DataTable dt = FA_FundsAccountJournalManager.GetFundsAccountJournalByName(name);
        if (dt != null && dt.Rows.Count > 0)
        {
            Store1.DataSource = GetNewDt(dt);
            Store1.DataBind();
        }
        else
        {
            dt = new DataTable();
            Store1.DataSource = dt;
            Store1.DataBind();
        }
    }

    private DataTable GetNewDt(DataTable dt)
    {
        decimal mon = 0;
        dt.Columns.Add("index");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["index"] = i + 1;
            mon += ToDec(dt.Rows[i]["JE"]);
        }
        DataRow dr = dt.NewRow();
        dr["index"] = "合计";
        dr["JE"] = mon;
        HidValue2.Text = mon.ToString();
        dt.Rows.Add(dr);
        return dt;
    }

    private DataTable GetNewDt1(DataTable dt)
    {
        decimal mon = 0;
        dt.Columns.Add("index");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["index"] = i + 1;
            mon += ToDec(dt.Rows[i]["JE"]);
        }
        DataRow dr = dt.NewRow();
        dr["index"] = "合计";
        dr["JE"] = mon;
        HidValue2.Text = mon.ToString();
        dt.Rows.Add(dr);
        return dt;
    }

    [DirectMethod]
    public void selectdep(string str)
    {
        HidText.Text = str;
        //DataTable dt = FA_FundsAccountJournalManager.GetFundsAccountJournalByName(str);
        //if (dt != null && dt.Rows.Count > 0)
        //{
        //    hidquerystr.Text = dt.Rows[0]["ZFLX"].ToString();
        //    rdCash.Hidden = true;
        //    rdNoCash.Hidden = true;
        //    X.MessageBox.Alert("温馨提示", "该部门支付类型为" + dt.Rows[0]["ZFLX"].ToString()).Show();
        //}
        if (str != "江岸地方税务局")
        {
            GetEDepDataBind(str);
        }
        else
        {
            GetDataBind();
        }
    }

    [DirectMethod]
    public void selectclick(string str)
    {
        HidValue1.Text = str;
        HidValue4.Text = "0";
    }

    protected void btnAdd_DirectClick(object sender, DirectEventArgs e)
    {
        string name = string.Empty;
        if (rdCash.Checked)
        {
            name = "现金";
            AddRow(name);
        }
        else if (rdNoCash.Checked)
        {
            name = "非现金";
            AddRow(name);
        }
        else
        {
            X.MessageBox.Alert("温馨提示", "请先选择支付类型").Show();
        }
        HidValue3.Text = name;
    }

    private void AddRow(string name)
    {
        if (HidText.Text != "江岸地方税务局" && HidText.Text != "")
        {
            FA_FundsAccountJournal fa = new FA_FundsAccountJournal();
            fa.BXRQ = DateTime.Now;
            fa.BM = HidText.Text;
            fa.ZFLX = name;
            fa.ZY = string.Empty;
            fa.JE = 0;
            fa.FJZS = 0;
            fa.BZ = string.Empty;
            //if (FA_FundsAccountJournalManager.AddFA_FundsAccountJournal(fa).FAUDID > 0)
            //{
            //    GetDepDataBind(fa.BM, name);
            //}
            //else
            //{
            //    X.MessageBox.Alert("操作提示", "增加失败").Show();
            //}
            fa.FAUDID = common.IntSafeConvert(HidValue5.Text) + 1;
            HidValue5.Text = fa.FAUDID.ToString();
            Store1.Insert(0, fa);
        }
        else
        {
            X.MessageBox.Alert("操作提示", "请先选择部门").Show();
        }
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

    [DirectMethod]
    public void clicksave(string str)
    {
        string[] arrstr = str.Trim().TrimEnd('#').Split('#');
        string bm = string.Empty;
        string zflx = string.Empty;
        for (int i = 0; i < arrstr.Length; i++)
        {
            string[] arr = arrstr[i].Split('*');
            int id = common.IntSafeConvert(arr[0], 0);
            FA_FundsAccountJournal fa = FA_FundsAccountJournalManager.GetFA_FundsAccountJournalByFAUDID(id);
            if (fa != null)
            {
                fa.BXRQ = Convert.ToDateTime(arr[1].Substring(3, 12));
                fa.ZY = arr[2];
                fa.JE = ToDec(arr[3]);
                fa.FJZS = ToDec(arr[4]);
                fa.BZ = arr[5];
                if (FA_FundsAccountJournalManager.ModifyFA_FundsAccountJournal(fa))
                {
                    X.MessageBox.Alert("操作提示", "保存成功").Show();
                }
                else
                {
                    X.MessageBox.Alert("操作提示", "保存失败").Show();
                }
            }
            else
            {
                if (arr[1] != "null")
                {
                    FA_FundsAccountJournal Newfa = new FA_FundsAccountJournal();
                    Newfa.BM = HidText.Text;
                    Newfa.ZFLX = HidValue3.Text;
                    Newfa.BXRQ = Convert.ToDateTime(arr[1].Substring(3, 12));
                    Newfa.ZY = arr[2];
                    Newfa.JE = ToDec(arr[3]);
                    Newfa.FJZS = ToDec(arr[4]);
                    Newfa.BZ = arr[5];
                    if (FA_FundsAccountJournalManager.AddFA_FundsAccountJournal(Newfa).FAUDID > 0)
                    {
                        X.MessageBox.Alert("操作提示", "保存成功").Show();
                    }
                    else
                    {
                        X.MessageBox.Alert("操作提示", "保存失败").Show();
                    }
                }
            }
        }
        if (HidText.Text != "" && HidText.Text != "江岸地方税务局")
        {
            if (HidValue3.Text != "")
            {
                GetDepDataBind(HidText.Text, HidValue3.Text);
            }
            else
            {
                GetEDepDataBind(HidText.Text);
            }
        }
        else
        {
            GetDataBind();
        }
    }
    protected void btnSearch_DirectClick(object sender, DirectEventArgs e)
    {
        WinSearch.Show();
        ComboBox1.Text = HidText.Text;
    }
    protected void Button1_DirectClick(object sender, DirectEventArgs e)
    {
        DataTable dt=  GetSearchData();
        if (dt != null && dt.Rows.Count > 0)
        {
            Store1.DataSource = GetNewDt(dt);
            Store1.DataBind();
        }
        else
        {
            X.MessageBox.Alert("操作提示", "未查询到数据").Show();
        }
        WinSearch.Hidden = true;
        HidValue4.Text = "1";
    }

    private DataTable  GetSearchData()
    {
        string str1 = string.Empty;
        string str2 = string.Empty;
        string str3 = string.Empty;
        string str4 = string.Empty;
        string str5 = string.Empty;
        string str6 = string.Empty;
        string str7 = string.Empty;
        string str8 = string.Empty;
        if (ComboBox1.Text != "")
        {
            str1 = "BM like '%" + ComboBox1.SelectedItem.Text + "%'";
        }
        else
        {
            str1 = "1=1";
        }
        if (Convert.ToDateTime(DateField2.Text).ToString("yyyy-MM-dd") != "0001-01-01")
        {
            str2 = " and YEAR(BXRQ) =" + Convert.ToDateTime(DateField2.Text).Year + " and MONTH(BXRQ) =" + Convert.ToDateTime(DateField2.Text).Month + " and Day(BXRQ) =" + Convert.ToDateTime(DateField2.Text).Day;
        }
        else
        {
            str2 = "";
        }
        if (TextField131.Text != "" && TextField148.Text != "")
        {
            str3 = "and JE BETWEEN '" + TextField131.Text + "' AND '" + TextField148.Text + "'";
        }
        else if (TextField131.Text != "" && TextField148.Text == "")
        {
            str3 = "and JE ='" + TextField131.Text + "'";
        }
        else
        {
            str3 = "";
        }
        if (Convert.ToDateTime(DateField15.Text).ToString("yyyy-MM-dd") != "0001-01-01" && Convert.ToDateTime(DateField16.Text).ToString("yyyy-MM-dd") != "0001-01-01")
        {
            str4 = " and BXRQ BETWEEN '" + Convert.ToDateTime(DateField15.Text).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(DateField16.Text).ToString("yyyy-MM-dd") + "'";
        }
        else
        {
            str4 = "";
        }
        if (TextField134.Text != "")
        {
            str5 = " and ZFLX = '" + TextField134.SelectedItem.Text + "'";
        }
        else
        {
            str5 = "";
        }
        if (TextField5.Text != "")
        {
            str6 = " and ZY like '%" + TextField5.Text + "%'";
        }
        else
        {
            str6 = "";
        }
        string sql = string.Empty;
        //if (uselim == 1001)
        //{
        //    sql = string.Format("select * from FA_FundsAccountJournal where BM='" + ComboBox1.Text + "' AND " + str2 + str3 + str4 + str5 + str6);
        //}
        //else
        //{
        sql = string.Format("select * from FA_FundsAccountJournal where " + str1 + str2 + str3 + str4 + str5 + str6);
        //}
        DataTable dt = DBUnity.AdapterToTab(sql);
        return dt;
    }

    protected void btnEmpty_DirectClick(object sender, DirectEventArgs e)
    {
        ComboBox1.Text = string.Empty;
        DateField2.Text = string.Empty;
        TextField131.Text = string.Empty;
        TextField148.Text = string.Empty;
        DateField15.Text = string.Empty;
        DateField16.Text = string.Empty;
        TextField134.Text = string.Empty;
        TextField5.Text = string.Empty;
    }
    protected void btnCancel_DirectClick(object sender, DirectEventArgs e)
    {
        WinSearch.Hidden = true;
    }
    protected void btnDel_DirectClick(object sender, DirectEventArgs e)
    {
        int id = common.IntSafeConvert(HidValue1.Text, 0);
        if (id >= 1000000)
        {
            Store1.RemoveAt(0);
        }
        else
        {
            if (id == 0)
            {
                // RowSelectionModel sm = this.GridPanel1.GetSelectionModel() as RowSelectionModel;
                X.MessageBox.Alert("操作提示", "请先点击所要删除的行！").Show();
            }
            else
            {
                X.Msg.Confirm("提示", "是否确定删除", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "CompanyX.getall()",
                        Text = "是"
                    },
                    No = new MessageBoxButtonConfig
                    {
                        Text = "否"
                    }
                }).Show();
            }
        }
    }

    [DirectMethod(Namespace = "CompanyX")]
    public void getall()
    {
        int id = common.IntSafeConvert(HidValue1.Text, 0);
        if (FA_FundsAccountJournalManager.DeleteFA_FundsAccountJournalByID(id))
        {
            if (HidText.Text != "" && HidText.Text != "江岸地方税务局")
            {
                if (HidValue3.Text != "")
                {
                    GetDepDataBind(HidText.Text, HidValue3.Text);
                }
                else
                {
                    GetEDepDataBind(HidText.Text);
                }
            }
            else
            {
                GetDataBind();
            }
        }
        else
        {
            X.MessageBox.Alert("操作提示", "删除失败").Show();
        }
        HidValue1.Text = "0";
    }

    protected void Button2_DirectClick(object sender, DirectEventArgs e)
    {
        int id = common.IntSafeConvert(HidValue1.Text, 0);
        FA_FundsAccountJournal fa = FA_FundsAccountJournalManager.GetFA_FundsAccountJournalByFAUDID(id);
        if (fa != null)
        {
            fa.BM = fa.BM;
            fa.ZFLX = fa.ZFLX;
            fa.BXRQ = Convert.ToDateTime(fa.BXRQ.Year.ToString() + "-" + fa.BXRQ.Month + "-" + (fa.BXRQ.Day - 1).ToString());
            fa.ZY = string.Empty;
            fa.JE = 0;
            fa.FJZS = 0;
            fa.BZ = string.Empty;
        }
        if (FA_FundsAccountJournalManager.AddFA_FundsAccountJournal(fa).FAUDID > 0)
        {
            GetDepDataBind(fa.BM, fa.ZFLX);
            X.MessageBox.Alert("操作提示", "插入成功").Show();
        }
        else
        {
            X.MessageBox.Alert("操作提示", "插入失败").Show();
        }
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (uselim == 1001)
        {
            FA_Department fa = FA_DepartmentManager.GetFA_DepartmentByDepID(depid);
            if (fa != null)
            {
                string name = fa.DepName;
                Hididstr.Text = name;
                string sql = string.Format("select * from FA_FundsAccountJournal where BM='{0}'", name);
                dt = DBUnity.AdapterToTab(sql);
            }
        }
        else
        {
            if (HidValue4.Text == "1")
            {
                dt = GetSearchData();
            }
            else
            {
                if (HidText.Text != "" && HidText.Text != "江岸地方税务局")
                {
                    if (HidValue3.Text != "")
                    {
                        dt = FA_FundsAccountJournalManager.GetFundsAccountJournalByNameZFLX(HidText.Text, HidValue3.Text);
                    }
                    else
                    {
                        dt = FA_FundsAccountJournalManager.GetFundsAccountJournalByName(HidText.Text);
                    }
                }
                else
                {
                    dt = FA_FundsAccountJournalManager.GetAllFA_FundsAccountJournal();
                }
            }
           
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            string title = "科所经费日记账.xls";
            //ExcelRender.RenderToExcel(dt, Context, title);
            TableCell[] header = new TableCell[9];
            for (int i = 0; i < header.Length; i++)
            {
                header[i] = new TableHeaderCell();
            }
            header[0].Text = "ID";
            header[1].Text = "报销日期";
            header[2].Text = "部门";
            header[3].Text = "支付类型";
            header[4].Text = "摘要";
            header[5].Text = "金额";
            header[6].Text = "附件张数";
            header[7].Text = "备注";
            header[8].Text = "序号";



            Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                mergeCellNums.Add(i, 0);
            }

            common.DataTable2Excel(GetNewDt(dt), header, title, mergeCellNums, 0); 
        }
        else
        {
            this.Response.Write("<script>alert('无数据不允许导出')</script>");
        }
    }

    protected void Store1_ReadData(object sender, StoreReadDataEventArgs e)
    {
        if (HidValue4.Text == "1")
        {
            GetSearchData();
        }
        else
        {
            if (HidText.Text != "" && HidText.Text != "江岸地方税务局")
            {
                if (HidValue3.Text != "")
                {
                    GetDepDataBind(HidText.Text, HidValue3.Text);
                }
                else
                {
                    GetEDepDataBind(HidText.Text);
                }
            }
            else
            {
                GetDataBind();
            }
        }
    }

    protected void CheckboxGroup1_DirectChange(object sender, DirectEventArgs e)
    {
        if (HidText.Text != "")
        {
            if (rdCash.Checked)
            {
                GetDepDataBind(HidText.Text, "现金");
            }
            if (rdNoCash.Checked)
            {
                GetDepDataBind(HidText.Text, "非现金");
            }
        }
    }
}