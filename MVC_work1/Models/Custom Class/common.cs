using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_work1.Models.Custom_Class
{
    public class common
    {
        public string getOrderBy(string sOrderBy, string sDefaultFieldName, out string sFieldName)
        {
            string sOrder, sField = "";

            if (string.IsNullOrEmpty(sOrderBy))
            {
                sOrder = "Asc";
                sField = sDefaultFieldName;
            }
            else
            {
                int iStart;

                iStart = sOrderBy.IndexOf("_");

                sOrder = sOrderBy.Substring(0, iStart);
                sField = sOrderBy.Substring(iStart+1, sOrderBy.Length - iStart - 1);
            }

            sFieldName = sField;
            return sOrder;
        }
    }
}