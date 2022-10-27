using System;

namespace T4Template.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        public string Account { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}