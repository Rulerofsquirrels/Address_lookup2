using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Focus();
        if (IsPostBack && txtName.Text.Length >= 1)
        {
           
             make_list();
            //btnLookup_Click();            
        }
        else
        {
            ListItem li = new ListItem("", "");
                      
        }
    }

    protected void make_list()
    {

        string error_msg;
        //Response.Write(txtName.Text);
        Orders ob = Query.Get_Orders(txtName.Text,
                                        out error_msg);
 
    }

   /* protected void btnLookup_Click()
    {
        string error_msg;
        //Response.Write(txtName.Text);
        Orders ob = Query.Get_Orders(txtName.Text,
                                        out error_msg);
        if (ob != null)
        {
            Display_Results(ob);
        }
        lblMessage.Text = error_msg;

    }*/

    protected void Display_Results(Orders ob)
    {
        lblMessage.Text ="FUN";
    }


    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        string error_msg;
        string stuff = txtName.Text;
        lblMessage.Text = "";
        //lblMessage.Text = ddlName.SelectedIndex.ToString;
        //Response.Write(ddlName.SelectedValue.ToString());
        if (ddlName.SelectedValue.ToString().Trim() != "")
        {
            lblMessage.Text = ddlName.SelectedItem.Text + " has " + Query.Get_Orderscount(ddlName.SelectedValue.ToString().Trim(), out error_msg) + " orders";
        }
        
        //lblNamebit.Text = "You wrote: " + stuff;
    }

    protected void btnLookup_Click(object sender, EventArgs e)
    {
        string error_msg;
        //Response.Write(txtName.Text);
        Orders ob = Query.Get_Orders(txtName.Text,out error_msg);
        lblMessage.Text = "";
        ddlName.Items.Clear();
        if (ob != null)
        {
            //Display_Results(ob);
            
           
            //Response.Write(ob.CompanyName.Count);
            
            if (ob.CompanyName.Count == 1)
            {
                lblMessage.Text = "";
                ddlName.Enabled = false;
                ddlName.Items.Clear();
               
                ListItem li = new ListItem(ob.CompanyName[0], ob.CustomerID[0]);
                ddlName.Items.Add(li);
                
                lblMessage.Text = ob.CompanyName[0] + "has " + Query.Get_Orderscount(ob.CustomerID[0], out error_msg) + " orders";
            }
            else
            {
                lblMessage.Text = "";
                ListItem linull = new ListItem("Select Company", "");
                ddlName.Items.Add(linull);
                for (int i = 0; i < ob.CompanyName.Count; i++)
                {
                    ddlName.Enabled = true;
                    ListItem li = new ListItem(ob.CompanyName[i], ob.CustomerID[i]);
                    ddlName.Items.Add(li);
                }
            }
            
        }
        else
        {
                ddlName.Enabled = false;
                lblMessage.Text = "";
                lblMessage.Text = "No companies match " + txtName.Text;
        }
        
    }
}
