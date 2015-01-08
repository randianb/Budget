//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-05-13 11:24:24
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
		private decimal money;
		private int year;

		
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
		
		
		public decimal Money
		{
			get { return this.money; }
			set { this.money = value; }
		}		
		
		
		public int Year
		{
			get { return this.year; }
			set { this.year = value; }
		}		
		
	}
}
