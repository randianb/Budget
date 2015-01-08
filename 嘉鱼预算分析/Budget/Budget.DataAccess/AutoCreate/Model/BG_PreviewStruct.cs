//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:01
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_PreviewStruct
	{
	
		private int pSID; 
		private string pSType = String.Empty;
		private string pSType2 = String.Empty;
		private string pSName = String.Empty;
		private decimal pDData;
		private decimal pDLYData;

		
		public BG_PreviewStruct() { }
		
		
		public int PSID
		{
			get { return this.pSID; }
			set { this.pSID = value; }
		}
		
        
		
		
		
		public string PSType
		{
			get { return this.pSType; }
			set { this.pSType = value; }
		}		
		
		
		public string PSType2
		{
			get { return this.pSType2; }
			set { this.pSType2 = value; }
		}		
		
		
		public string PSName
		{
			get { return this.pSName; }
			set { this.pSName = value; }
		}		
		
		
		public decimal PDData
		{
			get { return this.pDData; }
			set { this.pDData = value; }
		}		
		
		
		public decimal PDLYData
		{
			get { return this.pDLYData; }
			set { this.pDLYData = value; }
		}		
		
	}
}
