using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public static class Query
{
    public static SqlDataReader Get_List(string company_name, out string error_msg)
    {
        SqlDataReader rdr = null;
        SqlConnection cn = null;
        DropDownList list_ = new DropDownList();
        error_msg = "";
        try
        {
            
            cn = Setup_Connection();
            rdr = Get_Reader(company_name,cn);
            error_msg = "";
        }
        catch (Exception ex)
        {
            error_msg = "BROKE";
        }

        finally
        {
            if (cn != null)
            {
                cn.Close();
            }
        }
        return rdr;
    }

    public static Orders Get_Orders(string company_name, out string error_msg)
    {
        SqlDataReader rdr = null;
        SqlConnection cn = null;
        Orders adr = null;
        error_msg = "";
        try
        {
            cn = Setup_Connection();
            rdr = Get_Reader(company_name, cn);

            // Process Query Result
            if (rdr.Read())
            {
                adr = new Orders(rdr);
            }
            else
            {   
                
                error_msg = "Query Failed" ;
            }
        }
        catch (Exception ex)
        {
            error_msg = "ERROR: " + ex.Message;
        }

        finally
        {
            if (rdr != null)
            {
                rdr.Close();
            }

            if (cn != null)
            {
                cn.Close();
            }
        }
        return adr;
    }

    public static int Get_Orderscount(string company_id, out string error_msg)
    {
        SqlDataReader rdr = null;
        SqlConnection cn = null;
        int orders  = 0;
        error_msg = "";
        try
        {
            cn = Setup_Connection();
            rdr = Get_Count(company_id, cn);

            // Process Query Result
            if (rdr.Read())
            {
                
                orders=(int)rdr["countorder"];
            }
            else
            {
                orders = -1;
                error_msg = "Query Failed";
            }
        }
        catch (Exception ex)
        {
            orders = -2;
            error_msg = "ERROR: " + ex.Message;
        }

        finally
        {
            if (rdr != null)
            {
                rdr.Close();
            }

            if (cn != null)
            {
                cn.Close();
            }
        }
        return orders;
    }
   
    public static SqlConnection Setup_Connection()
    {
        String connection_string =
        WebConfigurationManager.ConnectionStrings["scorpius"].ConnectionString;

        SqlConnection cn = new SqlConnection(connection_string);

        cn.Open();
        return cn;
    }

    public static SqlDataReader Get_Reader(string company_name, SqlConnection cn)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT CompanyName, CustomerID FROM dbo.Customers WHERE (CompanyName LIKE @company_name + '%')";
        cmd.Parameters.AddWithValue("@company_name", company_name);
        cmd.Connection = cn;
        return cmd.ExecuteReader();
    }

    public static SqlDataReader Get_Count(string company_id, SqlConnection cn)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT COUNT(CustomerID) AS countorder FROM dbo.Orders WHERE (CustomerID LIKE @company_name)";
        cmd.Parameters.AddWithValue("@company_name", company_id);
        cmd.Connection = cn;
        return cmd.ExecuteReader();
    }


}

