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
	public class BG_PayWelSupply
	{
	
		private int gSEID; 
		private int gSEYear;
		private int depID;
		private decimal gSETotal;
		private decimal offSubTot;
		private decimal offPerPart;
		private decimal offPubPart;
		private decimal ebbSubTot;
		private decimal ebbPerPart;
		private decimal ebbPubPart;
		private decimal gSEHouPro;
		private decimal gSEMedChar;
		private decimal lifeAllo;
		private decimal gSEOther;

		
		public BG_PayWelSupply() { }
		
		
		public int GSEID
		{
			get { return this.gSEID; }
			set { this.gSEID = value; }
		}
		
        
		
		
		
		public int GSEYear
		{
			get { return this.gSEYear; }
			set { this.gSEYear = value; }
		}		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public decimal GSETotal
		{
			get { return this.gSETotal; }
			set { this.gSETotal = value; }
		}		
		
		
		public decimal OffSubTot
		{
			get { return this.offSubTot; }
			set { this.offSubTot = value; }
		}		
		
		
		public decimal OffPerPart
		{
			get { return this.offPerPart; }
			set { this.offPerPart = value; }
		}		
		
		
		public decimal OffPubPart
		{
			get { return this.offPubPart; }
			set { this.offPubPart = value; }
		}		
		
		
		public decimal EbbSubTot
		{
			get { return this.ebbSubTot; }
			set { this.ebbSubTot = value; }
		}		
		
		
		public decimal EbbPerPart
		{
			get { return this.ebbPerPart; }
			set { this.ebbPerPart = value; }
		}		
		
		
		public decimal EbbPubPart
		{
			get { return this.ebbPubPart; }
			set { this.ebbPubPart = value; }
		}		
		
		
		public decimal GSEHouPro
		{
			get { return this.gSEHouPro; }
			set { this.gSEHouPro = value; }
		}		
		
		
		public decimal GSEMedChar
		{
			get { return this.gSEMedChar; }
			set { this.gSEMedChar = value; }
		}		
		
		
		public decimal LifeAllo
		{
			get { return this.lifeAllo; }
			set { this.lifeAllo = value; }
		}		
		
		
		public decimal GSEOther
		{
			get { return this.gSEOther; }
			set { this.gSEOther = value; }
		}		
		
	}
}
