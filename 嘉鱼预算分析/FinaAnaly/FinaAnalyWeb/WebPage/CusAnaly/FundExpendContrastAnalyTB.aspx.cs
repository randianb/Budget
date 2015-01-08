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

public partial class WebPage_CusAnaly_FundExpendContrastAnalyTB : System.Web.UI.Page
{
    //protected Dictionary<string, decimal> DicZeroMon = null;
    //protected Dictionary<string, decimal> DicAreaMon = null;
    int uselim = 0;
    int depid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["uselim"] != null && Request.QueryString["depid"] != null)
        {
            uselim = common.IntSafeConvert(Request.QueryString["uselim"]);
            depid = common.IntSafeConvert(Request.QueryString["depid"]);
        }
    }

    #region
    private void xxxx()
    {
        decimal dcZero2 = ThisZeroMonData("办公费", "基本支出") + ThisZeroMonData("印刷费", "基本支出") + ThisZeroMonData("咨询费", "基本支出") + ThisZeroMonData("手续费", "基本支出") + ThisZeroMonData("水费", "基本支出") + ThisZeroMonData("电费", "基本支出") + ThisZeroMonData("邮电费", "基本支出")
            + ThisZeroMonData("取暖费", "基本支出") + ThisZeroMonData("物业管理费", "基本支出") + ThisZeroMonData("差旅费", "基本支出") + ThisZeroMonData("因公出国（境）费用", "基本支出") + ThisZeroMonData("维修（护）费", "基本支出") + ThisZeroMonData("租赁费", "基本支出") + ThisZeroMonData("会议费", "基本支出")
            + ThisZeroMonData("培训费", "基本支出") + ThisZeroMonData("公务接待费", "基本支出") + ThisZeroMonData("被装购置费", "基本支出") + ThisZeroMonData("劳务费", "基本支出") + ThisZeroMonData("委托业务费", "基本支出") + ThisZeroMonData("工会经费", "基本支出") + ThisZeroMonData("福利费", "基本支出")
            + ThisZeroMonData("公务用车运行维护费", "基本支出") + ThisZeroMonData("其他交通费用", "基本支出") + ThisZeroMonData("其他商品和服务支出", "基本支出");
        decimal dcArea2 = ThisAreaMonData("办公费", "基本支出") + ThisAreaMonData("印刷费", "基本支出") + ThisAreaMonData("咨询费", "基本支出") + ThisAreaMonData("手续费", "基本支出") + ThisAreaMonData("水费", "基本支出") + ThisAreaMonData("电费", "基本支出") + ThisAreaMonData("邮电费", "基本支出")
            + ThisAreaMonData("取暖费", "基本支出") + ThisAreaMonData("物业管理费", "基本支出") + ThisAreaMonData("差旅费", "基本支出") + ThisAreaMonData("因公出国（境）费用", "基本支出") + ThisAreaMonData("维修（护）费", "基本支出") + ThisAreaMonData("租赁费", "基本支出") + ThisAreaMonData("会议费", "基本支出")
            + ThisAreaMonData("培训费", "基本支出") + ThisAreaMonData("公务接待费", "基本支出") + ThisAreaMonData("被装购置费", "基本支出") + ThisAreaMonData("劳务费", "基本支出") + ThisAreaMonData("委托业务费", "基本支出") + ThisAreaMonData("工会经费", "基本支出") + ThisAreaMonData("福利费", "基本支出")
            + ThisAreaMonData("公务用车运行维护费", "基本支出") + ThisAreaMonData("其他交通费用", "基本支出") + ThisAreaMonData("其他商品和服务支出", "基本支出");
        decimal dcTZero2 = TatolZeroMonData("办公费", "基本支出") + TatolZeroMonData("印刷费", "基本支出") + TatolZeroMonData("咨询费", "基本支出") + TatolZeroMonData("手续费", "基本支出") + TatolZeroMonData("水费", "基本支出") + TatolZeroMonData("电费", "基本支出") + TatolZeroMonData("邮电费", "基本支出")
            + TatolZeroMonData("取暖费", "基本支出") + TatolZeroMonData("物业管理费", "基本支出") + TatolZeroMonData("差旅费", "基本支出") + TatolZeroMonData("因公出国（境）费用", "基本支出") + TatolZeroMonData("维修（护）费", "基本支出") + TatolZeroMonData("租赁费", "基本支出") + TatolZeroMonData("会议费", "基本支出")
            + TatolZeroMonData("培训费", "基本支出") + TatolZeroMonData("公务接待费", "基本支出") + TatolZeroMonData("被装购置费", "基本支出") + TatolZeroMonData("劳务费", "基本支出") + TatolZeroMonData("委托业务费", "基本支出") + TatolZeroMonData("工会经费", "基本支出") + TatolZeroMonData("福利费", "基本支出")
            + TatolZeroMonData("公务用车运行维护费", "基本支出") + TatolZeroMonData("其他交通费用", "基本支出") + TatolZeroMonData("其他商品和服务支出", "基本支出");
        decimal dcTArea2 = TatolAreaMonData("办公费", "基本支出") + TatolAreaMonData("印刷费", "基本支出") + TatolAreaMonData("咨询费", "基本支出") + TatolAreaMonData("手续费", "基本支出") + TatolAreaMonData("水费", "基本支出") + TatolAreaMonData("电费", "基本支出") + TatolAreaMonData("邮电费", "基本支出")
            + TatolAreaMonData("取暖费", "基本支出") + TatolAreaMonData("物业管理费", "基本支出") + TatolAreaMonData("差旅费", "基本支出") + TatolAreaMonData("因公出国（境）费用", "基本支出") + TatolAreaMonData("维修（护）费", "基本支出") + TatolAreaMonData("租赁费", "基本支出") + TatolAreaMonData("会议费", "基本支出")
            + TatolAreaMonData("培训费", "基本支出") + TatolAreaMonData("公务接待费", "基本支出") + TatolAreaMonData("被装购置费", "基本支出") + TatolAreaMonData("劳务费", "基本支出") + TatolAreaMonData("委托业务费", "基本支出") + TatolAreaMonData("工会经费", "基本支出") + TatolAreaMonData("福利费", "基本支出")
            + TatolAreaMonData("公务用车运行维护费", "基本支出") + TatolAreaMonData("其他交通费用", "基本支出") + TatolAreaMonData("其他商品和服务支出", "基本支出");
        decimal dcLZero2 = LThisZeroMonData("办公费", "基本支出") + LThisZeroMonData("印刷费", "基本支出") + LThisZeroMonData("咨询费", "基本支出") + LThisZeroMonData("手续费", "基本支出") + LThisZeroMonData("水费", "基本支出") + LThisZeroMonData("电费", "基本支出") + LThisZeroMonData("邮电费", "基本支出")
            + LThisZeroMonData("取暖费", "基本支出") + LThisZeroMonData("物业管理费", "基本支出") + LThisZeroMonData("差旅费", "基本支出") + LThisZeroMonData("因公出国（境）费用", "基本支出") + LThisZeroMonData("维修（护）费", "基本支出") + LThisZeroMonData("租赁费", "基本支出") + LThisZeroMonData("会议费", "基本支出")
            + LThisZeroMonData("培训费", "基本支出") + LThisZeroMonData("公务接待费", "基本支出") + LThisZeroMonData("被装购置费", "基本支出") + LThisZeroMonData("劳务费", "基本支出") + LThisZeroMonData("委托业务费", "基本支出") + LThisZeroMonData("工会经费", "基本支出") + LThisZeroMonData("福利费", "基本支出")
            + LThisZeroMonData("公务用车运行维护费", "基本支出") + LThisZeroMonData("其他交通费用", "基本支出") + LThisZeroMonData("其他商品和服务支出", "基本支出");
        decimal dcLArea2 = LThisAreaMonData("办公费", "基本支出") + LThisAreaMonData("印刷费", "基本支出") + LThisAreaMonData("咨询费", "基本支出") + LThisAreaMonData("手续费", "基本支出") + LThisAreaMonData("水费", "基本支出") + LThisAreaMonData("电费", "基本支出") + LThisAreaMonData("邮电费", "基本支出")
            + LThisAreaMonData("取暖费", "基本支出") + LThisAreaMonData("物业管理费", "基本支出") + LThisAreaMonData("差旅费", "基本支出") + LThisAreaMonData("因公出国（境）费用", "基本支出") + LThisAreaMonData("维修（护）费", "基本支出") + LThisAreaMonData("租赁费", "基本支出") + LThisAreaMonData("会议费", "基本支出")
            + LThisAreaMonData("培训费", "基本支出") + LThisAreaMonData("公务接待费", "基本支出") + LThisAreaMonData("被装购置费", "基本支出") + LThisAreaMonData("劳务费", "基本支出") + LThisAreaMonData("委托业务费", "基本支出") + LThisAreaMonData("工会经费", "基本支出") + LThisAreaMonData("福利费", "基本支出")
            + LThisAreaMonData("公务用车运行维护费", "基本支出") + LThisAreaMonData("其他交通费用", "基本支出") + LThisAreaMonData("其他商品和服务支出", "基本支出");
        decimal dcLTZero2 = LTatolZeroMonData("办公费", "基本支出") + LTatolZeroMonData("印刷费", "基本支出") + LTatolZeroMonData("咨询费", "基本支出") + LTatolZeroMonData("手续费", "基本支出") + LTatolZeroMonData("水费", "基本支出") + LTatolZeroMonData("电费", "基本支出") + LTatolZeroMonData("邮电费", "基本支出")
            + LTatolZeroMonData("取暖费", "基本支出") + LTatolZeroMonData("物业管理费", "基本支出") + LTatolZeroMonData("差旅费", "基本支出") + LTatolZeroMonData("因公出国（境）费用", "基本支出") + LTatolZeroMonData("维修（护）费", "基本支出") + LTatolZeroMonData("租赁费", "基本支出") + LTatolZeroMonData("会议费", "基本支出")
            + LTatolZeroMonData("培训费", "基本支出") + LTatolZeroMonData("公务接待费", "基本支出") + LTatolZeroMonData("被装购置费", "基本支出") + LTatolZeroMonData("劳务费", "基本支出") + LTatolZeroMonData("委托业务费", "基本支出") + LTatolZeroMonData("工会经费", "基本支出") + LTatolZeroMonData("福利费", "基本支出")
            + LTatolZeroMonData("公务用车运行维护费", "基本支出") + LTatolZeroMonData("其他交通费用", "基本支出") + LTatolZeroMonData("其他商品和服务支出", "基本支出");
        decimal dcLTArea2 = LTatolAreaMonData("办公费", "基本支出") + LTatolAreaMonData("印刷费", "基本支出") + LTatolAreaMonData("咨询费", "基本支出") + LTatolAreaMonData("手续费", "基本支出") + LTatolAreaMonData("水费", "基本支出") + LTatolAreaMonData("电费", "基本支出") + LTatolAreaMonData("邮电费", "基本支出")
            + LTatolAreaMonData("取暖费", "基本支出") + LTatolAreaMonData("物业管理费", "基本支出") + LTatolAreaMonData("差旅费", "基本支出") + LTatolAreaMonData("因公出国（境）费用", "基本支出") + LTatolAreaMonData("维修（护）费", "基本支出") + LTatolAreaMonData("租赁费", "基本支出") + LTatolAreaMonData("会议费", "基本支出")
            + LTatolAreaMonData("培训费", "基本支出") + LTatolAreaMonData("公务接待费", "基本支出") + LTatolAreaMonData("被装购置费", "基本支出") + LTatolAreaMonData("劳务费", "基本支出") + LTatolAreaMonData("委托业务费", "基本支出") + LTatolAreaMonData("工会经费", "基本支出") + LTatolAreaMonData("福利费", "基本支出")
            + LTatolAreaMonData("公务用车运行维护费", "基本支出") + LTatolAreaMonData("其他交通费用", "基本支出") + LTatolAreaMonData("其他商品和服务支出", "基本支出");

        decimal dcZero3 = ThisZeroMonData("离退休费", "基本支出") + ThisZeroMonData("抚恤金", "基本支出") + ThisZeroMonData("生活补助", "基本支出") + ThisZeroMonData("医疗费", "基本支出") + ThisZeroMonData("住房公积金", "基本支出") + ThisZeroMonData("提租补贴", "基本支出") + ThisZeroMonData("住房补贴", "基本支出") + ThisZeroMonData("其他对个人和家庭补助支出", "基本支出");
        decimal dcArea3 = ThisAreaMonData("离退休费", "基本支出") + ThisAreaMonData("抚恤金", "基本支出") + ThisAreaMonData("生活补助", "基本支出") + ThisAreaMonData("医疗费", "基本支出") + ThisAreaMonData("住房公积金", "基本支出") + ThisAreaMonData("提租补贴", "基本支出") + ThisAreaMonData("住房补贴", "基本支出") + ThisAreaMonData("其他对个人和家庭补助支出", "基本支出");
        decimal dcTZero3 = TatolZeroMonData("离退休费", "基本支出") + TatolZeroMonData("抚恤金", "基本支出") + TatolZeroMonData("生活补助", "基本支出") + TatolZeroMonData("医疗费", "基本支出") + TatolZeroMonData("住房公积金", "基本支出") + TatolZeroMonData("提租补贴", "基本支出") + TatolZeroMonData("住房补贴", "基本支出") + TatolZeroMonData("其他对个人和家庭补助支出", "基本支出");
        decimal dcTArea3 = TatolAreaMonData("离退休费", "基本支出") + TatolAreaMonData("抚恤金", "基本支出") + TatolAreaMonData("生活补助", "基本支出") + TatolAreaMonData("医疗费", "基本支出") + TatolAreaMonData("住房公积金", "基本支出") + TatolAreaMonData("提租补贴", "基本支出") + TatolAreaMonData("住房补贴", "基本支出") + TatolAreaMonData("其他对个人和家庭补助支出", "基本支出");
        decimal dcLZero3 = LThisZeroMonData("离退休费", "基本支出") + LThisZeroMonData("抚恤金", "基本支出") + LThisZeroMonData("生活补助", "基本支出") + LThisZeroMonData("医疗费", "基本支出") + LThisZeroMonData("住房公积金", "基本支出") + LThisZeroMonData("提租补贴", "基本支出") + LThisZeroMonData("住房补贴", "基本支出") + LThisZeroMonData("其他对个人和家庭补助支出", "基本支出");
        decimal dcLArea3 = LThisAreaMonData("离退休费", "基本支出") + LThisAreaMonData("抚恤金", "基本支出") + LThisAreaMonData("生活补助", "基本支出") + LThisAreaMonData("医疗费", "基本支出") + LThisAreaMonData("住房公积金", "基本支出") + LThisAreaMonData("提租补贴", "基本支出") + LThisAreaMonData("住房补贴", "基本支出") + LThisAreaMonData("其他对个人和家庭补助支出", "基本支出");
        decimal dcLTZero3 = LTatolZeroMonData("离退休费", "基本支出") + LTatolZeroMonData("抚恤金", "基本支出") + LTatolZeroMonData("生活补助", "基本支出") + LTatolZeroMonData("医疗费", "基本支出") + LTatolZeroMonData("住房公积金", "基本支出") + LTatolZeroMonData("提租补贴", "基本支出") + LTatolZeroMonData("住房补贴", "基本支出") + LTatolZeroMonData("其他对个人和家庭补助支出", "基本支出");
        decimal dcLTArea3 = LTatolAreaMonData("离退休费", "基本支出") + LTatolAreaMonData("抚恤金", "基本支出") + LTatolAreaMonData("生活补助", "基本支出") + LTatolAreaMonData("医疗费", "基本支出") + LTatolAreaMonData("住房公积金", "基本支出") + LTatolAreaMonData("提租补贴", "基本支出") + LTatolAreaMonData("住房补贴", "基本支出") + LTatolAreaMonData("其他对个人和家庭补助支出", "基本支出");

        decimal dcZero4 = ThisZeroMonData("津贴补贴", "项目支出") + ThisZeroMonData("奖金", "项目支出");
        decimal dcArea4 = ThisAreaMonData("津贴补贴", "项目支出") + ThisAreaMonData("奖金", "项目支出");
        decimal dcTZero4 = TatolZeroMonData("津贴补贴", "项目支出") + TatolZeroMonData("奖金", "项目支出");
        decimal dcTArea4 = TatolAreaMonData("津贴补贴", "项目支出") + TatolAreaMonData("奖金", "项目支出");
        decimal dcLZero4 = LThisZeroMonData("津贴补贴", "项目支出") + LThisZeroMonData("奖金", "项目支出");
        decimal dcLArea4 = LThisAreaMonData("津贴补贴", "项目支出") + LThisAreaMonData("奖金", "项目支出");
        decimal dcLTZero4 = LTatolZeroMonData("津贴补贴", "项目支出") + LTatolZeroMonData("奖金", "项目支出");
        decimal dcLTArea4 = LTatolAreaMonData("津贴补贴", "项目支出") + LTatolAreaMonData("奖金", "项目支出");

        decimal dcZero5 = ThisZeroMonData("税法宣传费", "项目支出") + ThisZeroMonData("稽查办案费", "项目支出") + ThisZeroMonData("税务工作经费", "项目支出") + ThisZeroMonData("发票工作经费", "项目支出") + ThisZeroMonData("协税护税费", "项目支出") + ThisZeroMonData("党团工会活动经费", "项目支出") + ThisZeroMonData("妇代会", "项目支出") + ThisZeroMonData("三代手续费", "项目支出") + ThisZeroMonData("计算机应用经费", "项目支出") + ThisZeroMonData("其他", "项目支出");
        decimal dcArea5 = ThisAreaMonData("税法宣传费", "项目支出") + ThisAreaMonData("稽查办案费", "项目支出") + ThisAreaMonData("税务工作经费", "项目支出") + ThisAreaMonData("发票工作经费", "项目支出") + ThisAreaMonData("协税护税费", "项目支出") + ThisAreaMonData("党团工会活动经费", "项目支出") + ThisAreaMonData("妇代会", "项目支出") + ThisAreaMonData("三代手续费", "项目支出") + ThisAreaMonData("计算机应用经费", "项目支出") + ThisAreaMonData("其他", "项目支出");
        decimal dcTZero5 = TatolZeroMonData("税法宣传费", "项目支出") + TatolZeroMonData("稽查办案费", "项目支出") + TatolZeroMonData("税务工作经费", "项目支出") + TatolZeroMonData("发票工作经费", "项目支出") + TatolZeroMonData("协税护税费", "项目支出") + TatolZeroMonData("党团工会活动经费", "项目支出") + TatolZeroMonData("妇代会", "项目支出") + TatolZeroMonData("三代手续费", "项目支出") + TatolZeroMonData("计算机应用经费", "项目支出") + TatolZeroMonData("其他", "项目支出");
        decimal dcTArea5 = TatolAreaMonData("税法宣传费", "项目支出") + TatolAreaMonData("稽查办案费", "项目支出") + TatolAreaMonData("税务工作经费", "项目支出") + TatolAreaMonData("发票工作经费", "项目支出") + TatolAreaMonData("协税护税费", "项目支出") + TatolAreaMonData("党团工会活动经费", "项目支出") + TatolAreaMonData("妇代会", "项目支出") + TatolAreaMonData("三代手续费", "项目支出") + TatolAreaMonData("计算机应用经费", "项目支出") + TatolAreaMonData("其他", "项目支出");
        decimal dcLZero5 = LThisZeroMonData("税法宣传费", "项目支出") + LThisZeroMonData("稽查办案费", "项目支出") + LThisZeroMonData("税务工作经费", "项目支出") + LThisZeroMonData("发票工作经费", "项目支出") + LThisZeroMonData("协税护税费", "项目支出") + LThisZeroMonData("党团工会活动经费", "项目支出") + LThisZeroMonData("妇代会", "项目支出") + LThisZeroMonData("三代手续费", "项目支出") + LThisZeroMonData("计算机应用经费", "项目支出") + LThisZeroMonData("其他", "项目支出");
        decimal dcLArea5 = LThisAreaMonData("税法宣传费", "项目支出") + LThisAreaMonData("稽查办案费", "项目支出") + LThisAreaMonData("税务工作经费", "项目支出") + LThisAreaMonData("发票工作经费", "项目支出") + LThisAreaMonData("协税护税费", "项目支出") + LThisAreaMonData("党团工会活动经费", "项目支出") + LThisAreaMonData("妇代会", "项目支出") + LThisAreaMonData("三代手续费", "项目支出") + LThisAreaMonData("计算机应用经费", "项目支出") + LThisAreaMonData("其他", "项目支出");
        decimal dcLTZero5 = LTatolZeroMonData("税法宣传费", "项目支出") + LTatolZeroMonData("稽查办案费", "项目支出") + LTatolZeroMonData("税务工作经费", "项目支出") + LTatolZeroMonData("发票工作经费", "项目支出") + LTatolZeroMonData("协税护税费", "项目支出") + LTatolZeroMonData("党团工会活动经费", "项目支出") + LTatolZeroMonData("妇代会", "项目支出") + LTatolZeroMonData("三代手续费", "项目支出") + LTatolZeroMonData("计算机应用经费", "项目支出") + LTatolZeroMonData("其他", "项目支出");
        decimal dcLTArea5 = LTatolAreaMonData("税法宣传费", "项目支出") + LTatolAreaMonData("稽查办案费", "项目支出") + LTatolAreaMonData("税务工作经费", "项目支出") + LTatolAreaMonData("发票工作经费", "项目支出") + LTatolAreaMonData("协税护税费", "项目支出") + LTatolAreaMonData("党团工会活动经费", "项目支出") + LTatolAreaMonData("妇代会", "项目支出") + LTatolAreaMonData("三代手续费", "项目支出") + LTatolAreaMonData("计算机应用经费", "项目支出") + LTatolAreaMonData("其他", "项目支出");

        decimal dcZero6 = ThisZeroMonData("房屋建筑物购建", "项目支出") + ThisZeroMonData("办公设备购置费", "项目支出") + ThisZeroMonData("专用设备购置费", "项目支出") + ThisZeroMonData("交通工具购置费", "项目支出") + ThisZeroMonData("大型修缮", "项目支出") + ThisZeroMonData("信息网络购建", "项目支出") + ThisZeroMonData("其他资本性支出", "项目支出");
        decimal dcArea6 = ThisAreaMonData("房屋建筑物购建", "项目支出") + ThisAreaMonData("办公设备购置费", "项目支出") + ThisAreaMonData("专用设备购置费", "项目支出") + ThisAreaMonData("交通工具购置费", "项目支出") + ThisAreaMonData("大型修缮", "项目支出") + ThisAreaMonData("信息网络购建", "项目支出") + ThisAreaMonData("其他资本性支出", "项目支出");
        decimal dcTZero6 = TatolZeroMonData("房屋建筑物购建", "项目支出") + TatolZeroMonData("办公设备购置费", "项目支出") + TatolZeroMonData("专用设备购置费", "项目支出") + TatolZeroMonData("交通工具购置费", "项目支出") + TatolZeroMonData("大型修缮", "项目支出") + TatolZeroMonData("信息网络购建", "项目支出") + TatolZeroMonData("其他资本性支出", "项目支出");
        decimal dcTArea6 = TatolAreaMonData("房屋建筑物购建", "项目支出") + TatolAreaMonData("办公设备购置费", "项目支出") + TatolAreaMonData("专用设备购置费", "项目支出") + TatolAreaMonData("交通工具购置费", "项目支出") + TatolAreaMonData("大型修缮", "项目支出") + TatolAreaMonData("信息网络购建", "项目支出") + TatolAreaMonData("其他资本性支出", "项目支出");
        decimal dcLZero6 = LThisZeroMonData("房屋建筑物购建", "项目支出") + LThisZeroMonData("办公设备购置费", "项目支出") + LThisZeroMonData("专用设备购置费", "项目支出") + LThisZeroMonData("交通工具购置费", "项目支出") + LThisZeroMonData("大型修缮", "项目支出") + LThisZeroMonData("信息网络购建", "项目支出") + LThisZeroMonData("其他资本性支出", "项目支出");
        decimal dcLArea6 = LThisAreaMonData("房屋建筑物购建", "项目支出") + LThisAreaMonData("办公设备购置费", "项目支出") + LThisAreaMonData("专用设备购置费", "项目支出") + LThisAreaMonData("交通工具购置费", "项目支出") + LThisAreaMonData("大型修缮", "项目支出") + LThisAreaMonData("信息网络购建", "项目支出") + LThisAreaMonData("其他资本性支出", "项目支出");
        decimal dcLTZero6 = LTatolZeroMonData("房屋建筑物购建", "项目支出") + LTatolZeroMonData("办公设备购置费", "项目支出") + LTatolZeroMonData("专用设备购置费", "项目支出") + LTatolZeroMonData("交通工具购置费", "项目支出") + LTatolZeroMonData("大型修缮", "项目支出") + LTatolZeroMonData("信息网络购建", "项目支出") + LTatolZeroMonData("其他资本性支出", "项目支出");
        decimal dcLTArea6 = LTatolAreaMonData("房屋建筑物购建", "项目支出") + LTatolAreaMonData("办公设备购置费", "项目支出") + LTatolAreaMonData("专用设备购置费", "项目支出") + LTatolAreaMonData("交通工具购置费", "项目支出") + LTatolAreaMonData("大型修缮", "项目支出") + LTatolAreaMonData("信息网络购建", "项目支出") + LTatolAreaMonData("其他资本性支出", "项目支出");
    }
    #endregion

    /// <summary>
    /// 本月零户金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal ThisZeroMonData(string str, string type)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        decimal dcZero = 0;
        DateTime time = Convert.ToDateTime(tbDate.Text);
        if (uselim == 1001)
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    FA_XOutlayDepCK oick1 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimepiiddepid(time, piid, depid);
                    if (oick1 != null)
                    {
                        dcZero = dcZero + oick1.ODCkZeroMon;
                    }
                }
            }
        }
        else
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    FA_XOutlayIncomeCK oick1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                    if (oick1 != null)
                    {
                        dcZero = dcZero + oick1.ODCKZeroMon;
                    }
                }
            }
        }
        return dcZero;
    }

    private decimal ThisZeroMonDataL(string str, string type, int length)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        decimal dcZero = 0;
        DateTime time = Convert.ToDateTime(tbDate.Text);
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = 0;
                string piestr = dt.Rows[j]["PIEcoSubCoding"].ToString();
                if (dt.Rows[j]["PIType"].ToString() == type && piestr.Length == length)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                }
                FA_XOutlayIncomeCK oick1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                if (oick1 != null)
                {
                    dcZero = dcZero + oick1.ODCKZeroMon;
                }
            }
        }
        return dcZero;
    }

    /// <summary>
    /// 本月区级金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal ThisAreaMonData(string str, string type)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        decimal dcZero = 0;
        DateTime time = Convert.ToDateTime(tbDate.Text);
        if (uselim == 1001)
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    FA_XOutlayDepCK oick1 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimepiiddepid(time, piid, depid);
                    if (oick1 != null)
                    {
                        dcZero = dcZero + oick1.ODCkAreaMon;
                    }
                }
            }
        }
        else
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    FA_XOutlayIncomeCK oick1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                    if (oick1 != null)
                    {
                        dcZero = dcZero + oick1.ODCKAreaMon;
                    }
                }
            }
        }
        return dcZero;
    }

    private decimal ThisAreaMonDataL(string str, string type, int length)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        decimal dcZero = 0;
        DateTime time = Convert.ToDateTime(tbDate.Text);
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = 0;
                string piestr = dt.Rows[j]["PIEcoSubCoding"].ToString();
                if (dt.Rows[j]["PIType"].ToString() == type && piestr.Length == length)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                }
                FA_XOutlayIncomeCK oick1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                if (oick1 != null)
                {
                    dcZero = dcZero + oick1.ODCKAreaMon;
                }
            }
        }
        return dcZero;
    }

    /// <summary>
    /// 一季度零户金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal TatolZeroMonData(string str, string type)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        decimal dclTatol = 0;
        if (uselim == 1001)
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    decimal dclBudTatol = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    for (int i = mon; i > 0; i--)
                    {
                        DateTime time1 = Convert.ToDateTime(year.ToString() + "-" + i.ToString());
                        FA_XOutlayDepCK oick11 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimepiiddepid(time1, piid, depid);
                        if (oick11 != null)
                        {
                            dclBudTatol = dclBudTatol + oick11.ODCkZeroMon;
                        }
                    }
                    dclTatol = dclTatol + dclBudTatol;
                }
            }
        }
        else
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    decimal dclBudTatol = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    for (int i = mon; i > 0; i--)
                    {
                        DateTime time1 = Convert.ToDateTime(year.ToString() + "-" + i.ToString());
                        FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                        if (oick11 != null)
                        {
                            dclBudTatol = dclBudTatol + oick11.ODCKZeroMon;
                        }
                    }
                    dclTatol = dclTatol + dclBudTatol;
                }
            }
        }
        return dclTatol;
    }

    private decimal TatolZeroMonDataL(string str, string type, int length)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        decimal dclTatol = 0;
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = 0;
                decimal dclBudTatol = 0;
                string piestr = dt.Rows[j]["PIEcoSubCoding"].ToString();
                if (dt.Rows[j]["PIType"].ToString() == type && piestr.Length == length)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                }
                for (int i = mon; i > 0; i--)
                {
                    DateTime time1 = Convert.ToDateTime(year.ToString() + "-" + i.ToString());
                    FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                    if (oick11 != null)
                    {
                        dclBudTatol = dclBudTatol + oick11.ODCKZeroMon;
                    }
                }
                dclTatol = dclTatol + dclBudTatol;
            }
        }

        return dclTatol;
    }

    /// <summary>
    /// 一季度区级金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal TatolAreaMonData(string str, string type)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        decimal dclTatol = 0;
        if (uselim == 1001)
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    decimal dclBudTatol = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    for (int i = mon; i > 0; i--)
                    {
                        DateTime time1 = Convert.ToDateTime(year.ToString() + "-" + i.ToString());
                        FA_XOutlayDepCK oick11 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimepiiddepid(time1, piid, depid);
                        if (oick11 != null)
                        {
                            dclBudTatol = dclBudTatol + oick11.ODCkAreaMon;
                        }
                    }
                    dclTatol = dclTatol + dclBudTatol;
                }
            }
        }
        else
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    decimal dclBudTatol = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    for (int i = mon; i > 0; i--)
                    {
                        DateTime time1 = Convert.ToDateTime(year.ToString() + "-" + i.ToString());
                        FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                        if (oick11 != null)
                        {
                            dclBudTatol = dclBudTatol + oick11.ODCKAreaMon;
                        }
                    }
                    dclTatol = dclTatol + dclBudTatol;
                }
            }
        }
        return dclTatol;
    }

    private decimal TatolAreaMonDataL(string str, string type, int length)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        decimal dclTatol = 0;
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = 0;
                decimal dclBudTatol = 0;
                string piestr = dt.Rows[j]["PIEcoSubCoding"].ToString();
                if (dt.Rows[j]["PIType"].ToString() == type && piestr.Length == length)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                }
                for (int i = mon; i > 0; i--)
                {
                    DateTime time1 = Convert.ToDateTime(year.ToString() + "-" + i.ToString());
                    FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                    if (oick11 != null)
                    {
                        dclBudTatol = dclBudTatol + oick11.ODCKAreaMon;
                    }
                }
                dclTatol = dclTatol + dclBudTatol;
            }
        }
        return dclTatol;
    }

    /// <summary>
    /// 去年本月零户金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal LThisZeroMonData(string str, string type)
    {
        decimal dcDistrict = 0;
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int Lyear = year - 1;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        DateTime time = Convert.ToDateTime(Lyear.ToString() + "-" + mon.ToString());
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = 0;
                if (dt.Rows[j]["PIType"].ToString() == type)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                }
                FA_XOutlayIncomeCK oick1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                if (oick1 != null)
                {
                    dcDistrict = dcDistrict + oick1.ODCKZeroMon;
                }
            }
        }
        return dcDistrict;

    }

    private decimal LThisZeroMonDataL(string str, string type, int length)
    {
        decimal dcDistrict = 0;
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int Lyear = year - 1;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        DateTime time = Convert.ToDateTime(Lyear.ToString() + "-" + mon.ToString());
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = 0;
                string piestr = dt.Rows[j]["PIEcoSubCoding"].ToString();
                if (dt.Rows[j]["PIType"].ToString() == type && piestr.Length == length)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                }
                FA_XOutlayIncomeCK oick1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                if (oick1 != null)
                {
                    dcDistrict = dcDistrict + oick1.ODCKZeroMon;
                }
            }
        }
        return dcDistrict;

    }

    /// <summary>
    /// 去年本月区级金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal LThisAreaMonData(string str, string type)
    {
        decimal dcDistrict = 0;
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int Lyear = year - 1;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        DateTime time = Convert.ToDateTime(Lyear.ToString() + "-" + mon.ToString());
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = 0;
                if (dt.Rows[j]["PIType"].ToString() == type)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                }
                FA_XOutlayIncomeCK oick1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                if (oick1 != null)
                {
                    dcDistrict = dcDistrict + oick1.ODCKAreaMon;
                }
            }
        }
        return dcDistrict;

    }

    private decimal LThisAreaMonDataL(string str, string type, int length)
    {
        decimal dcDistrict = 0;
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int Lyear = year - 1;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        DateTime time = Convert.ToDateTime(Lyear.ToString() + "-" + mon.ToString());
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = 0;
                string piestr = dt.Rows[j]["PIEcoSubCoding"].ToString();
                if (dt.Rows[j]["PIType"].ToString() == type && piestr.Length == length)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                }
                FA_XOutlayIncomeCK oick1 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time, piid);
                if (oick1 != null)
                {
                    dcDistrict = dcDistrict + oick1.ODCKAreaMon;
                }
            }
        }
        return dcDistrict;

    }

    /// <summary>
    /// 去年一季度累计零户金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal LTatolZeroMonData(string str, string type)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int Lyear = year - 1;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        decimal dclTatol = 0;
        if (uselim == 1001)
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    decimal dclBudTatol = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    for (int i = mon; i > 0; i--)
                    {
                        DateTime time1 = Convert.ToDateTime(Lyear.ToString() + "-" + i.ToString());
                        FA_XOutlayDepCK oick11 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimepiiddepid(time1, piid, depid);
                        if (oick11 != null)
                        {
                            dclBudTatol = dclBudTatol + oick11.ODCkZeroMon;
                        }
                    }
                    dclTatol = dclTatol + dclBudTatol;
                }
            }
        }
        else
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    decimal dclBudTatol = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    for (int i = mon; i > 0; i--)
                    {
                        DateTime time1 = Convert.ToDateTime(Lyear.ToString() + "-" + i.ToString());
                        FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                        if (oick11 != null)
                        {
                            dclBudTatol = dclBudTatol + oick11.ODCKZeroMon;
                        }
                    }
                    dclTatol = dclTatol + dclBudTatol;
                }
            }
        }
        return dclTatol;

    }

    private decimal LTatolZeroMonDataL(string str, string type, int length)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int Lyear = year - 1;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        decimal dclTatol = 0;
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = 0;
                decimal dclBudTatol = 0;
                string piestr = dt.Rows[j]["PIEcoSubCoding"].ToString();
                if (dt.Rows[j]["PIType"].ToString() == type && piestr.Length == length)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                }
                for (int i = mon; i > 0; i--)
                {
                    DateTime time1 = Convert.ToDateTime(Lyear.ToString() + "-" + i.ToString());
                    FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                    if (oick11 != null)
                    {
                        dclBudTatol = dclBudTatol + oick11.ODCKZeroMon;
                    }
                }
                dclTatol = dclTatol + dclBudTatol;
            }
        }
        return dclTatol;

    }

    /// <summary>
    /// 去年一季度累计区级金额
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private decimal LTatolAreaMonData(string str, string type)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int Lyear = year - 1;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        decimal dclTatol = 0;
        if (uselim == 1001)
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    decimal dclBudTatol = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    for (int i = mon; i > 0; i--)
                    {
                        DateTime time1 = Convert.ToDateTime(Lyear.ToString() + "-" + i.ToString());
                        FA_XOutlayDepCK oick11 = FA_XOutlayDepCKManager.GetXOutlayDepCKByTimepiiddepid(time1, piid, depid);
                        if (oick11 != null)
                        {
                            dclBudTatol = dclBudTatol + oick11.ODCkAreaMon;
                        }
                    }
                    dclTatol = dclTatol + dclBudTatol;
                }
            }
        }
        else
        {
            DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    int piid = 0;
                    decimal dclBudTatol = 0;
                    if (dt.Rows[j]["PIType"].ToString() == type)
                    {
                        piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                    }
                    for (int i = mon; i > 0; i--)
                    {
                        DateTime time1 = Convert.ToDateTime(Lyear.ToString() + "-" + i.ToString());
                        FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                        if (oick11 != null)
                        {
                            dclBudTatol = dclBudTatol + oick11.ODCKAreaMon;
                        }
                    }
                    dclTatol = dclTatol + dclBudTatol;
                }
            }
        }
        return dclTatol;

    }

    private decimal LTatolAreaMonDataL(string str, string type, int length)
    {
        int year = Convert.ToDateTime(tbDate.Text).Year;
        int Lyear = year - 1;
        int mon = Convert.ToDateTime(tbDate.Text).Month;
        decimal dclTatol = 0;
        DataTable dt = FA_XPayIncomeManager.GetXPayIncomeByPIecosubnamedt(str);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                int piid = 0;
                decimal dclBudTatol = 0;
                string piestr = dt.Rows[j]["PIEcoSubCoding"].ToString();
                if (dt.Rows[j]["PIType"].ToString() == type && piestr.Length == length)
                {
                    piid = common.IntSafeConvert(dt.Rows[j]["PIID"]);
                }
                for (int i = mon; i > 0; i--)
                {
                    DateTime time1 = Convert.ToDateTime(Lyear.ToString() + "-" + i.ToString());
                    FA_XOutlayIncomeCK oick11 = FA_XOutlayIncomeCKManager.GetXOutlayIncomeCKByTime(time1, piid);
                    if (oick11 != null)
                    {
                        dclBudTatol = dclBudTatol + oick11.ODCKAreaMon;
                    }
                }
                dclTatol = dclTatol + dclBudTatol;
            }
        }
        return dclTatol;

    }


    private void AddDataRow(DataTable dt, string name1, string name2, string type)
    {
        DataRow dr = dt.NewRow();
        dr["column1"] = name1;
        if (LThisZeroMonData(name2, type) + LThisAreaMonData(name2, type) != 0)
        {
            dr["column2"] = (LThisZeroMonData(name2, type) + LThisAreaMonData(name2, type)).ToString("f2");
        }
        if (LThisZeroMonData(name2, type) != 0)
        {
            dr["column3"] = (LThisZeroMonData(name2, type)).ToString("f2");
        }
        if (LThisAreaMonData(name2, type) != 0)
        {
            dr["column4"] = (LThisAreaMonData(name2, type)).ToString("f2");
        }
        if (LTatolZeroMonData(name2, type) + LTatolAreaMonData(name2, type) != 0)
        {
            dr["column5"] = (LTatolZeroMonData(name2, type) + LTatolAreaMonData(name2, type)).ToString("f2");
        }
        if (LTatolZeroMonData(name2, type) != 0)
        {
            dr["column6"] = (LTatolZeroMonData(name2, type)).ToString("f2");
        }
        if (LTatolAreaMonData(name2, type) != 0)
        {
            dr["column7"] = (LTatolAreaMonData(name2, type)).ToString("f2");
        }
        if (ThisZeroMonData(name2, type) + ThisAreaMonData(name2, type) != 0)
        {
            dr["column8"] = (ThisZeroMonData(name2, type) + ThisAreaMonData(name2, type)).ToString("f2");
        }
        if (ThisZeroMonData(name2, type) != 0)
        {
            dr["column9"] = (ThisZeroMonData(name2, type)).ToString("f2");
        }
        if (ThisAreaMonData(name2, type) != 0)
        {
            dr["column10"] = (ThisAreaMonData(name2, type)).ToString("f2");
        }
        if (TatolZeroMonData(name2, type) + TatolAreaMonData(name2, type) != 0)
        {
            dr["column11"] = (TatolZeroMonData(name2, type) + TatolAreaMonData(name2, type)).ToString("f2");
        }
        if (TatolZeroMonData(name2, type) != 0)
        {
            dr["column12"] = (TatolZeroMonData(name2, type)).ToString("f2");
        }
        if (TatolAreaMonData(name2, type) != 0)
        {
            dr["column13"] = (TatolAreaMonData(name2, type)).ToString("f2");
        }
        if (ToDec(dr["column2"]) != 0 && (ToDec(dr["column8"]) - ToDec(dr["column2"])) != 0)
        {
            dr["column14"] = (((ToDec(dr["column8"]) - ToDec(dr["column2"])) / ToDec(dr["column2"])) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr["column5"]) != 0 && (ToDec(dr["column11"]) - ToDec(dr["column5"])) != 0)
        {
            dr["column15"] = (((ToDec(dr["column11"]) - ToDec(dr["column5"])) / ToDec(dr["column5"])) * 100).ToString("f2") + "%";
        }
        if ((ToDec(dr["column8"]) - ToDec(dr["column2"])) != 0)
        {
            dr["column16"] = (ToDec(dr["column8"]) - ToDec(dr["column2"])).ToString("f2");
        }
        if ((ToDec(dr["column11"]) - ToDec(dr["column5"])) != 0)
        {
            dr["column17"] = (ToDec(dr["column11"]) - ToDec(dr["column5"])).ToString("f2");
        }
        dt.Rows.Add(dr);
    }

    private void AddDataRow1(DataTable dt, string name1, string name2, string name3, string name4, string type)
    {
        DataRow dr = dt.NewRow();
        dr["column1"] = name1;
        dr["column1"] = name1;
        if (LThisZeroMonData(name2, type) + LThisZeroMonData(name3, type) + LThisZeroMonData(name4, type) + LThisAreaMonData(name2, type) + LThisAreaMonData(name3, type) + LThisAreaMonData(name4, type) != 0)
        {
            dr["column2"] = (LThisZeroMonData(name2, type) + LThisZeroMonData(name3, type) + LThisZeroMonData(name4, type) + LThisAreaMonData(name2, type) + LThisAreaMonData(name3, type) + LThisAreaMonData(name4, type)).ToString("f2");
        }
        if (LThisZeroMonData(name2, type) + LThisZeroMonData(name3, type) + LThisZeroMonData(name4, type) != 0)
        {
            dr["column3"] = (LThisZeroMonData(name2, type) + LThisZeroMonData(name3, type) + LThisZeroMonData(name4, type)).ToString("f2");
        }
        if (LThisAreaMonData(name2, type) + LThisAreaMonData(name3, type) + LThisAreaMonData(name4, type) != 0)
        {
            dr["column4"] = (LThisAreaMonData(name2, type) + LThisAreaMonData(name3, type) + LThisAreaMonData(name4, type)).ToString("f2");
        }
        if (LTatolZeroMonData(name2, type) + LTatolZeroMonData(name3, type) + LTatolZeroMonData(name4, type) + LTatolAreaMonData(name2, type) + LTatolAreaMonData(name3, type) + LTatolAreaMonData(name4, type) != 0)
        {
            dr["column5"] = (LTatolZeroMonData(name2, type) + LTatolZeroMonData(name3, type) + LTatolZeroMonData(name4, type) + LTatolAreaMonData(name2, type) + LTatolAreaMonData(name3, type) + LTatolAreaMonData(name4, type)).ToString("f2");
        }
        if (LTatolZeroMonData(name2, type) + LTatolZeroMonData(name3, type) + LTatolZeroMonData(name4, type) != 0)
        {
            dr["column6"] = (LTatolZeroMonData(name2, type) + LTatolZeroMonData(name3, type) + LTatolZeroMonData(name4, type)).ToString("f2");
        }
        if (LTatolAreaMonData(name2, type) + LTatolAreaMonData(name3, type) + LTatolAreaMonData(name4, type) != 0)
        {
            dr["column7"] = (LTatolAreaMonData(name2, type) + LTatolAreaMonData(name3, type) + LTatolAreaMonData(name4, type)).ToString("f2");
        }
        if (ThisZeroMonData(name2, type) + ThisZeroMonData(name3, type) + ThisZeroMonData(name4, type) + ThisAreaMonData(name2, type) + ThisAreaMonData(name3, type) + ThisAreaMonData(name4, type) != 0)
        {
            dr["column8"] = (ThisZeroMonData(name2, type) + ThisZeroMonData(name3, type) + ThisZeroMonData(name4, type) + ThisAreaMonData(name2, type) + ThisAreaMonData(name3, type) + ThisAreaMonData(name4, type)).ToString("f2");
        }
        if (ThisZeroMonData(name2, type) + ThisZeroMonData(name3, type) + ThisZeroMonData(name4, type) != 0)
        {
            dr["column9"] = (ThisZeroMonData(name2, type) + ThisZeroMonData(name3, type) + ThisZeroMonData(name4, type)).ToString("f2");
        }
        if (ThisAreaMonData(name2, type) + ThisAreaMonData(name3, type) + ThisAreaMonData(name4, type) != 0)
        {
            dr["column10"] = (ThisAreaMonData(name2, type) + ThisAreaMonData(name3, type) + ThisAreaMonData(name4, type)).ToString("f2");
        }
        if (TatolZeroMonData(name2, type) + TatolZeroMonData(name3, type) + TatolZeroMonData(name4, type) + TatolAreaMonData(name2, type) + TatolAreaMonData(name3, type) + TatolAreaMonData(name4, type) != 0)
        {
            dr["column11"] = (TatolZeroMonData(name2, type) + TatolZeroMonData(name3, type) + TatolZeroMonData(name4, type) + TatolAreaMonData(name2, type) + TatolAreaMonData(name3, type) + TatolAreaMonData(name4, type)).ToString("f2");
        }
        if (TatolZeroMonData(name2, type) + TatolZeroMonData(name3, type) + TatolZeroMonData(name4, type) != 0)
        {
            dr["column12"] = (TatolZeroMonData(name2, type) + TatolZeroMonData(name3, type) + TatolZeroMonData(name4, type)).ToString("f2");
        }
        if (TatolAreaMonData(name2, type) + TatolAreaMonData(name3, type) + TatolAreaMonData(name4, type) != 0)
        {
            dr["column13"] = (TatolAreaMonData(name2, type) + TatolAreaMonData(name3, type) + TatolAreaMonData(name4, type)).ToString("f2");
        }
        if (ToDec(dr["column2"]) != 0 && (ToDec(dr["column8"]) - ToDec(dr["column2"])) != 0)
        {
            dr["column14"] = (((ToDec(dr["column8"]) - ToDec(dr["column2"])) / ToDec(dr["column2"])) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr["column5"]) != 0 && (ToDec(dr["column11"]) - ToDec(dr["column5"])) != 0)
        {
            dr["column15"] = (((ToDec(dr["column11"]) - ToDec(dr["column5"])) / ToDec(dr["column5"])) * 100).ToString("f2") + "%";
        }
        if ((ToDec(dr["column8"]) - ToDec(dr["column2"])) != 0)
        {
            dr["column16"] = (ToDec(dr["column8"]) - ToDec(dr["column2"])).ToString("f2");
        }
        if ((ToDec(dr["column11"]) - ToDec(dr["column5"])) != 0)
        {
            dr["column17"] = (ToDec(dr["column11"]) - ToDec(dr["column5"])).ToString("f2");
        }
        dt.Rows.Add(dr);
    }

    private void AddDataRow2(DataTable dt, string name1, string name2, string type, int length)
    {
        DataRow dr = dt.NewRow();
        dr["column1"] = name1;
        if (LThisZeroMonDataL(name2, type, length) + LThisAreaMonDataL(name2, type, length) != 0)
        {
            dr["column2"] = (LThisZeroMonDataL(name2, type, length) + LThisAreaMonDataL(name2, type, length)).ToString("f2");
        }
        if (LThisZeroMonDataL(name2, type, length) != 0)
        {
            dr["column3"] = (LThisZeroMonDataL(name2, type, length)).ToString("f2");
        }
        if (LThisAreaMonDataL(name2, type, length) != 0)
        {
            dr["column4"] = (LThisAreaMonDataL(name2, type, length)).ToString("f2");
        }
        if (LTatolZeroMonDataL(name2, type, length) + LTatolAreaMonDataL(name2, type, length) != 0)
        {
            dr["column5"] = (LTatolZeroMonDataL(name2, type, length) + LTatolAreaMonDataL(name2, type, length)).ToString("f2");
        }
        if (LTatolZeroMonDataL(name2, type, length) != 0)
        {
            dr["column6"] = (LTatolZeroMonDataL(name2, type, length)).ToString("f2");
        }
        if (LTatolAreaMonDataL(name2, type, length) != 0)
        {
            dr["column7"] = (LTatolAreaMonDataL(name2, type, length)).ToString("f2");
        }
        if (ThisZeroMonDataL(name2, type, length) + ThisAreaMonDataL(name2, type, length) != 0)
        {
            dr["column8"] = (ThisZeroMonDataL(name2, type, length) + ThisAreaMonDataL(name2, type, length)).ToString("f2");
        }
        if (ThisZeroMonDataL(name2, type, length) != 0)
        {
            dr["column9"] = (ThisZeroMonDataL(name2, type, length)).ToString("f2");
        }
        if (ThisAreaMonDataL(name2, type, length) != 0)
        {
            dr["column10"] = (ThisAreaMonDataL(name2, type, length)).ToString("f2");
        }
        if (TatolZeroMonDataL(name2, type, length) + TatolAreaMonDataL(name2, type, length) != 0)
        {
            dr["column11"] = (TatolZeroMonDataL(name2, type, length) + TatolAreaMonDataL(name2, type, length)).ToString("f2");
        }
        if (TatolZeroMonDataL(name2, type, length) != 0)
        {
            dr["column12"] = (TatolZeroMonDataL(name2, type, length)).ToString("f2");
        }
        if (TatolAreaMonDataL(name2, type, length) != 0)
        {
            dr["column13"] = (TatolAreaMonDataL(name2, type, length)).ToString("f2");
        }
        if (ToDec(dr["column2"]) != 0 && (ToDec(dr["column8"]) - ToDec(dr["column2"])) != 0)
        {
            dr["column14"] = (((ToDec(dr["column8"]) - ToDec(dr["column2"])) / ToDec(dr["column2"])) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr["column5"]) != 0 && (ToDec(dr["column11"]) - ToDec(dr["column5"])) != 0)
        {
            dr["column15"] = (((ToDec(dr["column11"]) - ToDec(dr["column5"])) / ToDec(dr["column5"])) * 100).ToString("f2") + "%";
        }
        if ((ToDec(dr["column8"]) - ToDec(dr["column2"])) != 0)
        {
            dr["column16"] = (ToDec(dr["column8"]) - ToDec(dr["column2"])).ToString("f2");
        }
        if ((ToDec(dr["column11"]) - ToDec(dr["column5"])) != 0)
        {
            dr["column17"] = (ToDec(dr["column11"]) - ToDec(dr["column5"])).ToString("f2");
        }
        dt.Rows.Add(dr);
    }

    private void AddDataRow3(DataTable dt, string name1, string name2, string name3, string name4, string name5, string type)
    {
        DataRow dr = dt.NewRow();
        dr["column1"] = name1;
        dr["column1"] = name1;
        if (LThisZeroMonData(name2, type) + LThisZeroMonData(name3, type) + LThisZeroMonData(name4, type) + LThisZeroMonData(name5, type) + LThisAreaMonData(name2, type) + LThisAreaMonData(name3, type) + LThisAreaMonData(name4, type) + LThisAreaMonData(name5, type) != 0)
        {
            dr["column2"] = (LThisZeroMonData(name2, type) + LThisZeroMonData(name3, type) + LThisZeroMonData(name4, type) + LThisZeroMonData(name5, type) + LThisAreaMonData(name2, type) + LThisAreaMonData(name3, type) + LThisAreaMonData(name4, type) + LThisAreaMonData(name5, type)).ToString("f2");
        }
        if (LThisZeroMonData(name2, type) + LThisZeroMonData(name3, type) + LThisZeroMonData(name4, type) + LThisZeroMonData(name5, type) != 0)
        {
            dr["column3"] = (LThisZeroMonData(name2, type) + LThisZeroMonData(name3, type) + LThisZeroMonData(name4, type) + LThisZeroMonData(name5, type)).ToString("f2");
        }
        if (LThisAreaMonData(name2, type) + LThisAreaMonData(name3, type) + LThisAreaMonData(name4, type) + LThisAreaMonData(name5, type) != 0)
        {
            dr["column4"] = (LThisAreaMonData(name2, type) + LThisAreaMonData(name3, type) + LThisAreaMonData(name4, type) + LThisAreaMonData(name5, type)).ToString("f2");
        }
        if (LTatolZeroMonData(name2, type) + LTatolZeroMonData(name3, type) + LTatolZeroMonData(name4, type) + LTatolZeroMonData(name5, type) + LTatolAreaMonData(name2, type) + LTatolAreaMonData(name3, type) + LTatolAreaMonData(name4, type) + LTatolZeroMonData(name5, type) != 0)
        {
            dr["column5"] = (LTatolZeroMonData(name2, type) + LTatolZeroMonData(name3, type) + LTatolZeroMonData(name4, type) + LTatolZeroMonData(name5, type) + LTatolAreaMonData(name2, type) + LTatolAreaMonData(name3, type) + LTatolAreaMonData(name4, type) + LTatolZeroMonData(name5, type)).ToString("f2");
        }
        if (LTatolZeroMonData(name2, type) + LTatolZeroMonData(name3, type) + LTatolZeroMonData(name4, type) + LTatolZeroMonData(name5, type) != 0)
        {
            dr["column6"] = (LTatolZeroMonData(name2, type) + LTatolZeroMonData(name3, type) + LTatolZeroMonData(name4, type) + LTatolZeroMonData(name5, type)).ToString("f2");
        }
        if (LTatolAreaMonData(name2, type) + LTatolAreaMonData(name3, type) + LTatolAreaMonData(name4, type) + LTatolZeroMonData(name5, type) != 0)
        {
            dr["column7"] = (LTatolAreaMonData(name2, type) + LTatolAreaMonData(name3, type) + LTatolAreaMonData(name4, type) + LTatolZeroMonData(name5, type)).ToString("f2");
        }
        if (ThisZeroMonData(name2, type) + ThisZeroMonData(name3, type) + ThisZeroMonData(name4, type) + ThisZeroMonData(name5, type) + ThisAreaMonData(name2, type) + ThisAreaMonData(name3, type) + ThisAreaMonData(name4, type) + ThisAreaMonData(name5, type) != 0)
        {
            dr["column8"] = (ThisZeroMonData(name2, type) + ThisZeroMonData(name3, type) + ThisZeroMonData(name4, type) + ThisZeroMonData(name5, type) + ThisAreaMonData(name2, type) + ThisAreaMonData(name3, type) + ThisAreaMonData(name4, type) + ThisAreaMonData(name5, type)).ToString("f2");
        }
        if (ThisZeroMonData(name2, type) + ThisZeroMonData(name3, type) + ThisZeroMonData(name4, type) + ThisZeroMonData(name5, type) != 0)
        {
            dr["column9"] = (ThisZeroMonData(name2, type) + ThisZeroMonData(name3, type) + ThisZeroMonData(name4, type) + ThisZeroMonData(name5, type)).ToString("f2");
        }
        if (ThisAreaMonData(name2, type) + ThisAreaMonData(name3, type) + ThisAreaMonData(name4, type) + ThisAreaMonData(name5, type) != 0)
        {
            dr["column10"] = (ThisAreaMonData(name2, type) + ThisAreaMonData(name3, type) + ThisAreaMonData(name4, type) + ThisAreaMonData(name5, type)).ToString("f2");
        }
        if (TatolZeroMonData(name2, type) + TatolZeroMonData(name3, type) + TatolZeroMonData(name4, type) + TatolZeroMonData(name5, type) + TatolAreaMonData(name2, type) + TatolAreaMonData(name3, type) + TatolAreaMonData(name4, type) + TatolAreaMonData(name5, type) != 0)
        {
            dr["column11"] = (TatolZeroMonData(name2, type) + TatolZeroMonData(name3, type) + TatolZeroMonData(name4, type) + TatolZeroMonData(name5, type) + TatolAreaMonData(name2, type) + TatolAreaMonData(name3, type) + TatolAreaMonData(name4, type) + TatolAreaMonData(name5, type)).ToString("f2");
        }
        if (TatolZeroMonData(name2, type) + TatolZeroMonData(name3, type) + TatolZeroMonData(name4, type) + TatolZeroMonData(name5, type) != 0)
        {
            dr["column12"] = (TatolZeroMonData(name2, type) + TatolZeroMonData(name3, type) + TatolZeroMonData(name4, type) + TatolZeroMonData(name5, type)).ToString("f2");
        }
        if (TatolAreaMonData(name2, type) + TatolAreaMonData(name3, type) + TatolAreaMonData(name4, type) + TatolAreaMonData(name5, type) != 0)
        {
            dr["column13"] = (TatolAreaMonData(name2, type) + TatolAreaMonData(name3, type) + TatolAreaMonData(name4, type) + TatolAreaMonData(name5, type)).ToString("f2");
        }
        if (ToDec(dr["column2"]) != 0 && (ToDec(dr["column8"]) - ToDec(dr["column2"])) != 0)
        {
            dr["column14"] = (((ToDec(dr["column8"]) - ToDec(dr["column2"])) / ToDec(dr["column2"])) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr["column5"]) != 0 && (ToDec(dr["column11"]) - ToDec(dr["column5"])) != 0)
        {
            dr["column15"] = (((ToDec(dr["column11"]) - ToDec(dr["column5"])) / ToDec(dr["column5"])) * 100).ToString("f2") + "%";
        }
        if ((ToDec(dr["column8"]) - ToDec(dr["column2"])) != 0)
        {
            dr["column16"] = (ToDec(dr["column8"]) - ToDec(dr["column2"])).ToString("f2");
        }
        if ((ToDec(dr["column11"]) - ToDec(dr["column5"])) != 0)
        {
            dr["column17"] = (ToDec(dr["column11"]) - ToDec(dr["column5"])).ToString("f2");
        }
        dt.Rows.Add(dr);
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

    private void FunExpendBind()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Columns.Add("column3");
        dt.Columns.Add("column4");
        dt.Columns.Add("column5");
        dt.Columns.Add("column6");
        dt.Columns.Add("column7");
        dt.Columns.Add("column8");
        dt.Columns.Add("column9");
        dt.Columns.Add("column10");
        dt.Columns.Add("column11");
        dt.Columns.Add("column12");
        dt.Columns.Add("column13");
        dt.Columns.Add("column14");
        dt.Columns.Add("column15");
        dt.Columns.Add("column16");
        dt.Columns.Add("column17");
        dt.Columns.Add("column18");

        GetRows(dt);

        RepFunExpend.DataSource = dt;
        RepFunExpend.DataBind();
    }

    private void GetRows(DataTable dt)
    {
        decimal dcZero0 = ThisZeroMonData("基本工资", "基本支出") + ThisZeroMonData("津贴补贴", "基本支出") + ThisZeroMonData("奖励性补贴", "项目支出") + ThisZeroMonData("社会保障缴费", "基本支出") + ThisZeroMonData("伙食补助费", "基本支出") + ThisZeroMonData("其他工资福利支出", "基本支出") + ThisZeroMonData("商品和服务支出", "基本支出") + ThisZeroMonData("对个人和家庭补助支出", "基本支出") + ThisZeroMonData("津贴补贴", "项目支出") + ThisZeroMonData("奖金", "基本支出") + ThisZeroMonData("其他商品和服务支出", "项目支出") + ThisZeroMonData("其他资本性支出", "项目支出");
        decimal dcArea0 = ThisAreaMonData("基本工资", "基本支出") + ThisAreaMonData("津贴补贴", "基本支出") + ThisAreaMonData("奖励性补贴", "项目支出") + ThisAreaMonData("社会保障缴费", "基本支出") + ThisAreaMonData("伙食补助费", "基本支出") + ThisAreaMonData("其他工资福利支出", "基本支出") + ThisAreaMonData("商品和服务支出", "基本支出") + ThisAreaMonData("对个人和家庭补助支出", "基本支出") + ThisAreaMonData("津贴补贴", "项目支出") + ThisAreaMonData("奖金", "基本支出") + ThisAreaMonData("其他商品和服务支出", "项目支出") + ThisAreaMonData("其他资本性支出", "项目支出");
        decimal dcTZero0 = TatolZeroMonData("基本工资", "基本支出") + TatolZeroMonData("津贴补贴", "基本支出") + TatolZeroMonData("奖励性补贴", "项目支出") + TatolZeroMonData("社会保障缴费", "基本支出") + TatolZeroMonData("伙食补助费", "基本支出") + TatolZeroMonData("其他工资福利支出", "基本支出") + TatolZeroMonData("商品和服务支出", "基本支出") + TatolZeroMonData("对个人和家庭补助支出", "基本支出") + TatolZeroMonData("津贴补贴", "项目支出") + TatolZeroMonData("奖金", "基本支出") + TatolZeroMonData("其他商品和服务支出", "项目支出") + TatolZeroMonData("其他资本性支出", "项目支出");
        decimal dcTArea0 = TatolAreaMonData("基本工资", "基本支出") + TatolAreaMonData("津贴补贴", "基本支出") + TatolAreaMonData("奖励性补贴", "项目支出") + TatolAreaMonData("社会保障缴费", "基本支出") + TatolAreaMonData("伙食补助费", "基本支出") + TatolAreaMonData("其他工资福利支出", "基本支出") + TatolAreaMonData("商品和服务支出", "基本支出") + TatolAreaMonData("对个人和家庭补助支出", "基本支出") + TatolAreaMonData("津贴补贴", "项目支出") + TatolAreaMonData("奖金", "基本支出") + TatolAreaMonData("其他商品和服务支出", "项目支出") + TatolAreaMonData("其他资本性支出", "项目支出");
        decimal dcLZero0 = LThisZeroMonData("基本工资", "基本支出") + LThisZeroMonData("津贴补贴", "基本支出") + LThisZeroMonData("奖励性补贴", "项目支出") + LThisZeroMonData("社会保障缴费", "基本支出") + LThisZeroMonData("伙食补助费", "基本支出") + LThisZeroMonData("其他工资福利支出", "基本支出") + LThisZeroMonData("商品和服务支出", "基本支出") + LThisZeroMonData("对个人和家庭补助支出", "基本支出") + LThisZeroMonData("津贴补贴", "项目支出") + LThisZeroMonData("奖金", "基本支出") + LThisZeroMonData("其他商品和服务支出", "项目支出") + LThisZeroMonData("其他资本性支出", "项目支出");
        decimal dcLArea0 = LThisAreaMonData("基本工资", "基本支出") + LThisAreaMonData("津贴补贴", "基本支出") + LThisAreaMonData("奖励性补贴", "项目支出") + LThisAreaMonData("社会保障缴费", "基本支出") + LThisAreaMonData("伙食补助费", "基本支出") + LThisAreaMonData("其他工资福利支出", "基本支出") + LThisAreaMonData("商品和服务支出", "基本支出") + LThisAreaMonData("对个人和家庭补助支出", "基本支出") + LThisAreaMonData("津贴补贴", "项目支出") + LThisAreaMonData("奖金", "基本支出") + LThisAreaMonData("其他商品和服务支出", "项目支出") + LThisAreaMonData("其他资本性支出", "项目支出");
        decimal dcLTZero0 = LTatolZeroMonData("基本工资", "基本支出") + LTatolZeroMonData("津贴补贴", "基本支出") + LTatolZeroMonData("奖励性补贴", "项目支出") + LTatolZeroMonData("社会保障缴费", "基本支出") + LTatolZeroMonData("伙食补助费", "基本支出") + LTatolZeroMonData("其他工资福利支出", "基本支出") + LTatolZeroMonData("商品和服务支出", "基本支出") + LTatolZeroMonData("对个人和家庭补助支出", "基本支出") + LTatolZeroMonData("津贴补贴", "项目支出") + LTatolZeroMonData("奖金", "基本支出") + LTatolZeroMonData("其他商品和服务支出", "项目支出") + LTatolZeroMonData("其他资本性支出", "项目支出");
        decimal dcLTArea0 = LTatolAreaMonData("基本工资", "基本支出") + LTatolAreaMonData("津贴补贴", "基本支出") + LTatolAreaMonData("奖励性补贴", "项目支出") + LTatolAreaMonData("社会保障缴费", "基本支出") + LTatolAreaMonData("伙食补助费", "基本支出") + LTatolAreaMonData("其他工资福利支出", "基本支出") + LTatolAreaMonData("商品和服务支出", "基本支出") + LTatolAreaMonData("对个人和家庭补助支出", "基本支出") + LTatolAreaMonData("津贴补贴", "项目支出") + LTatolAreaMonData("奖金", "基本支出") + LTatolAreaMonData("其他商品和服务支出", "项目支出") + LTatolAreaMonData("其他资本性支出", "项目支出");

        decimal dcZero1 = ThisZeroMonData("基本工资", "基本支出") + ThisZeroMonData("津贴补贴", "基本支出") + ThisZeroMonData("奖励性补贴", "项目支出") + ThisZeroMonData("社会保障缴费", "基本支出") + ThisZeroMonData("伙食补助费", "基本支出") + ThisZeroMonData("其他工资福利支出", "基本支出") + ThisZeroMonData("商品和服务支出", "基本支出") + ThisZeroMonData("对个人和家庭补助支出", "基本支出");
        decimal dcArea1 = ThisAreaMonData("基本工资", "基本支出") + ThisAreaMonData("津贴补贴", "基本支出") + ThisAreaMonData("奖励性补贴", "项目支出") + ThisAreaMonData("社会保障缴费", "基本支出") + ThisAreaMonData("伙食补助费", "基本支出") + ThisAreaMonData("其他工资福利支出", "基本支出") + ThisAreaMonData("商品和服务支出", "基本支出") + ThisAreaMonData("对个人和家庭补助支出", "基本支出");
        decimal dcTZero1 = TatolZeroMonData("基本工资", "基本支出") + TatolZeroMonData("津贴补贴", "基本支出") + TatolZeroMonData("奖励性补贴", "项目支出") + TatolZeroMonData("社会保障缴费", "基本支出") + TatolZeroMonData("伙食补助费", "基本支出") + TatolZeroMonData("其他工资福利支出", "基本支出") + TatolZeroMonData("商品和服务支出", "基本支出") + TatolZeroMonData("对个人和家庭补助支出", "基本支出");
        decimal dcTArea1 = TatolAreaMonData("基本工资", "基本支出") + TatolAreaMonData("津贴补贴", "基本支出") + TatolAreaMonData("奖励性补贴", "项目支出") + TatolAreaMonData("社会保障缴费", "基本支出") + TatolAreaMonData("伙食补助费", "基本支出") + TatolAreaMonData("其他工资福利支出", "基本支出") + TatolAreaMonData("商品和服务支出", "基本支出") + TatolAreaMonData("对个人和家庭补助支出", "基本支出");
        decimal dcLZero1 = LThisZeroMonData("基本工资", "基本支出") + LThisZeroMonData("津贴补贴", "基本支出") + LThisZeroMonData("奖励性补贴", "项目支出") + LThisZeroMonData("社会保障缴费", "基本支出") + LThisZeroMonData("伙食补助费", "基本支出") + LThisZeroMonData("其他工资福利支出", "基本支出") + LThisZeroMonData("商品和服务支出", "基本支出") + LThisZeroMonData("对个人和家庭补助支出", "基本支出");
        decimal dcLArea1 = LThisAreaMonData("基本工资", "基本支出") + LThisAreaMonData("津贴补贴", "基本支出") + LThisAreaMonData("奖励性补贴", "项目支出") + LThisAreaMonData("社会保障缴费", "基本支出") + LThisAreaMonData("伙食补助费", "基本支出") + LThisAreaMonData("其他工资福利支出", "基本支出") + LThisAreaMonData("商品和服务支出", "基本支出") + LThisAreaMonData("对个人和家庭补助支出", "基本支出");
        decimal dcLTZero1 = LTatolZeroMonData("基本工资", "基本支出") + LTatolZeroMonData("津贴补贴", "基本支出") + LTatolZeroMonData("奖励性补贴", "项目支出") + LTatolZeroMonData("社会保障缴费", "基本支出") + LTatolZeroMonData("伙食补助费", "基本支出") + LTatolZeroMonData("其他工资福利支出", "基本支出") + LTatolZeroMonData("商品和服务支出", "基本支出") + LTatolZeroMonData("对个人和家庭补助支出", "基本支出");
        decimal dcLTArea1 = LTatolAreaMonData("基本工资", "基本支出") + LTatolAreaMonData("津贴补贴", "基本支出") + LTatolAreaMonData("奖励性补贴", "项目支出") + LTatolAreaMonData("社会保障缴费", "基本支出") + LTatolAreaMonData("伙食补助费", "基本支出") + LTatolAreaMonData("其他工资福利支出", "基本支出") + LTatolAreaMonData("商品和服务支出", "基本支出") + LTatolAreaMonData("对个人和家庭补助支出", "基本支出");

        decimal dcZero2 = ThisZeroMonData("津贴补贴", "项目支出") + ThisZeroMonData("奖金", "基本支出") + ThisZeroMonData("其他商品和服务支出", "项目支出") + ThisZeroMonData("其他资本性支出", "项目支出");
        decimal dcArea2 = ThisAreaMonData("津贴补贴", "项目支出") + ThisAreaMonData("奖金", "基本支出") + ThisAreaMonData("其他商品和服务支出", "项目支出") + ThisAreaMonData("其他资本性支出", "项目支出");
        decimal dcTZero2 = TatolZeroMonData("津贴补贴", "项目支出") + TatolZeroMonData("奖金", "基本支出") + TatolZeroMonData("其他商品和服务支出", "项目支出") + TatolZeroMonData("其他资本性支出", "项目支出");
        decimal dcTArea2 = TatolAreaMonData("津贴补贴", "项目支出") + TatolAreaMonData("奖金", "基本支出") + TatolAreaMonData("其他商品和服务支出", "项目支出") + TatolAreaMonData("其他资本性支出", "项目支出");
        decimal dcLZero2 = LThisZeroMonData("津贴补贴", "项目支出") + LThisZeroMonData("奖金", "基本支出") + LThisZeroMonData("其他商品和服务支出", "项目支出") + LThisZeroMonData("其他资本性支出", "项目支出");
        decimal dcLArea2 = LThisAreaMonData("津贴补贴", "项目支出") + LThisAreaMonData("奖金", "基本支出") + LThisAreaMonData("其他商品和服务支出", "项目支出") + LThisAreaMonData("其他资本性支出", "项目支出");
        decimal dcLTZero2 = LTatolZeroMonData("津贴补贴", "项目支出") + LTatolZeroMonData("奖金", "基本支出") + LTatolZeroMonData("其他商品和服务支出", "项目支出") + LTatolZeroMonData("其他资本性支出", "项目支出");
        decimal dcLTArea2 = LTatolAreaMonData("津贴补贴", "项目支出") + LTatolAreaMonData("奖金", "基本支出") + LTatolAreaMonData("其他商品和服务支出", "项目支出") + LTatolAreaMonData("其他资本性支出", "项目支出");

        decimal dcZero3 = ThisZeroMonData("基本工资", "基本支出") + ThisZeroMonData("津贴补贴", "基本支出") + ThisZeroMonData("奖励性补贴", "项目支出") + ThisZeroMonData("社会保障缴费", "基本支出") + ThisZeroMonData("伙食补助费", "基本支出") + ThisZeroMonData("其他工资福利支出", "基本支出");
        decimal dcArea3 = ThisAreaMonData("基本工资", "基本支出") + ThisAreaMonData("津贴补贴", "基本支出") + ThisAreaMonData("奖励性补贴", "项目支出") + ThisAreaMonData("社会保障缴费", "基本支出") + ThisAreaMonData("伙食补助费", "基本支出") + ThisAreaMonData("其他工资福利支出", "基本支出");
        decimal dcTZero3 = TatolZeroMonData("基本工资", "基本支出") + TatolZeroMonData("津贴补贴", "基本支出") + TatolZeroMonData("奖励性补贴", "项目支出") + TatolZeroMonData("社会保障缴费", "基本支出") + TatolZeroMonData("伙食补助费", "基本支出") + TatolZeroMonData("其他工资福利支出", "基本支出");
        decimal dcTArea3 = TatolAreaMonData("基本工资", "基本支出") + TatolAreaMonData("津贴补贴", "基本支出") + TatolAreaMonData("奖励性补贴", "项目支出") + TatolAreaMonData("社会保障缴费", "基本支出") + TatolAreaMonData("伙食补助费", "基本支出") + TatolAreaMonData("其他工资福利支出", "基本支出");
        decimal dcLZero3 = LThisZeroMonData("基本工资", "基本支出") + LThisZeroMonData("津贴补贴", "基本支出") + LThisZeroMonData("奖励性补贴", "项目支出") + LThisZeroMonData("社会保障缴费", "基本支出") + LThisZeroMonData("伙食补助费", "基本支出") + LThisZeroMonData("其他工资福利支出", "基本支出");
        decimal dcLArea3 = LThisAreaMonData("基本工资", "基本支出") + LThisAreaMonData("津贴补贴", "基本支出") + LThisAreaMonData("奖励性补贴", "项目支出") + LThisAreaMonData("社会保障缴费", "基本支出") + LThisAreaMonData("伙食补助费", "基本支出") + LThisAreaMonData("其他工资福利支出", "基本支出");
        decimal dcLTZero3 = LTatolZeroMonData("基本工资", "基本支出") + LTatolZeroMonData("津贴补贴", "基本支出") + LTatolZeroMonData("奖励性补贴", "项目支出") + LTatolZeroMonData("社会保障缴费", "基本支出") + LTatolZeroMonData("伙食补助费", "基本支出") + LTatolZeroMonData("其他工资福利支出", "基本支出");
        decimal dcLTArea3 = LTatolAreaMonData("基本工资", "基本支出") + LTatolAreaMonData("津贴补贴", "基本支出") + LTatolAreaMonData("奖励性补贴", "项目支出") + LTatolAreaMonData("社会保障缴费", "基本支出") + LTatolAreaMonData("伙食补助费", "基本支出") + LTatolAreaMonData("其他工资福利支出", "基本支出");

        decimal dcZero4 = ThisZeroMonData("津贴补贴", "项目支出") + ThisZeroMonData("奖金", "基本支出");
        decimal dcArea4 = ThisAreaMonData("津贴补贴", "项目支出") + ThisAreaMonData("奖金", "基本支出");
        decimal dcTZero4 = TatolZeroMonData("津贴补贴", "项目支出") + TatolZeroMonData("奖金", "基本支出");
        decimal dcTArea4 = TatolAreaMonData("津贴补贴", "项目支出") + TatolAreaMonData("奖金", "基本支出");
        decimal dcLZero4 = LThisZeroMonData("津贴补贴", "项目支出") + LThisZeroMonData("奖金", "基本支出");
        decimal dcLArea4 = LThisAreaMonData("津贴补贴", "项目支出") + LThisAreaMonData("奖金", "基本支出");
        decimal dcLTZero4 = LTatolZeroMonData("津贴补贴", "项目支出") + LTatolZeroMonData("奖金", "基本支出");
        decimal dcLTArea4 = LTatolAreaMonData("津贴补贴", "项目支出") + LTatolAreaMonData("奖金", "基本支出");

        DataRow dr0 = dt.NewRow();
        dr0["column1"] = "总        计";
        if (dcLZero0 + dcLArea0 != 0)
        {
            dr0["column2"] = (dcLZero0 + dcLArea0).ToString("f2");
        }
        if (dcLZero0 != 0)
        {
            dr0["column3"] = (dcLZero0).ToString("f2");
        }
        if (dcLArea0 != 0)
        {
            dr0["column4"] = (dcLArea0).ToString("f2");
        }
        if (dcLTZero0 + dcLTArea0 != 0)
        {
            dr0["column5"] = (dcLTZero0 + dcLTArea0).ToString("f2");
        }
        if (dcLTZero0 != 0)
        {
            dr0["column6"] = (dcLTZero0).ToString("f2");
        }
        if (dcLTArea0 != 0)
        {
            dr0["column7"] = (dcLTArea0).ToString("f2");
        }
        if (dcZero0 + dcArea0 != 0)
        {
            dr0["column8"] = (dcZero0 + dcArea0).ToString("f2");
        }
        if (dcZero0 != 0)
        {
            dr0["column9"] = (dcZero0).ToString("f2");
        }
        if (dcArea0 != 0)
        {
            dr0["column10"] = (dcArea0).ToString("f2");
        }
        if (dcTZero0 + dcTArea0 != 0)
        {
            dr0["column11"] = (dcTZero0 + dcTArea0).ToString("f2");
        }
        if (dcTZero0 != 0)
        {
            dr0["column12"] = (dcTZero0).ToString("f2");
        }
        if (dcTArea0 != 0)
        {
            dr0["column13"] = (dcTArea0).ToString("f2");
        }
        if (ToDec(dr0["column2"]) != 0 && (ToDec(dr0["column8"]) - ToDec(dr0["column2"])) != 0)
        {
            dr0["column14"] = (((ToDec(dr0["column8"]) - ToDec(dr0["column2"])) / ToDec(dr0["column2"])) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr0["column5"]) != 0 && (ToDec(dr0["column11"]) - ToDec(dr0["column5"])) != 0)
        {
            dr0["column15"] = (((ToDec(dr0["column11"]) - ToDec(dr0["column5"])) / ToDec(dr0["column5"])) * 100).ToString("f2") + "%";
        }
        if ((ToDec(dr0["column8"]) - ToDec(dr0["column2"])) != 0)
        {
            dr0["column16"] = (ToDec(dr0["column8"]) - ToDec(dr0["column2"])).ToString("f2");
        }
        if ((ToDec(dr0["column11"]) - ToDec(dr0["column5"])) != 0)
        {
            dr0["column17"] = (ToDec(dr0["column11"]) - ToDec(dr0["column5"])).ToString("f2");
        }
        dt.Rows.Add(dr0);

        DataRow dr1 = dt.NewRow();
        dr1["column1"] = "一、基本支出";
        if (dcLZero1 + dcLArea1 != 0)
        {
            dr1["column2"] = (dcLZero1 + dcLArea1).ToString("f2");
        }
        if (dcLZero1 != 0)
        {
            dr1["column3"] = (dcLZero1).ToString("f2");
        }
        if (dcLArea1 != 0)
        {
            dr1["column4"] = (dcLArea1).ToString("f2");
        }
        if (dcLTZero1 + dcLTArea1 != 0)
        {
            dr1["column5"] = (dcLTZero1 + dcLTArea1).ToString("f2");
        }
        if (dcLTZero1 != 0)
        {
            dr1["column6"] = (dcLTZero1).ToString("f2");
        }
        if (dcLTArea1 != 0)
        {
            dr1["column7"] = (dcLTArea1).ToString("f2");
        }
        if (dcZero1 + dcArea1 != 0)
        {
            dr1["column8"] = (dcZero1 + dcArea1).ToString("f2");
        }
        if (dcZero1 != 0)
        {
            dr1["column9"] = (dcZero1).ToString("f2");
        }
        if (dcArea1 != 0)
        {
            dr1["column10"] = (dcArea1).ToString("f2");
        }
        if (dcTZero1 + dcTArea1 != 0)
        {
            dr1["column11"] = (dcTZero1 + dcTArea1).ToString("f2");
        }
        if (dcTZero1 != 0)
        {
            dr1["column12"] = (dcTZero1).ToString("f2");
        }
        if (dcTArea1 != 0)
        {
            dr1["column13"] = (dcTArea1).ToString("f2");
        }
        if (ToDec(dr1["column2"]) != 0 && (ToDec(dr1["column8"]) - ToDec(dr1["column2"])) != 0)
        {
            dr1["column14"] = (((ToDec(dr1["column8"]) - ToDec(dr1["column2"])) / ToDec(dr1["column2"])) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr1["column5"]) != 0 && (ToDec(dr1["column11"]) - ToDec(dr1["column5"])) != 0)
        {
            dr1["column15"] = (((ToDec(dr1["column11"]) - ToDec(dr1["column5"])) / ToDec(dr1["column5"])) * 100).ToString("f2") + "%";
        }
        if ((ToDec(dr1["column8"]) - ToDec(dr1["column2"])) != 0)
        {
            dr1["column16"] = (ToDec(dr1["column8"]) - ToDec(dr1["column2"])).ToString("f2");
        }
        if ((ToDec(dr1["column11"]) - ToDec(dr1["column5"])) != 0)
        {
            dr1["column17"] = (ToDec(dr1["column11"]) - ToDec(dr1["column5"])).ToString("f2");
        }
        dt.Rows.Add(dr1);

        DataRow dr2 = dt.NewRow();
        dr2["column1"] = "（一）工资福利支出";
        if ((dcLZero3 + dcLArea3) != 0)
        {
            dr2["column2"] = (dcLZero3 + dcLArea3).ToString("f2");
        }
        if (dcLZero3 != 0)
        {
            dr2["column3"] = (dcLZero3).ToString("f2");
        }
        if (dcLArea3 != 0)
        {
            dr2["column4"] = (dcLArea3).ToString("f2");
        }
        if ((dcLTZero3 + dcLTArea3) != 0)
        {
            dr2["column5"] = (dcLTZero3 + dcLTArea3).ToString("f2");
        }
        if (dcLTZero3 != 0)
        {
            dr2["column6"] = (dcLTZero3).ToString("f2");
        }
        if (dcLTArea3 != 0)
        {
            dr2["column7"] = (dcLTArea3).ToString("f2");
        }
        if ((dcZero3 + dcArea3) != 0)
        {
            dr2["column8"] = (dcZero3 + dcArea3).ToString("f2");
        }
        if (dcZero3 != 0)
        {
            dr2["column9"] = (dcZero3).ToString("f2");
        }
        if (dcArea3 != 0)
        {
            dr2["column10"] = (dcArea3).ToString("f2");
        }
        if ((dcTZero3 + dcTArea3) != 0)
        {
            dr2["column11"] = (dcTZero3 + dcTArea3).ToString("f2");
        }
        if (dcTZero3 != 0)
        {
            dr2["column12"] = (dcTZero3).ToString("f2");
        }
        if (dcTArea3 != 0)
        {
            dr2["column13"] = (dcTArea3).ToString("f2");
        }
        if (ToDec(dr2["column2"]) != 0 && (ToDec(dr2["column8"]) - ToDec(dr2["column2"])) != 0)
        {
            dr2["column14"] = (((ToDec(dr2["column8"]) - ToDec(dr2["column2"])) / ToDec(dr2["column2"])) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr2["column5"]) != 0 && (ToDec(dr2["column11"]) - ToDec(dr2["column5"])) != 0)
        {
            dr2["column15"] = (((ToDec(dr2["column11"]) - ToDec(dr2["column5"])) / ToDec(dr2["column5"])) * 100).ToString("f2") + "%";
        }
        if ((ToDec(dr2["column8"]) - ToDec(dr2["column2"])) != 0)
        {
            dr2["column16"] = (ToDec(dr2["column8"]) - ToDec(dr2["column2"])).ToString("f2");
        }
        if ((ToDec(dr2["column11"]) - ToDec(dr2["column5"])) != 0)
        {
            dr2["column17"] = (ToDec(dr2["column11"]) - ToDec(dr2["column5"])).ToString("f2");
        }
        dt.Rows.Add(dr2);

        //AddDataRow(dt, "　（一）工资福利支出", "工资福利支出", "基本支出");
        AddDataRow(dt, "　　　1、基本工资", "基本工资", "基本支出");
        AddDataRow(dt, "　　　2、津贴补贴", "津贴补贴", "基本支出");
        AddDataRow(dt, "　　　3、奖金", "奖励性补贴", "项目支出");
        AddDataRow(dt, "　　　4、社会保障缴费", "社会保障缴费", "基本支出");
        AddDataRow(dt, "　　　5、伙食补助费", "伙食补助费", "基本支出");
        AddDataRow(dt, "　　　6、其他工资福利支出", "其他工资福利支出", "基本支出");

        //DataRow dr3 = dt.NewRow();
        //dr3["column1"] = "（二）商品和服务支出";
        //if ((dcLZero2 + dcLArea2) != 0)
        //{
        //    dr3["column2"] = (dcLZero2 + dcLArea2).ToString("f2");
        //}
        //if (dcLZero2 != 0)
        //{
        //    dr3["column3"] = (dcLZero2).ToString("f2");
        //}
        //if (dcLArea2 != 0)
        //{
        //    dr3["column4"] = (dcLArea2).ToString("f2");
        //}
        //if ((dcLTZero2 + dcLTArea2) != 0)
        //{
        //    dr3["column5"] = (dcLTZero2 + dcLTArea2).ToString("f2");
        //}
        //if (dcLTZero2 != 0)
        //{
        //    dr3["column6"] = (dcLTZero2).ToString("f2");
        //}
        //if (dcLTArea2 != 0)
        //{
        //    dr3["column7"] = (dcLTArea2).ToString("f2");
        //}
        //if ((dcZero2 + dcArea2) != 0)
        //{
        //    dr3["column8"] = (dcZero2 + dcArea2).ToString("f2");
        //}
        //if (dcZero2 != 0)
        //{
        //    dr3["column9"] = (dcZero2).ToString("f2");
        //}
        //if (dcArea2 != 0)
        //{
        //    dr3["column10"] = (dcArea2).ToString("f2");
        //}
        //if ((dcTZero2 + dcTArea2) != 0)
        //{
        //    dr3["column11"] = (dcTZero2 + dcTArea2).ToString("f2");
        //}
        //if (dcTZero2 != 0)
        //{
        //    dr3["column12"] = (dcTZero2).ToString("f2");
        //}
        //if (dcTArea2 != 0)
        //{
        //    dr3["column13"] = (dcTArea2).ToString("f2");
        //}
        //if (ToDec(dr3["column2"]) != 0 && (ToDec(dr3["column8"]) - ToDec(dr3["column2"])) != 0)
        //{
        //    dr3["column14"] = (((ToDec(dr3["column8"]) - ToDec(dr3["column2"])) / ToDec(dr3["column2"])) * 100).ToString("f2") + "%";
        //}
        //if (ToDec(dr3["column5"]) != 0 && (ToDec(dr3["column11"]) - ToDec(dr3["column5"])) != 0)
        //{
        //    dr3["column15"] = (((ToDec(dr3["column11"]) - ToDec(dr3["column5"])) / ToDec(dr3["column5"])) * 100).ToString("f2") + "%";
        //}
        //if ((ToDec(dr3["column8"]) - ToDec(dr3["column2"])) != 0)
        //{
        //    dr3["column16"] = (ToDec(dr3["column8"]) - ToDec(dr3["column2"])).ToString("f2");
        //}
        //if ((ToDec(dr3["column11"]) - ToDec(dr3["column5"])) != 0)
        //{
        //    dr3["column17"] = (ToDec(dr3["column11"]) - ToDec(dr3["column5"])).ToString("f2");
        //}
        //dt.Rows.Add(dr3);
        AddDataRow(dt, "　（二）商品和服务支出", "商品和服务支出", "基本支出");
        AddDataRow(dt, "　　　1、办公费", "办公费", "基本支出");
        AddDataRow(dt, "　　　2、印刷费", "印刷费", "基本支出");
        AddDataRow(dt, "　　　3、咨询费", "咨询费", "基本支出");
        AddDataRow(dt, "　　　4、手续费", "手续费", "基本支出");
        AddDataRow(dt, "　　　5、水费", "水费", "基本支出");
        AddDataRow(dt, "　　　6、电费", "电费", "基本支出");
        AddDataRow(dt, "　　　7、邮电费", "邮电费", "基本支出");
        AddDataRow(dt, "　　　8、取暖费", "取暖费", "基本支出");
        AddDataRow(dt, "　　　9、物业管理费", "物业管理费", "基本支出");
        AddDataRow(dt, "　　　10、差旅费", "差旅费", "基本支出");
        AddDataRow(dt, "　　　11、因公出国（境）费用", "因公出国（境）费用", "基本支出");
        AddDataRow(dt, "　　　12、维修（护）费", "维修（护）费", "基本支出");
        AddDataRow(dt, "　　　13、租赁费", "租赁费", "基本支出");
        AddDataRow(dt, "　　　14、会议费", "会议费", "基本支出");
        AddDataRow(dt, "　　　15、培训费", "培训费", "基本支出");
        AddDataRow(dt, "　　　16、公务接待费", "公务接待费", "基本支出");
        AddDataRow(dt, "　　　17、被装购置费", "被装购置费", "基本支出");
        AddDataRow(dt, "　　　18、劳务费", "劳务费", "基本支出");
        AddDataRow(dt, "　　　19、委托业务费", "委托业务费", "基本支出");
        AddDataRow(dt, "　　　20、工会经费", "工会经费", "基本支出");
        AddDataRow(dt, "　　　21、福利费", "福利费", "基本支出");
        AddDataRow(dt, "　　　22、公务用车运行维护费", "公务用车运行维护费", "基本支出");
        AddDataRow(dt, "　　　23、其他交通费用", "其他交通费用", "基本支出");
        AddDataRow(dt, "　　　24、其他商品和服务支出", "其他商品和服务支出", "基本支出");

        //DataRow dr4 = dt.NewRow();
        //dr4["column1"] = "（三）对个人和家庭补助支出";
        //if ((dcLZero3 + dcLArea3) != 0)
        //{
        //    dr4["column2"] = (dcLZero3 + dcLArea3).ToString("f2");
        //}
        //if (dcLZero3 != 0)
        //{
        //    dr4["column3"] = (dcLZero3).ToString("f2");
        //}
        //if (dcLArea3 != 0)
        //{
        //    dr4["column4"] = (dcLArea3).ToString("f2");
        //}
        //if ((dcLTZero3 + dcLTArea3) != 0)
        //{
        //    dr4["column5"] = (dcLTZero3 + dcLTArea3).ToString("f2");
        //}
        //if (dcLTZero3 != 0)
        //{
        //    dr4["column6"] = (dcLTZero3).ToString("f2");
        //}
        //if (dcLTArea3 != 0)
        //{
        //    dr4["column7"] = (dcLTArea3).ToString("f2");
        //}
        //if ((dcZero3 + dcArea3) != 0)
        //{
        //    dr4["column8"] = (dcZero3 + dcArea3).ToString("f2");
        //}
        //if (dcZero3 != 0)
        //{
        //    dr4["column9"] = (dcZero3).ToString("f2");
        //}
        //if (dcArea3 != 0)
        //{
        //    dr4["column10"] = (dcArea3).ToString("f2");
        //}
        //if ((dcTZero3 + dcTArea3) != 0)
        //{
        //    dr4["column11"] = (dcTZero3 + dcTArea3).ToString("f2");
        //}
        //if (dcTZero3 != 0)
        //{
        //    dr4["column12"] = (dcTZero3).ToString("f2");
        //}
        //if (dcTArea3 != 0)
        //{
        //    dr4["column13"] = (dcTArea3).ToString("f2");
        //}
        //if (ToDec(dr4["column2"]) != 0 && (ToDec(dr4["column8"]) - ToDec(dr4["column2"])) != 0)
        //{
        //    dr4["column14"] = (((ToDec(dr4["column8"]) - ToDec(dr4["column2"])) / ToDec(dr4["column2"])) * 100).ToString("f2") + "%";
        //}
        //if (ToDec(dr4["column5"]) != 0 && (ToDec(dr4["column11"]) - ToDec(dr4["column5"])) != 0)
        //{
        //    dr4["column15"] = (((ToDec(dr4["column11"]) - ToDec(dr4["column5"])) / ToDec(dr4["column5"])) * 100).ToString("f2") + "%";
        //}
        //if ((ToDec(dr4["column8"]) - ToDec(dr4["column2"])) != 0)
        //{
        //    dr4["column16"] = (ToDec(dr4["column8"]) - ToDec(dr4["column2"])).ToString("f2");
        //}
        //if ((ToDec(dr4["column11"]) - ToDec(dr4["column5"])) != 0)
        //{
        //    dr4["column17"] = (ToDec(dr4["column11"]) - ToDec(dr4["column5"])).ToString("f2");
        //}
        //dt.Rows.Add(dr4);
        AddDataRow(dt, "　（三）对个人和家庭补助支出", "对个人和家庭补助支出", "基本支出");
        AddDataRow1(dt, "　　　1、离退休费", "离休费", "退休费", "退职(役)费", "基本支出");
        AddDataRow(dt, "　　　2、抚恤金", "抚恤金", "基本支出");
        AddDataRow(dt, "　　　3、生活补助", "生活补助", "基本支出");
        AddDataRow(dt, "　　　4、医疗费", "医疗费", "基本支出");
        AddDataRow(dt, "　　　5、住房公积金", "住房公积金", "基本支出");
        AddDataRow(dt, "　　　6、提租补贴", "提租补贴", "基本支出");
        AddDataRow(dt, "　　　7、住房补贴", "住房补贴", "基本支出");
        AddDataRow3(dt, "　　　8、其他对个人和家庭补助支出", "其他对个人和家庭补助支出", "救济费", "助学金", "奖励金", "基本支出");

        DataRow dr5 = dt.NewRow();
        dr5["column1"] = "二、项目支出";
        if (dcLZero2 + dcLArea2 != 0)
        {
            dr5["column2"] = (dcLZero2 + dcLArea2).ToString("f2");
        }
        if (dcLZero2 != 0)
        {
            dr5["column3"] = (dcLZero2).ToString("f2");
        }
        if (dcLArea2 != 0)
        {
            dr5["column4"] = (dcLArea2).ToString("f2");
        }
        if (dcLTZero2 + dcLTArea2 != 0)
        {
            dr5["column5"] = (dcLTZero2 + dcLTArea2).ToString("f2");
        }
        if (dcLTZero2 != 0)
        {
            dr5["column6"] = (dcLTZero2).ToString("f2");
        }
        if (dcLTArea2 != 0)
        {
            dr5["column7"] = (dcLTArea2).ToString("f2");
        }
        if (dcZero2 + dcArea2 != 0)
        {
            dr5["column8"] = (dcZero2 + dcArea2).ToString("f2");
        }
        if (dcZero2 != 0)
        {
            dr5["column9"] = (dcZero2).ToString("f2");
        }
        if (dcArea2 != 0)
        {
            dr5["column10"] = (dcArea2).ToString("f2");
        }
        if (dcTZero2 + dcTArea2 != 0)
        {
            dr5["column11"] = (dcTZero2 + dcTArea2).ToString("f2");
        }
        if (dcTZero2 != 0)
        {
            dr5["column12"] = (dcTZero2).ToString("f2");
        }
        if (dcTArea2 != 0)
        {
            dr5["column13"] = (dcTArea2).ToString("f2");
        }
        if (ToDec(dr5["column2"]) != 0 && (ToDec(dr5["column8"]) - ToDec(dr5["column2"])) != 0)
        {
            dr5["column14"] = (((ToDec(dr5["column8"]) - ToDec(dr5["column2"])) / ToDec(dr5["column2"])) * 100).ToString("f2") + "%";
        }
        if (ToDec(dr5["column5"]) != 0 && (ToDec(dr5["column11"]) - ToDec(dr5["column5"])) != 0)
        {
            dr5["column15"] = (((ToDec(dr5["column11"]) - ToDec(dr5["column5"])) / ToDec(dr5["column5"])) * 100).ToString("f2") + "%";
        }
        if ((ToDec(dr5["column8"]) - ToDec(dr5["column2"])) != 0)
        {
            dr5["column16"] = (ToDec(dr5["column8"]) - ToDec(dr5["column2"])).ToString("f2");
        }
        if ((ToDec(dr5["column11"]) - ToDec(dr5["column5"])) != 0)
        {
            dr5["column17"] = (ToDec(dr5["column11"]) - ToDec(dr5["column5"])).ToString("f2");
        }
        dt.Rows.Add(dr5);

        //DataRow dr6 = dt.NewRow();
        //dr6["column1"] = "（一）工资福利支出";
        //if ((dcLZero4 + dcLArea4) != 0)
        //{
        //    dr6["column2"] = (dcLZero4 + dcLArea4).ToString("f2");
        //}
        //if (dcLZero4 != 0)
        //{
        //    dr6["column3"] = (dcLZero4).ToString("f2");
        //}
        //if (dcLArea4 != 0)
        //{
        //    dr6["column4"] = (dcLArea4).ToString("f2");
        //}
        //if ((dcLTZero4 + dcLTArea4) != 0)
        //{
        //    dr6["column5"] = (dcLTZero4 + dcLTArea4).ToString("f2");
        //}
        //if (dcLTZero4 != 0)
        //{
        //    dr6["column6"] = (dcLTZero4).ToString("f2");
        //}
        //if (dcLTArea4 != 0)
        //{
        //    dr6["column7"] = (dcLTArea4).ToString("f2");
        //}
        //if ((dcZero4 + dcArea4) != 0)
        //{
        //    dr6["column8"] = (dcZero4 + dcArea4).ToString("f2");
        //}
        //if (dcZero4 != 0)
        //{
        //    dr6["column9"] = (dcZero4).ToString("f2");
        //}
        //if (dcArea4 != 0)
        //{
        //    dr6["column10"] = (dcArea4).ToString("f2");
        //}
        //if ((dcTZero4 + dcTArea4) != 0)
        //{
        //    dr6["column11"] = (dcTZero4 + dcTArea4).ToString("f2");
        //}
        //if (dcTZero4 != 0)
        //{
        //    dr6["column12"] = (dcTZero4).ToString("f2");
        //}
        //if (dcTArea4 != 0)
        //{
        //    dr6["column13"] = (dcTArea4).ToString("f2");
        //}        
        //if (ToDec(dr6["column2"]) != 0 && (ToDec(dr6["column8"]) - ToDec(dr6["column2"])) != 0)
        //{
        //    dr6["column14"] = (((ToDec(dr6["column8"]) - ToDec(dr6["column2"])) / ToDec(dr6["column2"])) * 100).ToString("f2") + "%";
        //}
        //if (ToDec(dr6["column5"]) != 0 && (ToDec(dr6["column11"]) - ToDec(dr6["column5"])) != 0)
        //{
        //    dr6["column15"] = (((ToDec(dr6["column11"]) - ToDec(dr6["column5"])) / ToDec(dr6["column5"])) * 100).ToString("f2") + "%";
        //}
        //if ((ToDec(dr6["column8"]) - ToDec(dr6["column2"])) != 0)
        //{
        //    dr6["column16"] = (ToDec(dr6["column8"]) - ToDec(dr6["column2"])).ToString("f2");
        //}
        //if ((ToDec(dr6["column11"]) - ToDec(dr6["column5"])) != 0)
        //{
        //    dr6["column17"] = (ToDec(dr6["column11"]) - ToDec(dr6["column5"])).ToString("f2");
        //}
        //dt.Rows.Add(dr6);
        //AddDataRow(dt, "　（一）工资福利支出 ", "工资福利支出", "项目支出");
        AddDataRow(dt, "　　　1、津贴补贴 ", "津贴补贴", "项目支出");
        AddDataRow(dt, "　　　2、奖励性补贴", "奖金", "基本支出");

        //DataRow dr7 = dt.NewRow();
        //dr7["column1"] = "（二）其他商品和服务支出";
        //if ((dcLZero5 + dcLArea5) != 0)
        //{
        //    dr7["column2"] = (dcLZero5 + dcLArea5).ToString("f2");
        //}
        //if (dcLZero5 != 0)
        //{
        //    dr7["column3"] = (dcLZero5).ToString("f2");
        //}
        //if (dcLArea5 != 0)
        //{
        //    dr7["column4"] = (dcLArea5).ToString("f2");
        //}
        //if ((dcLTZero5 + dcLTArea5) != 0)
        //{
        //    dr7["column5"] = (dcLTZero5 + dcLTArea5).ToString("f2");
        //}
        //if (dcLTZero5 != 0)
        //{
        //    dr7["column6"] = (dcLTZero5).ToString("f2");
        //}
        //if (dcLTArea5 != 0)
        //{
        //    dr7["column7"] = (dcLTArea5).ToString("f2");
        //}
        //if ((dcZero5 + dcArea5) != 0)
        //{
        //    dr7["column8"] = (dcZero5 + dcArea5).ToString("f2");
        //}
        //if (dcZero5 != 0)
        //{
        //    dr7["column9"] = (dcZero5).ToString("f2");
        //}
        //if (dcArea5 != 0)
        //{
        //    dr7["column10"] = (dcArea5).ToString("f2");
        //}
        //if ((dcTZero5 + dcTArea5) != 0)
        //{
        //    dr7["column11"] = (dcTZero5 + dcTArea5).ToString("f2");
        //}
        //if (dcTZero5 != 0)
        //{
        //    dr7["column12"] = (dcTZero5).ToString("f2");
        //}
        //if (dcTArea5 != 0)
        //{
        //    dr7["column13"] = (dcTArea5).ToString("f2");
        //}
        //if (ToDec(dr7["column2"]) != 0 && (ToDec(dr7["column8"]) - ToDec(dr7["column2"])) != 0)
        //{
        //    dr7["column14"] = (((ToDec(dr7["column8"]) - ToDec(dr7["column2"])) / ToDec(dr7["column2"])) * 100).ToString("f2") + "%";
        //}
        //if (ToDec(dr7["column5"]) != 0 && (ToDec(dr7["column11"]) - ToDec(dr7["column5"])) != 0)
        //{
        //    dr7["column15"] = (((ToDec(dr7["column11"]) - ToDec(dr7["column5"])) / ToDec(dr7["column5"])) * 100).ToString("f2") + "%";
        //}
        //if ((ToDec(dr7["column8"]) - ToDec(dr7["column2"])) != 0)
        //{
        //    dr7["column16"] = (ToDec(dr7["column8"]) - ToDec(dr7["column2"])).ToString("f2");
        //}
        //if ((ToDec(dr7["column11"]) - ToDec(dr7["column5"])) != 0)
        //{
        //    dr7["column17"] = (ToDec(dr7["column11"]) - ToDec(dr7["column5"])).ToString("f2");
        //}
        //dt.Rows.Add(dr7);
        AddDataRow(dt, "　（二）其他商品和服务支出", "其他商品和服务支出", "项目支出");
        AddDataRow(dt, "　　　1、税法宣传费", "税法宣传费", "项目支出");
        AddDataRow(dt, "　　　2、稽查办案费", "稽查办案费", "项目支出");
        AddDataRow(dt, "　　　3、税务工作经费", "税务工作经费", "项目支出");
        AddDataRow(dt, "　　　4、发票工作经费", "发票工作经费", "项目支出");
        AddDataRow(dt, "　　　5、协税护税费", "协税护税费", "项目支出");
        AddDataRow(dt, "　　　6、党团工会活动经费", "党团工会活动经费", "项目支出");
        AddDataRow(dt, "　　　7、妇代会", "妇代会", "项目支出");
        AddDataRow(dt, "　　　8、三代手续费", "三代手续费", "项目支出");
        AddDataRow(dt, "　　　9、计算机应用经费", "计算机应用经费", "项目支出");
        AddDataRow(dt, "　　　10、其他", "其他", "项目支出");

        //DataRow dr8 = dt.NewRow();
        //dr8["column1"] = "（三）其他资本性支出";       
        //if ((dcLZero6 + dcLArea6) != 0)
        //{
        //    dr8["column2"] = (dcLZero6 + dcLArea6).ToString("f2");
        //}
        //if (dcLZero6 != 0)
        //{
        //    dr8["column3"] = (dcLZero6).ToString("f2");
        //}
        //if (dcLArea6 != 0)
        //{
        //    dr8["column4"] = (dcLArea6).ToString("f2");
        //}
        //if ((dcLTZero6 + dcLTArea6) != 0)
        //{
        //    dr8["column5"] = (dcLTZero6 + dcLTArea6).ToString("f2");
        //}
        //if (dcLTZero6 != 0)
        //{
        //    dr8["column6"] = (dcLTZero6).ToString("f2");
        //}
        //if (dcLTArea6 != 0)
        //{
        //    dr8["column7"] = (dcLTArea6).ToString("f2");
        //}
        //if ((dcZero6 + dcArea6) != 0)
        //{
        //    dr8["column8"] = (dcZero6 + dcArea6).ToString("f2");
        //}
        //if (dcZero6 != 0)
        //{
        //    dr8["column9"] = (dcZero6).ToString("f2");
        //}
        //if (dcArea5 != 0)
        //{
        //    dr8["column10"] = (dcArea6).ToString("f2");
        //}
        //if ((dcTZero6 + dcTArea6) != 0)
        //{
        //    dr8["column11"] = (dcTZero6 + dcTArea6).ToString("f2");
        //}
        //if (dcTZero6 != 0)
        //{
        //    dr8["column12"] = (dcTZero6).ToString("f2");
        //}
        //if (dcTArea6 != 0)
        //{
        //    dr8["column13"] = (dcTArea6).ToString("f2");
        //}
        //if (ToDec(dr8["column2"]) != 0 && (ToDec(dr8["column8"]) - ToDec(dr8["column2"])) != 0)
        //{
        //    dr8["column14"] = (((ToDec(dr8["column8"]) - ToDec(dr8["column2"])) / ToDec(dr8["column2"])) * 100).ToString("f2") + "%";
        //}
        //if (ToDec(dr8["column5"]) != 0 && (ToDec(dr8["column11"]) - ToDec(dr8["column5"])) != 0)
        //{
        //    dr8["column15"] = (((ToDec(dr8["column11"]) - ToDec(dr8["column5"])) / ToDec(dr8["column5"])) * 100).ToString("f2") + "%";
        //}
        //if ((ToDec(dr8["column8"]) - ToDec(dr8["column2"])) != 0)
        //{
        //    dr8["column16"] = (ToDec(dr8["column8"]) - ToDec(dr8["column2"])).ToString("f2");
        //}
        //if ((ToDec(dr8["column11"]) - ToDec(dr8["column5"])) != 0)
        //{
        //    dr8["column17"] = (ToDec(dr8["column11"]) - ToDec(dr8["column5"])).ToString("f2");
        //}
        //dt.Rows.Add(dr8);
        AddDataRow2(dt, "　（三）其他资本性支出", "其他资本性支出", "项目支出", 10);
        AddDataRow(dt, "　　　1、房屋建筑物购建", "房屋建筑物购建", "项目支出");
        AddDataRow(dt, "　　　2、办公设备购置费", "办公设备购置费", "项目支出");
        AddDataRow(dt, "　　　3、专用设备购置费", "专用设备购置费", "项目支出");
        AddDataRow(dt, "　　　4、交通工具购置费", "交通工具购置费", "项目支出");
        AddDataRow(dt, "　　　5、大型修缮", "大型修缮", "项目支出");
        AddDataRow(dt, "　　　6、信息网络购建", "信息网络购建", "项目支出");
        AddDataRow2(dt, "　　　7、其他资本性支出", "其他资本性支出", "项目支出", 12);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        HidSearchFlag.Value = "0";
        FunExpendBind();
        HidSearchFlag.Value = "1";
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string title = "(" + tbDate.Text + ")经费支出对比分析表.xls";
        DataTable dt = new DataTable();
        dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Columns.Add("column3");
        dt.Columns.Add("column4");
        dt.Columns.Add("column5");
        dt.Columns.Add("column6");
        dt.Columns.Add("column7");
        dt.Columns.Add("column8");
        dt.Columns.Add("column9");
        dt.Columns.Add("column10");
        dt.Columns.Add("column11");
        dt.Columns.Add("column12");
        dt.Columns.Add("column13");
        dt.Columns.Add("column14");
        dt.Columns.Add("column15");
        dt.Columns.Add("column16");
        dt.Columns.Add("column17");
        dt.Columns.Add("column18");
        GetRows(dt);
        TableCell[] header = new TableCell[27];
        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }
        header[0].Text = "经费支出对比分析表</th></tr><tr>";
        header[0].ColumnSpan = 18;
        header[1].Text = "支出项目";
        header[1].RowSpan = 3;
        header[2].Text = "上年支出（元）";
        header[2].ColumnSpan = 6;
        header[3].Text = "本年支出（元）";
        header[3].ColumnSpan = 6;
        header[4].Text = "比同期+、-%";
        header[4].ColumnSpan = 2;
        header[5].Text = "比同期+、-额（元）";
        header[5].ColumnSpan = 2;
        header[6].Text = "备   注</th></tr><tr>";
        header[6].RowSpan = 3;

        header[7].Text = "本月";
        header[7].ColumnSpan = 3;
        header[8].Text = "累计";
        header[8].ColumnSpan = 3;
        header[9].Text = "本月";
        header[9].ColumnSpan = 3;
        header[10].Text = "累计";
        header[10].ColumnSpan = 3;
        header[11].Text = "本月";
        header[11].RowSpan = 2;
        header[12].Text = "累计";
        header[12].RowSpan = 2;
        header[13].Text = "本月";
        header[13].RowSpan = 2;
        header[14].Text = "累计</th></tr><tr>";
        header[14].RowSpan = 2;

        header[15].Text = "合计";
        header[16].Text = "零户经费";
        header[17].Text = "区级经费";
        header[18].Text = "合计";
        header[19].Text = "零户经费";
        header[20].Text = "区级经费";
        header[21].Text = "合计";
        header[22].Text = "零户经费";
        header[23].Text = "区级经费";
        header[24].Text = "合计";
        header[25].Text = "零户经费";
        header[26].Text = "区级经费</th>";

        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            mergeCellNums.Add(i, 0);
        }
        common.DataTable2Excel(dt, header, title, mergeCellNums, 0);
        
    }
}