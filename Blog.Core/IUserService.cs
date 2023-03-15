using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
    internal interface IUserService
    {
        List<User> GetAllUsers();
        User GetUser(string id);
        User Register(User user);
        User Update(User user);
        
    }
}
