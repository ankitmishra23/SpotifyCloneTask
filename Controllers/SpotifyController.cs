//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyTask.Repository;
using SpotifyTask.Request;

namespace SpotifyTask.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        private readonly ISpotify repository;
        public SpotifyController(ISpotify spotify)
        {
            this.repository = spotify;
        }
        
        [HttpPost("adduser")]
        public IActionResult AddUsers(AddUserRequest user)
        {
            return Ok(repository.AddUser(user));
        }

        [HttpPut("updateuser/{id}")]
        public IActionResult UpdateUsers(UpdateUserRequest user, int id)
        {
            return Ok(repository.UpdateUser(user, id));
        }

        [HttpGet("getusers/{id}")]
        public IActionResult GetUsers(int id)
        {
            return Ok(repository.GetUserDetailsById(id));
        }

        [HttpGet("getartists")]
        public IActionResult GetAllArtists()
        {
            return Ok(repository.GetArtists());
        }

        [HttpPost("addplaylist")]
        public IActionResult AddPlaylist(AddPlaylistRequest playlist)
        {
            return Ok(repository.AddPlaylist(playlist));
        }

        [HttpGet("getalbum")]
        public IActionResult GetAlbums()
        {
            return Ok(repository.GetAlbums());
        }

        [HttpGet("getplaylistbyid/{id}")]
        public IActionResult GetPlaylistById(int id)
        {
            return Ok(repository.GetPlaylistsById(id));
        }

        [HttpGet("getallsongs")]
        public IActionResult GetAllSongs()
        {
            return Ok(repository.GetAllSongs());
        }

        [HttpGet("getalbumsongsbyid/{id}")]

        public IActionResult GetAlbumSongsById(int id)
        {
            return Ok(repository.GetAlbumSongsByAlbumId(id));
        }

        [HttpPost("addsongstoplaylist")]
        public IActionResult AddSongsToPlaylist(AddSongToPlaylistRequest play)
        {
            return Ok(repository.AddSongToPlaylist(play));
        }

        [HttpDelete("removesong/{songid}/{playlistid}")]
        public IActionResult RemoveSongs(int songid, int playlistid)
        {
            return Ok(repository.RemoveSongfromPlaylist(songid, playlistid));
        }

        [HttpGet("getplaylistsongs/{userid}/{playlistid}")]
        public IActionResult GetPlaylistSongs(int userid, int playlistid)
        {
            return Ok(repository.GetPlaylistSongsById(userid, playlistid));
        }

        [HttpPost("followartist")]
        public IActionResult FollowArtist(AddFollowArtistRequest follow)
        {
            return Ok(repository.FollowArtist(follow));
        }

        [HttpDelete("unfollowartist/{userId}/{artistId}")]
        public IActionResult UnfollowArtist(int userId, int artistId)
        {
            return Ok(repository.UnfollowArtist(userId, artistId));
        }

        [HttpGet("getuserfollowings/{userId}")]

        public IActionResult GetUserFollow(int userId)
        {
            return Ok(repository.GetUserFollowings(userId));
        }

        [HttpGet("getartistbyname/{name}")]
        public IActionResult GetArtistByName(string name)
        {
            return Ok(repository.GetArtistByName(name));
        }

        [HttpGet("getfollowedartist")]
        public IActionResult GetFollowedArtist()
        {
            return Ok(repository.GetFollowedArtist());
        }

        [HttpGet("getuserauthentication/{name}/{pass}")]
        public IActionResult GetUserAuth(string name, string pass)
        {
            return Ok(repository.CheckUserAuth(name, pass));
        }

        [HttpGet("getuserdetailsbyname/{name}")]
        public IActionResult GetUserDetailsByName(string name)
        {
            return Ok(repository.GetUserDetailsByName(name));
        }

        [HttpGet("getplaylistidbyname/{name}")]
        public IActionResult GetPlaylistIdByName(string name)
        {
            return Ok(repository.GetPlaylistIdByName(name));
        }

        [HttpGet("getsongidbyname/{name}")]
        public IActionResult GetSongIdByName(string name)
        {
            return Ok(repository.GetSongIdByName(name));
        }

        [HttpGet("getsongnamebyname/{name}")]
        public IActionResult GetSongNameByName(string name)
        {
            return Ok(repository.GetSongByName(name));
        }

        [HttpGet("getunfollowedartist/{userId}")]
        public IActionResult GetUnfollowedArtist(int userId)
        {
            return Ok(repository.GetUnfollowedArtists(userId));
        }

        [HttpGet("getplaylistidbyuserid/{playlistName}/{userId}")]
        public IActionResult GetPlaylistIdBYUserId(string playlistName, int userId)
        {
            return Ok(repository.GetPlaylistIdByUserId(playlistName, userId));
        }
    }
}
