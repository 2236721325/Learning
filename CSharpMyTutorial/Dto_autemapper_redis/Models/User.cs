namespace Dto_autemapper_redis.Models
{

    public class User : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string PasswordHash { get; set; }


        public User(Guid id, string name, string account, string passwordHash)
        {
            Id = id;
            Name = name;
            Account = account;
            PasswordHash = passwordHash;
        }
    }
}
