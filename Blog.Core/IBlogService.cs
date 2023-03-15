using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        Blog GetById(string id);
        Blog AddBlog(Blog blog);
        Blog UpdateBlog(Blog blog);
        void DeleteBlog(string id);
    }
}
