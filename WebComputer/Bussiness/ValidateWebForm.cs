using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bussiness
{
    public class ValidateWebForm
    {
        public ValidateWebForm()
        {}
        public static bool IsNumber(string str)
        {
            string strRegex = "[^0-9]";
            Regex regex = new Regex(strRegex);
            Match match = regex.Match(str);
            if (match.Success)
                return false;
            else
                return true;
        }
    }
}
