using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Xml;
using System.Xml.Linq;

namespace aspprojecttt {
    public partial class Browse : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            String category = this.Request.QueryString["cat"];

            //String category =  Request.Form["Category"];
            int pageNumber;
            try {
                pageNumber = int.Parse(this.Request.QueryString["p"]);
            } catch (ArgumentNullException ex) {
                Console.WriteLine(ex.Message);
                pageNumber = 1;
            }

            loadBooks(category, pageNumber);
        }

        private void loadBooks(String cat, int page) {
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "Books.xml");

            int minBookId = (page - 1) * 20;
            int maxBookId = minBookId + 19; // 20 books range

            StringBuilder browseHtmlContent = new StringBuilder();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
                if (node.Attributes["Category"].InnerText.CompareTo(cat) == 0) {
                    int bookId = int.Parse(node.Attributes["Id"].InnerText);
                    if (bookId >= minBookId && bookId <= maxBookId) {
                        String html;
                        browseHtmlContent.Append("<div name=\"book\">");
                        foreach (XmlNode childNode in node.ChildNodes) {
                            html = getHtmlForColumn(childNode, bookId);
                            browseHtmlContent.Append(html);
                        }
                        browseHtmlContent.Append("</div>");
                    }
                }
            }

            display.InnerHtml = browseHtmlContent.ToString();
        }

        private String getHtmlForColumn(XmlNode node, int bookId) {
            String columnValue = node.InnerText;
            String columnName = node.Name;

            String valueHtml = "";

            switch (columnName) {
                case "Image":
                    valueHtml = "<img class=\"thumbnail\" src=\"" + columnValue + "\">";
                    valueHtml = getBookUrl(bookId, valueHtml);
                    break;
                case "Title":
                    valueHtml = "<b>" + columnValue + "</b>";
                    valueHtml = getBookUrl(bookId, valueHtml);
                    break;
                case "Author":
                    valueHtml = "<p>" + columnValue + "</p>";
                    break;
                default:
                    valueHtml = "<p>" + columnValue + "</p>";
                    break;
            }

            return valueHtml;
        }

        private String getBookUrl(int bookId, String middlePart) {
            String bookUrlPart1 = "<a href=\"" + "Book.aspx?id=" + bookId.ToString() + "\">";
            String bookUrlPart3 = "</a>";
            return bookUrlPart1 + middlePart + bookUrlPart3;
        }

    }
}