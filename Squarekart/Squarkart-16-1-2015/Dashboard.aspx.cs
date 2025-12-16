using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;

public partial class Dashboard : System.Web.UI.Page
{
    DAL dobj = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["heading"] = "Dashboard";
            if (!IsPostBack)
            {
                //callToday();
		        call() ;
            }
        }
        catch (Exception) 
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        call();
    }
    public void call() 
    {
        GridView1.DataSource = dobj.search_dashboard(txtfrom.Text, txtto.Text, txtmob.Text, txtname.Text);
        GridView1.DataBind();
    }
    protected void btnview_Click(object sender, EventArgs e)
    {
            int count = 0; 
            string temp = "";
            foreach (GridViewRow gv in GridView1.Rows)
            {
                CheckBox chk1 = (CheckBox)gv.Cells[0].FindControl("CheckBox1");

                if (chk1.Checked == true)
                {
                    count += 1;
                }
            }
            if (count <= 1)
            {
                foreach (GridViewRow gv in GridView1.Rows)
                {
                    CheckBox chk1 = (CheckBox)gv.Cells[0].FindControl("CheckBox1");

                    if (chk1.Checked == true)
                    {
                        Label lbltic = (Label)gv.Cells[1].FindControl("lblticket");
                        temp = lbltic.Text;
                        break;
                    }
                }
                string view = "view";
                if (temp != "")
                {
                    Response.Redirect("customer_profile.aspx?tic=" + temp.ToString() + "&view=" + view);
                }
                else
                {
                    Response.Write("<script> alert('Please select atleast 1 row')</script>");
                    // Response.Write("<script> alert('Please select atleast 1 row');location.href='Dashboard.aspx'</script>");
                    //Response.Redirect("Dashboard.aspx");
                }
            }
            else
                Response.Write("<script> alert('Please select 1 row')</script>");
               
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
      
            find_checked();
      
    }
    public void find_checked() 
    {
        int count = 0; 
       string temp="";
       foreach (GridViewRow gv in GridView1.Rows)
       {
           CheckBox chk1 = (CheckBox)gv.Cells[0].FindControl("CheckBox1");

           if (chk1.Checked == true)
           {
                count += 1;
           }
       }
       if (count <= 1)
       {
           foreach (GridViewRow gv in GridView1.Rows)
           {
               CheckBox chk1 = (CheckBox)gv.Cells[0].FindControl("CheckBox1");

               if (chk1.Checked == true)
               {
                   Label lbltic = (Label)gv.Cells[1].FindControl("lblticket");
                   temp = lbltic.Text;
                   break;
               }
           }

           if (temp != "")
           {
               string edit = "edit";
               Response.Redirect("customer_profile.aspx?tic=" + temp.ToString() + "&edit=" + edit.ToString());
           }
           else
           {
               Response.Write("<script> alert('Please select atleast 1 row')</script>");
               //Response.Write("<script> alert('Please select atleast 1 row');location.href='Dashboard.aspx'</script>");
               //Response.Redirect("Dashboard.aspx");
           }
       }
           else
           Response.Write("<script> alert('Please select 1 row')</script>");
               
       
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "print")
        {
            PrintTicket(e.CommandArgument.ToString());
        }
    }
    protected void PrintTicket(string tid)
    {
        
        DetailsView1.DataSource = dobj.print_complaint(tid);
        DetailsView1.DataBind();
        this.mpePrint.Show();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        call();
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("customer_profile.aspx");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnXls_Click(object sender, EventArgs e)
    {
        try
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Response.ClearContent();
            Response.Charset = "";

            htw.Write("<table border=2><b><tr><td align=center>Name</td><td>Mobile No.</td><td>Alternate No.</td><td align=center>Email</td><td>Date of Birth</td><td>Gender</td><td>Marital Status</td><td align=center>Spouse Name</td><td>Spouse Mobile</td><td>Spouse Alternate No.</td><td>Spouse Date of Birth</td><td align=center>Residential Address</td><td align=center>Official Address</td><td>Car</td><td>Car Brand</td><td>Car No.</td><td align=center>Father Name</td><td>Father Mobile No.</td><td>Father Date of Birth</td><td align=center>Mother Name</td><td>Mother Mobile No.</td><td>Mother Date of Birth</td><td align=center>Brother Name</td><td>Brother Mobile No.</td><td>Brother Date of Birth</td><td align=center>Sister Name</td><td>Sister Mobile No.</td><td>Sister Date of Birth</td><td>Credit Card No.</td align=center><td>Delivery Address</td><td>Anniversary Date</td><td>No. of Child</td><td>Child Name</td><td>Child Mobile no.</td><td align=center>Child School</td><td>Child Name</td><td>Child Mobile no.</td><td align=center>Child School</td><td>Child Name</td><td>Child Mobile no.</td><td align=center>Child School</td><td>Child Name</td><td>Child Mobile no.</td><td align=center>Child School</td><td>Child Name</td><td>Child Mobile no.</td><td align=center>Child School</td><td>Date</td><td>Ticket No.</td><td>Temprorary</td><td>Temprorary</td><td>Temprorary</td></tr></b></table>");


            Response.ClearContent();
            Response.Charset = "";
            Response.AddHeader("content-disposition", "attachment; filename=Squarekart_log.xls");
            Response.ContentType = "application/vnd.ms-excel";
            GridView gridExcel = new GridView();
             gridExcel.ShowHeader = false;


            // gridExcel.HeaderStyle.ForeColor = System.Drawing.Color.FromName("White");
            // gridExcel.HeaderStyle.ForeColor = System.Drawing.Color.FromName("Black");
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

            gridExcel.DataSource = dobj.eport_dashboard(txtfrom.Text, txtto.Text, txtmob.Text, txtname.Text);
            gridExcel.DataBind();
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            gridExcel.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        catch { }
    }
}