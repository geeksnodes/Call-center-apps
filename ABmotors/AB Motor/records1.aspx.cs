using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class records1 : System.Web.UI.Page
{
    DAL dobj = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count < 1)
            Server.Transfer("Default.aspx");
        if (!IsPostBack) 
        {
            call2();
        }
    }
    protected void gvrecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvrecords.PageIndex = e.NewPageIndex;
        call2();
    }
    public void call() 
    {
        gvrecords.DataSource = dobj.call_log_page_load();
        gvrecords.DataBind();
    }
    protected void gvrecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        { int i = 1;
            Label chk1 = (Label)e.Row.FindControl("lblstatus");
         
            if (!string.IsNullOrEmpty(chk1.Text))
            {
                if (chk1.Text == "Missed")
                {
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                   
                }
                if (chk1.Text == "Connected")
                {
                    //e.Row.Cells[0].Visible = false;
                   // Label lb1temp = new Label();
                    //lb1temp.Text = "hii";
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[1].Text = "";
                    //e.Row.Cells[0].Controls.Add(lb1temp);
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[0].Enabled = false;
                }
                if (chk1.Text == "Called Back")
                {
                    e.Row.Cells[0].Text = "";
                    e.Row.Cells[1].Text = "";
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[0].Enabled = false;
                }
                if (chk1.Text == "Not Connected")
                {
                   // e.Row.Cells[0].Enabled = false;
                    // e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;

                }
               
            }
       }
    }

    protected void Call_log_details_edit(object sender, EventArgs e) 
    {
        LinkButton btnlin_missed = (LinkButton)sender;
        hidden_missed.Value = btnlin_missed.CommandArgument.ToString();
        ModalPopup_call_log.Show();
    }
    protected void btnup(object sender, EventArgs e)
    {
        LinkButton btnUpdate = (LinkButton)sender;
            if (btnUpdate.CommandName.ToString() == "1")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'call_log/sales.aspx?popup_keypress=" + btnUpdate.CommandArgument + "', null, 'height=550,width=1000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
              
               // gvrecords.EditIndex = -1;
                call2();
            }
            if (btnUpdate.CommandName.ToString() == "2")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'call_log/service.aspx?popup_keypress=" + btnUpdate.CommandArgument + "', null, 'height=550,width=1000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                
               // gvrecords.EditIndex = -1;
                call2();
            }
           // dobj.call_log_update(btnUpdate.CommandArgument);
                //gvrecords.EditIndex = -1;
                //call2();
           
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        call2();
    }
    public void call2() 
    {
        gvrecords.DataSource = dobj.call_log_show_search(txtstart.Text, txtend.Text, DropDownstatus.SelectedItem.Text);
        gvrecords.DataBind();
    }
    protected void calllog_ok(object sender, EventArgs e)
    {
       // int i = Convert.ToInt32(dobj.call_log_update_chk(txt_reference.Text));
       // if (i == 1)
        //{
        dobj.call_log_update2(txt_reference.Text, hidden_missed.Value);
            txt_reference.Text = string.Empty;
            call2();
       // }
       // else
       // {
          //  calllog_err.Text = "Invalid Ticket no.!!!";
         //   ModalPopup_call_log.Show();
        //}
    }
    
}