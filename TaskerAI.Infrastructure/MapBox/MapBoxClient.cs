namespace TaskerAI.Infrastructure.MapBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Primitives;

    public class MapBoxClient
    {
        private readonly HttpClient httpClient;
        private readonly MapBoxClientSettings configuration;

        public MapBoxClient(HttpClient httpClient, IOptions<MapBoxClientSettings> options)
        {
            this.httpClient = httpClient;
            this.configuration = options.Value;

            this.httpClient.BaseAddress = new Uri(this.configuration.BaseUrl);
        }

        public Task<string> GetStringAsync(string relativeUrl)
        {
            string[] url = relativeUrl.Split("?");

            if (url.Length > 2)
            {
                //TODO handle invalid url format
            }

            string endpoint = url.First();
            string queryString = url.Skip(1).LastOrDefault();

            Dictionary<string, StringValues> query = QueryHelpers.ParseQuery(queryString);
            query.Add("access_token", this.configuration.AccessToken);

            return this.httpClient.GetStringAsync(string.Concat(endpoint, QueryString.Create(query)));
        }
    }
}
