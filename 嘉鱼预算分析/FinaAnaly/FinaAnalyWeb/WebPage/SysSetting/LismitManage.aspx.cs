using Ext.Net;
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

public partial class WebPage_SysSetting_LismitManage : System.Web.UI.Page
{
    protected string pur = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [DirectMethod]
    public string NodeLoad(string nodeID)
    {
        NodeCollection nodes = new Ext.Net.NodeCollection();
        if (nodeID == "root")
        {
            DataTable dtpark = FA_DepartmentManager.GetAllFA_Department();
            for (int i = 0; i < dtpark.Rows.Count; i++)
            {
                Node Nodeju = new Node();
                Nodeju.NodeID = dtpark.Rows[i]["DepID"].ToString();
                Nodeju.Text = dtpark.Rows[i]["DepName"].ToString();
                Nodeju.Icon = Icon.UserHome;
                nodes.Add(Nodeju);
                Getson(Nodeju);
            }
        }
        return nodes.ToJson();
    }

    private void Getson(Node node)
    {
        int id = common.IntSafeConvert(node.NodeID);
        DataTable dt = FA_UserManager.GetDtUserByDepid(id);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Node node2 = new Node();
                node2.NodeID = dt.Rows[i]["UserID"].ToString();
                node2.Text = dt.Rows[i]["UserName"].ToString();
                node2.Icon = Icon.User;
                node2.Leaf = true;
                node.Children.Add(node2);
            }
        }
        else
        {
            node.EmptyChildren = true;
        }
    }

    [DirectMethod]
    public void selectdep(int id)
    {
        Session["id"] = id;
        PutPur(id);
    }

    public void PutPur(int id)
    {
        Checkbox1.Disabled = false;
        Checkbox2.Disabled = false;
        Checkbox3.Disabled = false;
        Checkbox4.Disabled = false;
        Checkbox5.Disabled = false;
        Checkbox6.Disabled = false;
        FA_User ba = FA_UserManager.GetFA_UserByUserID(id);
        if (ba != null)
        {
            if (ba.UserLim == 1002)
            {
                string str = ba.UserPurStr;
                Checkbox1.Disabled = true;
                if (str.Substring(1, 1) == "1")
                {
                    Checkbox2.Checked = true;
                }
                else
                {
                    Checkbox2.Checked = false;
                }
                if (str.Substring(2, 1) == "1")
                {
                    Checkbox3.Checked = true;
                }
                else
                {
                    Checkbox3.Checked = false;
                }
                if (str.Substring(3, 1) == "1")
                {
                    Checkbox4.Checked = true;
                }
                else
                {
                    Checkbox4.Checked = false;
                }
                if (str.Substring(4, 1) == "1")
                {
                    Checkbox5.Checked = true;
                }
                else
                {
                    Checkbox5.Checked = false;
                }
                if (str.Substring(5, 1) == "1")
                {
                    Checkbox6.Checked = true;
                }
                else
                {
                    Checkbox6.Checked = false;
                }
            }
            if (ba.UserLim == 1001)
            {
                string str = ba.UserPurStr;
                Checkbox1.Disabled = true;
                Checkbox2.Disabled = true;
                Checkbox4.Disabled = true;
                Checkbox5.Disabled = true;
                if (str.Substring(2, 1) == "1")
                {
                    Checkbox3.Checked = true;
                }
                else
                {
                    Checkbox3.Checked = false;
                }
                if (str.Substring(5, 1) == "1")
                {
                    Checkbox6.Checked = true;
                }
                else
                {
                    Checkbox6.Checked = false;
                }
            }
        }
        else
        {
            Checkbox1.Checked = false;
            Checkbox2.Checked = false;
            Checkbox3.Checked = false;
            Checkbox4.Checked = false;
            Checkbox5.Checked = false;
            Checkbox6.Checked = false;
            Checkbox1.Disabled = false;
            Checkbox2.Disabled = false;
            Checkbox3.Disabled = false;
            Checkbox4.Disabled = false;
            Checkbox5.Disabled = false;
            Checkbox6.Disabled = false;
        }
    }


    protected void btnEdit_DirectClick(object sender, DirectEventArgs e)
    {
        int id = common.IntSafeConvert(Session["id"]);
        GetPur();
        FA_User fa = FA_UserManager.GetFA_UserByUserID(id);
        if (fa != null)
        {
            fa.UserPurStr = pur;
            if (FA_UserManager.ModifyFA_User(fa))
            {
                X.MessageBox.Alert("操作提示", "保存成功").Show();
            }
            else
            {
                X.MessageBox.Alert("操作提示", "保存失败").Show();
            }
        }
    }

    private void GetPur()
    {
        if (Checkbox1.Checked)
        {
            pur += "1";
        }
        else
        {
            pur += "0";
        }
        if (Checkbox2.Checked)
        {
            pur += "1";
        }
        else
        {
            pur += "0";
        }
        if (Checkbox3.Checked)
        {
            pur += "1";
        }
        else
        {
            pur += "0";
        }
        if (Checkbox4.Checked)
        {
            pur += "1";
        }
        else
        {
            pur += "0";
        }
        if (Checkbox5.Checked)
        {
            pur += "1";
        }
        else
        {
            pur += "0";
        }
        if (Checkbox6.Checked)
        {
            pur += "1";
        }
        else
        {
            pur += "0";
        }
    }
}