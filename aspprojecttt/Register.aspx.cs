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
        public void changeView(Object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex++;
        }
        public void registerUser(Object sender, EventArgs e) {
            if (Page.IsValid) {
                //Pobranie wartosci z formy rejestracji
                String name = nameField.Value;
                String surname = surnameField.Value;
                String email = emailField.Value;
                String password = passwordField.Value;
                String streetU = street.Value;
                String addressU = address.Value;
                String postalCodeU = postalCode.Value;
                String cityU = city.Value;
                String phoneU = phone.Value;

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

                    DataColumn streetColumn = new DataColumn();
                    streetColumn.DataType = System.Type.GetType("System.String");
                    streetColumn.ColumnName = "UserStreet";
                    users.Columns.Add(streetColumn);

                    DataColumn addressColumn = new DataColumn();
                    addressColumn.DataType = System.Type.GetType("System.String");
                    addressColumn.ColumnName = "UserAddress";
                    users.Columns.Add(addressColumn);

                    DataColumn postalCodeColumn = new DataColumn();
                    postalCodeColumn.DataType = System.Type.GetType("System.String");
                    postalCodeColumn.ColumnName = "UserPostalCode";
                    users.Columns.Add(postalCodeColumn);

                    DataColumn cityColumn = new DataColumn();
                    cityColumn.DataType = System.Type.GetType("System.String");
                    cityColumn.ColumnName = "UserCity";
                    users.Columns.Add(cityColumn);

                    DataColumn phoneColumn = new DataColumn();
                    phoneColumn.DataType = System.Type.GetType("System.String");
                    phoneColumn.ColumnName = "UserPhone";
                    users.Columns.Add(phoneColumn);

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
                    newUser["UserStreet"] = streetU;
                    newUser["UserAddress"] = addressU;
                    newUser["UserPostalCode"] = postalCodeU;
                    newUser["UserCity"] = cityU;
                    newUser["UserPhone"] = phoneU;

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
            MultiView1.ActiveViewIndex++;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e) {

        }
    }


}