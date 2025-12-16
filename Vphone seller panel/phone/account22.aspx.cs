using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class account22 : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            callold();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("account.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("account22.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Session["open"] = e.CommandArgument;
        try
        {
            if (e.CommandArgument.ToString().Length > 9)
            {
                Session["open"] = e.CommandArgument;
                call11();
            }

        }
        catch (Exception)
        {

        }
        finally
        {

        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        callold();
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {

    }
    public void call11()
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'account2.aspx', null, 'height=550,width=500,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
    }
    public void callold()
    {
        try
        {
            con.Open();
            string s = "SELECT * FROM vseller WHERE status1='Received' order by dat desc ";
            MySqlCommand cmd = new MySqlCommand(s, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }
        catch (Exception ex) 
        {
            Response.Write(ex);
        }
    }
}