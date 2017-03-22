using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC_work1.Models
{   
	public  class customer_info_viewRepository : EFRepository<customer_info_view>, Icustomer_info_viewRepository
	{
        public override IQueryable<customer_info_view> All()
        {
            return base.All();
        }

        public customer_info_view Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
    }

	public  interface Icustomer_info_viewRepository : IRepository<customer_info_view>
	{

	}
}