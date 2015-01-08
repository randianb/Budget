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
	public class BG_Department
	{
	
		private int depID; 
		private int depLev;
		private int faDepID;
		private string depCode = String.Empty;
		private string depName = String.Empty;
		private string depQua = String.Empty;
		private string depSta = String.Empty;
		private string depRem = String.Empty;

		
		public BG_Department() { }
		
		
		public int DepID
		{
			get { return this.depID; }
			set { this.depID = value; }
		}
		
        
		
		
		
		public int DepLev
		{
			get { return this.depLev; }
			set { this.depLev = value; }
		}		
		
		
		public int FaDepID
		{
			get { return this.faDepID; }
			set { this.faDepID = value; }
		}		
		
		
		public string DepCode
		{
			get { return this.depCode; }
			set { this.depCode = value; }
		}		
		
		
		public string DepName
		{
			get { return this.depName; }
			set { this.depName = value; }
		}		
		
		
		public string DepQua
		{
			get { return this.depQua; }
			set { this.depQua = value; }
		}		
		
		
		public string DepSta
		{
			get { return this.depSta; }
			set { this.depSta = value; }
		}		
		
		
		public string DepRem
		{
			get { return this.depRem; }
			set { this.depRem = value; }
		}		
		
	}
}
