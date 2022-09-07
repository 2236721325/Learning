using AbpDDDLearn.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AbpDDDLearn.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class MyDbContext : AbpDbContext<MyDbContext>
    {
        public DbSet<User> Users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
