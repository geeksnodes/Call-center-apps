using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;

public partial class sales : System.Web.UI.Page
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
                //string a = Request.QueryString["tic"].ToString();
                if (Request.QueryString["ticket"] != null)
                {
                    i = Convert.ToInt32(dobj.edit_count(Request.QueryString["ticket"].ToString()));
                    ds = dobj.dashboard_edit(Request.QueryString["ticket"].ToString());
                }
                if (Request.QueryString["tic"] != null)
                {
                    i = Convert.ToInt32(dobj.edit_count(Request.QueryString["tic"].ToString()));
                    ds = dobj.dashboard_edit(Request.QueryString["tic"].ToString());
                }
                if (i == 1)
                {
                    txtname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    txtalternate.Text = ds.Tables[0].Rows[0]["alternate_no"].ToString();
                    txtalternate2.Text = ds.Tables[0].Rows[0]["alternate_no2"].ToString();
                    txtemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                    txtprof.Text = ds.Tables[0].Rows[0]["profession"].ToString();
                    DropDownloc.SelectedValue = ds.Tables[0].Rows[0]["location"].ToString();
                    txtcustomer_loc.Text = ds.Tables[0].Rows[0]["customer_loc"].ToString();
                    DropDownsourceenq.SelectedValue = ds.Tables[0].Rows[0]["source"].ToString();
                    DropDownmodel.SelectedValue = ds.Tables[0].Rows[0]["model_interest"].ToString();
                    Radiodiesel.SelectedValue = ds.Tables[0].Rows[0]["diesel_petrol"].ToString();
                    Radiotest.SelectedValue = ds.Tables[0].Rows[0]["test_drive"].ToString();
                    txtvehicle.Text = ds.Tables[0].Rows[0]["current_vehicle_info"].ToString();
                    Radioexchange.SelectedValue = ds.Tables[0].Rows[0]["interest_in_exchange"].ToString();
                    txtremark.Text = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (Request.QueryString["tic"] != null && Request.QueryString["mob"] != null)
                {
                    txtalternate.Text = Request.QueryString["mob"].ToString();
                 }
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 1 && Request.QueryString["ticket"] != null)
        {
            dobj.sale_update(txtname.Text, txtalternate.Text, txtemail.Text, txtprof.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, Radiotest.SelectedValue, txtvehicle.Text, Radioexchange.SelectedValue, txtremark.Text, Request.QueryString["ticket"].ToString(), txtalternate2.Text, txtcustomer_loc.Text);
            Response.Write("<script> alert('Form updated Sucessfully!!!');location.href='dashboard_sale.aspx'</script>");
        }
        else
        {
            if (Request.QueryString.Count == 1 && Request.QueryString["popup_keypress"] != "")
            {
                string show_tic1= dobj.sale_insert(txtname.Text, Session["user_id"].ToString(), txtalternate.Text, txtemail.Text, txtprof.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, Radiotest.SelectedValue, txtvehicle.Text, Radioexchange.SelectedValue, txtremark.Text, txtalternate2.Text, txtcustomer_loc.Text);
                dobj.sendMailsale(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, txtprof.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, Radiotest.SelectedValue, txtvehicle.Text, Radioexchange.SelectedValue, txtremark.Text, show_tic1, txtcustomer_loc.Text, Session["user_id"].ToString());
                //Thread thread = new Thread(() => dobj.sendMailsale(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, txtprof.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, Radiotest.SelectedValue, txtvehicle.Text, Radioexchange.SelectedValue, txtremark.Text, show_tic1, txtcustomer_loc.Text, Session["user_id"].ToString()));
                //thread.Start();
                Thread thread6 = new Thread(() => dobj.msg_sale(txtname.Text, txtalternate.Text, show_tic1, DropDownmodel.SelectedItem.Text, DropDownloc.SelectedItem.Text, txtcustomer_loc.Text, Radiotest.SelectedValue));
                thread6.Start();
                if (show_tic1.ToString() != "")
                    dobj.call_log_update(Request.QueryString["popup_keypress"].ToString());
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "onAddNew", "window.close();", true);

            }
            else
            {
                string show_tic = dobj.sale_insert(txtname.Text, Session["user_id"].ToString(), txtalternate.Text, txtemail.Text, txtprof.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, Radiotest.SelectedValue, txtvehicle.Text, Radioexchange.SelectedValue, txtremark.Text, txtalternate2.Text, txtcustomer_loc.Text);
                dobj.sendMailsale(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, txtprof.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, Radiotest.SelectedValue, txtvehicle.Text, Radioexchange.SelectedValue, txtremark.Text, show_tic, txtcustomer_loc.Text, Session["user_id"].ToString());
                //Thread thread = new Thread(() => dobj.sendMailsale(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, txtprof.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, Radiotest.SelectedValue, txtvehicle.Text, Radioexchange.SelectedValue, txtremark.Text, show_tic, txtcustomer_loc.Text, Session["user_id"].ToString()));
                //thread.Start();
                Thread thread7 = new Thread(() => dobj.msg_sale(txtname.Text, txtalternate.Text, show_tic, DropDownmodel.SelectedItem.Text, DropDownloc.SelectedItem.Text, txtcustomer_loc.Text, Radiotest.SelectedValue));
                thread7.Start();
                Response.Write("<script> alert('Ticket ID is: " + show_tic + ". Form Submitted Sucessfully!!!');location.href='dashboard_sale.aspx'</script>");
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
}