using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using TAAPP16_12_2019.BAL;

namespace TAAPP16_12_2019.DAL
{
    public class select
    {
        public static DataSet getDashboard(String flag_)
        {
            ActivityClass ac = new ActivityClass();
            DataSet dset = new DataSet();
            string str = dbConstr.connectionString();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlDataAdapter cmdda = new SqlDataAdapter(ac.USP_REPORT, conn))
                {
                    if (flag_ != "")
                    {
                        cmdda.SelectCommand.Parameters.AddWithValue(ac.FLAG_PARAM, flag_);
                    }
                    cmdda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (dset = new DataSet())
                    {
                        cmdda.Fill(dset);
                    }
                }
            }
            return dset;
        }

        public static DataTable getGraphData([Optional] String flag_, [Optional] String param2_)
        {
            ActivityClass ac = new ActivityClass();
            DataTable dt = new DataTable();
            string str = dbConstr.connectionString();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlDataAdapter cmdda = new SqlDataAdapter(ac.USP_REPORT, conn))
                {
                    if(flag_ != "")
                    {
                        cmdda.SelectCommand.Parameters.AddWithValue(ac.FLAG_PARAM, flag_);
                    }                    
                    cmdda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (dt = new DataTable())
                    {
                        cmdda.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static string getSaltValue()
        {
            ActivityClass ac = new ActivityClass();
            string s = string.Empty;
            string str = dbConstr.connectionString();

            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = ac.USP_LOGIN;
                    cmd.Parameters.AddWithValue(ac.FLAG_PARAM, "S");
                    cmd.Connection = conn;
                    conn.Open();
                    Object obj = cmd.ExecuteScalar();
                    if (obj != null)
                    {
                        s = obj.ToString();
                    }
                }
            }
            return s;
        }

        public static DataSet getDistrict()
        {
            ActivityClass ac = new ActivityClass();
            DataSet ds = new DataSet();
            string str = dbConstr.connectionString();
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlDataAdapter cmdda = new SqlDataAdapter(ac.USP_DROPDOWN, conn))
                {
                    cmdda.SelectCommand.Parameters.AddWithValue(ac.FLAG_PARAM, "district");
                    cmdda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (ds = new DataSet())
                    {
                        cmdda.Fill(ds, "district");
                    }
                }
            }
            return ds;
        }

        public static DataSet getDropdown(string flag)
        {
            ActivityClass ac = new ActivityClass();
            DataSet ds = new DataSet();
            string str = dbConstr.connectionString();
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlDataAdapter cmdda = new SqlDataAdapter(ac.USP_DROPDOWN, conn))
                {
                    cmdda.SelectCommand.Parameters.AddWithValue(ac.FLAG_PARAM, flag);
                    cmdda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (ds = new DataSet())
                    {
                        cmdda.Fill(ds, "district");
                    }
                }
            }
            return ds;
        }

        public static DataSet getdetails(string flag, [Optional] string district, [Optional] string tehsil)
        {
            ActivityClass ac = new ActivityClass();
            DataSet ds = new DataSet();
            string str = dbConstr.connectionString();
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlDataAdapter cmdda = new SqlDataAdapter(ac.USP_REPORT, conn))
                {
                    cmdda.SelectCommand.Parameters.AddWithValue(ac.FLAG_PARAM, flag);
                    if (district != "")
                    {
                        cmdda.SelectCommand.Parameters.AddWithValue(ac.DISTRICT_ID, district);
                    }
                    if (tehsil != "")
                    {
                        cmdda.SelectCommand.Parameters.AddWithValue(ac.TEHSIL_ID, tehsil);
                    }
                    cmdda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (ds = new DataSet())
                    {
                        cmdda.Fill(ds, "report");
                    }
                }
            }

            return ds;
        }

        //public static DataSet getIncidentType()
        //{
        //    ActivityClass ac = new ActivityClass();
        //    DataSet ds = new DataSet();
        //    string str = dbConstr.connectionString();
        //    using (SqlConnection conn = new SqlConnection(str))
        //    {
        //        using (SqlDataAdapter cmdda = new SqlDataAdapter(ac.USP_DROPDOWN, conn))
        //        {
        //            cmdda.SelectCommand.Parameters.AddWithValue(ac.FLAG_PARAM, "IncidentType");
        //            cmdda.SelectCommand.CommandType = CommandType.StoredProcedure;
        //            using (ds = new DataSet())
        //            {
        //                cmdda.Fill(ds, "tg");
        //            }
        //        }
        //    }
        //    return ds;
        //}

        public static DataSet getTrrGroup()
        {
            ActivityClass ac = new ActivityClass();
            DataSet ds = new DataSet();
            string str = dbConstr.connectionString();
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlDataAdapter cmdda = new SqlDataAdapter(ac.USP_DROPDOWN, conn))
                {
                    cmdda.SelectCommand.Parameters.AddWithValue(ac.FLAG_PARAM, "TerroristGroup");
                    cmdda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (ds = new DataSet())
                    {
                        cmdda.Fill(ds, "tg");
                    }
                }
            }
            return ds;
        }


        public static DataSet bindGridView(string flag, [Optional] string districtid, [Optional] string ForceId_)
        {
            ActivityClass ac = new ActivityClass();
            DataSet ds = new DataSet();
            string str = dbConstr.connectionString();
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlDataAdapter cmdda = new SqlDataAdapter(ac.USP_BIND_GRIDVIEW, conn))
                {
                    cmdda.SelectCommand.Parameters.AddWithValue(ac.FLAG_PARAM, flag);
                    if (flag == "LocationDetails" || flag == "GetAttackDetails")
                    {
                        cmdda.SelectCommand.Parameters.AddWithValue(ac.DISTRICT_ID, districtid);
                    }
                    if (flag == "CivilianCasuality" || flag == "ForceCasuality" || flag == "CivilianInjury" || flag == "ForceInjury" || flag == "TerroristArrestedL" || flag == "TerroristArrestedNL" || flag == "TerroristInjuryL" || flag == "TerroristInjuryNL" || flag == "TerroristDeathL" || flag == "TerroristDeathNL" || flag == "BindSubDetails")
                    {
                        cmdda.SelectCommand.Parameters.AddWithValue(ac.AttackId, districtid);
                    }
                    cmdda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (ds = new DataSet())
                    {
                        cmdda.Fill(ds, "tg");
                    }
                }
            }
            return ds;
        }

        public static DataSet getIncident()
        {
            ActivityClass ac = new ActivityClass();
            DataSet ds = new DataSet();
            string str = dbConstr.connectionString();
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlDataAdapter cmdda = new SqlDataAdapter(ac.USP_DROPDOWN, conn))
                {
                    cmdda.SelectCommand.Parameters.AddWithValue(ac.FLAG_PARAM, "Incident");
                    cmdda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (ds = new DataSet())
                    {
                        cmdda.Fill(ds, "inci");
                    }
                }
            }
            return ds;
        }

        public static DataSet getTehsil(int districtid)
        {
            ActivityClass ac = new ActivityClass();
            DataSet ds = new DataSet();
            string str = dbConstr.connectionString();
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlDataAdapter cmdda = new SqlDataAdapter(ac.USP_DROPDOWN, conn))
                {
                    cmdda.SelectCommand.Parameters.AddWithValue(ac.FLAG_PARAM, "Tehsil");
                    cmdda.SelectCommand.Parameters.AddWithValue(ac.DISTRICT_ID, districtid);
                    cmdda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (ds = new DataSet())
                    {
                        cmdda.Fill(ds, "teh");
                    }
                }
            }
            return ds;
        }

        public static DataSet getattackDetails(string flag, string AttackId_)
        {
            ActivityClass ac = new ActivityClass();
            DataSet ds = new DataSet();
            string str = dbConstr.connectionString();
            using (SqlConnection conn = new SqlConnection(str))
            {
                using (SqlDataAdapter cmdda = new SqlDataAdapter(ac.USP_BIND_GRIDVIEW, conn))
                {
                    cmdda.SelectCommand.Parameters.AddWithValue(ac.FLAG_PARAM, flag);
                    cmdda.SelectCommand.Parameters.AddWithValue(ac.DISTRICT_ID, AttackId_);
                    cmdda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (ds = new DataSet())
                    {
                        cmdda.Fill(ds, "teh");
                    }
                }
            }
            return ds;
        }
    }
}