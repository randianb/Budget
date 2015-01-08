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
	public class FA_OutlayDepCK
	{
	
		private int oDID; 
		private int pIID;
		private int depID;
		private decimal oDCkAreaMon;
		private decimal oDCkZeroMon;
		private DateTime oDCkTime;

		
		public FA_OutlayDepCK() { }
		
		
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
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public decimal ODCkAreaMon
		{
			get { return this.oDCkAreaMon; }
			set { this.oDCkAreaMon = value; }
		}		
		
		
		public decimal ODCkZeroMon
		{
			get { return this.oDCkZeroMon; }
			set { this.oDCkZeroMon = value; }
		}		
		
		
		public DateTime ODCkTime
		{
			get { return this.oDCkTime; }
			set { this.oDCkTime = value; }
		}		
		
	}
}
