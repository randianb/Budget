//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2015/3/4 16:05:09
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetWeb.Model
{
	
	[Serializable()]
	public class BG_User
	{
	
		private int userID; 
		private string userName = String.Empty;
		private string userNum = String.Empty;
		private string userIDNum = String.Empty;
		private string userPwd = String.Empty;
		private string userLim = String.Empty;
		private int userSta;
		private int depID;
		private string userRem = String.Empty;
		private int isVIP;
		private string userDescription = String.Empty;
		private int isLogin;
		private string applyRem = String.Empty;

		
		public BG_User() { }
		
		
		public int UserID
		{
			get { return this.userID; }
			set { this.userID = value; }
		}
		
        
		
		
		
		public string UserName
		{
			get { return this.userName; }
			set { this.userName = value; }
		}		
		
		
		public string UserNum
		{
			get { return this.userNum; }
			set { this.userNum = value; }
		}		
		
		
		public string UserIDNum
		{
			get { return this.userIDNum; }
			set { this.userIDNum = value; }
		}		
		
		
		public string UserPwd
		{
			get { return this.userPwd; }
			set { this.userPwd = value; }
		}		
		
		
		public string UserLim
		{
			get { return this.userLim; }
			set { this.userLim = value; }
		}		
		
		
		public int UserSta
		{
			get { return this.userSta; }
			set { this.userSta = value; }
		}		
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}		
		
		
		public string UserRem
		{
			get { return this.userRem; }
			set { this.userRem = value; }
		}		
		
		
		public int IsVIP
		{
			get { return this.isVIP; }
			set { this.isVIP = value; }
		}		
		
		
		public string UserDescription
		{
			get { return this.userDescription; }
			set { this.userDescription = value; }
		}		
		
		
		public int IsLogin
		{
			get { return this.isLogin; }
			set { this.isLogin = value; }
		}		
		
		
		public string ApplyRem
		{
			get { return this.applyRem; }
			set { this.applyRem = value; }
		}		
		
	}
}
