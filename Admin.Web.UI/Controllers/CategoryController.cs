using Admin.BLL.Helpers;
using Admin.BLL.Repository;
using Admin.Models.Entities;
using Admin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Web.UI.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        } public ActionResult Add()
        {
            ViewBag.CategoryList = GetCategorySelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            try
            {
                model.TaxRate /= 100;
                if (model.SupCategoryId == 0) model.SupCategoryId = null;
                //yanlış girişlerde yanlış girdiktn snra verileri grei getirir ve kırmızı mesajı verir.
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("CategoryName", "100 karakteri geçemezsiniz");
                    model.SupCategoryId = model.SupCategoryId ?? 0;
                    ViewBag.CategoryList = GetCategorySelectList();
                    return View(model);
                }
                if (model.SupCategoryId>0)
                {
                    model.TaxRate = new CategoryRepo().GetById(model.SupCategoryId).TaxRate;
                }
                new CategoryRepo().Insert(model);
                TempData["Message"] = $"{model.CategoryName} isimli kategori başarıyla eklenmiştir";
                return RedirectToAction("Error","Home");
            }
            catch (DbEntityValidationException ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text=$"Bir hata oluştu{EntityHelpers.ValidationMessage(ex)}",
                    ActionName="Add",
                    ControllerName="Category"
                };
                return RedirectToAction("Error","Home");
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu{ex.Message}",
                    ActionName = "Add",
                    ControllerName = "Category"
                };
                return RedirectToAction("Add");
            }
        }
    }
}