//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:15:59
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_BudgetCon
	{
	
		private int pIID; 
		private string yNUse = String.Empty;
		private string bCRemark = String.Empty;

		
		public BG_BudgetCon() { }
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}
		
        
		
		
		
		public string YNUse
		{
			get { return this.yNUse; }
			set { this.yNUse = value; }
		}		
		
		
		public string BCRemark
		{
			get { return this.bCRemark; }
			set { this.bCRemark = value; }
		}		
		
	}
}
