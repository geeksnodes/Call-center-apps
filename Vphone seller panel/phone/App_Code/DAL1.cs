using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for DAL1
/// </summary>
public class DAL1
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["const"].ConnectionString);
    MySqlCommand cmd;
    MySqlDataReader dr;
    String s = "";
	public DAL1()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int login(string name, string password)
    {
            con.Open();
            int i = 0;
            if (i == 0)
            {
                s = "select name1,pass from seller where name1='" + name + "'and pass='" + password + "'";
                cmd = new MySqlCommand(s,con);                
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    i = 1;
                }
                dr.Close();
            }
            if (i == 0)
            {
                s = "select name1,pass from account where name1='" + name + "'and pass='" + password + "'";
                cmd = new MySqlCommand(s, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    i = 2;
                }
                dr.Close();
            }
            if (i == 0)
            {
                s = "select name1,pass from operator where name1='" + name + "'and pass='" + password + "'";
                cmd = new MySqlCommand(s, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    i = 3;
                }
                dr.Close();
            }
            if (i == 0)
            {
                s = "select name1,pass from support where name1='" + name + "'and pass='" + password + "'";
                cmd = new MySqlCommand(s, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    i = 4;
                }
                dr.Close();
            }

            if (i == 0)
            {
                s = "select name1,pass from super1 where name1='" + name + "'and pass='" + password + "'";
                cmd = new MySqlCommand(s, con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    i = 5;
                }
                dr.Close();
            }
            return i;
        }
}