using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Interfaces.IServices
{
    public interface IAccountService
    {
        public Task<bool> RegisterAsync(string username,string email, string password);
        public Task<bool> LoginAsync(string usernameOrEmail, string password);
    }
}
