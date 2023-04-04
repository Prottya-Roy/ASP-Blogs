using Microsoft.AspNetCore.Mvc;
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

        public async Task<Blog> AddBlog(Blog blog)
        {
            await _blogs.InsertOneAsync(blog);
            return blog;
        }

        public DeleteResult DeleteBlog(string Id)
        {
            var response = _blogs.DeleteOne(blog => blog._id == Id);
            return response;
        }

        public async Task<List<Blog>> GetBlogByAuthor(string author)
        {
            return await _blogs.Find(blog => (blog.author == author)).ToListAsync();
        }

        public async Task<List<Blog>> GetBlogs()
        {
            return await _blogs.Find(_ => true).ToListAsync();
        }

        public async Task<Blog> UpdateBlog(Blog newBlog)
        {
            await _blogs.FindOneAndReplaceAsync(blog => blog._id == newBlog._id, newBlog);
            return newBlog;
        }
        public async Task<Blog> GetBlogById(string Id)
        {
            Blog blog = await _blogs.Find(blog => blog._id == Id).FirstAsync();
            return blog;
        }
    }
}
