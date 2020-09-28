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
    public partial class UploadSubDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "CloseRedirect();", true);
                return;
            }
            if (Session["username"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "CloseRedirect();", true);
                return;
            }

            if (!Page.IsPostBack)
            {
                Session["q"] = validations.remove_bad_words(Request.QueryString["q"].ToString());
                if (Session["q"] == null || Session["q"].ToString() == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "CloseRedirect();", true);
                    return;
                }
                FillAttackData(Session["q"].ToString());
                bindgrid("BindSubDetails", Session["q"].ToString());
            }
        }

        protected void FillAttackData(string param_)
        {
            DataSet ds = new DataSet();
            ds = select.bindGridView("GetAttackDetails", param_);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ldistrict.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["DistrictName"].ToString());
                ltehsil.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["TehsilName"].ToString());
                ldatetime.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["DateAndTimeofIncident"].ToString());
                lincident.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["IncidentName"].ToString());
                llocation.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["LocationName"].ToString());
                ltgi.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["TerroristGroup"].ToString());
                lnti.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["NumberofTerroristInvolved"].ToString());
                lammo.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["AmunitionRecovered"].ToString());
                linfra.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["InfectedArea"].ToString());
                lremarks.Text = HttpUtility.HtmlEncode(ds.Tables[0].Rows[0]["Remarks"].ToString());
            }
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string CasualityCivilianLocal = validations.remove_bad_words(TextBoxCivilianLocal.Text.Trim());
            string CasualityCivilianNonLocal = validations.remove_bad_words(TextBoxCivilianNonLocal.Text.Trim());
            string CasualityForceCRPF = validations.remove_bad_words(TextBoxForceCRPF.Text.Trim());
            string CasualityForceCISF = validations.remove_bad_words(TextBoxForceCISF.Text.Trim());
            string CasualityForceJKP = validations.remove_bad_words(TextBoxForceJKP.Text.Trim());
            string CasualityForceITBP = validations.remove_bad_words(TextBoxForceITBP.Text.Trim());
            string CasualityForceBSF = validations.remove_bad_words(TextBoxForceBSF.Text.Trim());
            string CasualityForceSSB = validations.remove_bad_words(TextBoxForceSSB.Text.Trim());
            string InjuryCivilianLocal = validations.remove_bad_words(TextBoxInjuryLocal.Text.Trim());
            string InjuryCivilianNonLocal = validations.remove_bad_words(TextBoxInjuryNonLocal.Text.Trim());
            string InjuryForceCRPF = validations.remove_bad_words(TextBoxInjuryForceCRPF.Text.Trim());
            string InjuryForceCISF = validations.remove_bad_words(TextBoxInjuryForceCISF.Text.Trim());
            string InjuryForceJKP = validations.remove_bad_words(TextBoxInjuryForceJKP.Text.Trim());
            string InjuryForceITBP = validations.remove_bad_words(TextBoxInjuryForceITBP.Text.Trim());
            string InjuryForceBSF = validations.remove_bad_words(TextBoxInjuryForceBSF.Text.Trim());
            string InjuryForceSSB = validations.remove_bad_words(TextBoxInjuryForceSSB.Text.Trim());
            string TerroristDeathLocal = validations.remove_bad_words(TextBoxTerroristDeathLocal.Text.Trim());
            string TerroristDeathNonLocal = validations.remove_bad_words(TextBoxTerroristDeathNonLocal.Text.Trim());
            string TerroristInjuryLocal = validations.remove_bad_words(TextBoxTerroristInjuriesLocal.Text.Trim());
            string TerroristInjuryNonLocal = validations.remove_bad_words(TextBoxTerroristInjuriesNonLocal.Text.Trim());
            string TerroristArrestedLocal = validations.remove_bad_words(TextBoxTerroristArrestedLocal.Text.Trim());
            string TerroristArrestedNonLocal = validations.remove_bad_words(TextBoxTerroristArrestedNonLocal.Text.Trim());

            if (CasualityCivilianLocal == "" && CasualityCivilianNonLocal == "" &&
                CasualityForceCRPF == "" && CasualityForceCISF == "" && CasualityForceJKP == "" &&
                CasualityForceITBP == "" && CasualityForceBSF == "" && CasualityForceSSB == "" &&
                InjuryCivilianLocal == "" && InjuryCivilianNonLocal == "" && InjuryForceCRPF == "" &&
                InjuryForceCISF == "" && InjuryForceJKP == "" && InjuryForceITBP == "" &&
                InjuryForceBSF == "" && InjuryForceSSB == "" && TerroristDeathLocal == "" &&
                TerroristDeathNonLocal == "" && TerroristInjuryLocal == "" && TerroristInjuryNonLocal == "" &&
                TerroristArrestedLocal == "" && TerroristArrestedNonLocal == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('All the fields should not be left blank');", true);
                return;
            }

            
            string msg = update.updateSubDetails(CasualityCivilianLocal, CasualityCivilianNonLocal,
                CasualityForceCRPF, CasualityForceCISF, CasualityForceJKP,
                CasualityForceITBP, CasualityForceBSF, CasualityForceSSB,
                InjuryCivilianLocal, InjuryCivilianNonLocal, InjuryForceCRPF,
                InjuryForceCISF, InjuryForceJKP, InjuryForceITBP,
                InjuryForceBSF, InjuryForceSSB, TerroristDeathLocal,
                TerroristDeathNonLocal, TerroristInjuryLocal, TerroristInjuryNonLocal,
                TerroristArrestedLocal, TerroristArrestedNonLocal, Session["q"].ToString(), "UpdateSubDetails");
            if (msg != "")
            {
                clearallfields();
                if (Button1.Text == "Submit")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Record Submitted');", true);
                    bindgrid("BindSubDetails", Session["q"].ToString());
                    return;
                }
                else if (Button1.Text == "Update")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('Record Updated');", true);
                    bindgrid("BindSubDetails", Session["q"].ToString());
                    Button1.Text = "Submit";
                    return;
                }                
            }
            //      if()
            //string msg = insert.insertSubDetails2();
        }

        private void clearallfields()
        {
            TextBoxCivilianLocal.Text = String.Empty;
            TextBoxCivilianNonLocal.Text = String.Empty;
            TextBoxForceCRPF.Text = String.Empty;
            TextBoxForceCISF.Text = String.Empty;
            TextBoxForceJKP.Text = String.Empty;
            TextBoxForceITBP.Text = String.Empty;
            TextBoxForceBSF.Text = String.Empty;
            TextBoxForceSSB.Text = String.Empty;
            TextBoxInjuryLocal.Text = String.Empty;
            TextBoxInjuryNonLocal.Text = String.Empty;
            TextBoxInjuryForceCRPF.Text = String.Empty;
            TextBoxInjuryForceCISF.Text = String.Empty;
            TextBoxInjuryForceJKP.Text = String.Empty;
            TextBoxInjuryForceITBP.Text = String.Empty;
            TextBoxInjuryForceBSF.Text = String.Empty;
            TextBoxInjuryForceSSB.Text = String.Empty;
            TextBoxTerroristDeathLocal.Text = String.Empty;
            TextBoxTerroristDeathNonLocal.Text = String.Empty;
            TextBoxTerroristInjuriesLocal.Text = String.Empty;
            TextBoxTerroristInjuriesNonLocal.Text = String.Empty;
            TextBoxTerroristArrestedLocal.Text = String.Empty;
            TextBoxTerroristArrestedNonLocal.Text = String.Empty;
        }

        private void bindgrid(string flag, string param_)
        {
            DataSet ds = new DataSet();
            ds = select.bindGridView(flag, param_);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit_1")
            {
                //int index = Convert.ToInt32(e.CommandArgument);
                Button1.Text = "Update";
                GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

                TextBoxCivilianLocal.Text = row.Cells[1].Text;
                TextBoxCivilianNonLocal.Text = row.Cells[2].Text;
                TextBoxForceCRPF.Text = row.Cells[3].Text;
                TextBoxForceCISF.Text = row.Cells[4].Text;
                TextBoxForceJKP.Text = row.Cells[5].Text;
                TextBoxForceITBP.Text = row.Cells[6].Text;
                TextBoxForceBSF.Text = row.Cells[7].Text;
                TextBoxForceSSB.Text = row.Cells[8].Text;
                TextBoxInjuryLocal.Text = row.Cells[9].Text;
                TextBoxInjuryNonLocal.Text = row.Cells[10].Text;
                TextBoxInjuryForceCRPF.Text = row.Cells[11].Text;
                TextBoxInjuryForceCISF.Text = row.Cells[12].Text;
                TextBoxInjuryForceJKP.Text = row.Cells[13].Text;
                TextBoxInjuryForceITBP.Text = row.Cells[14].Text;
                TextBoxInjuryForceBSF.Text = row.Cells[15].Text;
                TextBoxInjuryForceSSB.Text = row.Cells[16].Text;
                TextBoxTerroristDeathLocal.Text = row.Cells[17].Text;
                TextBoxTerroristDeathNonLocal.Text = row.Cells[18].Text;
                TextBoxTerroristInjuriesLocal.Text = row.Cells[19].Text;
                TextBoxTerroristInjuriesNonLocal.Text = row.Cells[20].Text;
                TextBoxTerroristArrestedLocal.Text = row.Cells[21].Text;
                TextBoxTerroristArrestedNonLocal.Text = row.Cells[22].Text;
            }
        }
    }
}