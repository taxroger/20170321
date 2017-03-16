using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC_work1.Models
{   
	public  class Customer_Info_ViewRepository : EFRepository<Customer_Info_View>, ICustomer_Info_ViewRepository
	{

	}

	public  interface ICustomer_Info_ViewRepository : IRepository<Customer_Info_View>
	{

	}
}