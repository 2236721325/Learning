using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace AbpLearn
{
    public  class TodoItem:BasicAggregateRoot<int>
    {
        public string Name { get; set; }
    }
}
