<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Budjettilaskuri.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Budjettilaskuri</title>
    <link href="Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/budgetStyles.less" rel="stylesheet" />
    
</head>
<body>
    <form id="budjettiLaskuri" runat="server">
    <div class="col-md-12" id="mainFormContainer">
        <div id="topButtonContainer" class="col-md-10">
        <asp:Button ID="btnNewBudget" CssClass="btn btn-primary col-md-5" OnClick="btnNewBudget_Click" runat="server" Text="Lisää uusi merkintä" />
        <asp:Button ID="btnShowBudgets" CssClass="btn btn-default col-md-5" OnClick="btnShowBudgets_Click" runat="server" Text="Näytä budjettimerkinnät" />
        </div>

        <div id="newBudgetFields" class="col-md-10 col-md-offset-1" runat="server">
            <asp:Label ID="lblDate" runat="server" Text="Valitse kuukausi budjetille: "></asp:Label>
            <div id="datepicker" class="input-group date" data-provide="datepicker" runat="server">
             <input runat="server" id="datepickerInput" name="datepicker"  type="text" class="form-control" required="required"/>
                <div class="input-group-addon">
                <span class="glyphicon glyphicon-th"></span>
                 </div>
            </div>

            <asp:Label ID="lblIncome" runat="server" Text="Syötä kuukauden tulot: "></asp:Label>
            <asp:TextBox CssClass="text-primary" ID="txtIncome" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorIncome" ControlToValidate="txtIncome" ForeColor="Red"  runat="server" EnableClientScript="false" ErrorMessage="* Syötä tulot" Display="Dynamic">
            </asp:RequiredFieldValidator>

            <asp:Label ID="lblExpenses" runat="server" Text="Syötä kuukauden menot: "></asp:Label>
            <asp:TextBox ID="txtExpenses" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorExpenses" ControlToValidate="txtExpenses" ForeColor="Red"  runat="server" EnableClientScript="false" ErrorMessage="* Syötä menot" Display="Dynamic">
            </asp:RequiredFieldValidator>
            <br />

            <asp:Label ID="lblTaxPercent" runat="server" Text="Syötä veroprosenttisi: "></asp:Label>
            <asp:TextBox ID="txtTaxPercent" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTaxPercent" ControlToValidate="txtTaxPercent" ForeColor="Red"  runat="server" EnableClientScript="false" ErrorMessage="* Syötä veroprosentti" Display="Dynamic">
            </asp:RequiredFieldValidator>
            <br />
                        <asp:RegularExpressionValidator ControlToValidate="txtTaxPercent" ID="RegularExpressionValidator1" ValidationExpression="^[1-9][0-9]?$|^100$" runat="server" ErrorMessage="Syötä veroprosentti väliltä 0-100!"></asp:RegularExpressionValidator>
            <br />

            <br />
            <asp:Button ID="btnSend" CssClass="btn" OnClick="btnSend_Click" runat="server" Text="Lisää" />
            
            <br />
            <asp:Label ID="lblSuccess" runat="server" Visible="false" Text="Budjettimerkinnän lisäys onnistui!"></asp:Label>

        </div>
        <asp:GridView class="col-md-10 table table-responsive" ID="gvBudgets" runat="server" AutoGenerateColumns="false">
            
            <Columns>
                <asp:TemplateField HeaderText="Tulot">
                    <ItemTemplate>
                        <%# Eval("Income")%>€/kuukausi
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Menot">
                    <ItemTemplate>
                        <%# Eval("Expenses")%>€/kuukausi
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Balanssi">
                    <ItemTemplate>
                        <%# Eval("Balance")%>€
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Vero %">
                    <ItemTemplate>
                        <%# Eval("TaxPercent")%>%
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Kuukausi/Vuosi">
                    <ItemTemplate>
                        <%# Eval("Date")%>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
        <div id="totalDiv" class="col-md-10">
            <asp:Label ID="lblSavingsAsp" runat="server" Visible="false" Text=""></asp:Label><br />
            <asp:Label ID="lblTaxesAsp" runat="server" Visible="false" Text=""></asp:Label>

        </div>
    </div>
    </form>

    <script src="scripts/jquery-1.9.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/budgetcalculator.js"></script>
    <script src="scripts/bootstrap-datepicker.min.js"></script>
</body>
</html>
