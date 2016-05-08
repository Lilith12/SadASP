using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aspprojecttt;

namespace WebApplication1 {
    public partial class Site1 : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            //SiteMapDataSource1.SiteMapProvider = "Web.sitemap";
            setHtmlCartSize();          
        }

        public void setHtmlCartSize() {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            int cartSize = 0;
            if (cart != null) {
                cartSize = cart.getProductListSize();
            }
            cartInfoSpan.InnerText = "Koszyk: " + cartSize;
        }
    }
}