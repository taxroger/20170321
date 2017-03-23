using System;
using System.Linq;
using System.Collections.Generic;
using MVC_work1.Models.Custom_Class;
using System.Linq.Expressions;

namespace MVC_work1.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public 客戶資料 Find(int id)
        {
            return this.All(null, null, null).FirstOrDefault(p => p.Id == id);
        }

        public override void Delete(客戶資料 entity)
        {
            entity.isDeleted = true;
        }

        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => p.isDeleted == false);
        }

        public IQueryable<客戶資料> All(string sCName, string sSortBy, string sCategory)
        {
            var data = this.All().AsQueryable();
            
            if (!string.IsNullOrEmpty(sCName))
            {
                data = data.Where(p => p.客戶名稱.Contains(sCName));
            }

            if (!string.IsNullOrEmpty(sCategory))
            {
                data = data.Where(p => p.category.Equals(sCategory));
            }

            data = sortBy(data, sSortBy, "客戶名稱");

            return data.AsQueryable();
        }


        private IQueryable<客戶資料> sortBy(IQueryable<客戶資料> dataPassby, string sSortBy, string sDefaultSortField)
        {
            common commClass = new common();
            string sGetOrderBy, sGetFieldName;

            sGetOrderBy = commClass.getOrderBy(sSortBy, sDefaultSortField,  out sGetFieldName);

            var param = Expression.Parameter(typeof(客戶資料), "x");
            var orderExpression = Expression.Lambda<Func<客戶資料, object>>(Expression.Property(param, sGetFieldName), param);

            if (sGetOrderBy == "Asc")
            {
                dataPassby = dataPassby.OrderBy(orderExpression);
            }
            else
            {
                dataPassby = dataPassby.OrderByDescending(orderExpression);
            }


            return dataPassby;
        }


    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}