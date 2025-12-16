using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class account1 : System.Web.UI.Page
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
            string s = "select * from vseller where ticket='" + Session["open"].ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(s, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Label2.Text = ds.Tables[0].Rows[0]["ticket"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["did"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["name1"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["type1"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["choose_plan"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["amount"].ToString();
            Label14.Text = ds.Tables[0].Rows[0]["period"].ToString();
            Label16.Text = ds.Tables[0].Rows[0]["payment"].ToString();
            con.Close();
        }
        catch (Exception ex) 
        {
            Response.Write(ex);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        call2();
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "onAddNew", "window.close();", true);
        //Response.Redirect("account.aspx");
    }
    public void call2()
    {
        try
        {
            con.Open();
            string s = "update vseller set status1='" + DropDownList1.SelectedItem.Text + "', accountant_name='" + Session["uname"].ToString() + "' where ticket='" + Session["open"].ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Response.Write("<script> alert(' Error :- ''" + ex + "');</script>");
        }
        finally
        {
            Session["open"] = null;
            con.Close();
        }
    }
}