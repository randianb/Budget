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
	public class FA_BudConNum
	{
	
		private int bCID; 
		private decimal bCNBasExpBudMon;
		private decimal bCNProExpBudMon;
		private decimal bCNBasAddBudMon;
		private decimal bCNProAddBudMon;
		private int bCNYear;

		
		public FA_BudConNum() { }
		
		
		public int BCID
		{
			get { return this.bCID; }
			set { this.bCID = value; }
		}
		
        
		
		
		
		public decimal BCNBasExpBudMon
		{
			get { return this.bCNBasExpBudMon; }
			set { this.bCNBasExpBudMon = value; }
		}		
		
		
		public decimal BCNProExpBudMon
		{
			get { return this.bCNProExpBudMon; }
			set { this.bCNProExpBudMon = value; }
		}		
		
		
		public decimal BCNBasAddBudMon
		{
			get { return this.bCNBasAddBudMon; }
			set { this.bCNBasAddBudMon = value; }
		}		
		
		
		public decimal BCNProAddBudMon
		{
			get { return this.bCNProAddBudMon; }
			set { this.bCNProAddBudMon = value; }
		}		
		
		
		public int BCNYear
		{
			get { return this.bCNYear; }
			set { this.bCNYear = value; }
		}		
		
	}
}
