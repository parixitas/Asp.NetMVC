using Demo.Models;
using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
      public EmpContext db = new EmpContext();


       public EmpService service = new EmpService(new EmpContext());
        public ActionResult Index()
        {
            return View(service.ListOfEmployee());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Emp emp)
        {

            if (ModelState.IsValid)
            {
                service.AddEmployee(emp);
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp emp = service.GetEmpById(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp emp = service.GetEmpById(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if(id!= 0)
            {
                service.DeleteEmployee(id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp emp = service.GetEmpById(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Emp emp)
        {
            if (ModelState.IsValid)
            {
                service.EditEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }
    }
}