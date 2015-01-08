using System;
using System.Data;
using System.Web.UI.WebControls;
using FinaAnaly.BLL;
using Common;
using FinaAnaly.Model;

public partial class WebPage_SysSetting_MemberManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DepartListBind();
            int depid = common.IntSafeConvert(DepartList.SelectedItem.Value);
            StaffListBind(depid);
            HidUsid.Value = StaffList.SelectedItem.Value;
            int usid = common.IntSafeConvert(StaffList.SelectedItem.Value);
            txtStaffBind(usid);
        }
    }

    /// <summary>
    /// 绑定部门列表
    /// </summary>
    private void DepartListBind()
    {
        DataTable dt = FA_DepartmentManager.GetAllFA_Department();
        if (dt != null && dt.Rows.Count > 0)
        {
            //*******绑定部门列表[DepartList]************
            DepartList.DataSource = dt;
            DepartList.DataTextField = "DepName";
            DepartList.DataValueField = "DepID";
            DepartList.SelectedValue = dt.Rows[0]["DepID"].ToString();
            DepartList.DataBind();
            //*******绑定部门下拉列表[ddlDepart]************
            ddlDepart.DataSource = dt;
            ddlDepart.DataTextField = "DepName";
            ddlDepart.DataValueField = "DepID";
            ddlDepart.DataBind();
        }
    }

    /// <summary>
    /// 绑定人员列表
    /// </summary>
    /// <param name="depid"></param>
    private void StaffListBind(int depid)
    {
        lblShowResult.Text = string.Empty;
        StaffList.Items.Clear();
        ListItem item = new ListItem();
        item.Text = "添加人员";
        item.Value = "0";
        StaffList.Items.Add(item);
        DataTable dt = FA_UserManager.GetDtUserByDepid(depid);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem itemUser = new ListItem();
                itemUser.Text = dt.Rows[i]["UserName"].ToString();
                itemUser.Value = dt.Rows[i]["UserID"].ToString();
                StaffList.Items.Add(itemUser);
            }
            int firstUsid = common.IntSafeConvert(dt.Rows[0]["UserID"]);
            HidUsid.Value = firstUsid.ToString();
            StaffList.SelectedValue = firstUsid.ToString();
            txtStaffBind(firstUsid);
        }
        else
        {

            StaffList.SelectedValue = "0";
            ddlDepart.SelectedValue = DepartList.SelectedValue;
            lblTipInfo.Text = "添加";
            HidUsid.Value = "0";
            btnDel.Visible = false;
            txtClear();
        }
    }
    /// <summary>
    /// 绑定人员信息
    /// </summary>
    /// <param name="usid"></param>
    private void txtStaffBind(int usid)
    {
        FA_User userInfo = FA_UserManager.GetFA_UserByUserID(usid);
        if (userInfo != null)
        {
            txtStaffName.Text = userInfo.UserName;
            txtAccount.Text = userInfo.UserNum;
            txtIDNum.Text = userInfo.UserIDNum;
            txtRem.Text = userInfo.UserRem;
            ddlDepart.SelectedValue = userInfo.DepID.ToString();
            if (userInfo.UserLim == 1001)
            {
                rbtnUser.Checked = true;
            }
            else
            {
                rbtnBureau.Checked = true;
            }
        }
    }

    private void txtClear()
    {
        lblShowResult.Text = string.Empty;
        txtStaffName.Text = string.Empty;
        txtAccount.Text = string.Empty;
        txtIDNum.Text = string.Empty;
        txtRem.Text = string.Empty;
    }

    protected void DepartList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtClear();
        int depid = common.IntSafeConvert(DepartList.SelectedItem.Value);
        StaffListBind(depid);
        
    }

    protected void StaffList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (StaffList.SelectedItem.Value == "0")
        {
            lblTipInfo.Text = "添加";
            HidUsid.Value = "0";
            btnDel.Visible = false;
            ddlDepart.SelectedValue = DepartList.SelectedValue;
            txtClear();
        }
        else
        {
            lblShowResult.Text = string.Empty;
            lblTipInfo.Text = "修改";
            btnDel.Visible = true;
            HidUsid.Value = StaffList.SelectedItem.Value;
            int usid = common.IntSafeConvert(StaffList.SelectedValue);
            txtStaffBind(usid);
        }
    }
    protected void txtStaffName_TextChanged(object sender, EventArgs e)
    {
        string usname = txtStaffName.Text.Trim();
        txtAccount.Text = ChineseToSpell.ConvertToAllSpell(usname);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int hidUsid = common.IntSafeConvert(HidUsid.Value);
        if (hidUsid == 0)
        {
            int uselim = 1000;
            if (rbtnUser.Checked)
            {
                uselim = 1001;
            }
            if (rbtnBureau.Checked)
            {
                uselim = 1002;
            }
            FA_User user = new FA_User();
            user.UserName = txtStaffName.Text.Trim();
            user.UserNum = txtAccount.Text.Trim();
            user.UserIDNum = txtIDNum.Text.Trim();
            user.UserRem = txtRem.Text.Trim();
            user.UserLim = uselim;
            user.UserPwd = "12345";
            user.UserSta = 1;
            user.UserPurStr = "000000";
            user.DepID = common.IntSafeConvert(ddlDepart.SelectedValue);
            if (FA_UserManager.AddFA_User(user).UserID > 0)
            {
                int depid = common.IntSafeConvert(DepartList.SelectedItem.Value);
                StaffListBind(depid);
                lblShowResult.Text = "保存成功";
            }
            else
            {
                lblShowResult.Text = "操作失败，请重试";
            }
        }
        else
        {
            int uselim = 1000;
            if (rbtnUser.Checked)
            {
                uselim = 1001;
            }
            if (rbtnBureau.Checked)
            {
                uselim = 1002;
            }
            FA_User user = FA_UserManager.GetFA_UserByUserID(hidUsid);
            user.UserName = txtStaffName.Text.Trim();
            user.UserNum = txtAccount.Text.Trim();
            user.UserIDNum = txtIDNum.Text.Trim();
            user.UserRem = txtRem.Text.Trim();
            user.UserLim = uselim;
            user.DepID = common.IntSafeConvert(ddlDepart.SelectedValue);
            if (FA_UserManager.ModifyFA_User(user))
            {
                lblShowResult.Text = "保存成功";
            }
            else
            {
                lblShowResult.Text = "操作失败，请重试";
            }
        }
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
           int hidUsid = common.IntSafeConvert(HidUsid.Value);
           if (FA_UserManager.DeleteFA_UserByID(hidUsid))
           {
               int depid = common.IntSafeConvert(DepartList.SelectedItem.Value);
               StaffListBind(depid);
           }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
          int hidUsid = common.IntSafeConvert(HidUsid.Value);
          if (hidUsid == 0)
          {
              txtClear();
          }
          else
          {
              txtStaffBind(hidUsid);
          }
    }
}