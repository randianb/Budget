using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using BudgetWeb.BLL;
using BudgetWeb.Model;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        string usname = txtUer.Text;
        string pwd = txtPwd.Text;


        BG_User user = BG_UserLogic.UserLogin(usname, pwd);
        if (user != null)
        {
            Session[Constant.UserID] = user.UserID;         //用户ID
            Session[Constant.UserName] = user.UserName;     //用户名称
            Session[Constant.UserNum] = user.UserNum;       //用户工号
            Session[Constant.UserLim] = user.UserLim;       //用户权限
            Session[Constant.DepID] = user.DepID;           //用户所属部门ID
            BG_Department department = BG_DepartmentManager.GetBG_DepartmentByDepID(user.DepID);
            Session[Constant.DepName] = department.DepName; //用户所属部门名称


            Response.Redirect("default.aspx", true);
        }
        else
        {
            X.Msg.Alert("Error", "密码或帐户名错误!").Show();

        }
    }
    protected void ibtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        txtUer.Text = string.Empty;
        txtPwd.Text = string.Empty;
    }
}