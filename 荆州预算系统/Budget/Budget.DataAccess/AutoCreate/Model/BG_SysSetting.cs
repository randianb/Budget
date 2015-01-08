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
	public class BG_SysSetting
	{
	
		private int sSID; 
		private string sysName = String.Empty;
		private int defaultYear;
		private int pepNum;

		
		public BG_SysSetting() { }
		
		
		public int SSID
		{
			get { return this.sSID; }
			set { this.sSID = value; }
		}
		
        
		
		
		
		public string SysName
		{
			get { return this.sysName; }
			set { this.sysName = value; }
		}		
		
		
		public int DefaultYear
		{
			get { return this.defaultYear; }
			set { this.defaultYear = value; }
		}		
		
		
		public int PepNum
		{
			get { return this.pepNum; }
			set { this.pepNum = value; }
		}		
		
	}
}
