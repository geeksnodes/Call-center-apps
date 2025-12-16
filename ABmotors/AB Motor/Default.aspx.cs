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
        string i = dobj.login_check(txtid.Text, txtpass.Text).ToString();
        if (i != "")
        {
            Session["user_id"] = txtid.Text;
            Session["role"] = i.ToUpper();
            if (Session["role"].ToString() == "SALE")
                Response.Redirect("dashboard_sale.aspx");
            if (Session["role"].ToString() == "SERVICE")
                Response.Redirect("dashboard_service.aspx");
            if (Session["role"].ToString() == "ADMIN")
                Response.Redirect("dashboard_admin_sale.aspx");
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Invalid ID or Password.";
        }
    }
}