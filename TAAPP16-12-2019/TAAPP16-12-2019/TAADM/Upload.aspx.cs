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
    public partial class Upload : System.Web.UI.Page
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
                fillDropdownForces();
            }
        }

        protected void fillDropdownForces()
        {
            DataSet ds = new DataSet();
            ds = select.getDropdown("FillForces");
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DropDownListForce.Items.Add(HttpUtility.HtmlEncode(ds.Tables[0].Rows[i]["ForceName"].ToString()));
                DropDownListForce.Items[i].Value = HttpUtility.HtmlEncode(ds.Tables[0].Rows[i]["ForceId"].ToString());
            }
            DropDownListForce.Items.Insert(0, new ListItem("--Select--", "0"));
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

        protected void radiobuttonlistCII_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetSubDetails();
            TextBoxLocalNonLocal.Text = "";
            if (radiobuttonlistCII.SelectedItem.Value == "1")
            {
                panelCasualityInjury.Visible = true; 
                panelTerrorist.Visible = false;
                panelTerroristLNL.Visible = false;
            }
            else if (radiobuttonlistCII.SelectedItem.Value == "2")
            {
                panelCasualityInjury.Visible = true;
                panelTerrorist.Visible = false;
                panelTerroristLNL.Visible = false;
            }
            else if (radiobuttonlistCII.SelectedItem.Value == "3")
            {
                panelCasualityInjury.Visible = false;
                panelTerrorist.Visible = true;
            }
            GridViewCasualityCivilian.Visible = false;
            GridViewCasualityForce.Visible = false;
            GridViewInjuryCivilian.Visible = false;
            GridViewInjuryForce.Visible = false;
        }
        protected void radiobuttonlistCF_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (radiobuttonlistCII.SelectedItem.Value == "1") // Casuality
            {                
                if (radiobuttonlistCF.SelectedItem.Value == "1") // CIVILIAN
                {
                    ds = select.bindGridView("CivilianCasuality", Session["q"].ToString());
                    GridViewCasualityCivilian.DataSource = ds;
                    GridViewCasualityCivilian.DataBind();
                    
                    GridViewCasualityCivilian.Visible = true;
                    panelCivilian.Visible = true;
                    panelForce.Visible = false;

                    GridViewCasualityForce.Visible = false;
                    GridViewInjuryCivilian.Visible = false;
                    GridViewInjuryForce.Visible = false;
                }
                else if (radiobuttonlistCF.SelectedItem.Value == "2") // FORCE
                {
                    ds = select.bindGridView("ForceCasuality", Session["q"].ToString());
                    GridViewCasualityForce.DataSource = ds;
                    GridViewCasualityForce.DataBind();
                    GridViewCasualityForce.Visible = true;                    

                    panelCivilian.Visible = false;
                    panelForce.Visible = true;

                    GridViewCasualityCivilian.Visible = false;

                    GridViewInjuryCivilian.Visible = false;
                    GridViewInjuryForce.Visible = false;
                }
                LabelTitle.Text = HttpUtility.HtmlEncode("Enter Number of Casuality");
            }
            else if (radiobuttonlistCII.SelectedItem.Value == "2") // INJURY
            {
                if (radiobuttonlistCF.SelectedItem.Value == "1") // Civilian
                {
                    ds = select.bindGridView("CivilianInjury", Session["q"].ToString());
                    GridViewInjuryCivilian.DataSource = ds;
                    GridViewInjuryCivilian.DataBind();
                   
                    GridViewInjuryCivilian.Visible = true;
                    panelCivilian.Visible = true;
                    panelForce.Visible = false;

                    GridViewInjuryForce.Visible = false;
                    GridViewCasualityForce.Visible = false;
                    GridViewCasualityCivilian.Visible = false;
                }
                else if (radiobuttonlistCF.SelectedItem.Value == "2") // Force
                {
                    ds = select.bindGridView("ForceInjury", Session["q"].ToString());
                    GridViewInjuryForce.DataSource = ds;
                    GridViewInjuryForce.DataBind();
                    GridViewInjuryForce.Visible = true;
                    GridViewInjuryCivilian.Visible = false;

                    panelCivilian.Visible = false;
                    panelForce.Visible = true;

                    GridViewInjuryCivilian.Visible = false;
                    GridViewCasualityForce.Visible = false;
                    GridViewCasualityCivilian.Visible = false;
                }
                LabelTitle.Text = HttpUtility.HtmlEncode("Enter Number of Injury");
            }
            else if (radiobuttonlistCII.SelectedItem.Value == "3") //TERRORIST
            {
                LabelTitle.Text = "";
                panelTerroristLNL.Visible = true;
                panelCivilian.Visible = false;
                panelForce.Visible = true;

                GridViewCasualityCivilian.Visible = false;
                GridViewCasualityForce.Visible = false;
                GridViewInjuryCivilian.Visible = false;
                GridViewInjuryForce.Visible = false;
            }
        }
         
        protected void radiobuttonlistDIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            radiobuttonlistLocalNonLocal.ClearSelection();
            GridView5.Visible = false;
            TextBoxLocalNonLocal.Text = "";
            panelTerroristLNL.Visible = true;
            Labeltitle2.Text = HttpUtility.HtmlEncode("Enter Number of " + validations.remove_bad_words(radiobuttonlistDIA.SelectedItem.Text.ToString()));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var str = "";
            string msg = "";
            var ForceId = "";
            var numberofCasuality = "";

            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "CloseRedirect();", true);
                return;
            }
            else
            {
                if (Session["q"] == null || Session["q"].ToString() == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "CloseRedirect();", true);
                    return;
                }
            }
                       

            if (radiobuttonlistCII.SelectedIndex == -1)
            {
                str = "Select Atleast One Among Casuality Injury and Terrorist";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                return;
            }
            else if (radiobuttonlistCII.SelectedIndex == 0) // Casuality
            {   
                if (radiobuttonlistCF.SelectedIndex == -1)
                {
                    str = "Select Atleast One Among Civilian and Forces";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                    return;
                }
                else if (radiobuttonlistCF.SelectedIndex == 0) //***** Civilian
                {

                    Session["casualityType"] = "CivilianCasuality";                    
                    if (TextBoxCivilian1.Text.Trim() == "")
                    {
                        str = "Enter Casuality For Civilian";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                        return;
                    }
                    else
                    {
                        if (validations.numbers(TextBoxCivilian1.Text.Trim()) != true)
                        {
                            str = "Number of Casuality: Only Numbers";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                            return;
                        }
                        else
                        {
                            numberofCasuality = validations.remove_bad_words(TextBoxCivilian1.Text.Trim());
                        }
                    }
                }
                else if (radiobuttonlistCF.SelectedIndex == 1) // Force
                {                    
                    Session["casualityType"] = "ForceCasuality";
                    if (DropDownListForce.SelectedIndex == 0)
                    {
                        str = "Select Force";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                        return;
                    }
                    else
                    {
                        ForceId = validations.remove_bad_words(DropDownListForce.SelectedItem.Value.ToString());
                    }
                    if (TextBoxForce1.Text.Trim() == "")
                    {
                        str = "Enter Casuality For Force";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                        return;
                    }
                    else
                    {
                        if (validations.numbers(TextBoxForce1.Text.Trim()) != true)
                        {
                            str = "Number of Injury: Only Numbers";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                            return;
                        }
                        else
                        {
                            numberofCasuality = validations.remove_bad_words(TextBoxForce1.Text.Trim());
                        }
                    }
                }                
            }
            else if (radiobuttonlistCII.SelectedIndex == 1) //**** Injury
            {
                //Session["casualityType"] = "CivilianInjury";
                if (radiobuttonlistCF.SelectedIndex == 0) // Civilian
                {
                    Session["casualityType"] = "CivilianInjury";
                    if (TextBoxCivilian1.Text.Trim() == "")
                    {
                        str = "Enter Casuality For Civilian";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                        return;
                    }
                    else
                    {
                        if (validations.numbers(TextBoxCivilian1.Text.Trim()) != true)
                        {
                            str = "Number of Casuality: Only Numbers";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                            return;
                        }
                        else
                        {
                            numberofCasuality = validations.remove_bad_words(TextBoxCivilian1.Text.Trim());
                        }
                    }

                }
                else if (radiobuttonlistCF.SelectedIndex == 1) // Force
                {
                    Session["casualityType"] = "ForceInjury";
                    if (DropDownListForce.SelectedIndex == 0)
                    {
                        str = "Select Force";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                        return;
                    }
                    else
                    {
                        ForceId = validations.remove_bad_words(DropDownListForce.SelectedItem.Value.ToString());
                    }
                    if (TextBoxForce1.Text.Trim() == "")
                    {
                        str = "Enter Casuality For Force";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                        return;
                    }
                    else
                    {
                        if (validations.numbers(TextBoxForce1.Text.Trim()) != true)
                        {
                            str = "Number of Injury: Only Numbers";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                            return;
                        }
                        else
                        {
                            numberofCasuality = validations.remove_bad_words(TextBoxForce1.Text.Trim());
                        }
                    }
                }
            }
            else if (radiobuttonlistCII.SelectedIndex == 2) // Terrorist
            {
                if (radiobuttonlistDIA.SelectedIndex == 0) // Death
                {
                    if (radiobuttonlistLocalNonLocal.SelectedItem.Value == "1") // Local
                    {
                        Session["casualityType"] = "TerroristDeathL";
                    }
                    else if (radiobuttonlistLocalNonLocal.SelectedItem.Value == "2") // Non-Local
                    {
                        Session["casualityType"] = "TerroristDeathNL";
                    }

                    if (TextBoxLocalNonLocal.Text.Trim() == "")
                    {
                        str = "Enter Number of " + HttpUtility.HtmlEncode(radiobuttonlistDIA.SelectedItem.Text.ToString());
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                        return;
                    }
                    else
                    {
                        if (validations.numbers(TextBoxLocalNonLocal.Text.Trim()) != true)
                        {
                            str = "For " + HttpUtility.HtmlEncode(radiobuttonlistDIA.SelectedItem.Text.ToString()) + ": Only Number";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                            return;
                        }
                        else
                        {
                            numberofCasuality = validations.remove_bad_words(TextBoxLocalNonLocal.Text.Trim());
                        }
                    }
                }
                else if (radiobuttonlistDIA.SelectedIndex == 1) // Injury
                {
                    if (radiobuttonlistLocalNonLocal.SelectedItem.Value == "1") // Local
                    {
                        Session["casualityType"] = "TerroristInjuryL";
                    }
                    else if (radiobuttonlistLocalNonLocal.SelectedItem.Value == "2") // Non-Local
                    {
                        Session["casualityType"] = "TerroristInjuryNL";
                    }

                    if (TextBoxLocalNonLocal.Text.Trim() == "")
                    {
                        str = "Enter Number of " + HttpUtility.HtmlEncode(radiobuttonlistDIA.SelectedItem.Text.ToString());
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                        return;
                    }
                    else
                    {
                        if (validations.numbers(TextBoxLocalNonLocal.Text.Trim()) != true)
                        {
                            str = "For " + HttpUtility.HtmlEncode(radiobuttonlistDIA.SelectedItem.Text.ToString()) + ": Only Number";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                            return;
                        }
                        else
                        {
                            numberofCasuality = validations.remove_bad_words(TextBoxLocalNonLocal.Text.Trim());
                        }
                    }
                }
                else if (radiobuttonlistDIA.SelectedIndex == 2) // Arrested
                {
                    if (radiobuttonlistLocalNonLocal.SelectedItem.Value == "1") // Local
                    {
                        Session["casualityType"] = "TerroristArrestedL";
                    }
                    else if (radiobuttonlistLocalNonLocal.SelectedItem.Value == "2") // Non-Local
                    {
                        Session["casualityType"] = "TerroristArrestedNL";
                    }

                    if (TextBoxLocalNonLocal.Text.Trim() == "")
                    {
                        str = "Enter Number of " + HttpUtility.HtmlEncode(radiobuttonlistDIA.SelectedItem.Text.ToString());
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                        return;
                    }
                    else
                    {
                        if (validations.numbers(TextBoxLocalNonLocal.Text.Trim()) != true)
                        {
                            str = "For " + HttpUtility.HtmlEncode(radiobuttonlistDIA.SelectedItem.Text.ToString()) + ": Only Number";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                            return;
                        }
                        else
                        {
                            numberofCasuality = validations.remove_bad_words(TextBoxLocalNonLocal.Text.Trim());
                        }
                    }

                    
                }
                // Insert Data
                msg = insert.insertSubDetailsArrested(Session["casualityType"].ToString(), Session["q"].ToString(), numberofCasuality);
                if (msg != "")
                {
                    str = msg;
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                    BindCasualityGrid(Session["casualityType"].ToString(), Session["q"].ToString(), "");
                    return;
                }
            }

            // Insert Data
            msg = insert.insertSubDetails(Session["casualityType"].ToString(), Session["q"].ToString(), ForceId, numberofCasuality);
            if (msg != "")
            {
                str = msg;
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + str + "');", true);
                BindCasualityGrid(Session["casualityType"].ToString(), Session["q"].ToString(), ForceId);
                return;
            }
        }

        private void BindCasualityGrid(string flag, string param_, string forceid)
        {
            DataSet ds = new DataSet();
            if (flag == "CivilianCasuality" || flag == "CivilianInjury")
            {
                ds = select.bindGridView(flag, param_);
            }
            else if (flag == "ForceCasuality" || flag == "ForceInjury")
            {
                ds = select.bindGridView(flag, param_, forceid);
            }
            else if (flag == "TerroristArrestedL" || flag == "TerroristArrestedNL" || flag == "TerroristInjuryL" || flag == "TerroristInjuryNL" || flag == "TerroristDeathL" || flag == "TerroristDeathNL")
            {
                ds = select.bindGridView(flag, param_);
            }
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (flag == "CivilianCasuality")
                {
                    GridViewCasualityCivilian.DataSource = ds;
                    GridViewCasualityCivilian.DataBind();
                    GridViewCasualityCivilian.Visible = true;
                    GridViewCasualityForce.Visible = false;
                }
                else if (flag == "ForceCasuality")
                {
                    GridViewCasualityForce.DataSource = ds;
                    GridViewCasualityForce.DataBind();
                    GridViewCasualityCivilian.Visible = false;
                    GridViewCasualityForce.Visible = true;
                }
                else if (flag == "CivilianInjury")
                {
                    GridViewInjuryCivilian.DataSource = ds;
                    GridViewInjuryCivilian.DataBind();
                    GridViewInjuryCivilian.Visible = true;
                    GridViewInjuryForce.Visible = false;
                }
                else if (flag == "ForceInjury")
                {
                    GridViewInjuryForce.DataSource = ds;
                    GridViewInjuryForce.DataBind();
                    GridViewInjuryCivilian.Visible = false;
                    GridViewInjuryForce.Visible = true;
                }
                else if (flag == "TerroristArrestedL" || flag == "TerroristArrestedNL" || flag == "TerroristInjuryL" || flag == "TerroristInjuryNL" || flag == "TerroristDeathL" || flag == "TerroristDeathNL")
                {
                    GridView5.DataSource = ds;
                    GridView5.DataBind();
                    GridView5.Visible = true;
                }
            }
            else
            {
                if (flag == "CivilianCasuality")
                {
                    GridViewCasualityCivilian.DataSource = null;
                    GridViewCasualityCivilian.DataBind();
                    GridViewCasualityCivilian.Visible = true;
                    GridViewCasualityForce.Visible = false;
                }
                else if (flag == "ForceCasuality")
                {
                    GridViewCasualityForce.DataSource = null;
                    GridViewCasualityForce.DataBind();
                    GridViewCasualityCivilian.Visible = false;
                    GridViewCasualityForce.Visible = true;
                }
                else if (flag == "CivilianInjury")
                {
                    GridViewInjuryCivilian.DataSource = null;
                    GridViewInjuryCivilian.DataBind();
                    GridViewInjuryCivilian.Visible = true;
                    GridViewInjuryForce.Visible = false;
                }
                else if (flag == "ForceInjury")
                {
                    GridViewInjuryForce.DataSource = null;
                    GridViewInjuryForce.DataBind();
                    GridViewInjuryCivilian.Visible = false;
                    GridViewInjuryForce.Visible = true;
                }
                else if (flag == "TerroristArrestedL" || flag == "TerroristArrestedNL" || flag == "TerroristInjuryL" || flag == "TerroristInjuryNL" || flag == "TerroristDeathL" || flag == "TerroristDeathNL")
                {
                    GridView5.DataSource = null;
                    GridView5.DataBind();
                    GridView5.Visible = true;
                }
            }
        }

        private void resetSubDetails()
        {
            radiobuttonlistCF.ClearSelection();
            radiobuttonlistDIA.ClearSelection();

            panelCivilian.Visible = false;
            panelForce.Visible = false;

            TextBoxCivilian1.Text = "";
            TextBoxForce1.Text = "";
            DropDownListForce.ClearSelection();

            GridViewCasualityCivilian.DataSource = null;
            GridViewCasualityCivilian.DataBind();
            
            GridViewCasualityForce.DataSource = null;
            GridViewCasualityForce.DataBind();

            GridViewCasualityCivilian.Visible = false;
            GridViewCasualityForce.Visible = false;

            radiobuttonlistLocalNonLocal.ClearSelection();
            TextBoxLocalNonLocal.Text = "";
        }

        protected void radiobuttonlistLocalNonLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (radiobuttonlistCII.SelectedIndex == 2) // Terrorist
            {
                if (radiobuttonlistDIA.SelectedIndex == 0) // Death
                {
                    if (radiobuttonlistLocalNonLocal.SelectedIndex == 0) // Local
                    {
                        Session["casualityType"] = "TerroristDeathL";                          
                    }
                    else if (radiobuttonlistLocalNonLocal.SelectedIndex == 1) // Non-Local
                    {
                        Session["casualityType"] = "TerroristDeathNL"; 
                    }
                }
                else if (radiobuttonlistDIA.SelectedIndex == 1) // Injury
                {
                    if (radiobuttonlistLocalNonLocal.SelectedIndex == 0) // Local
                    {
                        Session["casualityType"] = "TerroristInjuryL";
                    }
                    else if (radiobuttonlistLocalNonLocal.SelectedIndex == 1) // Non-Local
                    {
                        Session["casualityType"] = "TerroristInjuryNL";
                    }
                }
                else if (radiobuttonlistDIA.SelectedIndex == 2) // Arrested
                {
                    if (radiobuttonlistLocalNonLocal.SelectedIndex == 0) // Local
                    {
                        Session["casualityType"] = "TerroristArrestedL";
                    }
                    else if (radiobuttonlistLocalNonLocal.SelectedIndex == 1) // Non-Local
                    {
                        Session["casualityType"] = "TerroristArrestedNL";
                    }
                }
            }
            ds = select.bindGridView(Session["casualityType"].ToString(), Session["q"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView5.DataSource = ds;
                GridView5.DataBind();
            }
            else
            {
                GridView5.DataSource = null;
                GridView5.DataBind();
            }
            GridView5.Visible = true;
            
        }
    }
}