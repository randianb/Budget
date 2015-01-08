//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/6/12 11:28:32
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_Pre
	{
	
		private int preID; 
		private decimal preMon;
		private int year;

		
		public BG_Pre() { }
		
		
		public int PreID
		{
			get { return this.preID; }
			set { this.preID = value; }
		}
		
        
		
		
		
		public decimal PreMon
		{
			get { return this.preMon; }
			set { this.preMon = value; }
		}		
		
		
		public int Year
		{
			get { return this.year; }
			set { this.year = value; }
		}		
		
	}
}
