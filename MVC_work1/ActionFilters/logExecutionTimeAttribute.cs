using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_work1.ActionFilters
{
    public class logExecutionTimeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.aStartTime = DateTime.Now;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var exec_time = DateTime.Now - filterContext.Controller.ViewBag.aStartTime;

            string sExecTime = Convert.ToString(exec_time);
            System.Diagnostics.Debug.WriteLine("Action 執行時間:" + sExecTime);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.vStartTime = DateTime.Now;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var exec_time = DateTime.Now - filterContext.Controller.ViewBag.vStartTime;

            string sVExecTime = Convert.ToString(exec_time);
            System.Diagnostics.Debug.WriteLine("View 執行時間:" + sVExecTime);
        }
    }
}