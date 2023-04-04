using WebApplication1.Models;
using MongoDB.Driver;


namespace WebApplication1.Services
{
    public interface IBlogService
    {
         Task<List<Blog>> GetBlogs();
         Task<Blog> GetBlogById(string Id);
         Task<List<Blog>> GetBlogByAuthor(string author);
         Task<Blog> AddBlog(Blog blog);
         Task<Blog> UpdateBlog(Blog newBlog);
         DeleteResult DeleteBlog(string Id);

    }
}
