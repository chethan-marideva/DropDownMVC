using DropDownMVC.Models;
using DropDownMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DropDownMVC.Data
{
    public class CustomersRepository
    {

        public IEnumerable<CustomerDisplayViewModel> GetCustomers()
        {


            using (var context = new DataContext())
            {

                List<Customer> customers = new List<Customer>();


                customers = context.Customers.AsNoTracking()
                    .Include(x => x.Country)
                    .Include(x => x.Region)
                    .ToList();

                if (customers != null)
                {

                    List<CustomerDisplayViewModel> cutomersDisplay = new List<CustomerDisplayViewModel>();

                    foreach (var x in customers)
                    {

                        var customerDisplay = new CustomerDisplayViewModel()
                        {

                            CustomerID = x.CustomerID,
                            CustomerName = x.CustomerName,
                            CountryName = x.Country.CountryNameEnglish,
                            RegionName = x.Region.RegionNameEnglish

                        };

                        cutomersDisplay.Add(customerDisplay);
                    }

                    return cutomersDisplay;
                }

                return null;


            }


        }

        public bool SaveCustomer(CustomerEditViewModel model)
        {

            if (model != null)
            {
                using (var context = new DataContext())
                {
                   
                    {
                        var customer = new Customer()
                        {
                            CustomerID = Guid.Parse(model.CustomerID),
                            CustomerName = model.CustomerName,
                            CountryIso3 = model.SelectedCountryIso3,
                            RegionCode = model.SelectedRegionCode
                        };


                        customer.Country = context.Countries.Find(model.SelectedCountryIso3);
                        customer.Region = context.Regions.Find(model.SelectedRegionCode);

                        context.Customers.Add(customer);
                        context.SaveChanges();
                        return true;
                    }

                }

            }

            return false;




            //throw new NotImplementedException();
        }

        public CustomerEditViewModel CreateCustomer()
        {

            var cRepo = new CountriesRepository();
            var rRepo = new RegionsRepository();

            var customer = new CustomerEditViewModel()
            {

                CustomerID = Guid.NewGuid().ToString(),
                Countries = cRepo.GetCountries(),
                Regions = rRepo.GetRegions()

            };

            return customer;



        }
    }
}