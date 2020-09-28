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
using System.Collections;

namespace TAAPP16_12_2019.TAADM
{
    public partial class addModifyAttackDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SetInitialRow();  
            //checkCSRFGaurd();
            Response.AddHeader("Pragma", "no-cache");
            Response.CacheControl = "no-cache";
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Expires = -1;
            Response.CacheControl = "private";

            if (Request.UrlReferrer == null)
            {
                Response.Redirect("~/login.aspx");
            }

            if (!Page.IsPostBack)
            {
                BindDistrict();
                filltime();
                //filllocation();
                fillTerroristGroup();
                fillincident();
                Calendar1.EndDate = DateTime.Now;
                Bindgrid();
            }
        }

        private void filltime()
        {
            for (int j = 1; j <= 24; j++)
            {
                ddlHour.Items.Add(j.ToString());
            }
            for (int j = 1; j <= 59; j++)
            {
                ddlMinute.Items.Add(j.ToString());
            }
            ddlHour.Items.Insert(0, new ListItem("HH", "0"));
            ddlMinute.Items.Insert(0, new ListItem("MM", "0"));
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
            ddldistrict.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddldistrict.DataBind();
        }

        private void fillTerroristGroup()
        {
            DataSet ds = new DataSet();
            ds = select.getTrrGroup();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ddlterroristgroup.Items.Add(HttpUtility.HtmlEncode(ds.Tables[0].Rows[i]["GroupName"].ToString()));
                ddlterroristgroup.Items[i].Value = HttpUtility.HtmlEncode(ds.Tables[0].Rows[i]["GroupId"].ToString());
            }
            ddlterroristgroup.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddldistrict.DataBind();
        }

        private void fillincident()
        {
            DataSet ds = new DataSet();
            ds = select.getIncident();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ddlIncident.Items.Add(HttpUtility.HtmlEncode(ds.Tables[0].Rows[i]["IncidentName"].ToString()));
                ddlIncident.Items[i].Value = HttpUtility.HtmlEncode(ds.Tables[0].Rows[i]["IncidentId"].ToString());
            }
            ddlIncident.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddldistrict.DataBind();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // Validate whether ViewState contains the MAC fingerprint
            // Without a fingerprint, it's impossible to prevent CSRF.
            if (!this.Page.EnableViewStateMac)
            {
                throw new InvalidOperationException(
                    "The page does NOT have the MAC enabled and the view" +
                    "state is therefore vulnerable to tampering.");
            }

            this.ViewStateUserKey = this.Session.SessionID;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string districtid, location, incidentid, terroristgroupinvolved, numberofterroristinvolved, hr, mi, ammorecovered, infectedarea, remarks;
            string dt;
            var tehsilid = "";
            if (ddldistrict.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Select District');", true);
                return;
            }
            else
            {
                districtid = validations.remove_bad_words(ddldistrict.SelectedItem.Value.ToString());
            }

            if (ddltehsil.SelectedIndex != 0)
            {
                tehsilid = validations.remove_bad_words(ddltehsil.SelectedItem.Value.ToString());
            }

            if (TextBoxLocation.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Enter Location');", true);
                return;
            }
            else
            {
                if (validations.alpha_space(TextBoxLocation.Text.Trim()) != true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Location: Alphabet and Space Only');", true);
                    return;
                }
                else
                {
                    location = validations.remove_bad_words(TextBoxLocation.Text.Trim());
                }

            }

            if (ddlIncident.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Select Incident');", true);
                return;
            }
            else
            {
                incidentid = validations.remove_bad_words(ddlIncident.SelectedItem.Value.ToString());
            }

            if (TextBoxDatetimeofIncident.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Select Date of Incident');", true);
                return;
            }
            else
            {
                dt = TextBoxDatetimeofIncident.Text.Trim();
            }

            if (ddlHour.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Select Time of Incident (Hours)');", true);
                return;
            }
            else
            {
                hr = validations.remove_bad_words(ddlHour.SelectedItem.Value.ToString());
            }

            if (ddlMinute.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Select Time of Incident (Minutes)');", true);
                return;
            }
            else
            {
                mi = validations.remove_bad_words(ddlMinute.SelectedItem.Value.ToString());
            }

            if (ddlterroristgroup.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Select Terrorist Group Involved');", true);
                return;
            }
            else
            {
                terroristgroupinvolved = validations.remove_bad_words(ddlterroristgroup.SelectedItem.Value.ToString());
            }

            if (TextBoxNumberofTerroristInvolved.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Mention Number of Terrorist Involved');", true);
                return;
            }
            else
            {
                numberofterroristinvolved = validations.remove_bad_words(TextBoxNumberofTerroristInvolved.Text.Trim());
            }

            if (TextBoxAmmunationRecovered.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Mention Ammunition Recovered');", true);
                return;
            }
            else
            {
                if (validations.alpha_number_space(TextBoxAmmunationRecovered.Text.Trim()) != true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Ammunition Recovered: Alphabet Space and Number Only');", true);
                    return;
                }
                else
                {
                    ammorecovered = validations.remove_bad_words(TextBoxAmmunationRecovered.Text.Trim());
                }
            }

            if (TextBoxInfectedArea.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Mention Infra Affected');", true);
                return;
            }
            else
            {
                if (validations.alpha_number_space(TextBoxInfectedArea.Text.Trim()) != true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Infra Affected: Alphabet Number and Space Only');", true);
                    return;
                }
                else
                {
                    infectedarea = validations.remove_bad_words(TextBoxInfectedArea.Text.Trim());
                }
            }

            if (TextBoxRemarks.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Enter Remarks');", true);
                return;
            }
            else
            {
                if (validations.alpha_number_space(TextBoxRemarks.Text.Trim()) != true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Remarks: Alphabet Number and Space Only');", true);
                    return;
                }
                else
                {
                    remarks = validations.remove_bad_words(TextBoxRemarks.Text.Trim());
                }
            }

            dt = dt + " " + hr + ":" + mi;
            string msg = "";
            if (btnSubmit.Text == "Submit") // Insert
            {
                msg = insert.insertAttackDetails(districtid, tehsilid, location, incidentid, dt, terroristgroupinvolved, numberofterroristinvolved, ammorecovered, infectedarea, remarks);
            }
            else if (btnSubmit.Text == "Update") // Update
            {
                msg = update.updateAttackDetails("UpdateAttack", districtid, tehsilid, location, incidentid, dt, terroristgroupinvolved, numberofterroristinvolved, ammorecovered, infectedarea, remarks, Session["AttackId"].ToString());
            }

            if (msg != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + msg + "');", true);
                //return;
                Bindgrid();
                btnSubmit.Text = "Submit";
                clearallfields();
            }
        }

        private void clearallfields()
        {
            ddldistrict.ClearSelection();
            ddltehsil.Items.Clear();
            TextBoxDatetimeofIncident.Text = String.Empty;
            ddlHour.ClearSelection();
            ddlMinute.ClearSelection();
            ddlIncident.ClearSelection();
            TextBoxAmmunationRecovered.Text = String.Empty;
            TextBoxNumberofTerroristInvolved.Text = String.Empty;
            TextBoxRemarks.Text = String.Empty;
            btnSubmit.Text = "Submit";
        }

        private void Bindgrid()
        {
            DataSet ds = new DataSet();
            ds = select.bindGridView("AttackDetails");
            if (ds.Tables[0].Rows.Count > 0)
            {
                attackGridView.DataSource = ds.Tables[0].DefaultView;
                attackGridView.DataBind();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            clearallfields();
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


        protected void attackGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit_1")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Session["AttackId"] = index;
                DataSet ds = new DataSet();
                DataSet dsTehsil = new DataSet();
                ds = select.bindGridView("GetAttackDetails", Session["AttackId"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ddldistrict.Items.Count - 1; i++)
                    {
                        if (ddldistrict.Items[i].Value.ToString() == HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["DistrictId"].ToString()))
                        {
                            ddldistrict.SelectedIndex = i;
                        }
                    }
                    dsTehsil = select.getTehsil(Convert.ToInt32(ds.Tables[0].Rows[0]["DistrictId"].ToString()));
                    filltehsil(dsTehsil);
                    for (int i = 0; i <= ddltehsil.Items.Count - 1; i++)
                    {
                        if (ddltehsil.Items[i].Value.ToString() == HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["TehsilId"].ToString()))
                        {
                            ddltehsil.SelectedIndex = i;
                        }
                    }

                    string datetime_ = ds.Tables[0].Rows[0]["DateAndTimeofIncident"].ToString();
                    string[] param_ = datetime_.Split(' ');
                    TextBoxDatetimeofIncident.Text = param_[0].ToString().Replace(" ","-");

                    string param2_ = param_[1].ToString();
                    string[] time_ = param2_.Split(':');

                    for (int i = 0; i <= ddlHour.Items.Count - 1; i++)
                    {
                        if (Convert.ToInt32(ddlHour.Items[i].Value.ToString()) == Convert.ToInt32(time_[0].ToString()))
                        {
                            ddlHour.SelectedIndex = i;
                        }
                    }

                    for (int i = 0; i <= ddlMinute.Items.Count - 1; i++)
                    {
                        if (Convert.ToInt32(ddlMinute.Items[i].Value.ToString()) == Convert.ToInt32(time_[1].ToString()))
                        {
                            ddlMinute.SelectedIndex = i;
                        }
                    }

                    for (int i = 0; i <= ddlIncident.Items.Count - 1; i++)
                    {
                        if (ddlIncident.Items[i].Value.ToString() == HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["IncidentId"].ToString()))
                        {
                            ddlIncident.SelectedIndex = i;
                        }
                    }

                    TextBoxLocation.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["LocationName"].ToString());

                    for (int i = 0; i <= ddlterroristgroup.Items.Count - 1; i++)
                    {
                        if (ddlterroristgroup.Items[i].Value.ToString() == HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["TerroristGroupInvolved"].ToString()))
                        {
                            ddlterroristgroup.SelectedIndex = i;
                        }
                    }

                    TextBoxNumberofTerroristInvolved.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["NumberofTerroristInvolved"].ToString());
                    TextBoxAmmunationRecovered.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["AmunitionRecovered"].ToString());
                    TextBoxInfectedArea.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["InfectedArea"].ToString());
                    TextBoxRemarks.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["Remarks"].ToString());

                    btnSubmit.Text = "Update";
                }
            }
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
                ddltehsil.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        protected void attackGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            attackGridView.PageIndex = e.NewPageIndex;
            Bindgrid();
        }


    }
}