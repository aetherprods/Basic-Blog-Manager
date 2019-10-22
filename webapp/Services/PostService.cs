using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using shared_classes.Models;
using webapp.Services;

namespace webapp.Services
{
    public class PostService : IPostService<IBlogService>
    {
        private readonly HttpClient _client;
        public PostService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("webapi");
        }
        public async Task<IEnumerable<PostModel>> GetAll(int blogId)
        {
            var result = new List<PostModel>();
            var response = await _client.GetAsync($"/v1/post");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<List<PostModel>>();
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }
        public async Task<PostModel> GetById(int id)
        {
            var result = new PostModel();
            var response = await _client.GetAsync($"/v1/post/{id}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<PostModel>();
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }
        public async Task Add(PostModel blog)
        {
            await _client.PostAsJsonAsync("/v1/post", blog);
        }

        public Task Update(PostModel post)
        {
            throw new NotImplementedException();
        }
        public Task Delete(PostModel post)
        {
            throw new NotImplementedException();
        }
    }

}