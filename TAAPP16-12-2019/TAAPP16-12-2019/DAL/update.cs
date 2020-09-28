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
    public class update
    {
        public static string updateAttackDetails(string flag, string districtid, [Optional] string tehsilid, string location, string incidentid, string dt, string terroristgroupinvolved, string numberofterroristinvolved, string ammorecovered, string infectedarea, string remarks, string AttackId_)
        {
            string m = "";
            ActivityClass ac = new ActivityClass();
            string str = dbConstr.connectionString();
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand(ac.USP_UPDATE, conn))
                    {
                        cmd.Parameters.AddWithValue(ac.FLAG_PARAM, flag);
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
                        cmd.Parameters.AddWithValue(ac.AttackId, AttackId_);
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

        public static string updateIncident(string flag, string location_, string IncidentId)
        {
            string m = "";
            ActivityClass ac = new ActivityClass();
            string str = dbConstr.connectionString();
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand(ac.USP_UPDATE, conn))
                    {
                        cmd.Parameters.AddWithValue(ac.FLAG_PARAM, flag);
                        cmd.Parameters.AddWithValue(ac.IncidentName, location_);
                        cmd.Parameters.AddWithValue(ac.INCIDENT_ID, IncidentId);
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

        public static string updateGroup(string flag, string group_, string GroupId_)
        {
            string m = "";
            ActivityClass ac = new ActivityClass();
            string str = dbConstr.connectionString();
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand(ac.USP_UPDATE, conn))
                    {
                        cmd.Parameters.AddWithValue(ac.FLAG_PARAM, flag);
                        cmd.Parameters.AddWithValue(ac.GroupName, group_);
                        cmd.Parameters.AddWithValue(ac.GroupId, GroupId_);
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

        public static string updateSubDetails(string CasualityCivilianLocal, string CasualityCivilianNonLocal,
                string CasualityForceCRPF, string CasualityForceCISF, string CasualityForceJKP,
                string CasualityForceITBP, string CasualityForceBSF, string CasualityForceSSB,
                string InjuryCivilianLocal, string InjuryCivilianNonLocal, string InjuryForceCRPF,
                string InjuryForceCISF, string InjuryForceJKP, string InjuryForceITBP,
                string InjuryForceBSF, string InjuryForceSSB, string TerroristDeathLocal,
                string TerroristDeathNonLocal, string TerroristInjuryLocal, string TerroristInjuryNonLocal,
                string TerroristArrestedLocal, string TerroristArrestedNonLocal, string AttackId_, string flag)
        {
            string m = "";
            ActivityClass ac = new ActivityClass();
            string str = dbConstr.connectionString();
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand(ac.USP_UPDATE, conn))
                    {
                        cmd.Parameters.AddWithValue(ac.FLAG_PARAM, flag);
                        //cmd.Parameters.AddWithValue(ac.DISTRICT_ID, districtid);
                        cmd.Parameters.AddWithValue(ac.AttackId, AttackId_);
                        cmd.Parameters.AddWithValue(ac.CasualityCivilianLocal, ((CasualityCivilianLocal == "") ? "0" : CasualityCivilianLocal));
                        cmd.Parameters.AddWithValue(ac.CasualityCivilianNonLocal, ((CasualityCivilianNonLocal == "") ? "0" : CasualityCivilianNonLocal));
                        cmd.Parameters.AddWithValue(ac.CasualityForceCRPF, ((CasualityForceCRPF == "") ? "0" : CasualityForceCRPF));
                        cmd.Parameters.AddWithValue(ac.CasualityForceCISF, ((CasualityForceCISF == "") ? "0" : CasualityForceCISF));
                        cmd.Parameters.AddWithValue(ac.CasualityForceJKP, ((CasualityForceJKP == "") ? "0" : CasualityForceJKP));
                        cmd.Parameters.AddWithValue(ac.CasualityForceITBP, ((CasualityForceITBP == "") ? "0" : CasualityForceITBP));
                        cmd.Parameters.AddWithValue(ac.CasualityForceBSF, ((CasualityForceBSF == "") ? "0" : CasualityForceBSF));
                        cmd.Parameters.AddWithValue(ac.CasualityForceSSB, ((CasualityForceSSB == "") ? "0" : CasualityForceSSB));
                        cmd.Parameters.AddWithValue(ac.InjuryCivilianLocal, ((InjuryCivilianLocal == "") ? "0" : InjuryCivilianLocal));
                        cmd.Parameters.AddWithValue(ac.InjuryCivilianNonLocal, ((InjuryCivilianNonLocal == "") ? "0" : InjuryCivilianNonLocal));
                        cmd.Parameters.AddWithValue(ac.InjuryForceCRPF, ((InjuryForceCRPF == "") ? "0" : InjuryForceCRPF));
                        cmd.Parameters.AddWithValue(ac.InjuryForceCISF, ((InjuryForceCISF == "") ? "0" : InjuryForceCISF));
                        cmd.Parameters.AddWithValue(ac.InjuryForceJKP, ((InjuryForceJKP == "") ? "0" : InjuryForceJKP));
                        cmd.Parameters.AddWithValue(ac.InjuryForceITBP, ((InjuryForceITBP == "") ? "0" : InjuryForceITBP));
                        cmd.Parameters.AddWithValue(ac.InjuryForceBSF, ((InjuryForceBSF == "") ? "0" : InjuryForceBSF));
                        cmd.Parameters.AddWithValue(ac.InjuryForceSSB, ((InjuryForceSSB == "") ? "0" : InjuryForceSSB));
                        cmd.Parameters.AddWithValue(ac.TerroristDeathLocal, ((TerroristDeathLocal == "") ? "0" : TerroristDeathLocal));
                        cmd.Parameters.AddWithValue(ac.TerroristDeathNonLocal, ((TerroristDeathNonLocal == "") ? "0" : TerroristDeathNonLocal));
                        cmd.Parameters.AddWithValue(ac.TerroristInjuryLocal, ((TerroristInjuryLocal == "") ? "0" : TerroristInjuryLocal));
                        cmd.Parameters.AddWithValue(ac.TerroristInjuryNonLocal, ((TerroristInjuryNonLocal == "") ? "0" : TerroristInjuryNonLocal));
                        cmd.Parameters.AddWithValue(ac.TerroristArrestedLocal, ((TerroristArrestedLocal == "") ? "0" : TerroristArrestedLocal));
                        cmd.Parameters.AddWithValue(ac.TerroristArrestedNonLocal, ((TerroristArrestedNonLocal == "") ? "0" : TerroristArrestedNonLocal));
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