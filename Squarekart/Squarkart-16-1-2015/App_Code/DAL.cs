using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{

    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    MySqlConnection foodcon = new MySqlConnection(ConfigurationManager.ConnectionStrings["foodcon"].ConnectionString);
   
    MySqlDataAdapter da;
    MySqlDataReader dr;
    MySqlCommand cmd;
    DataSet ds;
    string s = "";

	public DAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int login_check(string id1, string pass)
    {
        int i = 0;
        try
        {
            if (i == 0)
            {
                foodcon.Open();
                s = "select userid,role from squarekart_ui_agent where UserId='" + id1 + "' and Password='" + pass + "' and role='ADMIN'";
                cmd = new MySqlCommand(s, foodcon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    i = 1;
                }
                dr.Close();
                foodcon.Close();
            }
            if (i == 0)
            {
                foodcon.Open();
                s = "select userid,role from squarekart_ui_agent where UserId='" + id1 + "' and Password='" + pass + "' and role='AGENT'";
                cmd = new MySqlCommand(s, foodcon);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    i = 2;
                }
                dr.Close();
                foodcon.Close();
            }
            if (i != 0)
            {
                foodcon.Open();
                string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                s = "update squarekart_ui_agent set is_active='1',last_login='" + dat.ToString() + "' where UserId='" + id1 + "' and Password='" + pass + "'";
                cmd = new MySqlCommand(s, foodcon);
                cmd.ExecuteNonQuery();
                foodcon.Close();
            }
            else 
            {
                i = 0;
            }
        }
        catch (Exception)
        {
            i = 0;
        }
        return i;
    }


    public int check_pop() 
    {
        int i=0;
        try
        {
                con.Open();
                s = "select count(*) from temp";
                cmd = new MySqlCommand(s, con);
                i =Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            
        }
        catch (Exception) 
        {
        
        }
        return i;
    }

    public void child_count(int ch)
    {
        
        try
        {
            con.Open();
            s = "insert into child(child) values('"+ch.ToString()+"')";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }
       
    }
    public void child_count()
    {

        try
        {
            con.Open();
            s = "delete from child";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }

    }
    public void popup_accept(string id)
    {

        try
        {
            con.Open();
            s = "update newcall set status='Accept' where id='"+id+"'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "insert into oldcalls(select * from newcall where id ='" +id+ "')";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "delete from newcall where id ='"+id+"'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }

    }
    public void popup_busy(string id)
    {

        try
        {
            con.Open();
            s = "update newcall set status='Busy' where id='" + id + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "insert into oldcalls(select * from newcall where id =" + id + ")";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "delete from newcall where id ='" + id + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }

    }
    public void user_logout(string id)
    {

        try
        {
            foodcon.Open();
            string dat = System.DateTime.Now.ToString();
            s = "update squarekart_ui_agent set is_active='0',last_login='"+dat+"' where UserID='" + id + "'";
            cmd = new MySqlCommand(s, foodcon);
            cmd.ExecuteNonQuery();
            foodcon.Close();
           
        }
        catch (Exception) { }
    }
    //public void popup_update( string id,string answer)
    //{

    //    try
    //    {
    //        con.Open();
    //        s = "update temp set status='"+answer.ToString()+"' where mob='"+id.ToString() +"'  ";
    //        cmd = new MySqlCommand(s, con);
    //        cmd.ExecuteNonQuery();
    //        con.Close();

    //    }
    //    catch (Exception)
    //    {

    //    }

    //}
    public DataSet child_show()
    {
        try
        {
            con.Open();
            s = "select * from child";
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();

        }
        catch (Exception)
        {

        }
        return ds;
    }
    public int check_reg(string mob)
    {
        int i = 0;
        try
        {
            con.Open();
            s = "select * from customer where mobile_no='" + mob + "'";
            cmd = new MySqlCommand(s, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                i = 1;
            }
            dr.Close();
            con.Close();
        }
        catch (Exception)
        {
            i = 0;
        }
        return i;
    }
    public DataSet dashboard_show()
    {
        try
        {
            con.Open();
            s = "select * from customer where dat=date(now()) order by ticket_id desc limit 25"; //change by ankit
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();

        }
        catch (Exception)
        {

        }
        return ds;
    }
    public int check_count1(string id)
    {
        int i = 0;
        try
        {
            con.Open();
            s = "select count(*) from newcall where status='new' and agentid='" + id + "'";
            cmd = new MySqlCommand(s, con);
            i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception)
        {
            i = 0;
        }
        return i;
    }
    public string check_count_popup(string id)
    {
        string i="";
        try
        {
            con.Open();
            s = "SELECT CONCAT(mobileno,'#',id,'#',call_id) FROM newcall WHERE STATUS='new' AND agentid='" + id + "' order by trndate desc limit 1";
            cmd = new MySqlCommand(s, con);
         //   cmd.CommandText = s;
            

            i = cmd.ExecuteScalar().ToString();
            con.Close();

        }
        catch (Exception)
        {
            i = "";
        }
        return i;
    }
    public int square_ashx_read(string id)
    {
        int i=0;
        try
        {
                con.Open();
                s = "select * from newcall where agentid='" + id + "' ";
                cmd = new MySqlCommand(s, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    i = 1;
                }
                dr.Close();
                con.Close();
         }
        catch(Exception)
        {
        
         }
       return i;
    }
    public DataSet check_count_popup2(string id)
    {
        string i = "";
        try
        {
            con.Open();
            s = "SELECT mobileno,id,call_id FROM newcall WHERE STATUS='new' AND agentid='" + id + "' order by trndate desc limit 1";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

        }
        catch (Exception)
        {
            ds = null;
        }
        return ds;
    }
   
    public void popup_flush(string agent,string id) 
    {
        try
        {
            con.Open();
            s = "insert into oldcalls(select * from newcall where agentid='" +agent + "' and id< " + id + ")";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "delete from newcall where agentid='"+agent+ "' and id< " +id + "";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception) 
        {
        
        }
    
    }
    public void complaint_insert(string uname, string mob, string alternate, string email, string dob, string gender, string marital, string sp_name, string sp_mobile, string sp_alternate, string sp_dob, string resdt, string official, string car, string car_brand, string car_no, string fname, string fmobile, string fdob, string mname, string mmobile, string mdob, string bname, string bmobile, string bdob, string sname, string smobile, string sdob, string credit, string delivery, string anniversary, string child, string c_name1, string cmobile1, string school1, string c_name2, string cmobile2, string school2, string c_name3, string cmobile3, string school3, string c_name4, string cmobile4, string school4, string c_name5, string cmobile5, string school5,string ticket)
    {
        try
        {
            con.Open();
            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            s = "insert into customer(uname,mobile_no,alternate_no,email,dob,gender,marital,spouse_name,spouse_mobile,spouse_alternate,spouse_dob,resident_add,official_add,car,car_brand,car_no,f_name,f_mobile,f_dob,m_name,m_mobile,m_dob,b_name,b_mobile,b_dob,s_name,s_mobile,s_dob,credit_card_no,delivery_add,aniversary,child,c_name1,c_mobile1,c_school1,c_name2,c_mobile2,c_school2,c_name3,c_mobile3,c_school3,c_name4,c_mobile4,c_school4,c_name5,c_mobile5,c_school5,dat,ticket_id) values('" + uname + "','" + mob + "','" + alternate + "','" + email + "','" + dob + "','" + gender + "','" + marital + "','" + sp_name + "','" + sp_mobile + "','" + sp_alternate + "','" + sp_dob + "','" + resdt + "','" + official + "','" + car + "','" + car_brand + "','" + car_no + "','" + fname + "','" + fmobile + "','" + fdob + "','" + mname + "','" + mmobile + "','" + mdob + "','" + bname + "','" + bmobile + "','" + bdob + "','" + sname + "','" + smobile + "','" + sdob + "','" + credit + "','" + delivery + "','" + anniversary + "','" + child + "','" + c_name1 + "','" + cmobile1 + "','" + school1 + "','" + c_name2 + "','" + cmobile2 + "','" + school2 + "','" + c_name3 + "','" + cmobile3 + "','" + school3 + "','" + c_name4 + "','" + cmobile4 + "','" + school4 + "','" + c_name5 + "','" + cmobile5 + "','" + school5 + "','"+dat.ToString()+"', '"+ticket+"') ";
            cmd=new MySqlCommand(s,con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception) 
        {
        
        }
    }
    public void complaint_update(string uname, string mob, string alternate, string email, string dob, string gender, string marital, string sp_name, string sp_mobile, string sp_alternate, string sp_dob, string resdt, string official, string car, string car_brand, string car_no, string fname, string fmobile, string fdob, string mname, string mmobile, string mdob, string bname, string bmobile, string bdob, string sname, string smobile, string sdob, string credit, string delivery, string anniversary, string child, string c_name1, string cmobile1, string school1, string c_name2, string cmobile2, string school2, string c_name3, string cmobile3, string school3, string c_name4, string cmobile4, string school4, string c_name5, string cmobile5, string school5, string ticket)
    {
        try
        {
            con.Open();
            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            s = "update customer set uname='" + uname + "',mobile_no='" + mob + "',alternate_no='" + alternate + "',email='" + email + "',dob='" + dob + "',gender='" + gender + "',marital='" + marital + "',spouse_name='" + sp_name + "',spouse_mobile='" + sp_mobile + "',spouse_alternate='" + sp_alternate + "',spouse_dob='" + sp_dob + "',resident_add='" + resdt + "',official_add='" + official + "',car='" + car + "',car_brand='" + car_brand + "',car_no='" + car_no + "',f_name='" + fname + "',f_mobile='" + fmobile + "',f_dob='" + fdob + "',m_name='" + mname + "',m_mobile='" + mmobile + "',m_dob='" + mdob + "',b_name='" + bname + "',b_mobile='" + bmobile + "',b_dob='" + bdob + "',s_name='" + sname + "',s_mobile='" + smobile + "',s_dob='" + sdob + "',credit_card_no='" + credit + "', delivery_add='" + delivery + "' ,aniversary='" + anniversary + "',child='" + child + "',c_name1='" + c_name1 + "',c_mobile1='" + cmobile1 + "',c_school1='" + school1 + "',c_name2='" + c_name2 + "',c_mobile2='" + cmobile2 + "',c_school2='" + school2 + "',c_name3='" + c_name3 + "',c_mobile3='" + cmobile3 + "',c_school3='" + school3 + "',c_name4='" + c_name4 + "',c_mobile4='" + cmobile4 + "',c_school4='" + school4 + "',c_name5='" + c_name5 + "',c_mobile5='" + cmobile5 + "',c_school5='" + school5 + "',dat='" + dat + "' where ticket_id='" + ticket + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }
    }
    public void complaint_update_mobile(string uname, string mob, string alternate, string email, string dob, string gender, string marital, string sp_name, string sp_mobile, string sp_alternate, string sp_dob, string resdt, string official, string car, string car_brand, string car_no, string fname, string fmobile, string fdob, string mname, string mmobile, string mdob, string bname, string bmobile, string bdob, string sname, string smobile, string sdob, string credit, string delivery, string anniversary, string child, string c_name1, string cmobile1, string school1, string c_name2, string cmobile2, string school2, string c_name3, string cmobile3, string school3, string c_name4, string cmobile4, string school4, string c_name5, string cmobile5, string school5)
    {
        try
        {
            con.Open();
            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            s = "update customer set uname='" + uname + "',alternate_no='" + alternate + "',email='" + email + "',dob='" + dob + "',gender='" + gender + "',marital='" + marital + "',spouse_name='" + sp_name + "',spouse_mobile='" + sp_mobile + "',spouse_alternate='" + sp_alternate + "',spouse_dob='" + sp_dob + "',resident_add='" + resdt + "',official_add='" + official + "',car='" + car + "',car_brand='" + car_brand + "',car_no='" + car_no + "',f_name='" + fname + "',f_mobile='" + fmobile + "',f_dob='" + fdob + "',m_name='" + mname + "',m_mobile='" + mmobile + "',m_dob='" + mdob + "',b_name='" + bname + "',b_mobile='" + bmobile + "',b_dob='" + bdob + "',s_name='" + sname + "',s_mobile='" + smobile + "',s_dob='" + sdob + "',credit_card_no='" + credit + "', delivery_add='" + delivery + "' ,aniversary='" + anniversary + "',child='" + child + "',c_name1='" + c_name1 + "',c_mobile1='" + cmobile1 + "',c_school1='" + school1 + "',c_name2='" + c_name2 + "',c_mobile2='" + cmobile2 + "',c_school2='" + school2 + "',c_name3='" + c_name3 + "',c_mobile3='" + cmobile3 + "',c_school3='" + school3 + "',c_name4='" + c_name4 + "',c_mobile4='" + cmobile4 + "',c_school4='" + school4 + "',c_name5='" + c_name5 + "',c_mobile5='" + cmobile5 + "',c_school5='" + school5 + "',dat='" + dat + "' where mobile_no='" + mob + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }
    }
    public void flush_popup()
    {

        try
        {
            con.Open();
            s = "delete from temp";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }

    }
    public int complaint_read_popup(string mob)
    {
        int i = 0;
        try
        {
            con.Open();
            s = "select uname,mobile_no,ticket_id from customer where mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' limit 1";
            cmd = new MySqlCommand(s, con);
            dr = cmd.ExecuteReader();
            if (dr.Read()) 
            {
                i = 1;
            }
            con.Close();
        }
        catch (Exception)
        {
            i = 0;

        }
        return i;
    }

    public DataSet complaint_fetch_popup11(string mob)
    {
        try
        {
            ds = null;
            con.Open();
            s = "select * from customer where mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' limit 1";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception)
        {
            ds = null;

        }
        return ds;
    }
    
    public DataSet complaint_fetch_popup(string mob) 
    {
        try
        {
            ds = null;
            con.Open();
            s = "select uname,mobile_no from customer where mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' limit 1";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) 
        {
            ds = null;
        
        }
        return ds;
    }
    public void square_ashx_page(string id,string mob,string call_id)
    {

        try
        {
            con.Open();
            string status = "new";
            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            s = "insert into newcall(mobileno,agentid,status,call_id,trndate) values('" + mob + "','" + id + "','" + status + "','" +call_id+ "','"+dat+"')";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }

    }
    public DataSet edit_complaint(string tic) 
    {
        try
        {
            con.Open();
            s = "select * from customer where ticket_id='"+tic+"'";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) 
        {
            ds = null;

        }
        return ds;
    }
    public DataSet print_complaint(string tic)
    {
        try
        {
            con.Open();
            s = "select * from customer where ticket_id='" + tic + "'";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception)
        {
            ds = null;

        }
        return ds;
    }

    public DataSet eport_dashboard(string date1, string date2, string mob, string name)
    {
        try
        {
            if (date1 != "" && date2 != "" && mob != "" && name != "")
            {
                con.Open();
                s = "select * from customer where uname='" + name + "' and dat between '" + date1 + "' and '" + date2 + "' and  mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "'  order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 != "" && date2 != "" && mob != "" && name == "")
            {
                con.Open();
                s = "select * from customer where dat between '" + date1 + "' and '" + date2 + "' and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 != "" && date2 != "" && mob == "" && name != "")
            {
                con.Open();
                s = "select * from customer where uname='" + name + "' and dat between '" + date1 + "' and '" + date2 + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }

            if (date1 != "" && date2 != "" && mob == "" && name == "")
            {
                con.Open();
                s = "select * from customer where dat between '" + date1 + "' and '" + date2 + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

            }
            if (date1 != "" && date2 == "" && mob != "" && name != "")
            {
                con.Open();
                s = "select * from customer where uname='" + name + "' and dat>='" + date1 + "' and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

            }
            if (date1 == "" && date2 != "" && mob != "" && name != "")
            {
                con.Open();
                s = "select * from customer where uname='" + name + "' and dat <='" + date2 + "' and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 == "" && date2 != "" && mob == "" && name != "")
            {
                con.Open();
                s = "select * from customer where uname='" + name + "' and dat <='" + date2 + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 == "" && date2 == "" && mob != "" && name != "")
            {
                con.Open();
                s = "select * from customer where uname='" + name + "' and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

            }

            if (date1 == "" && date2 == "" && mob != "" && name == "")
            {
                con.Open();
                s = "select * from customer where mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 == "" && date2 != "" && mob == "" && name == "")
            {
                con.Open();
                s = "select * from customer where dat <='" + date2 + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 != "" && date2 == "" && mob == "" && name != "")
            {
                con.Open();
                s = "select * from customer where dat >='" + date1 + "' and uname='" + name + "'  order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 != "" && date2 == "" && mob == "" && name == "")
            {
                con.Open();
                s = "select * from customer where dat >='" + date1 + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 == "" && date2 == "" && mob == "" && name != "")
            {
                con.Open();
                s = "select * from customer where uname like '" + name + "%' order by dat DESC ";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 != "" && date2 == "" && mob != "" && name == "")
            {
                con.Open();
                s = "select * from customer where dat>='" + date1 + "'and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

            }
            if (date1 == "" && date2 != "" && mob != "" && name == "")
            {
                con.Open();
                s = "select * from customer where dat <='" + date2 + "' and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 == "" && date2 == "" && mob == "" && name == "")
            {
                con.Open();
                string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                s = "select * from customer where dat='" + dat + "' order by ticket_id desc limit 25"; //change by ankit
                //s = "select * from customer where dat=date(now()) order by ticket_id desc limit 25"; //change by ankit
                cmd = new MySqlCommand(s, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                con.Close();
            }


        }
        catch (Exception)
        {
            ds = null;

        }
        return ds;
    }


    public DataSet search_dashboard(string date1,string date2,string mob,string name)
    {
        try
        {
            if (date1 != "" && date2 != ""  && mob != "" && name != "") 
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where uname='" + name + "' and dat between '" + date1 + "' and '" + date2 + "' and  mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "'  order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 != "" && date2 != "" && mob != "" && name == "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where dat between '" + date1 + "' and '" + date2 + "' and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 != "" && date2 != "" && mob == "" && name != "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where uname='" + name + "' and dat between '" + date1 + "' and '" + date2 + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
           
            if (date1 != "" && date2 != "" && mob == "" && name == "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where dat between '" + date1 + "' and '" + date2 + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

            }
            if (date1 != "" && date2 == "" && mob != "" && name != "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where uname='" + name + "' and dat>='" + date1 + "' and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

            }
            if (date1 == "" && date2 != "" && mob != "" && name != "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where uname='" + name + "' and dat <='" + date2 + "' and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 == "" && date2 != "" && mob == "" && name != "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where uname='" + name + "' and dat <='" + date2 + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 == "" && date2 == "" && mob != "" && name != "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where uname='" + name + "' and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

            }
          
            if (date1 == "" && date2 == "" && mob != "" && name == "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 == "" && date2 != "" && mob == "" && name == "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where dat <='" + date2 + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 != "" && date2 == "" && mob == "" && name != "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where dat >='" + date1 + "' and uname='" + name + "'  order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 != "" && date2 == "" && mob == "" && name == "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where dat >='" + date1 + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 == "" && date2 == "" && mob == "" && name != "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where uname like '" + name + "%' order by dat DESC ";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 != "" && date2 == "" && mob != "" && name == "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where dat>='" + date1 + "'and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

            }
            if (date1 == "" && date2 != "" && mob != "" && name == "")
            {
                con.Open();
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where dat <='" + date2 + "' and mobile_no='" + mob + "' or alternate_no='" + mob + "' or spouse_mobile='" + mob + "' or spouse_alternate='" + mob + "' or f_mobile='" + mob + "' or m_mobile='" + mob + "' or b_mobile='" + mob + "' or s_mobile='" + mob + "' or c_mobile1='" + mob + "' or c_mobile2='" + mob + "' or c_mobile3='" + mob + "' or c_mobile4='" + mob + "' or c_mobile5='" + mob + "' order by dat DESC";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            if (date1 == "" && date2 == "" && mob == "" && name == "")
            {
                con.Open();
                string dat=System.DateTime.Now.ToString("yyyy-MM-dd");
                s = "select ticket_id,uname,mobile_no,alternate_no,email,dob,credit_card_no from customer where dat='" + dat + "' order by ticket_id desc limit 25"; //change by ankit
                //s = "select * from customer where dat=date(now()) order by ticket_id desc limit 25"; //change by ankit
                cmd = new MySqlCommand(s, con);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                con.Close();
            }


        }
        catch (Exception)
        {
            ds = null;

        }
        return ds;
    }
    public DataSet map_show() 
    {
        try
        {
            foodcon.Open();
            s = "select * from foodbazar_agent_mapping_view";
            cmd = new MySqlCommand(s, foodcon);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            foodcon.Close();
        }
        catch (Exception)
        {
            ds = null;

        }
        return ds;
    }
    public void map_update(string num,string agent)
    {

        try
        {
            foodcon.Open();
            s = "update foodbazar_agent_mapping_view set agent_list='" + agent + "' where knumber='" + num.ToString() + "'  ";
            cmd = new MySqlCommand(s, foodcon);
            cmd.ExecuteNonQuery();
            foodcon.Close();

        }
        catch (Exception)
        {

        }
    }
    public void map_delete(string id)
    {

        try
        {
            foodcon.Open();
            s = "delete from foodbazar_agent_mapping_view where knumber='" + id.ToString() + "'  ";
            cmd = new MySqlCommand(s, foodcon);
            cmd.ExecuteNonQuery();
            foodcon.Close();

        }
        catch (Exception)
        {

        }
    }
    public void map_insert(string num, string agent)
    {

        try
        {
            foodcon.Open();
            s = "insert into foodbazar_agent_mapping_view(knumber,agent_list) values ('" + num + "','" + agent + "')";
            cmd = new MySqlCommand(s, foodcon);
            cmd.ExecuteNonQuery();
            foodcon.Close();

        }
        catch (Exception)
        {

        }

    }
    public void square_ashx_notresponse(string id)
    {

        try
        {
            con.Open();
            s = "update newcall set status='Not Response' where agentid='" + id + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "insert into oldcalls(select * from newcall where agentid ='" + id + "')";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "delete from newcall where agentid ='" + id + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }

    }
    public void tempchild(string name, string mob,string school,string temp)
    {

        try
        {
            con.Open();
            s = "insert into temp(child,tname,tmob,tschool) values ('" + temp + "','" + name + "','" + mob + "','" + school + "')";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }

    }
    public DataSet tempchild1()
    {
        try
        {
            con.Open();
            s = "select * from temp";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception)
        {
            ds = null;

        }
        return ds;
    }
    public void tempchild2()
    {

        try
        {
            con.Open();
            s = "delete from temp";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }

    }
}