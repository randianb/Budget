//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace FinaAnaly.Model
{
	
	[Serializable()]
	public class FA_WarningQuota
	{
	
		private int wQID; 
		private string yellowWarning = String.Empty;
		private string redWarning = String.Empty;
		private int wQYear;

		
		public FA_WarningQuota() { }
		
		
		public int WQID
		{
			get { return this.wQID; }
			set { this.wQID = value; }
		}
		
        
		
		
		
		public string YellowWarning
		{
			get { return this.yellowWarning; }
			set { this.yellowWarning = value; }
		}		
		
		
		public string RedWarning
		{
			get { return this.redWarning; }
			set { this.redWarning = value; }
		}		
		
		
		public int WQYear
		{
			get { return this.wQYear; }
			set { this.wQYear = value; }
		}		
		
	}
}
