<%@ Page Title="Rejestracja" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="szukajka">
                <li><img src="logoKsiegarnia.png"  height="50" width="125"/></li>
                <li><a href="Login.aspx"<>Logowanie</a></li>
                <li><a class="active" href="Register.aspx"<>Rejestracja</a></li>
                <li><a href="#"<><span class="glyphicon glyphicon-shopping-cart"></span> Koszyk</a></li>
            </ul>
    <table>
        <tr>
            <td>Imie:
            </td>
            <td>
                <input type="text" runat="server" id="nameField" />
                <asp:RegularExpressionValidator id="nameRegexValidator" runat="server" Display="dynamic"
                    ControlToValidate="nameField"
                    ErrorMessage="Podano złe imię!"
                    ValidationExpression="^[A-Za-z]{3,50}$" />
                <asp:RequiredFieldValidator id="nameReqValidator" runat="server" Display="dynamic"
                    ControlToValidate="nameField" ErrorMessage="Musisz podać imię!" />
            </td>
        </tr>
        <tr>
            <td>Nazwisko:
            </td>
            <td>
                <input type="text" runat="server" id="surnameField" />
                <asp:RegularExpressionValidator id="surnameRegexValidator" runat="server" Display="dynamic"
                    ControlToValidate="surnameField"
                    ErrorMessage="Podano złe nazwisko!"
                    ValidationExpression="^[A-Za-z]{3,50}$" />
                <asp:RequiredFieldValidator id="surnameReqValidator" runat="server" Display="dynamic"
                    ControlToValidate="surnameField" ErrorMessage="Musisz podać nazwisko!" />
            </td>
        </tr>
        <tr>
            <td>Email:
            </td>
            <td>
                <input type="text" runat="server" id="emailField" name="emailField" />
                <asp:RegularExpressionValidator id="emailRegexValidator" runat="server" Display="dynamic"
                    ControlToValidate="emailField"
                    ErrorMessage="Podano zły email!"
                    ValidationExpression="^[A-Za-z0-9.]{1,}@[A-Za-z0-9]{1,}.[A-Za-z]{2,3}$" ClientIDMode="Static" />
                <asp:RequiredFieldValidator id="emailReqValidator" runat="server" Display="dynamic"
                    ControlToValidate="emailField" ErrorMessage="Musisz podać email!" />
            </td>
        </tr>
        <tr>
            <td>Hasło:
            </td>
            <td>
                <input type="password" runat="server" id="passwordField" name="passwordField" />&nbsp;
                <asp:RegularExpressionValidator id="passRegexValidator" runat="server" Display="dynamic"
                    ControlToValidate="passwordField"
                    ErrorMessage="Podano złe hasło! Hasło musi się składać z minimum 8 znaków (W tym małe i wielkie litery,cyfra i specjalny znak)"
                    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}$" />
                <asp:RequiredFieldValidator id="passReqValidator" runat="server" Display="dynamic"
                    ControlToValidate="passwordField" ErrorMessage="Musisz podać hasło!" />
            </td>
        </tr>
        <tr>
            <td>Powtórz hasło:
            </td>
            <td>
                <input type="password" runat="server" id="passwordConfirmationField" name="passwordConfirmationField" />
                <asp:CompareValidator id="passConfRegexValidator" runat="server" Display="dynamic"
                    ControlToValidate="passwordConfirmationField"
                    ControlToCompare="passwordField"
                    ErrorMessage="Wpisane hasła nie są takie same!" />
                <asp:RequiredFieldValidator id="passConfReqValidator" runat="server" Display="dynamic"
                    ControlToValidate="passwordConfirmationField" ErrorMessage="Musisz powtórzyć podane hasło!" />
            </td>
        </tr>
    </table>
    <asp:Button CssClass="formButton" ID="RegisterButton" runat="server" Text="Zarejestruj" OnClick="registerUser" />
</asp:Content>
