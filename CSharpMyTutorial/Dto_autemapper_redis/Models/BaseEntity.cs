namespace Dto_autemapper_redis.Models
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; protected set; }
    }
}
