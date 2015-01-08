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
	public class BG_ProPay
	{
	
		private int proPID; 
		private int depID;
		private DateTime proPYear;
		private string pPID = String.Empty;
		private decimal proPA0M;

		
		public BG_ProPay() { }
		
		
		public int ProPID
		{
			get { return this.proPID; }
			set { this.proPID = value; }
		}
		
        
		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public DateTime ProPYear
		{
			get { return this.proPYear; }
			set { this.proPYear = value; }
		}		
		
		
		public string PPID
		{
			get { return this.pPID; }
			set { this.pPID = value; }
		}		
		
		
		public decimal ProPA0M
		{
			get { return this.proPA0M; }
			set { this.proPA0M = value; }
		}		
		
	}
}
