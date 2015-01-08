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
	public class BG_OutlayAna
	{
	
		private int oAID; 
		private int pIID;
		private int pPID;
		private int depID;
		private decimal oABudMon;
		private decimal oAAudMon;
		private decimal oACkMon;
		private string oAType = String.Empty;
		private int oAYear;
		private string mark = String.Empty;

		
		public BG_OutlayAna() { }
		
		
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
		
		
		public decimal OABudMon
		{
			get { return this.oABudMon; }
			set { this.oABudMon = value; }
		}		
		
		
		public decimal OAAudMon
		{
			get { return this.oAAudMon; }
			set { this.oAAudMon = value; }
		}		
		
		
		public decimal OACkMon
		{
			get { return this.oACkMon; }
			set { this.oACkMon = value; }
		}		
		
		
		public string OAType
		{
			get { return this.oAType; }
			set { this.oAType = value; }
		}		
		
		
		public int OAYear
		{
			get { return this.oAYear; }
			set { this.oAYear = value; }
		}		
		
		
		public string Mark
		{
			get { return this.mark; }
			set { this.mark = value; }
		}		
		
	}
}
