//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace FinaAnaly.Model
{
	
	[Serializable()]
	public class FA_OutlayIncomeDepCK
	{
	
		private int oDID; 
		private int pIID;
		private decimal oDCKAreaMon;
		private decimal oDCKZeroMon;
		private DateTime oDCKTime;

		
		public FA_OutlayIncomeDepCK() { }
		
		
		public int ODID
		{
			get { return this.oDID; }
			set { this.oDID = value; }
		}
		
        
		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
		
		public decimal ODCKAreaMon
		{
			get { return this.oDCKAreaMon; }
			set { this.oDCKAreaMon = value; }
		}		
		
		
		public decimal ODCKZeroMon
		{
			get { return this.oDCKZeroMon; }
			set { this.oDCKZeroMon = value; }
		}		
		
		
		public DateTime ODCKTime
		{
			get { return this.oDCKTime; }
			set { this.oDCKTime = value; }
		}		
		
	}
}
