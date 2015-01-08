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
	public class BG_BudCostPro
	{
	
		private int costID; 
		private int budID;
		private int bCPCurrYear;
		private int pIID;
		private decimal bCPTotal;
		private decimal bCPSubtFinAllo;
		private decimal bCPSubtExp;
		private decimal bCInExpenses;
		private decimal bCOutFunding;
		private string bCPRemark = String.Empty;

		
		public BG_BudCostPro() { }
		
		
		public int CostID
		{
			get { return this.costID; }
			set { this.costID = value; }
		}
		
        
		
		
		
		public int BudID
		{
			get { return this.budID; }
			set { this.budID = value; }
		}		
		
		
		public int BCPCurrYear
		{
			get { return this.bCPCurrYear; }
			set { this.bCPCurrYear = value; }
		}		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
		
		public decimal BCPTotal
		{
			get { return this.bCPTotal; }
			set { this.bCPTotal = value; }
		}		
		
		
		public decimal BCPSubtFinAllo
		{
			get { return this.bCPSubtFinAllo; }
			set { this.bCPSubtFinAllo = value; }
		}		
		
		
		public decimal BCPSubtExp
		{
			get { return this.bCPSubtExp; }
			set { this.bCPSubtExp = value; }
		}		
		
		
		public decimal BCInExpenses
		{
			get { return this.bCInExpenses; }
			set { this.bCInExpenses = value; }
		}		
		
		
		public decimal BCOutFunding
		{
			get { return this.bCOutFunding; }
			set { this.bCOutFunding = value; }
		}		
		
		
		public string BCPRemark
		{
			get { return this.bCPRemark; }
			set { this.bCPRemark = value; }
		}		
		
	}
}
