using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TAAPP16_12_2019.TAADM
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer == null)
            {
                Response.Redirect("login.aspx", true);
            }
            if (Session["username"] == null || Convert.ToString(Session["role"]) != "A")
            {
                Response.Redirect("login.aspx", true);
            }
            else
            {
                handleredirection();
            }
        }

        private void handleredirection()
        {
            if (Convert.ToString(Session["role"]) == "A")
            {
                Response.Redirect("adminDashboard.aspx", false);
            }
        }
    }
}