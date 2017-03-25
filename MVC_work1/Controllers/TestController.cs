using ClosedXML.Excel;
using MVC_work1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC_work1.Controllers
{
    [AllowAnonymous]
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult NewPage()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult ExportToExcel()
        {
            客戶資料Repository CustomerRepo = RepositoryHelper.Get客戶資料Repository();

            DataTable dt = new DataTable("TestExcel");

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

            var data = CustomerRepo.All();

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

                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TestExcel.xlsx");
                }
            }


            //var columnNames = (from t in typeof(客戶資料).GetProperties()
            //                   select t.Name).ToList();

            //string sCol = "";
            //foreach (var item in columnNames)
            //{
            //    sCol = sCol + ',' + item.ToString() ;
            //}

            //var gv = new GridView();
            //gv.DataSource = data;

            //gv.DataBind();

            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            //Response.ContentType = "application/ms-excel";

            //return Content(sCol);

            //return View();
        }
    }
}