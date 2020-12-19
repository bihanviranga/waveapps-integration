using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace waveapps.Client
{
    public class WaveappsClient
    {
        private readonly GraphQLHttpClient _client;

        public WaveappsClient()
        {
            var token = "XXXXX";
            var options = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("https://gql.waveapps.com/graphql/public")
            };
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _client = new GraphQLHttpClient(options, new NewtonsoftJsonSerializer(), httpClient);
        }

        public async Task<List<CustomerWrapper>> GetAllCustomers()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query getallusers{
                        business(id:""QnVzaW5lc3M6OTY4NTcyZWItM2FhYy00OWU0LTlkY2UtMmE2MDBhNDNmZWRj"") {
                            id
                            customers {
                                edges {
                                    node {
                                        id
                                        name
                                        email
                                    }
                                }
                            }
                        }
                    }"
            };
            var response = await _client.SendQueryAsync<BusinessResponse>(query);
            // raw output
            // Console.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
            return response.Data.business.customers.edges;
        }

        public async Task CreateCustomer(string name, string email)
        {
            var customer = new CustomerInput();
            customer.businessId = "QnVzaW5lc3M6OTY4NTcyZWItM2FhYy00OWU0LTlkY2UtMmE2MDBhNDNmZWRj";
            customer.name = name;
            customer.email = email;

            var query = new GraphQLRequest
            {
                Query = @"
                    mutation ($input: CustomerCreateInput!) {
                         customerCreate(input: $input) {
                            didSucceed
                            inputErrors {
                                code
                                message
                                path
                            }
                            customer {
                                id
                                name
                                firstName
                                lastName
                                email
                                address {
                                    addressLine1
                                    addressLine2
                                    city
                                    province {
                                        code
                                        name
                                    }
                                    country {
                                        code
                                        name
                                    }
                                    postalCode
                                }
                                currency {
                                    code
                                }
                            }
                        }
                    }",
                Variables = new { input = customer }
            };

            try
            {
                var response = await _client.SendMutationAsync<Customer>(query);
                // Console.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (GraphQL.Client.Http.GraphQLHttpRequestException exception)
            {
                Console.WriteLine(exception.StatusCode);
                Console.WriteLine(exception.ResponseHeaders);
                Console.WriteLine(exception.Content);
            }
        }

        public async Task DeleteCustomer(string customerId)
        {
            CustomerDeleteInput cust = new CustomerDeleteInput();
            cust.id = customerId;
            var query = new GraphQLRequest
            {
                Query = @"
                    mutation ($input: CustomerDeleteInput!) {
                        customerDelete(input: $input) {
                            didSucceed
                        }
                    }",
                Variables = new { input = cust }
            };

            try
            {
                var response = await _client.SendMutationAsync<Customer>(query);
                // Console.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (GraphQL.Client.Http.GraphQLHttpRequestException exception)
            {
                Console.WriteLine(exception.Content);
            }
        }
    }
}