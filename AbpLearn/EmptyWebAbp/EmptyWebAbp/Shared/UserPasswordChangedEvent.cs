namespace EmptyWebAbp.Shared
{
    public class UserPasswordChangedEvent
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public UserPasswordChangedEvent(string oldPassword, string newPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
    }
}
