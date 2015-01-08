//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:01
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_ReimDocuments
	{
	
		private int rDID; 
		private int aRID;
		private string rDType = String.Empty;
		private string rDCont = String.Empty;
		private DateTime rDTime;

		
		public BG_ReimDocuments() { }
		
		
		public int RDID
		{
			get { return this.rDID; }
			set { this.rDID = value; }
		}
		
        
		
		
		
		public int ARID
		{
			get { return this.aRID; }
			set { this.aRID = value; }
		}		
		
		
		public string RDType
		{
			get { return this.rDType; }
			set { this.rDType = value; }
		}		
		
		
		public string RDCont
		{
			get { return this.rDCont; }
			set { this.rDCont = value; }
		}		
		
		
		public DateTime RDTime
		{
			get { return this.rDTime; }
			set { this.rDTime = value; }
		}		
		
	}
}
