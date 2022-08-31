using AbpLearn.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpLearn
{
    public class TodoAppService : ApplicationService, ITodoService
    {
        private readonly IRepository<TodoItem, int> _Repository;
        

        public async Task AddAsync(string name)
        {
            await _Repository.InsertAsync(new TodoItem()
            {
                Name = name
            },true);
        }

        public async Task FindAsync(int id)
        {
            await _Repository.FindAsync(id);
        }

        public async Task<List<TodoItemDto>> GetListAsync()
        {
            var items = await _Repository.GetListAsync();
            return items
                .Select(item => new TodoItemDto
                {
                    Id = item.Id,
                    Name = item.Name
                }).ToList();
        }

        public async Task RemoveAsync(int id)
        {
            await _Repository.DeleteAsync(id);
        }

      



        // TODO: Implement the methods here...
    }
}
