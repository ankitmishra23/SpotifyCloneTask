using SpotifyTask.Models;
//using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.SpotifyDTO
{
    public class UserFollowingDTO
    {
        public string UserName { get; set; }
        public List<Artist> follow { get; set; }
    }
}
