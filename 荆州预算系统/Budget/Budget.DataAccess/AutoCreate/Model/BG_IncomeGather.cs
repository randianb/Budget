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
	public class BG_IncomeGather
	{
	
		private int iGID; 
		private int depID;
		private decimal icoMon;
		private string icoType = String.Empty;
		private int icoYear;

		
		public BG_IncomeGather() { }
		
		
		public int IGID
		{
			get { return this.iGID; }
			set { this.iGID = value; }
		}
		
        
		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public decimal IcoMon
		{
			get { return this.icoMon; }
			set { this.icoMon = value; }
		}		
		
		
		public string IcoType
		{
			get { return this.icoType; }
			set { this.icoType = value; }
		}		
		
		
		public int IcoYear
		{
			get { return this.icoYear; }
			set { this.icoYear = value; }
		}		
		
	}
}
