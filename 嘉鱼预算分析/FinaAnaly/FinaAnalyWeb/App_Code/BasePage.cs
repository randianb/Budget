using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using FinaAnaly.BLL; 
using Common;

/// <summary>
/// BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
        if (Session[Constant.UserName] != null && Session[Constant.UserLim] != null)
        {
            userLim = common.IntSafeConvert(Session[Constant.UserLim]);
            userName = Session[Constant.UserName].ToString();
            userNum = Session[Constant.UserNum].ToString();
            depID = common.IntSafeConvert(Session[Constant.DepID]);
            depName = Session[Constant.DepName].ToString();
            UserID = common.IntSafeConvert(Session[Constant.UserID]);
            areaDepID = common.IntSafeConvert(ConfigurationManager.AppSettings["AreaDepID"]);
            currentYear = FA_SysSettingManager.GetSysSettingByYear(DateTime.Now.Year).SSYear.ToString();
            userLimStr = GetUserLimStr(userLim);
        }
        else
        {

            ClientScript.RegisterStartupScript(GetType(), "lgout", "window.top.location.href='" + ResolveClientUrl("~/login.aspx") + "'");

        }
        base.OnLoad(e);
    }


    private string GetUserLimStr(int userLim)
    {
        //返回权限字符串
        //管理员/操作员
        string limStr = string.Empty;
        if (userLim == 1000)
        {
            limStr = "管理员";
        }
        if (userLim == 1001)
        {
            limStr = "操作员";
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

    private int userLim =0;
    /// <summary>
    ///  权限
    /// </summary>
    public int UserLim
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


    private int areaDepID = 0;
    /// <summary>
    /// 单位部门ID(如：嘉鱼县1083)
    /// </summary>
    public int AreaDepID
    {
        get { return areaDepID; }
        set { areaDepID = value; }
    }

    private string currentYear = string.Empty;
    /// <summary>
    /// 当前操作的年度
    /// </summary>
    public string CurrentYear
    {
        get { return currentYear; }
        set { currentYear = value; }
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