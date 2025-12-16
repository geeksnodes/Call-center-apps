<%@ WebHandler Language="C#" Class="call_log_details" %>

using System;
using System.Web;

public class call_log_details : IHttpHandler {
    DAL dobj=new DAL();
    public void ProcessRequest (HttpContext context) {

        try
        {
            if (context.Request.QueryString.Count >= 5 && context.Request.QueryString.Count <= 15)
            {
                //call_log_details.ashx?id=&date=&time=&called_number=&caller_number=&caller_status=&caller_duration=&call_forwarding_number=&call_connected_to=&call_transfer_status=&call_status=&key_pressed=&call_recording_url=&call_voicemailurl=
               // string id = context.Request.QueryString["id"].ToString();
                string date = context.Request.QueryString["date"].ToString();
                string time = context.Request.QueryString["time"].ToString();
                string called_number = context.Request.QueryString["called_number"].ToString();
                string caller_number = context.Request.QueryString["caller_number"].ToString();
                string caller_status = context.Request.QueryString["caller_status"].ToString();
                string caller_duration = context.Request.QueryString["caller_duration"].ToString();
                string call_forwarding_number = context.Request.QueryString["call_forwarding_number"].ToString();
                string call_connected = context.Request.QueryString["call_connected_to"].ToString();
                string call_transfer_status = context.Request.QueryString["call_transfer_status"].ToString();
                string call_status = context.Request.QueryString["call_status"].ToString();
               // string call_transfer_duration = context.Request.QueryString["call_transfer_duration"].ToString();
                string key_pressed = context.Request.QueryString["key_pressed"].ToString();
                string call_recordingurl = context.Request.QueryString["call_recording_url"].ToString();
                string call_uuid = context.Request.QueryString["call_voicemailurl"].ToString();
                if (called_number.Length > 10) 
                   called_number= called_number.Replace(" ", "+").ToString();
                if (caller_number.Length > 10)
                    caller_number = caller_number.Replace(" ", "+").ToString();
                if (call_forwarding_number.Length > 10)
                    call_forwarding_number = call_forwarding_number.Replace(" ", "+").ToString();
                
                dobj.call_log_details_view( date, time, called_number, caller_number, caller_status, caller_duration, call_forwarding_number, call_connected, call_transfer_status, call_status, key_pressed, call_recordingurl, call_uuid);
                context.Response.ContentType = "text/plain";
                context.Response.Write("Successfully Submitted!!!");
            }
            else 
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Invalid Parameters!!!");
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