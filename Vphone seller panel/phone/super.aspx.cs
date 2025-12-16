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


public partial class super : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            call();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandArgument.ToString().Length >= 9)
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
    public void call()
    {
        con.Open();
        string s = "select * from vseller order by dat desc ";
        MySqlCommand cmd = new MySqlCommand(s, con);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label chk1 = (Label)e.Row.FindControl("Label6");
            Label chk2 = (Label)e.Row.FindControl("Label7");
            Label chk3 = (Label)e.Row.FindControl("Label8");
            //Label chk4 = (Label)e.Row.FindControl("Label9");
            if (!string.IsNullOrEmpty(chk1.Text) ) 
            {
                
                if (chk1.Text == "NA") 
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Green;
                }
                
            }
            if (!string.IsNullOrEmpty(chk2.Text))
            {
                
                if (chk2.Text == "Completed")
                {
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                }
            }
            if (!string.IsNullOrEmpty(chk3.Text))
            {
                if (chk3.Text == "Done")
                {
                    e.Row.Cells[10].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
                }
            }
            //if (string.IsNullOrEmpty(chk1.Text)) 
            //{
            //        e.Row.Cells[5].Text = "Pending";
             
            //}
            //if (string.IsNullOrEmpty(chk2.Text))
            //{
            //    e.Row.Cells[6].Text = "Pending";

            //}
            //if (string.IsNullOrEmpty(chk3.Text))
            //{
            //    e.Row.Cells[7].Text = "Pending";

            //}

            //if (!string.IsNullOrEmpty(chk4.Text))
            //{
            //    if (chk4.Text == "Not Approved")
            //    {
            //        e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
            //    }
            //    else
            //    {
            //        e.Row.Cells[8].ForeColor = System.Drawing.Color.Green;
            //    }
            //}

          
        }
       
    }
    public void call11()
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'support1.aspx', null, 'height=900,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("super2.aspx");
    }
}