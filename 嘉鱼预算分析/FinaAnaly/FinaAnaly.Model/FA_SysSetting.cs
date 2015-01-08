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
	public class FA_SysSetting
	{
	
		private int sSID; 
		private string unitName = String.Empty;
		private string unitCode = String.Empty;
		private int sSYear;
		private int staffNum;

		
		public FA_SysSetting() { }
		
		
		public int SSID
		{
			get { return this.sSID; }
			set { this.sSID = value; }
		}
		
        
		
		
		
		public string UnitName
		{
			get { return this.unitName; }
			set { this.unitName = value; }
		}		
		
		
		public string UnitCode
		{
			get { return this.unitCode; }
			set { this.unitCode = value; }
		}		
		
		
		public int SSYear
		{
			get { return this.sSYear; }
			set { this.sSYear = value; }
		}		
		
		
		public int StaffNum
		{
			get { return this.staffNum; }
			set { this.staffNum = value; }
		}		
		
	}
}
