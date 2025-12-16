using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class complaint : System.Web.UI.Page
{

    DAL dobj = new DAL();
    int temprory = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds=new DataSet();
        if (!IsPostBack) 
        {
            try
            {
                
                Session["heading"] = "New Customer";
                if (Request.QueryString.Count == 3 && Request.QueryString["mob"] != null && Request.QueryString["agentid"] != null && Request.QueryString["accept"] == "accept")
                {
                    temprory = 1;

                    int i = Convert.ToInt32(dobj.complaint_read_popup(Request.QueryString["mob"]));
                    if (i != 0)
                    {
                        ds = dobj.complaint_fetch_popup11(Request.QueryString["mob"].ToString());
                        autofill_details(ds);

                        txtspouse.Enabled = true;
                        txtspouse_mob.Enabled = true;
                        txtspouse_dob.Enabled = true;
                        txtspouse_alternate.Enabled = true;
                        Panelhigh.Visible = true;
                      
                    }
                    else
                    {
                        txtmob.Text = Request.QueryString["mob"].ToString();
                    }
                }
               if (Request.QueryString.Count == 2)
                {
                    if (Request.QueryString["tic"]!= null && Request.QueryString["view"] == "view")
                    {
                        temprory = 1;
                        // for view
                        DropDownchildren.AutoPostBack = false;
                        Panelhigh.Visible = true;
                        btnsubmit.Enabled = false;

                        string tic = Request.QueryString["tic"].ToString();
                        ds = dobj.edit_complaint(tic.ToString());

                        autofill_details(ds);
                        txtbrand.Enabled = true;
                        txtcar_no.Enabled = true;
                    }
                    if (Request.QueryString["tic"] != null && Request.QueryString["edit"] == "edit")
                    {
                        temprory = 1;
                        DropDownchildren.AutoPostBack = false;
                        txtspouse.Enabled = true;
                        txtspouse_mob.Enabled = true;
                        txtspouse_dob.Enabled = true;
                        txtspouse_alternate.Enabled = true;
                        Panelhigh.Visible = true;
                        btnsubmit.Enabled = true;
                        string tic = Request.QueryString["tic"].ToString();
                        ds = dobj.edit_complaint(tic.ToString());

                        autofill_details(ds);
                        txtbrand.Enabled = true;
                        txtcar_no.Enabled = true;
                    }
                }
            /*    if (Request.QueryString["tic"] != null)
                {
                   
                    string tic = Request.QueryString["tic"].ToString();
                    ds = dobj.edit_complaint(tic.ToString());

                    autofill_details(ds);
                    txtbrand.Enabled = true;
                    txtcar_no.Enabled = true;

                }*/
            }
            catch (Exception) 
            {
            
            }
        }

    }
    public void autofill_details( DataSet ds) 
    {
        int i_temp = 0;
        string name1 = ds.Tables[0].Rows[0]["uname"].ToString();
        string[] name2 = name1.Split(' ');
        txtname.Text = name2[0].ToString();
        txtname2.Text = name2[1].ToString();
        txtmob.Text = ds.Tables[0].Rows[0]["mobile_no"].ToString();
        txtalternate.Text = ds.Tables[0].Rows[0]["alternate_no"].ToString();
        txtemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
        Radiogender.SelectedValue = ds.Tables[0].Rows[0]["gender"].ToString();
        Radiomarital.SelectedValue = ds.Tables[0].Rows[0]["marital"].ToString();
        /*change by Ankit */
        if (Radiomarital.SelectedValue == "Married")
            pnlSpouse.Visible = true;

        /*change by Ankit end*/
        txtspouse.Text = ds.Tables[0].Rows[0]["spouse_name"].ToString();
        txtspouse_mob.Text = ds.Tables[0].Rows[0]["spouse_mobile"].ToString();
        txtspouse_alternate.Text = ds.Tables[0].Rows[0]["spouse_alternate"].ToString();
        txtspouse_dob.Text = ds.Tables[0].Rows[0]["spouse_dob"].ToString();
        txtresident.Text = ds.Tables[0].Rows[0]["resident_add"].ToString();
        txtofficial.Text = ds.Tables[0].Rows[0]["official_add"].ToString();
        txtdelivery.Text = ds.Tables[0].Rows[0]["delivery_add"].ToString();
        txtcredit.Text = ds.Tables[0].Rows[0]["credit_card_no"].ToString();
        txtfather_name.Text = ds.Tables[0].Rows[0]["f_name"].ToString();
        txtfather_mob.Text = ds.Tables[0].Rows[0]["f_mobile"].ToString();
        txtfather_dob.Text = ds.Tables[0].Rows[0]["f_dob"].ToString();
        txtmother_name.Text = ds.Tables[0].Rows[0]["m_name"].ToString();
        txtmother_mob.Text = ds.Tables[0].Rows[0]["m_mobile"].ToString();
        txtmotherdob.Text = ds.Tables[0].Rows[0]["m_dob"].ToString();
        txtbrother_name.Text = ds.Tables[0].Rows[0]["b_name"].ToString();
        txtbrother_mob.Text = ds.Tables[0].Rows[0]["b_mobile"].ToString();
        txtbrother_dob.Text = ds.Tables[0].Rows[0]["b_dob"].ToString();
        txtsister_name.Text = ds.Tables[0].Rows[0]["s_name"].ToString();
        txtsister_mob.Text = ds.Tables[0].Rows[0]["s_mobile"].ToString();
        txtsister_dob.Text = ds.Tables[0].Rows[0]["s_dob"].ToString();
        txtanniversary.Text = ds.Tables[0].Rows[0]["aniversary"].ToString();
        Radiocar.SelectedValue = ds.Tables[0].Rows[0]["car"].ToString();
        txtbrand.Text = ds.Tables[0].Rows[0]["car_brand"].ToString();
        txtcar_no.Text = ds.Tables[0].Rows[0]["car_no"].ToString();
        txtdob.Text = ds.Tables[0].Rows[0]["dob"].ToString();
        DropDownchildren.SelectedItem.Text = ds.Tables[0].Rows[0]["child"].ToString();



        i_temp = Convert.ToInt32(ds.Tables[0].Rows[0]["child"].ToString());

        string ch1 = ds.Tables[0].Rows[0]["c_name1"].ToString();
        string ch1m = ds.Tables[0].Rows[0]["c_mobile1"].ToString();
        string ch1s = ds.Tables[0].Rows[0]["c_school1"].ToString();
        string ch2 = ds.Tables[0].Rows[0]["c_name2"].ToString();
        string ch2m = ds.Tables[0].Rows[0]["c_mobile2"].ToString();
        string ch2s = ds.Tables[0].Rows[0]["c_school2"].ToString();
        string ch3 = ds.Tables[0].Rows[0]["c_name3"].ToString();
        string ch3m = ds.Tables[0].Rows[0]["c_mobile3"].ToString();
        string ch3s = ds.Tables[0].Rows[0]["c_school3"].ToString();
        string ch4 = ds.Tables[0].Rows[0]["c_name4"].ToString();
        string ch4m = ds.Tables[0].Rows[0]["c_mobile4"].ToString();
        string ch4s = ds.Tables[0].Rows[0]["c_school4"].ToString();
        string ch5 = ds.Tables[0].Rows[0]["c_name5"].ToString();
        string ch5m = ds.Tables[0].Rows[0]["c_mobile5"].ToString();
        string ch5s = ds.Tables[0].Rows[0]["c_school5"].ToString();



        string[,] details = { { ch1, ch1m, ch1s }, { ch2, ch2m, ch2s }, { ch3, ch3m, ch3s }, { ch4, ch4m, ch4s }, { ch5, ch5m, ch5s } };

        DataTable dt = new DataTable();
        dt.Columns.Add("StudentName");
        dt.Columns.Add("StudentMobile");
        dt.Columns.Add("StudentAddress");
        //dt.WriteXml();
        for (int i = 0; i < 5; i++)
        {
            dt.Rows.Add();
            for (int j = 0; j < 3; j++)
            {
                dt.Rows[i][j] = details[i, j].ToString();

            }
            dobj.tempchild(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), (i + 1).ToString());
        }
        GridView1.DataSource = dobj.tempchild1();
        GridView1.DataBind();
        dobj.tempchild2();//flush temp table
    }
    protected void DropDownchildren_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 1; i <= Convert.ToInt32(DropDownchildren.SelectedItem.Text); i++)
        {
            dobj.child_count(i);
        }
        call();
        dobj.child_count();
       
        btnsubmit.Visible = true;
    }
    public void call() 
    {
        GridView1.DataSource = dobj.child_show();
        GridView1.DataBind();
    }
    protected void Radiomarital_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Radiomarital.SelectedValue == "Married")
        {
            txtspouse.Enabled = true;
            txtspouse_mob.Enabled = true;
            txtspouse_dob.Enabled = true;
            txtspouse_alternate.Enabled = true;
            Panelhigh.Visible = true;
            btnsubmit.Visible = true;

            pnlSpouse.Visible = true;  //change by ankit
        }
        else 
        {
            txtspouse.Text = txtspouse_mob.Text = txtspouse_alternate.Text= txtspouse_dob.Text = "";
           // txtspouse.BackColor = txtspouse_mob.BackColor = txtspouse_alternate.BackColor = txtspouse_dob.BackColor = txtspouse_dob.BackColor = System.Drawing.Color.FromName("Gray");
            
            txtspouse.Enabled = false;
            txtspouse_mob.Enabled = false;
            txtspouse_dob.Enabled = false;
            txtspouse_alternate.Enabled = false;

            pnlSpouse.Visible = false;
            Panelhigh.Visible = false;
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int temp1 = 0;
            int temp3 = 0;
            int temp4 = 0;
            if (temprory == 0)
            {
                temp1 = Convert.ToInt32(dobj.check_reg(txtmob.Text));
            }
            int temp2 = temp1;
            Random random = new Random();
            int len = 10;
            string res = "";
            string temp = "0987654321";
            while (0 < len--)
            {
                res += temp[random.Next(temp.Length)];
            }


            string name = txtname.Text + " " + txtname2.Text;
            TextBox name1, mobile1, school1, name2, mobile2, school2, name3, mobile3, school3, name4, mobile4, school4, name5, mobile5, school5;
            string blank = "0";
            if (GridView1.Rows.Count == 1)
            {
                name1 = (TextBox)GridView1.Rows[0].Cells[1].FindControl("txtname1");
                mobile1 = (TextBox)GridView1.Rows[0].Cells[2].FindControl("txtmobile1");
                school1 = (TextBox)GridView1.Rows[0].Cells[3].FindControl("txtschool1");
                if (Request.QueryString["edit"] == "edit" && Request.QueryString["tic"] != null)
                {
                    temp1 = 0;
                    dobj.complaint_update(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank, blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), Request.QueryString["tic"].ToString());
                    temp4 = 1;
                }
                else
                {
                    if (Request.QueryString.Count == 3 && Request.QueryString["mob"] != null && Request.QueryString["agentid"] != null && Request.QueryString["accept"] == "accept")
                    {
                        if (temp2 == 1)
                        {
                            temp1 = 0;
                            dobj.complaint_update_mobile(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank, blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString());
                            temp4 = 1;
                        }
                        else
                        {
                            dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank, blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), res.ToString());
                            temp4 = 1;
                        }
                    }
                  if(temp4 ==0)
                    {
                        if(temp2==0)
                            dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank, blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), blank.ToString(), res.ToString());
                        else
                            temp3 = 1;
                    }
                }
            }
            else
                if (GridView1.Rows.Count == 2)
                {
                    name1 = (TextBox)GridView1.Rows[0].Cells[1].FindControl("txtname1");
                    mobile1 = (TextBox)GridView1.Rows[0].Cells[2].FindControl("txtmobile1");
                    school1 = (TextBox)GridView1.Rows[0].Cells[3].FindControl("txtschool1");
                    name2 = (TextBox)GridView1.Rows[1].Cells[1].FindControl("txtname1");
                    mobile2 = (TextBox)GridView1.Rows[1].Cells[2].FindControl("txtmobile1");
                    school2 = (TextBox)GridView1.Rows[1].Cells[3].FindControl("txtschool1");
                    if (Request.QueryString["edit"] == "edit" && Request.QueryString["tic"] != null)
                    {
                        temp1 = 0;
                        dobj.complaint_update(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, blank, blank, blank, blank, blank, blank, blank, blank, blank, Request.QueryString["tic"].ToString());
                        temp4 = 1;
                    }
                    else
                    {
                        if (Request.QueryString.Count == 3 && Request.QueryString["mob"] != null && Request.QueryString["agentid"] != null && Request.QueryString["accept"] == "accept")
                        {
                            if (temp2 == 1)
                            {
                                temp1 = 0;
                                dobj.complaint_update_mobile(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, blank, blank, blank, blank, blank, blank, blank, blank, blank);
                                temp4 = 1;
                            }
                            else
                            {
                                dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, blank, blank, blank, blank, blank, blank, blank, blank, blank, res.ToString());
                                temp4 = 1;
                            }   
                        }
                        if(temp4 ==0)
                        {
                            if (temp2 == 0)
                                dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, blank, blank, blank, blank, blank, blank, blank, blank, blank, res.ToString());
                            else
                                temp3 = 1;
                        }
                    }
                }
                else
                    if (GridView1.Rows.Count == 3)
                    {
                        name1 = (TextBox)GridView1.Rows[0].Cells[1].FindControl("txtname1");
                        mobile1 = (TextBox)GridView1.Rows[0].Cells[2].FindControl("txtmobile1");
                        school1 = (TextBox)GridView1.Rows[0].Cells[3].FindControl("txtschool1");
                        name2 = (TextBox)GridView1.Rows[1].Cells[1].FindControl("txtname1");
                        mobile2 = (TextBox)GridView1.Rows[1].Cells[2].FindControl("txtmobile1");
                        school2 = (TextBox)GridView1.Rows[1].Cells[3].FindControl("txtschool1");
                        name3 = (TextBox)GridView1.Rows[2].Cells[1].FindControl("txtname1");
                        mobile3 = (TextBox)GridView1.Rows[2].Cells[2].FindControl("txtmobile1");
                        school3 = (TextBox)GridView1.Rows[2].Cells[3].FindControl("txtschool1");
                        if (Request.QueryString["edit"] == "edit" && Request.QueryString["tic"] != null)
                        {
                            temp1 = 0;
                            dobj.complaint_update(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, blank, blank, blank, blank, blank, blank, Request.QueryString["tic"].ToString());
                            temp4 = 1;
                        }
                        else
                        {
                            if (Request.QueryString.Count == 3 && Request.QueryString["mob"] != null && Request.QueryString["agentid"] != null && Request.QueryString["accept"] == "accept")
                            {
                                if (temp2 == 1)
                                {
                                    temp1 = 0;
                                    
                                    dobj.complaint_update_mobile(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, blank, blank, blank, blank, blank, blank);
                                    temp4 = 1;
                                }
                                else
                                {
                                    dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, blank, blank, blank, blank, blank, blank, res.ToString());
                                    temp4 = 1;
                                }
                            }
                          if(temp4 ==0)
                            {
                                if (temp2 == 0)
                                {
                                    dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, blank, blank, blank, blank, blank, blank, res.ToString());
                                    temp4 = 1;
                                }
                                else
                                    temp3 = 1;
                            }
                        }
                    }
                    else
                        if (GridView1.Rows.Count == 4)
                        {
                            name1 = (TextBox)GridView1.Rows[0].Cells[1].FindControl("txtname1");
                            mobile1 = (TextBox)GridView1.Rows[0].Cells[2].FindControl("txtmobile1");
                            school1 = (TextBox)GridView1.Rows[0].Cells[3].FindControl("txtschool1");
                            name2 = (TextBox)GridView1.Rows[1].Cells[1].FindControl("txtname1");
                            mobile2 = (TextBox)GridView1.Rows[1].Cells[2].FindControl("txtmobile1");
                            school2 = (TextBox)GridView1.Rows[1].Cells[3].FindControl("txtschool1");
                            name3 = (TextBox)GridView1.Rows[2].Cells[1].FindControl("txtname1");
                            mobile3 = (TextBox)GridView1.Rows[2].Cells[2].FindControl("txtmobile1");
                            school3 = (TextBox)GridView1.Rows[2].Cells[3].FindControl("txtschool1");
                            name4 = (TextBox)GridView1.Rows[3].Cells[1].FindControl("txtname1");
                            mobile4 = (TextBox)GridView1.Rows[3].Cells[2].FindControl("txtmobile1");
                            school4 = (TextBox)GridView1.Rows[3].Cells[3].FindControl("txtschool1");
                            if (Request.QueryString["edit"] == "edit" && Request.QueryString["tic"] != null)
                            {
                                temp1 = 0;
                                dobj.complaint_update(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, name4.Text, mobile4.Text, school4.Text, blank, blank, blank, Request.QueryString["tic"].ToString());
                                temp4 = 1;
                            }
                            else
                            {
                                if (Request.QueryString.Count == 3 && Request.QueryString["mob"] != null && Request.QueryString["agentid"] != null && Request.QueryString["accept"] == "accept")
                                {
                                    if (temp2 == 1)
                                    {
                                        temp1 = 0;
                                        dobj.complaint_update_mobile(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, name4.Text, mobile4.Text, school4.Text, blank, blank, blank);
                                        temp4 = 1;
                                    }
                                    else
                                    {
                                        dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, name4.Text, mobile4.Text, school4.Text, blank, blank, blank, res.ToString());
                                        temp4 = 1;
                                    }
                                }
                                if (temp4 == 0)
                                {

                                    if (temp2 == 0)
                                    {
                                        dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, name4.Text, mobile4.Text, school4.Text, blank, blank, blank, res.ToString());
                                        temp4 = 1;
                                    }
                                    else
                                    {
                                        temp3 = 1;
                                    }
                                }
                            }
                        }
                        else
                            if (GridView1.Rows.Count == 5)
                            {
                                name1 = (TextBox)GridView1.Rows[0].Cells[1].FindControl("txtname1");
                                mobile1 = (TextBox)GridView1.Rows[0].Cells[2].FindControl("txtmobile1");
                                school1 = (TextBox)GridView1.Rows[0].Cells[3].FindControl("txtschool1");
                                name2 = (TextBox)GridView1.Rows[1].Cells[1].FindControl("txtname1");
                                mobile2 = (TextBox)GridView1.Rows[1].Cells[2].FindControl("txtmobile1");
                                school2 = (TextBox)GridView1.Rows[1].Cells[3].FindControl("txtschool1");
                                name3 = (TextBox)GridView1.Rows[2].Cells[1].FindControl("txtname1");
                                mobile3 = (TextBox)GridView1.Rows[2].Cells[2].FindControl("txtmobile1");
                                school3 = (TextBox)GridView1.Rows[2].Cells[3].FindControl("txtschool1");
                                name4 = (TextBox)GridView1.Rows[3].Cells[1].FindControl("txtname1");
                                mobile4 = (TextBox)GridView1.Rows[3].Cells[2].FindControl("txtmobile1");
                                school4 = (TextBox)GridView1.Rows[3].Cells[3].FindControl("txtschool1");
                                name5 = (TextBox)GridView1.Rows[4].Cells[1].FindControl("txtname1");
                                mobile5 = (TextBox)GridView1.Rows[4].Cells[2].FindControl("txtmobile1");
                                school5 = (TextBox)GridView1.Rows[4].Cells[3].FindControl("txtschool1");
                                if (Request.QueryString["edit"] == "edit" && Request.QueryString["tic"] != null)
                                {
                                    temp1 = 0;
                                    dobj.complaint_update(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, name4.Text, mobile4.Text, school4.Text, name5.Text, mobile5.Text, school5.Text, Request.QueryString["tic"].ToString());
                                    temp4 = 1;
                                }
                                else
                                {
                                    if (Request.QueryString.Count == 3 && Request.QueryString["mob"] != null && Request.QueryString["agentid"] != null && Request.QueryString["accept"] == "accept")
                                    {
                                        if (temp2 == 1)
                                        {
                                            temp1 = 0;
                                            dobj.complaint_update_mobile(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, name4.Text, mobile4.Text, school4.Text, name5.Text, mobile5.Text, school5.Text);
                                            temp4 = 1;
                                        }
                                        else
                                        {
                                            dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, name4.Text, mobile4.Text, school4.Text, name5.Text, mobile5.Text, school5.Text, res.ToString());
                                            temp4 = 1;
                                        }
                                    }
                                   if(temp4 ==0)
                                    {
                                        if (temp2 == 0)
                                            dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, name1.Text, mobile1.Text, school1.Text, name2.Text, mobile2.Text, school2.Text, name3.Text, mobile3.Text, school3.Text, name4.Text, mobile4.Text, school4.Text, name5.Text, mobile5.Text, school5.Text, res.ToString());
                                        else
                                            temp3 = 1;
                                    }
                                }
                            }
                            else
                            {
                                if (Request.QueryString["edit"] == "edit" && Request.QueryString["tic"] != null)
                                {
                                    temp1 = 0;
                                    dobj.complaint_update(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, Request.QueryString["tic"].ToString());
                                    temp4 = 1;
                                }
                               
                                    if (Request.QueryString.Count == 3 && Request.QueryString["mob"] != null && Request.QueryString["agentid"] != null && Request.QueryString["accept"] == "accept")
                                    {
                                        if (temp2 == 1)
                                        {
                                            temp1 = 0;

                                            dobj.complaint_update_mobile(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank);
                                            temp4 = 1;
                                        }
                                        else
                                        {
                                            dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, res.ToString());
                                            temp4 = 1;
                                        }
                                    }
                                   if(temp4 ==0)
                                    {
                                        if (temp2 == 0)
                                        {
                                            dobj.complaint_insert(name.ToString(), txtmob.Text, txtalternate.Text, txtemail.Text, txtdob.Text, Radiogender.SelectedValue, Radiomarital.SelectedValue, txtspouse.Text, txtspouse_mob.Text, txtspouse_alternate.Text, txtspouse_dob.Text, txtresident.Text, txtofficial.Text, Radiocar.SelectedValue, txtbrand.Text, txtcar_no.Text, txtfather_name.Text, txtfather_mob.Text, txtfather_dob.Text, txtmother_name.Text, txtmother_mob.Text, txtmotherdob.Text, txtbrother_name.Text, txtbrother_mob.Text, txtbrother_dob.Text, txtsister_name.Text, txtsister_mob.Text, txtsister_dob.Text, txtcredit.Text, txtdelivery.Text, txtanniversary.Text, DropDownchildren.SelectedItem.Text, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, blank, res.ToString());
                                        }
                                        else
                                        {

                                            temp3 = 1;
                                        }
                                    }
                                
                            }
            if (temp3==1)
            {

                lblerr.Text = "*This Mobile no. already exists";
                }
            else
            {
                Response.Write("<script> alert('Form Submitted Sucessfully!!!');location.href='Dashboard.aspx'</script>");
           
	        }
        }
        catch (Exception)
        {
            Response.Write("<script> alert('Something went wrong!!!');location.href='Dashboard.aspx'</script>");
        }
    }

    protected void Checkadd_CheckedChanged(object sender, EventArgs e)
    {
        if (Checkadd.Checked == true)
        {
            txtdelivery.Text = txtresident.Text;
        }
        else 
        {
            txtdelivery.Text = "";
        }
    }
    protected void Radiocar_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Radiocar.SelectedValue == "No")
        {
            txtbrand.Enabled = false;
            txtcar_no.Enabled = false;
            txtbrand.Text = "";
            txtcar_no.Text = "";
        }
        else 
        {
            txtbrand.Enabled = true;
            txtcar_no.Enabled = true;
        }
    }
}