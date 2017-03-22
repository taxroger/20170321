namespace MVC_work1.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static category_dataRepository Getcategory_dataRepository()
		{
			var repository = new category_dataRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static category_dataRepository Getcategory_dataRepository(IUnitOfWork unitOfWork)
		{
			var repository = new category_dataRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static customer_info_viewRepository Getcustomer_info_viewRepository()
		{
			var repository = new customer_info_viewRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static customer_info_viewRepository Getcustomer_info_viewRepository(IUnitOfWork unitOfWork)
		{
			var repository = new customer_info_viewRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static user_infoRepository Getuser_infoRepository()
		{
			var repository = new user_infoRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static user_infoRepository Getuser_infoRepository(IUnitOfWork unitOfWork)
		{
			var repository = new user_infoRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static 客戶資料Repository Get客戶資料Repository()
		{
			var repository = new 客戶資料Repository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static 客戶資料Repository Get客戶資料Repository(IUnitOfWork unitOfWork)
		{
			var repository = new 客戶資料Repository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static 客戶銀行資訊Repository Get客戶銀行資訊Repository()
		{
			var repository = new 客戶銀行資訊Repository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static 客戶銀行資訊Repository Get客戶銀行資訊Repository(IUnitOfWork unitOfWork)
		{
			var repository = new 客戶銀行資訊Repository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static 客戶聯絡人Repository Get客戶聯絡人Repository()
		{
			var repository = new 客戶聯絡人Repository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static 客戶聯絡人Repository Get客戶聯絡人Repository(IUnitOfWork unitOfWork)
		{
			var repository = new 客戶聯絡人Repository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}