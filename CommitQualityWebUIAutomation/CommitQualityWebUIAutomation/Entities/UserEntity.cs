namespace CommitQualityWebUIAutomation.Entities
{
    public class UserEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserEntity(string  username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
