//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:00
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_PayWelExpen
	{
	
		private int pWEID; 
		private int pWEYear;
		private int depID;
		private decimal pWESubTotal;
		private decimal pWEBasWage;
		private decimal pWEAlloSub;
		private decimal pWEPrize;
		private decimal pWEPerWage;
		private decimal pWESafePay;
		private decimal pWEOth;

		
		public BG_PayWelExpen() { }
		
		
		public int PWEID
		{
			get { return this.pWEID; }
			set { this.pWEID = value; }
		}
		
        
		
		
		
		public int PWEYear
		{
			get { return this.pWEYear; }
			set { this.pWEYear = value; }
		}		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public decimal PWESubTotal
		{
			get { return this.pWESubTotal; }
			set { this.pWESubTotal = value; }
		}		
		
		
		public decimal PWEBasWage
		{
			get { return this.pWEBasWage; }
			set { this.pWEBasWage = value; }
		}		
		
		
		public decimal PWEAlloSub
		{
			get { return this.pWEAlloSub; }
			set { this.pWEAlloSub = value; }
		}		
		
		
		public decimal PWEPrize
		{
			get { return this.pWEPrize; }
			set { this.pWEPrize = value; }
		}		
		
		
		public decimal PWEPerWage
		{
			get { return this.pWEPerWage; }
			set { this.pWEPerWage = value; }
		}		
		
		
		public decimal PWESafePay
		{
			get { return this.pWESafePay; }
			set { this.pWESafePay = value; }
		}		
		
		
		public decimal PWEOth
		{
			get { return this.pWEOth; }
			set { this.pWEOth = value; }
		}		
		
	}
}
