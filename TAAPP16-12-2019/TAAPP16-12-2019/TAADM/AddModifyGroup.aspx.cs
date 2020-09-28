using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TAAPP16_12_2019.DAL;
using System.Text.RegularExpressions;
using TAAPP16_12_2019.App_Code;

namespace TAAPP16_12_2019.TAADM
{
    public partial class AddModifyGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //checkCSRFGaurd();
            Response.AddHeader("Pragma", "no-cache");
            Response.CacheControl = "no-cache";
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Expires = -1;
            // Response.CacheControl = "no-cache";
            Response.CacheControl = "private";
            //ClearCache();
            //if (Session["AuthToken"] != null
            //   && Request.Cookies["AuthToken"] != null)
            //{
            //    if (!Session["AuthToken"].ToString().Equals(
            //               Request.Cookies["AuthToken"].Value))
            //    {
            //        // redirect to the login page in real application
            //        Response.Redirect("~/login.aspx");
            //    }
            //    else
            //    {
            //        Label Label1 = (Label)Master.FindControl("Label1");
            //        Label1.Text = HttpUtility.HtmlEncode(Session["username"].ToString());
            //    }
            //}
            //else
            //{
            //    Response.Redirect("~/login.aspx");
            //}
            if (Session["username"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (Session["role"] == null || Session["role"].ToString() != "A")
            {
                Response.Redirect("~/login.aspx");
            }
            if (Request.UrlReferrer == null)
            {
                Response.Redirect("~/login.aspx");
            }

            if (!Page.IsPostBack)
            {
                Bindgrid();
            }
        }

        private void Bindgrid()
        {
            DataSet ds = new DataSet();
            ds = select.bindGridView("GroupName");
            if (ds.Tables[0].Rows.Count > 0)
            {
                locationGridView.DataSource = ds.Tables[0].DefaultView;
                locationGridView.DataBind();
            }
            else
            {
                locationGridView.DataSource = null;
                locationGridView.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string locationName = "";
            string msg = "";
            //if (ddldistrict.SelectedIndex == 0)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Select District');", true);
            //    return;
            //}
            //else
            //{
            //    districtid = validations.remove_bad_words(ddldistrict.SelectedItem.Value.ToString());
            //}

            if (TextBoxGroup.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Enter Group Name');", true);
                return;
            }
            else
            {
                if (validations.alpha_Slash_space(TextBoxGroup.Text.Trim()) != true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Group Name: Alphabet Space and Slash(/) Only');", true);
                    return;
                }
                else
                {
                    locationName = validations.remove_bad_words(TextBoxGroup.Text.Trim());
                }
            }

            if (btnSubmit.Text == "Submit")
            {
                msg = insert.insertGroup(TextBoxGroup.Text.Trim());
            }
            else if (btnSubmit.Text == "Update")
            {
                msg = update.updateGroup("UpdateGroup", locationName, Session["GroupId"].ToString());
            }

            if (msg != "")
            {                
                Bindgrid();
                TextBoxGroup.Text = "";
                TextBoxGroup.Focus();
                btnSubmit.Text = "Submit";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + msg + "');", true);
            }
        }

        protected void locationGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            locationGridView.PageIndex = e.NewPageIndex;
            Bindgrid();
        }

        protected void locationGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update_1")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Session["GroupId"] = index;
                GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                Label lbl = row.FindControl("lblIncident") as Label; //locationGridView.Rows[index].FindControl["lblIncident"]
                TextBoxGroup.Text = HttpUtility.HtmlEncode(lbl.Text.Trim());

                btnSubmit.Text = "Update";
            }
        }
    }
}