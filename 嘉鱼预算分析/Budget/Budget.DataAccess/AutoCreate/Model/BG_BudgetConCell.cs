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
	public class BG_BudgetConCell
	{
	
		private int bCCID; 
		private int pIID;
		private string bCCName = String.Empty;
		private decimal bCCStan;
		private string bCCUseSta = String.Empty;

		
		public BG_BudgetConCell() { }
		
		
		public int BCCID
		{
			get { return this.bCCID; }
			set { this.bCCID = value; }
		}
		
        
		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
		
		public string BCCName
		{
			get { return this.bCCName; }
			set { this.bCCName = value; }
		}		
		
		
		public decimal BCCStan
		{
			get { return this.bCCStan; }
			set { this.bCCStan = value; }
		}		
		
		
		public string BCCUseSta
		{
			get { return this.bCCUseSta; }
			set { this.bCCUseSta = value; }
		}		
		
	}
}
