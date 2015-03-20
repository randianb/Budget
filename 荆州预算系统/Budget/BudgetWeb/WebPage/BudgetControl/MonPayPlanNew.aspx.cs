using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Xml;
using BudgetWeb.BLL;
using System.Data;
using BudgetWeb.Model;

public partial class WebPage_BudgetControl_MonPayPlanNew : BudgetBasePage
{
	protected void Page_Load(object sender, EventArgs e)
	{
        Session["NodeBC59"] = 0;
		Getmonth();
		if (Request.QueryString["Month"] != null && Request.QueryString["pici"] != null)
		{
			string str = Request.QueryString["Month"];
			string pi = Request.QueryString["pici"];
            if (str.Length==1)
            {
                str = "0" + str;
            }
			cmbmon.SelectedItem.Value = str;
			cmbpici.SelectedItem.Value = pi;
		}  
		if (!IsPostBack && !X.IsAjaxRequest)
		{
			getpici();
			Incomebalance.Style.Add("color", "red");
			Label3.Style.Add("color", "red");
            if (cmbmon.SelectedItem.Value == null)
            {
                string str= DateTime.Now.Month.ToString();
                if (str.Length==1)
                {
                    str = "0" + str;
                }
                cmbmon.SelectedItem.Value = str;
            }
            if (cmbpici.SelectedItem.Value == null)
            {
                cmbpici.SelectedItem.Value = MATimesBind().ToString();
            }
			gettotal();
			GetPIETotalBind();
			GetGridPaneltotal();
			//TextBind();
		}

		//GetGridPaneltotal();
	}
	[DirectMethod]
	public void TextBind()
	{
		if (Session["lbtotal2.Text"] != null)
		{
			lbtotal2.Text = ParToDecimal.ParToDel(Session["lbtotal2.Text"].ToString()).ToString("f2");
		}
		if (Session["lbtotal3.Text"] != null)
		{
			lbtotal3.Text = ParToDecimal.ParToDel(Session["lbtotal3.Text"].ToString()).ToString("f2");
		}
		if (Session["lbtotal4.Text"] != null)
		{
			lbtotal4.Text = ParToDecimal.ParToDel(Session["lbtotal4.Text"].ToString()).ToString("f2");
		}
		if (Session["lbtotal5.Text"] != null)
		{
			lbtotal5.Text = ParToDecimal.ParToDel(Session["lbtotal5.Text"].ToString()).ToString("f2");
		}
		Session["lbtotal2.Text"] = null;
		Session["lbtotal3.Text"] = null;
		Session["lbtotal4.Text"] = null;
		Session["lbtotal5.Text"] = null;
	}
	[DirectMethod]
	public void GetPIETotalBind()
	{
		 
		decimal t1 = 0, t2 = 0, t3 = 0,t4=0;
		string YearMonth = "";
		if (common.IntSafeConvert(cmbmon.SelectedItem.Value) > 0)
		{
			YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
		}
		else
		{
			YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
		}
		DataTable dtTable=new DataTable(); DataTable dt=new DataTable();
		DataTable dtTable1 = BG_MonPayPlanLogic.GetPIETotal(common.IntSafeConvert(CurrentYear), DepID);
		dtTable=getNewtotaldt(dtTable1);
		DataTable dt1 = BG_MonPayPlanLogic.GetMpFundingTotal(DepID, YearMonth);
		dt=getNewtotaldt1(dt1);
		DataTable dtedit=BG_MonPayPlanLogic.GetEiditeTotal(YearMonth,DepID,common.IntSafeConvert(cmbpici.SelectedItem.Value));
		if (dt.Rows.Count > 0)
		{
			for (int i = 0; i < 4; i++)
			{
				 
					Hidtotalapply.Value += ParseUtil.ToDecimal(dt.Rows[i]["Mon"].ToString(), 0) * 10000 + "*";
					t1 += ParseUtil.ToDecimal(dt.Rows[i]["Mon"].ToString(), 0) * 10000;
				

			}
		}
		else
		{
			Hidtotalapply.Value += 0 + "*" + 0 + "*" + 0 + "*" + 0 + "*";
		}
		if (dtTable.Rows.Count > 0)
		{
			for (int i = 0; i < dtTable.Rows.Count; i++)
			{
				
					Hidtotal.Value +=
						ParseUtil.ToDecimal(dtTable.Rows[i]["PIRtotal"].ToString(), 0) * 10000 + "*";
					t3 += ParseUtil.ToDecimal(dtTable.Rows[i]["PIRtotal"].ToString(), 0) * 10000;
				 
			}
		}
		else
		{
			Hidtotal.Value += 0 + "*" + 0 + "*" + 0 + "*" + 0 + "*";
		}
		if (dtedit.Rows.Count>0)
		{ 
			for (int i = 0; i < dtedit.Rows.Count; i++)
			{
				t4+=ParseUtil.ToDecimal(dtedit.Rows[i]["MPFundingAdd"].ToString(), 0) * 10000;
			}
		}
		t2 = t3 - t1;
		Session["lbtotal2.Text"] = t3.ToString();
		Session["lbtotal3.Text"] = t2.ToString();
		Session["lbtotal4.Text"] = t1.ToString();
		Session["lbtotal5.Text"] = t4.ToString();
		Hidtotalapply.Value.TrimEnd('*');
		Hidtotal.Value.TrimEnd('*');
	}
	private DataTable getNewtotaldt1(DataTable dtTable)
	{
		DataTable dtttttt=new DataTable();
		string listtmp = "1000,1015,1051,1065";
		if (dtTable.Rows.Count==4)
		{
			return dtTable;
		}
		for (int i = 0; i < dtTable.Rows.Count; i++)
		{
			string piidtmp = dtTable.Rows[i]["PIEcoSubParID"].ToString();
			//            if (piidtmp ==1000||piidtmp ==1015||piidtmp ==1051||piidtmp ==1065)
			//            {
			//                    
			//            }
			listtmp=listtmp.Replace(piidtmp, "");
		}
		string[] strlist = listtmp.Split(',');
		for (int i = 0; i < strlist.Length; i++)
		{
			if (common.IntSafeConvert(strlist[i])!=0)
			{
				DataRow dr= dtTable.NewRow();
				dr["PIEcoSubParID"] = strlist[i];
				dr["Mon"] = 0;
				dtTable.Rows.Add(dr);
			}
		}
		System.Data.DataView dv = dtTable.DefaultView;
		dv.Sort = "PIEcoSubParID asc";
		dtttttt = dv.ToTable(true);
		return dtttttt;
	}
	private DataTable getNewtotaldt(DataTable dtTable)
	{
		DataTable dtttttt=new DataTable();
		string listtmp = "1000,1015,1051,1065";
		if (dtTable.Rows.Count==4)
		{
			return dtTable;
		}
		for (int i = 0; i < dtTable.Rows.Count; i++)
		{
			string piidtmp = dtTable.Rows[i]["PIEcoSubParID"].ToString(); 
//            if (piidtmp ==1000||piidtmp ==1015||piidtmp ==1051||piidtmp ==1065)
//            {
//                    
//            }
			listtmp=listtmp.Replace(piidtmp, "");
		}
		string[] strlist = listtmp.Split(',');
		for (int i = 0; i < strlist.Length; i++)
		{
			if (common.IntSafeConvert(strlist[i])!=0)
			{
			   DataRow dr= dtTable.NewRow();
			   dr["PIEcoSubParID"] = strlist[i];
			   dr["PIRtotal"] = 0;
			   dtTable.Rows.Add(dr);
			}
		}
		System.Data.DataView dv = dtTable.DefaultView;
		dv.Sort = "PIEcoSubParID asc";
		dtttttt = dv.ToTable(true);
		return dtttttt;
	}

