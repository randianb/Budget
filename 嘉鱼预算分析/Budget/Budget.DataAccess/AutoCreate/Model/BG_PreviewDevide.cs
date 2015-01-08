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
	public class BG_PreviewDevide
	{
	
		private int pDID; 
		private int depID;
		private int pSID;
		private decimal devMon;

		
		public BG_PreviewDevide() { }
		
		
		public int PDID
		{
			get { return this.pDID; }
			set { this.pDID = value; }
		}
		
        
		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public int PSID
		{
			get { return this.pSID; }
			set { this.pSID = value; }
		}		
		
		
		public decimal DevMon
		{
			get { return this.devMon; }
			set { this.devMon = value; }
		}		
		
	}
}
