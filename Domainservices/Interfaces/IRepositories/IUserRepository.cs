using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public Task<bool> AddUserAsync(User newUser);
        public Task<User> GetUserAsync(string username);
    }
}
