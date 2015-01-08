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
	public class BG_ChangePwd
	{
	
		private int pwdID; 
		private int userID;
		private string oldPwd = String.Empty;
		private string newPwd = String.Empty;
		private DateTime crTime;
		private string userName = String.Empty;
		private string depName = String.Empty;

		
		public BG_ChangePwd() { }
		
		
		public int PwdID
		{
			get { return this.pwdID; }
			set { this.pwdID = value; }
		}
		
        
		
		
		
		public int UserID
		{
			get { return this.userID; }
			set { this.userID = value; }
		}		
		
		
		public string OldPwd
		{
			get { return this.oldPwd; }
			set { this.oldPwd = value; }
		}		
		
		
		public string NewPwd
		{
			get { return this.newPwd; }
			set { this.newPwd = value; }
		}		
		
		
		public DateTime CrTime
		{
			get { return this.crTime; }
			set { this.crTime = value; }
		}		
		
		
		public string UserName
		{
			get { return this.userName; }
			set { this.userName = value; }
		}		
		
		
		public string DepName
		{
			get { return this.depName; }
			set { this.depName = value; }
		}		
		
	}
}
