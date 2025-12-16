<%@ WebHandler Language="C#" Class="bg_call" %>

using System;
using System.Web;

public class bg_call : IHttpHandler {

    DAL dobj = new DAL();
    public void ProcessRequest(HttpContext context)
    {
        try
        {
            if (context.Request.QueryString.Count == 4 && context.Request.QueryString["mob"].ToString() != null && context.Request.QueryString["agentid"] != null && context.Request.QueryString["ext"] != null && context.Request.QueryString["call_id"] != null)
            {
                string number = string.Empty;
                if (context.Request.QueryString["mob"].ToString().Length > 10) 
                {
                    number = context.Request.QueryString["mob"].ToString().Substring(context.Request.QueryString["mob"].ToString().Length - 10);
                }
                if (context.Request.QueryString["mob"].ToString().Length == 10)
                {
                  number = context.Request.QueryString["mob"].ToString();
                }
                //string number = context.Request.QueryString["mob"].ToString().Replace(" ", "+");
                if (context.Request.QueryString["ext"].ToString() == "1" || context.Request.QueryString["ext"].ToString() == "2")
                {
                    int i = Convert.ToInt32(dobj.bg_ashx_read(context.Request.QueryString["agentid"].ToString()));
                    if (i == 0)
                    {
                        //check for extension is correct or not
                        if (Convert.ToInt32(dobj.complaint_read_popup_chk(Convert.ToInt32(context.Request.QueryString["ext"]), context.Request.QueryString["agentid"].ToString())) == 1)
                        {
                            dobj.bg_ashx_page(context.Request.QueryString["agentid"].ToString(), number.ToString(), context.Request.QueryString["call_id"].ToString(), context.Request.QueryString["ext"].ToString());
                            context.Response.ContentType = "text/plain";
                            context.Response.Write("Call submitted successfully");
                        }
                        else
                            context.Response.Write("Invalid extention or details");
                    }
                    else
                    {
                        if (Convert.ToInt32(dobj.complaint_read_popup_chk(Convert.ToInt32(context.Request.QueryString["ext"]), context.Request.QueryString["agentid"].ToString())) == 1)
                        {
                            if (Convert.ToInt32(dobj.complaint_read_popup_chk(Convert.ToInt32(context.Request.QueryString["ext"]), context.Request.QueryString["agentid"].ToString())) == 1)
                            {
                                dobj.bg_ashx_notresponse(context.Request.QueryString["agentid"].ToString());
                                dobj.bg_ashx_page(context.Request.QueryString["agentid"].ToString(), number.ToString(), context.Request.QueryString["call_id"].ToString(), context.Request.QueryString["ext"].ToString());
                                context.Response.ContentType = "text/plain";
                                context.Response.Write("Call submitted successfully");
                            }
                            else
                                context.Response.Write("Invalid extention or details");
                  
                        }
                    }
                }
                else
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Invalid Parameters");

                }
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Invalid extention");

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