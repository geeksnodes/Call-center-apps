using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;


public partial class mapagent : System.Web.UI.Page
{
    private String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conKnowlarity"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
            Response.Redirect("Login.aspx");
        else if(Session["role"]=="AGENT")
            Response.Redirect("dashboard.aspx");

        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void BindData()
    {
        try
        {
            using (MySqlConnection con = new MySqlConnection(strConnString))
            {
                using (MySqlDataAdapter da = new MySqlDataAdapter("select id,called_number,agentlist from citelum_ui_agentmapping", con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
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
            string ID = ((Label)GridView1.Rows[e.RowIndex]
                            .FindControl("lblID")).Text;
            string called_number = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtCnum")).Text;
            string agentlist = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtAgList")).Text;
            using (MySqlConnection con = new MySqlConnection(strConnString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "update citelum_ui_agentmapping set called_number=?cnum, agentlist=?alist where id=?id";
                    cmd.Parameters.AddWithValue("?id", ID);
                    cmd.Parameters.AddWithValue("?cnum", called_number);
                    cmd.Parameters.AddWithValue("?alist", agentlist);
                    cmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                    BindData();

                }
            }
        }
        catch { }
     
    }

    protected void DeleteCustomer(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkRemove = (LinkButton)sender;
            using (MySqlConnection con = new MySqlConnection(strConnString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "delete from citelum_ui_agentmapping where id=?id";
                    cmd.Parameters.AddWithValue("?id", lnkRemove.CommandArgument);
                    cmd.ExecuteNonQuery();
                    BindData();
                }
            }
        }
        catch { }
    }
    protected void AddNewCustomer(object sender, EventArgs e)
    {
        try
        {
            string called_number = ((TextBox)GridView1.FooterRow.FindControl("txtCnum")).Text;
            string agentlist = ((TextBox)GridView1.FooterRow.FindControl("txtAgList")).Text;
            using (MySqlConnection con = new MySqlConnection(strConnString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into citelum_ui_agentmapping (called_number,agentlist) values(?cnum, ?alist)";
                    cmd.Parameters.AddWithValue("?cnum", called_number);
                    cmd.Parameters.AddWithValue("?alist", agentlist);
                    cmd.ExecuteNonQuery();
                    BindData();

                }
            }
        }
        catch { }
    }
}