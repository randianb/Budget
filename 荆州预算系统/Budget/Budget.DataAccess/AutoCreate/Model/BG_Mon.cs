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
	public class BG_Mon
	{
	
		private int bGID; 
		private decimal bGMon;
		private int bGYear;
		private int isEditMon;

		
		public BG_Mon() { }
		
		
		public int BGID
		{
			get { return this.bGID; }
			set { this.bGID = value; }
		}
		
        
		
		
		
		public decimal BGMon
		{
			get { return this.bGMon; }
			set { this.bGMon = value; }
		}		
		
		
		public int BGYear
		{
			get { return this.bGYear; }
			set { this.bGYear = value; }
		}		
		
		
		public int IsEditMon
		{
			get { return this.isEditMon; }
			set { this.isEditMon = value; }
		}		
		
	}
}
