<%@ WebHandler Language="C#" Class="celtium" %>

using System;
using System.Web;
using MySql.Data.MySqlClient;

public class celtium : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        try
        {
            if (context.Request.QueryString.Count == 3)
            {
                if (context.Request.QueryString["agentid"] == null || context.Request.QueryString["cli"] == null || context.Request.QueryString["uniqueid"] == null)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Invalid Parameters Given");
                }
                else
                {
                    string agentID = context.Request.QueryString["agentid"];
                    string cli = context.Request.QueryString["cli"];
                    string uid = context.Request.QueryString["uniqueid"];
           


                    string checkres = checkData(agentID, cli, uid);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(checkres);
                }

            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Invalid Parameters Given");
            }
        }
        catch {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Error Submiting Call");
        }
        
    }
    public string checkData(string agentid, string cli, string uid)
    {
        string result = "";
        try
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["mysqlcon"].ConnectionString;
             using (MySqlConnection con = new MySqlConnection(constr))
             {
                 using (MySqlCommand cmd = new MySqlCommand())
                 {
                     cmd.Connection = con;
                     cmd.CommandText = "insert into newcall(agentid,cli,trndate,call_id,status) values('"+agentid +"','"+cli+"',now(),'"+uid+"','NEW')";
                     con.Open();
                     cmd.ExecuteNonQuery();
                     result = "Call submitted successfully";
                 }
             }
        }
        catch { result = "Error Submiting Call"; }
        return result;
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}