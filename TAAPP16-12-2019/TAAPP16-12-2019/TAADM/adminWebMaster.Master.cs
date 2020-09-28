using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TAAPP16_12_2019.TAADM
{
    public partial class adminWebMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx", true);
            }
            if (Session["username"].ToString() == "")
            {
                Response.Redirect("login.aspx", true);
            }
            if (!Page.IsPostBack)
            {
                lblusername.Text = Convert.ToString("Welcome, <strong>" + Session["username"] + "</strong>");
            }
        }
    }
}