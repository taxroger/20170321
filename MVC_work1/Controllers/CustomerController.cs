using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_work1.Models;
using PagedList;
using System.Data.Entity.Validation;
using ClosedXML.Excel;
using System.IO;
using System.Web.Security;

namespace MVC_work1.Controllers
{
    [HandleError(View = "error_DbEntityValidationException", ExceptionType = typeof(DbEntityValidationException))]
    public class CustomerController : BaseController
    {
        //private CustomerDataEntities db = new CustomerDataEntities();

        客戶資料Repository customerRepo = RepositoryHelper.Get客戶資料Repository();
        category_dataRepository cgRepo = RepositoryHelper.Getcategory_dataRepository();

        // GET: Customer
        public ActionResult Index(string sCustName, string sSortby, string sCategory, int pageNo = 1)
        {
            var data = customerRepo.All(sCustName, sSortby, sCategory).AsQueryable();

            ViewBag.sCustName = sCustName;
            ViewBag.pageNo = pageNo;
            ViewBag.sSortby = sSortby;
            ViewBag.sCategory = sCategory;

            ViewBag.categories = cgRepo.getCategories(null);

            //this.ViewData["category"] = cgRepo.getCategory_SelectList();

            return View(data.ToPagedList(pageNo, 5));
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 customerData = customerRepo.Find(id.Value);
            if (customerData == null)
            {
                return HttpNotFound();
            }
            return View(customerData);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            ViewBag.categories = cgRepo.getCategories(null);

            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,isDeleted,category,username,password")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                //db.客戶資料.Add(客戶資料);
                //db.SaveChanges();

                customerRepo.Add(客戶資料);
                customerRepo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            //ViewBag.categories = cgRepo.getCategories();
            //ViewBag.category = cgRepo.getCategory_SelectList();

            return View(客戶資料);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = customerRepo.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }

            //category_dataRepository cdRepo = RepositoryHelper.Getcategory_dataRepository();

            //ViewBag.CategoryList = new SelectList(cdRepo.All(), "category", "description", 客戶資料.category);

            //ViewBag.CategoryList = new SelectList(cdRepo.All(), "category", "category");
            ViewBag.categories = cgRepo.getCategories(客戶資料.category);

            return View(客戶資料);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,isDeleted,category")] 客戶資料 客戶資料)
        public ActionResult Edit(int id, FormCollection form, 客戶聯絡人[] data)
        {
            //if (ModelState.IsValid)
            //{
            //    var db = customerRepo.UnitOfWork.Context;
            //    db.Entry(客戶資料).State = EntityState.Modified;
            //    //db.SaveChanges();
            //    customerRepo.UnitOfWork.Commit();

            //    return RedirectToAction("Index");
            //}

            var 客戶資料 = customerRepo.Find(id);
            if (TryUpdateModel(客戶資料, new string[] { "客戶名稱", "統一編號", "電話", "傳真", "地址", "Email", "category", "username", "password" }))
            {
                if (!string.IsNullOrEmpty(客戶資料.password))
                {
                    客戶資料.password = FormsAuthentication.HashPasswordForStoringInConfigFile(客戶資料.password + "SepvTT", "sha1");
                }

                customerRepo.UnitOfWork.Commit();

                if (data != null)
                {
                    var contactRepo = RepositoryHelper.Get客戶聯絡人Repository();

                    foreach (var item in data)
                    {
                        var contact = contactRepo.Find(item.Id);

                        contact.職稱 = item.職稱;
                        contact.手機 = item.手機;
                        contact.電話 = item.電話;
                    }

                    contactRepo.UnitOfWork.Commit();

                }

                return RedirectToAction("Index");
            }

            ViewBag.categories = cgRepo.getCategories(客戶資料.category);

            return View(客戶資料);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = customerRepo.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            //db.客戶資料.Remove(客戶資料);
            //db.SaveChanges();

            客戶資料 客戶資料 = customerRepo.Find(id);
            customerRepo.Delete(客戶資料);
            customerRepo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult ExportToExcel(string sCustName, string sSortby, string sCategory)
        {
            var data = customerRepo.All(sCustName, sSortby, sCategory);

            DataTable dt = new DataTable("Customers");

            dt.Columns.AddRange(new DataColumn[8]
            {
                new DataColumn("Id"),
                new DataColumn("客戶名稱"),
                new DataColumn("統一編號"),
                new DataColumn("電話"),
                new DataColumn("傳真"),
                new DataColumn("地址"),
                new DataColumn("Email"),
                new DataColumn("category")
            });


            foreach (var item in data)
            {
                dt.Rows.Add(item.Id, item.客戶名稱, item.統一編號, item.電話, item.傳真, item.地址, item.Email, item.category);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);

                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Customers.xlsx");
                }
            }

        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        [HttpPost]
        public ActionResult saveContacts(客戶聯絡人[] data)
        {
            var contactRepo = RepositoryHelper.Get客戶聯絡人Repository();

            foreach (var item in data)
            {
                var contact = contactRepo.Find(item.Id);

                contact.職稱 = item.職稱;
                contact.手機 = item.手機;
                contact.電話 = item.電話;
            }

            contactRepo.UnitOfWork.Commit();
            
            return RedirectToAction("Index");
        }
    }
}
