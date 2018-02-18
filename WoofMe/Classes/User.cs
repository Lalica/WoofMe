
namespace WoofMe.Classes
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        //public string ProfilePictureUrl { get; set; }
        public string EMail { get; set; }

        public User(string id, string name, string email)
        {
            Id = id;
            Name = name;
            EMail = email;
        }
    }
}
