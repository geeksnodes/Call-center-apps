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

            if (Request.QueryString.Count >= 1)
            {
                int i = 0;
                DataSet ds = new DataSet();
                if (Request.QueryString["ticket"] != null)
                {
                    i = Convert.ToInt32(dobj.edit_count(Request.QueryString["ticket"].ToString()));
                    ds = dobj.dashboard_edit_service(Request.QueryString["ticket"].ToString());
                } if (Request.QueryString["tic"] != null)
                {
                    i = Convert.ToInt32(dobj.edit_count(Request.QueryString["tic"].ToString()));
                    ds = dobj.dashboard_edit_service(Request.QueryString["tic"].ToString());
                }
                if (i == 1)
                {
                    txtname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    txtalternate.Text = ds.Tables[0].Rows[0]["alternate_no"].ToString();
                    txtalternate2.Text = ds.Tables[0].Rows[0]["alternate_no2"].ToString();
                    txtemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                    DropDownloc.SelectedValue = ds.Tables[0].Rows[0]["location"].ToString();
                    DropDownsourceenq.SelectedValue = ds.Tables[0].Rows[0]["source"].ToString();
                    DropDownmodel.SelectedValue = ds.Tables[0].Rows[0]["car_model"].ToString();
                    txtcustomer_loc.Text = ds.Tables[0].Rows[0]["customer_loc"].ToString();
                    txtyear.Text = ds.Tables[0].Rows[0]["model_year"].ToString();
                    txtkm.Text = ds.Tables[0].Rows[0]["km_done"].ToString();
                    txtVhRegNo.Text = ds.Tables[0].Rows[0]["vehicle_reg_no"].ToString();
                    string aa = ds.Tables[0].Rows[0]["prefer_date_time"].ToString();
                    string[] prefer = ds.Tables[0].Rows[0]["prefer_date_time"].ToString().Split(' ');
                    int temp = prefer.Length;
                    if (temp >0)
                    txtprefer_dat.Text = prefer[0];
                        if(temp==2)
                            DropDownList1.SelectedValue = prefer[1];
                    Radiodiesel.SelectedValue = ds.Tables[0].Rows[0]["diesel_petrol"].ToString();
                    Radiopick.SelectedValue = ds.Tables[0].Rows[0]["required_pickup"].ToString();
                    txtremark.Text = ds.Tables[0].Rows[0]["remark"].ToString();
                }

                if (Request.QueryString["tic"] != null && Request.QueryString["mob"] != null)
                {
                    txtalternate.Text = Request.QueryString["mob"].ToString();
                }
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
            dobj.service_update(txtname.Text, txtalternate.Text, txtemail.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, txtyear.Text, txtkm.Text, prefer_dt.ToString(), Radiopick.SelectedValue, txtremark.Text, Request.QueryString["ticket"].ToString(), txtalternate2.Text, txtcustomer_loc.Text,txtVhRegNo.Text );

            Response.Write("<script> alert('Form updated Sucessfully!!!');location.href='dashboard_service.aspx'</script>");

        }
        else
        {
            if (Request.QueryString.Count == 1 && Request.QueryString["popup_keypress"] != "")
            {
                string show_tic1 = dobj.service_insert(txtname.Text, Session["user_id"].ToString(), txtalternate.Text, txtemail.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, txtyear.Text, txtkm.Text, prefer_dt.ToString(), Radiopick.SelectedValue, txtremark.Text, txtalternate2.Text, txtcustomer_loc.Text,txtVhRegNo.Text );
                dobj.sendMailservice(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, txtyear.Text, txtkm.Text, prefer_dt.ToString(), Radiopick.SelectedValue, txtremark.Text, show_tic1, txtcustomer_loc.Text, txtVhRegNo.Text, Session["user_id"].ToString());
                //Thread thread = new Thread(() => dobj.sendMailservice(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, txtyear.Text, txtkm.Text, prefer_dt.ToString(), Radiopick.SelectedValue, txtremark.Text, show_tic1, txtcustomer_loc.Text, txtVhRegNo.Text, Session["user_id"].ToString()));
                //thread.Start();
                Thread thread9 = new Thread(() => dobj.msg_service(txtname.Text, txtalternate.Text, show_tic1, txtemail.Text, DropDownloc.SelectedItem.Text, txtcustomer_loc.Text, Radiopick.SelectedValue, DropDownmodel.SelectedItem.Text));
                thread9.Start();
                if (show_tic1.ToString() != "")
                    dobj.call_log_update(Request.QueryString["popup_keypress"].ToString());
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "onAddNew", "window.close();", true);
            }
            else
            {
                string show_tic = dobj.service_insert(txtname.Text, Session["user_id"].ToString(), txtalternate.Text, txtemail.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, txtyear.Text, txtkm.Text, prefer_dt.ToString(), Radiopick.SelectedValue, txtremark.Text, txtalternate2.Text, txtcustomer_loc.Text,txtVhRegNo.Text );
                dobj.sendMailservice(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, txtyear.Text, txtkm.Text, prefer_dt.ToString(), Radiopick.SelectedValue, txtremark.Text, show_tic, txtcustomer_loc.Text, txtVhRegNo.Text, Session["user_id"].ToString());
                //Thread thread = new Thread(() => dobj.sendMailservice(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, txtyear.Text, txtkm.Text, prefer_dt.ToString(), Radiopick.SelectedValue, txtremark.Text, show_tic, txtcustomer_loc.Text, txtVhRegNo.Text, Session["user_id"].ToString()));
                //thread.Start();
                Thread thread10 = new Thread(() => dobj.msg_service(txtname.Text, txtalternate.Text, show_tic, txtemail.Text, DropDownloc.SelectedItem.Text, txtcustomer_loc.Text, Radiopick.SelectedValue, DropDownmodel.SelectedItem.Text));
                thread10.Start();
                Response.Write("<script> alert('Ticket ID is: " + show_tic + ". Form Submitted Sucessfully!!!');location.href='dashboard_service.aspx'</script>");
            }
        }
    }
   
}