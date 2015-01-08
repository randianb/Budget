//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-22 10:36:36
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace FinaAnaly.Model
{
	
	[Serializable()]
	public class FA_FundsAccountJournal
	{
	
		private int fAUDID; 
		private DateTime bXRQ;
		private string bM = String.Empty;
		private string zFLX = String.Empty;
		private string zY = String.Empty;
		private decimal jE;
		private decimal fJZS;
		private string bZ = String.Empty;

		
		public FA_FundsAccountJournal() { }
		
		
		public int FAUDID
		{
			get { return this.fAUDID; }
			set { this.fAUDID = value; }
		}
		
        
		
		
		
		public DateTime BXRQ
		{
			get { return this.bXRQ; }
			set { this.bXRQ = value; }
		}		
		
		
		public string BM
		{
			get { return this.bM; }
			set { this.bM = value; }
		}		
		
		
		public string ZFLX
		{
			get { return this.zFLX; }
			set { this.zFLX = value; }
		}		
		
		
		public string ZY
		{
			get { return this.zY; }
			set { this.zY = value; }
		}		
		
		
		public decimal JE
		{
			get { return this.jE; }
			set { this.jE = value; }
		}		
		
		
		public decimal FJZS
		{
			get { return this.fJZS; }
			set { this.fJZS = value; }
		}		
		
		
		public string BZ
		{
			get { return this.bZ; }
			set { this.bZ = value; }
		}		
		
	}
}
