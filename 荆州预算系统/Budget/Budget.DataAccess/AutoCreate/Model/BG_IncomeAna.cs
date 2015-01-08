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
	public class BG_IncomeAna
	{
	
		private int iAID; 
		private string eIID = String.Empty;
		private string depID = String.Empty;
		private decimal iABudMon;
		private decimal iAAudMon;
		private decimal iACkMon;
		private int iAYear;

		
		public BG_IncomeAna() { }
		
		
		public int IAID
		{
			get { return this.iAID; }
			set { this.iAID = value; }
		}
		
        
		
		
		
		public string EIID
		{
			get { return this.eIID; }
			set { this.eIID = value; }
		}		
		
		
		public string DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public decimal IABudMon
		{
			get { return this.iABudMon; }
			set { this.iABudMon = value; }
		}		
		
		
		public decimal IAAudMon
		{
			get { return this.iAAudMon; }
			set { this.iAAudMon = value; }
		}		
		
		
		public decimal IACkMon
		{
			get { return this.iACkMon; }
			set { this.iACkMon = value; }
		}		
		
		
		public int IAYear
		{
			get { return this.iAYear; }
			set { this.iAYear = value; }
		}		
		
	}
}
