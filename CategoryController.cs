using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website2.Controllers
{
    public class CategoryController : Controller
    {
       Db1Entities db1=new Db1Entities();
        public ActionResult Index()
        {
            return View(db1.Categories.ToList());
        }
    }
}