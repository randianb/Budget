using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinaAnaly.Model;
using FinaAnaly.BLL;
using Common;
using Ext.Net;

public partial class WebPage_BraFundInquiry_BraFundLimitTB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Column3.Text = DateTime.Now.Year.ToString() + "年额度";
        if (!IsPostBack)
        {
            ImpDataBind();
        }
    }

    private void ImpDataBind()
    {
        DataTable dt = null;
        dt = FA_FundsAccountManager.GetAllFA_FundsAccount();
        if (dt != null && dt.Rows.Count > 0)
        {
            Store1.DataSource = dt;
            Store1.DataBind();
        }
        else
        {
            Store1.DataSource = null;
            Store1.DataBind();
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "flagred", "flagred();", true);
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

    protected void btnImport_Click1(object sender, EventArgs e)
    {
        DataTable dt = null;
        if (FileUpload1.HasFile)
        {
            byte[] fileBytes = FileUpload1.FileBytes;
            if (ExcelRender.HasData(new MemoryStream(fileBytes)))
            {
                dt = ExcelRender.RenderFromExcel(new MemoryStream(fileBytes), 0, 0);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataTable dt1 = FA_FundsAccountManager.GetFundsAccountByName(dt.Rows[i][0].ToString());
                        if (dt1 != null && dt1.Rows.Count > 0)
                        {
                            int id = common.IntSafeConvert(dt1.Rows[0]["FAID"].ToString(), 0);
                            FA_FundsAccount faut = FA_FundsAccountManager.GetFA_FundsAccountByFAID(id);
                            faut.DEPARTMENT = dt.Rows[i][0].ToString();
                            if (dt.Rows[i][2].ToString().Contains("_") && dt.Rows[i][2].ToString().Contains("*"))
                            {
                                faut.NUMBEROFPEOPLE = common.IntSafeConvert(dt.Rows[i][1].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                faut.NUMBEROFPEOPLE = common.IntSafeConvert(dt.Rows[i][1]);
                            }
                            if (dt.Rows[i][2].ToString().Contains("_") && dt.Rows[i][2].ToString().Contains("*"))
                            {
                                faut.LIMIT = ToDec(dt.Rows[i][2].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                faut.LIMIT = ToDec(dt.Rows[i][2]);
                            }
                            if (dt.Rows[i][3].ToString().Contains("_") && dt.Rows[i][3].ToString().Contains("*"))
                            {
                                faut.RFOUNDING = ToDec(dt.Rows[i][3].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                faut.RFOUNDING = ToDec(dt.Rows[i][3]);
                            }
                            if (dt.Rows[i][4].ToString().Contains("_") && dt.Rows[i][4].ToString().Contains("*"))
                            {
                                faut.ATCFOR = ToDec(dt.Rows[i][4].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                faut.ATCFOR = ToDec(dt.Rows[i][4]);
                            }
                            if (dt.Rows[i][5].ToString().Contains("_") && dt.Rows[i][5].ToString().Contains("*"))
                            {
                                faut.JXGLYXDY = ToDec(dt.Rows[i][5].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                faut.JXGLYXDY = ToDec(dt.Rows[i][5]);
                            }
                            if (dt.Rows[i][6].ToString().Contains("_") && dt.Rows[i][6].ToString().Contains("*"))
                            {
                                faut.DFLZYXDW = ToDec(dt.Rows[i][6].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                faut.DFLZYXDW = ToDec(dt.Rows[i][6]);
                            }
                            if (dt.Rows[i][7].ToString().Contains("_") && dt.Rows[i][7].ToString().Contains("*"))
                            {
                                faut.WBWLWCXJJ = ToDec(dt.Rows[i][7].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                faut.WBWLWCXJJ = ToDec(dt.Rows[i][7]);
                            }
                            if (dt.Rows[i][8].ToString().Contains("_") && dt.Rows[i][8].ToString().Contains("*"))
                            {
                                faut.BYHBSHGDW = ToDec(dt.Rows[i][8].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                faut.BYHBSHGDW = ToDec(dt.Rows[i][8]);
                            }
                            if (dt.Rows[i][9].ToString().Contains("_") && dt.Rows[i][9].ToString().Contains("*"))
                            {
                                faut.GFJLJF = ToDec(dt.Rows[i][9].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                faut.GFJLJF = ToDec(dt.Rows[i][9]);
                            }
                            if (FA_FundsAccountManager.ModifyFA_FundsAccount(faut))
                            {
                                ImpDataBind();
                                lblShowResult.Text = "导入成功";
                            }
                            else
                            {
                                lblShowResult.Text = "操作失败，请重试";
                            }
                        }
                        else
                        {
                            FA_FundsAccount fa = new FA_FundsAccount();
                            fa.DEPARTMENT = dt.Rows[i][0].ToString();
                            if (dt.Rows[i][1].ToString().Contains("_") && dt.Rows[i][1].ToString().Contains("*"))
                            {
                                fa.NUMBEROFPEOPLE = common.IntSafeConvert(dt.Rows[i][1].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                fa.NUMBEROFPEOPLE = common.IntSafeConvert(dt.Rows[i][1]);
                            }
                            if (dt.Rows[i][2].ToString().Contains("_") && dt.Rows[i][2].ToString().Contains("*"))
                            {
                                fa.LIMIT = ToDec(dt.Rows[i][2].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                fa.LIMIT = ToDec(dt.Rows[i][2]);
                            }
                            if (dt.Rows[i][3].ToString().Contains("_") && dt.Rows[i][3].ToString().Contains("*"))
                            {
                                fa.RFOUNDING = ToDec(dt.Rows[i][3].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                fa.RFOUNDING = ToDec(dt.Rows[i][3]);
                            }
                            if (dt.Rows[i][4].ToString().Contains("_") && dt.Rows[i][4].ToString().Contains("*"))
                            {
                                fa.ATCFOR = ToDec(dt.Rows[i][4].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                fa.ATCFOR = ToDec(dt.Rows[i][4]);
                            }
                            if (dt.Rows[i][5].ToString().Contains("_") && dt.Rows[i][5].ToString().Contains("*"))
                            {
                                fa.JXGLYXDY = ToDec(dt.Rows[i][5].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                fa.JXGLYXDY = ToDec(dt.Rows[i][5]);
                            }
                            if (dt.Rows[i][6].ToString().Contains("_") && dt.Rows[i][6].ToString().Contains("*"))
                            {
                                fa.DFLZYXDW = ToDec(dt.Rows[i][6].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                fa.DFLZYXDW = ToDec(dt.Rows[i][6]);
                            }
                            if (dt.Rows[i][7].ToString().Contains("_") && dt.Rows[i][7].ToString().Contains("*"))
                            {
                                fa.WBWLWCXJJ = ToDec(dt.Rows[i][7].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                fa.WBWLWCXJJ = ToDec(dt.Rows[i][7]);
                            }
                            if (dt.Rows[i][8].ToString().Contains("_") && dt.Rows[i][8].ToString().Contains("*"))
                            {
                                fa.BYHBSHGDW = ToDec(dt.Rows[i][8].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                fa.BYHBSHGDW = ToDec(dt.Rows[i][8]);
                            }
                            if (dt.Rows[i][9].ToString().Contains("_") && dt.Rows[i][9].ToString().Contains("*"))
                            {
                                fa.GFJLJF = ToDec(dt.Rows[i][9].ToString().TrimStart('_').Split('*')[1].Split('_')[0]);
                            }
                            else
                            {
                                fa.GFJLJF = ToDec(dt.Rows[i][9]);
                            }
                            if (FA_FundsAccountManager.AddFA_FundsAccount(fa).FAID > 0)
                            {
                                ImpDataBind();
                                lblShowResult.Text = "导入成功";
                            }
                            else
                            {
                                lblShowResult.Text = "操作失败，请重试";
                            }
                        }
                    }
                }
            }
        }
    }

    [DirectMethod]
    public void clicksave(string idstrs)
    {
        string[] arrstr = idstrs.Trim().TrimEnd('#').Split('#');
        for (int i = 0; i < arrstr.Length; i++)
        {
            string[] arr = arrstr[i].Split('*');
            int id = common.IntSafeConvert(arr[0], 0);
            FA_FundsAccount fa = FA_FundsAccountManager.GetFA_FundsAccountByFAID(id);
            if (fa != null)
            {
                fa.NUMBEROFPEOPLE = common.IntSafeConvert(arr[1], 0);
                if(FA_FundsAccountManager.ModifyFA_FundsAccount(fa))
                {                   
                    X.MessageBox.Alert("操作提示", "保存成功").Show();
                }
                else
                {
                    X.MessageBox.Alert("操作提示", "保存失败").Show();
                }                
            }
        }
        ImpDataBind();
    }
}