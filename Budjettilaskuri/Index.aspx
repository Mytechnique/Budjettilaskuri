<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Budjettilaskuri.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Budjettilaskuri</title>
    <link href="Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/blStyles.less" rel="stylesheet" />
    
</head>
<body>
    <form id="budjettiLaskuri" runat="server">
    <div>
        <asp:Button ID="btnNewBudget" OnClick="btnNewBudget_Click" runat="server" Text="Lisää uusi merkintä" />
        <asp:Button ID="btnShowBudgets" OnClick="btnShowBudgets_Click" runat="server" Text="Näytä budjettimerkinnät" />


        <div id="newBudgetFields" runat="server">

            <div id="datepicker" class="input-group date" data-provide="datepicker" runat="server">
             <input runat="server" id="datepickerInput" type="text" class="form-control" required="required"/>
                <div class="input-group-addon">
                <span class="glyphicon glyphicon-th"></span>
                 </div>
            </div>

            <asp:TextBox ID="txtTulot" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTulot" ControlToValidate="txtTulot" ForeColor="Red"  runat="server" EnableClientScript="false" ErrorMessage="* Syötä tulot" Display="Dynamic">
            </asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="txtMenot" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMenot" ControlToValidate="txtMenot" ForeColor="Red"  runat="server" EnableClientScript="false" ErrorMessage="* Syötä menot" Display="Dynamic">
            </asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="txtVeroProsentti" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorVeroProsentti" ControlToValidate="txtVeroProsentti" ForeColor="Red"  runat="server" EnableClientScript="false" ErrorMessage="* Syötä veroprosentti" Display="Dynamic">
            </asp:RequiredFieldValidator>
            <br />


            <br />
            <asp:Button ID="btnSend" OnClick="btnSend_Click" runat="server" Text="Lisää" />

            <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>

    <script src="scripts/jquery-1.9.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/budjettilaskuri.js"></script>
    <script src="scripts/bootstrap-datepicker.min.js"></script>
</body>
</html>
