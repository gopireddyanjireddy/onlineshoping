using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website2.Controllers
{
    public class ProductController: Controller
    {
        // GET: Product
        Db1Entities1 db1 =new Db1Entities1();

        [HttpGet]
        public ActionResult Index(string search)
        {
            List<Product1> prd = db1.Product1.ToList();
            return View(db1.Product1.Where(x => x.ptype.StartsWith(search) || search == null 
            || x.pname.StartsWith(search)||search ==null).ToList());
        }
        public ActionResult Details(int id)
        {
            Product1 p1 = db1.Product1.Find(id);
            return View(p1);

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string uname = Request.Form["t1"].ToString();
            string pwd = Request.Form["t2"].ToString();
            Userdetail obj1 = db1.Userdetails.FirstOrDefault(x => x.username == uname && x.password == pwd);
            string msg = "";
            if (obj1 == null)
            {
                //return View();
                msg = "Login Failed";
            }
            else
            {
                return Redirect(@"~/Home/Index");

            }
            ViewBag.message = msg;
            return View();
        }

        [HttpGet]
        public ActionResult Reg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reg(Userdetail u)
        {
            db1.Userdetails.Add(u);
            db1.SaveChanges();
            return RedirectToAction("Login");
        }

    }
}
