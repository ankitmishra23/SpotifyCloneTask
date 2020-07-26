using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.Request
{
    public class UpdateUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