	private void Getmonth()
	{
		//DataTable dt = new DataTable();
		//dt.Columns.Add("month");
		//int mon = BG_MonPayPlanLogic.GetmonthbyMonPayPlan(DepID) + 1;

		//if (mon < 11)
		//{
		//    for (int i = mon; i > 0; i--)
		//    {
		//        DataRow dr = dt.NewRow();
		//        dr["month"] = "0" + i.ToString();
		//        dt.Rows.Add(dr);
		//    }
		//}
		//else
		//{
		//    for (int i = mon; i > 0; i--)
		//    {
		//        DataRow dr = dt.NewRow();
		//        dr["month"] = i.ToString();
		//        dt.Rows.Add(dr);
		//    }
		//}

		DataTable dt = new DataTable();
		dt.Columns.Add("month");
		for (int i = 1; i < 13; i++)
		{
			string t = i.ToString();
			if (i < 10)
			{
				t = "0" + i;
			}
			DataRow dr = dt.NewRow();
			dr["month"] = t;
			dt.Rows.Add(dr);
		}
		cmbmonstore.DataSource = dt;
		cmbmonstore.DataBind();
        
        
	}
	private bool ISNode(string NodeID)
	{
		bool valid = false;
		string PIEcoSubName = "";
		if (common.IntSafeConvert(NodeID) == 0)
		{
			valid = true;
		}
		else
		{
			if (BG_PayIncomeLogic.GetLeverByPIID(2))
			{
				return true;
			}
			//if (BG_PayIncomeLogic.GetBoolByPiid(common.IntSafeConvert(NodeID)))
			//{
			//    return true;
			//}
			PIEcoSubName = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(NodeID)).PIEcoSubName;
			string va = "";
			string temstr = Listallocationstr;
			string[] liststr = temstr.Split('*');
			for (int i = 0; i < liststr.Length; i++)
			{
				string[] temtt = liststr[i].Split(',');
				for (int j = 0; j < temtt.Length; j++)
				{
					va = temtt[j];
					if (PIEcoSubName == va.Trim())
					{
						valid = true;
					}
				}
			}
		}
		return valid;
	}

	private int SingleNode(string NodeID)
	{
		int t = 0;
		string tem;
		if (common.IntSafeConvert(NodeID) == 0)
		{
			if (NodeID == "PA")
			{
				if (Listallocationstr.Contains("财政拨款") && !Listallocationstr.Contains("其他资金"))
				{
					t = 2;
				}
				else if (Listallocationstr.Contains("其他资金") && !Listallocationstr.Contains("财政拨款"))
				{
					t = 1;
				}
				else
				{
					t = 3;
				}
			}
			if (NodeID == "nodeF")
			{
				if (Listallocationstr.Contains("基本支出") && !Listallocationstr.Contains("项目支出"))
				{
					t = 21;
				}
				else if (Listallocationstr.Contains("项目支出") && !Listallocationstr.Contains("基本支出"))
				{
					t = 22;
				}
				else
				{
					t = 23;
				}
			}
			if (NodeID == "nodeO")
			{
				if (Listallocationstr.Contains("基本支出") && !Listallocationstr.Contains("项目支出"))
				{
					t = 11;
				}
				else if (Listallocationstr.Contains("项目支出") && !Listallocationstr.Contains("基本支出"))
				{
					t = 12;
				}
				else
				{
					t = 13;
				}
			}
		}
		else
		{
			string name = BG_PayIncomeManager.GetBG_PayIncomeByPIID(common.IntSafeConvert(NodeID)).PIEcoSubName;
			if (Listallocationstr.Contains(name))
			{
				t = 1000;
			}
		}
		return t;
	}
	[DirectMethod]
	public string NodeLoad(string NodeID)
	{
		if (!ISNode(NodeID))
		{
			return "failure";
		}
		NodeCollection nodes = new NodeCollection();
		int tem = 1;
		int nodeID = common.IntSafeConvert(NodeID);
		string Financial_allocation = "财政拨款";
		string Other_funds = "其他资金";
		string BasicIncome = "基本支出";
		string ProjectIncome = "项目支出";
		Node rootNode = new Node();
		Node nodeO = new Node();
		Node nodeF = new Node();
		Node nodeFB = new Node();
		Node nodeFP = new Node();
		Node nodeOB = new Node();
		Node nodeOP = new Node();
		if (NodeID == "root")
		{
			rootNode.Text = "经济科目";
			rootNode.NodeID = "PA";
			rootNode.Icon = Icon.Folder;
			nodes.Add(rootNode);
			rootNode.Expanded = true;
		}
		else if (NodeID == "PA")
		{
			if (SingleNode(NodeID) == 2)
			{
				nodeF.NodeID = "nodeF";
				nodeF.Text = Financial_allocation;
				nodeF.Icon = Icon.Folder;
				nodes.Add(nodeF);
				nodeF.Expanded = true;
			}
			//else if (SingleNode(NodeID) == 1)
			//{
			//    nodeO.NodeID = "nodeO";
			//    nodeO.Text = Other_funds;
			//    nodeO.Icon = Icon.Folder;
			//    nodes.Add(nodeO);
			//    nodeO.Expanded = true;
			//}
			else if (SingleNode(NodeID) == 3)
			{
				nodeF.NodeID = "nodeF";
				nodeF.Text = Financial_allocation;
				nodeF.Icon = Icon.Folder;
				nodes.Add(nodeF);
				//nodeO.NodeID = "nodeO";
				//nodeO.Text = Other_funds;
				//nodeO.Icon = Icon.Folder;
				//nodes.Add(nodeO);
				//nodeO.Expanded = true;
				nodeF.Expanded = true;
			}
		}
		else if (NodeID == "nodeF")
		{
			//if (SingleNode(NodeID) == 21)
			//{
			//    nodeFB.NodeID = "nodeFB";
			//    nodeFB.Text = BasicIncome;
			//    nodeFB.Icon = Icon.Folder;
			//    nodes.Add(nodeFB);
			//    nodeFB.Expanded = true;
			//}
			//else if (SingleNode(NodeID) == 22)
			//{
			//    nodeFP.NodeID = "nodeFP";
			//    nodeFP.Text = ProjectIncome;
			//    nodeFP.Icon = Icon.Folder;
			//    nodes.Add(nodeFP);
			//    nodeFP.Expanded = true;
			//}
			//else if (SingleNode(NodeID) == 23)
			//{
			//    nodeFB.NodeID = "nodeFB";
			//    nodeFB.Text = BasicIncome;
			//    nodeFB.Icon = Icon.Folder;
			//    nodes.Add(nodeFB);

			//    nodeFP.NodeID = "nodeFP";
			//    nodeFP.Text = ProjectIncome;
			//    nodeFP.Icon = Icon.Folder;
			//    nodes.Add(nodeFP);
			//    nodeFB.Expanded = true;
			//    nodeFP.Expanded = true;
			//}
			nodeFB.NodeID = "nodeFB";
			nodeFB.Text = BasicIncome;
			nodeFB.Icon = Icon.Folder;
			nodes.Add(nodeFB);
			nodeFB.Expanded = true;
		}
		else if (NodeID == "nodeO")
		{
			if (SingleNode(NodeID) == 11)
			{
				nodeOB.NodeID = "nodeOB";
				nodeOB.Text = BasicIncome;
				nodeOB.Icon = Icon.Folder;
				nodes.Add(nodeOB);
				nodeOB.Expanded = true;
			}
			else if (SingleNode(NodeID) == 12)
			{
				nodeOP.NodeID = "nodeOP";
				nodeOP.Text = ProjectIncome;
				nodeOP.Icon = Icon.Folder;
				nodes.Add(nodeOP);
				nodeOP.Expanded = true;
			}
			else if (SingleNode(NodeID) == 13)
			{
				nodeOB.NodeID = "nodeOB";
				nodeOB.Text = BasicIncome;
				nodeOB.Icon = Icon.Folder;
				nodes.Add(nodeOB);
				nodeOP.NodeID = "nodeOP";
				nodeOP.Text = ProjectIncome;
				nodeOP.Icon = Icon.Folder;
				nodes.Add(nodeOP);
				nodeOB.Expanded = true;
				nodeOP.Expanded = true;
			}
		}
		else if (NodeID == "nodeFB")
		{
			SetNode(tem, Financial_allocation, BasicIncome, nodes);
		}
		//else if (NodeID == "nodeFP")
		//{
		//    SetNode(tem, Financial_allocation, ProjectIncome, nodes);
		//}
		//else if (NodeID == "nodeOB")
		//{
		//    SetNode(tem, Other_funds, BasicIncome, nodes);
		//}
		//else if (NodeID == "nodeOP")
		//{
		//    SetNode(tem, Other_funds, ProjectIncome, nodes);
		//}
		if (nodeID >= 1000)
		{
			SetNode(nodeID, nodes);
		}
		Session["Slist"] = HidSlist.Text;
		return nodes.ToJson();
	}
	List<int> listpiid = new List<int>();

	private void gettotal()
	{
		decimal total = 0;
		string YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
		DataTable dtpay = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), DepID);

		for (int i = 0; i < dtpay.Rows.Count; i++)
		{
			DataTable dtpiid = BG_PayIncomeLogic.GetBG_PayIncomeByname(dtpay.Rows[i][0].ToString());
			int piid = common.IntSafeConvert(dtpiid.Rows[0]["PIID"]); //支出项目ID
			total += ParToDecimal.ParToDel(dtpay.Rows[i][1].ToString()) + ParToDecimal.ParToDel(dtpay.Rows[i][2].ToString()) - BG_ApplyReimburLogic.GetARMon(piid, DepID, YearMonth);
		}
		total -= BG_MonPayPlanGenerateLogic.getAllMon(DepID, YearMonth);
		Incomebalance.Text = total.ToString("N") + "　万元";
	}

   

	private void SetNode(int tem, string ftype, string incomeinfo, NodeCollection node)
	{
		string YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
		DataTable dtpay = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), DepID);
		DataTable dtapply = BG_MonPayPlanGenerateLogic.GetMonPayTime(YearMonth, DepID,
			common.IntSafeConvert(cmbpici.SelectedItem.Value));
        DataTable dtapply1 = BG_MonPayPlanGenerateLogic.GetMonPayTime1(YearMonth, DepID,
            common.IntSafeConvert(cmbpici.SelectedItem.Value));
        string pici = cmbpici.SelectedItem.Value;
        string pici1 = cmbpici.RawValue.ToString();
        string pici2 = cmbpici.SelectedItem.Text;
        pici = pici1 == pici2 ? pici1 : pici2;

        decimal sq = BG_MonPayPlanGenerateLogic.GetsqMon(CurrentYear + "-" + cmbmon.SelectedItem.Value,
             DepID, common.IntSafeConvert(pici));
		if (Session["Slist"] != null && Session["Slist"].ToString() != "")
		{
			HidSlist.Text = Session["Slist"].ToString();
		}
		NodeCollection nodes = new NodeCollection();
		DataTable dt = BG_PayIncomeLogic.GetDtPayIncome(incomeinfo, ftype, tem);
		int year = common.IntSafeConvert(CurrentYear);
		decimal balance = 0;
		if (dt.Rows.Count > 0)
		{
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				int piid = common.IntSafeConvert(dt.Rows[j]["PIID"].ToString());
				Node nodeN = new Node();
				nodeN.NodeID = piid.ToString();
				nodeN.Text = dt.Rows[j]["PIEcoSubName"].ToString();
				string sql = string.Format("PIEcoSubName='{0}'", nodeN.Text);
				DataRow[] dr = dtpay.Select(sql);
				decimal Mon = 0;
				decimal MPFunding = 0;
				decimal MPFundingAdd = 0;
				if (dr.Length > 0)
				{
					for (int i = 0; i < dr.Length; i++)
					{
						Mon += ParToDecimal.ParToDel(dr[i]["BAAMon"].ToString()) +
							   ParToDecimal.ParToDel(dr[i]["SuppMon"].ToString());
					}
				}
				string MPRemark = "";
				sql = string.Format("PIID={0}", piid);
				DataRow[] drapply = dtapply.Select(sql);
				if (drapply.Length > 0)
				{
					MPRemark = drapply[0]["MPRemark"].ToString();
					for (int i = 0; i < drapply.Length; i++)
					{
						MPFunding += ParToDecimal.ParToDel(drapply[i]["MPFunding"].ToString());
//						MPFundingAdd += ParToDecimal.ParToDel(drapply[i]["MPFundingAdd"].ToString());
					}
				}
                DataRow[] drapply1 = dtapply1.Select(sql);
                if (drapply1.Length > 0)
                {
                    MPRemark = drapply1[0]["MPRemark"].ToString();
                    for (int i = 0; i < drapply1.Length; i++)
                    {
//                        MPFunding += ParToDecimal.ParToDel(drapply[i]["MPFunding"].ToString());
                        MPFundingAdd += ParToDecimal.ParToDel(drapply1[i]["MPFundingAdd"].ToString());
                    }
                }
				if (!BG_PayIncomeLogic.GetBoolPayIncome(incomeinfo, ftype, piid))
				{
					balance = Mon - MPFunding - BG_ApplyReimburLogic.GetARMon(piid, DepID, YearMonth);
					nodeN.Icon = Icon.Anchor;
					node.Add(nodeN);
					nodeN.Leaf = true;
					nodeN.CustomAttributes.Add(new ConfigItem("Mon",
						ParseUtil.ToDecimal((Mon*10000).ToString(), 0).ToString(), ParameterMode.Value));
					nodeN.CustomAttributes.Add(new ConfigItem("Balance",
						ParseUtil.ToDecimal((balance*10000).ToString(), 0).ToString(), ParameterMode.Value));
					nodeN.CustomAttributes.Add(new ConfigItem("MPFunding",
						ParseUtil.ToDecimal((MPFunding*10000).ToString(), 0).ToString(), ParameterMode.Value));
                    if (sq > 0)
                    {
                        nodeN.CustomAttributes.Add(new ConfigItem("MPFundingAdd",
                            ParseUtil.ToDecimal((MPFundingAdd * 10000).ToString(), 0).ToString(), ParameterMode.Value));
                    }
					nodeN.CustomAttributes.Add(new ConfigItem("MPRemark", MPRemark, ParameterMode.Value));

					listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
					SaveListIdStrs(listpiid);
					//SetNode(nodeID, nodes);
					//Session["slist"] = listpiid;
					//node.CustomAttributes.Add(new ConfigItem("BAAMon", CountBaamon.ToString(), ParameterMode.Value));
					//node.CustomAttributes.Add(new ConfigItem("SuppMon", CountSuppmon.ToString(), ParameterMode.Value));
					//nodeN.Checked = false; 
				}
				else
				{
					if (SingleNode(piid.ToString()) == 0)
					{
						break;
					}
					else if (BG_PayIncomeLogic.ISSign(piid))
					{
						balance = Mon - MPFunding - BG_ApplyReimburLogic.GetARMon(piid, DepID, YearMonth);
						nodeN.Leaf = true;
						nodeN.Icon = Icon.Anchor;
						node.Add(nodeN);
						nodeN.CustomAttributes.Add(new ConfigItem("Mon",
							ParseUtil.ToDecimal((Mon*10000).ToString(), 0).ToString(), ParameterMode.Value));
						nodeN.CustomAttributes.Add(new ConfigItem("Balance",
							ParseUtil.ToDecimal((balance*10000).ToString(), 0).ToString(), ParameterMode.Value));
						nodeN.CustomAttributes.Add(new ConfigItem("MPFunding",
							ParseUtil.ToDecimal((MPFunding*10000).ToString(), 0).ToString(), ParameterMode.Value));
                        if (sq > 0)
                        {
                            nodeN.CustomAttributes.Add(new ConfigItem("MPFundingAdd",
                                ParseUtil.ToDecimal((MPFundingAdd * 10000).ToString(), 0).ToString(), ParameterMode.Value));
                        }
						nodeN.CustomAttributes.Add(new ConfigItem("MPRemark", MPRemark, ParameterMode.Value));

						listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
						SaveListIdStrs(listpiid);
						//Session["slist"] = listpiid;
					}
					else
					{
						nodeN.Icon = Icon.Folder;
						node.Add(nodeN);
						//listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
						//SaveListIdStrs(listpiid);
					}
					//11
					//nodeN.Expanded = true;
					//nodeN.CustomAttributes.Add(new ConfigItem("BAAMon", CountBaamon.ToString(), ParameterMode.Value));
					//nodeN.CustomAttributes.Add(new ConfigItem("SuppMon", CountSuppmon.ToString(), ParameterMode.Value));
					//CountBaamon = 0;
					//CountSuppmon = 0;
				}
				//SetNode(piid, ftype, incomeinfo, nodeN);
				//node.Children.Add(nodeN); 
				//SetNode(piid, ftype, incomeinfo, nodeN);
			}

		}
		GetGridPaneltotal();
	}





	#region 展开代码

	private void SetNode(int tem, NodeCollection node)
	{ 
		string pici = cmbpici.SelectedItem.Value;
		string pici1 = cmbpici.RawValue.ToString();
		string pici2 = cmbpici.SelectedItem.Text;
		pici = pici1 == pici2 ? pici1 : pici2;
	   
		decimal sq = BG_MonPayPlanGenerateLogic.GetsqMon(CurrentYear + "-" + cmbmon.SelectedItem.Value,
			 DepID, common.IntSafeConvert(pici));
//        if (sq > 0)
//        {
//            
//        }
 


		Session["lbtotal5.Text"] = 0;
		string YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
		DataTable dtpay = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), DepID);
		DataTable dtapply = BG_MonPayPlanGenerateLogic.GetMonPayTime(YearMonth, DepID,
			common.IntSafeConvert(cmbpici.SelectedItem.Value));
        DataTable dtapply1 = BG_MonPayPlanGenerateLogic.GetMonPayTime1(YearMonth, DepID,
          common.IntSafeConvert(cmbpici.SelectedItem.Value));
		NodeCollection nodes = new NodeCollection();
		DataTable dt = BG_PayIncomeLogic.GetDtPayIncomeByPIID(tem);
		int year = common.IntSafeConvert(CurrentYear);
		decimal balance = 0;
		if (dt.Rows.Count > 0)
		{
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				int piid = common.IntSafeConvert(dt.Rows[j]["PIID"].ToString());
				Node nodeN = new Node();
				nodeN.NodeID = piid.ToString();
				nodeN.Text = dt.Rows[j]["PIEcoSubName"].ToString();
				string sql = string.Format("PIEcoSubName='{0}'", nodeN.Text);
				DataRow[] dr = dtpay.Select(sql);
				string MPRemark = "";
				decimal Mon = 0;
				decimal MPFunding = 0;
				decimal MPFundingAdd = 0;
				if (dr.Length > 0)
				{
					for (int i = 0; i < dr.Length; i++)
					{
						Mon += ParToDecimal.ParToDel(dr[i]["BAAMon"].ToString()) +
							   ParToDecimal.ParToDel(dr[i]["SuppMon"].ToString());
					}
				}
				sql = string.Format("PIID={0}", piid);
                DataRow[] drapply = dtapply.Select(sql);
                if (drapply.Length > 0)
                {
                    MPRemark = drapply[0]["MPRemark"].ToString();
                    for (int i = 0; i < drapply.Length; i++)
                    {
                        MPFunding += ParToDecimal.ParToDel(drapply[i]["MPFunding"].ToString());
                        //						MPFundingAdd += ParToDecimal.ParToDel(drapply[i]["MPFundingAdd"].ToString());
                    }
                }
                DataRow[] drapply1 = dtapply1.Select(sql);
                if (drapply1.Length > 0)
                {
                    MPRemark = drapply1[0]["MPRemark"].ToString();
                    for (int i = 0; i < drapply1.Length; i++)
                    {
                        //                        MPFunding += ParToDecimal.ParToDel(drapply[i]["MPFunding"].ToString());
                        MPFundingAdd += ParToDecimal.ParToDel(drapply1[i]["MPFundingAdd"].ToString());
                    }
                }

				if (BG_PayIncomeLogic.GetBoolPayIncomeByPIID(tem))
				{

					if (!BG_PayIncomeLogic.GetBoolPayIncomeByPIID(common.IntSafeConvert(piid)))
					{
						balance = Mon - MPFunding - BG_ApplyReimburLogic.GetARMon(piid, DepID, YearMonth);
						nodeN.Icon = Icon.Anchor;
						node.Add(nodeN);
						nodeN.Leaf = true;
						nodeN.CustomAttributes.Add(new ConfigItem("Mon",
							ParseUtil.ToDecimal((Mon*10000).ToString(), 0).ToString(), ParameterMode.Value));
						nodeN.CustomAttributes.Add(new ConfigItem("Balance",
							ParseUtil.ToDecimal((balance*10000).ToString(), 0).ToString(), ParameterMode.Value));
						nodeN.CustomAttributes.Add(new ConfigItem("MPFunding",
							ParseUtil.ToDecimal((MPFunding*10000).ToString(), 0).ToString(), ParameterMode.Value)); 
						if (sq > 0)
						{ 
						    nodeN.CustomAttributes.Add(new ConfigItem("MPFundingAdd",
							ParseUtil.ToDecimal((MPFundingAdd*10000).ToString(), 0).ToString(), ParameterMode.Value));
						}
						nodeN.CustomAttributes.Add(new ConfigItem("MPRemark", MPRemark, ParameterMode.Value));
						listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
						SaveListIdStrs(listpiid);
					}
					else
					{
						if (BG_PayIncomeLogic.GetLever(3))
						{
							balance = Mon - MPFunding - BG_ApplyReimburLogic.GetARMon(piid, DepID, YearMonth);
							nodeN.Icon = Icon.Anchor;
							node.Add(nodeN);
							nodeN.Leaf = true;
							nodeN.CustomAttributes.Add(new ConfigItem("Mon",
								ParseUtil.ToDecimal((Mon*10000).ToString(), 0).ToString(), ParameterMode.Value));
							nodeN.CustomAttributes.Add(new ConfigItem("Balance",
								ParseUtil.ToDecimal((balance*10000).ToString(), 0).ToString(), ParameterMode.Value));
							nodeN.CustomAttributes.Add(new ConfigItem("MPFunding",
								ParseUtil.ToDecimal((MPFunding*10000).ToString(), 0).ToString(), ParameterMode.Value));
						    if (sq > 0)
						    {
						        nodeN.CustomAttributes.Add(new ConfigItem("MPFundingAdd",
						            ParseUtil.ToDecimal((MPFundingAdd*10000).ToString(), 0).ToString(), ParameterMode.Value));
						    }
						    nodeN.CustomAttributes.Add(new ConfigItem("MPRemark", MPRemark, ParameterMode.Value));
							listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
							SaveListIdStrs(listpiid);
						}
						else
						{
							nodeN.Icon = Icon.Folder;
							node.Add(nodeN);
							//listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
							//SaveListIdStrs(listpiid);
						}
					}

					// Session["slist"] = listpiid;
					//node.CustomAttributes.Add(new ConfigItem("BAAMon", CountBaamon.ToString(), ParameterMode.Value));
					//node.CustomAttributes.Add(new ConfigItem("SuppMon", CountSuppmon.ToString(), ParameterMode.Value));
					//nodeN.Checked = false; 
				}
				else
				{
					if (SingleNode(piid.ToString()) == 0)
					{
						break;
					}
					else if (BG_PayIncomeLogic.ISSign(piid))
					{
						balance = Mon - MPFunding - BG_ApplyReimburLogic.GetARMon(piid, DepID, YearMonth);
						nodeN.Leaf = true;
						nodeN.Icon = Icon.Anchor;
						node.Add(nodeN);
						nodeN.CustomAttributes.Add(new ConfigItem("Mon",
							ParseUtil.ToDecimal((Mon*10000).ToString(), 0).ToString(), ParameterMode.Value));
						nodeN.CustomAttributes.Add(new ConfigItem("Balance",
							ParseUtil.ToDecimal((balance*10000).ToString(), 0).ToString(), ParameterMode.Value));
						nodeN.CustomAttributes.Add(new ConfigItem("MPFunding",
							ParseUtil.ToDecimal((MPFunding*10000).ToString(), 0).ToString(), ParameterMode.Value));
					    if (sq > 0)
					    {
					        nodeN.CustomAttributes.Add(new ConfigItem("MPFundingAdd",
					            ParseUtil.ToDecimal((MPFundingAdd*10000).ToString(), 0).ToString(), ParameterMode.Value));
					        nodeN.CustomAttributes.Add(new ConfigItem("MPRemark", MPRemark, ParameterMode.Value));
					    }
					    listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
						SaveListIdStrs(listpiid);
						//Session["slist"] = listpiid;
					}
					else
					{
						nodeN.Icon = Icon.Folder;
						node.Add(nodeN);
						listpiid.Add(common.IntSafeConvert(nodeN.NodeID));
						SaveListIdStrs(listpiid);
					}


					//nodeN.Expanded = true;
					//nodeN.CustomAttributes.Add(new ConfigItem("BAAMon", CountBaamon.ToString(), ParameterMode.Value));
					//nodeN.CustomAttributes.Add(new ConfigItem("SuppMon", CountSuppmon.ToString(), ParameterMode.Value));
					//CountBaamon = 0;
					//CountSuppmon = 0;
				}
				//SetNode(piid, ftype, incomeinfo, nodeN);
				//node.Children.Add(nodeN); 
				//SetNode(piid, ftype, incomeinfo, nodeN);
			}
		}

	}

	#endregion


	private void SaveListIdStrs(List<int> lstTmp)
	{
		for (int i = 0; i < lstTmp.Count; i++)
		{
			HidSlist.Text += lstTmp[i].ToString() + "&";
		}
	}

	protected void RemoteEdit(object sender, RemoteEditEventArgs e)
	{
		string pici = cmbpici.SelectedItem.Value;
		string pici1 = cmbpici.RawValue.ToString();
		string pici2 = cmbpici.SelectedItem.Text;
		pici = pici1 == pici2 ? pici1 : pici2;
		string yearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
		if (hidflag.Text == "1")
		{
			X.Msg.Alert("申请月度用款计划", yearMonth + "月已经提交，不允许修改").Show();
			return;
		}
		e.Accept = true;
		string[] idStrArr = HidSlist.Text.ToString().TrimEnd('&').Split('&');
		List<int> slist = new List<int>();
		foreach (string item in idStrArr)
		{
			int IntId = common.IntSafeConvert(item);
			if (!slist.Contains(IntId))
			{
				slist.Add(IntId);
			}
		}
		int piid = common.IntSafeConvert(e.NodeID);
		RowChanges rc = e.Changes[0];
		//if (rc.Value<float>() <= 0 && rc.OldValue<float>() <= 0)
		//{
		//    X.Msg.Alert("提示", "填写数字不能为0").Show();
		//    return;
		//} 
		if (e.Json == null)
		{
			return;
		}

		if (!slist.Contains(piid))
		{
			rc.SetValue("");
			X.Msg.Alert("提示", "此处不可填写,请填写到正确位置").Show();
			return;
		}
		else
		{ 
			decimal newValue = 0;
			decimal oldValue = 0;
			decimal balance = 0;
			decimal MPFundingAdd = 0;
			decimal Mon = 0;
			DataTable dt = BG_MonPayPlanLogic.GetMpFunding(piid, DepID, yearMonth, common.IntSafeConvert(pici));

			if (rc.Field == "MPRemark")
			{
				if (!rc.IsDirty<string>())
				{
					return;
				}
				if (dt.Rows.Count > 0)
				{
					int CPID = common.IntSafeConvert(dt.Rows[0][0]);
					BG_MonPayPlan mp = BG_MonPayPlanManager.GetBG_MonPayPlanByCPID(CPID);
					mp.MPRemark = rc.Value<string>();
					BG_MonPayPlanManager.ModifyBG_MonPayPlan(mp);
				}
				else
				{
					BG_MonPayPlan mp = new BG_MonPayPlan();
					mp.MPRemark = rc.Value<string>();
					mp.DeptID = DepID;
					mp.PIID = piid;
					mp.MPFundingAdd = 0;
					mp.MPTime = Convert.ToDateTime(CurrentYear + "-" + cmbmon.SelectedItem.Value + "-01");
					BG_MonPayPlanManager.AddBG_MonPayPlan(mp);

				}
				return;
			}
			DataTable dtdevide = BG_MonPayPlanGenerateLogic.GetMonPay(common.IntSafeConvert(CurrentYear), DepID);
			string PIEcoSubName = "";
			PIEcoSubName = BG_PayIncomeManager.GetBG_PayIncomeByPIID(piid).PIEcoSubName;
			string sql = string.Format("PIEcoSubName='{0}'", PIEcoSubName);
			DataRow[] drdevide = dtdevide.Select(sql);
			if (drdevide.Length > 0)
			{
				for (int i = 0; i < drdevide.Length; i++)
				{
					Mon += ParToDecimal.ParToDel(drdevide[i]["BAAMon"].ToString()) + ParToDecimal.ParToDel(drdevide[i]["SuppMon"].ToString());
				}
			}

			sql = string.Format("PIID={0}", piid);
			DataRow[] dr = dt.Select(sql);

			if (dr.Length > 0)
			{
				for (int i = 0; i < dr.Length; i++)
				{
					MPFundingAdd += ParToDecimal.ParToDel(dr[i]["MPFundingAdd"].ToString());
				}
			}
			newValue = ParseUtil.ToDecimal(rc.Value<float>().ToString(), 0);
			oldValue = ParseUtil.ToDecimal(rc.OldValue<float>().ToString(), 0);
            //if (newValue==0)
            //{
            //    BG_MonPayPlan mppalert = new BG_MonPayPlan();
            //    mppalert = BG_MonPayPlanManager.GetBG_MonPayPlanByCPID(CPID);
            //    mppalert.MPFundingAdd = newValue / 10000;
            //    mppalert.MPFunding = mppalert.MPFunding + (newValue) / 10000 - oldValue / 10000;
            //    mppalert.MPFundingAddTimes = common.IntSafeConvert(cmbpici.SelectedItem.Value);
            //    BG_MonPayPlanManager.ModifyBG_MonPayPlan(mppalert);
            //    string message = "<b>科目:</b> {0}<br /><b>原经费:</b> {1}<br /><b>更改经费:</b> {2}";
            //    X.Msg.Notify(new NotificationConfig()
            //    {
            //        Title = "申请月度用款计划",
            //        Html = string.Format(message, PIEcoSubName, oldValue, newValue),
            //        Width = 250
            //    }).Show();
            //    return;
            //}
			balance = Mon - MPFundingAdd;
			if (dt.Rows.Count > 0)
			{
				int CPID = common.IntSafeConvert(dt.Rows[0][0]);
				BG_MonPayPlan mp = BG_MonPayPlanManager.GetBG_MonPayPlanByCPID(CPID);
				foreach (RowChanges change in e.Changes)
				{
					if (change.Field == "MPFundingAdd" && change.IsDirty<float>())
					{
						if (mp.MPFunding + newValue > Mon * 10000)
						{
							X.Msg.Alert("申请月度用款计划", "科目：" + PIEcoSubName + "经费不足，请调整经费").Show();
							return;
						}
						mp.MPFundingAdd = newValue;
						if (hidflag.Text == "2" || hidflag.Text == "3")
						{
							string message = "<b>科目:</b> {0}<br /><b>原经费:</b> {1}<br /><b>更改经费:</b> {2}";
							//if (oldValue > newValue)
							//{
							//    //X.Msg.Alert("提示", "修改提交或审核通过的经费必须大于现经费").Show();
							//    //rc.SetValue(rc.OldValue<float>());
							//    //return;
							//}
							//else
							//{
							BG_MonPayPlan mppalert = new BG_MonPayPlan();
							mppalert = BG_MonPayPlanManager.GetBG_MonPayPlanByCPID(CPID);
							mppalert.MPFundingAdd = newValue / 10000;
							mppalert.MPFunding = mppalert.MPFunding + (newValue) / 10000- oldValue / 10000 ;
							mppalert.MPFundingAddTimes = common.IntSafeConvert(cmbpici.SelectedItem.Value);
							BG_MonPayPlanManager.ModifyBG_MonPayPlan(mppalert);
//							BG_MonPayPlan_His bgMonPayPlanHis = new BG_MonPayPlan_His();
//							bgMonPayPlanHis.CPID = CPID;
//							bgMonPayPlanHis.DeptID = mppalert.DeptID;
//							bgMonPayPlanHis.MPFunding = mppalert.MPFunding;
//							bgMonPayPlanHis.MPPHisTime = DateTime.Now;
//							bgMonPayPlanHis.PIID = mppalert.PIID;
//							bgMonPayPlanHis.MPRemark = "修改";
//							bgMonPayPlanHis.MPFundingAdd = mppalert.MPFundingAdd;
//							bgMonPayPlanHis.MPTime = mppalert.MPTime;
//							bgMonPayPlanHis.MPFundingAddTimes = mppalert.MPFundingAddTimes;
//							if (BG_MonPayPlan_HisManager.AddBG_MonPayPlan_His(bgMonPayPlanHis).MPPHis > 0)
//							{
//								GetGridPaneltotal();
//							}
							X.Msg.Notify(new NotificationConfig()
							{
								Title = "申请月度用款计划",
								Html = string.Format(message, PIEcoSubName, oldValue, newValue),
								Width = 250
							}).Show();
							//return;
							//}

						}
						else if (hidflag.Text == "1")
						{
							X.Msg.Alert("申请月度用款计划", yearMonth + "月已经提交，不允许修改").Show();
							rc.SetValue(rc.OldValue<float>());
							return;
						}
						else if (hidflag.Text == "0")
						{
							string message = "<b>科目:</b> {0}<br /><b>原经费:</b> {1}<br /><b>更改经费:</b> {2}";
							BG_MonPayPlan mpp = new BG_MonPayPlan();
							mpp = BG_MonPayPlanManager.GetBG_MonPayPlanByCPID(CPID);
							if (mpp != null)
							{
								mpp.MPFundingAdd = newValue / 10000;
								mpp.MPFunding = mpp.MPFunding + (newValue) / 10000- oldValue / 10000 ;
								mpp.MPFundingAddTimes = common.IntSafeConvert(cmbpici.SelectedItem.Value);
								BG_MonPayPlanManager.ModifyBG_MonPayPlan(mpp);
//								if (mpp.CPID > 0)
//								{
//									BG_MonPayPlan_His bgMonPayPlanHis = new BG_MonPayPlan_His();
//									bgMonPayPlanHis.CPID = mpp.CPID;
//									bgMonPayPlanHis.DeptID = mpp.DeptID;
//									bgMonPayPlanHis.MPFunding = mpp.MPFunding;
//									bgMonPayPlanHis.MPPHisTime = DateTime.Now;
//									bgMonPayPlanHis.PIID = mpp.PIID;
//									bgMonPayPlanHis.MPRemark = "修改";
//									bgMonPayPlanHis.MPFundingAdd = mpp.MPFundingAdd;
//									bgMonPayPlanHis.MPTime = mpp.MPTime;
//									bgMonPayPlanHis.MPFundingAddTimes = mpp.MPFundingAddTimes;
//									if (BG_MonPayPlan_HisManager.AddBG_MonPayPlan_His(bgMonPayPlanHis).MPPHis > 0)
//									{
//										GetGridPaneltotal();
//									}
//								}
								X.Msg.Notify(new NotificationConfig()
								{
									Title = "申请月度用款计划",
									Html = string.Format(message, PIEcoSubName, oldValue, newValue),
									Width = 250
								}).Show();
							}
							else
							{
								mpp.MPRemark = "";
								mpp.DeptID = DepID;
								mpp.PIID = piid;
								mpp.MPFundingAdd = newValue / 10000;
								mpp.MPFunding += newValue / 10000;
								mpp.MPTime = Convert.ToDateTime(CurrentYear + "-" + cmbmon.SelectedItem.Value + "-01");
								mpp.MPFundingAddTimes = common.IntSafeConvert(cmbpici.SelectedItem.Value);
							    BG_MonPayPlanManager.AddBG_MonPayPlan(mpp);
//								int cpid = BG_MonPayPlanManager.AddBG_MonPayPlan(mpp).CPID;
//								if (cpid > 0)
//								{
//									BG_MonPayPlan_His bgMonPayPlanHis = new BG_MonPayPlan_His();
//									bgMonPayPlanHis.CPID = cpid;
//									bgMonPayPlanHis.DeptID = mpp.DeptID;
//									bgMonPayPlanHis.MPFunding = mpp.MPFunding;
//									bgMonPayPlanHis.MPPHisTime = DateTime.Now;
//									bgMonPayPlanHis.PIID = mpp.PIID;
//									bgMonPayPlanHis.MPRemark = "添加";
//									bgMonPayPlanHis.MPFundingAdd = mpp.MPFundingAdd;
//									bgMonPayPlanHis.MPTime = mpp.MPTime;
//									bgMonPayPlanHis.MPFundingAddTimes = mpp.MPFundingAddTimes;
//									if (BG_MonPayPlan_HisManager.AddBG_MonPayPlan_His(bgMonPayPlanHis).MPPHis > 0)
//									{
//										GetGridPaneltotal();
//									}
//								}
								X.Msg.Notify(new NotificationConfig()
								{
									Title = "申请月度用款计划",
									Html = string.Format(message, PIEcoSubName, oldValue, newValue),
									Width = 250
								}).Show();
							}
						}
					}
				}
			}
			else
			{
				if (newValue > Mon * 10000)
				{
					X.Msg.Alert("申请月度用款计划", "科目：" + PIEcoSubName + "经费不足，请调整经费").Show();
					return;
				}
				string message = "<b>科目:</b> {0}<br /><b>原经费:</b> {1}<br /><b>更改经费:</b> {2}";
				BG_MonPayPlan mpp = new BG_MonPayPlan();
				mpp.DeptID = DepID;
				mpp.PIID = piid;
				mpp.MPFundingAdd = newValue / 10000;
				mpp.MPFunding += newValue / 10000;
				mpp.MPTime = Convert.ToDateTime(CurrentYear + "-" + cmbmon.SelectedItem.Value + "-01");
				mpp.MPFundingAddTimes = 1;
				mpp.MPFundingAddTimes = common.IntSafeConvert(cmbpici.SelectedItem.Value);
			    BG_MonPayPlanManager.AddBG_MonPayPlan(mpp);
//				int cpid = BG_MonPayPlanManager.AddBG_MonPayPlan(mpp).CPID;
//				if (cpid > 0)
//				{
//					BG_MonPayPlan_His bgMonPayPlanHis = new BG_MonPayPlan_His();
//					bgMonPayPlanHis.CPID = cpid;
//					bgMonPayPlanHis.DeptID = mpp.DeptID;
//					bgMonPayPlanHis.MPFunding = mpp.MPFunding;
//					bgMonPayPlanHis.MPPHisTime = DateTime.Now;
//					bgMonPayPlanHis.PIID = mpp.PIID;
//					bgMonPayPlanHis.MPRemark = "添加";
//					bgMonPayPlanHis.MPFundingAdd = mpp.MPFundingAdd;
//					bgMonPayPlanHis.MPTime = mpp.MPTime;
//					bgMonPayPlanHis.MPFundingAddTimes = mpp.MPFundingAddTimes;
//					if (BG_MonPayPlan_HisManager.AddBG_MonPayPlan_His(bgMonPayPlanHis).MPPHis > 0)
//					{
//						GetGridPaneltotal();
//					}
//
//				}
				hidflag.Text = "2";
				X.Msg.Notify(new NotificationConfig()
				{
					Title = "申请月度用款计划",
					Html = string.Format(message, PIEcoSubName, oldValue, newValue),
					Width = 250
				}).Show();

			}
		}
		gettotal();
		TPPlan.Listeners.AddScript("GettatolMon();");

	}

	private void GetGridPaneltotal()
	{
		string YearMonth = "";
		if (common.IntSafeConvert(cmbmon.SelectedItem.Value) > 0)
		{
			YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
		}
		else
		{
			YearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
		}
        DataTable dt = BG_SelMonPayPlanLogic.GetMonPayPlanTotal(DepID, YearMonth);
	    GetNewtatol(dt);
		GTPHisStore.DataSource = dt;
		GTPHisStore.DataBind();
	}

	private void GetNewtatol(DataTable dt)
	{
        decimal mon = 0, mon1 = 0, mon2 = 0, mon3 = 0, mon4 = 0, mon5 = 0;
		for (int i = 0; i < dt.Rows.Count; i++)
		{
            mon += ParseUtil.ToDecimal(dt.Rows[i]["MPFunding"].ToString(), 0);
//			int psub = common.IntSafeConvert(dt.Rows[i]["ParentPIEcoSubName"]);
//			if (psub > 0)
//			{
//				if (psub == 1000 || psub == 1015 || psub == 1051 || psub == 1065)
//				{
//					dt.Rows[i]["ParentPIEcoSubName"] = BG_PayIncomeManager.GetBG_PayIncomeByPIID(psub).PIEcoSubName;
//					dt.Rows[i]["PIEcoSubName"] = BG_PayIncomeManager.GetBG_PayIncomeByPIID(psub).PIEcoSubName;
//				}
//			}
            if (dt.Rows[i]["weitijiao"].ToString()=="1")
            {
                mon1 += ParseUtil.ToDecimal(dt.Rows[i]["MPFunding"].ToString(),0);
            }
            if (dt.Rows[i]["tijiao"].ToString()=="1")
            {
                mon2 += ParseUtil.ToDecimal(dt.Rows[i]["MPFunding"].ToString(), 0);
            }
            if (dt.Rows[i]["shenhetongguo"].ToString()=="1")
            {
                mon3 += ParseUtil.ToDecimal(dt.Rows[i]["MPFunding"].ToString(), 0);
            }
            if (dt.Rows[i]["shenhebutongguo"].ToString()=="1")
            {
                mon4 += ParseUtil.ToDecimal(dt.Rows[i]["MPFunding"].ToString(), 0);
            }
            if (dt.Rows[i]["tuihui"].ToString()=="1")
            {
                mon5 += ParseUtil.ToDecimal(dt.Rows[i]["MPFunding"].ToString(), 0);

            }
		} 
	     
        TF2.Text=  mon1.ToString();
        TF3.Text=  mon2.ToString();
        TF4.Text = mon3.ToString();
        TF5.Text = mon4.ToString();
        TF6.Text = mon5.ToString();
        TF7.Text = mon.ToString(); 
	}
    [DirectMethod]
    public void DB(string pici)
    {
        string month = "";
        //        month = common.IntSafeConvert(cmbmon.SelectedItem.Value) + 1 < 10
        //            ? "0" + (common.IntSafeConvert(cmbmon.SelectedItem.Value) + 1)
        //            : (common.IntSafeConvert(cmbmon.SelectedItem.Value) + 1).ToString();
        month = cmbmon.SelectedItem.Value.ToString();
        if (pici != cmbpici.SelectedItem.Value.ToString())
        { 
            Response.Redirect("MonPayPlanNew.aspx?Month=" + month + "&" + "pici=" + pici.ToString(), true);
            cmbpici.RawValue =pici.ToString();
        } 
    }
	protected void cmbmon_DirectChange(object sender, DirectEventArgs e)
	{
		Ifuseeditinfo();

	}
	private bool Ifuseeditinfo()
	{
		string pici = cmbpici.SelectedItem.Value;
		string pici1 = cmbpici.RawValue.ToString();
		string pici2 = cmbpici.SelectedItem.Text;
		pici = pici1 == pici2 ? pici1 : pici2;
		string yearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
		if (BG_MonPayPlanRemarkLogic.IsRemark(DepID, yearMonth, common.IntSafeConvert(pici)))
		{
			btnsubmit.Hidden = true;
			hidflag.Text = "1";
			NFeditor.Disable(true);
			if (BG_MonPayPlanGenerateLogic.IsAuditMonPay(yearMonth, DepID, common.IntSafeConvert(pici)))
			{

				//X.Msg.Confirm("申请月度用款计划", yearMonth + "月已经审核通过，是否确定要修改").Show();
				X.Msg.Alert("申请月度用款计划", yearMonth + "月已经审核通过,无法修改,如需修改,请在下批次追加.").Show();
				//X.Msg.Confirm("申请月度用款计划", yearMonth + "月已经审核通过，是否确定要修改?", new MessageBoxButtonsConfig
				//{
				//    Yes = new MessageBoxButtonConfig
				//    {
				//        Handler = "XX.DoYes()",
				//        Text = "是"
				//    },
				//    No = new MessageBoxButtonConfig
				//    {
				//        Handler = "XX.DoNo()",
				//        Text = "否"
				//    }
                //}).Show();
                Session["NodeBC59"] = 1;
				return false;
			}
			else if (BG_MonPayPlanGenerateLogic.IsSubmitMonPay(yearMonth, DepID, common.IntSafeConvert(pici)))
			{

				X.Msg.Alert("申请月度用款计划", yearMonth + "月已经提交给局领导,无法修改,如需修改,请在下批次追加.").Show();
				//X.Msg.Confirm("申请月度用款计划", yearMonth + "月已经提交给局领导，是否确定要修改?", new MessageBoxButtonsConfig
				//{
				//    Yes = new MessageBoxButtonConfig
				//    {
				//        Handler = "XX.DoYes()",
				//        Text = "是"
				//    },
				//    No = new MessageBoxButtonConfig
				//    {
				//        Handler = "XX.DoNo()",
				//        Text = "否"
				//    }
				//}).Show();
                Session["NodeBC59"] = 1;
				return false;
			}
			else if (BG_MonPayPlanGenerateLogic.ISMonlatePay(yearMonth, DepID, common.IntSafeConvert(pici)))
			{

				//X.Msg.Alert("申请月度用款计划", yearMonth + "月已经提交，是否确定要修改").Show();
				string msg = string.Format("月已经被财务室退回（{0}），请核实数据后修改?", BG_MonPayPlanGenerateLogic.MonlatePayCause(yearMonth, DepID));
				X.Msg.Confirm("申请月度用款计划", yearMonth + msg, new MessageBoxButtonsConfig
				{
					Yes = new MessageBoxButtonConfig
					{
						Handler = "SS.DoYesSSS()",
						Text = "确定"
					}
				}).Show();
                Session["NodeBC59"] = 1;
				return true;
			}
		}
		else
		{
			hidflag.Text = "0";
            Session["NodeBC59"] = 0;
			NFeditor.Enable(true);
			btnsubmit.Hidden = false;
            Session["NodeBC59"] = 0;
			Getmonth();
			return false;
		}
		return true;
	}
	[DirectMethod]
	public void GetPagedirect()
	{
		string month = "";
		//        month = common.IntSafeConvert(cmbmon.SelectedItem.Value) + 1 < 10
		//            ? "0" + (common.IntSafeConvert(cmbmon.SelectedItem.Value) + 1)
		//            : (common.IntSafeConvert(cmbmon.SelectedItem.Value) + 1).ToString();
		month = cmbmon.SelectedItem.Value.ToString();
		string pici = cmbpici.SelectedItem.Value;
		string pici1 = cmbpici.RawValue.ToString();
		string pici2 = cmbpici.SelectedItem.Text;
		pici = pici1 == pici2 ? pici1 : pici2;
		if (pici == MATimesBind().ToString())
		{
			cmbpici.SelectedItem.Value = MATimesBind().ToString();
			Response.Redirect("MonPayPlanNew.aspx?Month=" + month + "&" + "pici=" + cmbpici.SelectedItem.Value, true);
		}
		else
		{
			//if (common.IntSafeConvert(MATimesBind().ToString()) < common.IntSafeConvert(cmbpici.SelectedItem.Value))
			//{
			//    X.Msg.Alert("系统提示", "所选批次不可编辑.").Show();
			//}
			if (Ifuseeditinfo())
			{
				Response.Redirect("MonPayPlanNew.aspx?Month=" + month + "&" + "pici=" + cmbpici.SelectedItem.Value, true);
			}
			else
			{
				if (common.IntSafeConvert(pici) > common.IntSafeConvert(MATimesBind().ToString())) { X.Msg.Alert("系统提示", "所选批次不可编辑.").Show(); }
				cmbpici.RawValue = MATimesBind().ToString();
			}
		}

	}

	[DirectMethod]
	public void GetTPPlan()
	{
		TPPlan.Enable(true);
	}
	[DirectMethod(Namespace = "XX")]
	public void DoYes()
	{
		hidflag.Text = "3";
		NFeditor.Enable(true);
		Getmonth();
		btnsubmit.Show();
	}

	[DirectMethod(Namespace = "SS")]
	public void DoYesSSS()
	{
		hidflag.Text = "2";
		NFeditor.Enable(true);
        Session["NodeBC59"] = 0;
		btnsubmit.Show();
	}
	[DirectMethod(Namespace = "XX")]
	public void DoNo()
	{
		Getmonth();
	}

	private void getpici()
	{
		for (int i = 0; i < 20; i++)
		{
			cmbpici.Items.Add(new Ext.Net.ListItem((i + 1).ToString(), (i + 1).ToString()));
		}
	}
	public int MATimesBind()
	{
		string yearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
		int times = BG_MonPayPlanGenerateLogic.GetSubmitMonPayremarkTimes(yearMonth, DepID);
		int t = 0;
		t = times == 0 ? 1 : times + 1;
		Label3.Text = "可编辑批次" + t;
		return t;
	}

	protected void btnsubmit_DirectClick(object sender, DirectEventArgs e)
	{ 
		string pici = cmbpici.SelectedItem.Value;
		string pici1 = cmbpici.RawValue.ToString();
		string pici2 = cmbpici.SelectedItem.Text;
		pici = pici1 == pici2 ? pici1 : pici2;
		if (hidflag.Text != "2")
		{
			decimal sq = BG_MonPayPlanGenerateLogic.GetsqMon(CurrentYear + "-" + cmbmon.SelectedItem.Value,
				 DepID,common.IntSafeConvert(pici));
			if (sq <= 0)
			{
				X.Msg.Alert("申请月度用款计划","无法提交,请先填写数据.").Show();
				return;
			}

		}
		string yearMonth = CurrentYear + "-" + cmbmon.SelectedItem.Value;
		int PRID = BG_MonPayPlanGenerateLogic.GetSubmitMonPayremarkID(yearMonth, DepID, common.IntSafeConvert(pici));
		if (PRID > 0)
		{
			BG_MonPayPlanRemark mppr = BG_MonPayPlanRemarkManager.GetBG_MonPayPlanRemarkByPRID(PRID);
			mppr.DeptID = DepID;
			mppr.MACause = "";
			mppr.MASta = "未提交";
			mppr.MATime = Convert.ToDateTime(CurrentYear + "-" + cmbmon.SelectedItem.Value + "-01");
			mppr.MAUser = UserName;
			mppr.MATimes = common.IntSafeConvert(cmbpici.SelectedItem.Value);
			BG_MonPayPlanRemarkManager.ModifyBG_MonPayPlanRemark(mppr);
			X.Msg.Alert("申请月度用款计划", cmbmon.SelectedItem.Value + "月份用款计划已提交给财务科，请等待审核").Show();
			btnsubmit.Hidden = true;
			hidflag.Text = "1";
            Getmonth(); Session["NodeBC59"] = 1;
		}
		else
		{
			BG_MonPayPlanRemark mppr = new BG_MonPayPlanRemark();
			mppr.DeptID = DepID;
			mppr.MACause = "";
			mppr.MASta = "未提交";
			mppr.MATime = Convert.ToDateTime(CurrentYear + "-" + cmbmon.SelectedItem.Value + "-01");
			mppr.MAUser = UserName;
			mppr.MATimes = common.IntSafeConvert(cmbpici.SelectedItem.Value);
			BG_MonPayPlanRemarkManager.AddBG_MonPayPlanRemark(mppr);
			X.Msg.Alert("申请月度用款计划", cmbmon.SelectedItem.Value + "月份用款计划已提交财务科，请等待审核").Show();
			btnsubmit.Hidden = true;
            hidflag.Text = "1"; Session["NodeBC59"] = 1;
			Getmonth();
		}
		cmbpici.SelectedItem.Value = MATimesBind().ToString(); 
	}

	protected void Button1_DirectClick(object sender, DirectEventArgs e)
	{
		Response.Redirect("MonPayPlanNew.aspx", true);
	}
}