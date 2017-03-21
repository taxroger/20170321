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
    public class BankController : BaseController
    {
        //private CustomerDataEntities db = new CustomerDataEntities();

        客戶銀行資訊Repository custBankRepo = RepositoryHelper.Get客戶銀行資訊Repository();

        // GET: Bank
        public ActionResult Index(string sCustName, string sSortby, int pageNo = 1)
        {
            //var 客戶銀行資訊 = db.客戶銀行資訊.Include(客 => 客.客戶資料);
            //return View(客戶銀行資訊.ToList());

            var data = custBankRepo.All(sCustName, sSortby);

            ViewBag.sCustName = sCustName;
            ViewBag.sSortby = sSortby;
            ViewBag.pageNo = pageNo;

            return View(data.ToPagedList(pageNo, 5));
        }

        // GET: Bank/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            客戶銀行資訊 客戶銀行資訊 = custBankRepo.Find(id.Value);

            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: Bank/Create
        public ActionResult Create()
        {
            var custData = RepositoryHelper.Get客戶資料Repository();

            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            ViewBag.客戶Id = new SelectList(custData.All(), "Id", "客戶名稱");

            return View();
        }

        // POST: Bank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼,isDeleted")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                //db.客戶銀行資訊.Add(客戶銀行資訊);
                //db.SaveChanges();

                custBankRepo.Add(客戶銀行資訊);
                custBankRepo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            var custData = RepositoryHelper.Get客戶資料Repository();

            ViewBag.客戶Id = new SelectList(custData.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: Bank/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            客戶銀行資訊 客戶銀行資訊 = custBankRepo.Find(id.Value);

            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }

            var custData = RepositoryHelper.Get客戶資料Repository();

            ViewBag.客戶Id = new SelectList(custData.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: Bank/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼,isDeleted")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                var db = custBankRepo.UnitOfWork.Context;

                //db.Entry(客戶銀行資訊).State = EntityState.Modified;
                //db.SaveChanges();

                db.Entry(客戶銀行資訊).State = EntityState.Modified;
                custBankRepo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            var custData = RepositoryHelper.Get客戶資料Repository();

            ViewBag.客戶Id = new SelectList(custData.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: Bank/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            客戶銀行資訊 客戶銀行資訊 = custBankRepo.Find(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: Bank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            //db.客戶銀行資訊.Remove(客戶銀行資訊);
            //db.SaveChanges();

            客戶銀行資訊 客戶銀行資訊 = custBankRepo.Find(id);
            custBankRepo.Delete(客戶銀行資訊);
            custBankRepo.UnitOfWork.Commit();

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
