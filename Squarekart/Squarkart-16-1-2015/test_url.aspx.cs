using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_url : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_test_Click(object sender, EventArgs e)
    {
       Response.Redirect("http://119.82.74.68/squarekart/squareKart.ashx?mob=" + txtmob.Text + "&agentid=" + txtagent.Text + "&call_id=" + txtcall.Text);
        
        //Response.Redirect("<script>alert('Form submitted!!!'); location.href=' http://119.82.74.68/squarekart/squareKart.ashx?mob='" + txtmob.Text + "'&agentid='" + txtagent.Text + "'&call_id='" + txtcall.Text + "'</script>");

    }
}