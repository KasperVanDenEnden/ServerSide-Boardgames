using Domain;
using Domainservices.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetUserAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
