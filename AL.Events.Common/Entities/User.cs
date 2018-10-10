namespace AL.Events.Common.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
