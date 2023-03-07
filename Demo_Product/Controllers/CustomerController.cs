using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
        JobManager jobManager = new JobManager(new EFJobDal());
        public IActionResult Index()
        {
            var values = customerManager.GetCustomersListWithJob();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            
            List<SelectListItem> deger = (from x in jobManager.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.JobID.ToString()

                                          }).ToList();
            ViewBag.d = deger;
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            
                customerManager.TInsert(p);
                return RedirectToAction("Index");

        }
        public IActionResult DeleteCustomer(int id)
        {
            var value = customerManager.TGetById(id);
            customerManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            List<SelectListItem> deger = (from x in jobManager.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.JobID.ToString()

                                          }).ToList();
            ViewBag.d = deger;
            var value = customerManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            customerManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
