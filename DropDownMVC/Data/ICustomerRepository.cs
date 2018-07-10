using DropDownMVC.ViewModel;
using System.Collections.Generic;

namespace DropDownMVC.Data
{
    public interface ICustomerRepository
    {

        IEnumerable<CustomerDisplayViewModel> GetCustomers();
        bool SaveCustomer(CustomerEditViewModel model);
        CustomerEditViewModel CreateCustomer();

    }
}