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
	public class BG_EcoIncome
	{
	
		private int eIID; 
		private string eICoding = String.Empty;
		private string eILev = String.Empty;
		private int eIParID;
		private string eIName = String.Empty;

		
		public BG_EcoIncome() { }
		
		
		public int EIID
		{
			get { return this.eIID; }
			set { this.eIID = value; }
		}
		
        
		
		
		
		public string EICoding
		{
			get { return this.eICoding; }
			set { this.eICoding = value; }
		}		
		
		
		public string EILev
		{
			get { return this.eILev; }
			set { this.eILev = value; }
		}		
		
		
		public int EIParID
		{
			get { return this.eIParID; }
			set { this.eIParID = value; }
		}		
		
		
		public string EIName
		{
			get { return this.eIName; }
			set { this.eIName = value; }
		}		
		
	}
}
