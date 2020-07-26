//using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.Models
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public int UserId { get; set; }
    }
}
