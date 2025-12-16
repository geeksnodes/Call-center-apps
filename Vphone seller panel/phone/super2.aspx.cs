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

public partial class super2 : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            callnew();
            
        }

    }
    public void callnew()
    {
        try
        {
            con.Open();
            string s = "select * from temp_super Union select * from reject Union select * from vseller where super1='Approved' order by dat desc";
            MySqlCommand cmd = new MySqlCommand(s,con);
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
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Session["open"] = e.CommandArgument;
        try
        {
            if (e.CommandArgument.ToString().Length >10)
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
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        callnew();

    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {

    }
    public void call11()
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'super3.aspx', null, 'height=900,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("super.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label chk1 = (Label)e.Row.FindControl("Label9");
            if (!string.IsNullOrEmpty(chk1.Text))
            {
                if (chk1.Text == "Approved")
                {
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                }
            }
            //else
            //{
            //    e.Row.Cells[9].Text = "Pending";
            //    //e.Row.Cells[10].Text= "<blink>" + System.Drawing.Color.Red + "</blink>";
            //    e.Row.Cells[9].BackColor = System.Drawing.Color.White;
            //}
        }
}}