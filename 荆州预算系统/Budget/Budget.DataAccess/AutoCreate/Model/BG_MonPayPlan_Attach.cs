//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/8 17:48:02
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_MonPayPlan_Attach
	{
	
		private int cPAID; 
		private int pIID;
		private decimal mPFunding;
		private int deptID;
		private DateTime mPTime;
		private string mPRemark = String.Empty;
		private decimal mPFundingAdd;
		private int cPATimes;
		private int cPID;

		
		public BG_MonPayPlan_Attach() { }
		
		
		public int CPAID
		{
			get { return this.cPAID; }
			set { this.cPAID = value; }
		}
		
        
		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
		
		public decimal MPFunding
		{
			get { return this.mPFunding; }
			set { this.mPFunding = value; }
		}		
		
		
		public int DeptID
		{
			get { return this.deptID; }
			set { this.deptID = value; }
		}		
		
		
		public DateTime MPTime
		{
			get { return this.mPTime; }
			set { this.mPTime = value; }
		}		
		
		
		public string MPRemark
		{
			get { return this.mPRemark; }
			set { this.mPRemark = value; }
		}		
		
		
		public decimal MPFundingAdd
		{
			get { return this.mPFundingAdd; }
			set { this.mPFundingAdd = value; }
		}		
		
		
		public int CPATimes
		{
			get { return this.cPATimes; }
			set { this.cPATimes = value; }
		}		
		
		
		public int CPID
		{
			get { return this.cPID; }
			set { this.cPID = value; }
		}		
		
	}
}
