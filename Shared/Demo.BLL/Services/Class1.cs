using Demo.BLL.Tools;
using Demo.DAL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services
{
    public interface IBaseService<T>
    {
        Task<ApiResponse> GetPagedListAsync(Expression<Func<T, bool>> predicate = null, int pageIndex = 0,int pageSize = 20);
                   
        Task<ApiResponse> GetSingleAsync(int id);

        Task<ApiResponse> AddAsync(T model);

        Task<ApiResponse> UpdateAsync(T model);

        Task<ApiResponse> DeleteAsync(int id);
    }

    public class UserService
    {

    }
}
