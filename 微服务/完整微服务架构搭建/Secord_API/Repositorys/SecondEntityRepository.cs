using API_Shared.BaseRepositorys;
using Microsoft.EntityFrameworkCore;
using Secord_API.DbContexts;
using Secord_API.IRepositorys;
using Secord_API.Models;

namespace Secord_API.Repositorys
{
    public class SecondEntityRepository : Repository<SecondEntity>, ISecondEntityRepository
    {
        public SecondEntityRepository(SecondDbContext dbContext) : base(dbContext)
        {
        }
    }
}
