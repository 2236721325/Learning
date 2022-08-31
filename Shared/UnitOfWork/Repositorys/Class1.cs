using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Contexts;
using UnitOfWork.Models;
using UnitOfWork.UnitOfWork;

namespace UnitOfWork.Repositorys
{
    public class MemoRepository : Repository<User>, IRepository<User>
    {
        public MemoRepository(MyDbContext dbContext) : base(dbContext)
        {

        }
    }
}
