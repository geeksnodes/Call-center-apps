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

public partial class super3 : System.Web.UI.Page
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        //int i = 0;
        //if (i == 0)
        //{
        //    call(temp_super);
        //} 
        //if (i == 0)
        //{
        //    call(reject);
        //}
        call();
    }
   
    string alternate_no;
    string product;
    string city;
    string state;
    string profession;
    string payment;
    string mode;
    string message;
    string recovery;
    string seller;
    string dat;
    string tim;
    string super1;
    public void call()
    {

        try
        {
            con.Open();
            string s = "select * from temp_super where ticket='" + Session["open"].ToString() + "' Union select * from reject where ticket='" + Session["open"].ToString() + "' Union select * from vseller where ticket='" + Session["open"].ToString() + "'";
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
            Label16.Text = ds.Tables[0].Rows[0]["call_credit"].ToString();
            Label18.Text = ds.Tables[0].Rows[0]["email"].ToString();
            Label20.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
            Label22.Text = ds.Tables[0].Rows[0]["con_call"].ToString();
            alternate_no = ds.Tables[0].Rows[0]["alternate_no"].ToString();
            product = ds.Tables[0].Rows[0]["product"].ToString();
            city = ds.Tables[0].Rows[0]["city"].ToString();
            state = ds.Tables[0].Rows[0]["state"].ToString();
            profession = ds.Tables[0].Rows[0]["profession"].ToString();
            payment = ds.Tables[0].Rows[0]["payment"].ToString();
            mode = ds.Tables[0].Rows[0]["mode1"].ToString();
            message = ds.Tables[0].Rows[0]["message"].ToString();
            recovery = ds.Tables[0].Rows[0]["recovery"].ToString();
            dat = ds.Tables[0].Rows[0]["dat"].ToString();
            tim = ds.Tables[0].Rows[0]["tim"].ToString();
            super1 = ds.Tables[0].Rows[0]["super1"].ToString();
            seller = ds.Tables[0].Rows[0]["seller_name"].ToString();
            if (super1 != "") 
            {
                Button1.Visible = false;
                Button2.Visible = false;
            }
            con.Close();
            
        }
        catch (Exception ex) 
        {
            Response.Write("<script>alert('error ''" + ex + "')</script>");
        }
    }
    string super = "Approved";
    protected void Button2_Click(object sender, EventArgs e)
    {
        reject();
        not_approve();
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        approve();
    }
    public void approve()
    {
        con.Open();
        string s = "insert into vseller(did,name1,email,mobile,alternate_no,product,type1,choose_plan,city,state,profession,call_credit,period,mode1,con_call,message,recovery,payment,ticket,dat,tim,amount,super1,seller_name) values('" + Label4.Text + "','" + Label6.Text + "','" + Label18.Text + "','" + Label20.Text + "','" + alternate_no + "','" + product + "','" + Label8.Text + "','" + Label10.Text + "','" + city + "','" + state + "','" + profession + "','" + Label16.Text + "','" + Label14.Text + "','" + mode + "','" + Label22.Text + "','" + message + "','" + recovery + "','" + payment + "','" + Label2.Text + "','" + dat + "','" + tim + "','" + Label12.Text + "','" + super + "','"+seller+"') ";
        MySqlCommand cmd = new MySqlCommand(s, con);
        cmd.ExecuteNonQuery();
        con.Close();
        not_approve();
       
     
    }
    public void not_approve() 
    {
        con.Open();
        string s = "insert into did values('"+Label4.Text+"')";
        MySqlCommand cmd = new MySqlCommand(s, con);
        cmd.ExecuteNonQuery();
        s = "delete from temp_super where ticket='" + Label2.Text + "'";
        cmd = new MySqlCommand(s, con);
        cmd.ExecuteNonQuery();
        Session["open"] = "";
        con.Close();
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "onAddNew", "window.close();", true);
        //ScriptManager.RegisterClientScriptBlock(this.Page, GetType(), "ClosePopup", "window.close()", true);
    }
    public void reject() 
    {
        con.Open();
        super="Not Approved";
        string s = "insert into reject(did,name1,email,mobile,alternate_no,product,type1,choose_plan,city,state,profession,call_credit,period,mode1,con_call,message,recovery,payment,ticket,dat,tim,amount,super1,seller_name) values('" + Label4.Text + "','" + Label6.Text + "','" + Label18.Text + "','" + Label20.Text + "','" + alternate_no + "','" + product + "','" + Label8.Text + "','" + Label10.Text + "','" + city + "','" + state + "','" + profession + "','" + Label16.Text + "','" + Label14.Text + "','" + mode + "','" + Label22.Text + "','" + message + "','" + recovery + "','" + payment + "','" + Label2.Text + "','" + dat + "','" + tim + "','" + Label12.Text + "','" + super + "','"+seller+"') ";
        MySqlCommand cmd = new MySqlCommand(s, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}