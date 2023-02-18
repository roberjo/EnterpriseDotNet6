using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseDotNet6.Contracts;
using EnterpriseDotNet6.Entities;
using EnterpriseDotNet6.Entities.Models;

namespace EnterpriseDotNet6.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Account> AccountsByOwner(Guid ownerId) =>
           FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
    }
}
