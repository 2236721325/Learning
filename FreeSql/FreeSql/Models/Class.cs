using FreeSql.DataAnnotations;
using System.Security.Principal;

namespace FreeSqlDemo.Models
{
    public class Blog
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
    }
    public class BlogDto
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
    }
    public class BlogCreateDto
    {
        public string Url { get; set; }
        public int Rating { get; set; }
    }

    public class BlogUpdateDto
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }

    }

}
