using Demo.DAL.Contexts;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositorys.EntityRepositorys
{
    public class UserRepository:Repository<User>,IRepository<User>
    {
        public UserRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
    }
}
