using AbpDDDLearn.Domain.Shared;
using Volo.Abp.Modularity;

namespace AbpDDDLearn.Application.Contracts
{
    [DependsOn(
    typeof(AbpDDDLearnDomainSharedModule)

)]
    public class AbpDDDLearnApplicationContractsModule : AbpModule
    {

    }
}