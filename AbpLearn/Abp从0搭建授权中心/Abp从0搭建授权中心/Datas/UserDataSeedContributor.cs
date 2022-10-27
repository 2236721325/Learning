using Abp从0搭建授权中心.Models;
using Abp从0搭建授权中心.Shared;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Abp从0搭建授权中心.Datas
{
    public class UserDataSeedContributor
         : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<User, Guid> _userRepository;
        private readonly IRepository<Role, Guid> _Rolerepository;
        private readonly IRepository<UserRole> _UserRoleRepository;
        private readonly IGuidGenerator _guidGenerator;

        public UserDataSeedContributor(
            IRepository<User, Guid> userRepository,
            IRepository<Role, Guid> roleRepository,
            IGuidGenerator guidGenerator
,
            IRepository<UserRole> userRoleRepository)
        {
            _userRepository = userRepository;
            _Rolerepository = roleRepository;
            _guidGenerator = guidGenerator;
            _UserRoleRepository = userRoleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _userRepository.GetCountAsync() > 0)
            {
                return;
            }
            var userId = _guidGenerator.Create();
            await  _userRepository.InsertAsync(new User(
                userId,
                "wangyaohua",
                "wangyaohua",
                MD5Helper.MD5Encrypt32("wangyaohua")
            ), true);
            var roleId = _guidGenerator.Create();
            await _Rolerepository.InsertAsync(new Role(roleId, "超级管理员"),true);
            await _UserRoleRepository.InsertAsync(new UserRole(userId, roleId),true);
        }
    }
}
