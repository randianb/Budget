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
	public class BG_OutlayCK
	{
	
		private int oAID; 
		private int pIID;
		private int pPID;
		private int depID;
		private decimal oACkMon;
		private DateTime oATime;
		private string oACkType = String.Empty;

		
		public BG_OutlayCK() { }
		
		
		public int OAID
		{
			get { return this.oAID; }
			set { this.oAID = value; }
		}
		
        
		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
		
		public int PPID
		{
			get { return this.pPID; }
			set { this.pPID = value; }
		}		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public decimal OACkMon
		{
			get { return this.oACkMon; }
			set { this.oACkMon = value; }
		}		
		
		
		public DateTime OATime
		{
			get { return this.oATime; }
			set { this.oATime = value; }
		}		
		
		
		public string OACkType
		{
			get { return this.oACkType; }
			set { this.oACkType = value; }
		}		
		
	}
}
