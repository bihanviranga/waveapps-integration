using System.Collections.Generic;

namespace waveapps.Client
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class UserNode
    {
        public User user { get; set; }
    }

    public class UserNodeWrapper
    {
        public User node { get; set; }
    }

    public class CustomersResponse
    {
        public List<UserNodeWrapper> edges { get; set; }
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

}