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
	public class BG_MonPayPlanRemark
	{
	
		private int pRID; 
		private int deptID;
		private DateTime mATime;
		private string mASta = String.Empty;
		private string mACause = String.Empty;
		private string mAUser = String.Empty;
		private int mATimes;

		
		public BG_MonPayPlanRemark() { }
		
		
		public int PRID
		{
			get { return this.pRID; }
			set { this.pRID = value; }
		}
		
        
		
		
		
		public int DeptID
		{
			get { return this.deptID; }
			set { this.deptID = value; }
		}		
		
		
		public DateTime MATime
		{
			get { return this.mATime; }
			set { this.mATime = value; }
		}		
		
		
		public string MASta
		{
			get { return this.mASta; }
			set { this.mASta = value; }
		}		
		
		
		public string MACause
		{
			get { return this.mACause; }
			set { this.mACause = value; }
		}		
		
		
		public string MAUser
		{
			get { return this.mAUser; }
			set { this.mAUser = value; }
		}		
		
		
		public int MATimes
		{
			get { return this.mATimes; }
			set { this.mATimes = value; }
		}		
		
	}
}
