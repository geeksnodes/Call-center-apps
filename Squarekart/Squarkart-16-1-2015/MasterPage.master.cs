using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DAL dobj = new DAL();
    int temp=0;
    string mobpass;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session.Count > 0)
                {
                    lblUserid.Text = Session["userid"].ToString();
                    if (Session["role"].ToString() == "ADMIN")
                        HyperLink1.Enabled = true;
                    else
                        HyperLink1.Enabled = false;
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
               lbldash.Text= Session["heading"].ToString();
        }
        catch (Exception)
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            dobj.user_logout(Session["userid"].ToString());
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        catch (Exception) 
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
 
    protected void btnDone_Click(object sender, EventArgs e)
    {
        string accept="accept";
        dobj.popup_accept(lblid.Text);
        Response.Redirect("customer_profile.aspx?mob=" + lblPop.Text + "&agentid=" + Session["userid"].ToString() + "&accept=" + accept);
        lblid.Text = "";
        lblPop.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        dobj.popup_busy(lblid.Text);
      
    }
    protected void chk(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            if (Session["role"].ToString() == "AGENT")
            {
                lblPop.Text = "";
                lblpop1.Text = "";
                int i = Convert.ToInt32(dobj.check_count1(Session["userid"].ToString()));
                if (i > 0)
                {
                    DataSet ds = new DataSet();
                    ds = dobj.check_count_popup2(Session["userid"].ToString());
                    string mob = ds.Tables[0].Rows[0]["mobileno"].ToString();
                    mobpass = mob.ToString();
                    int m_read = Convert.ToInt32(dobj.complaint_read_popup(mob.ToString()));
                    if (m_read == 0)
                    {
                        lblPop.Text = mob.ToString();
                    }
                    if (m_read == 1)
                    {
                        DataSet ds2 = new DataSet();
                        ds2 = dobj.complaint_fetch_popup(mob);
                        lblpop1.Text = ds2.Tables[0].Rows[0]["uname"].ToString();
                        lblPop.Text = ds.Tables[0].Rows[0]["mobileno"].ToString();
                        lblPop.Visible = true;//mobile no. hide
                    }
                    else
                    {
                        DataSet ds2 = new DataSet();
                        ds2 = dobj.complaint_fetch_popup(mob);
                        lblPop.Text = ds.Tables[0].Rows[0]["mobileno"].ToString();
                        lblPop.Visible = true;

                    }
                    lblid.Text = ds.Tables[0].Rows[0]["id"].ToString();
                    hfUid.Value = ds.Tables[0].Rows[0]["call_id"].ToString();

                    this.ModalPopupExtender1.Show();
                }
            }
        }
       
    }
}
