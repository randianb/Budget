//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2015/1/21 16:13:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_Project
	{
	
		private int pJID; 
		private string pJName = String.Empty;

		
		public BG_Project() { }
		
		
		public int PJID
		{
			get { return this.pJID; }
			set { this.pJID = value; }
		}
		
        
		
		
		
		public string PJName
		{
			get { return this.pJName; }
			set { this.pJName = value; }
		}		
		
	}
}
