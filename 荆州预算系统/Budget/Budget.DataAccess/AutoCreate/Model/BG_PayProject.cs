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
	public class BG_PayProject
	{
	
		private int pPID; 
		private string payPrjName = String.Empty;
		private int pIID;

		
		public BG_PayProject() { }
		
		
		public int PPID
		{
			get { return this.pPID; }
			set { this.pPID = value; }
		}
		
        
		
		
		
		public string PayPrjName
		{
			get { return this.payPrjName; }
			set { this.payPrjName = value; }
		}		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
	}
}
