using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace aspprojecttt {
    public partial class Book : System.Web.UI.Page {
        private List<String> displayableInTableColumns = new List<String> { "Title", "Authors", "Author", "Price" };

        protected void Page_Load(object sender, EventArgs e) {
            String bookId = this.Request.QueryString["id"];
            loadBookInfo(bookId);
        }

        private void loadBookInfo(String bookId) {
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "Books.xml");

            StringBuilder browseHtmlContent = new StringBuilder();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
                String currBookId = node.Attributes["Id"].InnerText;
                if (currBookId.CompareTo(bookId) == 0) {
                    String html;
                    browseHtmlContent.Append("<div id=\"singleBook\">");
                    browseHtmlContent.Append("<table id=\"bookTable\">");
                    foreach (XmlNode childNode in node.ChildNodes) {
                        html = nodeToHtml(childNode);
                        browseHtmlContent.Append(html);
                    }
                    browseHtmlContent.Append("</table>");
                    browseHtmlContent.Append("</div>");
                    break;
                }
            }

            display.InnerHtml = browseHtmlContent.ToString();
        }

        private String nodeToHtml(XmlNode node) {
            String columnName = node.Name;
            if (displayableInTableColumns.Contains(columnName)) {
                return nodeToTableRow(node);
            } else {
                return getHtmlForColumn(node);
            }
        }

        private String getHtmlForColumn(XmlNode node) {
            String columnValue = node.InnerText;
            String columnName = node.Name;

            String valueHtml = "";

            switch (columnName) {
                case "Image":
                    valueHtml = "<img src=\"" + columnValue + "\">";
                    break;
                case "Title":
                    valueHtml = "<b>" + columnValue + "</b>";
                    break;
                case "Author":
                    valueHtml = "<p>" + columnValue + "</p>";
                    break;
                case "Price":
                    valueHtml = "<p>" + columnValue + "</p>";
                    break;
            }

            return valueHtml;
        }

        private String nodeToTableRow(XmlNode node) {
            String columnName = node.Name;

            String columnValue = node.InnerText;
            String translatedColumnName = translateColumnName(columnName);

            String row = "<tr>";
            row += "<td>" + translatedColumnName + "</td>";
            row += "<td>" + columnValue + "</td>";
            row += "</tr>";
            return row;
        }

        public void addToCart(Object sender, EventArgs e) {
            String bookId = this.Request.QueryString["id"];
            ShoppingCart cart = (ShoppingCart)Session["Cart"];

            if (cart == null) {
                cart = new ShoppingCart();
                Session["Cart"] = cart;
            }

            cart.AddItem(bookId);
            (this.Master as WebApplication1.Site1).setHtmlCartSize();
        }

        private String translateColumnName(String columnName) {
            switch (columnName) {
                case "Title":
                    return "Tytuł";
                case "Price":
                    return "Cena";
                case "Authors":
                    return "Autorzy";
                case "Author":
                    return "Autor";
            }
            return "";
        }

    }
}
