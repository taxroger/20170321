using MVC_work1.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_work1.Controllers
{
    [Authorize]
    [logExecutionTime]
    public abstract class BaseController : Controller
    {
        
    }
}