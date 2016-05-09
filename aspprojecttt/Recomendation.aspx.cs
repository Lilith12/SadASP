using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace aspprojecttt {
    public partial class Recomendation : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            List<int> ids = generateIds();
            loadBooks(ids);
        }

        private List<int> generateIds() {
            int maxId = 17;
            Random rnd = new Random();
            List<int> bookId = new List<int>(5);

            int randomId;
            for (int i = 0; i < 5; i++) {
                randomId = rnd.Next(0, 17);
                bookId.Add(randomId);
            }

            return bookId;
        }

        private void loadBooks(List<int> ids) {
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "Books.xml");


            StringBuilder browseHtmlContent = new StringBuilder();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
                int bookId = int.Parse(node.Attributes["Id"].InnerText);
                if (ids.Contains(bookId)) {
                    String html;
                    browseHtmlContent.Append("<div name=\"book\" id=\"books\">");
                    foreach (XmlNode childNode in node.ChildNodes) {
                        html = getHtmlForColumn(childNode, bookId);
                        browseHtmlContent.Append(html);
                    }
                    browseHtmlContent.Append("</div>");
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
                    valueHtml = "<img src=\"" + columnValue + "\">";
                    valueHtml = getBookUrl(bookId, valueHtml);
                    break;
                case "Title":
                    valueHtml = "<br/> <b>" + columnValue + "</b>";
                    valueHtml = getBookUrl(bookId, valueHtml);
                    break;
                case "Author":
                    valueHtml = "<li><p>" + columnValue + "</p></li>";
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