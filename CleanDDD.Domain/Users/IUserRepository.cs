using CleanDDD.Domain.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDDD.Domain.Users
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
    }
}
