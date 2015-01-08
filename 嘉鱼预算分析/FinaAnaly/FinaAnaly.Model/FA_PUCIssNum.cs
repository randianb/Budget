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
	public class FA_PUCIssNum
	{
	
		private int pUCID; 
		private string pIEcoSubName = String.Empty;
		private decimal pUCMon;
		private int pUCYear;

		
		public FA_PUCIssNum() { }
		
		
		public int PUCID
		{
			get { return this.pUCID; }
			set { this.pUCID = value; }
		}
		
        
		
		
		
		public string PIEcoSubName
		{
			get { return this.pIEcoSubName; }
			set { this.pIEcoSubName = value; }
		}		
		
		
		public decimal PUCMon
		{
			get { return this.pUCMon; }
			set { this.pUCMon = value; }
		}		
		
		
		public int PUCYear
		{
			get { return this.pUCYear; }
			set { this.pUCYear = value; }
		}		
		
	}
}
