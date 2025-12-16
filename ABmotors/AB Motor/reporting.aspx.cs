using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class reporting : System.Web.UI.Page
{
    DAL dobj = new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            try
            {
                if (Session["role"].ToString() == "ADMIN")
                { }
                else
                    Response.Redirect("<script> alert('Session Timeout !!!'); location.href='Default.aspx'</script>");
              
            }
            catch (Exception)
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }
            BindData();
        }
    }
    protected void BindData()
    {
        try
        {
            GridView1.DataSource = dobj.map_show();
            GridView1.DataBind();
        }
        catch { }
    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }
    protected void EditCustomer(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            //  string ID = ((Label)GridView1.Rows[e.RowIndex]
            //       .FindControl("lblID")).Text;
            string called_number = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtCnum")).Text;
            string pass = ((TextBox)GridView1.Rows[e.RowIndex]
                               .FindControl("txtpass")).Text;
            string agentlist = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtAgList")).Text;
            string id = ((Label)GridView1.Rows[e.RowIndex]
                                .FindControl("lblID")).Text;
            dobj.map_update(called_number.ToString(), agentlist.ToString(), id.ToString(),pass.ToString());

            GridView1.EditIndex = -1;
            BindData();
        }
        catch { }

    }

    protected void DeleteCustomer(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkRemove = (LinkButton)sender;
            dobj.map_delete(lnkRemove.CommandArgument);
            BindData();

        }
        catch { }
    }
    protected void AddNewCustomer(object sender, EventArgs e)
    {
        try
        {
            string id = ((TextBox)GridView1.FooterRow.FindControl("txtid")).Text;
            string pass = ((TextBox)GridView1.FooterRow.FindControl("txtpass")).Text;
            string called_number = ((TextBox)GridView1.FooterRow.FindControl("txtCnum")).Text;
            string agentlist = ((TextBox)GridView1.FooterRow.FindControl("txtAgList")).Text;
            dobj.map_insert(id.ToString(),called_number.ToString(), agentlist.ToString(),pass.ToString());
            BindData();
        }
        catch { }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin_details.aspx");
    }
}