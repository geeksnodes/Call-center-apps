using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.IO;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string query = "select if(count(*)>0,role,'0') from citelum_ui_agent where userid='"+txtUser.Text +"' and password='"+txtPass.Text +"' and is_active='1'";
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["conKnowlarity"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    con.Open();
                    cmd.Connection = con;
                    string res = cmd.ExecuteScalar().ToString();
                    if (res!="0")
                    {
                       
                        cmd.CommandText = "select if(agent_number is null,' ',agent_number) from citelum_ui_agent where userid='" + txtUser.Text + "' ";
                        Session.Add("agentnum", cmd.ExecuteScalar().ToString());
                        Session.Add("userid", txtUser.Text);
                        Session.Add("role",res);
                        Response.Redirect("dashboard.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "Invalid User-ID/Password";
                        lblMsg.Visible = true;
                    }
                }
            }
           

        }
        catch (Exception ex)
        {
            using (TextWriter tws = new StreamWriter(Server.MapPath("LogMissed.txt"), true))
            {
                tws.WriteLine(System.DateTime.Now.ToString());
                tws.WriteLine(ex.ToString());
            }
        }
    }
}