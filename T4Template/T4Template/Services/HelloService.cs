using T4Template.Datas;
using T4Template.Dtos.HelloDtos;
using T4Template.IServices;

namespace T4Template.Services
{
    public class HelloService : CrudService<Hello, Guid,
        HelloDto, HelloUpdateDto, HelloCreateDto>,
        IHelloService,
        ITransientDependency
    {
        public HelloService(MyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<ApiResult> CanInsertAsync(HelloCreateDto dto)
        {

        }

        public override async Task<ApiResult> CanUpdateAsync(HelloUpdateDto dto)
        {

        }
    }
}