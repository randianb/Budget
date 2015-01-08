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
	public class BG_EstimatesAllocation
	{
	
		private int bEAID; 
		private int depID;
		private int pIID;
		private decimal bEAMon;
		private int bEAYear;

		
		public BG_EstimatesAllocation() { }
		
		
		public int BEAID
		{
			get { return this.bEAID; }
			set { this.bEAID = value; }
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
		
		
		public decimal BEAMon
		{
			get { return this.bEAMon; }
			set { this.bEAMon = value; }
		}		
		
		
		public int BEAYear
		{
			get { return this.bEAYear; }
			set { this.bEAYear = value; }
		}		
		
	}
}
