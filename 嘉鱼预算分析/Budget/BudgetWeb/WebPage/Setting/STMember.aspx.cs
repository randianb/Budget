using Common;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using FinaAnaly.BLL;
using FinaAnaly.Model;

public partial class WebPage_Setting_STMember : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!X.IsAjaxRequest && !IsPostBack)
        //{
        //    int depid = AreaDepID;
        //    ddlDepBind(depid); 
        //}
        if (Request.QueryString["depid"] != null)
        {
            Session["depid"] = common.IntSafeConvert(Request.QueryString["depid"]);
        }
        else
        {

            Session["depid"] = 0;
        }
        //int Areadepid = AreaDepID;
        //ddlDepBind(Areadepid); 

    }
    //绑定部门
    //private void ddlDepBind(int depid)
    //{
    //    DataTable depTable = null;
    //    //if (depid == 1083)//if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
    //    //{
    //    depTable = BG_DepartmentLogic.GetBG_Department(depid);
    //    //}
    //    //else
    //    //{
    //    //    depTable = BG_DepartmentLogic.GetBG_DepartmentBydepid(depid);
    //    //}
    //    for (int i = 0; i < depTable.Rows.Count; i++)
    //    {
    //        //  cmbDepnaem.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
    //        ComboBox1.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
    //    }
    //}


    //protected void GetNodes(object sender, NodeLoadEventArgs e)
    //{
    //    DataTable dt = BG_DepartmentLogic.GetAllBG_Department(AreaDepID);

    //    Node rootNode = new Node();
    //    rootNode.Text = "部门管理";
    //    rootNode.Icon = Icon.Folder;
    //    e.Nodes.Add(rootNode);

    //    NodeCollection nodes = new NodeCollection();
    //    List<string> listdep = new List<string>();
    //    if (dt.Rows.Count > 0)
    //    {
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            string depname = dt.Rows[i]["DepName"].ToString();

    //            string depid = dt.Rows[i]["DepID"].ToString();
    //            listdep.Add(depname);
    //            Node node1 = new Node();
    //            node1.NodeID = dt.Rows[i]["DepID"].ToString();
    //            node1.Text = depname;
    //            node1.Icon = Icon.UserHome;
    //            //node1.Leaf = true; 
    //            rootNode.Children.Add(node1);
    //            DataTable dt1 = BG_UserLogic.GetDtUserByDepid(depid);
    //            if (dt1.Rows.Count > 0)
    //            {
    //                for (int j = 0; j < dt1.Rows.Count; j++)
    //                {
    //                    Node node2 = new Node();
    //                    node2.NodeID = dt1.Rows[j]["UserID"].ToString();
    //                    node2.Text = dt1.Rows[j]["UserName"].ToString();
    //                    node2.Icon = Icon.User;
    //                    node2.Leaf = true;
    //                    node1.Children.Add(node2);
    //                }
    //            }
    //            else
    //            {
    //                node1.EmptyChildren = true;
    //            }

    //        }
    //    }
    //    Session["sedep"] = listdep;
    //    STMem.ExpandAll();
    //}

    [DirectMethod]
    public string NodeLoad(string nodeID)
    {
        DataTable dt = BG_DepartmentLogic.GetAllBG_Department(AreaDepID);
        NodeCollection nodes = new Ext.Net.NodeCollection();
        Node rootNode = new Node();
        rootNode.Text = "部门管理";
        rootNode.Icon = Icon.Folder;
        nodes.Add(rootNode);
        rootNode.Expanded = true;
        List<string> listdep = new List<string>();
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string depname = dt.Rows[i]["DepName"].ToString();

                string depid = dt.Rows[i]["DepID"].ToString();
                listdep.Add(depname);
                Node node1 = new Node();
                node1.NodeID = dt.Rows[i]["DepID"].ToString();
                node1.Text = depname;
                node1.Icon = Icon.UserHome;
                int sedepid = common.IntSafeConvert((int)Session["depid"]);
                if (sedepid == common.IntSafeConvert(dt.Rows[i]["DepID"]))
                {
                    node1.Expanded = true;
                }
                //node1.Leaf = true; 
                rootNode.Children.Add(node1);
                DataTable dt1 = BG_UserLogic.GetDtUserByDepid(depid);
                if (dt1.Rows.Count > 0)
                {
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        Node node2 = new Node();
                        node2.NodeID = dt1.Rows[j]["UserID"].ToString();
                        node2.Text = dt1.Rows[j]["UserName"].ToString();
                        node2.Icon = Icon.User;
                        node2.Leaf = true;
                        node1.Children.Add(node2);
                    }
                }
                else
                {
                    node1.EmptyChildren = true;
                }

            }
        }
        Session["sedep"] = listdep;
        return nodes.ToJson();
    }
    private int StrToInt(string str)
    {
        int tmp = 0;
        if (!string.IsNullOrEmpty(str))
        {
            if (Int32.TryParse(str, out tmp))
            {
                tmp = Convert.ToInt32(str);
            }
        }
        return tmp;
    }

    private void chkClear()
    {
        Radio1.Checked = false;
        Radio2.Checked = false;
        Radio3.Checked = false;
        Radio4.Checked = false;
        Radio5.Checked = false;
    }
    [DirectMethod]
    public void selectdep(string depname)
    {
        List<string> listdep = (List<string>)Session["sedep"];
        if (depname == "部门管理")
        {
            return;
        }
        //int depid = common.IntSafeConvert(BG_DepartmentLogic.GetBG_DepartmentByName(depname).DepID);
        if (listdep.Contains(depname))
        {
            //if (depid<=0)
            //{
            //    return;
            //}  
            if (TextField1.Text != string.Empty)
            {
                if ((int)Session["TextField1"] != 0)
                {
                    string st = string.Format("CompanyX.DoSelectDepYes('{0}')", depname);
                    X.Msg.Confirm("提示", "您未添加该数据，确认选择其他部门会丢失该数据，是否仍选择其他部门？", new MessageBoxButtonsConfig
                    {
                        Yes = new MessageBoxButtonConfig
                        {
                            Handler = st,
                            Text = "是"
                        },
                        No = new MessageBoxButtonConfig
                        {
                            Text = "否"
                        }
                    }).Show();
                }
                else
                {
                    ComboBox1.Text = depname;
                    Session["depname"] = depname;
                    UserID.Text = "";
                    TextField1.Text = "";
                    TextField3.Text = "";
                    TextField4.Text = "";
                    TextField1.ReadOnly = false;
                    txtRem.Text = "";
                    Radio1.Checked = true;
                }

            }
            else
            {
                //ComboBox1.RawValue = depname;
                ComboBox1.Text = depname;
                Session["depname"] = depname;
                UserID.Text = "";
                TextField1.Text = "";
                TextField3.Text = "";
                TextField4.Text = "";
                TextField1.ReadOnly = false;
                txtRem.Text = "";
                Radio1.Checked = true;
            }
        }
    }

    [DirectMethod(Namespace = "CompanyX")]
    public void DoSelectDepYes(string depname)
    {
        //ComboBox1.RawValue = depname;
        ComboBox1.Text = depname;
        Session["depname"] = depname;
        UserID.Text = "";
        TextField1.Text = "";
        TextField3.Text = "";
        TextField4.Text = "";
        TextField1.ReadOnly = false;
        txtRem.Text = "";
        Radio1.Checked = true;
    }
    [DirectMethod]
    public void Memberselect(string uid)
    {
        TextField1.ReadOnly = true;
        Session["TextField1"] = 0;
        if (uid.Length <= 0)
        {
            return;
        }
        hidUserID.Value = uid;
        chkClear();
        int id = StrToInt(uid);
        BG_User user = BG_UserManager.GetBG_UserByUserID(id);
        //BG_User user = BG_UserManager.GetBG_UserByUsid(id);
        if (user != null)
        {
            TextField1.Text = user.UserName;
            int depid = user.DepID;
            TextField3.Text = user.UserNum;
            TextField4.Text = user.UserIDNum;
            txtRem.Text = user.UserRem;
            UserID.Text = user.UserID.ToString();
            string limit = user.UserLim;
            if (limit.Length >= 5)
            {
                if (limit.Substring(0, 1) == "1")
                {
                    Radio1.Checked = true;
                }
                if (limit.Substring(1, 1) == "1")
                {
                    Radio2.Checked = true;
                }
                if (limit.Substring(2, 1) == "1")
                {
                    Radio3.Checked = true;
                }
                if (limit.Substring(3, 1) == "1")
                {
                    Radio4.Checked = true;
                }
                if (limit.Substring(4, 1) == "1")
                {
                    Radio5.Checked = true;
                }
            }


            BG_Department dp = BG_DepartmentManager.GetBG_DepartmentByDepID(depid);
            if (dp != null)
            {
                //ComboBox1.RawValue = dp.DepName;
                ComboBox1.Text = dp.DepName;
            }
        }

    }


    protected void btnMod_DirectClick(object sender, DirectEventArgs e)
    {
        GetClick();
    }
    [DirectMethod(Namespace = "CompanyX")]
    public void DoYes()
    {
        add();
    }
    [DirectMethod(Namespace = "CompanyX")]
    public void DoModYes(int uid)
    {
        mod(uid);
    }

    private void GetClick()
    {
        int uid = StrToInt(UserID.Text);
        if (uid == 0)
        {
            X.Msg.Confirm("提示", "是否添加该数据", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "CompanyX.DoYes()",
                    Text = "是"
                },
                No = new MessageBoxButtonConfig
                {
                    Text = "否"
                }
            }).Show();
        }
        else
        {
            string str = string.Format("CompanyX.DoModYes({0})", uid);
            X.Msg.Confirm("提示", "是否修改该数据", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = str,
                    Text = "是"
                },
                No = new MessageBoxButtonConfig
                {
                    Text = "否"
                }
            }).Show();
        }

    }

    private void mod(int uid)
    {
        BG_User user = BG_UserManager.GetBG_UserByUserID(uid);
        FA_User faUser = FA_UserManager.GetFA_UserByUserID(uid);
        user.UserName = TextField1.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        user.UserNum = TextField3.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        user.UserIDNum = TextField4.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        user.UserRem = txtRem.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        string limit = string.Empty;

        if (Radio1.Checked == true)
        {
            limit = "10000";
        }

        if (Radio2.Checked == true)
        {
            limit = "01000";
        }
        if (Radio3.Checked == true)
        {
            limit = "00100";
        }
        if (Radio4.Checked == true)
        {
            limit = "00010";
        }
        if (Radio5.Checked == true)
        {
            limit = "00001";
        } 
        user.UserLim = limit;
        string depname = ComboBox1.Text; //ComboBox1.RawValue.ToString();
        DataTable dt = BG_DepartmentLogic.GetDepidByName(depname);
        if (dt.Rows.Count > 0)
        {
            user.DepID = StrToInt(dt.Rows[0]["DepID"].ToString());
        }
        faUser.UserName = user.UserName;
        faUser.UserNum = user.UserNum;
        faUser.UserPwd = user.UserPwd;
        faUser.UserIDNum = user.UserIDNum;
        faUser.UserRem = user.UserRem;
        if (user.UserLim.Substring(1,1)=="1")
        {
            faUser.UserLim = 1002;
        }
        else if (user.UserLim.Substring(0, 1) == "1")
        {
            faUser.UserLim = 1000;
        }
        else
        {
            faUser.UserLim = 1001;
        }
        faUser.DepID = user.DepID;
       // faUser.UserPurStr = "000000";
        if (BG_UserManager.ModifyBG_User(user) && FA_UserManager.ModifyFA_User(faUser))
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "提示",
                Message = "修改成功",
                Width = 300,
                Buttons = Ext.Net.MessageBox.Button.OK,

            });
            int depid = common.IntSafeConvert(user.DepID);
            Response.Redirect("STMember.aspx?depid=" + depid, true);
            //Response.Redirect("STMember.aspx", true);
        }
    }

    protected void btnDel_DirectClick(object sender, DirectEventArgs e)
    {
        X.Msg.Confirm("提示", "是否删除该数据", new MessageBoxButtonsConfig
        {
            Yes = new MessageBoxButtonConfig
            {
                Handler = "CompanyX.DodelYes()",
                Text = "是"
            },
            No = new MessageBoxButtonConfig
            {
                Text = "否"
            }
        }).Show();

    }

    [DirectMethod(Namespace = "CompanyX")]
    public void DodelYes()
    {
        if (!string.IsNullOrEmpty(UserID.Text))
        {
            int uid = StrToInt(UserID.Text);
            int depid = common.IntSafeConvert(BG_UserManager.GetBG_UserByUserID(uid).DepID);
            if (BG_UserManager.DeleteBG_UserByID(uid) && FA_UserManager.DeleteFA_UserByID(uid))
            {
                Response.Redirect("STMember.aspx?depid=" + depid, true);
            }
        }
    }

    private void add()
    {
        UserID.Text = "";
        BG_User user = new BG_User();
        FA_User faUser =new FA_User();
        user.UserIDNum = TextField4.Text;
        user.UserName = TextField1.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        if (user.UserName == "" || user.UserName == (string)Session["depname"])
        {
            X.Msg.Alert("提示", "人名不能与部门名重名！").Show();
            return;
        }
        if (BG_UserLogic.IsUser(user.UserName))
        {
            X.Msg.Alert("提示", "已经存在该姓名，请使用其他姓名添加！").Show();
            return;
        }
        user.UserNum = TextField3.Text;
        user.UserRem = txtRem.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        string limit = string.Empty;

        if (Radio1.Checked == true)
        {
            limit = "10000";
        }

        if (Radio2.Checked == true)
        {
            limit = "01000";
        }
        if (Radio3.Checked == true)
        {
            limit = "00100";
        }
        if (Radio4.Checked == true)
        {
            limit = "00010";
        }
        if (Radio5.Checked == true)
        {
            limit = "00001";
        }


        user.UserLim = limit;
        //user.UserSta = StrToInt(cbbSta.Text);
        //if (cbbSta.Text == "禁用")
        //{
        //    user.UserSta = 2;
        //}
        //if (cbbSta.Text == "禁用")
        //{
        //    user.UserSta = 1;
        //}
        user.UserSta = 1;
        user.UserPwd = "12345";
        int depid = common.IntSafeConvert(BG_DepartmentLogic.GetBG_DepartmentByName((string)Session["depname"]).DepID);
        user.DepID = depid;
        faUser.UserName = user.UserName;
        faUser.UserNum = user.UserNum;
        faUser.UserPwd = user.UserPwd;
        faUser.UserIDNum = user.UserIDNum;
        faUser.UserRem = user.UserRem;
        if (user.UserLim.Substring(1, 1) == "1")
        {
            faUser.UserLim = 1002;
            faUser.UserPurStr = "000000";
        }
        else if (user.UserLim.Substring(0, 1) == "1")
        {
            faUser.UserLim = 1000;
            faUser.UserPurStr = "111111";
        }
        else
        {
            faUser.UserLim = 1001;
            faUser.UserPurStr = "000000";
        }
        faUser.DepID = user.DepID;
       
        if (BG_UserManager.AddBG_User(user).UserID > 0 && FA_UserManager.AddFA_User(faUser).UserID>0)
        {
            Node node = new Node();

            node.Text = user.UserName;
            node.Icon = Icon.User;
            node.Leaf = true;
            STMem.GetNodeById(depid).AppendChild(node);
            //X.Msg.Show(new MessageBoxConfig
            //{
            //    Title = "提示",
            //    Message = "添加成功",
            //    Width = 300,
            //    Buttons = MessageBox.Button.OK,
            //}); 
            Session["depname"] = "政策法规科";
            Response.Redirect("STMember.aspx?depid=" + depid, true);

        }
        //STMem.ExpandAll();
        //int depid = AreaDepID; 
    }

    //protected void ComboBox1_DirectChange(object sender, DirectEventArgs e)
    //{
    //    Session["depname"] = ComboBox1.SelectedItem.Text;
    //}
    protected void gettext_Event(object sender, DirectEventArgs e)
    {
       TextField3.Text= ChineseToPinYin.Get(TextField1.Text);
    }
}