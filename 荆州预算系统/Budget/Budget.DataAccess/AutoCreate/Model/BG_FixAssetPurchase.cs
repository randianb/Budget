//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:43
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_FixAssetPurchase
	{
	
		private int fAID; 
		private int budID;
		private string fAName = String.Empty;
		private string fAModel = String.Empty;
		private string fABrand = String.Empty;
		private decimal fAPrice;
		private int fANum;
		private decimal fAMon;
		private string fAIsGovPur = String.Empty;
		private string fAConfig = String.Empty;
		private string fARemark = String.Empty;
		private DateTime fATime;

		
		public BG_FixAssetPurchase() { }
		
		
		public int FAID
		{
			get { return this.fAID; }
			set { this.fAID = value; }
		}
		
        
		
		
		
		public int BudID
		{
			get { return this.budID; }
			set { this.budID = value; }
		}		
		
		
		public string FAName
		{
			get { return this.fAName; }
			set { this.fAName = value; }
		}		
		
		
		public string FAModel
		{
			get { return this.fAModel; }
			set { this.fAModel = value; }
		}		
		
		
		public string FABrand
		{
			get { return this.fABrand; }
			set { this.fABrand = value; }
		}		
		
		
		public decimal FAPrice
		{
			get { return this.fAPrice; }
			set { this.fAPrice = value; }
		}		
		
		
		public int FANum
		{
			get { return this.fANum; }
			set { this.fANum = value; }
		}		
		
		
		public decimal FAMon
		{
			get { return this.fAMon; }
			set { this.fAMon = value; }
		}		
		
		
		public string FAIsGovPur
		{
			get { return this.fAIsGovPur; }
			set { this.fAIsGovPur = value; }
		}		
		
		
		public string FAConfig
		{
			get { return this.fAConfig; }
			set { this.fAConfig = value; }
		}		
		
		
		public string FARemark
		{
			get { return this.fARemark; }
			set { this.fARemark = value; }
		}		
		
		
		public DateTime FATime
		{
			get { return this.fATime; }
			set { this.fATime = value; }
		}		
		
	}
}
