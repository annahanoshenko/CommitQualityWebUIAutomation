
namespace CommitQualityWebUIAutomation.Entities
{
    public class ContactUsFormUserEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
       public string QueryType { get; set; }
        public string DateOfBirth { get; set; }

        public ContactUsFormUserEntity(string name, string email, string queryType, string dateOfBirth)
        {
            Name = name;
            Email = email;
            QueryType = queryType;
            DateOfBirth = dateOfBirth;
        }
    }
}
