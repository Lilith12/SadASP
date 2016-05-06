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
    public partial class Login2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public void loginUser(Object sender, EventArgs e) {
            if (Page.IsValid) {
                //Pobranie wartosci z formy logowania
                String email = emailField.Value;
                String password = passwordField.Value;
                String cmd = "UserEmail='" + email + "'";

                //Wczytanie users.xml do dataset
                DataSet ds = new DataSet();
                FileStream fs = new FileStream(Server.MapPath("Users.xml"),
                                      FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs);
                ds.ReadXml(reader);
                fs.Close();

                DataTable users = null;
                DataRow[] matches = null;

                if(ds.Tables.Count > 0) {
                    users = ds.Tables[0];
                    matches = users.Select(cmd);
                }
                
                if (matches != null && matches.Length > 0) {
                    DataRow row = matches[0];
                    String hashedpwd = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                    String pass = (String)row["UserPassword"];
                    if (String.Compare(pass, hashedpwd, false) == 0) {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect script", "alert('Poprawnie zalogowano.'); location.href='Login.aspx';", true);
                    } else {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect script", "alert('Podano złe hasło.'); location.href='Login.aspx';", true);
                    }

                } else {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect script", "alert('Nie znaleziono użytkownika.'); location.href='Register.aspx';", true);
                }
            } else {
                return;
            }
        }
    }
}