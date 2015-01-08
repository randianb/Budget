using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BudgetWeb.BLL;
using BudgetWeb.Model;
using Ext.Net;
using BudgetWeb.DAL;

public partial class WebPage_BudgetEdit_ImportFinaData : BudgetBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !X.IsAjaxRequest)
        {
            IFDYearDataBind();
        }
    }
    private void dtBind()
    {
        if (BG_ProBasiPerPayOneLogic.IsBG_ProBasiPerPayOneByyear(common.IntSafeConvert(CurrentYear)))
        {
            X.Msg.Confirm("提示", CurrentYear + "年度财政二下数据已导入，是否覆盖当前数据？", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "CompanyX.DoYes()",
                    Text = "是"
                },
                No = new MessageBoxButtonConfig
                {
                    Handler = "CompanyX.DoNo()",
                    Text = "否"
                }
            }).Show();
        }
        else
        {
            IsnotBG_ProBasiPerPay();
        }

        //X.Msg.Alert("提示", "导入成功").Show();  
    }

    [DirectMethod(Namespace = "CompanyX")]
    public void DoYes()
    {
        IsBG_ProBasiPerPay();
    }
    [DirectMethod(Namespace = "CompanyX")]
    public void DoNo()
    {

    }

    private void IsnotBG_ProBasiPerPay()
    {
        byte[] bt;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();

        if (FUFEXC.HasFile)
        {
            bt = FUFEXC.FileBytes;
            dt1 = ImportFinaDataLogic.GetDTBySheetname("基人一", bt, 9, 10);
            dt2 = ImportFinaDataLogic.GetDTBySheetname("基人二", bt, 10, 12);
            dt3 = ImportFinaDataLogic.GetDTBySheetname("基公", bt, 9, 21);
            dt4 = ImportFinaDataLogic.GetDTBySheetname("项目支出", bt, 9, 15);
        }
        else
        {
            Response.Write("没有数据");
        }
        bt = null;

        DateTime dtime = Convert.ToDateTime(CurrentYear + "-" + "01-" + "01");
        BG_ProBasiPerPayOne PBPPOM = new BG_ProBasiPerPayOne();
        PBPPOM.POBS = ParToDecimal.ParToDel(dt1.Rows[0][4].ToString());
        PBPPOM.POAS = ParToDecimal.ParToDel(dt1.Rows[0][5].ToString());
        PBPPOM.POBonus = ParToDecimal.ParToDel(dt1.Rows[0][6].ToString());
        PBPPOM.POPS = ParToDecimal.ParToDel(dt1.Rows[0][7].ToString());
        PBPPOM.POSE = ParToDecimal.ParToDel(dt1.Rows[0][8].ToString());
        PBPPOM.POOther = ParToDecimal.ParToDel(dt1.Rows[0][9].ToString());
        PBPPOM.POTitol = ParToDecimal.ParToDel(dt1.Rows[0][3].ToString());
        PBPPOM.POYear = dtime;
        PBPPOM.DepID = AreaDepID;
        BG_ProBasiPerPayOneManager.AddBG_ProBasiPerPayOne(PBPPOM);

        BG_ProBasiPerPayTwo PBPPT = new BG_ProBasiPerPayTwo();
        PBPPT.RetiredPerP = ParToDecimal.ParToDel(dt2.Rows[0][5].ToString());
        PBPPT.RetiredPubP = ParToDecimal.ParToDel(dt2.Rows[0][6].ToString());
        PBPPT.RetirementPerP = ParToDecimal.ParToDel(dt2.Rows[0][9].ToString());
        PBPPT.RetirementPubP = ParToDecimal.ParToDel(dt2.Rows[0][8].ToString());
        PBPPT.PTME = ParToDecimal.ParToDel(dt2.Rows[0][10].ToString());
        PBPPT.PTOther = ParToDecimal.ParToDel(dt2.Rows[0][11].ToString());
        PBPPT.PTTitol = ParToDecimal.ParToDel(dt2.Rows[0][3].ToString());
        PBPPT.PTYear = dtime;
        PBPPT.DepID = AreaDepID;
        BG_ProBasiPerPayTwoManager.AddBG_ProBasiPerPayTwo(PBPPT);

        BG_ProBasiPubPay PBPP = new BG_ProBasiPubPay();

        PBPP.PBOE = ParToDecimal.ParToDel(dt3.Rows[0][5].ToString());
        PBPP.PBUtilities = ParToDecimal.ParToDel(dt3.Rows[0][6].ToString());
        PBPP.PBPF = ParToDecimal.ParToDel(dt3.Rows[0][7].ToString());
        PBPP.OBCFE = ParToDecimal.ParToDel(dt3.Rows[0][8].ToString());
        PBPP.PBTravelE = ParToDecimal.ParToDel(dt3.Rows[0][9].ToString());
        PBPP.PBRE = ParToDecimal.ParToDel(dt3.Rows[0][10].ToString());
        PBPP.PBME = ParToDecimal.ParToDel(dt3.Rows[0][11].ToString());
        PBPP.PBTrainE = ParToDecimal.ParToDel(dt3.Rows[0][12].ToString());
        PBPP.OBRE = ParToDecimal.ParToDel(dt3.Rows[0][13].ToString());
        PBPP.PBAE = ParToDecimal.ParToDel(dt3.Rows[0][14].ToString());
        PBPP.LUMD = ParToDecimal.ParToDel(dt3.Rows[0][15].ToString());
        PBPP.PBWE = ParToDecimal.ParToDel(dt3.Rows[0][16].ToString());
        PBPP.PBOCE = ParToDecimal.ParToDel(dt3.Rows[0][17].ToString());
        PBPP.OCASE = ParToDecimal.ParToDel(dt3.Rows[0][19].ToString());
        PBPP.PBIDTitol = ParToDecimal.ParToDel(dt3.Rows[0][3].ToString());
        PBPP.PBYear = dtime;
        PBPP.DepID = AreaDepID;
        BG_ProBasiPubPayManager.AddBG_ProBasiPubPay(PBPP);

        for (int i = 0; i < dt4.Rows.Count; i++)
        {
            if (string.IsNullOrEmpty(dt4.Rows[i][3].ToString()))
            {
                return;
            }
            BG_ProPay PP = new BG_ProPay();
            PP.PPID = dt4.Rows[i][3].ToString().Trim();
            PP.ProPA0M = ParToDecimal.ParToDel(dt4.Rows[i][4].ToString());
            PP.ProPYear = dtime;
            PP.DepID = AreaDepID;
            BG_ProPayManager.AddBG_ProPay(PP);
        }
        X.Msg.Alert("提示", "导入成功.").Show();
    }
    private void IsBG_ProBasiPerPay()
    {
        byte[] bt;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();

        if (FUFEXC.HasFile)
        {
            bt = FUFEXC.FileBytes;
            dt1 = ImportFinaDataLogic.GetDTBySheetname("基人一", bt, 9, 10);
            dt2 = ImportFinaDataLogic.GetDTBySheetname("基人二", bt, 10, 12);
            dt3 = ImportFinaDataLogic.GetDTBySheetname("基公", bt, 9, 21);
            dt4 = ImportFinaDataLogic.GetDTBySheetname("项目支出", bt, 9, 15);
        }
        else
        {
            Response.Write("没有数据");
        }
        bt = null;

        DateTime dtime = Convert.ToDateTime(CurrentYear + "-" + "01-" + "01");
        int poid = GetPOIDByYear(CurrentYear);
        BG_ProBasiPerPayOne PBPPOM = BG_ProBasiPerPayOneManager.GetBG_ProBasiPerPayOneByPOID(poid);
        if (PBPPOM != null)
        {
            PBPPOM.POBS = ParToDecimal.ParToDel(dt1.Rows[0][4].ToString());
            PBPPOM.POAS = ParToDecimal.ParToDel(dt1.Rows[0][5].ToString());
            PBPPOM.POBonus = ParToDecimal.ParToDel(dt1.Rows[0][6].ToString());
            PBPPOM.POPS = ParToDecimal.ParToDel(dt1.Rows[0][7].ToString());
            PBPPOM.POSE = ParToDecimal.ParToDel(dt1.Rows[0][8].ToString());
            PBPPOM.POOther = ParToDecimal.ParToDel(dt1.Rows[0][9].ToString());
            PBPPOM.POTitol = ParToDecimal.ParToDel(dt1.Rows[0][3].ToString());
            PBPPOM.POYear = dtime;
            PBPPOM.DepID = AreaDepID;
            BG_ProBasiPerPayOneManager.ModifyBG_ProBasiPerPayOne(PBPPOM);
        }
        else
        {
            PBPPOM = new BG_ProBasiPerPayOne();
            PBPPOM.POBS = ParToDecimal.ParToDel(dt1.Rows[0][4].ToString());
            PBPPOM.POAS = ParToDecimal.ParToDel(dt1.Rows[0][5].ToString());
            PBPPOM.POBonus = ParToDecimal.ParToDel(dt1.Rows[0][6].ToString());
            PBPPOM.POPS = ParToDecimal.ParToDel(dt1.Rows[0][7].ToString());
            PBPPOM.POSE = ParToDecimal.ParToDel(dt1.Rows[0][8].ToString());
            PBPPOM.POOther = ParToDecimal.ParToDel(dt1.Rows[0][9].ToString());
            PBPPOM.POTitol = ParToDecimal.ParToDel(dt1.Rows[0][3].ToString());
            PBPPOM.POYear = dtime;
            PBPPOM.DepID = AreaDepID;
            BG_ProBasiPerPayOneManager.AddBG_ProBasiPerPayOne(PBPPOM);
        }

        int ptid = GetPTIDByYear(CurrentYear);
        BG_ProBasiPerPayTwo PBPPT = BG_ProBasiPerPayTwoManager.GetBG_ProBasiPerPayTwoByPTID(ptid);
        if (PBPPT != null)
        {
            PBPPT.RetiredPerP = ParToDecimal.ParToDel(dt2.Rows[0][5].ToString());
            PBPPT.RetiredPubP = ParToDecimal.ParToDel(dt2.Rows[0][6].ToString());
            PBPPT.RetirementPerP = ParToDecimal.ParToDel(dt2.Rows[0][9].ToString());
            PBPPT.RetirementPubP = ParToDecimal.ParToDel(dt2.Rows[0][8].ToString());
            PBPPT.PTME = ParToDecimal.ParToDel(dt2.Rows[0][10].ToString());
            PBPPT.PTOther = ParToDecimal.ParToDel(dt2.Rows[0][11].ToString());
            PBPPT.PTTitol = ParToDecimal.ParToDel(dt2.Rows[0][3].ToString());
            PBPPT.PTYear = dtime;
            PBPPT.DepID = AreaDepID;
            BG_ProBasiPerPayTwoManager.ModifyBG_ProBasiPerPayTwo(PBPPT);
        }
        else
        {
            PBPPT = new BG_ProBasiPerPayTwo();
            PBPPT.RetiredPerP = ParToDecimal.ParToDel(dt2.Rows[0][5].ToString());
            PBPPT.RetiredPubP = ParToDecimal.ParToDel(dt2.Rows[0][6].ToString());
            PBPPT.RetirementPerP = ParToDecimal.ParToDel(dt2.Rows[0][9].ToString());
            PBPPT.RetirementPubP = ParToDecimal.ParToDel(dt2.Rows[0][8].ToString());
            PBPPT.PTME = ParToDecimal.ParToDel(dt2.Rows[0][10].ToString());
            PBPPT.PTOther = ParToDecimal.ParToDel(dt2.Rows[0][11].ToString());
            PBPPT.PTTitol = ParToDecimal.ParToDel(dt2.Rows[0][3].ToString());
            PBPPT.PTYear = dtime;
            PBPPT.DepID = AreaDepID;
            BG_ProBasiPerPayTwoManager.AddBG_ProBasiPerPayTwo(PBPPT);
        }

        int pbid = GetPBIDByYear(CurrentYear);
        BG_ProBasiPubPay PBPP = BG_ProBasiPubPayManager.GetBG_ProBasiPubPayByPBID(pbid);

        if (PBPP != null)
        {
            PBPP.PBOE = ParToDecimal.ParToDel(dt3.Rows[0][5].ToString());
            PBPP.PBUtilities = ParToDecimal.ParToDel(dt3.Rows[0][6].ToString());
            PBPP.PBPF = ParToDecimal.ParToDel(dt3.Rows[0][7].ToString());
            PBPP.OBCFE = ParToDecimal.ParToDel(dt3.Rows[0][8].ToString());
            PBPP.PBTravelE = ParToDecimal.ParToDel(dt3.Rows[0][9].ToString());
            PBPP.PBRE = ParToDecimal.ParToDel(dt3.Rows[0][10].ToString());
            PBPP.PBME = ParToDecimal.ParToDel(dt3.Rows[0][11].ToString());
            PBPP.PBTrainE = ParToDecimal.ParToDel(dt3.Rows[0][12].ToString());
            PBPP.OBRE = ParToDecimal.ParToDel(dt3.Rows[0][13].ToString());
            PBPP.PBAE = ParToDecimal.ParToDel(dt3.Rows[0][14].ToString());
            PBPP.LUMD = ParToDecimal.ParToDel(dt3.Rows[0][15].ToString());
            PBPP.PBWE = ParToDecimal.ParToDel(dt3.Rows[0][16].ToString());
            PBPP.PBOCE = ParToDecimal.ParToDel(dt3.Rows[0][17].ToString());
            PBPP.OCASE = ParToDecimal.ParToDel(dt3.Rows[0][19].ToString());
            PBPP.PBIDTitol = ParToDecimal.ParToDel(dt3.Rows[0][3].ToString());
            PBPP.PBYear = dtime;
            PBPP.DepID = AreaDepID;
            BG_ProBasiPubPayManager.ModifyBG_ProBasiPubPay(PBPP);
        }
        else
        {
            PBPP = new BG_ProBasiPubPay();
            PBPP.PBOE = ParToDecimal.ParToDel(dt3.Rows[0][5].ToString());
            PBPP.PBUtilities = ParToDecimal.ParToDel(dt3.Rows[0][6].ToString());
            PBPP.PBPF = ParToDecimal.ParToDel(dt3.Rows[0][7].ToString());
            PBPP.OBCFE = ParToDecimal.ParToDel(dt3.Rows[0][8].ToString());
            PBPP.PBTravelE = ParToDecimal.ParToDel(dt3.Rows[0][9].ToString());
            PBPP.PBRE = ParToDecimal.ParToDel(dt3.Rows[0][10].ToString());
            PBPP.PBME = ParToDecimal.ParToDel(dt3.Rows[0][11].ToString());
            PBPP.PBTrainE = ParToDecimal.ParToDel(dt3.Rows[0][12].ToString());
            PBPP.OBRE = ParToDecimal.ParToDel(dt3.Rows[0][13].ToString());
            PBPP.PBAE = ParToDecimal.ParToDel(dt3.Rows[0][14].ToString());
            PBPP.LUMD = ParToDecimal.ParToDel(dt3.Rows[0][15].ToString());
            PBPP.PBWE = ParToDecimal.ParToDel(dt3.Rows[0][16].ToString());
            PBPP.PBOCE = ParToDecimal.ParToDel(dt3.Rows[0][17].ToString());
            PBPP.OCASE = ParToDecimal.ParToDel(dt3.Rows[0][19].ToString());
            PBPP.PBIDTitol = ParToDecimal.ParToDel(dt3.Rows[0][3].ToString());
            PBPP.PBYear = dtime;
            PBPP.DepID = AreaDepID;
            BG_ProBasiPubPayManager.AddBG_ProBasiPubPay(PBPP);
        }
        //删除一年度数据
        if (DodelBG_ProPay(CurrentYear))
        {
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt4.Rows[i][3].ToString()))
                {
                    X.Msg.Alert("提示", "导入成功.").Show();
                    return;
                }
                BG_ProPay PP = new BG_ProPay();
                PP.PPID = dt4.Rows[i][3].ToString().Trim();
                PP.ProPA0M = ParToDecimal.ParToDel(dt4.Rows[i][4].ToString());
                PP.ProPYear = dtime;
                PP.DepID = AreaDepID;
                BG_ProPayManager.AddBG_ProPay(PP);
            }
        }
        else
        {
            X.Msg.Alert("提示", "导入失败，请重试.").Show();
            return;
        }
        X.Msg.Alert("提示", "导入成功.").Show();
    }

    private bool DodelBG_ProPay(string year)
    {
        string sql = string.Format("delete from BG_ProPay where Year(ProPYear)='{0}'", year);
        int t = DBUnity.ExecuteNonQuery(CommandType.Text, sql, null);
        if (t > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int GetPBIDByYear(string year)
    {
        int t = 0;
        string sql = string.Format("select PBID from BG_ProBasiPubPay where Year(PBYear)='{0}'", year);
        t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
        return t;
    }

    private int GetPTIDByYear(string year)
    {
        int t = 0;
        string sql = string.Format("select PTID from BG_ProBasiPerPayTwo where Year(PTYear)='{0}'", year);
        t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
        return t;
    }

    private int GetPOIDByYear(string year)
    {
        int t = 0;
        string sql = string.Format("select POID from BG_ProBasiPerPayOne where Year(POYear)='{0}'", year);
        t = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
        return t;
    }
    private void IFDYearDataBind()
    {
        DataTable dt = BG_SysSettingManager.GetAllBG_SysSetting();
        int count = dt.Rows.Count;
        if (count > 0)
        {
            txtYear1.Text = CurrentYear.ToString();
        }
    }
    protected void btnImport_DirectClick(object sender, DirectEventArgs e)
    {
        if (FUFEXC.HasFile)
        {
            dtBind();
            // X.Msg.Alert("提示", "导入成功!").Show();
            //string message = "导入成功!";
            //Response.Write("<script language=javascript>alert(\"" + message.Trim() + "\");window.top.close();</script>");
        }
        else
        {
            X.Msg.Notify(new NotificationConfig()
            {
                Title = "提示",
                Html = "　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　请先选择文件！",
                Width = 250
            }).Show();
        }
    }
    protected void btnadd_DirectClick(object sender, DirectEventArgs e)
    {
        int curtime = common.IntSafeConvert(txtSuppyear.Text.Trim());
        DataTable dtpre = BG_PreLogic.GetBG_PreByyear(curtime - 1);
        decimal premon = 0;
        if (dtpre == null)
        {
            premon = 0;
        }
        else
        {
            premon = ParToDecimal.ParToDel(dtpre.Rows[0]["PreMon"].ToString());
        }
        if (!BG_SupplementaryLogic.IsSuppByYear(curtime))
        {
            BG_Supplementary bg_sup = new BG_Supplementary();
            bg_sup.SuppMon = ParToDecimal.ParToDel(txtSupp.Text.Trim()) - premon;
            bg_sup.Year = Convert.ToInt32(txtSuppyear.Text.Trim());
            BG_SupplementaryManager.AddBG_Supplementary(bg_sup);
            X.Msg.Alert("提示", "添加成功!").Show();
        }
        else
        {
            BG_Supplementary bg_sup = new BG_Supplementary();
            DataTable bgsuid = BG_SupplementaryLogic.GetBG_SupplementaryByyear(curtime);
            bg_sup.SuppID = common.IntSafeConvert(bgsuid.Rows[0]["SuppID"].ToString());
            bg_sup.SuppMon = ParToDecimal.ParToDel(txtSupp.Text.Trim()) - premon;
            bg_sup.Year = Convert.ToInt32(txtSuppyear.Text.Trim());
            bool flag = BG_SupplementaryManager.ModifyBG_Supplementary(bg_sup);
            if (flag)
            {
                X.Msg.Alert("提示", "修改成功!").Show();
            }
            else
            {
                X.Msg.Alert("提示", "修改失败，请与管理员联系!").Show();
            }
        }
    }
    protected void btnPreadd_DirectClick(object sender, DirectEventArgs e)
    {
        int curtime = common.IntSafeConvert(txtPreYear.Text.Trim());
        if (!BG_PreLogic.IsPreByYear(curtime))
        {
            BG_Pre bg_pre = new BG_Pre();
            bg_pre.PreMon = ParToDecimal.ParToDel(txtPreMon.Text.Trim());
            bg_pre.Year = Convert.ToInt32(txtPreYear.Text.Trim());
            BG_PreManager.AddBG_Pre(bg_pre);
            X.Msg.Alert("提示", "添加成功!").Show();
        }
        else
        {
            BG_Pre bg_pre = new BG_Pre();
            DataTable bgsuid = BG_PreLogic.GetBG_PreByyear(curtime);
            bg_pre.PreID = common.IntSafeConvert(bgsuid.Rows[0]["PreID"].ToString());
            bg_pre.PreMon = ParToDecimal.ParToDel(txtPreMon.Text.Trim());
            bg_pre.Year = Convert.ToInt32(txtPreYear.Text.Trim());
            bool flag = BG_PreManager.ModifyBG_Pre(bg_pre);
            if (flag)
            {
                X.Msg.Alert("提示", "修改成功!").Show();
            }
            else
            {
                X.Msg.Alert("提示", "修改失败，请与管理员联系!").Show();
            }
        }
    }
    protected void txtPreYear_DirectChange(object sender, DirectEventArgs e)
    {
        int curtime = common.IntSafeConvert(txtPreYear.Text.Trim());
        DataTable bgsuid = BG_PreLogic.GetBG_PreByyear(curtime);
        if (bgsuid.Rows.Count > 0)
        {
            if (ParToDecimal.ParToDel(bgsuid.Rows[0]["PreMon"].ToString()) == 0)
            {
                lbPre.Text = "0";
            }
            else
            {
                lbPre.Text = ParToDecimal.ParToDel(bgsuid.Rows[0]["PreMon"].ToString()).ToString();
            }
        }
        else
        {
            lbPre.Text = "0";
        }
        lbPre.Text += "万元";

    }
    protected void txtSuppyear_DirectChange(object sender, DirectEventArgs e)
    {
        int curtime = common.IntSafeConvert(txtSuppyear.Text.Trim());
        DataTable bgsuid = BG_SupplementaryLogic.GetBG_SupplementaryByyear(curtime);
        if (bgsuid.Rows.Count > 0)
        {
            if (ParToDecimal.ParToDel(bgsuid.Rows[0]["SuppMon"].ToString()) == 0)
            {
                lbsupp.Text = "0";
            }
            else
            {
                lbsupp.Text = ParToDecimal.ParToDel(bgsuid.Rows[0]["SuppMon"].ToString()).ToString();
            }
        }
        else
        {
            lbsupp.Text = "0";
        }
        lbsupp.Text += "万元";
    }
}