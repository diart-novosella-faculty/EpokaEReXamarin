using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App3
{
    public class ApiCall
    {
        public static async Task<List<Kryesore>> getHome()
        {
            string apiurl = "https://www.epokaere.com/wp-json/app/v1/home";
            

            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(apiurl);
                var rootResult = JsonConvert.DeserializeObject<List<Kryesore>>(content);

                return rootResult;
            }
        }
        public static async Task<List<Kryesore>> getByCategorie(string cat)
        {
            string apiurl = "https://www.epokaere.com/wp-json/app/v1/" + cat;

            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(apiurl);
                var rootResult = JsonConvert.DeserializeObject<List<Kryesore>>(content);

                return rootResult;
            }
        }
        public static async Task<Post> getPost(int id)
        {
            string apiurl = "https://www.epokaere.com/wp-json/app/v1/single_post/" + id.ToString();

            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(apiurl);
                var rootResult = JsonConvert.DeserializeObject<RootObject>(content);

                return rootResult.Post;
            }
        }
        public static async Task<List<string>> getAds()
        {
            string apiurl = "https://www.epokaere.com/wp-json/app/v1/imagesAds";


            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(apiurl);
                var rootResult = JsonConvert.DeserializeObject<List<String>>(content);

                return rootResult;
            }
        }
    }
}
