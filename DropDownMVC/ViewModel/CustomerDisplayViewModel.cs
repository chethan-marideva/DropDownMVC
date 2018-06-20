using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DropDownMVC.ViewModel
{
    public class CustomerDisplayViewModel
    {
        [Display(Name ="Customer ID")]
        public Guid CustomerID { get; set; }

        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name ="Country")]
        public string CountryName { get; set; }

        [Display(Name ="Region")]
        public string RegionName { get; set; }


    }
}