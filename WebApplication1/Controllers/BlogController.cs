using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;
        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }
    }
}
