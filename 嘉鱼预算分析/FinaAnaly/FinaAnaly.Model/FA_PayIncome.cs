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
	public class FA_PayIncome
	{
	
		private int pIID; 
		private string pIEcoSubCoding = String.Empty;
		private int pIEcoSubLev;
		private int pIEcoSubParID;
		private string pIEcoSubName = String.Empty;
		private string pIType = String.Empty;

		
		public FA_PayIncome() { }
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}
		
        
		
		
		
		public string PIEcoSubCoding
		{
			get { return this.pIEcoSubCoding; }
			set { this.pIEcoSubCoding = value; }
		}		
		
		
		public int PIEcoSubLev
		{
			get { return this.pIEcoSubLev; }
			set { this.pIEcoSubLev = value; }
		}		
		
		
		public int PIEcoSubParID
		{
			get { return this.pIEcoSubParID; }
			set { this.pIEcoSubParID = value; }
		}		
		
		
		public string PIEcoSubName
		{
			get { return this.pIEcoSubName; }
			set { this.pIEcoSubName = value; }
		}		
		
		
		public string PIType
		{
			get { return this.pIType; }
			set { this.pIType = value; }
		}		
		
	}
}
