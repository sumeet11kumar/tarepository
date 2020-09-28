using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using TAAPP16_12_2019.BAL;
using System.Runtime.InteropServices;


namespace TAAPP16_12_2019.DAL
{
    public class insert
    {

        //Boolean boolStat = false;

        public static string insertAttackDetails(string districtid, [Optional] string tehsilid, string location, string incidentid, string dt, string terroristgroupinvolved, string numberofterroristinvolved, string ammorecovered, string infectedarea, string remarks)
        {
            string m = "";
            ActivityClass ac = new ActivityClass();
            string str = dbConstr.connectionString();
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand(ac.USP_INSERT, conn))
                    {
                        cmd.Parameters.AddWithValue(ac.FLAG_PARAM, "AttackDetails");
                        cmd.Parameters.AddWithValue(ac.DISTRICT_ID, districtid);
                        if (tehsilid == "")
                        {
                            cmd.Parameters.AddWithValue(ac.TEHSIL_ID, (Object)DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(ac.TEHSIL_ID, tehsilid);
                        }
                        cmd.Parameters.AddWithValue(ac.LocationName, location);
                        cmd.Parameters.AddWithValue(ac.INCIDENT_ID, incidentid);
                        cmd.Parameters.AddWithValue(ac.DateAndTimeOfIncident, dt);
                        cmd.Parameters.AddWithValue(ac.TerroristGroupInvolved, terroristgroupinvolved);
                        cmd.Parameters.AddWithValue(ac.NumberOfTerroristInvolved, numberofterroristinvolved);
                        cmd.Parameters.AddWithValue(ac.AmmunitionRecovered, ammorecovered);
                        cmd.Parameters.AddWithValue(ac.InfectedArea, infectedarea);
                        cmd.Parameters.AddWithValue(ac.Remarks, remarks);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        int j = cmd.ExecuteNonQuery();
                        m = cmd.Parameters["@msg"].Value.ToString();
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                m = "";
            }
            return m;
        }

        public static string insertSubDetailsArrested(string flag, string Attackid, string NumberOfCasuality)
        {
            string m = "";
            ActivityClass ac = new ActivityClass();
            string str = dbConstr.connectionString();
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand(ac.USP_INSERT, conn))
                    {
                        cmd.Parameters.AddWithValue(ac.FLAG_PARAM, flag);                        
                        cmd.Parameters.AddWithValue(ac.CasualityType, flag);
                        cmd.Parameters.AddWithValue(ac.AttackId, Attackid); 
                        cmd.Parameters.AddWithValue(ac.NumberofCasuality, NumberOfCasuality);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        int j = cmd.ExecuteNonQuery();
                        m = cmd.Parameters["@msg"].Value.ToString();
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                m = "";
            }
            return m;
        }

        public static string insertSubDetails(string flag, string attackid, [Optional] string forceid, string NumberOfCasuality)
        {
            string m = "";
            ActivityClass ac = new ActivityClass();
            string str = dbConstr.connectionString();
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand(ac.USP_INSERT, conn))
                    {
                        cmd.Parameters.AddWithValue(ac.FLAG_PARAM, flag);
                        //cmd.Parameters.AddWithValue(ac.DISTRICT_ID, districtid);
                        cmd.Parameters.AddWithValue(ac.AttackId, attackid);
                        cmd.Parameters.AddWithValue(ac.CasualityType, flag);
                        if (forceid != "")
                        {
                            cmd.Parameters.AddWithValue(ac.ForceId, forceid);
                        }
                        cmd.Parameters.AddWithValue(ac.NumberofCasuality, NumberOfCasuality);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        int j = cmd.ExecuteNonQuery();
                        m = cmd.Parameters["@msg"].Value.ToString();
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                m = "";
            }
            return m;
        }

        public static string insertGroup(string groupName_, [Optional] string districtid)
        {
            string m = "";
            ActivityClass ac = new ActivityClass();
            string str = dbConstr.connectionString();
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand(ac.USP_INSERT, conn))
                    {
                        cmd.Parameters.AddWithValue(ac.FLAG_PARAM, "GroupName");
                        //cmd.Parameters.AddWithValue(ac.DISTRICT_ID, districtid);
                        cmd.Parameters.AddWithValue(ac.GroupName, groupName_);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        int j = cmd.ExecuteNonQuery();
                        m = cmd.Parameters["@msg"].Value.ToString();
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                m = "";
            }
            return m;
        }

        public static string insertLocations(string incidentName_, [Optional] string districtid)
        {
            string m = "";
            ActivityClass ac = new ActivityClass();
            string str = dbConstr.connectionString();
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand(ac.USP_INSERT, conn))
                    {
                        cmd.Parameters.AddWithValue(ac.FLAG_PARAM, "IncidentType");
                        //cmd.Parameters.AddWithValue(ac.DISTRICT_ID, districtid);
                        cmd.Parameters.AddWithValue(ac.IncidentName, incidentName_);
                        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        int j = cmd.ExecuteNonQuery();
                        m = cmd.Parameters["@msg"].Value.ToString();
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                m = "";
            }
            return m;
        }
    }
}