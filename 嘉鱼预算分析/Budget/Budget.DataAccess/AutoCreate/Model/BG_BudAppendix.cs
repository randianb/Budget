//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:15:59
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_BudAppendix
	{
	
		private int aPID; 
		private int budID;
		private string aPPath = String.Empty;
		private string apName = String.Empty;
		private DateTime apTime;

		
		public BG_BudAppendix() { }
		
		
		public int APID
		{
			get { return this.aPID; }
			set { this.aPID = value; }
		}
		
        
		
		
		
		public int BudID
		{
			get { return this.budID; }
			set { this.budID = value; }
		}		
		
		
		public string APPath
		{
			get { return this.aPPath; }
			set { this.aPPath = value; }
		}		
		
		
		public string ApName
		{
			get { return this.apName; }
			set { this.apName = value; }
		}		
		
		
		public DateTime ApTime
		{
			get { return this.apTime; }
			set { this.apTime = value; }
		}		
		
	}
}
