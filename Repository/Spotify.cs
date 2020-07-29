//using Microsoft.EntityFrameworkCore;
using SpotifyTask.Models;
using SpotifyTask.Request;
using SpotifyTask.SpotifyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.Repository
{
    public class Spotify : ISpotify
    {
        private readonly SpotifyContext db;
        public Spotify(SpotifyContext db)
        {
            this.db = db;
        }

        public bool AddPlaylist(AddPlaylistRequest playlist)
        {
            Playlist newPlaylist = new Playlist();
            newPlaylist.PlaylistName = playlist.PlaylistName;
            newPlaylist.UserId = playlist.UserId;
            db.Playlists.Add(newPlaylist);
            db.SaveChanges();
            return true;
        }

        public bool AddSongToPlaylist(AddSongToPlaylistRequest playlist)
        {
            PlaylistSong play = new PlaylistSong();
            play.PlaylistId = playlist.PlaylistId;
            play.SongId = playlist.SongId;
            db.PlaylistSong.Add(play);
            db.SaveChanges();
            return true;
        }

        public bool AddUser(AddUserRequest user)
        {
            User newUser = new User();
            newUser.UserName = user.UserName;
            newUser.Email = user.Email;
            newUser.Password = user.Password;
            newUser.Gender = user.Gender;
            newUser.Location = user.Location;
            newUser.Phone = user.Phone;
            newUser.CreatedOn = DateTime.Now;
            db.Users.Add(newUser);
            db.SaveChanges();
            return true;
        }

        public List<Album> GetAlbums()
        {
            return (db.Albums.ToList());
        }

        public AlbumSongsDTO GetAlbumSongsByAlbumId(int id)
        {
            var albumResult = db.Albums.Where(a => a.AlbumId == id).FirstOrDefault();
            var result = db.AlbumSong.Where(a => a.AlbumId == id).ToList();
            if (result != null)
            {
                
                AlbumSongsDTO albumSongs = new AlbumSongsDTO();
                albumSongs.AlbumId = albumResult.AlbumId;
                albumSongs.AlbumName = albumResult.AlbumName;
                List<Song> albumsong = new List<Song>();
                foreach (AlbumSong item in result)
                {                    
                    foreach (Song song in db.Songs)
                    {
                        if (item.SongId == song.SongId)
                        {
                            albumsong.Add(song);
                        }
                    }
                }
                albumSongs.Songs = albumsong;
                return albumSongs;
            }
            return null;
        }

        public List<Song> GetAllSongs()
        {
            return (db.Songs.ToList());
        }

        public List<Artist> GetArtists()
        {
            return (db.Artists.ToList());
        }

        public List<Playlist> GetPlaylistsById(int id)
        {
            return (db.Playlists.Where(a => a.UserId == id).ToList());
        }

        public List<User> GetUserDetailsById(int id)
        {
            return (db.Users.Where(a => a.UserId == id).ToList());
        }

        public bool RemoveSongfromPlaylist(int songId, int playlistId)
        {
            var result = db.PlaylistSong.Where(a => a.PlaylistId == playlistId && a.SongId == songId).FirstOrDefault();
            if (result != null)
            {
                db.Remove(result);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateUser(UpdateUserRequest user, int id)
        {
            var result = db.Users.Where(a => a.UserId == id).FirstOrDefault();
            if (result != null)
            {
                result.UserName = user.UserName;
                result.Email = user.Email;
                result.Password = user.Password;
                result.Gender = user.Gender;
                result.Location = user.Location;
                result.Phone = user.Phone;
                result.CreatedOn = DateTime.Now;

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public PlaylistSongsDTO GetPlaylistSongsById(int userId, int playlistId)
        {
            PlaylistSongsDTO play = new PlaylistSongsDTO();
            var playResult = db.Playlists.Where(a => a.UserId == userId && a.PlaylistId == playlistId).FirstOrDefault();
            if (playResult != null)
            {
                var userResult = db.Users.FirstOrDefault(a => a.UserId == userId);
                play.PlaylistName = playResult.PlaylistName;
                play.UserName = userResult.UserName;
                var playSong = db.PlaylistSong.Where(a => a.PlaylistId == playlistId).ToList();
                List<Song> aboutSong = new List<Song>();
                foreach (PlaylistSong item in playSong)
                {
                    foreach (Song song in db.Songs)
                    {
                        if (item.SongId == song.SongId)
                        {
                            aboutSong.Add(song);
                        }
                    }
                }
                play.song = aboutSong;
                return play;
            }
            return null;
        }

        public bool FollowArtist(AddFollowArtistRequest follow)
        {
            Follow followArtist = new Follow();
            followArtist.ArtistId = follow.ArtistId;
            followArtist.UserId = follow.UserId;
            db.ArtistFollow.Add(followArtist);
            db.SaveChanges();
            return true;
        }

        public bool UnfollowArtist(int userId, int artistId)
        {
            var unfollow = db.ArtistFollow.FirstOrDefault(a => a.ArtistId == artistId && a.UserId == userId);
            if (unfollow != null)
            {
                db.ArtistFollow.Remove(unfollow);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        

        public UserFollowingDTO GetUserFollowings(int userId)
        {
            UserFollowingDTO user = new UserFollowingDTO();
            var userResult = db.Users.FirstOrDefault(a => a.UserId == userId);
            user.UserName = userResult.UserName;
            var follow = db.ArtistFollow.Where(a => a.UserId == userId).ToList();
            List<Artist> artistFollow = new List<Artist>();
            if (follow != null)
            {
                foreach (Follow item in follow)
                {
                    foreach (Artist art in db.Artists)
                    {
                        if (item.ArtistId == art.ArtistId)
                        {
                            artistFollow.Add(art);
                        }
                    }
                }
                user.follow = artistFollow;
                return user;
            }
            return null;
        }

        public Artist GetArtistByName(string str)
        {
            var result = db.Artists.FirstOrDefault(a => a.ArtistName == str);
            return result;
        }

        public List<ArtistDTO> GetFollowedArtist()
        {
            var result = (from f in db.ArtistFollow join a in db.Artists on f.ArtistId equals a.ArtistId select new { 
                artistId=a.ArtistId,
                artistName=a.ArtistName
            }).ToList();
            List<ArtistDTO> resultArtist = new List<ArtistDTO>();
            foreach (var item in result)
            {
                
                        ArtistDTO art = new ArtistDTO();
                        art.artistId = item.artistId;
                        art.artistName = item.artistName;
                        resultArtist.Add(art);
                    
                
            }
                return resultArtist;
        }

        public bool CheckUserAuth(string name, string pass)
        {
            var result = db.Users.FirstOrDefault(a => a.UserName == name && a.Password == pass);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public User GetUserDetailsByName(string name)
        {
            var result = db.Users.FirstOrDefault(a => a.UserName == name);
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public int GetPlaylistIdByName(string name)
        {
            var result = db.Playlists.FirstOrDefault(a => a.PlaylistName == name);
            if (result != null)
            {
                return result.PlaylistId;
            }
            return -1;
        }

        public int GetSongIdByName(string name)
        {
            var result = db.Songs.FirstOrDefault(a => a.SongName == name);
            if (result != null)
            {
                return result.SongId;
            }
            return -1;
        }

        public Song GetSongByName(string name)
        {
            var result = db.Songs.FirstOrDefault(a => a.SongName == name);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public List<Artist> GetUnfollowedArtists(int id)
        {
            var result = db.ArtistFollow.Where(a=>a.UserId==id).ToList();
            List<Artist> resultList = new List<Artist>();
            if (result != null)
            {
                foreach (Artist art in db.Artists)
                {
                    bool flag = true;
                    foreach (Follow item in result)
                    {
                        if (art.ArtistId == item.ArtistId)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        resultList.Add(art); 
                    }
                }
                return resultList;
            }
            return null;
        }

        public int GetPlaylistIdByUserId(string playlistName, int userId)
        {
            var result = db.Playlists.FirstOrDefault(a => a.UserId == userId && a.PlaylistName == playlistName);
            if (result != null)
            {
                return result.PlaylistId;
            }
            return -1;
        }
    }
}
