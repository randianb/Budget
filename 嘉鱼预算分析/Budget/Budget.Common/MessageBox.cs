using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;

namespace Common
{
    /// <summary>
    ///MessageBox 的摘要说明
    /// </summary>
    public class MessageBox
    {
        // Methods
        private MessageBox()
        {
        }

        public static void alert(string msg)
        {
            HttpContext.Current.Response.Write("<script>alert('" + msg + "');window.location.href=window.location.href;</script>");
        }

        public static void alert(string msg, string url)
        {
            HttpContext.Current.Response.Write("<script>alert('" + msg + "');window.location.href='" + url + "'</script>");
        }

        public static void alertTop(string msg, string url)
        {
            HttpContext.Current.Response.Write("<script>alert('" + msg + "');window.top.location.href='" + url + "'</script>");
        }

        public static void ResponseScript(Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }

        public static void Show(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        public static void ShowAndRedirect(Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg + "');window.location=\"" + url + "\"</script>");
        }

        public static void ShowAndRedirects(Page page, string msg, string url)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<script language='javascript' defer>");
            builder.AppendFormat("alert('{0}');", msg);
            builder.AppendFormat("top.location.href='{0}'", url);
            builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", builder.ToString());
        }

        public static void ShowConfirm(WebControl Control, string msg)
        {
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        public static void ShowRedirectParent(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

    }
}