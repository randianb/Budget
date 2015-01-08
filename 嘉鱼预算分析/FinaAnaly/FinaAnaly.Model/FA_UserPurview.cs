//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace FinaAnaly.Model
{
	
	[Serializable()]
	public class FA_UserPurview
	{
	
		private int uPID; 
		private string uPName = String.Empty;
		private string remark = String.Empty;

		
		public FA_UserPurview() { }
		
		
		public int UPID
		{
			get { return this.uPID; }
			set { this.uPID = value; }
		}
		
        
		
		
		
		public string UPName
		{
			get { return this.uPName; }
			set { this.uPName = value; }
		}		
		
		
		public string Remark
		{
			get { return this.remark; }
			set { this.remark = value; }
		}		
		
	}
}
