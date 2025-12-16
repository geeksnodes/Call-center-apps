using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    DAL1 dboj = new DAL1();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                var i = dboj.login(TextBox1.Text, TextBox2.Text);
                if (i == 0)
                {
                    Response.Write("<script> alert('Please Enter Valid Username or Password !')</script>");
                }
                if (i == 1)
                {
                    Session["uname"] = TextBox1.Text;
                    Response.Redirect("seller.aspx");
                }
                if (i == 2)
                {
                    Session["uname"] = TextBox1.Text;
                    Response.Redirect("accountmain.aspx");
                }
                if (i == 3)
                {
                    Session["uname"] = TextBox1.Text;
                    Response.Redirect("operate.aspx");
                }
                if (i == 4)
                {
                    Session["uname"] = TextBox1.Text;
                    Response.Redirect("Support.aspx");
                }
                if (i == 5)
                {
                    Session["uname"] = TextBox1.Text;
                    Response.Redirect("super.aspx");
                }
            }
            else
            {
                Response.Write("<script> alert('Please Enter Username or Password')</script>");
            }
        }
        catch (Exception ex) 
        {
            Response.Write("<script language='javascript'>alert('Error:- ' + '" +Server.HtmlEncode(ex.Message) + "')</script>"); 
            //Response.Write("<script>alert('Error :- ''" +Server.HtmlEncode( ex.Message) + "')</script>");
        }
    }
}