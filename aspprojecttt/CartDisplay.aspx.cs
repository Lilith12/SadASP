using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace aspprojecttt {
    public partial class CartDisplay : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            List<int> cartIds = getCartIds();
            loadBooks(cartIds);
        }

        private List<int> getCartIds() {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            try {
                List<int> productIds = cart.getProductList();
                return cart.getProductList();
            } catch(NullReferenceException e) {
                //Cos
            }
            return null;
        }

        private void loadBooks(List<int> ids) {

            if (ids != null) {

                XmlDocument doc = new XmlDocument();
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + "Books.xml");

                float price = 0.0f;
                StringBuilder browseHtmlContent = new StringBuilder();
                foreach (XmlNode node in doc.DocumentElement.ChildNodes) {
                    
                    int bookId = int.Parse(node.Attributes["Id"].InnerText);
                    if (ids.Contains(bookId)) {
                        String html;
                        browseHtmlContent.Append("<div name=\"book\" id=\"books\">");
                        foreach (XmlNode childNode in node.ChildNodes) {
                            html = getHtmlForColumn(childNode, bookId);
                            if(childNode.Name.CompareTo("Price") != 0) {
                                browseHtmlContent.Append(html);
                            } else {
                                float p = float.Parse(html.Replace('.', ','));
                                price = price + p;
                            }
                            
                        }
                        browseHtmlContent.Append("</div>");
                    }
                    

                }
                display.InnerHtml = browseHtmlContent.ToString();
                priceDiv.InnerHtml = "<p style=\"align: right; font-size: 18px;\">Suma: " + price + "</p>";
            }
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
                case "Price":
                    valueHtml = columnValue;
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