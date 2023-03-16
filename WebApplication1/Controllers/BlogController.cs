using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Models;
using MongoDB.Driver;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;
        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpPost("AddBlog")]
        public async Task<Blog> AddBlog(Blog newBlog)
        {
            Blog blog = await _blogService.AddBlog(newBlog);
            return blog;
        }

        [HttpGet("GetBlogs")]
        public async Task<List<Blog>> GetBlogs()
        {
           return await _blogService.GetBlogs();
        }

        [HttpGet("GetBlogByAuthor")]
        public async Task<List<Blog>> GetBlogByAuthor(string author)
        {
            return await _blogService.GetBlogByAuthor(author);
        }

        [HttpGet("GetBlogById")]
        public async Task<Blog> GetBlogById(string Id)
        {
            Blog blog= await _blogService.GetBlogById(Id);
            return blog;
        }

        [HttpDelete("DeleteBlog")]
        public  DeleteResult DeleteBlog(string Id)
        {
            return  _blogService.DeleteBlog(Id);
        }

        [HttpPatch("UpdateBlog")]
        public async Task<Blog> UpdateBlog(string Id, Blog newBlog)
        {
            return await _blogService.UpdateBlog(Id, newBlog);
        }
    }
}
