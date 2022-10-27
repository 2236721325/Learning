namespace Dto_autemapper_redis.Commoms.GuidGenerator
{
    public interface IGuidGenerator
    {
        /// <summary>
        /// Creates a new <see cref="Guid"/>.
        /// </summary>
        Guid Create();
    }
}
