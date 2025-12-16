using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage2 : System.Web.UI.MasterPage
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
    public void call()
    {
        if (Session["uname"] != "")
        {
            Label1.Text = "Welcome " + Session["uname"].ToString();
           
        }
        else
        {
           
            Label1.Text = "";
        }
    }
}
