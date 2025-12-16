using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml;

/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{

    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    MySqlConnection con2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["const2"].ConnectionString);
    MySqlConnection con3 = new MySqlConnection(ConfigurationManager.ConnectionStrings["const3"].ConnectionString);

    MySqlDataAdapter da;
    MySqlDataReader dr;
    MySqlCommand cmd;
    DataSet ds;
    string s = string.Empty;

    public DAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //insert for sales
    public string sale_insert(string name, string ex_id, string alternate, string email, string prof, string location, string source, string model_int, string diesel, string test, string current_vehicle, string exchange, string remark, string mob2, string customer_location)
    {
        string tic = string.Empty;
        try
        {
            /* Random ran=new Random();
             string n="0987654321";
             int i=10;
             string tic=string.Empty;
             while(0<i--)
             {
                 tic+=n[ran.Next(n.Length)];
             }*/
            string callid = DateTime.Now.ToString("yyyymmddhhmmssfff_" + alternate);

            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            con.Open();
            s = "insert into sale_service(callid,name,executive_id,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,role,date_of_entry,alternate_no2,customer_loc,time_of_entry) values('" + callid + "','" + name + "','" + ex_id + "','" + alternate + "','" + email + "','" + prof + "','" + location + "','" + source + "','" + model_int + "','" + diesel + "','" + test + "','" + current_vehicle + "','" + exchange + "','" + remark + "','sale','" + dat + "','" + mob2 + "','" + customer_location + "',Time(now()))";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "select ticket from sale_service where callid='" + callid + "'";
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            tic = ds.Tables[0].Rows[0]["ticket"].ToString();
            con.Close();

            //sendMailsale(name, alternate,mob2, email, prof, location, source, model_int, diesel, test, current_vehicle, exchange, remark, tic, customer_location);
            //msg_sale(name, alternate, tic, model_int, location, customer_location, test);
            // Thread thread = new Thread(() => msg_sale(name, alternate, tic, email, customer_location));
            // thread.Start();

        }
        catch (Exception) { }
        return tic;
    }
    //insert for service
    public string service_insert(string name, string ex_id, string alternate, string email, string loc, string source, string car_model, string diesel, string model_yr, string km, string prefer, string pick, string remark, string mob2, string customer_loc, string vehicle_regno)
    {
        string tic = string.Empty;
        try
        {
            /*Random ran = new Random();
            string n = "0987654321";
            int i = 10;
            string tic = string.Empty;
            while (0 < i--)
            {
                tic += n[ran.Next(n.Length)];
            }*/
            string callid = DateTime.Now.ToString("yyyymmddhhmmssfff_" + alternate);
            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            con.Open();
            s = "insert into sale_service(callid,name,executive_id,alternate_no,email,location,source,car_model,diesel_petrol,model_year,km_done,prefer_date_time,required_pickup,remark,role,date_of_entry,alternate_no2,customer_loc,vehicle_reg_no,time_of_entry) values('" + callid + "','" + name + "','" + ex_id + "','" + alternate + "','" + email + "','" + loc + "','" + source + "','" + car_model + "','" + diesel + "','" + model_yr + "','" + km + "','" + prefer + "','" + pick + "','" + remark + "','service','" + dat + "','" + mob2 + "','" + customer_loc + "','" + vehicle_regno + "',time(now()) )";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "select ticket from sale_service where callid='" + callid + "'";
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            tic = ds.Tables[0].Rows[0]["ticket"].ToString();
            con.Close();

            //sendMailservice(name, alternate, email, loc, source, car_model, diesel, model_yr, km, prefer, pick, remark, tic, customer_loc);
            //msg_service(name, alternate, tic, email, loc, customer_loc, pick, car_model);
            //Thread thread = new Thread(() => msg_service(name, alternate, tic, email, customer_loc, pick));
            //thread.Start();
        }
        catch (Exception) { }
        return tic;
    }
    public void msg_sale(string name11, string mob, string ticket, string model_int, string location, string cust, string test)
    {
        try
        {
            con.Open();
            s = "select sales_no from branch_details where location='" + location + "'";
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            string mobile = ds.Tables[0].Rows[0]["sales_no"].ToString();
            con.Close();
            if (test == "Yes")
                test = "Y";
            else
                test = "N";
            WebClient wc = new WebClient();
            string res = wc.DownloadString("http://int.kapps.in/webapi/enterprise/send_sms?smsnumber=" + mobile + "&smstext=Sales query Ticket ID:" + ticket + "\r\nName: " + name11 + "\r\nMob No.: " + mob + "\r\nModel Int.: " + model_int + "\r\nTest Drive Reqd: " + test + "\r\nLocation: " + cust + "\r\nSales Team" + "&auth_key=cb8d085c-9026-11e4-8500-22000a968650");
            ////// Regex regex1 = new Regex("[<>?/_]");
            ////string res_hold = regex1.Replace(res.ToString(), "t").ToString();
            //string [] temp_res=res_hold.Split('smststatus');
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            xmldoc.LoadXml(res);
            xmlnode = xmldoc.GetElementsByTagName("sms_status");
            string sms_resp = xmlnode[0].ChildNodes.Item(0).InnerText.Trim();

            con.Open();
            s = "update sale_service set sms='" + sms_resp + "' where ticket='" + ticket + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();


        }
        catch (Exception) { }
    }
    public void msg_service(string name11, string mob, string ticket, string email, string location, string cust, string pick, string car_model)
    {
        try
        {
            con.Open();
            s = "select service_no from branch_details where location='" + location + "'";
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            string mobile = ds.Tables[0].Rows[0]["service_no"].ToString();
            con.Close();
            if (pick == "Yes")
                pick = "Y";
            else
                pick = "N";
            WebClient wc = new WebClient();
            string res = wc.DownloadString("http://int.kapps.in/webapi/enterprise/send_sms?smsnumber=" + mobile + "&smstext=Service query Ticket ID:" + ticket + "\r\nName: " + name11 + "\r\nMob No.: " + mob + "\r\nLocation: " + cust + "\r\nModel: " + car_model + " \r\nPick Up Reqd: " + pick + "\r\nService Team" + "&auth_key=cb8d085c-9026-11e4-8500-22000a968650");
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            xmldoc.LoadXml(res);
            xmlnode = xmldoc.GetElementsByTagName("sms_status");
            string sms_resp = xmlnode[0].ChildNodes.Item(0).InnerText.Trim();

            con.Open();
            s = "update sale_service set sms='" + sms_resp + "' where ticket='" + ticket + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

            /*  HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://int.kapps.in/webapi/enterprise/send_sms?smsnumber=" + mobile + "&msg=Service query Ticket ID:" + ticket + " Name:" + name11 + " Email:" + email + " Location:" + location + " Service Team"+" &auth_key=cb8d085c-9026-11e4-8500-22000a968650");
              HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
              System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
              string responseString = respStreamReader.ReadToEnd();
              respStreamReader.Close();
              myResp.Close();*/
        }
        catch (Exception) { }
    }


    public DataSet dashboard_show() // show first time entries in dashboard
    {
        try
        {
            if (HttpContext.Current.Session["role"].ToString() == "ADMIN")
            {
                string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                s = "select date_of_entry,time_of_entry,executive_id,ticket,name,alternate_no,email,location,role from sale_service where date_of_entry='" + dat + "' order by ticket desc limit 25";
            }
            else
            {
                string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                // string role = HttpContext.Current.Session["role"].ToString();
                s = "select date_of_entry,time_of_entry,executive_id,ticket,name,alternate_no,email,location,role from sale_service where executive_id='" + HttpContext.Current.Session["user_id"] + "' and date_of_entry='" + dat + "' order by ticket desc limit 25";
                //s = "select ticket,name,alternate_no,email,location,role from sale_service where executive_id='" + HttpContext.Current.Session["user_id"] + "'";
            }
            con.Open();
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) { }
        return ds;
    }
    public int dashboard_show_edit1(string tic) // show first time entries in dashboard
    {
        int i = 0;
        try
        {
            s = "select ticket from sale_service where ticket='" + tic + "' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "'";
            con.Open();
            cmd = new MySqlCommand(s, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                i = 1;
            }
            con.Close();
        }
        catch (Exception) { }
        return i;
    }
    public DataSet dashboard_search(string start, string end, string number)// search creteria
    {
        try
        {
                if (HttpContext.Current.Session["role"].ToString() == "SALE")
                {
                    string role = HttpContext.Current.Session["role"].ToString();
                    // string ex_id=HttpContext.Current.Session["user_id"].ToString();
                    if (start != "" && end != "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start != "" && end != "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start != "" && end == "" && number != "")
                    {
                        s = "select date_of_entry,time_of_entry,executive_id,ticket,name,alternate_no,email,location,role,alternate_no2,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start == "" && end != "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start == "" && end == "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start != "" && end == "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start == "" && end != "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else
                    {
                        string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where executive_id='" + HttpContext.Current.Session["user_id"] + "' and date_of_entry='" + dat + "' order by ticket desc limit 25";
                       
                    }
                }
                if (HttpContext.Current.Session["role"].ToString() == "SERVICE")
                {
                    string role = HttpContext.Current.Session["role"].ToString();
                    // string ex_id=HttpContext.Current.Session["user_id"].ToString();
                    if (start != "" && end != "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";
                        //ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role
                    }
                    else if (start != "" && end != "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start != "" && end == "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start == "" && end != "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start == "" && end == "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start != "" && end == "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start == "" && end != "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else
                    {
                        string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where executive_id='" + HttpContext.Current.Session["user_id"] + "' and date_of_entry='" + dat + "' order by ticket desc limit 25 ";

                    }

            }

            con.Open();
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) { }
        return ds;
    }

    public DataSet dashboard_search_sale(string start, string end, string number)// search creteria
    {
        try
        {
                    if (start != "" && end != "" && number != "")
                    {
                        s = "select date_of_entry,time_of_entry,executive_id,ticket,name,alternate_no,email,location,role,alternate_no2,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "' and role='sale' order by ticket desc  ";

                    }
                    else if (start != "" && end != "" && number == "")
                    {
                        s = "select date_of_entry,time_of_entry,executive_id,ticket,name,alternate_no,email,location,role,alternate_no2,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and role='sale' order by ticket desc  ";

                    }
                    else if (start != "" && end == "" && number != "")
                    {
                        s = "select date_of_entry,time_of_entry,executive_id,ticket,name,alternate_no,email,location,role,alternate_no2,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "' and role='sale' order by ticket desc  ";

                    }
                    else if (start == "" && end != "" && number != "")
                    {
                        s = "select date_of_entry,time_of_entry,executive_id,ticket,name,alternate_no,email,location,role,alternate_no2,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "' and role='sale' order by ticket desc ";

                    }
                    else if (start == "" && end == "" && number != "")
                    {
                        s = "select date_of_entry,time_of_entry,executive_id,ticket,name,alternate_no,email,location,role,alternate_no2,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange from sale_service where alternate_no='" + number + "' and role='sale' order by ticket desc ";

                    }
                    else if (start != "" && end == "" && number == "")
                    {
                        s = "select date_of_entry,time_of_entry,executive_id,ticket,name,alternate_no,email,location,role,alternate_no2,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange from sale_service where date_of_entry>='" + start + "' and role='sale' order by ticket desc ";

                    }
                    else if (start == "" && end != "" && number == "")
                    {
                        s = "select date_of_entry,time_of_entry,executive_id,ticket,name,alternate_no,email,location,role,alternate_no2,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange from sale_service where date_of_entry<='" + end + "' and role='sale' order by ticket desc ";

                    }
                    else
                    {
                        string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                        s = "select date_of_entry,time_of_entry,executive_id,ticket,name,alternate_no,email,location,role,alternate_no2,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange from sale_service where role='sale' and date_of_entry='" + dat + "' order by ticket desc limit 25";

                    }
              
            con.Open();
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) { }
        return ds;
    }

    public DataSet dashboard_search_service(string start, string end, string number)// search creteria
    {
        try
        {
                    if (start != "" && end != "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "' and role='service' order by ticket desc ";

                    }
                    else if (start != "" && end != "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and role='service' order by ticket desc ";

                    }
                    else if (start != "" && end == "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "' and role='service' order by ticket desc ";

                    }
                    else if (start == "" && end != "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "' and role='service' order by ticket desc ";

                    }
                    else if (start == "" && end == "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where alternate_no='" + number + "' and role='service' order by ticket desc ";

                    }
                    else if (start != "" && end == "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and role='service' order by ticket desc ";

                    }
                    else if (start == "" && end != "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and role='service' order by ticket desc ";

                    }
                    else
                    {
                        string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry='" + dat + "' and role='service' order by ticket desc limit 25";

                    }

            con.Open();
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) { }
        return ds;
    }


    public DataTable dashboard_search_sale_exp(string start, string end, string number)// search creteria
    {
        DataTable dt = new DataTable();
        try
        {
            if (start != "" && end != "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "' and role='sale' order by ticket desc  ";

            }
            else if (start != "" && end != "" && number == "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and role='sale' order by ticket desc  ";

            }
            else if (start != "" && end == "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "' and role='sale' order by ticket desc  ";

            }
            else if (start == "" && end != "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "' and role='sale' order by ticket desc ";

            }
            else if (start == "" && end == "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where alternate_no='" + number + "' and role='sale' order by ticket desc ";

            }
            else if (start != "" && end == "" && number == "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and role='sale' order by ticket desc ";

            }
            else if (start == "" && end != "" && number == "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and role='sale' order by ticket desc ";

            }
            else
            {
                string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where role='sale' and date_of_entry='" + dat + "' order by ticket desc limit 25";

            }

            con.Open();
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
        }
        catch (Exception) { }
        return dt;
    }

    public DataTable dash_service_exp(string start, string end, string number)
    {
        DataTable dt = new DataTable();
        try
        {
            if (start != "" && end != "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

            }
            else if (start != "" && end != "" && number == "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

            }
            else if (start != "" && end == "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

            }
            else if (start == "" && end != "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

            }
            else if (start == "" && end == "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

            }
            else if (start != "" && end == "" && number == "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

            }
            else if (start == "" && end != "" && number == "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

            }
            else
            {
                string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where executive_id='" + HttpContext.Current.Session["user_id"] + "' and date_of_entry='" + dat + "' order by ticket desc limit 25";

            }
            con.Open();
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
        }
        catch (Exception) { }
        return dt;
    }
  
    public DataTable dash_sale_exp(string start, string end, string number) 
    {
        DataTable dt=new DataTable();
        try
        {
                  if (start != "" && end != "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";
                        //ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role
                    }
                    else if (start != "" && end != "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start != "" && end == "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start == "" && end != "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start == "" && end == "" && number != "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start != "" && end == "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else if (start == "" && end != "" && number == "")
                    {
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket desc ";

                    }
                    else
                    {
                        string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                        s = "select ticket,name,alternate_no,alternate_no2,email,location,profession,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,date_of_entry,time_of_entry,executive_id,role from sale_service where executive_id='" + HttpContext.Current.Session["user_id"] + "' and date_of_entry='" + dat + "' order by ticket desc limit 25";
                    }
             con.Open();
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
        }
        catch (Exception) { }
        return dt;
    }
    public DataTable dashboard_search_service_exp(string start, string end, string number)// search creteria
    {
        DataTable dt=new DataTable();
        try
        {
            if (start != "" && end != "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "' and role='service' order by ticket desc ";

            }
            else if (start != "" && end != "" && number == "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and role='service' order by ticket desc ";

            }
            else if (start != "" && end == "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "' and role='service' order by ticket desc ";

            }
            else if (start == "" && end != "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "' and role='service' order by ticket desc ";

            }
            else if (start == "" && end == "" && number != "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where alternate_no='" + number + "' and role='service' order by ticket desc ";

            }
            else if (start != "" && end == "" && number == "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry>='" + start + "' and role='service' order by ticket desc ";

            }
            else if (start == "" && end != "" && number == "")
            {
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry<='" + end + "' and role='service' order by ticket desc ";

            }
            else
            {
                string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                s = "select ticket,name,alternate_no,alternate_no2,email,location,source,diesel_petrol,car_model,model_year,km_done,prefer_date_time,required_pickup,customer_loc,vehicle_reg_no,date_of_entry,time_of_entry,executive_id,role from sale_service where date_of_entry='" + dat + "' and role='service' order by ticket desc limit 25";

            }

            con.Open();
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
        }
        catch (Exception) { }
        return dt;
    }

    public string login_check(string user, string pass) // 
    {
        int i = 0;
        string id = string.Empty;
        try
        {
            con.Open();
            s = "select user_id from login where user_id='" + user + "' and password='" + pass + "' and is_active='1'";
            cmd = new MySqlCommand(s, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                i = 1;
            }
            con.Close();
            if (i == 1)
            {
                con.Open();
                s = "select role from login where user_id='" + user + "' and password='" + pass + "' and is_active='1' ";
                cmd = new MySqlCommand(s, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                id = ds.Tables[0].Rows[0]["role"].ToString();
                con.Close();
                con.Open();
                string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
                con.Open();
                s = "update login set status='Busy' where user_id='" + HttpContext.Current.Session["user_id"].ToString() + "'";
                cmd = new MySqlCommand(s, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (Exception) { }
        return id;
    }
    public DataSet populate_location() // populate location dropdownlist
    {
        try
        {
            con.Open();
            s = "select location from branch_details";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) { }
        return ds;
    }
    public void delete_dashboard(string tic) // delete entry from dashboard
    {
        try
        {
            con.Open();
            s = "delete from sale_service where ticket='" + tic + "' ";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception) { }

    }



    public void sendMailsale(string name, string alternate, string alternate2, string email, string profession, string location, string source, string model, string diesel, string test, string current_vehicle, string interest, string remark, string ticket_id, string cust_loc, string userid)
    {
        try
        {
            con.Open();
            s = "select sales from branch_details where location='" + location + "'";
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            string email_send = ds.Tables[0].Rows[0]["sales"].ToString();
            con.Close();
            con.Open();
            s = "update sale_service set mail_status_admin='Successfully',mail_address_receipent='" + email_send.ToString() + "',mail_address_receipent2='boservice@bhagatgroup.com',mail_address_sender='ivr@bhagatgroup.com',mail_sent_timestamp='" + System.DateTime.Now.ToString() + "' where ticket='" + ticket_id.ToString() + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

            string mailmsg = string.Format("Sales form " +
            "<b>Enquiry Details</b> <br /> <br /> " +
            "<br /> Ticket ID: " + ticket_id.ToString() +
            "<br /> Executive ID: " + userid +
             "<br /> Name: " + name +
            "<br /> Email: " + email +
            "<br /> Mobile no.: " + alternate +
            "<br /> Alternate Mobile no.: " + alternate2 +
            "<br /> Profession : " + profession +
            "<br /> Location: " + cust_loc +
            "<br /> Source of Enqury : " + source +
            "<br /> Model Interested in: " + model +
            "<br /> Diesel/Petrol: " + diesel +
            "<br /> Test Drive: " + test +
            "<br /> Current Vehicle Info.: " + current_vehicle +
            "<br /> Interested in exchange: " + interest +
            "<br /> Remarks: " + remark +
            "<br /><br />Warm Regards<br />" +
            "<b>BG Group(Sales Team)<b>");
            MailMessage msg = new MailMessage("ivr@bhagatgroup.com", email_send + ",boservice@bhagatgroup.com", "BG Sale ", mailmsg);

            msg.IsBodyHtml = true;
            SmtpClient clnt = new SmtpClient();
            clnt.Host = "mail.bhagatgroup.com";
            clnt.Port = 587;
            clnt.EnableSsl = false;
            NetworkCredential crd = new NetworkCredential("ivr@bhagatgroup.com", "welcome123");
            clnt.Credentials = crd;
            clnt.Send(msg);
            

        }
        catch (Exception ex)
        {
            con.Open();
            s = "update sale_service set mail_status_admin='" + ex + "' where ticket='" + ticket_id.ToString() + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }

    public void sendMailservice(string name, string alternate, string alternate2, string email, string location, string source, string car_model, string diesel, string model_year, string km, string prefer_date, string pickup, string remark, string ticket_id, string cust_loc, string vehicle_regno, string userid)
    {
        try
        {
            con.Open();
            s = "select service from branch_details where location='" + location + "'";
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            string email_send = ds.Tables[0].Rows[0]["service"].ToString();
            con.Close();
            con.Open();
            s = "update sale_service set mail_status_admin='Successfully',mail_address_receipent='" + email_send.ToString() + "',mail_address_receipent2='boservice@bhagatgroup.com',mail_address_sender='ivr@bhagatgroup.com',mail_sent_timestamp='" + System.DateTime.Now.ToString() + "' where ticket='" + ticket_id.ToString() + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            string mailmsg = string.Format("Sales form " +
            "<b>Enquiry Details</b> <br /> <br /> " +
            "<br /> Ticket ID: " + ticket_id.ToString() +
            "<br /> Executive ID: " + userid +
             "<br /> Name: " + name +
            "<br /> Email: " + email +
            "<br /> Mobile no.: " + alternate +
            "<br /> Alternate Mobile no.: " + alternate2 +
            "<br /> Location: " + cust_loc +
            "<br /> Source of Enqury : " + source +
            "<br /> Car Model: " + car_model +
            "<br /> Diesel/Petrol: " + diesel +
            "<br /> Model year: " + model_year +
            "<br /> Kilometer done: " + km +
            "<br /> Vehicle  Reg. No: " + vehicle_regno +
            "<br /> Prefer Date Time: " + prefer_date +
             "<br /> Required Pickup: " + pickup +
            "<br /> Remarks: " + remark +
            "<br /><br />Warm Regards<br />" +
            "<b>BG Group(Service Team)<b>");
            MailMessage msg = new MailMessage("ivr@bhagatgroup.com", email_send.ToString() + ",boservice@bhagatgroup.com", "BG Service ", mailmsg);
            //  mail.To.Add("ankit.tech@gmail.com");
            //  mail.To.Add("harish.singhus@gmail.com");
            msg.IsBodyHtml = true;
            SmtpClient clnt = new SmtpClient();
            clnt.Host = "mail.bhagatgroup.com";
            clnt.Port = 587;
            clnt.EnableSsl = false;
            NetworkCredential crd = new NetworkCredential("ivr@bhagatgroup.com", "welcome123");
            clnt.Credentials = crd;
            clnt.Send(msg);

            /*
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("abmotor.bg@gmail.com");
            mail.To.Add("ankit.tech@gmail.com");
            mail.To.Add("harish.singhus@gmail.com");
            mail.To.Add("samidrawat@gmail.com");
            mail.Subject = "Service Team";
            mail.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
            System.Net.Mail.AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(mailmsg, @"<(.|\n)*?>", string.Empty), null, "text/plain");
            System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(mailmsg, null, "text/html");
            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);
            mail.Body = mailmsg;
            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtpout.asia.secureserver.net";
            smtpClient.Port = 80;
            smtpClient.EnableSsl = false;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("abmotor.bg@gmail.com", "123@admin");
            smtpClient.Send(mail);*/
        }
        catch (Exception ex)
        {
            con.Open();
            s = "update sale_service set mail_status_admin='" + ex + "' where ticket='" + ticket_id.ToString() + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public int edit_count(string tic) // edit sales entry of dasboard
    {
        int i = 0;
        try
        {
            con.Open();
            s = "select name from sale_service where ticket='" + tic + "'";
            cmd = new MySqlCommand(s, con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                i = 1;
            }
            con.Close();
        }
        catch (Exception) { }
        return i;
    }

    public DataSet dashboard_edit(string tic) // edit sales entry of dasboard
    {
        // string data = string.Empty;
        try
        {
            con.Open();
            s = "select name,customer_loc,alternate_no,alternate_no2,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark from sale_service where ticket='" + tic + "'";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) { }
        return ds;
    }
    public DataSet chk_sale(string mob) // edit sales entry of dasboard
    {
        // string data = string.Empty;
        try
        {
            con.Open();
            s = "select name,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark from sale_service where alternate_no='" + mob + "' limit 1";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) { }
        return ds;
    }
    public DataSet chk_service(string mob) // edit sales entry of dasboard
    {
        // string data = string.Empty;
        try
        {
            con.Open();
            s = "select name,email,location,source,car_model,diesel_petrol,model_year,km_done,prefer_date_time,required_pickup,remark from sale_service where alternate_no='" + mob + "' limit 1";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) { }
        return ds;
    }


    public DataSet dashboard_edit_service(string tic) // edit sales entry of dasboard
    {
        // string data = string.Empty;
        try
        {
            con.Open();
            s = "select name,customer_loc,alternate_no,alternate_no2,email,location,source,car_model,diesel_petrol,model_year,km_done,prefer_date_time,model_interest,required_pickup,remark,vehicle_reg_no from sale_service where ticket='" + tic + "'";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) { }
        return ds;
    }
    public void sale_update(string name, string alternate, string email, string prof, string location, string source, string model_int, string diesel, string test, string current_vehicle, string exchange, string remark, string tic, string mob2, string customer_location)
    {
        try
        {
            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            con.Open();
            s = "update sale_service set name='" + name + "',alternate_no='" + alternate + "',alternate_no2='" + mob2 + "',email='" + email + "',profession='" + prof + "',location='" + location + "', source='" + source + "',model_interest='" + model_int + "',diesel_petrol='" + diesel + "',test_drive='" + test + "', current_vehicle_info='" + current_vehicle + "',interest_in_exchange='" + exchange + "',remark='" + remark + "',executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "',update_date=now(),customer_loc='" + customer_location + "' where ticket='" + tic + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception) { }
    }
    public void service_update(string name, string alternate, string email, string loc, string source, string car_model, string diesel, string model_yr, string km, string prefer, string pick, string remark, string tic, string mob2, string customer_loc, string vehicle_regno)
    {
        try
        {
            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            con.Open();
            s = "update sale_service set name='" + name + "',alternate_no='" + alternate + "',email='" + email + "',location='" + loc + "', source='" + source + "',car_model='" + car_model + "',diesel_petrol='" + diesel + "',model_year='" + model_yr + "', km_done='" + km + "',prefer_date_time='" + prefer + "',remark='" + remark + "',executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "',update_date=now(),alternate_no2='" + mob2 + "',customer_loc='" + customer_loc + "',vehicle_reg_no='" + vehicle_regno + "' where ticket='" + tic + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception) { }
    }


    public void logout() //update details at logout
    {
        try
        {
            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            con.Open();
            s = "update login set status='Free',last_login_time='" + dat + "' where user_id='" + HttpContext.Current.Session["user_id"].ToString() + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception) { }
    }

    public DataSet map_show()
    {
        try
        {
            con.Open();
            s = "select user_id,role,is_active,password from login";
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
    public void map_update(string role, string active, string id, string pass)
    {

        try
        {
            con.Open();
            s = "update login set role='" + role + "',is_active='" + active + "',password='" + pass + "' where user_id='" + id + "'  ";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }
    }
    public void map_delete(string id)
    {

        try
        {
            con.Open();
            s = "delete from login where user_id='" + id.ToString() + "'  ";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }
    }
    public void map_insert(string id, string role, string active, string pass)
    {

        try
        {
            con.Open();
            s = "insert into login(user_id,role,is_active,password) values ('" + id + "','" + role + "','" + active + "','" + pass + "')";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }

    }


    public DataTable dashboard_search_export(string start, string end, string number)// search creteria
    {

        DataTable dt = new DataTable();
        try
        {
            if (HttpContext.Current.Session["role"].ToString() == "ADMIN")
            {
                if (start != "" && end != "" && number != "")
                {

                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
                }
                else if (start != "" && end != "" && number == "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and role='service' ";

                }
                else if (start != "" && end == "" && number != "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
                }
                else if (start == "" && end != "" && number != "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "'and role='service' ";
                }
                else if (start == "" && end == "" && number != "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where alternate_no='" + number + "'and role='service' ";
                }
                else if (start != "" && end == "" && number == "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry>='" + start + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry>='" + start + "' and role='service' ";
                }
                else if (start == "" && end != "" && number == "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and role='service' ";
                }
                else
                {
                    //s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,mode_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark from sale_service where role='sale' union select role,executive_id,ticket,name,alternate_no,email,profession,location,source,mode_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark from sale_service where role='service' ";
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup from sale_service where role='service' ";

                }
            }
            else
            {
                if (start != "" && end != "" && number != "")
                {

                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "'  ";
                }
                else if (start != "" && end != "" && number == "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and role='sale' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and role='service' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' ";

                }
                else if (start != "" && end == "" && number != "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' ";
                }
                else if (start == "" && end != "" && number != "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "'and role='sale' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "'and role='service' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' ";
                }
                else if (start == "" && end == "" && number != "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where alternate_no='" + number + "'and role='sale' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where alternate_no='" + number + "'and role='service' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' ";
                }
                else if (start != "" && end == "" && number == "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry>='" + start + "'and role='sale' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry>='" + start + "' and role='service' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' ";
                }
                else if (start == "" && end != "" && number == "")
                {
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and role='sale' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and role='service' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' ";
                }
                else
                {
                    //s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,mode_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark from sale_service where role='sale' union select role,executive_id,ticket,name,alternate_no,email,profession,location,source,mode_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark from sale_service where role='service' ";
                    s = "select role,executive_id,ticket,name,alternate_no,email,profession,location,source,model_interest,diesel_petrol,test_drive,current_vehicle_info,interest_in_exchange,remark,null as car_model,null as model_year,null as km_done,null as prefer_date_time,null as required_pickup,date_of_entry from sale_service where role='sale' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where role='service' and executive_id='" + HttpContext.Current.Session["user_id"].ToString() + "'  ";

                }
            }
            con.Open();
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
        }
        catch (Exception) { }
        return dt;
    }

    public DataTable dashboard_search_export_dash(string start, string end, string number)// search creteria
    {

        DataTable dt = new DataTable();
        try
        {
            if (HttpContext.Current.Session["role"].ToString() == "ADMIN")
            {
                if (start != "" && end != "" && number != "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "' order by ticket ASC ";

                }
                else if (start != "" && end != "" && number == "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' order by ticket ASC";

                }
                else if (start != "" && end == "" && number != "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "' order by ticket ASC ";

                }
                else if (start == "" && end != "" && number != "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "' order by ticket ASC ";

                }
                else if (start == "" && end == "" && number != "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where alternate_no='" + number + "' order by ticket ASC ";

                }
                else if (start != "" && end == "" && number == "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry>='" + start + "' order by ticket ASC";

                }
                else if (start == "" && end != "" && number == "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry<='" + end + "' order by ticket ASC";

                }
                else
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service order by ticket ASC limit 25";

                }
            }
            else
            {
                //string role = HttpContext.Current.Session["role"].ToString();
                // string ex_id=HttpContext.Current.Session["user_id"].ToString();
                if (start != "" && end != "" && number != "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket ASC ";

                }
                else if (start != "" && end != "" && number == "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket ASC";

                }
                else if (start != "" && end == "" && number != "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry>='" + start + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket ASC ";

                }
                else if (start == "" && end != "" && number != "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry<='" + end + "' and alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket ASC ";

                }
                else if (start == "" && end == "" && number != "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where alternate_no='" + number + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket ASC ";

                }
                else if (start != "" && end == "" && number == "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry>='" + start + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket ASC ";

                }
                else if (start == "" && end != "" && number == "")
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where date_of_entry<='" + end + "' and executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket ASC ";

                }
                else
                {
                    s = "select executive_id,ticket,name,alternate_no,email,location,role,date_of_entry,time_of_entry from sale_service where executive_id='" + HttpContext.Current.Session["user_id"] + "' order by ticket ASC limit 25";

                }
            }
            con.Open();
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
        }
        catch (Exception) { }
        return dt;
    }





    public int bg_ashx_read(string id)
    {
        int i = 0;
        try
        {
            con.Open();
            s = "select agent_id from newcall where agent_id='" + id + "' ";
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

        }
        return i;
    }
    public void bg_ashx_page(string id, string mob, string call_id, string ext)
    {

        try
        {
            con.Open();
            string status = "new";
            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            s = "insert into newcall(mobile,agent_id,status,ext,trans_date,call_id) values('" + mob + "','" + id + "','" + status + "','" + ext + "','" + dat + "','" + call_id + "')";
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
            s = "update newcall set status='Accept' where id='" + id + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "insert into oldcalls(select * from newcall where id ='" + id + "')";
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
    public int check_count1(string id)
    {
        int i = 0;
        try
        {
            con.Open();
            s = "select count(*) from newcall where status='new' and agent_id='" + id + "'";
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
    public DataSet check_count_popup2(string id)
    {
        try
        {
            con.Open();
            s = "SELECT mobile,id,call_id,ext FROM newcall WHERE STATUS='new' AND agent_id='" + id + "' order by trans_date desc limit 1";
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
    public int complaint_read_popup(string mob)
    {
        int i = 0;
        try
        {
            con.Open();
            string role = HttpContext.Current.Session["role"].ToString();
            s = "select name from sale_service where role='" + role.ToLower() + "' and (alternate_no='" + mob + "' or alternate_no2='" + mob + "') limit 1";
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
    public int complaint_read_popup_chk(int ext, string user)
    {
        int i = 0;
        try
        {
            if (ext == 1)
                s = "select user_id from login where user_id='" + user + "' and role='sale' and is_active='1'";
            if (ext == 2)
                s = "select user_id from login where user_id='" + user + "' and role='service' and is_active='1'";
            con.Open();
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

    public DataSet bg_fetch_popup(string mob)
    {
        try
        {
            ds = null;
            string role = HttpContext.Current.Session["role"].ToString();
            con.Open();
            s = "select name,remark,ticket,alternate_no2,email,location from sale_service where role='" + role.ToLower() + "' and (alternate_no='" + mob + "' or alternate_no2='" + mob + "') order by ticket desc limit 1";
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


    public void bg_ashx_notresponse(string id)
    {
        try
        {
            con.Open();
            s = "update newcall set status='Not Response' where agent_id='" + id + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "insert into oldcalls(select * from newcall where agent_id ='" + id + "')";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            s = "delete from newcall where agent_id ='" + id + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }

    }
    public void popup_remark(string tic, string p_remark, string remark)
    {
        try
        {
            con.Open();
            s = "select previous_remark from sale_service where ticket='" + tic + "'";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            string temp_remark = ds.Tables[0].Rows[0]["previous_remark"].ToString();
            con.Close();
            con.Open();
            s = "update sale_service set previous_remark='" + temp_remark + "#" + p_remark + "',remark='" + remark + "' where ticket='" + tic + "'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception) { }
    }
    public DataSet record_show()
    {
        ds = new DataSet();
        try
        {
            if (HttpContext.Current.Session["role"].ToString() == "ADMIN")
                s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log";
            else
            {
                if (HttpContext.Current.Session["role"].ToString() == "SALE")
                    s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log where key_pressed='1' ";
                if (HttpContext.Current.Session["role"].ToString() == "SERVICE")
                    s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log  where key_pressed='2'";
            }

            con.Open();
            cmd = new MySqlCommand(s, con);
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
    public void call_log_update(string id)
    {

        try
        {
            string status = "Called Back";
            con.Open();
            s = "update abmotors_call_log set caller_status='" + status + "',callback_visibility=1 where id='" + id.ToString() + "' and caller_status='Missed' or caller_status='Not Connected'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }
    }
    public void call_log_update2(string missed,string id)
    {

        try
        {
            string status = "Called Back";
            con.Open();
            s = "update abmotors_call_log set caller_status='" + status + "',missed_ref_no='" + missed + "',callback_visibility=1 where id='" + id.ToString() + "' and caller_status='Missed' or caller_status='Not Connected'";
            cmd = new MySqlCommand(s, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception)
        {

        }
    }

    public int call_log_update_chk(string id)
    {
        int i = 0;
        try
        {
            con.Open();
            s = "select id from abmotors_call_log where id='"+id+"'";
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

        }
        return i;
    }

    public string call_log_fetch_mobile(string id)
    {
        string temp = string.Empty;
        try
        {
            con.Open();
            s = "select caller_number from abmotors_call_log where id='" + id + "' ";
            cmd = new MySqlCommand(s, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            temp = ds.Tables[0].Rows[0]["caller_number"].ToString();
            con.Close();

        }
        catch (Exception)
        {
            temp = "";
        }
        return temp;
    }

    public DataSet call_log_show_search(string start, string end, string status)
    {
        ds = new DataSet();
        if (status == "--")
        {
            status = "";
        }
        try
        {
            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            if (HttpContext.Current.Session["role"].ToString() == "ADMIN")
            {
                if (start != "" && end != "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log  LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' and date>='" + start + "' and caller_status='" + status + "' order by date DESC,time DESC  ";
                }
                else if (start != "" && end != "" && status == "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' and date>='" + start + "' ORDER BY date DESC,time DESC ";
                }
                else if (start != "" && end == "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date>='" + start + "' and caller_status='" + status + "' ORDER BY date DESC,time DESC ";
                }
                else if (start == "" && end != "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' and caller_status='" + status + "' ORDER BY date DESC,time DESC  ";
                }

                else if (start != "" && end == "" && status == "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date>='" + start + "' ORDER BY date DESC,time DESC  ";
                }
                else if (start == "" && end != "" && status == "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' ORDER BY date DESC,time DESC   ";
                }
                else if (start == "" && end == "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where caller_status='" + status + "' ORDER BY date DESC,time DESC ";
                }
                else
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log  LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date='" + dat + "' order by date desc,time DESC limit 25";
                   // s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no order by date desc limit 25";
                }
            }
            if (HttpContext.Current.Session["role"].ToString() == "SALE")
            {
                if (start != "" && end != "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' and date>='" + start + "' and caller_status='" + status + "' and key_pressed='1' ORDER BY date DESC,time DESC";
                }
                else if (start != "" && end != "" && status == "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' and date>='" + start + "' and key_pressed='1' ORDER BY date DESC,time DESC ";
                }
                else if (start != "" && end == "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date>='" + start + "' and caller_status='" + status + "' and key_pressed='1' ORDER BY date DESC,time DESC";
                }
                else if (start == "" && end != "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' and caller_status='" + status + "' and key_pressed='1' ORDER BY date DESC,time DESC ";
                }

                else if (start != "" && end == "" && status == "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date>='" + start + "' and key_pressed='1' ORDER BY date DESC,time DESC ";
                }
                else if (start == "" && end != "" && status == "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' and key_pressed='1' ORDER BY date DESC,time DESC";
                }
                else if (start == "" && end == "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where caller_status='" + status + "' and key_pressed='1' ORDER BY date DESC,time DESC ";
                }
                else
                {
                   // s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where key_pressed='1' order by date desc limit 25";

                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log  LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date='" + dat + "'and key_pressed='1' order by date desc,time DESC limit 25";

                }
            }
            if (HttpContext.Current.Session["role"].ToString() == "SERVICE")
            {
                if (start != "" && end != "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' and date>='" + start + "' and caller_status='" + status + "' and key_pressed='2' ORDER BY date DESC,time DESC";
                }
                else if (start != "" && end != "" && status == "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' and date>='" + start + "' and key_pressed='2' ORDER BY date DESC,time DESC";
                }
                else if (start != "" && end == "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date>='" + start + "' and caller_status='" + status + "' and key_pressed='2' ORDER BY date DESC,time DESC";
                }
                else if (start == "" && end != "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' and caller_status='" + status + "' and key_pressed='2' ORDER BY date DESC,time DESC ";
                }

                else if (start != "" && end == "" && status == "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date>='" + start + "' and key_pressed='2' ORDER BY date DESC,time DESC";
                }
                else if (start == "" && end != "" && status == "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date<='" + end + "' and key_pressed='2' ORDER BY date DESC,time DESC ";
                }
                else if (start == "" && end == "" && status != "")
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where caller_status='" + status + "' and key_pressed='2' ORDER BY date DESC,time DESC";
                }
                else
                {
                    s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log  LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date='" + dat + "' and key_pressed='2'  order by date desc,time DESC limit 25";

                  //  s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where key_pressed='2' order by date desc limit 25";
                }
            }
            ds = new DataSet();
            con.Open();
            cmd = new MySqlCommand(s, con);
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

    public DataSet call_log_page_load()
    {
        try
        {
            ds = new DataSet();
            string dat = System.DateTime.Now.ToString("yyyy-MM-dd");
            if (HttpContext.Current.Session["role"].ToString() == "ADMIN")
                s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log  LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date='" + dat + "' order by date desc limit 25";

            if (HttpContext.Current.Session["role"].ToString() == "SERVICE")
                s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log  LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date='" + dat + "' and key_pressed='2'  order by date desc limit 25";

            if (HttpContext.Current.Session["role"].ToString() == "SALE")
                s = "select distinct called_number,name,caller_number,id,key_pressed,caller_status,caller_duration,time,Cast(date as char)as date from abmotors_call_log  LEFT JOIN sale_service ON SUBSTR(caller_number,4) = sale_service.alternate_no where date='" + dat + "'and key_pressed='1' order by date desc limit 25";

            con.Open();
            cmd = new MySqlCommand(s, con);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
        }
        catch (Exception) { ds = null; }
        return ds;
    }

    public void call_log_details_view(string date, string tim,string called_number,string caller_number,string caller_status,string caller_duration,string call_forwarding_number,string call_connected ,string call_transfer_status,string call_status,string key_pressed,string call_recording_url,string call_uuid )
    {
        con.Open();
        s = "insert into abmotors_call_log(date,time,called_number,caller_number,caller_status,caller_duration,call_forwarding_number,call_connected_to,call_transfer_status,call_status,key_pressed,call_recordingurl,call_uuid) values('" + date + "','" + tim + "','" + called_number + "','" + caller_number + "','" + caller_status + "','" + caller_duration + "','" + call_forwarding_number + "','" + call_connected + "','" + call_transfer_status + "','" + call_status + "','" + key_pressed + "','" + call_recording_url + "','" + call_uuid + "')";
        cmd = new MySqlCommand(s, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
}
/* 
 * Call Log search creteria
 * if (start != "" && end != "" && status != "" && agent !="" )
       {

           s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and caller_status='" + status + "'and ='" +agent+ "' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
       }
   else if (start != "" && end != "" && status != "" && agent == "")
   {
       s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + status + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
            
   }
   else if (start != "" && end != "" && status == "" && agent != "")
       {
           s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + status + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
       }
       else if (start != "" && end != "" && status == "" && agent == "")
       {
           s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
       }
   else if (start != "" && end == "" && status != "" && agent != "")
       {
           s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
       }
   else if (start != "" && end == "" && status != "" && agent == "")
   {
       s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
   }
   else if (start == "" && end != "" && status != "" && agent != "")
       {
           s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
       }
   else if (start == "" && end != "" && status != "" && agent == "")
   {
       s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
   }
   else if (start == "" && end == "" && status != "" && agent != "")
       {
           s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
       }
   else if (start == "" && end == "" && status != "" && agent == "")
   {
       s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
   }
   else if (start != "" && end == "" && status == "" && agent != "")
       {
           s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
       }
   else if (start != "" && end == "" && status == "" && agent == "")
   {
       s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
   }
   else if (start == "" && end != "" && status == "" && agent != "")
       {
           s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
       }
   else if (start == "" && end != "" && status == "" && agent == "")
   {
       s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
   }
   else if (start == "" && end == "" && status == "" && agent != "")
   {
       s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
   }
     else
       {
           s = "select called_number,caller_number,id,key_pressed,caller_status,caller_duration,time,date from abmotors_call_log_view where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='sale' union select role,executive_id,ticket,name,alternate_no,email,null as profession,location,source,null as model_interest,diesel_petrol,null as test_drive,null as current_vehicle_info,null as interest_in_exchange,remark,car_model,model_year,km_done,prefer_date_time,required_pickup,date_of_entry from sale_service where date_of_entry<='" + end + "' and date_of_entry>='" + start + "' and alternate_no='" + number + "'and role='service' ";
       }
   */