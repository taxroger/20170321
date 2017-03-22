﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_work1.Models;
using PagedList;

namespace MVC_work1.Controllers
{
    public class Customer_Info_ViewController : BaseController
    {
        //private CustomerDataEntities db = new CustomerDataEntities();

        customer_info_viewRepository civRepo = RepositoryHelper.Getcustomer_info_viewRepository();

        // GET: Customer_Info_View
        public ActionResult Index(int pageNo = 1)
        {
            var data = civRepo.All().AsQueryable();

            //return View(db.Customer_Info_View.ToList());
            return View(civRepo.All().OrderBy(p => p.客戶名稱).ToPagedList(pageNo, 5));

        }

        // GET: Customer_Info_View/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_info_view customer_Info_View = civRepo.Find(id.Value);
            if (customer_Info_View == null)
            {
                return HttpNotFound();
            }
            return View(customer_Info_View);
        }

        // GET: Customer_Info_View/Create

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
