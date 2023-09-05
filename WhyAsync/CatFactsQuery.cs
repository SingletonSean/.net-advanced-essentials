using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WhyAsync
{
    public class CatFactsQuery
    {
        public async Task<IEnumerable<CatFact>> Execute(int delay = 0)
        {
            await Task.Delay(delay);
            
            using (HttpClient client = new HttpClient())
            {
                CatFactListingResponse? response = await client.GetFromJsonAsync<CatFactListingResponse>("https://catfact.ninja/facts?limit=10");

                if (response == null || response.Data == null)
                {
                    throw new Exception();
                }

                return response.Data
                    .Select(c => new CatFact()
                    {
                        Content = c.Fact
                    });
            }
        }

        private class CatFactListingResponse
        {
            public IEnumerable<CatFactResponse> Data { get; set; }
        }

        private class CatFactResponse
        {
            public string Fact { get; set; }
        }
    }
}
