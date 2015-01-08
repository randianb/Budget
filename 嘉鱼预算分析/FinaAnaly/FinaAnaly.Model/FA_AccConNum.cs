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
	public class FA_AccConNum
	{
	
		private int aCID; 
		private decimal aCNBasExpBudMon;
		private decimal aCNProExpBudMon;
		private int aCNYear;

		
		public FA_AccConNum() { }
		
		
		public int ACID
		{
			get { return this.aCID; }
			set { this.aCID = value; }
		}
		
        
		
		
		
		public decimal ACNBasExpBudMon
		{
			get { return this.aCNBasExpBudMon; }
			set { this.aCNBasExpBudMon = value; }
		}		
		
		
		public decimal ACNProExpBudMon
		{
			get { return this.aCNProExpBudMon; }
			set { this.aCNProExpBudMon = value; }
		}		
		
		
		public int ACNYear
		{
			get { return this.aCNYear; }
			set { this.aCNYear = value; }
		}		
		
	}
}
