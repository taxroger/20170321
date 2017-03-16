using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC_work1.Models
{   
	public  class Customer_Info_ViewRepository : EFRepository<Customer_Info_View>, ICustomer_Info_ViewRepository
	{
        public override IQueryable<Customer_Info_View> All()
        {
            return base.All();  
        }

        public Customer_Info_View Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
    }

	public  interface ICustomer_Info_ViewRepository : IRepository<Customer_Info_View>
	{

	}
}