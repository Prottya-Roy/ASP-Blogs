namespace WebApplication1.Models
{
    public class BlogDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string BlogsCollectionName { get; set; } = null!;
        public string UserCollectionName { get; set; } = null!;
    }
}
