<%@ WebHandler Language="C#" Class="squareKart" %>

using System;
using System.Web;

public class squareKart : IHttpHandler {

    DAL dobj = new DAL();
    public void ProcessRequest(HttpContext context)
    {
        try
        {
            if (context.Request.QueryString.Count == 3 && context.Request.QueryString["mob"].ToString() != null && context.Request.QueryString["agentid"] != null && context.Request.QueryString["call_id"] != null)
            {
                int i = Convert.ToInt32(dobj.square_ashx_read(context.Request.QueryString["agentid"].ToString()));
                string number = context.Request.QueryString["mob"].ToString();
                if (context.Request.QueryString["mob"].ToString().Length > 10)
                {
                    number = context.Request.QueryString["mob"].ToString().Substring(context.Request.QueryString["mob"].ToString().Length - 10);
                }
                if (i == 0)
                {
                    dobj.square_ashx_page(context.Request.QueryString["agentid"].ToString(), number.ToString(), context.Request.QueryString["call_id"].ToString());
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Call submitted successfully");
                }
                else 
                {
                    dobj.square_ashx_notresponse(context.Request.QueryString["agentid"].ToString());
                    dobj.square_ashx_page(context.Request.QueryString["agentid"].ToString(), number.ToString(), context.Request.QueryString["call_id"].ToString());
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Call submitted successfully");
                }
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Invalid Parameters");

            }
        }
        catch (Exception) 
        {
            context.Response.Write("something went wrong");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}