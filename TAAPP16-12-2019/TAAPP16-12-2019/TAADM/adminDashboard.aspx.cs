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

namespace TAAPP16_12_2019.TAADM
{
    public partial class adminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillDashboard();
            }
                //fillChart();
        }

        private void fillDashboard()
        {
            DataSet ds = select.getDashboard("DashBaord");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Label1.Text = ds.Tables[0].Rows[0]["str"].ToString();
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }
        }

        private void fillChart()
        {             
            //Chart1.Visible = false;
            //string query = "";
            //DataTable dt = select.getGraphData("graph1");
            //string[] x = new string[dt.Rows.Count];
            //int[] y = new Int32[dt.Rows.Count];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    x[i] = dt.Rows[i]["Name"].ToString();
            //    y[i] = Convert.ToInt32(dt.Rows[i]["noofattacks"]);
            //}
            //Chart1.Series[0].Points.DataBindXY(x, y);
            //Chart1.Series[0].ChartType = SeriesChartType.Pie;
            //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            //Chart1.Legends[0].Enabled = true;
            ////Chart1.Legends[0].Enabled = true;

            //Chart1.Series[0].LegendUrl = "Default.aspx";
            //Chart1.Series[0].LabelUrl = "Default.aspx";
            //Chart1.Series[0].Url = "Default.aspx";

            //Chart1.Series[0].LegendPostBackValue = "#VALY-#VALX";
            //Chart1.Series[0].LabelPostBackValue = "#VALY-#VALX";
            //Chart1.Series[0].PostBackValue = "#VALY-#VALX";

            //Chart1.Series[0].LegendMapAreaAttributes = "target=\"_blank\"";
            //Chart1.Series[0].LabelMapAreaAttributes = "target=\"_blank\"";
            //Chart1.Series[0].MapAreaAttributes = "target=\"_blank\"";
        }
    }
}