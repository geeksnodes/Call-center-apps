using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DAL dobj = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int i = Convert.ToInt32(dobj.login_check(txtid.Text, txtpass.Text));
            if (i == 1)
            {
               
                Session["userid"] = txtid.Text;
                Session["role"] = "ADMIN";
                Response.Redirect("Dashboard.aspx");
            }
            else
                if (i == 2) 
                {
                        Session["userid"] = txtid.Text;
                        Session["role"] = "AGENT";
                        Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "*Invalid Id or Password";
                }
            }
            catch (Exception )
            {
                
                // Response.Write(ex);
            }
          
       
    }
}