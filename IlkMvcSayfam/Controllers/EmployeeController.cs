using IlkMvcSayfam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlkMvcSayfam.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            var data = new NorthwindSabahEntities()
                .Employees
                .OrderBy(x => x.EmployeeID)
                .ToList();
            return View(data);
        }
        public ActionResult Sil(int? id)
        {
            var db = new NorthwindSabahEntities();
            try
            {
                var employee = db
                    .Employees
                    .Find(id.GetValueOrDefault());
                if (employee == null)
                    return RedirectToAction("Index");
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction($"Index{ex.Message}");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Detay(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var data = new NorthwindSabahEntities().Employees.Find(id.Value);

            if (id == null)
                return RedirectToAction("Index");
            return View(data);

        }
        public ActionResult Ekle(Employee employee)
        {
            try
            {
                var db = new NorthwindSabahEntities();
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Employee");
            try
            {
                var data = new NorthwindSabahEntities().Employees.Find(id.Value);
                if(data==null)
                    return RedirectToAction("Index", "Employee");
                return View(data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Employee", $"{ex.Message}");
            }         
        }
        [HttpPost]
        public ActionResult Guncelle(Employee employee)
        {
            try
            {
                var db = new NorthwindSabahEntities();
                var data = db.Employees.Find(employee.EmployeeID);
                if (data == null)
                    return RedirectToAction("Index", "Employee");
                data.FirstName = employee.FirstName;
                data.LastName = employee.LastName;
                data.LastName = employee.HomePhone;
                data.Address = employee.Address;
                db.SaveChanges();
                ViewBag.Message = "<span class='text text-success'>Update Successfully</span>";
                return View(data);

            }
            catch (Exception ex)
            {
                ViewBag.Message = $"<span class='text text-danger'>Update Error{ex.Message}</span> ";
                return View(employee);
            }

        }


    }
}