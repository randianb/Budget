//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:02
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace FinaAnaly.Model
{
	
	[Serializable()]
	public class FA_FundsAccountUDetail
	{
	
		private int fAUDID; 
		private string dEPARTMENT = String.Empty;
		private decimal eD;
		private decimal tZ;
		private decimal qZXJ;
		private decimal xJJH;
		private decimal xJKYED;
		private decimal kYYE;
		private decimal zEDB;
		private string bZ = String.Empty;

		
		public FA_FundsAccountUDetail() { }
		
		
		public int FAUDID
		{
			get { return this.fAUDID; }
			set { this.fAUDID = value; }
		}
		
        
		
		
		
		public string DEPARTMENT
		{
			get { return this.dEPARTMENT; }
			set { this.dEPARTMENT = value; }
		}		
		
		
		public decimal ED
		{
			get { return this.eD; }
			set { this.eD = value; }
		}		
		
		
		public decimal TZ
		{
			get { return this.tZ; }
			set { this.tZ = value; }
		}		
		
		
		public decimal QZXJ
		{
			get { return this.qZXJ; }
			set { this.qZXJ = value; }
		}		
		
		
		public decimal XJJH
		{
			get { return this.xJJH; }
			set { this.xJJH = value; }
		}		
		
		
		public decimal XJKYED
		{
			get { return this.xJKYED; }
			set { this.xJKYED = value; }
		}		
		
		
		public decimal KYYE
		{
			get { return this.kYYE; }
			set { this.kYYE = value; }
		}		
		
		
		public decimal ZEDB
		{
			get { return this.zEDB; }
			set { this.zEDB = value; }
		}		
		
		
		public string BZ
		{
			get { return this.bZ; }
			set { this.bZ = value; }
		}		
		
	}
}
