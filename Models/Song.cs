//using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.Models
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        public string SongName { get; set; }

        public string Genre { get; set; }
    }
}
