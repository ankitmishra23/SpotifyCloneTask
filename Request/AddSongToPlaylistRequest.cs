//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.Request
{
    public class AddSongToPlaylistRequest
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
    }
}
