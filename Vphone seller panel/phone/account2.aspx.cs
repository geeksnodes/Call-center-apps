using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class account2 : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        call();
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
            Label18.Text = ds.Tables[0].Rows[0]["status1"].ToString();
            con.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('error ''" + ex + "')</script>");
        }
        finally 
        {
            Session["open"] = null;
        }
    }

}