using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Agent_mapping : System.Web.UI.Page
{
    DAL dobj=new DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["heading"] = "Agent Mapping";
        //if (Session.Count <= 0)
        //    Response.Redirect("Login.aspx");
        //else if (Session["role"] == "AGENT")
        //    Response.Redirect("dashboard.aspx");

        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void BindData()
    {
        try
        {
                    GridView1.DataSource =dobj.map_show();
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
            string agentlist = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtAgList")).Text;
            dobj.map_update( called_number.ToString(), agentlist.ToString());

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
            string called_number = ((TextBox)GridView1.FooterRow.FindControl("txtCnum")).Text;
            string agentlist = ((TextBox)GridView1.FooterRow.FindControl("txtAgList")).Text;
            dobj.map_insert(called_number.ToString(), agentlist.ToString());
            BindData();
        }
        catch { }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}