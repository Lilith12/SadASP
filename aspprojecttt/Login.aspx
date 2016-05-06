<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <ul class="szukajka">
                <li><img src="logoKsiegarnia.png"  height="50" width="125"/></li>
                <li><a class="active" href="Login.aspx"<>Logowanie</a></li>
                <li><a href="Register.aspx"<>Rejestracja</a></li>
            </ul>
        <table>
            <tr>
                <td>Email:
                </td>
                <td>
                    <input type="text" runat="server" id="emailField" />
                    <asp:RegularExpressionValidator id="emailRegexValidator" runat="server" Display="dynamic"
                        ControlToValidate="emailField"
                        ErrorMessage="Podano niepoprawny email!"
                        ValidationExpression="^[A-Za-z0-9.]{1,}@[A-Za-z0-9]{1,}.[A-Za-z]{2,3}$" />
                    <asp:RequiredFieldValidator id="emailReqValidator" runat="server" Display="dynamic"
                        ControlToValidate="emailField" ErrorMessage="Musisz podać email!" />
                </td>
            </tr>
            <tr>
                <td>Hasło:
                </td>
                <td>
                    <input type="password" runat="server" id="passwordField" />
                    <asp:RegularExpressionValidator id="passRegexValidator" runat="server" Display="dynamic"
                        ControlToValidate="passwordField"
                        ErrorMessage="Podano złe hasło! Hasło musi się składać z minimum 8 znaków (W tym małe i wielkie litery,cyfra i specjalny znak)"
                        ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}$" />
                    <asp:RequiredFieldValidator id="passReqValidator" runat="server" Display="dynamic"
                        ControlToValidate="passwordField" ErrorMessage="Musisz podać hasło!" />
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="LoginButton" runat="server" Text="Zaloguj" OnClick="loginUser" />
</asp:Content>
