using T4Template.Datas;
using T4Template.Dtos.UserDtos;
using T4Template.IServices;

namespace T4Template.Services
{
    public class UserService : CrudService<User, Guid,
        UserDto, UserUpdateDto, UserCreateDto>,
        IUserService,
        ITransientDependency
    {
        public UserService(MyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<ApiResult> CanInsertAsync(UserCreateDto dto)
        {

        }

        public override async Task<ApiResult> CanUpdateAsync(UserUpdateDto dto)
        {

        }
    }
}