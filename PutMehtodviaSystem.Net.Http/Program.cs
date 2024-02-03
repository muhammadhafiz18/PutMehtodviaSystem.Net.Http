using System;
using System.Net.Http;
using System.Text.Json;


public class PutMethod
{
    static async Task Main(string[] args)
    {
        using (var client = new HttpClient()) 
        {
            var post = new { id = 1, title = "foo", body = "faa", userId = 1 };
            string json = JsonSerializer.Serialize(post);

            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://jsonplaceholder.typicode.com/posts/1", content);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }

            else
            {
                Console.WriteLine($"Error has occured: {response.StatusCode}");
            }
        }
    }
}
