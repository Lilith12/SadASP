using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1 {
    public partial class Register2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public void registerUser(Object sender, EventArgs e) {
            if (Page.IsValid) {
                //Pobranie wartosci z formy rejestracji
                String name = nameField.Value;
                String surname = surnameField.Value;
                String email = emailField.Value;
                String password = passwordField.Value;

                //Wczytanie users.xml do dataset
                DataSet ds = new DataSet();
                FileStream fs = new FileStream(Server.MapPath("Users.xml"), FileMode.Open, FileAccess.ReadWrite);
                StreamReader reader = new StreamReader(fs);
                ds.ReadXml(reader);
                fs.Close();


                DataTable users = null;
                DataRow[] matches = null;


                //Sprawdzenie czy plik jest pusty
                if (ds.Tables.Count > 0) {
                    users = ds.Tables[0];
                    String cmd = "UserEmail='" + email + "'";
                    matches = users.Select(cmd);
                } else { //Pusty
                    users = new DataTable();
                    users.TableName = "User";

                    DataColumn emailColumn = new DataColumn();
                    emailColumn.DataType = System.Type.GetType("System.String");
                    emailColumn.ColumnName = "UserEmail";
                    users.Columns.Add(emailColumn);

                    DataColumn passwordColumn = new DataColumn();
                    passwordColumn.DataType = System.Type.GetType("System.String");
                    passwordColumn.ColumnName = "UserPassword";
                    users.Columns.Add(passwordColumn);

                    DataColumn nameColumn = new DataColumn();
                    nameColumn.DataType = System.Type.GetType("System.String");
                    nameColumn.ColumnName = "UserName";
                    users.Columns.Add(nameColumn);

                    DataColumn surnameColumn = new DataColumn();
                    surnameColumn.DataType = System.Type.GetType("System.String");
                    surnameColumn.ColumnName = "UserSurname";
                    users.Columns.Add(surnameColumn);

                    ds.Tables.Add(users);
                }

                //Sprawdzenie czy nie znaleziono usera o podanym emailu w bazie
                if ((matches != null && matches.Length == 0) || matches == null) {
                    String hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                    DataRow newUser = ds.Tables[0].NewRow();
                    newUser["UserEmail"] = email;
                    newUser["UserPassword"] = hashedPassword;
                    newUser["UserName"] = name;
                    newUser["UserSurname"] = surname;
                    ds.Tables[0].Rows.Add(newUser);
                    ds.AcceptChanges();

                    fs = new FileStream(Server.MapPath("Users.xml"), FileMode.Create, FileAccess.Write | FileAccess.Read);
                    StreamWriter writer = new StreamWriter(fs);
                    ds.WriteXml(writer);
                    writer.Close();
                    fs.Close();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect script", "alert('Zarejestrowano.'); location.href='Login.aspx';", true);
                } else {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect script", "alert('Istnieje już użytkownik w bazie z podanym emailem.'); location.href='Login.aspx';", true);
                }
            } else {
                return;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e) {

        }
    }


}