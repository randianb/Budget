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
	public class BG_BudgetAllocationHis
	{
	
		private int bAAHisID; 
		private int bAAID;
		private int depID;
		private int pIID;
		private decimal addBAAMon;
		private decimal addSuppMon;
		private string userOp = String.Empty;
		private DateTime crtime;
		private decimal oldBAAMon;
		private decimal oldSuppMon;
		private decimal newBAAMon;
		private decimal newSuppMon;
		private string depName = String.Empty;

		
		public BG_BudgetAllocationHis() { }
		
		
		public int BAAHisID
		{
			get { return this.bAAHisID; }
			set { this.bAAHisID = value; }
		}
		
        
		
		
		
		public int BAAID
		{
			get { return this.bAAID; }
			set { this.bAAID = value; }
		}		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public int PIID
		{
			get { return this.pIID; }
			set { this.pIID = value; }
		}		
		
		
		public decimal AddBAAMon
		{
			get { return this.addBAAMon; }
			set { this.addBAAMon = value; }
		}		
		
		
		public decimal AddSuppMon
		{
			get { return this.addSuppMon; }
			set { this.addSuppMon = value; }
		}		
		
		
		public string UserOp
		{
			get { return this.userOp; }
			set { this.userOp = value; }
		}		
		
		
		public DateTime Crtime
		{
			get { return this.crtime; }
			set { this.crtime = value; }
		}		
		
		
		public decimal OldBAAMon
		{
			get { return this.oldBAAMon; }
			set { this.oldBAAMon = value; }
		}		
		
		
		public decimal OldSuppMon
		{
			get { return this.oldSuppMon; }
			set { this.oldSuppMon = value; }
		}		
		
		
		public decimal NewBAAMon
		{
			get { return this.newBAAMon; }
			set { this.newBAAMon = value; }
		}		
		
		
		public decimal NewSuppMon
		{
			get { return this.newSuppMon; }
			set { this.newSuppMon = value; }
		}		
		
		
		public string DepName
		{
			get { return this.depName; }
			set { this.depName = value; }
		}		
		
	}
}
