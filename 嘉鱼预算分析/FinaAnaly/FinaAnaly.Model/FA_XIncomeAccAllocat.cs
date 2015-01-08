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
	public class FA_XIncomeAccAllocat
	{
	
		private int iAAID; 
		private int pIID;
		private decimal iAAMon;
		private int iAAYear;

		
		public FA_XIncomeAccAllocat() { }
		
		
		public int IAAID
		{
			get { return this.iAAID; }
			set { this.iAAID = value; }
		}
		
        
		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
		
		public decimal IAAMon
		{
			get { return this.iAAMon; }
			set { this.iAAMon = value; }
		}		
		
		
		public int IAAYear
		{
			get { return this.iAAYear; }
			set { this.iAAYear = value; }
		}		
		
	}
}
