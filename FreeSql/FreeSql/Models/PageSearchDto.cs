using FreeSql.Internal.Model;
using Microsoft.AspNetCore.Http.Features;

namespace FreeSqlDemo.Models
{
    public class PageSearchDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? FilterInfos { get; set; }
    }
}
