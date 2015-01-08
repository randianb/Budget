using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// AnalyseBasePage 的摘要说明
/// </summary>
public class AnalyseBasePage : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
        if (Session[Constant.UserName] != null && Session[Constant.UserLim] != null)
        {
            userLim = Session[Constant.UserLim].ToString();
            userName = Session[Constant.UserName].ToString();
            userNum = Session[Constant.UserNum].ToString();
            depID = Convert.ToInt32(Session[Constant.DepID]);
            depName = Session[Constant.DepName].ToString();
            UserID = Convert.ToInt32(Session[Constant.UserID]);

            userLimStr = GetUserLimStr(userLim);

        }
        else
        {
            //Response.Redirect("~/Login.aspx", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "lgout", "window.top.location.href='login.aspx'", true);

        }
        base.OnLoad(e);
    }

    private string GetUserLimStr(string userLim)
    { 
        //返回权限字符串
        //管理员/审批员/审核员/录入员/查询员
        string limStr = string.Empty;
        if (userLim.Substring(0, 1) == "1")
        {
            limStr = "管理员";
        }

        if (userLim.Substring(1, 1) == "1")
        {
            if (limStr.Length > 0)
            {
                limStr += "|";
            }
            limStr = "审批员";
        }

        if (userLim.Substring(2, 1) == "1")
        {
            if (limStr.Length > 0)
            {
                limStr += "|";
            }
            limStr = "审核员";
        }

        if (userLim.Substring(3, 1) == "1")
        {
            if (limStr.Length > 0)
            {
                limStr += "|";
            }
            limStr = "录入员";
        }

        if (userLim.Substring(4, 1) == "1")
        {
            if (limStr.Length > 0)
            {
                limStr += "|";
            }
            limStr = "查询员";
        }


        return limStr;
    }

    #region 属性

    private int userID = 0;
    /// <summary>
    /// 用户ID
    /// </summary>
    public int UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    private string userName = string.Empty;
    /// <summary>
    /// 姓名
    /// </summary>
    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    private string userNum = string.Empty;
    /// <summary>
    /// 工号
    /// </summary>
    public string UserNum
    {
        get { return userNum; }
        set { userNum = value; }
    }

    private string userLim = string.Empty;
    /// <summary>
    /// 权限
    /// </summary>
    public string UserLim
    {
        get { return userLim; }
        set { userLim = value; }
    }

    private string userLimStr = string.Empty;
    /// <summary>
    /// 权限描述
    /// </summary>
    public string UserLimStr
    {
        get { return userLimStr; }
        set { userLimStr = value; }
    }


    private int depID = 0;
    /// <summary>
    /// 部门ID
    /// </summary>
    public int DepID
    {
        get { return depID; }
        set { depID = value; }
    }

    private string depName = string.Empty;
    /// <summary>
    /// 部门
    /// </summary>
    public string DepName
    {
        get { return depName; }
        set { depName = value; }
    }
    #endregion
}