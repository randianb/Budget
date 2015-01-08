//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:00
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_Policy
	{
	
		private int pLID; 
		private string pTitle = String.Empty;
		private string pContent = String.Empty;
		private DateTime pTime;
		private string pFrom = String.Empty;
		private int pOrder;
		private string pType = String.Empty;
		private string pStatus = String.Empty;

		
		public BG_Policy() { }
		
		
		public int PLID
		{
			get { return this.pLID; }
			set { this.pLID = value; }
		}
		
        
		
		
		
		public string PTitle
		{
			get { return this.pTitle; }
			set { this.pTitle = value; }
		}		
		
		
		public string PContent
		{
			get { return this.pContent; }
			set { this.pContent = value; }
		}		
		
		
		public DateTime PTime
		{
			get { return this.pTime; }
			set { this.pTime = value; }
		}		
		
		
		public string PFrom
		{
			get { return this.pFrom; }
			set { this.pFrom = value; }
		}		
		
		
		public int POrder
		{
			get { return this.pOrder; }
			set { this.pOrder = value; }
		}		
		
		
		public string PType
		{
			get { return this.pType; }
			set { this.pType = value; }
		}		
		
		
		public string PStatus
		{
			get { return this.pStatus; }
			set { this.pStatus = value; }
		}		
		
	}
}
