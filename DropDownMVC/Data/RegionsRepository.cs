using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownMVC.Data
{
    public class RegionsRepository
    {
        public IEnumerable<SelectListItem> GetRegions()
        {
            List<SelectListItem> regions = new List<SelectListItem>() {


                new SelectListItem(){


                    Value=null,
                    Text=" "
                }

            };

            return regions;
        }



        public IEnumerable<SelectListItem> GetRegions(string iso3)
        {
            if (!string.IsNullOrWhiteSpace(iso3))
            {

                using (var context = new DataContext())
                {


                    IEnumerable<SelectListItem> regions = context.Regions.AsNoTracking()
                         .OrderBy(n => n.RegionNameEnglish)
                         .Where(w => w.Iso3 == iso3)
                         .Select(l => new SelectListItem
                         {
                             Value = l.RegionCode,
                             Text = l.RegionNameEnglish

                         }).ToList();

                    return new SelectList(regions, "Value", "Text");
                }


            }

            return null;


        }
    }
}