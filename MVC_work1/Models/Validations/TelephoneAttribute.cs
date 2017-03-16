using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC_work1.Models.Validations
{
    public class TelephoneAttribute : DataTypeAttribute
    {
        private static Regex _regex = new Regex(@"\d{4}-\d{6", RegexOptions.IgnoreCase);

        public TelephoneAttribute() : base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            string sValue;
            sValue = Convert.ToString(value);

            if (!string.IsNullOrEmpty(sValue))
            {
                string sPattern = @"\d{4}-\d{6}";

                Regex reg = new Regex(sPattern, RegexOptions.IgnoreCase);

                Match regMatch = reg.Match(Convert.ToString(value));

                if (regMatch.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
           
        }

    }
}