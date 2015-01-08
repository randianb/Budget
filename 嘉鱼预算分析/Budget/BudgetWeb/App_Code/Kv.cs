using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// kv 的摘要说明
/// </summary>
public class Kv
{
    public Kv()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    private string key = string.Empty;
    /// <summary>
    /// 键
    /// </summary>
    public string Key
    {
        get { return key; }
        set { key = value; }
    }

    private string val = string.Empty;
    /// <summary>
    /// 值
    /// </summary>
    public string Val
    {
        get { return val; }
        set { val = value; }
    }
}