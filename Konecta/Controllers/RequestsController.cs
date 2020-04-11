using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Konecta.Controllers.ViewModels;
using Konecta.Models.Context;
using Konecta.Models.Entities;

namespace Konecta.Controllers
{
    public class RequestsController : Controller
    {
        private KonectaContext db = new KonectaContext();

        // GET: Requests
        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.Employee);
            return View(requests.ToList());
        }

        // GET: Requests/Requests_Read grid telerik
        public ActionResult Requests_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetRequests().ToDataSourceResult(request));
        }

        private IEnumerable<RequestViewModel> GetRequests()
        {
            var requests = db.Requests.Select(request => new RequestViewModel
            {
                RequestId = request.RequestId,
                Code = request.Code,
                Description = request.Description,
                Summary = request.Summary,
                EmployeeName = request.Employee.Name
            });
            return requests;
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name");
            return View();
        }

        // POST: Requests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,Code,Description,Summary,EmployeeId")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", request.EmployeeId);
            return View(request);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", request.EmployeeId);
            return View(request);
        }

        // POST: Requests/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,Code,Description,Summary,EmployeeId")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", request.EmployeeId);
            return View(request);
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
