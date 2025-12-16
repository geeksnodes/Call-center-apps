using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class seller : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    con.Open();
        //    string s = "select id from did";
        //    MySqlCommand cmd = new MySqlCommand(s, con);
        //    MySqlDataReader dr = cmd.ExecuteReader();
        //    DropDownList1.DataSource = dr;
        //    DropDownList1.DataTextField = "id";
        //    DropDownList1.DataValueField = "id";
        //    DropDownList1.DataBind();
        //    con.Close();
        //}
        //catch (Exception ex) 
        //{
        //    Response.Write(ex);
        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        call();
    }
    public void call()
    {
        string table = "";

        if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox6.Text != "" && TextBox7.Text != "" && TextBox8.Text != "" && TextBox9.Text != "" && TextBox10.Text != "" && TextBox11.Text != "" && TextBox12.Text != "" && RadioButtonList1.SelectedValue != "" && RadioButtonList2.SelectedValue != "" && DropDownList2.SelectedItem.Text != "--Select--" && RadioButtonList3.SelectedValue != "" && RadioButtonList4.SelectedValue != "" && TextBox13.Text != "")
        {
            
            try
            {
                if (Session["sendsuper"] == "sendsuper" || Session["sendsuper1"] == "sendsuper" || Session["sendsuper2"] == "sendsuper" || Session["sendsuper3"] == "sendsuper")
                {
                    table = "temp_super";
                }
                else
                {
                    table = "vseller";
                }
                int i = 0;
                string s = "";
                MySqlCommand cmd;
                MySqlDataReader dr;
                string dat = System.DateTime.Now.ToShortDateString();
                string tim = System.DateTime.Now.ToShortTimeString();
                Random random = new Random();
                string tic = "";
                if (i == 0) 
                {
                    string n = "0987654321";
                    int len = 14;
                    
                    while (0 < len--)
                    {
                        tic += n[random.Next(n.Length)];
                    }
                    s = "select ticket from vseller where ticket='" + tic + "'";
                    cmd = new MySqlCommand(s, con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        i = 1;
                    }
                    dr.Close();
                }
                if (i ==1 )
                {
                    string n = "0987654321";
                    int len = 15;
                    while (0 < len--)
                    {
                        tic += n[random.Next(n.Length)];
                    }
                }
                s = "insert into " + table + " (did,name1,email,mobile,alternate_no,product,type1,choose_plan,city,state,profession,call_credit,period,mode1,con_call,message,recovery,payment,ticket,dat,tim,amount,seller_name) values('" + DropDownList1.SelectedItem.Text + "','" + TextBox1.Text + " " + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + DropDownList2.SelectedItem.Value + "','" + RadioButtonList1.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "','" + RadioButtonList2.SelectedItem.Text + "','" + TextBox11.Text + "','" + TextBox12.Text + "','" + RadioButtonList3.SelectedItem.Text + "','" + RadioButtonList4.SelectedItem.Text + "','" + tic.ToString() + "','" + dat.ToString() + "','" + tim.ToString() + "','" + TextBox13.Text + "','" + Session["uname"].ToString() + "') ";
                cmd = new MySqlCommand(s, con);
                cmd.ExecuteNonQuery();
                s = "delete from did where id='" + DropDownList1.SelectedItem.Text + "'";
                cmd = new MySqlCommand(s, con);
                cmd.ExecuteNonQuery();
                Session["sendsuper"] = "";
                Response.Redirect("seller.aspx");

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                con.Close();
                Session["sendsuper"] = null;
                Session["prepaid"] = null;
                Session["sendsuper1"] = null;
                Session["sendsuper2"] = null;
                Session["sendsuper3"] = null;
            }
        }
        else
        {
            Response.Write("<script> alert('Please fill all details properly');</script>");
        }

    }
   
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedItem.Text == "Big")
        {
            TextBox9.Text = "60000";
            TextBox13.Text = "6555";
            TextBox10.Text = "365";
            TextBox11.Text = "15";
            Label21.Text = "per Month";
        }
        if (DropDownList3.SelectedItem.Text == "Medium")
        {
            TextBox9.Text = "30000";
            TextBox13.Text = "28888";
            TextBox10.Text = "365";
            TextBox11.Text = "5";
            Label21.Text = "";
        }
        if (DropDownList3.SelectedItem.Text == "Small")
        {
            TextBox9.Text = "12000";
            TextBox13.Text = "9999";
            TextBox10.Text = "365";
            TextBox11.Text = "2";
            Label21.Text = "";
        }

        if (DropDownList3.SelectedItem.Text == "Basic")
        {
            TextBox9.Text = "5111";
            TextBox13.Text = "5111";
            TextBox11.Text = "2";
            TextBox10.Text = "90";
        }
        if (DropDownList3.SelectedItem.Text == "Medium" && Session["prepaid"] != "")
        {
            TextBox9.Text = "11111";
            TextBox13.Text = "11111";
            TextBox11.Text = "2";
            TextBox10.Text = "180";
        }
        if (DropDownList3.SelectedItem.Text == "Enterprise")
        {
            TextBox9.Text = "23000";
            TextBox13.Text = "21111";
            TextBox10.Text = "300";
            TextBox11.Text = "2";
        }
    }
    protected void TextBox9_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string a = TextBox9.Text;
            int ii;
            if (int.TryParse(a, out ii))
            {
                if (DropDownList3.SelectedItem.Text == "Big")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox9.Text) > 60001)
                    {
                        Response.Write("<script>alert('You are not applicable for it ')</script>");
                        Session["sendsuper1"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox9.Text) < 60001)
                    {
                        Session["sendsuper1"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Medium")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox9.Text) > 30001)
                    {
                        Response.Write("<script>alert('You are not applicable for it ')</script>");
                        Session["sendsuper1"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox9.Text) < 30001)
                    {
                        Session["sendsuper1"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Small")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox9.Text) > 12001)
                    {
                        Response.Write("<script>alert('You are not applicable for it ')</script>");
                        Session["sendsuper1"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox9.Text) < 366)
                    {
                        Session["sendsuper1"] = "";
                    }
                }

                if (DropDownList3.SelectedItem.Text == "Basic")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox9.Text) > 5112)
                    {
                        Response.Write("<script>alert('You are not applicable for it ')</script>");
                        Session["sendsuper1"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox9.Text) < 5112)
                    {
                        Session["sendsuper1"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Medium" && Session["prepaid"] != "")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox9.Text) > 11112)
                    {
                        Response.Write("<script>alert('You are not applicable for it ')</script>");
                        Session["sendsuper1"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox9.Text) < 11112)
                    {
                        Session["sendsuper1"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Enterprise")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox9.Text) > 23001)
                    {
                        Response.Write("<script>alert('You are not applicable for it ')</script>");
                        Session["sendsuper1"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox9.Text) < 23001)
                    {
                        Session["sendsuper1"] = "";
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter Valid Call Credit')</script>");
                TextBox9.Text = "";
                SetFocus(TextBox9);

            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('error ''" + ex + "')</script>");
        }

    }
    protected void TextBox11_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string a = TextBox11.Text;
            int ii;
            if (int.TryParse(a, out ii))
            {
                if (DropDownList3.SelectedItem.Text == "Big")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox11.Text) > 15)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper2"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox11.Text) < 16)
                    {
                        Session["sendsuper2"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Medium")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox11.Text) > 5)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper2"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox11.Text) < 6)
                    {
                        Session["sendsuper2"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Small")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox11.Text) > 2)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper2"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox10.Text) < 3)
                    {
                        Session["sendsuper2"] = "";
                    }
                }

                if (DropDownList3.SelectedItem.Text == "Basic")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox11.Text) > 2)
                    {
                        Response.Write("<script>alert('You are not applicable for it ')</script>");
                       // Session["sendsuper2"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox11.Text) < 3)
                    {
                       // Session["sendsuper2"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Medium" && Session["prepaid"] != "")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox11.Text) > 2)
                    {
                        Response.Write("<script>alert('You are not applicable for it ')</script>");
                      //  Session["sendsuper2"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox11.Text) < 3)
                    {
                       // Session["sendsuper2"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Enterprise")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox11.Text) > 2)
                    {
                        Response.Write("<script>alert('You are not applicable for it ')</script>");
                       // Session["sendsuper2"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox11.Text) < 3)
                    {
                        Session["sendsuper2"] = "";
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter Valid Concurrent Call')</script>");
                TextBox9.Text = "";
                SetFocus(TextBox11);

            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('error ''" + ex + "')</script>");
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        Response.Redirect("seller.aspx");

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (RadioButtonList1.SelectedValue == "Prepaid")
        {
            try
            {
                Session["prepaid"] = RadioButtonList1.SelectedValue.ToString();
                con.Open();
                string s = "select prepaid from prepaid where id='" + 2 + "'";
                MySqlCommand cmd = new MySqlCommand(s, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                DropDownList3.DataSource = dr;
                DropDownList3.DataTextField = "prepaid";
                DropDownList3.DataValueField = "prepaid";
                DropDownList3.DataBind();
                con.Close();
                TextBox9.Text = "5111";
                TextBox10.Text = "365";
                TextBox13.Text = "5111";
                TextBox11.Text = "2";
                Label21.Text = "";
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        if (RadioButtonList1.SelectedValue == "Postpaid")
        {
            try
            {
                Session["prepaid"] = "";
                con.Open();
                string s = "select prepaid from prepaid where id='" + 1 + "'";
                MySqlCommand cmd = new MySqlCommand(s, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                DropDownList3.DataSource = dr;
                DropDownList3.DataTextField = "prepaid";
                DropDownList3.DataValueField = "prepaid";
                DropDownList3.DataBind();
                con.Close();
                TextBox9.Text = "60000";
                TextBox10.Text = "365";
                TextBox13.Text = "6555";
                TextBox11.Text = "15";
                if (DropDownList3.SelectedItem.Text == "Big")
                {
                    Label21.Text = "per Month";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
    protected void TextBox10_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string a = TextBox10.Text;
            int ii;
            if (int.TryParse(a, out ii))
            {
                if (DropDownList3.SelectedItem.Text == "Big")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox10.Text) > 365)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox10.Text) < 366)
                    {
                        Session["sendsuper"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Medium" && Session["prepaid"] == "")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox10.Text) > 365)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority  ')</script>");
                        Session["sendsuper"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox10.Text) < 366)
                    {
                        Session["sendsuper"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Small")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox10.Text) > 365)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority  ')</script>");
                        Session["sendsuper"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox10.Text) < 366)
                    {
                        Session["sendsuper"] = "";
                    }
                }

                if (DropDownList3.SelectedItem.Text == "Basic")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox10.Text) > 90)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority  ')</script>");
                        Session["sendsuper"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox10.Text) < 91)
                    {
                        Session["sendsuper"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Medium" && Session["prepaid"] != "")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");

                    if (Convert.ToInt32(TextBox10.Text) > 180)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox10.Text) < 181)
                    {
                        Session["sendsuper"] = "";
                    }
                }
                if (DropDownList3.SelectedItem.Text == "Enterprise")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");

                    if (Convert.ToInt32(TextBox10.Text) > 300)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper"] = "sendsuper";
                    }
                    if (Convert.ToInt32(TextBox10.Text) < 301)
                    {
                        Session["sendsuper"] = "";
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter Valid Validity Period ')</script>");
                TextBox10.Text = "";
                SetFocus(TextBox10);
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('error ''" + ex + "')</script>");
        }

    }
    //protected void TextBox3_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        con.Open();
    //        string s = "select email from vseller where email='"+TextBox3.Text+"'";
    //        SqlCommand cmd = new SqlCommand(s, con);
    //        SqlDataReader dr = cmd.ExecuteReader();
    //        if (dr.Read())
    //        {
    //                Response.Write("<script>alert('This Email address is already exist ')</script>");
    //                SetFocus(TextBox3);

    //        }
    //        con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex);
    //    }
    //}
    protected void TextBox13_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string a = TextBox13.Text;
            int ii;
            if (int.TryParse(a, out ii))
            {
                if (DropDownList3.SelectedItem.Text == "Big")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox13.Text) > 6555)
                    {
                        TextBox13.Text = "6555";
                    }
                    if (Convert.ToInt32(TextBox13.Text) < 6555)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper3"] = "sendsuper";

                    }
                }
                if (DropDownList3.SelectedItem.Text == "Medium")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox13.Text) > 28888)
                    {
                        TextBox13.Text = "28888";
                    }
                    if (Convert.ToInt32(TextBox13.Text) < 28888)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper3"] = "sendsuper";

                    }
                }
                if (DropDownList3.SelectedItem.Text == "Small")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox13.Text) > 9999)
                    {
                        TextBox13.Text = "9999";
                    }
                    if (Convert.ToInt32(TextBox13.Text) < 9999)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper3"] = "sendsuper";

                    }
                }

                if (DropDownList3.SelectedItem.Text == "Basic")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox13.Text) > 5111)
                    {
                        TextBox13.Text = "5111";
                    }
                    if (Convert.ToInt32(TextBox13.Text) < 5111)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper3"] = "sendsuper";

                    }
                }
                if (DropDownList3.SelectedItem.Text == "Medium" && Session["prepaid"] != "")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox13.Text) > 11111)
                    {
                       
                        TextBox13.Text = "11111";
                    }
                    if (Convert.ToInt32(TextBox13.Text) < 11111)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper3"] = "sendsuper";

                    }
                }
                if (DropDownList3.SelectedItem.Text == "Enterprise")
                {
                    Response.Write("<script>alert('You required to take approval from competent authority')</script>");
                    if (Convert.ToInt32(TextBox13.Text) > 21111)
                    {
                        TextBox13.Text = "21111";
                    }
                    if (Convert.ToInt32(TextBox13.Text) < 21111)
                    {
                        Response.Write("<script>alert('This Query is submitted after approval of competent authority ')</script>");
                        Session["sendsuper3"] = "sendsuper";

                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter Valid Amount')</script>");
                TextBox9.Text = "";
                SetFocus(TextBox13);

            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('error ''" + ex + "')</script>");
        }
    }
}




