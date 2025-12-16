using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.IO;

public partial class dashboard : System.Web.UI.Page
{
    static  bool isNew ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
            Response.Redirect("Login.aspx");

        if (!IsPostBack)
        {
            
            fillWard();
            showTodayData();
            isNew = true;
        }

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        isNew = false;
        showData();
    }
    public void fillDate()
    {
        try
        {
           /* ddlEdate.DataSource = ddlSdate.DataSource = GetData("SELECT DISTINCT  cast(DATE_FORMAT(date,'%d-%M-%Y') as char) AS sdate, date as dateval FROM citelum_ui_call_log   ORDER BY 2 DESC");
            ddlSdate.DataTextField = "sdate";
            ddlEdate.DataTextField = "sdate";
            ddlSdate.DataValueField = "dateval";
            ddlEdate.DataValueField = "dateval";
            ddlSdate.DataBind();
            ddlEdate.DataBind();
            ddlSdate.Items.Insert(0, "Select");
            ddlEdate.Items.Insert(0, "Select");*/
            
        }
        catch { }
    }
    public void showData()
    {
        try
        {
           
               // string query = "SELECT ticket_id,date,time,customer_number,customer_name,zone_description,ward_description,poll_number,ticket_status_description FROM citelum_ui_call_log where date between '" + ddlSdate.SelectedValue + "' and '" + ddlEdate.SelectedValue + "' ORDER BY date DESC";
                string query = "SELECT ticket_id,date,time,customer_number,customer_name,zone_description,ward_description,poll_number,ticket_status_description FROM citelum_ui_call_log where date<>''  ";

                if (txtDate.Text.Length == 10 && txtTo.Text.Length == 10)
                    query += " and date between '" + txtDate.Text + "' and '" + txtTo.Text + "' ";
                else if (txtDate.Text.Length == 10)
                    query += " and date like '" + txtDate.Text + "%' ";
                    
                if (ddlClassification.SelectedIndex > 0)
                    query += " and classification='"+ddlClassification.SelectedItem.Text +"' ";

                if (ddlZone.SelectedIndex > 0)
                    query += " and zone_description='" + ddlZone.SelectedItem.Text + "' ";

                if (ddlWard.SelectedIndex > 0)
                    query += " and ward_description='"+ddlWard.SelectedItem.Text +"' ";

                if (ddlStatus.SelectedIndex > 0)
                    query += " and ticket_status_description='"+ddlStatus.SelectedItem.Text +"' ";

                if (txtTicketNo.Text.Length >0)
                    query += " and ticket_id=" + txtTicketNo.Text +" ";

                if (ddlCallTrans.SelectedIndex > 0)
                    query += " and call_transfer_status='" + ddlCallTrans.SelectedItem.Text + "' ";
                //Response.Write(query);
                query += " ORDER BY ticket_id DESC";
                DataSet ds = GetData(query);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                lblCount.Text = ds.Tables[0].Rows.Count.ToString() +" Records found";
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
    protected void PrintTicket(string tid)
    {
       string qry="SELECT ticket_id,customer_number,customer_name,DATE,TIME,zone_description,ward_description,poll_number,classification,landmark,ticket_status_description,remark FROM citelum_ui_call_log WHERE ticket_id='" + tid + "'";
       DataSet ds = GetData(qry);
       DetailsView1.DataSource = ds;
       DetailsView1.DataBind();
       this.mpePrint.Show();
    }
    public void showTodayData()
    {
        try
        {
           
                string query = "SELECT ticket_id,date,time,customer_number,customer_name,zone_description,ward_description,poll_number,ticket_status_description FROM citelum_ui_call_log where date =DATE(now()) ORDER BY ticket_id DESC";
                //Response.Write(query);
                GridView1.DataSource = GetData(query);
                GridView1.DataBind();
           
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
    private static DataSet GetData(string query)
    {
        DataSet ds = new DataSet();
        string constr = ConfigurationManager.ConnectionStrings["conKnowlarity"].ConnectionString;
        //string constr = ConfigurationManager.ConnectionStrings["conKnowlarity"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(ds);
                }
            }
            return ds;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (isNew == false)
            showData();
        else
            showTodayData();
        
    }
    protected void btnXls_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ClearContent();
            Response.Charset = "";
            Response.AddHeader("content-disposition", "attachment; filename=citelum_call_log.xls");
            Response.ContentType = "application/vnd.ms-excel";
            GridView gridExcel = new GridView();
            gridExcel.HeaderStyle.Font.Size = FontUnit.Point(10);
            gridExcel.HeaderStyle.BackColor = System.Drawing.Color.FromName("White");
            gridExcel.HeaderStyle.ForeColor = System.Drawing.Color.FromName("Black");
            gridExcel.RowStyle.Font.Size = FontUnit.Point(9);
            gridExcel.AlternatingRowStyle.Font.Size = FontUnit.Point(9);
            gridExcel.AlternatingRowStyle.ForeColor = System.Drawing.Color.FromName("Black");
            gridExcel.AlternatingRowStyle.BackColor = System.Drawing.Color.FromName("White");
            gridExcel.RowStyle.BackColor = System.Drawing.Color.FromName("White");
            gridExcel.RowStyle.ForeColor = System.Drawing.Color.FromName("Black");
            gridExcel.HeaderStyle.Font.Bold = true;
            gridExcel.AllowPaging = false;
            gridExcel.AllowSorting = false;
            gridExcel.GridLines = GridLines.Both;
            string query = "SELECT ticket_id,DATE,TIME,customer_number,customer_name,zone_description,ward_description,poll_number,classification,landmark,sms_notifier,"
        + "ticket_status,ticket_status_description,called_number,caller_duration,agentlist,call_transfer_to,call_transfer_status,call_transfer_duration,"
        + "recordingurl,remark,call_id,flag,ticket_open_sms,ticket_closed_sms,cast(ticket_close_date as char) ticket_close_date FROM citelum_ui_call_log where date <>'' ";
            if (txtDate.Text.Length == 10 && txtTo.Text.Length == 10)
                query += " and date between '" + txtDate.Text + "' and '" + txtTo.Text + "' ";
            else if (txtDate.Text.Length == 10)
                query += " and date like '" + txtDate.Text + "%' ";

            if (ddlClassification.SelectedIndex > 0)
                query += " and classification='" + ddlClassification.SelectedItem.Text + "' ";

            if (ddlZone.SelectedIndex > 0)
                query += " and zone_description='" + ddlZone.SelectedItem.Text + "' ";

            if (ddlWard.SelectedIndex > 0)
                query += " and ward_description='" + ddlWard.SelectedItem.Text + "' ";

            if (ddlStatus.SelectedIndex > 0)
                query += " and ticket_status_description='" + ddlStatus.SelectedItem.Text + "' ";

            if (txtTicketNo.Text.Length > 0)
                query += " and ticket_id=" + txtTicketNo.Text + " ";

            if (ddlCallTrans.SelectedIndex > 0)
                query += " and call_transfer_status='" + ddlCallTrans.SelectedItem.Text + "' ";

            query += " ORDER BY date,time DESC";
            gridExcel.DataSource = GetData(query);
            gridExcel.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gridExcel.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        catch { }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        string tid = string.Empty; ;
        foreach (GridViewRow rw in GridView1.Rows)
        {
            CheckBox chkBx = (CheckBox)rw.FindControl("Check");
            if (chkBx != null && chkBx.Checked)
            {
                tid = rw.Cells[1].Text;
                Response.Redirect("oncall.aspx?action=VIEW&tid=" + tid);
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("oncall.aspx");
    }
    protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillWard(ddlZone.SelectedValue);
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
    protected void fillWard()
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["conKnowlarity"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlDataAdapter da = new MySqlDataAdapter("SELECT distinct ward_id,ward_description FROM citelum_ui_ward_mapping ", con))
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
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string tid = string.Empty; ;
        foreach (GridViewRow rw in GridView1.Rows)
        {
            CheckBox chkBx = (CheckBox)rw.FindControl("Check");
            if (chkBx != null && chkBx.Checked)
            {
                tid = rw.Cells[1].Text;
                Response.Redirect("oncall.aspx?action=EDIT&tid=" + tid);
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "print")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index % GridView1.PageSize];
            string tid = row.Cells[1].Text.ToString();
            PrintTicket(tid);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.mpePrint.Hide();
    }
}