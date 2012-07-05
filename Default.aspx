<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Address Lookup</title>
    <style type="text/css">
        .style1
        {
            width: 160px;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server">
       <div style="text-align:center;margin:auto;width:100%">
            <table style="text-align:center;margin:auto;">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblTitle" runat="server" Text="Northwind Traders Orders" Font-Bold="true" Forecolor="#0503E7" Font-Size="XX-Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:left; font-weight:bold;" class="style1">
                        Select A Company<br />
                        one or more Inital Letters
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:TextBox ID="txtName" runat="server" AutoPostBack="true" OnTextChanged="btnLookup_Click" tab></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlName" runat="server" Width="150px" 
                            onselectedindexchanged="ddlName_SelectedIndexChanged" AutoPostBack=true>
                        </asp:DropDownList><asp:Label ID="lblNamebit" runat="server"></asp:Label>
                         
                    </td>
                </tr>
                <tr>
                    <td colspan="2"> 
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            
        </div>
  
    </form>
</body>
</html>
