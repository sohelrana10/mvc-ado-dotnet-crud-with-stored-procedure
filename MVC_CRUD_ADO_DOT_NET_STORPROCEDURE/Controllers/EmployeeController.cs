using MVC_CRUD_ADO_DOT_NET_STORPROCEDURE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD_ADO_DOT_NET_STORPROCEDURE.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeServices employeeServices = new EmployeeServices();

        public ActionResult List()
        {
            return View(employeeServices.Employees.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeServices.SaveEmployee(employee);
                return RedirectToAction("List");
            }
            return View();
          
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee = employeeServices.Employees.Single(e => e.Id == id);
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            Employee employee = employeeServices.Employees.Single(e => e.Id == id);
            UpdateModel(employee);
            if (ModelState.IsValid)
            {
                employeeServices.UpdateEmployee(employee);
                return RedirectToAction("List");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee employee = employeeServices.Employees.Single(e => e.Id == id);
            return View(employee);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee employee = employeeServices.Employees.Single(e => e.Id == id);
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete_Confirm(int id)
        {
            if (ModelState.IsValid)
            {
                employeeServices.DeleteEmployee(id);
                return RedirectToAction("List");
            }
            return View();
        }
    }
}