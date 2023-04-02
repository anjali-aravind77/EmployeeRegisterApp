using EmployeeRegisterApp.DAL;
using EmployeeRegisterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeRegisterApp.Controllers
{
    public class EmployeeController : Controller
    {
        Employee_DAL employee = new Employee_DAL();

        // GET: Employee
        public ActionResult Index()
        {
            var emp = employee.GetAllEmp();
            return View(emp);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee collection, Departments depts)
        {
            bool isInserted = false;
            //var departents = depts.DeptName.ToList();
            //ViewBag.DeptList = new SelectList(departents, "DeptName");
           
            try
            {
                if(ModelState.IsValid)
                {
                    isInserted = employee.InsertEmployee(collection);
                    if(isInserted)
                    {
                        TempData["message"] = "inserted";
                    }
                    else
                    {
                        TempData["error"] = "invalid entry";
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
