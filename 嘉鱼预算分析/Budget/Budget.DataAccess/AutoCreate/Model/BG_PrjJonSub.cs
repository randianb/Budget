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
	public class BG_PrjJonSub
	{
	
		private int pSID; 
		private int pPID;
		private int pIID;

		
		public BG_PrjJonSub() { }
		
		
		public int PSID
		{
			get { return this.pSID; }
			set { this.pSID = value; }
		}
		
        
		
		
		
		public int PPID
		{
			get { return this.pPID; }
			set { this.pPID = value; }
		}		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
	}
}
