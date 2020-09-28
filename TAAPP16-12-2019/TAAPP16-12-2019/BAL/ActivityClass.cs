using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAAPP16_12_2019.BAL
{
    public class ActivityClass
    {
        // Parameters
        public string FLAG_PARAM = "@flag";
        public string DISTRICT_ID = "@districtid";
        public string TEHSIL_ID = "@TehsilId";
        public string LOCATION_ID = "@LocationId";
        public string INCIDENT_ID = "@IncidentId";
        public string DateAndTimeOfIncident = "@DateAndTimeofIncident";
        public string TerroristGroupInvolved = "@TerroristGroupInvolved";
        public string NumberOfTerroristInvolved = "@NumberofTerroristInvolved";
        public string AmmunitionRecovered = "@AmunitionRecovered";
        public string InfectedArea = "@InfectedArea";
        public string Remarks = "@Remarks";
        public string LocationName = "@LocationName";
        public string IncidentName = "@IncidentName";
        public string GroupName = "@GroupName";
        public string GroupId = "@GroupId";

        public string AttackId = "@AttackId";
        public string CasualityType = "@CasualityType";
        public string ForceId = "@ForceId";
        public string NumberofCasuality = "@NumberofCasuality";

        public string CasualityCivilianLocal = "@CasualityCivilianLocal";
        public string CasualityCivilianNonLocal = "@CasualityCivilianNonLocal";
        public string CasualityForceCRPF = "@CasualityForceCRPF"; 
        public string CasualityForceCISF = "@CasualityForceCISF";
        public string CasualityForceJKP = "@CasualityForceJKP";
        public string CasualityForceITBP = "@CasualityForceITBP"; 
        public string CasualityForceBSF = "@CasualityForceBSF";
        public string CasualityForceSSB = "@CasualityForceSSB";
        public string InjuryCivilianLocal = "@InjuryCivilianLocal"; 
        public string InjuryCivilianNonLocal = "@InjuryCivilianNonLocal";
        public string InjuryForceCRPF = "@InjuryForceCRPF";
        public string InjuryForceCISF = "@InjuryForceCISF"; 
        public string InjuryForceJKP = "@InjuryForceJKP";
        public string InjuryForceITBP = "@InjuryForceITBP";
        public string InjuryForceBSF = "@InjuryForceBSF"; 
        public string InjuryForceSSB = "@InjuryForceSSB"; 
        public string TerroristDeathLocal = "@TerroristDeathLocal";
        public string TerroristDeathNonLocal = "@TerroristDeathNonLocal"; 
        public string TerroristInjuryLocal = "@TerroristInjuryLocal";
        public string TerroristInjuryNonLocal = "@TerroristInjuryNonLocal";
        public string TerroristArrestedLocal = "@TerroristArrestedLocal"; 
        public string TerroristArrestedNonLocal = "@TerroristArrestedNonLocal";


        // Stored Procedures
        public string USP_AUDITTRAIL = "usp_audittrail";
        public string USP_LOGIN = "usp_login";
        public string USP_DROPDOWN = "usp_dropdown";
        public string USP_INSERT = "usp_insert";
        public string USP_BIND_GRIDVIEW = "usp_bindGrid";
        public string USP_UPDATE = "usp_update";
        public string USP_REPORT = "usp_report";
         
    }
}