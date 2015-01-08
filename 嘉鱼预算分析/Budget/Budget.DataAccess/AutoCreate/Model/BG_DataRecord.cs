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
	public class BG_DataRecord
	{
	
		private int dRID; 
		private string dRType = String.Empty;
		private DateTime dRTime;
		private string dRName = String.Empty;
		private string isBackUp = String.Empty;

		
		public BG_DataRecord() { }
		
		
		public int DRID
		{
			get { return this.dRID; }
			set { this.dRID = value; }
		}
		
        
		
		
		
		public string DRType
		{
			get { return this.dRType; }
			set { this.dRType = value; }
		}		
		
		
		public DateTime DRTime
		{
			get { return this.dRTime; }
			set { this.dRTime = value; }
		}		
		
		
		public string DRName
		{
			get { return this.dRName; }
			set { this.dRName = value; }
		}		
		
		
		public string IsBackUp
		{
			get { return this.isBackUp; }
			set { this.isBackUp = value; }
		}		
		
	}
}
