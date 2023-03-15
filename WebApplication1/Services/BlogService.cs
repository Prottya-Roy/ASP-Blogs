using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BlogService : IBlogService
    {

        private readonly IMongoCollection<Blog> _blogs;
        public BlogService(IOptions<BlogDatabaseSettings> blogDatabaseSettings)
        {
            var mongoClient = new MongoClient(blogDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(blogDatabaseSettings.Value.DatabaseName);
            _blogs = mongoDatabase.GetCollection<Blog>(blogDatabaseSettings.Value.BlogsCollectionName);
        }
        public void AddBlog(Blog blog)
        {
             _blogs.InsertOne(blog);
        }

        public void DeleteBlog(string Id)
        {
            _blogs.DeleteOne(blog=>blog.Id == Id);
        }

        public Blog GetBlog(string Id)
        {
             Blog blog = _blogs.Find(blog=>blog.Id==Id).First();
            return blog;
        }

        public Blog GetBlogByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogs()
        {
            throw new NotImplementedException();
        }

        public Blog UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
