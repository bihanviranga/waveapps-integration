using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using waveapps.Client;

namespace waveapps.Pages
{
    public class CustomersModel : PageModel
    {

        private readonly WaveappsClient _client;
        public List<Customer> CustomerList;
        public CustomersModel()
        {
            _client = new WaveappsClient();
            CustomerList = new List<Customer>();
        }
        public async Task OnGetAsync()
        {
            var customers = await _client.GetAllCustomers();
            foreach (CustomerWrapper wrapper in customers)
            {
                CustomerList.Add(wrapper.node);
            }
        }

        public async Task<IActionResult> OnPostCreateCustomerAsync([FromForm] string name, [FromForm] string email)
        {
            await _client.CreateCustomer(name, email);
            return RedirectToPage("./Customers");
        }

        public async Task<IActionResult> OnPostDeleteCustomerAsync([FromForm] string customerId)
        {
            await _client.DeleteCustomer(customerId);
            return RedirectToPage("./Customers");
        }
    }
}