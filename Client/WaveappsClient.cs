using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace waveapps.Client
{
    public class WaveappsClient
    {
        private readonly GraphQLHttpClient _client;

        public WaveappsClient()
        {
            var token = "fhSBKWgy22k8TiAMhG4iKxzP4zpHid";
            var options = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("https://gql.waveapps.com/graphql/public")
            };
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _client = new GraphQLHttpClient(options, new NewtonsoftJsonSerializer(), httpClient);
        }

        public async Task GetAllUsers()
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
            Console.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}