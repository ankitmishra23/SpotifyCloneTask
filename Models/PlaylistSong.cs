//using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.Models
{
    public class PlaylistSong
    {
        [Key]
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
    }
}
