using AL.Events.Common.Entities;
using System.Collections.Generic;

namespace AL.Events.WEB.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<Role> RoleList { get; set; }

        public Role Role { get; set; }
    }
}