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

public partial class WebPage_SysSetting_BudConNum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtBind();
    }

    private void txtBind()
    {
        FA_SysSetting ss = FA_SysSettingManager.GetSysSettingByMaxYear();
        if (ss != null)
        {
            lblYear.Text = ss.SSYear.ToString();
        }
        int bcnyear = common.IntSafeConvert(lblYear.Text.Trim());
        FA_BudConNum bcn = FA_BudConNumManager.GetBudConNumByYear(bcnyear);
        if (bcn != null)
        {
            HidPBM.Value = bcn.BCNProExpBudMon.ToString();
            HidPAM.Value = bcn.BCNProAddBudMon.ToString();
        }
        FA_AddBudConNum abc = FA_AddBudConNumManager.GetFA_AddBudConNumByYear(bcnyear);
        if (abc != null)
        {
            HidTUM.Value = abc.TUserMon.ToString();
            HidTPM.Value = abc.TPubMon.ToString();
            HidTFM.Value = abc.TFamMon.ToString();
            HidAUM.Value = abc.AddUserMon.ToString();
            HidAPM.Value = abc.AddPubMon.ToString();
            HidAFM.Value = abc.AddFamMon.ToString();
        }
        lblthisMon.Text = (ToDec(HidTUM.Value) + ToDec(HidTPM.Value) + ToDec(HidTFM.Value)).ToString();
        lblAddMon.Text = (ToDec(HidAUM.Value) + ToDec(HidAPM.Value) + ToDec(HidAFM.Value)).ToString();
        lblBudMon.Text = (ToDec(lblthisMon.Text) + ToDec(lblAddMon.Text) + ToDec(HidPAM.Value) + ToDec(HidPBM.Value)).ToString();
        //if (bcn != null)
        //{
        //    txtBasBudMon.Text = bcn.BCNBasExpBudMon.ToString();
        //    txtProBudMon.Text = bcn.BCNProExpBudMon.ToString();
        //}
    }

    #region
    ///// <summary>
    ///// 绑定年度
    ///// </summary>
    //private void txtBind()
    //{
    //    FA_SysSetting ss = FA_SysSettingManager.GetSysSettingByYear(DateTime.Now.Year);
    //    if (ss != null)
    //    {
    //        txtYear.Text = ss.SSYear.ToString();
    //    }
    //}


    //private void dtBind()
    //{

    //    int year = common.IntSafeConvert(txtYear.Text.Trim());
    //    if (FA_ProBasiPerPayOneManager.IsProBasiPerPayOneByYear(year))
    //    {
    //        string TipMsg = year.ToString() + "年度财政二下数据已导入，不允许重复导入。";
    //        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "Tips('" + TipMsg + "')");
    //        return;
    //    }
    //    byte[] bt;
    //    DataTable dt1 = new DataTable();
    //    DataTable dt2 = new DataTable();
    //    DataTable dt3 = new DataTable();
    //    DataTable dt4 = new DataTable();

    //    if (fupFile.HasFile)
    //    {
    //        bt = fupFile.FileBytes;
    //        dt1 = ImportFinaDataLogic.GetDTBySheetname("基人一", bt, 9, 10);
    //        dt2 = ImportFinaDataLogic.GetDTBySheetname("基人二", bt, 10, 12);
    //        dt3 = ImportFinaDataLogic.GetDTBySheetname("基公", bt, 9, 21);
    //        dt4 = ImportFinaDataLogic.GetDTBySheetname("项目支出", bt, 9, 15);
    //    }
    //    else
    //    {
    //        Response.Write("没有数据");
    //    }
    //    bt = null;
    //    DateTime dtime = Convert.ToDateTime(year.ToString () + "-" + "01-" + "01");
    //    int AreaDepID = 0;
    //    FA_ProBasiPerPayOne PBPPOM = new FA_ProBasiPerPayOne();
    //    PBPPOM.POBS = ToDec(dt1.Rows[0][4]);
    //    PBPPOM.POAS = ToDec(dt1.Rows[0][5]);
    //    PBPPOM.POBonus = ToDec(dt1.Rows[0][6]);
    //    PBPPOM.POPS = ToDec(dt1.Rows[0][7]);
    //    PBPPOM.POSE = ToDec(dt1.Rows[0][8]);
    //    PBPPOM.POOther = ToDec(dt1.Rows[0][9]);
    //    PBPPOM.POTotal = ToDec(dt1.Rows[0][3]);
    //    PBPPOM.POYear = dtime;
    //    PBPPOM.DepID = AreaDepID;
    //    FA_ProBasiPerPayOneManager.AddFA_ProBasiPerPayOne(PBPPOM);

    //    FA_ProBasiPerPayTwo PBPPT = new FA_ProBasiPerPayTwo();
    //    PBPPT.RetiredPerP = ToDec(dt2.Rows[0][5]);
    //    PBPPT.RetiredPubP = ToDec(dt2.Rows[0][6]);
    //    PBPPT.RetirementPerP = ToDec(dt2.Rows[0][9]);
    //    PBPPT.RetirementPubP = ToDec(dt2.Rows[0][8]);
    //    PBPPT.PTME = ToDec(dt2.Rows[0][10]);
    //    PBPPT.PTOther = ToDec(dt2.Rows[0][11]);
    //    PBPPT.PTTotal = ToDec(dt2.Rows[0][3]);
    //    PBPPT.PTYear = dtime;
    //    PBPPT.DepID = AreaDepID;
    //    FA_ProBasiPerPayTwoManager.AddFA_ProBasiPerPayTwo(PBPPT);

    //    FA_ProBasiPubPay PBPP = new FA_ProBasiPubPay();

    //    PBPP.PBOE = ToDec(dt3.Rows[0][5]);
    //    PBPP.PBUtilities = ToDec(dt3.Rows[0][6]);
    //    PBPP.PBPF = ToDec(dt3.Rows[0][7]);
    //    PBPP.OBCFE = ToDec(dt3.Rows[0][8]);
    //    PBPP.PBTravelE = ToDec(dt3.Rows[0][9]);
    //    PBPP.PBRE = ToDec(dt3.Rows[0][10]);
    //    PBPP.PBME = ToDec(dt3.Rows[0][11]);
    //    PBPP.PBTrainE = ToDec(dt3.Rows[0][12]);
    //    PBPP.OBRE = ToDec(dt3.Rows[0][13]);
    //    PBPP.PBAE = ToDec(dt3.Rows[0][14]);
    //    PBPP.LUMD = ToDec(dt3.Rows[0][15]);
    //    PBPP.PBWE = ToDec(dt3.Rows[0][16]);
    //    PBPP.PBOCE = ToDec(dt3.Rows[0][17]);
    //    PBPP.OCASE = ToDec(dt3.Rows[0][19]);
    //    PBPP.PBTotal = ToDec(dt3.Rows[0][3]);
    //    PBPP.PBYear = dtime;
    //    PBPP.DepID = AreaDepID;
    //    FA_ProBasiPubPayManager.AddFA_ProBasiPubPay(PBPP);

    //    for (int i = 0; i < 8; i++)
    //    {
    //        FA_ProPay PP = new FA_ProPay();
    //        PP.PPID =common.IntSafeConvert(dt4.Rows[i][3].ToString().Trim());
    //        PP.ProPA0M = ToDec(dt4.Rows[i][4]);
    //        PP.ProPYear = dtime;
    //        PP.DepID = AreaDepID;
    //        FA_ProPayManager.AddFA_ProPay(PP);
    //    }
    //    lblShowResult.Text = "* 导入成功!";
    //}


    //private Decimal ToDec(object obj)
    //{
    //    Decimal decTmp = 0;
    //    if (obj != null)
    //    {
    //        string objStr = obj.ToString();
    //        if (!string.IsNullOrEmpty(objStr))
    //        {
    //            decTmp = ParseUtil.ToDecimal(objStr, decTmp);
    //        }
    //    }
    //    return decTmp;
    //}

    //protected void btnImport_Click(object sender, EventArgs e)
    //{
    //    if (fupFile.HasFile)
    //    {
    //        dtBind();
    //    }
    //    else
    //    {
    //        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "Tips('请选择文件')");
    //    }
    //}
    #endregion 

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

    protected void btnCon_Click(object sender, EventArgs e)
    {
        string bbm = lblthisMon.Text.Trim();
        string pbm = txtProBudMon.Text.Trim();
        string abm = lblAddMon.Text.Trim();
        string apm = txtProAddMon.Text.Trim();
        string tum = txtTUserMon.Text.Trim();
        string tpm = txtTPubMon.Text.Trim();
        string tfm = txtTFamMon.Text.Trim();
        string umon = txtAddUserMon.Text.Trim();
        string pmon = txtAddPubMon.Text.Trim();
        string fmon = txtAddFamMon.Text.Trim();
        int bcnyear = common.IntSafeConvert(lblYear.Text.Trim());
        int count = FA_BudConNumManager.GetBudConNumCountByYear(bcnyear);
        if (count == 0)
        {
            FA_BudConNum fa = new FA_BudConNum();
            fa.BCNBasExpBudMon = ToDec(bbm);
            fa.BCNProExpBudMon = ToDec(pbm);
            fa.BCNBasAddBudMon = ToDec(abm);
            fa.BCNProAddBudMon = ToDec(apm);
            fa.BCNYear = bcnyear;
            if (FA_BudConNumManager.AddFA_BudConNum(fa).BCID > 0)
            {
                lblShowResult.Text = "* 保存成功";
            }
            else
            {
                lblShowResult.Text = "* 操作失败，请检查后重试";
            }
        }
        else
        {
            FA_BudConNum fa = FA_BudConNumManager.GetBudConNumByYear(bcnyear);
            fa.BCNBasExpBudMon = ToDec(bbm);
            fa.BCNProExpBudMon = ToDec(pbm);
            fa.BCNBasAddBudMon = ToDec(abm);
            fa.BCNProAddBudMon = ToDec(apm);
            fa.BCNYear = bcnyear;
            if (FA_BudConNumManager.ModifyFA_BudConNum(fa))
            {
                lblShowResult.Text = "* 保存成功";
            }
            else
            {
                lblShowResult.Text = "* 操作失败，请检查后重试";
            }
        }

        FA_AddBudConNum abc = FA_AddBudConNumManager.GetFA_AddBudConNumByYear(bcnyear);
        if (abc != null)
        {
            abc.TUserMon = ToDec(tum);
            abc.TPubMon = ToDec(tpm);
            abc.TFamMon = ToDec(tfm);
            abc.AddUserMon = ToDec(umon);
            abc.AddPubMon = ToDec(pmon);
            abc.AddFamMon = ToDec(fmon);
            if (FA_AddBudConNumManager.ModifyFA_AddBudConNum(abc))
            {
                txtBind();
                lblShowResult.Text = "* 保存成功";
            }
            else
            {
                lblShowResult.Text = "* 操作失败，请检查后重试";
            }
        }
        else
        {
            FA_AddBudConNum fa = new FA_AddBudConNum();
            fa.TUserMon = ToDec(tum);
            fa.TPubMon = ToDec(tpm);
            fa.TFamMon = ToDec(tfm);
            fa.AddUserMon = ToDec(umon);
            fa.AddPubMon = ToDec(pmon);
            fa.AddFamMon = ToDec(fmon);
            fa.AddYear = bcnyear;
            if(FA_AddBudConNumManager.AddFA_AddBudConNum(fa).AddID>0)
            {
                txtBind();
                lblShowResult.Text = "* 保存成功";
            }
            else
            {
                lblShowResult.Text = "* 操作失败，请检查后重试";
            }
        }
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        lblShowResult.Text = string.Empty;
        txtBind();
    }
}