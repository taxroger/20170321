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

namespace MVC_work1.Controllers
{
    public class CustomerContactController : Controller
    {
        客戶聯絡人Repository customerRepo = RepositoryHelper.Get客戶聯絡人Repository();

        // GET: CustomerContact
        public ActionResult Index(string sName, string sSortby, int pageNo = 1)
        {
            var data = customerRepo.All(sName, sSortby).AsQueryable();

            ViewBag.sName = sName;
            ViewBag.pageNo = pageNo;
            ViewBag.sSortby = sSortby;

            return View(data.ToPagedList(pageNo, 5));
        }

        // GET: CustomerContact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = customerRepo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: CustomerContact/Create
        public ActionResult Create()
        {
            客戶資料Repository custRepo = RepositoryHelper.Get客戶資料Repository();

            ViewBag.客戶Id = new SelectList(custRepo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: CustomerContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,isDeleted")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                //db.客戶聯絡人.Add(客戶聯絡人);
                //db.SaveChanges();

                customerRepo.Add(客戶聯絡人);
                customerRepo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            客戶資料Repository custRepo = RepositoryHelper.Get客戶資料Repository();

            ViewBag.客戶Id = new SelectList(custRepo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: CustomerContact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
//            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = customerRepo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }

            客戶資料Repository custRepo = RepositoryHelper.Get客戶資料Repository();

            ViewBag.客戶Id = new SelectList(custRepo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: CustomerContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,isDeleted")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                var db = customerRepo.UnitOfWork.Context;

                db.Entry(客戶聯絡人).State = EntityState.Modified;
                customerRepo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            客戶資料Repository custRepo = RepositoryHelper.Get客戶資料Repository();

            ViewBag.客戶Id = new SelectList(custRepo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: CustomerContact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = customerRepo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: CustomerContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = customerRepo.Find(id);
            customerRepo.Delete(客戶聯絡人);
            customerRepo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

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
