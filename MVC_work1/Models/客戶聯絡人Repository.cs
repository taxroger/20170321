using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC_work1.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public 客戶聯絡人 Find(int id)
        {
            return this.All(null, null).FirstOrDefault(p => p.Id == id);
        }

        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.isDeleted == false);
        }

        public IQueryable<客戶聯絡人> All(string sName, string sSortBy)
        {
            var data = this.All().AsQueryable();

            if (!string.IsNullOrEmpty(sName))
            {
                data = data.Where(p => p.姓名.Contains(sName));
            }

            if (sSortBy == "Asc" || string.IsNullOrEmpty(sSortBy))
            {
                data = data.OrderBy(p => p.姓名);
            }
            else if (sSortBy == "Desc")
            {
                data = data.OrderByDescending(p => p.姓名);
            }

            return data.AsQueryable();
        }

        public override void Delete(客戶聯絡人 entity)
        {
            entity.isDeleted = true;    
        }


    }

    public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}