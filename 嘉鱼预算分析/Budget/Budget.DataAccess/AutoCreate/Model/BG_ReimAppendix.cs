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
	public class BG_ReimAppendix
	{
	
		private int rADID; 
		private int aRID;
		private string aRType = String.Empty;
		private string aRName = String.Empty;
		private string aRContent = String.Empty;
		private DateTime aRTime;

		
		public BG_ReimAppendix() { }
		
		
		public int RADID
		{
			get { return this.rADID; }
			set { this.rADID = value; }
		}
		
        
		
		
		
		public int ARID
		{
			get { return this.aRID; }
			set { this.aRID = value; }
		}		
		
		
		public string ARType
		{
			get { return this.aRType; }
			set { this.aRType = value; }
		}		
		
		
		public string ARName
		{
			get { return this.aRName; }
			set { this.aRName = value; }
		}		
		
		
		public string ARContent
		{
			get { return this.aRContent; }
			set { this.aRContent = value; }
		}		
		
		
		public DateTime ARTime
		{
			get { return this.aRTime; }
			set { this.aRTime = value; }
		}		
		
	}
}
