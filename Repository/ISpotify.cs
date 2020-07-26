using SpotifyTask.Models;
using SpotifyTask.Request;
using SpotifyTask.SpotifyDTO;
//using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace SpotifyTask.Repository
{
   public  interface ISpotify
    {
        bool AddUser(AddUserRequest user);
        bool UpdateUser(UpdateUserRequest user, int id);
        List<User> GetUserDetailsById(int id);

        List<Artist> GetArtists();

        List<Album> GetAlbums();

        bool AddPlaylist(AddPlaylistRequest playlist);

        List<Playlist> GetPlaylistsById(int id);

        List<Song> GetAllSongs();

        AlbumSongsDTO GetAlbumSongsByAlbumId(int id);

        bool AddSongToPlaylist(AddSongToPlaylistRequest playlist);

        bool RemoveSongfromPlaylist(int songId, int playlistId);

        PlaylistSongsDTO GetPlaylistSongsById(int userId, int playlistId);

        bool FollowArtist(AddFollowArtistRequest follow);

        bool UnfollowArtist(int userId, int artistId);

        UserFollowingDTO GetUserFollowings(int userId);

        Artist GetArtistByName(string str);

        List<ArtistDTO> GetFollowedArtist();


        bool CheckUserAuth(string name, string pass);

        User GetUserDetailsByName(string name);

        int GetPlaylistIdByName(string name);

        int GetSongIdByName(string name);

        Song GetSongByName(string name);

        List<Artist> GetUnfollowedArtists(int id);

        int GetPlaylistIdByUserId(string playlistname, int userId);

    }
}
