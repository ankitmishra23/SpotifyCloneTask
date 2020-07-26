using SpotifyTask.Models;
//using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.SpotifyDTO
{
    public class AlbumSongsDTO
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public List<Song> Songs { get; set; }
    }
}
