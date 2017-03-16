using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MVC_work1.Models.Validations
{
    public class DuplicateEmail : DataTypeAttribute
    {
        public string _field;
        
        public DuplicateEmail(string sField) : base(DataType.Text)
        {
            this._field = sField;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo custProp = validationContext.ObjectType.GetProperty(this._field);

            var oCustId = custProp.GetValue(validationContext.ObjectInstance, null);

            int iCustId = Convert.ToInt32(oCustId);

            string sValue;
            sValue = Convert.ToString(value);

            客戶聯絡人Repository custContactRepo = RepositoryHelper.Get客戶聯絡人Repository();

            var data = custContactRepo.All().AsQueryable();

            data = data.Where(p => p.客戶Id == iCustId && p.Email == sValue);

            if (data.Count() > 0)
            {
                return new ValidationResult("Email Address重複!!");
            }
            else
            {
                return null;
            }


            //   return base.IsValid(value, validationContext);  
        }
    }
}