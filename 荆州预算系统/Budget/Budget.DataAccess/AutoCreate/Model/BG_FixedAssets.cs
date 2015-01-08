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
	public class BG_FixedAssets
	{
	
		private int fAID; 
		private string fACode = String.Empty;
		private decimal fAMon;
		private int fAYear;
		private int fAMonth;

		
		public BG_FixedAssets() { }
		
		
		public int FAID
		{
			get { return this.fAID; }
			set { this.fAID = value; }
		}
		
        
		
		
		
		public string FACode
		{
			get { return this.fACode; }
			set { this.fACode = value; }
		}		
		
		
		public decimal FAMon
		{
			get { return this.fAMon; }
			set { this.fAMon = value; }
		}		
		
		
		public int FAYear
		{
			get { return this.fAYear; }
			set { this.fAYear = value; }
		}		
		
		
		public int FAMonth
		{
			get { return this.fAMonth; }
			set { this.fAMonth = value; }
		}		
		
	}
}
