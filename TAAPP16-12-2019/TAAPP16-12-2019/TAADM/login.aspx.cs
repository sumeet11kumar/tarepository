using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using TAAPP16_12_2019.DAL;
using System.Data;
using System.Web.Security;

namespace TAAPP16_12_2019.TAADM
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AddHeader("Pragma", "no-cache");
            Response.CacheControl = "no-cache";
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Expires = -1;

            if (Request.QueryString["ReturnUrl"] != null)
            {
                Response.Redirect("login.aspx");
            }

            if (!Page.IsPostBack)
            {
                this.Session["hf1"] = DAL.select.getSaltValue();
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            ////MasterPageFile = "administrator.master";
            if (!this.Page.EnableViewStateMac)
            {
                throw new InvalidOperationException(
                    "The page does NOT have the MAC enabled and the view" +
                    "state is therefore vulnerable to tampering.");
            }

            this.ViewStateUserKey = this.Session.SessionID;

        }
        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    ClearCache();
        //}
        //private void ClearCache()
        //{
        //    String pstr = "private,no-cache,must-revalidate";
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        //    Response.Cache.SetNoStore();
        //    Response.AppendHeader("Pragma", "no-cache");
        //    Response.AppendHeader("cache-control", pstr);
        //}
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
            if (TextBoxcaptcha.Value.ToString() == "")
            {
                string body = HttpUtility.HtmlEncode("Enter Security Code");
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + body + "');", true);
                return;
            }
            else
            {
                Captcha1.ValidateCaptcha(TextBoxcaptcha.Value);
                if (Captcha1.UserValidated)
                {
                    string guid = Guid.NewGuid().ToString();
                    Session["AuthToken"] = guid;
                    // now create a new cookie with this guid value
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                    string str = dbConstr.connectionString();
                    string logs, ipaddr, lgtype;
                    String uname = Request.Form["hf2"].ToString();
                    String pwd = Request.Form["hfh"].ToString();
                    uname = App_Code.validations.RemoveBad(uname);
                    if (uname == "1")
                    {
                        Response.RedirectPermanent("~/ErrorPage.aspx", true);
                        return;
                    }
                    using (SqlConnection conn = new SqlConnection(str))
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "usp_login";
                                cmd.Connection = conn;
                                cmd.Parameters.AddWithValue("@flag", "L");
                                cmd.Parameters.AddWithValue("@unm", uname);
                                cmd.Parameters.AddWithValue("@pwd", pwd);
                                //cmd.Parameters.AddWithValue("@salt", this.Session["hf1"]);
                                cmd.Parameters.Add("@uid", SqlDbType.Int).Direction = ParameterDirection.Output;
                                cmd.Parameters.Add("@role", SqlDbType.Char, 1).Direction = ParameterDirection.Output;
                                cmd.Parameters.Add("@status", SqlDbType.Char, 1).Direction = ParameterDirection.Output;
                                conn.Open();
                                cmd.ExecuteNonQuery();

                                int status = Convert.ToInt32(cmd.Parameters["@status"].Value.ToString());
                                conn.Close();

                                if (status == 1)
                                {
                                    this.Session["username"] = uname;
                                    this.Session["userid"] = Convert.ToInt32(cmd.Parameters["@uid"].Value.ToString());
                                    this.Session["role"] = cmd.Parameters["@role"].Value.ToString();

                                    // Auditrail
                                    //Boolean boo_ = ;
                                    Response.Redirect("~/TAADM/home.aspx", false);

                                }
                                else
                                {
                                    //FormsAuthentication.RedirectFromLoginPage("cpadm/login.aspx", false);

                                    string body = HttpUtility.HtmlEncode("Invalid Username/Password.");
                                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + body + "');", true);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //string title = "Login Error";
                            string body = ex.ToString();
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + body + "');", true);
                        }
                        finally
                        {
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
                else
                {
                    string body = HttpUtility.HtmlEncode("Code Not Matched");
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + body + "');", true);
                    return;
                }
            }

        }
    }
}