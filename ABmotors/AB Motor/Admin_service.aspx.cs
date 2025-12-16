using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;

public partial class service : System.Web.UI.Page
{
    DAL dobj = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count < 1)
            Server.Transfer("Default.aspx");
        if (!IsPostBack) 
        {
            bind_loc();

            if (Request.QueryString.Count == 1 && Request.QueryString["ticket"].ToString() != "")
            {
                DataSet ds = new DataSet();
                ds = dobj.dashboard_edit_service(Request.QueryString["ticket"].ToString());
                txtname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                txtalternate.Text = ds.Tables[0].Rows[0]["alternate_no"].ToString();
                txtalternate2.Text = ds.Tables[0].Rows[0]["alternate_no2"].ToString();
                txtemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                DropDownsourceenq.SelectedValue = ds.Tables[0].Rows[0]["source"].ToString();
                DropDownmodel.SelectedValue = ds.Tables[0].Rows[0]["car_model"].ToString();
                DropDownloc.SelectedValue = ds.Tables[0].Rows[0]["location"].ToString();
                txtcustomer_loc.Text = ds.Tables[0].Rows[0]["customer_loc"].ToString();
                txtyear.Text = ds.Tables[0].Rows[0]["model_year"].ToString();
                txtkm.Text = ds.Tables[0].Rows[0]["km_done"].ToString();
                txtVhRegNo.Text = ds.Tables[0].Rows[0]["vehicle_reg_no"].ToString();
                string[] prefer = ds.Tables[0].Rows[0]["prefer_date_time"].ToString().Split(' ');
                int temp = prefer.Length;
                if (temp > 0)
                    txtprefer_dat.Text = prefer[0];
                if (temp == 2)
                    DropDownList1.SelectedValue = prefer[1];
                Radiodiesel.SelectedValue = ds.Tables[0].Rows[0]["diesel_petrol"].ToString();
                Radiopick.SelectedValue = ds.Tables[0].Rows[0]["required_pickup"].ToString();
                txtremark.Text = ds.Tables[0].Rows[0]["remark"].ToString();
            }
        }
    }
    public void bind_loc() // populate location dropdownlist
    {
        DropDownloc.DataSource = dobj.populate_location();
        DropDownloc.DataTextField = "location";
        DropDownloc.DataValueField = "location";
        DropDownloc.DataBind();
        DropDownloc.Items.Insert(0, new ListItem("--"));

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string prefer_dt = txtprefer_dat.Text + " " + DropDownList1.SelectedItem.Text;
        if (Request.QueryString.Count == 1 && Request.QueryString["ticket"] != null)
        {
            dobj.service_update(txtname.Text, txtalternate.Text, txtemail.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, txtyear.Text, txtkm.Text, prefer_dt.ToString(), Radiopick.SelectedValue, txtremark.Text, Request.QueryString["ticket"].ToString(), txtalternate2.Text, txtcustomer_loc.Text, txtVhRegNo.Text);
            Response.Write("<script> alert('Form updated Sucessfully!!!');location.href='dashboard_admin_service.aspx'</script>");
     
        }
        else
        {
            string show_tic = dobj.service_insert(txtname.Text, Session["user_id"].ToString(), txtalternate.Text, txtemail.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, txtyear.Text, txtkm.Text, prefer_dt.ToString(), Radiopick.SelectedValue, txtremark.Text, txtalternate2.Text, txtcustomer_loc.Text, txtVhRegNo.Text);
            dobj.sendMailservice(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, txtyear.Text, txtkm.Text, prefer_dt.ToString(), Radiopick.SelectedValue, txtremark.Text, show_tic, txtcustomer_loc.Text, txtVhRegNo.Text, Session["user_id"].ToString());
            //Thread thread = new Thread(() => dobj.sendMailservice(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, txtyear.Text, txtkm.Text, prefer_dt.ToString(), Radiopick.SelectedValue, txtremark.Text, show_tic, txtcustomer_loc.Text, txtVhRegNo.Text, Session["user_id"].ToString()));
            //thread.Start();
            Thread thread5 = new Thread(() => dobj.msg_service(txtname.Text, txtalternate.Text, show_tic, txtemail.Text, DropDownloc.SelectedItem.Text, txtcustomer_loc.Text, Radiopick.SelectedValue, DropDownmodel.SelectedItem.Text));
            thread5.Start();
            Response.Write("<script> alert('Ticket ID is: " + show_tic + ". Form Submitted Sucessfully!!!');location.href='dashboard_admin_service.aspx'</script>");
        }
    }
    protected void Button2sale_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin_sales.aspx");
    }
    protected void Button1service_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin_service.aspx");
    }
}