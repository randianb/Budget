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
	public class FA_IncomeBudAllocat
	{
	
		private int iBAID; 
		private int pIID;
		private decimal iBAMon;
		private int iBAYear;

		
		public FA_IncomeBudAllocat() { }
		
		
		public int IBAID
		{
			get { return this.iBAID; }
			set { this.iBAID = value; }
		}
		
        
		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
		
		public decimal IBAMon
		{
			get { return this.iBAMon; }
			set { this.iBAMon = value; }
		}		
		
		
		public int IBAYear
		{
			get { return this.iBAYear; }
			set { this.iBAYear = value; }
		}		
		
	}
}
