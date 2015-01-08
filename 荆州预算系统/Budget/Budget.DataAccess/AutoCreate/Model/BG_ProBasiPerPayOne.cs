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
	public class BG_ProBasiPerPayOne
	{
	
		private int pOID; 
		private int depID;
		private DateTime pOYear;
		private decimal pOBS;
		private decimal pOAS;
		private decimal pOBonus;
		private decimal pOPS;
		private decimal pOSE;
		private decimal pOOther;
		private decimal pOTitol;

		
		public BG_ProBasiPerPayOne() { }
		
		
		public int POID
		{
			get { return this.pOID; }
			set { this.pOID = value; }
		}
		
        
		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public DateTime POYear
		{
			get { return this.pOYear; }
			set { this.pOYear = value; }
		}		
		
		
		public decimal POBS
		{
			get { return this.pOBS; }
			set { this.pOBS = value; }
		}		
		
		
		public decimal POAS
		{
			get { return this.pOAS; }
			set { this.pOAS = value; }
		}		
		
		
		public decimal POBonus
		{
			get { return this.pOBonus; }
			set { this.pOBonus = value; }
		}		
		
		
		public decimal POPS
		{
			get { return this.pOPS; }
			set { this.pOPS = value; }
		}		
		
		
		public decimal POSE
		{
			get { return this.pOSE; }
			set { this.pOSE = value; }
		}		
		
		
		public decimal POOther
		{
			get { return this.pOOther; }
			set { this.pOOther = value; }
		}		
		
		
		public decimal POTitol
		{
			get { return this.pOTitol; }
			set { this.pOTitol = value; }
		}		
		
	}
}
