<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculateLeave.aspx.cs" Inherits="LeaveCalculation.CalculateLeave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Calculation</title>
        
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
 
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body class="bg-dark text-light">
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="my-4">Leave Calculation <asp:Label ID="Label2" runat="server" Text=""></asp:Label> </h1>
 
            <div class="form-group">
                <label for="TextBox3">From Date:</label>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Date" CssClass="form-control bg-dark text-light"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TextBox4">To Date:</label>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Date" CssClass="form-control bg-dark text-light"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TextBox5">Reason:</label>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control bg-dark text-light"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TextBox1">Enter your salary:</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control bg-dark text-light"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calculate" CssClass="btn btn-primary" />
            </div>
            <div class="form-group">
                <label for="Label1">Result:</label>
                <asp:Label ID="Label1" runat="server" CssClass="form-control bg-dark text-light"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
