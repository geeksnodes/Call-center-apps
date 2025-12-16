using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Net;
using System.Threading;

public partial class oncall : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       	if (Session.Count <= 0)
           Response.Redirect("Login.aspx");

        if (!IsPostBack)
        {
            //fillData();
            if (Request.QueryString.Count > 0 && Request.QueryString["TID"] != null && Request.QueryString["action"] != null)
            {
                if (Session["role"].ToString() == "AGENT")
                {
                    //btnSubmit.Enabled = false;
                    //pnlForm.Enabled = false;
                    ddlTicketStatus.Enabled = false;
                }

                if (Request.QueryString["action"].ToString() == "VIEW")
                    pnlForm.Enabled = false;
                else if (Request.QueryString["action"].ToString() == "EDIT")
                {
                    pnlForm.Enabled = true;

                }
               
                fillForm(Request.QueryString["TID"]);
            }
            else if (Request.QueryString.Count > 0 && Request.QueryString["action"].ToString() == "ADD")
            {
                hfCallID.Value = Request.QueryString["callid"].ToString();
                txtCustNo.Text = Request.QueryString["custno"].ToString();
                ddlClassification.SelectedIndex = 4;
                ddlClassification.Enabled = false;
            }
            else
            {
                foreach (ListItem li in ddlClassification.Items)
                {
                    if (li.Value == "Toll Free")
                        li.Enabled = false;
                }
            }
        }

    }

    protected void fillForm(string tid)
    {
        try
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["conKnowlarity"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlDataAdapter da = new MySqlDataAdapter("SELECT customer_number,customer_name,zone_id,ward_id,poll_number,classification,landmark,ticket_status,remark,call_id,ticket_status_description,recordingurl,cast(ticket_close_date as char) ticket_close_date FROM citelum_ui_call_log where ticket_id=" + tid, con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        txtCustNo.Text = ds.Tables[0].Rows[0]["customer_number"].ToString();
                        //txtContact.Text = ds.Tables[0].Rows[0]["customer_number"].ToString();
                        txtCustName.Text = ds.Tables[0].Rows[0]["customer_name"].ToString();
                        ddlZone.SelectedValue = ds.Tables[0].Rows[0]["zone_id"].ToString();
                        fillWard(ds.Tables[0].Rows[0]["zone_id"].ToString());
                        ddlWard.SelectedValue = ds.Tables[0].Rows[0]["ward_id"].ToString();
                        txtPoleNo.Text = ds.Tables[0].Rows[0]["poll_number"].ToString();
                        
                        ddlClassification.SelectedValue = ds.Tables[0].Rows[0]["classification"].ToString();
                        if (ddlClassification.SelectedValue == "Toll Free")
                            ddlClassification.Enabled = false;
                        txtLandmark.Text = ds.Tables[0].Rows[0]["landmark"].ToString();
                        ddlTicketStatus.SelectedValue = ds.Tables[0].Rows[0]["ticket_status"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["remark"].ToString();
                        hfCallID.Value = ds.Tables[0].Rows[0]["call_id"].ToString();
                        ltlPlay.Text = "<script type='text/javascript'>"
                       + " $(document).ready(function () {"
                       + "    $(\"#jquery_jplayer_1\").jPlayer({"
                         + "       ready: function () {"
                            + "        $(this).jPlayer(\"setMedia\", {"
                             + "           mp3: \"" + ds.Tables[0].Rows[0]["recordingurl"].ToString() + "\","

                                    + "});"
                               + " },"
                              + "  swfPath: \"../js\","
                               + " supplied: \"mp3\""
                           + " });"
                        + "});"
                        + " </script>";
                        /*ltlPlay.Text = " <audio controls>"
                        + "<source src='" + ds.Tables[0].Rows[0]["recordingurl"].ToString()+"' type='audio/wav'>"
                        + " <embed height='50' width='100' src='" + ds.Tables[0].Rows[0]["recordingurl"].ToString() + "'>"
                        + "</audio>";*/
                        if (ds.Tables[0].Rows[0]["ticket_status_description"].ToString() == "Closed")
                        {
                            txtCloseDate.Text = ds.Tables[0].Rows[0]["ticket_close_date"].ToString();
                            pnlForm.Enabled = false;
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            /*using (TextWriter tws = new StreamWriter(Server.MapPath("LogMissed.txt"), true))
            {
                tws.WriteLine(System.DateTime.Now.ToString());
                tws.WriteLine(ex.ToString());
            }*/
        }
    }

    protected void fillData()
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["conKnowlarity"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlDataAdapter da = new MySqlDataAdapter("SELECT distinct ward_id,ward_description FROM citelum_ui_ward_mapping", con))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                ddlWard.DataSource = ds;
                ddlWard.DataTextField = "ward_description";
                ddlWard.DataValueField = "ward_id";
                ddlWard.DataBind();

            }
        }
    }
    protected void fillWard(string zone)
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["conKnowlarity"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlDataAdapter da = new MySqlDataAdapter("SELECT distinct ward_id,ward_description FROM citelum_ui_ward_mapping where ward_id like '" + zone + "%'", con))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                ddlWard.DataSource = ds;
                ddlWard.DataTextField = "ward_description";
                ddlWard.DataValueField = "ward_id";
                ddlWard.DataBind();
                ddlWard.Items.Insert(0, "select");
            }
        }
    }
   
    
    protected int CheckExists()
    {
        int res = 0;
        if (ddlTicketStatus.SelectedItem.Text != "Open")
        {
            res = 0;
        }
        else
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["conKnowlarity"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM citelum_ui_call_log WHERE zone_id='" + ddlZone.SelectedValue + "' AND ward_id='" + ddlWard.SelectedValue + "' AND poll_number='" + txtPoleNo.Text + "' AND ticket_status_description<>'Closed' ", con))
                {
                    con.Open();
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        return res;
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (CheckExists() == 0)
            {

                // "SELECT DATE,TIME,customer_number,customer_name,zone_id,zone_description,ward_id,ward_description,poll_number,classification,landmark,ticket_status,ticket_status_description,remark,call_id FROM `citelum_ui_call_log`";
                string constr = System.Configuration.ConfigurationManager.ConnectionStrings["conKnowlarity"].ConnectionString;
                string callid = string.Empty;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                   using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        int res = 0;
                        if (hfCallID.Value.Length > 0)
                        {
                            cmd.CommandText = "select count(*) from citelum_ui_call_log where call_id='" + hfCallID.Value + "'";
                            res = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        else
                            res = 0;
                        if (res > 0)
                            cmd.CommandText = "update citelum_ui_call_log set customer_name=?custname,zone_id=?zoneid,zone_description=?zonedesc,"
                        + "ward_id=?wardid,ward_description=?warddesc,poll_number=?pollno,classification=?classify,landmark=?landmark,ticket_status=?tstatus,"
                        + "ticket_status_description=?tsdesc,remark=?remark , sms_notifier=?smsnotifier where call_id=?callid ";
                        else
                            cmd.CommandText = "insert into citelum_ui_call_log( DATE,TIME,call_id,customer_number,customer_name,zone_id,zone_description,ward_id,"
                        + "ward_description,poll_number,classification,landmark,ticket_status,ticket_status_description,remark,sms_notifier) values(date(now()),time(now()),"
                        + "?callid,?custno,?custname,?zoneid,?zonedesc,?wardid,?warddesc,?pollno,?classify,?landmark,?tstatus,?tsdesc,?remark,?smsnotifier)";

                        callid = DateTime.Now.ToString("yyyymmddhhmmssfff_" + txtCustNo.Text);
                        if (hfCallID.Value.Length == 0)
                            hfCallID.Value = callid;
                        cmd.Parameters.AddWithValue("?callid", hfCallID.Value);
                        cmd.Parameters.AddWithValue("?custno", txtCustNo.Text);
                        cmd.Parameters.AddWithValue("?custname", txtCustName.Text);
                        if (ddlZone.SelectedIndex <= 0)
                        {
                            cmd.Parameters.AddWithValue("?zoneid", "");
                            cmd.Parameters.AddWithValue("?zonedesc", "");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("?zoneid", ddlZone.SelectedValue);
                            cmd.Parameters.AddWithValue("?zonedesc", ddlZone.SelectedItem.Text);
                        }
                        if (ddlWard.SelectedIndex <= 0)
                        {
                            cmd.Parameters.AddWithValue("?wardid", "");
                            cmd.Parameters.AddWithValue("?warddesc", "");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("?wardid", ddlWard.SelectedValue);
                            cmd.Parameters.AddWithValue("?warddesc", ddlWard.SelectedItem.Text);
                        }
                        cmd.Parameters.AddWithValue("?pollno", txtPoleNo.Text);
                        if (ddlClassification.SelectedIndex <= 0)
                            cmd.Parameters.AddWithValue("?classify", "");
                        else
                            cmd.Parameters.AddWithValue("?classify", ddlClassification.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("?landmark", txtLandmark.Text);
                        cmd.Parameters.AddWithValue("?tstatus", ddlTicketStatus.SelectedValue);
                        cmd.Parameters.AddWithValue("?tsdesc", ddlTicketStatus.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("?remark", txtRemarks.Text);
                        cmd.Parameters.AddWithValue("?smsnotifier", txtContact.Text);
                        int res1 = cmd.ExecuteNonQuery();
                        if (res1 > 0)
                        {
                            cmd.CommandText = "select ticket_id from citelum_ui_call_log where call_id='" + hfCallID.Value + "'";
                            string tid = cmd.ExecuteScalar().ToString();
                            if (Request.QueryString["action"] != null)
                            {
                                lblSuccess.Text = "Complaint Updated Successfully";
                                if (ddlTicketStatus.SelectedItem.Text == "Closed")
                                {
                                    cmd.CommandText = "update citelum_ui_call_log set ticket_close_date=now() where ticket_id="+tid ;
                                    cmd.ExecuteNonQuery();
                                    if(txtContact.Text.Length>=10)
                                    {
                                         Thread thread = new Thread(() => sendSMS(hfCallID.Value, "closed",tid));
                                         thread.Start();
                                    }
                                }

                            }
                            else
                            {
                                lblSuccess.Text = "Complaint Successfully Submitted.";
                                if (ddlTicketStatus.SelectedItem.Text == "Open" && txtContact.Text.Length>=10)
                                {
                                    Thread thread = new Thread(() => sendSMS(hfCallID.Value, "open",tid));
                                    thread.Start();
                                    //sendSMS(hfCallID.Value, "open");
                                }
                                else if (ddlTicketStatus.SelectedItem.Text == "Closed" )
                                {
                                    cmd.CommandText = "update citelum_ui_call_log set ticket_close_date=now() where ticket_id="+tid ;
                                    cmd.ExecuteNonQuery();
                                    if(txtContact.Text.Length>=10)
                                    {
                                         Thread thread = new Thread(() => sendSMS(hfCallID.Value, "closed",tid));
                                         thread.Start();
                                    }
                                }                   
                            }
                            lblTicketId.Text = "Ticket ID :" + tid;

                            this.mpeSuccess.Show();

                        }
                        else
                        {
                            lblSuccess.Text = "Complaint could not be submitted. Please contact admin.";
                            lblTicketId.Text = "";
                            this.mpeSuccess.Show();
                        }

                    }
                }
            }
            else
            {
                lblSuccess.Text = "Complaint of this pole number already exists.";
                lblTicketId.Text = "";
                this.mpeSuccess.Show();
            }
        }
        catch (Exception ex)
        {
            /*using (TextWriter tws = new StreamWriter(Server.MapPath("LogMissed.txt"), true))
            {
                tws.WriteLine(System.DateTime.Now.ToString());
                tws.WriteLine(ex.ToString());
            }*/
        }
    }
    protected void sendSMS(string call_id, string status, string ticket_id)
    {
	try
	{

        	WebClient wc = new WebClient();
            string res = wc.DownloadString("http://int.kapps.in/webapi/Citelum/api/citelum_sms?uniqueid=" + call_id + "&ticket_type=" + status + "&ticket_id=" + ticket_id );
          //string res = wc.DownloadString("http://int.kapps.in/webapi/Citelum/api/citelum_sms?uniqueid=" + call_id + "&ticket_type=" + status);
	}
	catch{}
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        this.mpeSuccess.Hide();
        lblTicketId.Text = "";
        lblSuccess.Text = "";
        Response.Redirect("oncall.aspx");
    }
    protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillWard(ddlZone.SelectedValue);
    }
}