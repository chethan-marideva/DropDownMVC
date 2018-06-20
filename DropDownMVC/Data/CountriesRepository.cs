using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownMVC.Data
{
    public class CountriesRepository
    {
        public IEnumerable<SelectListItem> GetCountries()
        {
            using (var context = new DataContext())
            {

                List<SelectListItem> countries = context.Countries.AsNoTracking()
                   .OrderBy(n => n.CountryNameEnglish)
                   .Select(l => new SelectListItem()
                   {

                       Value = l.Iso3.ToString(),
                       Text = l.CountryNameEnglish.ToString()
                   }).ToList();


                var countryTip = new SelectListItem
                {


                    Value = null,
                    Text = "------Select County-----"

                };

                countries.Insert(0, countryTip);

                return countries;
            }
        }
    }
}