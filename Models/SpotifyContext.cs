using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.Models
{
    public class SpotifyContext:DbContext
    {
        public SpotifyContext(DbContextOptions<SpotifyContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }

        public DbSet<Playlist> Playlists { get; set; }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }
        public DbSet<AlbumSong> AlbumSong { get; set; }
        public DbSet<Follow> ArtistFollow { get; set; }
        public DbSet<PlaylistSong> PlaylistSong { get; set; }
    }
}
