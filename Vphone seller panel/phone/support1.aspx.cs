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

public partial class support1 : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        call();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    public void call()
    {
        try
        {
            string id = Convert.ToString(Session["open"]);
            con.Open();
            string s = "select * from vseller where ticket='" + id + "'";
            MySqlCommand cmd = new MySqlCommand(s, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Label2.Text = ds.Tables[0].Rows[0]["ticket"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["name1"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["email"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["alternate_no"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["product"].ToString();
            Label14.Text = ds.Tables[0].Rows[0]["type1"].ToString();
            Label16.Text = ds.Tables[0].Rows[0]["choose_plan"].ToString();
            Label18.Text = ds.Tables[0].Rows[0]["city"].ToString();
            Label20.Text = ds.Tables[0].Rows[0]["state"].ToString();
            Label22.Text = ds.Tables[0].Rows[0]["profession"].ToString();
            Label24.Text = ds.Tables[0].Rows[0]["call_credit"].ToString();
            Label26.Text = ds.Tables[0].Rows[0]["period"].ToString();
            Label28.Text = ds.Tables[0].Rows[0]["mode1"].ToString();
            Label30.Text = ds.Tables[0].Rows[0]["con_call"].ToString();
            Label32.Text = ds.Tables[0].Rows[0]["message"].ToString();
            Label34.Text = ds.Tables[0].Rows[0]["recovery"].ToString();
            Label36.Text = ds.Tables[0].Rows[0]["payment"].ToString();
            Label38.Text = ds.Tables[0].Rows[0]["did"].ToString();
            Label43.Text = ds.Tables[0].Rows[0]["status1"].ToString();
            Label41.Text = ds.Tables[0].Rows[0]["record"].ToString();
            Label44.Text = ds.Tables[0].Rows[0]["config"].ToString();
            Label46.Text = ds.Tables[0].Rows[0]["test"].ToString();
        }
        catch (Exception ex)
        {
            Response.Write("<script> alert('Error:- ','" + ex + "')</script>");
        }
    }
}