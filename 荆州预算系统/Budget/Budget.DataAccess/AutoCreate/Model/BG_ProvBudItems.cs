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
	public class BG_ProvBudItems
	{
	
		private int pBID; 
		private string pBType = String.Empty;
		private decimal pBMon;
		private int pBYear;
		private int depID;

		
		public BG_ProvBudItems() { }
		
		
		public int PBID
		{
			get { return this.pBID; }
			set { this.pBID = value; }
		}
		
        
		
		
		
		public string PBType
		{
			get { return this.pBType; }
			set { this.pBType = value; }
		}		
		
		
		public decimal PBMon
		{
			get { return this.pBMon; }
			set { this.pBMon = value; }
		}		
		
		
		public int PBYear
		{
			get { return this.pBYear; }
			set { this.pBYear = value; }
		}		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
	}
}
