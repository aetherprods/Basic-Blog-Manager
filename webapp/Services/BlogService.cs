using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using shared_classes.Models;
using webapp.Services;

namespace webapp.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _client;
        public BlogService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("webapi");
        }
        public async Task<IEnumerable<BlogModel>> GetAll()
        {
            var result = new List<BlogModel>();
            var response = await _client.GetAsync($"/v1/blog");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<List<BlogModel>>();
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }
        public async Task<BlogModel> GetById(int id)
        {
            var result = new BlogModel();
            var response = await _client.GetAsync($"/v1/blog/{id}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<BlogModel>();
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }
        public async Task Add(BlogModel blog)
        {
            await _client.PostAsJsonAsync("/v1/blog", blog);
        }
    }

}