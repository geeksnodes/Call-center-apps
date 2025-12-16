using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;

public partial class dashboard_sale : System.Web.UI.Page
{
      DAL dobj = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Session.Count < 1)
            Server.Transfer("Default.aspx");
        if (!IsPostBack) 
        {
            call();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        call();
    }
    public void call() // search creteria
    {
        GridView1.DataSource = dobj.dashboard_search_sale(txtstart.Text, txtend.Text, txtmob.Text);
        GridView1.DataBind();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        call();
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        try
        {
          DataTable dt = new DataTable();
          dt = dobj.dashboard_search_sale_exp(txtstart.Text, txtend.Text, txtmob.Text);
           // dt = dobj.dashboard_search_export(txtstart.Text, txtend.Text, txtmob.Text);
            //Build the CSV file data as a Comma separated string.
            string csv = string.Empty;


            csv += "   Ticket   ,   Name   ,  Mobile No. ,  Alternate No. ,    Email    ,   Location   ,  Profession , Source of Enq. ,   Model Interested  ,  Type  ,  Test Drive ,    Current Vehicle Info.  , Interested in Exchange ,  Date   ,   Time   , Agent ID ,Sales/Service ";
            //ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role
            /* foreach (DataColumn column in dt.Columns)
            {
                //Add the Header row for CSV file.
                csv += column.ColumnName + ',';
            }*/
            //Add new line.
            csv += "\r\n";
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    //Add the Data rows.
                    csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                }
                //Add new line.
                csv += "\r\n";
            }
            //Download the CSV file.
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Bg_motors.csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(csv);
            Response.Flush();
            Response.End();

        }
        catch { }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string tic = string.Empty;
        int count = 0;
        string page = string.Empty;
        foreach (GridViewRow gv in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gv.FindControl("chk1");
            if (chk != null && chk.Checked)
            {
                count += 1;
                Label lbl1 = (Label)gv.Cells[1].FindControl("Label1");
                Label lbl2 = (Label)gv.Cells[1].FindControl("Label6");
                tic = lbl1.Text;
                page = lbl2.Text;
            }
        }
        if (count == 1)
        {
            if (Session["role"].ToString() == "ADMIN")
            {
                dobj.delete_dashboard(tic.ToString());
                Response.Redirect("dashboard_admin_sale.aspx");
            }
            else
            {
            //    int i = Convert.ToInt32(dobj.dashboard_show_edit1(tic.ToString()));
            //    if (i == 1)
            //    {
            //        dobj.delete_dashboard(tic.ToString());
            //        Response.Redirect("dashboard_admin_sale.aspx");
            //    }
            //    else
            //        lblerr.Text = "*You have not permission to access.";
            }
        }
        else if (count == 0)
        {
            lblerr.Text = "*Please select atleast 1 row";
        }
        else
        {
            lblerr.Text = "*Please select only 1 row at a time";
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        string tic = string.Empty;
        int count=0;
        string page = string.Empty;
        foreach (GridViewRow gv in GridView1.Rows) 
        {
            CheckBox chk = (CheckBox)gv.FindControl("chk1");
            if (chk != null && chk.Checked) 
            {
                count += 1;
                Label lbl1 = (Label)gv.Cells[1].FindControl("Label1");
                Label lbl2 = (Label)gv.Cells[1].FindControl("Label6");
                tic = lbl1.Text;
                page = lbl2.Text;
               
            }
        }

        if (count == 1)
        {
            if (Session["role"].ToString() == "ADMIN")
            {
                if (page == "sale")
                    Response.Redirect("Admin_sales.aspx?ticket=" + tic);
                else
                    Response.Redirect("Admin_service.aspx?ticket=" + tic);
            }
            //else
            //{
            //    int i = Convert.ToInt32(dobj.dashboard_show_edit1(tic.ToString()));
            //    if (i == 1)
            //    {
            //        if (page == "sale")
            //            Response.Redirect("sales.aspx?ticket=" + tic);
            //        else
            //            Response.Redirect("service.aspx?ticket=" + tic);
            //    }
            //    else
            //        lblerr.Text = "*You have not permission to access.";
            //}
        }
        else if (count == 0)
        {
            lblerr.Text = "*Please select atleast 1 row";
        }
        else
        {
            lblerr.Text = "*Please select only 1 row at a time";
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        //if (Session["role"].ToString() == "SALE")
        //    Response.Redirect("sales.aspx");
        //if (Session["role"].ToString() == "SERVICE")
        //    Response.Redirect("service.aspx");
        if (Session["role"].ToString() == "ADMIN")
            Response.Redirect("ADMIN_sales.aspx");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void btn_adm_sale_Click(object sender, EventArgs e)
    {
        Response.Redirect("dashboard_admin_sale.aspx");
    }
    protected void btn_adm_service_Click(object sender, EventArgs e)
    {
        Response.Redirect("dashboard_admin_service.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) 
        {
            Label lb = (Label)e.Row.FindControl("Label3");
            Label lb2 = (Label)e.Row.FindControl("lblalternate");
            string temp = lb.Text;
            string temp2 = lb.Text;
            if (temp.Length == 10) 
            {
                lb.Text = "+91"+temp;
            }
            if (temp2.Length == 10)
            {
                lb2.Text = "+91" + temp2;
            }
        }
    }
}