using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DAL dobj = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            call();
        }
        
    }
    public void call() 
    {
        try
        {
            if (Session["role"].ToString() == "ADMIN")
                Linkreport.Enabled = true;
         
            if (Session["user_id"] != null)
                lbluser.Text = Session["user_id"].ToString();
            else
                Response.Redirect("Default.aspx");
        }
        catch (Exception) 
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
    protected void Linklogout_Click(object sender, EventArgs e)
    {
        dobj.logout();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
    protected void Linkreport_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporting.aspx");
    }
  
    protected void Linksaleservice_Click(object sender, EventArgs e)
    {
        if (Session["role"].ToString() == "SALE")
            Response.Redirect("sales.aspx");
            if (Session["role"].ToString() == "SERVICE")
                Response.Redirect("service.aspx");
        if(Session["role"].ToString() == "ADMIN")
            Response.Redirect("ADMIN_sales.aspx");
    }
    protected void btnDone_Click(object sender, EventArgs e)
    {
        string accept = "accept";
        dobj.popup_accept(lblid.Text);
        if (lblremark.Text != "")
        {
            if (txtremark.Text != "")
           // {
                dobj.popup_remark(Hiddentic.Value, lblremark.Text, txtremark.Text);
               // lblerremark.Text = "";
               // lblid.Text = lblremark.Text = txtremark.Text = lblPop.Text = lblheading.Text = string.Empty;
                //lblremark.Visible = txtremark.Visible = false;
            //}
           // else 
          //  {
               // lblerremark.Text = "* Enter Remark ";
                //this.ModalPopupExtender1.Show();
           // }
        }
        else
        {
            if (Session["role"].ToString() == "SALE")
            {
                if (Hidden_ext.Value == "1")
                    
                 Response.Redirect("sales.aspx?tic=" + Hiddentic.Value + "&mob="+ lblPop.Text.Replace("+","%2B") );
              
                  //  Response.Redirect("sales.aspx?tic=" + Hiddentic.Value + "&mob=" + lblPop.Text);
                else
                    Response.Write("<script> alert('Invalid extension!!!');location.href='dashboard_sale.aspx'</script>");

            }
            // Response.Redirect("sales.aspx?mob=" + lblPop.Text + "&agentid=" + Session["userid"].ToString() + "&accept=" + accept);
            else if (Session["role"].ToString() == "SERVICE")
            {
                if (Hidden_ext.Value == "2")
                    Response.Redirect("service.aspx?tic=" + Hiddentic.Value + "&mob=" + lblPop.Text.Replace("+", "%2B"));
                else
                    Response.Write("<script> alert('Invalid extension!!!');location.href='dashboard_service.aspx'</script>");
            }
            // Response.Redirect("service.aspx?mob=" + lblPop.Text + "&agentid=" + Session["userid"].ToString() + "&accept=" + accept);
            else { }
           // lblid.Text = lblremark.Text = txtremark.Text = lblPop.Text = lblheading.Text = string.Empty;
           // lblremark.Visible = txtremark.Visible = false;
        }
        lblid.Text = lblremark.Text = txtremark.Text = lblPop.Text = lblheading.Text = string.Empty;
        lblremark.Visible = txtremark.Visible = false;
     
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        dobj.popup_busy(lblid.Text);

    }
    protected void chk(object sender, EventArgs e)
    {
        
        if (Session["user_id"] != null)
        {
            if (Session["role"].ToString() != "ADMIN")
            {
                lblPop.Text = "";
                lblpop1.Text = "";
                lblremark.Text = "";
                int i = Convert.ToInt32(dobj.check_count1(Session["user_id"].ToString()));
                if (i > 0)
                {
                    
                    DataSet ds = new DataSet();
                    ds = dobj.check_count_popup2(Session["user_id"].ToString());
                    //string mob = ds.Tables[0].Rows[0]["mobile"].ToString();
                    lblPop.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
                    string ext = ds.Tables[0].Rows[0]["ext"].ToString();
                    Hidden_ext.Value = ext.ToString();
                    // mobpass = mob.ToString();
                    int m_read = Convert.ToInt32(dobj.complaint_read_popup(lblPop.Text));
                    if (m_read != 0)
                    {
                        DataSet ds2 = new DataSet();
                        ds2 = dobj.bg_fetch_popup(lblPop.Text);
                        lblheading.Text = "Remark";
                        lblremark.Visible = true;
                        txtremark.Visible = true;
                        //btnDone.Text = "Submit";
                        lblpop1.Text = "Name: "+ds2.Tables[0].Rows[0]["name"].ToString();
                        lblremark.Text = ds2.Tables[0].Rows[0]["remark"].ToString();
                        Hiddentic.Value = ds2.Tables[0].Rows[0]["ticket"].ToString();
                    }
                    lblid.Text = ds.Tables[0].Rows[0]["id"].ToString();
                    hfUid.Value = ds.Tables[0].Rows[0]["call_id"].ToString();
                    this.ModalPopupExtender1.Show();
                }
                
            }
        }
        
    }
    protected void Linkdashboard_Click(object sender, EventArgs e)
    {
        if (Session["role"].ToString() == "SALE")
            Response.Redirect("dashboard_sale.aspx");
        if (Session["role"].ToString() == "SERVICE")
            Response.Redirect("dashboard_service.aspx");
        if (Session["role"].ToString() == "ADMIN")
            Response.Redirect("dashboard_admin_sale.aspx");
    }
}
