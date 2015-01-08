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
	public class BG_Supplementary
	{
	
		private int suppID; 
		private decimal suppMon;
		private int year;

		
		public BG_Supplementary() { }
		
		
		public int SuppID
		{
			get { return this.suppID; }
			set { this.suppID = value; }
		}
		
        
		
		
		
		public decimal SuppMon
		{
			get { return this.suppMon; }
			set { this.suppMon = value; }
		}		
		
		
		public int Year
		{
			get { return this.year; }
			set { this.year = value; }
		}		
		
	}
}
