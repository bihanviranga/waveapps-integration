/****** SAMPLE OUTPUT *****
{
  "Data": {
    "business": {
      "id": "QnVzaW5lc3M6OTY4NTcyZWItM2FhYy00OWU0LTlkY2UtMmE2MDBhNDNmZWRj",
      "customers": {
        "edges": [
          {
            "node": {
              "id": "QnVzaW5lc3M6OTY4NTcyZWItM2FhYy00OWU0LTlkY2UtMmE2MDBhNDNmZWRjO0N1c3RvbWVyOjQ4MDA2ODgw",
              "name": "Testing Customer 2",
              "email": "testing2@email.com"
            }
          },
          {
            "node": {
              "id": "QnVzaW5lc3M6OTY4NTcyZWItM2FhYy00OWU0LTlkY2UtMmE2MDBhNDNmZWRjO0N1c3RvbWVyOjQ4MDAxNDQx",
              "name": "Testing Customer One",
              "email": "testing1@email.com"
            }
          }
        ]
      }
    }
  },
  "Errors": null,
  "Extensions": null
}
******/

using System.Collections.Generic;

namespace waveapps.Client
{
    public class Customer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class CustomerWrapper
    {
        public Customer node { get; set; }
    }

    public class CustomersResponse
    {
        public List<CustomerWrapper> edges { get; set; }
    }

    public class Business
    {
        public string id { get; set; }
        public CustomersResponse customers { get; set; }
    }

    public class BusinessResponse
    {
        public Business business { get; set; }
    }

    public class CustomerInput
    {
        public string businessId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class CustomerDeleteInput
    {
        public string id { get; set; }
    }

}