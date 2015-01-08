//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-4 10:04:30
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace FinaAnaly.Model
{
	
	[Serializable()]
	public class FA_OutLayGather
	{
	
		private int oGID; 
		private int depID;
		private decimal otlMon;
		private string otlType = String.Empty;
		private int otlYear;

		
		public FA_OutLayGather() { }
		
		
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
