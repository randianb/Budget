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
	public class BG_ProBasiPerPayTwo
	{
	
		private int pTID; 
		private int depID;
		private DateTime pTYear;
		private decimal retiredPerP;
		private decimal retiredPubP;
		private decimal retirementPerP;
		private decimal retirementPubP;
		private decimal pTHF;
		private decimal pTME;
		private decimal pTOther;
		private decimal pTTitol;

		
		public BG_ProBasiPerPayTwo() { }
		
		
		public int PTID
		{
			get { return this.pTID; }
			set { this.pTID = value; }
		}
		
        
		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public DateTime PTYear
		{
			get { return this.pTYear; }
			set { this.pTYear = value; }
		}		
		
		
		public decimal RetiredPerP
		{
			get { return this.retiredPerP; }
			set { this.retiredPerP = value; }
		}		
		
		
		public decimal RetiredPubP
		{
			get { return this.retiredPubP; }
			set { this.retiredPubP = value; }
		}		
		
		
		public decimal RetirementPerP
		{
			get { return this.retirementPerP; }
			set { this.retirementPerP = value; }
		}		
		
		
		public decimal RetirementPubP
		{
			get { return this.retirementPubP; }
			set { this.retirementPubP = value; }
		}		
		
		
		public decimal PTHF
		{
			get { return this.pTHF; }
			set { this.pTHF = value; }
		}		
		
		
		public decimal PTME
		{
			get { return this.pTME; }
			set { this.pTME = value; }
		}		
		
		
		public decimal PTOther
		{
			get { return this.pTOther; }
			set { this.pTOther = value; }
		}		
		
		
		public decimal PTTitol
		{
			get { return this.pTTitol; }
			set { this.pTTitol = value; }
		}		
		
	}
}
