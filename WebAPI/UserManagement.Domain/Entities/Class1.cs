using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain.Entities
{
    public interface IAggregateRoot
    {

    }
    public record User:IAggregateRoot
    {
        public Guid Id { get; init; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string PwdHash { get; set; }
    }
}