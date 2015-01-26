//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2015/1/22 11:04:06
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_ApplyReimbur
	{
	
		private int aRID; 
		private int depID;
		private DateTime aRTime;
		private string aRReiSinNum = String.Empty;
		private int pPID;
		private string aRExpType = String.Empty;
		private string aRRepDep = String.Empty;
		private string aRAgent = String.Empty;
		private decimal aRMon;
		private string aRExcu = String.Empty;
		private string aRListSta = String.Empty;
		private string aRReason = String.Empty;

		
		public BG_ApplyReimbur() { }
		
		
		public int ARID
		{
			get { return this.aRID; }
			set { this.aRID = value; }
		}
		
        
		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public DateTime ARTime
		{
			get { return this.aRTime; }
			set { this.aRTime = value; }
		}		
		
		
		public string ARReiSinNum
		{
			get { return this.aRReiSinNum; }
			set { this.aRReiSinNum = value; }
		}		
		
		
		public int PPID
		{
			get { return this.pPID; }
			set { this.pPID = value; }
		}		
		
		
		public string ARExpType
		{
			get { return this.aRExpType; }
			set { this.aRExpType = value; }
		}		
		
		
		public string ARRepDep
		{
			get { return this.aRRepDep; }
			set { this.aRRepDep = value; }
		}		
		
		
		public string ARAgent
		{
			get { return this.aRAgent; }
			set { this.aRAgent = value; }
		}		
		
		
		public decimal ARMon
		{
			get { return this.aRMon; }
			set { this.aRMon = value; }
		}		
		
		
		public string ARExcu
		{
			get { return this.aRExcu; }
			set { this.aRExcu = value; }
		}		
		
		
		public string ARListSta
		{
			get { return this.aRListSta; }
			set { this.aRListSta = value; }
		}		
		
		
		public string ARReason
		{
			get { return this.aRReason; }
			set { this.aRReason = value; }
		}		
		
	}
}
