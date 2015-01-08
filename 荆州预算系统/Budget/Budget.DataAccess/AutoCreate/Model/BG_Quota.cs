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
	public class BG_Quota
	{
	
		private int qtID; 
		private int pIID;
		private string money = String.Empty;
		private DateTime qtime;
		private int depID;

		
		public BG_Quota() { }
		
		
		public int QtID
		{
			get { return this.qtID; }
			set { this.qtID = value; }
		}
		
        
		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
		
		public string Money
		{
			get { return this.money; }
			set { this.money = value; }
		}		
		
		
		public DateTime Qtime
		{
			get { return this.qtime; }
			set { this.qtime = value; }
		}		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
	}
}
