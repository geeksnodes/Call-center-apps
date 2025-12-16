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

public partial class operate : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            call();
        }
    }
    public void call()
    {
        try
        {
            con.Open();
            string s = "SELECT * FROM vseller WHERE status1='Received' AND (test<>'Done' OR test IS NULL) ORDER BY dat DESC; ";//SELECT * FROM vseller WHERE status1 IS NOT NULL AND test IS NULL ORDER BY dat DESC  SELECT * FROM vseller WHERE status1='Received' AND test IS NULL ORDER BY dat DESC 
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
 
   
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandArgument.ToString().Length > 10)
           {
                Session["open"] = e.CommandArgument;
                call11();
            }
        }
        catch (Exception ex) 
        {
            Response.Write("<script>alert('error ''" + ex + "')</script>");
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        call();

    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {

    }
    public void call11() 
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'operate1.aspx', null, 'height=700,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("operate.aspx");
    }
}