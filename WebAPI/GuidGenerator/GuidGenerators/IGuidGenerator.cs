namespace GuidGenerator.GuidGenerators
{
    public interface IGuidGenerator
    {
        /// <summary>
        /// Creates a new <see cref="Guid"/>.
        /// </summary>
        Guid Create();
    }
}
