using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IBlogService
    {
        List<Blog> GetBlogs();
        Blog GetBlog(string Id);
        Blog GetBlogByAuthor(string author);
        void AddBlog(Blog blog);
        Blog UpdateBlog(Blog blog);
        void DeleteBlog(string Id);

    }
}
