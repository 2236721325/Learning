using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;


namespace HelloAbp.Models
{
    public class ToDoItem:BasicAggregateRoot<int>
    {
        public string Text { get; set; }
    }
}
