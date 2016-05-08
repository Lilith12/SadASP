using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspprojecttt {
    public partial class AllBooks : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {
            BookSource2.XPath = "/Books/Book[@Id=" + GridView1.SelectedDataKey.Value.ToString() + "]";
        }
    }
}