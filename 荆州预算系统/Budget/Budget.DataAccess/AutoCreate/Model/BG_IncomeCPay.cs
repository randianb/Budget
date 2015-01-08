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
	public class BG_IncomeCPay
	{
	
		private int iCPID; 
		private int depID;
		private string inComeSouce = String.Empty;
		private decimal inComeMon;
		private DateTime iCPTime;

		
		public BG_IncomeCPay() { }
		
		
		public int ICPID
		{
			get { return this.iCPID; }
			set { this.iCPID = value; }
		}
		
        
		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public string InComeSouce
		{
			get { return this.inComeSouce; }
			set { this.inComeSouce = value; }
		}		
		
		
		public decimal InComeMon
		{
			get { return this.inComeMon; }
			set { this.inComeMon = value; }
		}		
		
		
		public DateTime ICPTime
		{
			get { return this.iCPTime; }
			set { this.iCPTime = value; }
		}		
		
	}
}
