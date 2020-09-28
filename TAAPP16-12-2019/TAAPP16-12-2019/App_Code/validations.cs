using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace TAAPP16_12_2019.App_Code
{
    public class validations
    {     
        public static Boolean numbers(string num_)
        {
            Regex numberOnly = new Regex(@"\d+");
            if (numberOnly.IsMatch(Convert.ToString(num_)) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean alpha_space(string str_)
        {
            Regex alphaSpaceOnly = new Regex(@"^[a-zA-Z ]*$");
            if (alphaSpaceOnly.IsMatch(str_) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean alpha_Slash_space(string str_)
        {
            Regex alphaSpaceOnly = new Regex(@"^[a-zA-Z/ ]*$");
            if (alphaSpaceOnly.IsMatch(str_) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean alpha_number_space(string str_)
        {
            Regex alphaNumberSpaceOnly = new Regex(@"^[a-zA-Z0-9 ]*$");
            if (alphaNumberSpaceOnly.IsMatch(str_) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean alpha_space_dot(string str_)
        {
            Regex alphaSpaceOnly = new Regex(@"^[a-zA-Z. ]*$");
            if (alphaSpaceOnly.IsMatch(str_) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string RemoveBad(string strTemp)
        {
            string str = string.Empty;
            if (strTemp.Contains("'") || strTemp.Contains("@@") || strTemp.Contains(";") || strTemp.Contains(";--") || strTemp.Contains("--") || strTemp.Contains("/*") || strTemp.Contains("*/") || strTemp.Contains("="))
            {
                str = "1";
            }
            else
            {
                str = strTemp;
            }
            return str;
        }

        public static string remove_bad_words(string stringword)
        {
            string functionReturnValue = null;
            try
            {
                if (string.IsNullOrEmpty(stringword))
                {
                    return "";
                    //return functionReturnValue;
                }
                string newChars = null;
                string[] badstuff = {
			"'",
			"CREATE",
			"SELECT",
			"UNION",
			"DROP",
			";",
			"--",
			"INSERT",
			"DELETE",
			"TRUNCATE",
			"XP_",
			"*",
			"<",
			">",
			"%",
			"=",
			"SCRIPT",
			"ALERT",
			"HAVING",
			"MASTER..XP_CMDSHELL",
			"XP_STARTMAIL",
			"XP_SENDMAIL",
			"SP_MAKEWEBTASK",
			"=",
			"~",
			"!",
			"#",
			"$",
			"%",
			"^",
			"&",
			"*",
			"(",
			")",
			"_",
			"+",
			"`",
			"{",
			"}",
			"[",
			"]",
			
			";",
			"\",\"",
			",",
			
			"<",
			">",
			"?",
			"|",
			"\\",
			"\\",
			"open()",
			"sysopen()",
			"system()",
			"<>",
			"()",
			"eval()"
		};
                newChars = stringword;
                for (int i = 0; i < badstuff.Length; i++)
                {
                    newChars = newChars.Replace(badstuff[i], "");
                }
                return newChars;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("Error.aspx", true);
            }
            return functionReturnValue;
        }
    }
}