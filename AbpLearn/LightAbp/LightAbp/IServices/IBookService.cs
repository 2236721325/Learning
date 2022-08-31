using LightAbp.Maps.Dtos;
using LightAbp.Models;
using LightAbp.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LightAbp.IServices
{
    public interface IBookAppService :
         ICrudAppService< //Defines CRUD methods
             BookDto, //Used to show books
             Guid, //Primary key of the book entity
             PagedAndSortedResultRequestDto, //Used for paging/sorting
             CreateUpdateBookDto> //Used to create/update a book
    {

    }
}
