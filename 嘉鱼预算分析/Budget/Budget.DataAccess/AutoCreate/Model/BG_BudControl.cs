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
	public class BG_BudControl
	{
	
		private int bCID; 
		private string bCName = String.Empty;
		private string bCType = String.Empty;
		private decimal bCMon;
		private decimal bCAdjust;

		
		public BG_BudControl() { }
		
		
		public int BCID
		{
			get { return this.bCID; }
			set { this.bCID = value; }
		}
		
        
		
		
		
		public string BCName
		{
			get { return this.bCName; }
			set { this.bCName = value; }
		}		
		
		
		public string BCType
		{
			get { return this.bCType; }
			set { this.bCType = value; }
		}		
		
		
		public decimal BCMon
		{
			get { return this.bCMon; }
			set { this.bCMon = value; }
		}		
		
		
		public decimal BCAdjust
		{
			get { return this.bCAdjust; }
			set { this.bCAdjust = value; }
		}		
		
	}
}
