using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IBlogService
    {
        Task<List<Blog>> GetBlogs();
        Task GetBlog(string Id);
        Task GetBlogByAuthor(string author);
        Task<Blog> AddBlog(Blog blog);
        Task UpdateBlog(Blog blog);
        void DeleteBlog(string Id);

    }
}
