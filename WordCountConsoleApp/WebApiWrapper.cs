using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WordCountConsoleApp
{
    public class WebApiWrapper
    {
        public async Task<string> CallApi(int pageNumber)
        {
            using (HttpClient client = new HttpClient())
            {
                // http://localhost:52779/api/LoyalBooksdata/4/bookName
                return await client.GetStringAsync($"http://localhost:52779/api/LoyalBooksdata/{pageNumber}/Railway-Children-by-E-Nesbit.txt");
            }
        }

        public IEnumerable<WordOccurance> ConvertIntoModelObject(string jsonString)
        {
            IEnumerable<WordOccurance> data = JsonConvert.DeserializeObject<IEnumerable<WordOccurance>>(jsonString);
            return data;
        }
    }
}