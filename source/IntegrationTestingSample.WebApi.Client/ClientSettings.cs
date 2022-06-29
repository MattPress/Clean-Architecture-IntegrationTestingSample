using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTestingSample.WebApi.Client
{
    public class ClientSettings : IClientSettings
    {
        public string BaseUrl { get; set; }
    }
}
