using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC_work1.Models
{   
	public  class user_infoRepository : EFRepository<user_info>, Iuser_infoRepository
	{

	}

	public  interface Iuser_infoRepository : IRepository<user_info>
	{

	}
}