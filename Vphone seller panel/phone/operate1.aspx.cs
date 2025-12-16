using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

public partial class operate1 : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Label41.Visible = false;
        Label42.Visible = false;
        RadioButtonList2.Visible = false;
        RadioButtonList3.Visible = false;
        call();
        
    }
    public void call()
    {
        try
        {
            int i = 0;
            string id = Convert.ToString(Session["open"]);
            con.Open();
            string s = "select * from vseller where ticket='" + id + "'";
            MySqlCommand cmd = new MySqlCommand(s, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlDataReader dr;
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

            if (i == 0)
            {
                s = "select config from vseller where config='Completed' and record='Received' and ticket='" + id + "' ";
                cmd = new MySqlCommand(s, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    RadioButtonList1.SelectedValue = "Received";
                    RadioButtonList1.Enabled = false;
                    RadioButtonList2.SelectedValue = "Completed";
                    RadioButtonList2.Enabled = false;
                    Label41.Visible = true;
                    RadioButtonList2.Visible = true;
                    Label42.Visible = true;
                    RadioButtonList3.Visible = true;
                    i = 2;
                }
                dr.Close(); 
            }
            if (i == 0)
            {
                s = "select record from vseller where record='Received' and ticket='" + id + "' ";
                cmd = new MySqlCommand(s, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    RadioButtonList1.SelectedValue = "Received";
                    RadioButtonList1.Enabled = false;
                    Label41.Visible = true;
                    RadioButtonList2.Visible = true;
                    i = 2;
                }
                dr.Close();
            }
           
            
            //else 
            //{
            //    Label41.Visible = false;
            //    Label42.Visible = false;
            //    RadioButtonList2.Visible = false;
            //    RadioButtonList3.Visible = false;
            //}
            con.Close();
        }
        catch (Exception ex) 
        {
            Response.Write(ex);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(RadioButtonList1.SelectedValue !="" && RadioButtonList2.SelectedValue !="" && RadioButtonList3.SelectedValue !="")
        {
            try
            {
                con.Open();
                string s = "update vseller set record='" + RadioButtonList1.SelectedValue + "',config='" + RadioButtonList2.SelectedValue + "',test='" + RadioButtonList3.SelectedValue + "',operator_name='" + Session["uname"].ToString() + "' where ticket='" + Session["open"].ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(s, con);
                cmd.ExecuteNonQuery();
                Session["open"] = null;
               //HttpContext.Current.Session["check"] = null;
                con.Close();
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "onAddNew", "window.close();", true);
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        if (RadioButtonList1.SelectedValue != "" && RadioButtonList2.SelectedValue != "") 
        {
            try
            {
                con.Open();
                string s = "update vseller set record='" + RadioButtonList1.SelectedValue + "',config='" + RadioButtonList2.SelectedValue + "',operator_name='" + Session["uname"].ToString() + "' where ticket='" + Session["open"].ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(s, con);
                cmd.ExecuteNonQuery();
                Session["open"] = null;
                //HttpContext.Current.Session["check"] = null;
                con.Close();
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "onAddNew", "window.close();", true);
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        
        }
        if (RadioButtonList1.SelectedValue != "")
        {
            try
            {
                con.Open();
                string s = "update vseller set record='" + RadioButtonList1.SelectedValue + "',operator_name='" + Session["uname"].ToString() + "' where ticket='" + Session["open"].ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(s, con);
                cmd.ExecuteNonQuery();
                Session["open"] = null;
                //HttpContext.Current.Session["check"] = null;
                con.Close();
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "onAddNew", "window.close();", true);
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }

        else
        {
            Response.Write("<script>alert('Please select all fields properly !!!')</script>");

        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "Received")
        {
            Label41.Visible = true;
            RadioButtonList2.Visible = true;
        }
    }
   
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "Completed")
        {
            Label41.Visible = true;
            RadioButtonList2.Visible = true;
            Label42.Visible = true;
            RadioButtonList3.Visible = true;
        }
        else 
        {
            Label41.Visible = true;
            RadioButtonList2.Visible = true;
        }
    }
}