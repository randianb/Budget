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
	public class BG_OutLayGather
	{
	
		private int oGID; 
		private int depID;
		private decimal otlMon;
		private string otlType = String.Empty;
		private int otlYear;

		
		public BG_OutLayGather() { }
		
		
		public int OGID
		{
			get { return this.oGID; }
			set { this.oGID = value; }
		}
		
        
		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public decimal OtlMon
		{
			get { return this.otlMon; }
			set { this.otlMon = value; }
		}		
		
		
		public string OtlType
		{
			get { return this.otlType; }
			set { this.otlType = value; }
		}		
		
		
		public int OtlYear
		{
			get { return this.otlYear; }
			set { this.otlYear = value; }
		}		
		
	}
}
