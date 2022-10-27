using FreeSql;
using FreeSql.DataAnnotations;
using System.Security.Principal;

namespace FreesqlTest.Models
{
    public class BaseEntity<T>
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public T Id { get; set; }
    }
    public class Poet:BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Artical { get; set; }
    }
}
