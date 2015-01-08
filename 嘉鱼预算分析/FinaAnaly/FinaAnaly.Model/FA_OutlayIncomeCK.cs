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
	public class FA_OutlayIncomeCK
	{
	
		private int oIID; 
		private int pIID;
		private decimal oICkAreaMon;
		private decimal oICkZeroMon;
		private DateTime oICkTime;

		
		public FA_OutlayIncomeCK() { }
		
		
		public int OIID
		{
			get { return this.oIID; }
			set { this.oIID = value; }
		}
		
        
		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
		
		public decimal OICkAreaMon
		{
			get { return this.oICkAreaMon; }
			set { this.oICkAreaMon = value; }
		}		
		
		
		public decimal OICkZeroMon
		{
			get { return this.oICkZeroMon; }
			set { this.oICkZeroMon = value; }
		}		
		
		
		public DateTime OICkTime
		{
			get { return this.oICkTime; }
			set { this.oICkTime = value; }
		}		
		
	}
}
