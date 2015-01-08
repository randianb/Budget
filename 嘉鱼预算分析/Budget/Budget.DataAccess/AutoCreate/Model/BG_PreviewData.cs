//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:00
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_PreviewData
	{
	
		private int pSID; 
		private string pSType1 = String.Empty;
		private string pSType2 = String.Empty;
		private string pSName = String.Empty;
		private decimal pDBaseData;
		private decimal pDBaseLYData;
		private decimal pDProjectData;
		private decimal pDProjectLYData;

		
		public BG_PreviewData() { }
		
		
		public int PSID
		{
			get { return this.pSID; }
			set { this.pSID = value; }
		}
		
        
		
		
		
		public string PSType1
		{
			get { return this.pSType1; }
			set { this.pSType1 = value; }
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
		
		
		public decimal PDBaseData
		{
			get { return this.pDBaseData; }
			set { this.pDBaseData = value; }
		}		
		
		
		public decimal PDBaseLYData
		{
			get { return this.pDBaseLYData; }
			set { this.pDBaseLYData = value; }
		}		
		
		
		public decimal PDProjectData
		{
			get { return this.pDProjectData; }
			set { this.pDProjectData = value; }
		}		
		
		
		public decimal PDProjectLYData
		{
			get { return this.pDProjectLYData; }
			set { this.pDProjectLYData = value; }
		}		
		
	}
}
