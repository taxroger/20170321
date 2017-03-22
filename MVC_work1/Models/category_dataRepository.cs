using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_work1.Models
{   
	public  class category_dataRepository : EFRepository<category_data>, Icategory_dataRepository
	{
        public List<SelectListItem> getCategories(string sCategory)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var data = this.All();

            if (string.IsNullOrEmpty(sCategory))
            {
                items.Add(new SelectListItem()
                {
                    Text = null,
                    Value = null,
                    Selected = true
                });
            }

            foreach (var item in data)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.cateogry,
                    Value = item.cateogry,
                    Selected = item.cateogry.Equals(sCategory)
                });
            }

            return items;
        }

        public SelectList getCategory_SelectList()
        {
            var data = this.All().ToList();

            var Categories = new SelectList(
                items: data,
                dataTextField: "category",
                dataValueField: "category"
                );

            return Categories;
        }
    }

	public  interface Icategory_dataRepository : IRepository<category_data>
	{

	}
}