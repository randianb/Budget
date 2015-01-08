<%@ WebHandler Language="C#" Class="SessionAJAX" %>

using System;
using System.Web;
using System.Web.SessionState;

public class SessionAJAX : System.Web.IHttpHandler, System.Web.SessionState.IRequiresSessionState
{ 
    public void ProcessRequest (HttpContext context) {
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.ContentType = "text/plain";
        string str = "0";
        try
        {
            if (context.Session["NodeBC59"]!=null)
            {
                str = context.Session["NodeBC59"].ToString();
            }
        }
        catch (Exception)
        {

            str = "0";
        } 
        context.Response.Write(str);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}