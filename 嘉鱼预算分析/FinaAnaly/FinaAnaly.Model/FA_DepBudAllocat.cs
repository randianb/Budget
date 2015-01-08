//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:02
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace FinaAnaly.Model
{
	
	[Serializable()]
	public class FA_DepBudAllocat
	{
	
		private int dBAID; 
		private int depID;
		private decimal dBAMon;
		private int dBAYear;

		
		public FA_DepBudAllocat() { }
		
		
		public int DBAID
		{
			get { return this.dBAID; }
			set { this.dBAID = value; }
		}
		
        
		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public decimal DBAMon
		{
			get { return this.dBAMon; }
			set { this.dBAMon = value; }
		}		
		
		
		public int DBAYear
		{
			get { return this.dBAYear; }
			set { this.dBAYear = value; }
		}		
		
	}
}
