//using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.Models
{
    public class AlbumSong
    {
        [Key]
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int SongId { get; set; }
    }
}

