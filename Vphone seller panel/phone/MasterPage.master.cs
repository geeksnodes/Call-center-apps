using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            call();
        }
        catch (Exception)
        {
            HttpContext.Current.Session["uname"] = null;
            HttpContext.Current.Session.Abandon();
            Response.Redirect("login.aspx");
           
        }
      
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Session["uname"] != "") 
        {
            HttpContext.Current.Session["uname"] = null;
            HttpContext.Current.Session.Abandon();
            Response.Redirect("login.aspx");
        }

    }
    public void call() 
    {
        if (Session["uname"] != "")
        {
            Label1.Text = "Welcome " + Session["uname"].ToString();
            LinkButton1.Text = "Logout";
        }
        else 
        {
            LinkButton1.Visible = false;
            Label1.Text = "";
        }
    }
}
