//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2015/1/22 8:18:38
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
		private decimal baseMon;
		private decimal proMon;
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
		
		
		public decimal BaseMon
		{
			get { return this.baseMon; }
			set { this.baseMon = value; }
		}		
		
		
		public decimal ProMon
		{
			get { return this.proMon; }
			set { this.proMon = value; }
		}		
		
		
		public int Year
		{
			get { return this.year; }
			set { this.year = value; }
		}		
		
	}
}
