using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class FirstPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session.Count > 0)
            {
                lblUserid.Text = Session["userid"].ToString();
                if (Session["role"].ToString() == "ADMIN")
                    HyperLink1.Visible = true;
                else
                    HyperLink1.Visible = false;
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
    public void chk(object sender, EventArgs e)
    {
        //lblCounter.Text = DateTime.Now.ToLongTimeString() ;
        try
        {
            //if (lblTicketId.Text.Length > 0)
            //    this.mpeSuccess.Show();
             if (Session["role"].ToString() == "AGENT")
            {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["mysqlcon"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT count(*) FROM newcall WHERE STATUS='NEW' AND agentid='" + Session["agentnum"].ToString() + "' ", con))
                {
                    con.Open();
                    int ctr = Convert.ToInt32(cmd.ExecuteScalar());
                    if (ctr > 0)
                    {
                        cmd.CommandText = "SELECT CONCAT(cli,'#',id,'#',call_id) FROM newcall WHERE STATUS='NEW' AND agentid='" + Session["agentnum"].ToString() + "' order by trndate desc limit 1";
                        string res = cmd.ExecuteScalar().ToString();
                        string[] res1 = res.Split(new char[] { '#' });
                         cmd.CommandText = "insert into oldcalls(select * from newcall where agentid='" + Session["agentnum"].ToString() + "' and id< "+res1[1]+")";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "delete from newcall where agentid='" + Session["agentnum"].ToString() + "' and id< " + res1[1] + "";
                            cmd.ExecuteNonQuery();
                        lblid.Text = res1[1];
                        lblPop.Text = res1[0];
                        hfUid.Value = res1[2];
                        this.ModalPopupExtender1.Show();
                    }

                }

            }
          }
        }
        catch { }
    }
    protected void btnDone_Click(object sender, EventArgs e)
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["mysqlcon"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("update newcall set status='ACCEPT' where id=" + lblid.Text, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into oldcalls (select * from newcall where id =" + lblid.Text + ")";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "delete from newcall where id =" + lblid.Text + "";
                cmd.ExecuteNonQuery();
                Response.Redirect("oncall.aspx?action=ADD&callid=" + hfUid.Value + "&custno=" + lblPop.Text);
                //txtCustNo.Text = lblPop.Text;
                //hfCallID.Value = hfUid.Value;
                lblid.Text = "";
                lblPop.Text = "";

            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["mysqlcon"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("update newcall set status='BUSY' where id=" + lblid.Text, con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into oldcalls (select * from newcall where id =" + lblid.Text + ")";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "delete from newcall where id =" + lblid.Text + "";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
