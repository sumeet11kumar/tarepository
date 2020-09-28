using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TAAPP16_12_2019.App_Code;
using TAAPP16_12_2019.DAL;

namespace TAAPP16_12_2019.TAADM
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AddHeader("Pragma", "no-cache");
            Response.CacheControl = "no-cache";
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Expires = -1;
            // Response.CacheControl = "no-cache";
            Response.CacheControl = "private";
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
                //BindDistrict();

                //BindIncidentType();
                //Bindgrid();
                BindDistrict();
            }
        }

        private void BindDistrict()
        {
            DataSet ds = new DataSet();
            ds = select.getDistrict();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ddldistrict.Items.Add(HttpUtility.HtmlEncode(ds.Tables[0].Rows[i]["DistrictName"].ToString()));
                ddldistrict.Items[i].Value = HttpUtility.HtmlEncode(ds.Tables[0].Rows[i]["DistrictId"].ToString());
            }
            ddldistrict.Items.Insert(0, new ListItem("ALL", "0"));
            //ddldistrict.DataBind();
        }

        private void filltehsil(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    ddltehsil.Items.Add(HttpUtility.HtmlEncode(ds.Tables[0].Rows[i]["TehsilName"].ToString()));
                    ddltehsil.Items[i].Value = HttpUtility.HtmlEncode(ds.Tables[0].Rows[i]["TehsilId"].ToString());
                }
                ddltehsil.Items.Insert(0, new ListItem("ALL", "0"));
            }
        }

        protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddltehsil.Items.Clear();
            if (ddldistrict.SelectedIndex != 0)
            {
                DataSet ds = new DataSet();
                ds = select.getTehsil(Convert.ToInt32(ddldistrict.SelectedItem.Value.ToString()));
                filltehsil(ds);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string flag_ = "";
            string district_ = "";
            string tehsil_ = "";
            if (ddldistrict.SelectedIndex == 0)
            {
                flag_ = "SortByAll";
            }
            else
            {
                flag_ = "SortByDistrict";
                district_ = validations.remove_bad_words(ddldistrict.SelectedItem.Value.ToString());
            }

            if (ddltehsil.SelectedIndex != 0 && ddltehsil.Items.Count > 0)
            {
                flag_ = "SortByDistrictTehsil";
                tehsil_ = validations.remove_bad_words(ddltehsil.SelectedItem.Value.ToString());
            }
            ds = select.getdetails(flag_, district_, tehsil_);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Panel1.Visible = true;
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
                //Button1.Visible = true;
            }
        }
            
    }
}