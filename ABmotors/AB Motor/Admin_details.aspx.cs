using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_details : System.Web.UI.Page
{
    DAL dobj = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count < 1)
            Server.Transfer("Default.aspx");
    }
    public void call() // search creteria
    {
        GridView1.DataSource = dobj.dashboard_search(txtstart.Text, txtend.Text, txtmob.Text);
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
            dt = dobj.dashboard_search_export(txtstart.Text, txtend.Text, txtmob.Text);
            //Build the CSV file data as a Comma separated string.
            string csv = string.Empty;
            csv += " Role , Agent ID ,  Ticket   ,   Name   ,  Alternate No. ,    Email    ,  Profession  ,   Location   ,  Source of Enquiry  ,Model Interested in , Diesel/Petrol , Test-drive , Current Vehicle info. , Interest in Exchange ,   Remark   ,  Car Model  , Model year , Kilometer done , Prefer date time , Required Pickup , Date of entry ";
          
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        call();
    }
}