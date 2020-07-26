using SpotifyTask.Models;
//using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.SpotifyDTO
{
    public class PlaylistSongsDTO
    {
        public string UserName { get; set; }
        public string PlaylistName { get; set; }
        public List<Song> song { get; set; }
    }
}
