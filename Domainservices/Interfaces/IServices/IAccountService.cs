using Domain;
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
        public UserIdentity CreateUserIdentityFromModel(dynamic model);
        public User CreateUserFromModel(dynamic model);
    }
}
