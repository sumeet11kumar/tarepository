using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.DataVisualization.Charting;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TAAPP16_12_2019.DAL;

namespace TAAPP16_12_2019
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["VAL"] == null)
                {
                    fillChart();
                }
                else if (Session["VAL"] != null)
                {
                }                
            }                
        }

        private void fillChart()
        {             
            Chart1.Visible = false;
            string query = "";
            DataTable dt = select.getGraphData("graph1");
            string[] x = new string[dt.Rows.Count];
            int[] y = new Int32[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i]["Name"].ToString() + "-(" + dt.Rows[i]["noofattacks"].ToString() + ")";
                y[i] = Convert.ToInt32(dt.Rows[i]["noofattacks"]);
            }
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            //Chart1.Legends[0].Enabled = true;
            //Chart1.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
            //Chart1.Legends[0].BackColor = System.Drawing.Color.Red;
            //Chart1.Legends["legendDefault"]. = "Disabled";

            Chart1.Series[0].LegendUrl = "Default.aspx";
            Chart1.Series[0].LabelUrl = "Default.aspx";
            Chart1.Series[0].Url = "Default.aspx";

            Chart1.Series[0].LegendPostBackValue = "#VALY-#VALX";
            Chart1.Series[0].LabelPostBackValue = "#VALY-#VALX";
            Chart1.Series[0].PostBackValue = "#VALY-#VALX";

            Chart1.Series[0].LegendMapAreaAttributes = "target=\"_parent\"";
            Chart1.Series[0].LabelMapAreaAttributes = "target=\"_parent\"";
            Chart1.Series[0].MapAreaAttributes = "target=\"_parent\"";
            Chart1.Visible = true;
        }

        protected void Chart1_Click(object sender, ImageMapEventArgs e)
        {
            HttpContext.Current.Session["VAL"] = e.PostBackValue;
            Response.Redirect("WebForm1.aspx", false);
        }
    }
}