<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="LeaveCalculation.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Details</title>
    <!-- Bootstrap CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Optional: Include the following for Bootstrap JavaScript components -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body class="bg-dark text-light">
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="my-4">Employee Details</h1>
            <div class="form-group">
                <label for="TextBox1">Employee Name:</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control bg-dark text-light"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TextBox2">Employee Email:</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control bg-dark text-light"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TextBox3">Employee Contact:</label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control bg-dark text-light"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="TextBox4">Date of Joining:</label>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Date" CssClass="form-control bg-dark text-light"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
</body>
</html>
