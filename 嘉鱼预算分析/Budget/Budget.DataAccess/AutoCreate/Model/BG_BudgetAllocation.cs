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
	public class BG_BudgetAllocation
	{
	
		private int bAAID; 
		private int depID;
		private int pIID;
		private decimal bAAMon;
		private decimal suppMon;
		private int bAAYear;

		
		public BG_BudgetAllocation() { }
		
		
		public int BAAID
		{
			get { return this.bAAID; }
			set { this.bAAID = value; }
		}
		
        
		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
		
		public decimal BAAMon
		{
			get { return this.bAAMon; }
			set { this.bAAMon = value; }
		}		
		
		
		public decimal SuppMon
		{
			get { return this.suppMon; }
			set { this.suppMon = value; }
		}		
		
		
		public int BAAYear
		{
			get { return this.bAAYear; }
			set { this.bAAYear = value; }
		}		
		
	}
}
