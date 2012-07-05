using System;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Orders
{
    private string compid;
    public string compId
    {
        get { return compid; }
    }
    private string compname;
    public string compName
    {
        get { return compname; }
    }
    public List<string> CompanyName = new List<string>();
    public List<string> CustomerID = new List<string>();

    public Orders(SqlDataReader rdr)
    {
        while(rdr.Read())
        {
            CompanyName.Add(rdr["CompanyName"].ToString());
            CustomerID.Add(rdr["CustomerID"].ToString());
        }
        
      
    }

}