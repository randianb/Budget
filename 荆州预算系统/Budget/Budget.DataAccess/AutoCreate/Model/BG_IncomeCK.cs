//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:43
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_IncomeCK
	{
	
		private int iKID; 
		private int eIID;
		private int depID;
		private decimal iACkMon;
		private DateTime iATime;

		
		public BG_IncomeCK() { }
		
		
		public int IKID
		{
			get { return this.iKID; }
			set { this.iKID = value; }
		}
		
        
		
		
		
		public int EIID
		{
			get { return this.eIID; }
			set { this.eIID = value; }
		}		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public decimal IACkMon
		{
			get { return this.iACkMon; }
			set { this.iACkMon = value; }
		}		
		
		
		public DateTime IATime
		{
			get { return this.iATime; }
			set { this.iATime = value; }
		}		
		
	}
}
