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
        if (!IsPostBack) 
        {
            bind_loc();
            if (Request.QueryString.Count == 1 && Request.QueryString["popup_keypress"] != "")
            {
             string mob_temp= dobj.call_log_fetch_mobile(Request.QueryString["popup_keypress"].ToString()).ToString();
             string caller_number = mob_temp.Substring(mob_temp.Length - 10);
             txtalternate.Text = caller_number.ToString();
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 1 && Request.QueryString["popup_keypress"] != "")
        {
            string show_tic1 = dobj.sale_insert(txtname.Text, Session["user_id"].ToString(), txtalternate.Text, txtemail.Text, txtprof.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, Radiotest.SelectedValue, txtvehicle.Text, Radioexchange.SelectedValue, txtremark.Text, txtalternate2.Text, txtcustomer_loc.Text);
            dobj.sendMailsale(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, txtprof.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, Radiotest.SelectedValue, txtvehicle.Text, Radioexchange.SelectedValue, txtremark.Text, show_tic1, txtcustomer_loc.Text, Session["user_id"].ToString());
            //Thread thread = new Thread(() => dobj.sendMailsale(txtname.Text, txtalternate.Text, txtalternate2.Text, txtemail.Text, txtprof.Text, DropDownloc.SelectedItem.Text, DropDownsourceenq.SelectedItem.Text, DropDownmodel.SelectedItem.Text, Radiodiesel.SelectedValue, Radiotest.SelectedValue, txtvehicle.Text, Radioexchange.SelectedValue, txtremark.Text, show_tic1, txtcustomer_loc.Text, Session["user_id"].ToString()));
            //thread.Start();
            Thread thread2 = new Thread(() => dobj.msg_sale(txtname.Text, txtalternate.Text, show_tic1, DropDownmodel.SelectedItem.Text, DropDownloc.SelectedItem.Text, txtcustomer_loc.Text, Radiotest.SelectedValue));
            thread2.Start();
            if (show_tic1.ToString() != "")
                dobj.call_log_update(Request.QueryString["popup_keypress"].ToString());
            Response.Write("<script> alert('Ticket ID is: " + show_tic1 + ". Form Submitted Sucessfully!!!');location.href='dashboard_sale.aspx'</script>");
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "onAddNew", "window.close();", true);
          
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