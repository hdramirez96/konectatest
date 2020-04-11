using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Konecta.Controllers.ViewModels;
using Konecta.Models;
using Konecta.Models.Context;

namespace Konecta.Controllers
{
    public class EmployeesController : Controller
    {
        private KonectaContext db = new KonectaContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Employees_Read grid telerik
        public ActionResult Employees_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetEmployees().ToDataSourceResult(request));
        }

        private IEnumerable<EmployeeViewModel> GetEmployees()
        {
            var employees = db.Employees.Select(employee => new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                AdmissionDate = employee.AdmissionDate,
                Salary = employee.Salary
            });
            return employees;
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,AdmissionDate,Name,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.AdmissionDate = DateTime.Now;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,AdmissionDate,Name,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
