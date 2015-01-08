using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Ext.Net;

public partial class WebPage_SysSetting_STMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!X.IsAjaxRequest && !IsPostBack)
        //{
        //    int depid = AreaDepID;
        //    ddlDepBind(depid);
        //    STMem.ExpandAll();
        //}

       
    }
    //绑定部门
    private void ddlDepBind(int depid)
    {
        //DataTable depTable = null;
        ////if (depid == 1083)//if (PurviewConstant.Admin || PurviewConstant.Auditor || PurviewConstant.Examiner)
        ////{
        //    depTable = BG_DepartmentLogic.GetBG_Department(depid);
        ////}
        ////else
        ////{
        ////    depTable = BG_DepartmentLogic.GetBG_DepartmentBydepid(depid);
        ////}
        //for (int i = 0; i < depTable.Rows.Count; i++)
        //{
        //    //  cmbDepnaem.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
        //    ComboBox1.Items.Add(new Ext.Net.ListItem(depTable.Rows[i]["depName"].ToString(), depTable.Rows[i]["depID"].ToString()));
        //}
    }


    protected void GetNodes(object sender, NodeLoadEventArgs e)
    {
        DataTable dt = new DataTable();// BG_DepartmentLogic.GetAllBG_Department();

        Node rootNode = new Node();
        rootNode.Text = "部门管理";
        rootNode.Icon = Icon.Folder;
        e.Nodes.Add(rootNode);

        NodeCollection nodes = new NodeCollection();

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string depname = dt.Rows[i]["DepName"].ToString();
                string depid = dt.Rows[i]["DepID"].ToString();

                Node node1 = new Node();
                node1.NodeID = dt.Rows[i]["DepID"].ToString();
                node1.Text = depname;
                node1.Icon = Icon.UserHome;
                //node1.Leaf = true; 
                rootNode.Children.Add(node1);
                DataTable dt1 = new DataTable();// BG_UserLogic.GetDtUserByDepid(depid);
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
                    Node node2 = new Node();
                    node2.NodeID = "";
                    node2.Text = "";
                    node2.Leaf = true;
                    node1.Children.Add(node2);
                }
                
            }
        }
        STMem.ExpandAll();
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
    }

    [DirectMethod]
    public void Memberselect(string uid)
    {
        TextField1.ReadOnly = true;
        if (uid.Length <= 0)
        {
            return;
        }
        hidUserID.Value = uid;
        chkClear();
        int id = StrToInt(uid);
        //BG_User user = BG_UserManager.GetBG_UserByUserID(id);
        //BG_User user = BG_UserManager.GetBG_UserByUsid(id);
        //if (user != null)
        //{
        //    TextField1.Text = user.UserName;
        //    int depid = user.DepID;
        //    TextField3.Text = user.UserNum;
        //    TextField4.Text = user.UserIDNum;
        //    txtRem.Text = user.UserRem;
        //    UserID.Text = user.UserID.ToString();
        //    string limit = user.UserLim;
        //    if (limit.Length >= 5)
        //    {
        //        if (limit.Substring(0, 1) == "1")
        //        {
        //            Radio1.Checked = true;
        //        }
        //        if (limit.Substring(1, 1) == "1")
        //        {
        //            Radio2.Checked = true;
        //        }
        //        if (limit.Substring(2, 1) == "1")
        //        {
        //            Radio3.Checked = true;
        //        }
        //        if (limit.Substring(3, 1) == "1")
        //        {
        //            Radio4.Checked = true;
        //        }
        //        if (limit.Substring(4, 1) == "1")
        //        {
        //            Radio5.Checked = true;
        //        }
        //    }


        //    BG_Department dp = BG_DepartmentManager.GetBG_DepartmentByDepID(depid);
        //    if (dp != null)
        //    {
        //        ComboBox1.RawValue = dp.DepName;
        //    }
        //}

    }


    protected void btnMod_DirectClick(object sender, DirectEventArgs e)
    {
      

        int uid = StrToInt(UserID.Text);
        if (uid == 0)
        {
            add();
            return;
        }
        
        //BG_User user = BG_UserManager.GetBG_UserByUserID(uid);
        //user.UserName = TextField1.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        //user.UserNum = TextField3.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        //user.UserIDNum = TextField4.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        //user.UserRem = txtRem.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        string limit = string.Empty;
      
        if (Radio1.Checked == true)
        {
            limit = "10000";
        }

        if (Radio2.Checked == true)
        {
            limit = "01000";
        }
       
        //user.UserLim = limit;
        //string depname = ComboBox1.RawValue.ToString();
        //DataTable dt = BG_DepartmentLogic.GetDepidByName(depname);
        //if (dt.Rows.Count > 0)
        //{
        //    user.DepID = StrToInt(dt.Rows[0]["DepID"].ToString());
        //}
        //if (BG_UserManager.ModifyBG_User(user))
        //{
        //    X.Msg.Show(new MessageBoxConfig
        //    {
        //        Title = "提示",
        //        Message = "修改成功",
        //        Width = 300,
        //        Buttons = MessageBox.Button.OK,

        //    });

        //    //Response.Redirect("STMember.aspx", true);
        //}
    }
    protected void btnCan_DirectClick(object sender, DirectEventArgs e)
    {
        string uid = UserID.Text;
        Memberselect(uid);
    }
    protected void btnDel_DirectClick(object sender, DirectEventArgs e)
    {
        //if (!string.IsNullOrEmpty(UserID.Text))
        //{
        //    int uid = StrToInt(UserID.Text);
        //    if (BG_UserManager.DeleteBG_UserByID(uid))
        //    {
        //        Response.Redirect("STMember.aspx", true);
        //    }
        //}
    }

    protected void btnWinAdd_DirectClick(object sender, DirectEventArgs e)
    {
        //UserID.Text = "";
        //BG_User user = new BG_User();
        //user.UserIDNum = UserIDNum.Text;
        //user.UserName = UserName.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        //user.UserNum = UserNum.Text;
        //user.UserRem = UserRem.Text.Replace(",", string.Empty).Replace("，", string.Empty);
        //string limit = string.Empty;
    
        //if (Radio1.Checked == true)
        //{
        //    limit = "10000";
        //}

        //if (Radio2.Checked == true)
        //{
        //    limit = "01000";
        //}
        //if (Radio3.Checked == true)
        //{
        //    limit = "00100";
        //}
        //if (Radio4.Checked == true)
        //{
        //    limit = "00010";
        //} 
        //if (Radio5.Checked == true)
        //{
        //    limit = "00001";
        //} 

       
        //user.UserLim = limit;
        ////user.UserSta = StrToInt(cbbSta.Text);
        //if (cbbSta.Text == "禁用")
        //{
        //    user.UserSta = 2;
        //}
        //if (cbbSta.Text == "禁用")
        //{
        //    user.UserSta = 1;
        //}
        //user.UserPwd = "12345";
        //string depname = UserDep.Text;
        //DataTable dt = BG_DepartmentLogic.GetDepidByName(depname);
        //if (dt.Rows.Count > 0)
        //{
        //    user.DepID = StrToInt(dt.Rows[0]["DepID"].ToString());
        //}
        //if (BG_UserManager.AddBG_User(user).UserID > 0)
        //{
        //    X.Msg.Show(new MessageBoxConfig
        //    {
        //        Title = "提示",
        //        Message = "添加成功",
        //        Width = 300,
        //        Buttons = MessageBox.Button.OK, 
        //    });   
           
        //}
      //Response.Redirect("STMember.aspx", true);
    }
    protected void btnWinCancel_DirectClick(object sender, DirectEventArgs e)
    {
        //Winadd.Close();
        //Response.Redirect("STMember.aspx", true);
    }
    protected void btnAdd_DirectClick1(object sender, DirectEventArgs e)
    {
        UserID.Text = "";
        TextField1.Text = "";
        ComboBox1.SelectedItem.Value = "";
        TextField3.Text = "";
        TextField4.Text = "";
        TextField1.ReadOnly = false;
        chkClear();
        txtRem.Text = "";
        //Winadd.Show();
        // ddlDepBind(1083);
    }

    private void add()
    {
    //    UserID.Text = "";
    //    BG_User user = new BG_User();
    //    user.UserIDNum = TextField4.Text;
    //    user.UserName = TextField1.Text.Replace(",", string.Empty).Replace("，", string.Empty);
    //    if (user.UserName == "")
    //    {
    //        return;
    //    }
    //    user.UserNum = TextField3.Text;
    //    user.UserRem = txtRem.Text.Replace(",", string.Empty).Replace("，", string.Empty);
    //    string limit = string.Empty;

    //    if (Radio1.Checked == true)
    //    {
    //        limit = "10000";
    //    }

    //    if (Radio2.Checked == true)
    //    {
    //        limit = "01000";
    //    }
    //    if (Radio3.Checked == true)
    //    {
    //        limit = "00100";
    //    }
    //    if (Radio4.Checked == true)
    //    {
    //        limit = "00010";
    //    }
    //    if (Radio5.Checked == true)
    //    {
    //        limit = "00001";
    //    } 
       
       
    //    user.UserLim = limit;
    //    //user.UserSta = StrToInt(cbbSta.Text);
    //    //if (cbbSta.Text == "禁用")
    //    //{
    //    //    user.UserSta = 2;
    //    //}
    //    //if (cbbSta.Text == "禁用")
    //    //{
    //    //    user.UserSta = 1;
    //    //}
    //    user.UserSta = 1;
    //    user.UserPwd = "12345";
    //    int depid = Convert.ToInt32(ComboBox1.SelectedItem.Value);
    //    user.DepID = depid;
        
    //    if (BG_UserManager.AddBG_User(user).UserID > 0)
    //    {
    //        X.Msg.Show(new MessageBoxConfig
    //        {
    //            Title = "提示",
    //            Message = "添加成功",
    //            Width = 300,
    //            Buttons = MessageBox.Button.OK,
    //        });

    //    }
    //    Node node = new Node();

    //    node.Text = user.UserName;
    //    node.Icon = Icon.User;
    //    node.Leaf = true;
    //    STMem.GetNodeById(depid).AppendChild(node);
    //    //STMem.ExpandAll();
        
    }

}