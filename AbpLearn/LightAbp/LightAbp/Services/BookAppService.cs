using LightAbp.IServices;
using LightAbp.Maps.Dtos;
using LightAbp.Models;
using Microsoft.Extensions.Options;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace LightAbp.Services
{
    public class MyService 
    {
        private readonly MyOptions _options;

        public MyService(IOptions<MyOptions> options)
        {
            _options = options.Value; //Notice the options.Value usage!
        }

        public void DoIt()
        {
            var v1 = _options.Value1;
            var v2 = _options.Value2;
        }
    }
    public class BookAppService :
         CrudAppService<
             Book, //The Book entity
             BookDto, //Used to show books
             Guid, //Primary key of the book entity
             PagedAndSortedResultRequestDto, //Used for paging/sorting
             CreateUpdateBookDto>, //Used to create/update a book
         IBookAppService //implement the IBookAppService
    {
        public BookAppService(IRepository<Book, Guid> repository)
            : base(repository)
        {

        }
    }
}
