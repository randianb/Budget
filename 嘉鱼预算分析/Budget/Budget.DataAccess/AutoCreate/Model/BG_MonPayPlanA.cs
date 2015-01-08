//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:00
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_MonPayPlanA
	{
	
		private int cAID; 
		private int cPID;
		private decimal mABasicExp;
		private decimal mAProExp;
		private decimal mATotal;
		private DateTime mATime;
		private decimal mAFunding;

		
		public BG_MonPayPlanA() { }
		
		
		public int CAID
		{
			get { return this.cAID; }
			set { this.cAID = value; }
		}
		
        
		
		
		
		public int CPID
		{
			get { return this.cPID; }
			set { this.cPID = value; }
		}		
		
		
		public decimal MABasicExp
		{
			get { return this.mABasicExp; }
			set { this.mABasicExp = value; }
		}		
		
		
		public decimal MAProExp
		{
			get { return this.mAProExp; }
			set { this.mAProExp = value; }
		}		
		
		
		public decimal MATotal
		{
			get { return this.mATotal; }
			set { this.mATotal = value; }
		}		
		
		
		public DateTime MATime
		{
			get { return this.mATime; }
			set { this.mATime = value; }
		}		
		
		
		public decimal MAFunding
		{
			get { return this.mAFunding; }
			set { this.mAFunding = value; }
		}		
		
	}
}
