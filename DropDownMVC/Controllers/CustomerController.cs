using DropDownMVC.Data;
using DropDownMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownMVC.Controllers
{
    public class CustomerController : Controller
    {

        private ICustomerRepository CustomerRepo;

        public CustomerController(ICustomerRepository CustomerRepo)
        {
            this.CustomerRepo = CustomerRepo;
        }

        //[OutputCache(Duration =3600)]
        // GET: Customer
        [CustomFilters]
        public ActionResult Index()
        {
            var customersList = CustomerRepo.GetCustomers();
            return View(customersList);
        }


        public ActionResult Create()
        {

            var customer = CustomerRepo.CreateCustomer();
            return View(customer);

        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "CustomerID, CustomerName, SelectedCountryIso3, SelectedRegionCode")] CustomerEditViewModel model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    bool saved = CustomerRepo.SaveCustomer(model);

                    if (saved) { return RedirectToAction("Index"); }


                }


                throw new ApplicationException("Invalid Model");
                // return View("Index");

            }
            catch (ApplicationException ex) { throw ex; }



        }

        [HttpGet]
        public ActionResult GetRegions(string iso3)
        {
            if (!string.IsNullOrWhiteSpace(iso3) && iso3.Length == 3)
            {
                var repo = new RegionsRepository();

                IEnumerable<SelectListItem> regions = repo.GetRegions(iso3);
                return Json(regions, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

    }
}