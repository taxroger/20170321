using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC_work1.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p => p.isDeleted == false);  
        }

        public 客戶銀行資訊 Find(int id)
        {
            return this.All(null, null).FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<客戶銀行資訊> All(string sCustName, string sSortBy)
        {
            var data = this.All().AsQueryable();

            if (!string.IsNullOrEmpty(sCustName))
            {
                data = data.Where(p => p.客戶資料.客戶名稱.Contains(sCustName));
            }

            //if (sSortBy == "Asc" || string.IsNullOrEmpty(sSortBy))
            //{
            //    data = data.OrderBy(p => p.客戶資料.客戶名稱);
            //}
            //else if (sSortBy == "Desc")
            //{
            //    data = data.OrderByDescending(p => p.客戶資料.客戶名稱);
            //}

            data = data.OrderBy(p => p.銀行名稱);

            return data.AsQueryable();
        }

        public override void Delete(客戶銀行資訊 entity)
        {
            entity.isDeleted = true;
        }
    }

    public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}