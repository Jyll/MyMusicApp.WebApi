using System;
using Microsoft.AspNetCore.Mvc;
using MyMusicApp.WebApi.Services;
using System.Net;
using Microsoft.ApplicationInsights;
using MyMusicApp.WebApi.Models;
using System.Collections.Generic;

namespace MyMusicApp.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MusicLibraryController : Controller
    {
        private readonly IMusicLibrary _musicLibraryService;
        private readonly TelemetryClient _telemetryClient;

        public MusicLibraryController(IMusicLibrary musicLibraryService, TelemetryClient telemetryClient)
        {
            _musicLibraryService = musicLibraryService;
            _telemetryClient = telemetryClient;
        }

        /// <summary>
        /// Get all songs potentially filtered by genre
        /// </summary>
        /// <param name="genreFilter">Optional filter</param>
        /// <returns>List of songs or nothing if an error happened</returns>
        [HttpGet("Songs")]
        [ProducesResponseType(typeof(List<Song>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public JsonResult GetSongs(string genreFilter = null)
        {
            try          
            {
                _telemetryClient.TrackTrace($"{nameof(GetSongs)} begins");
                return Json(_musicLibraryService.GetSongs(genreFilter));
            }
            catch(Exception unhandledException)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _telemetryClient.TrackException(unhandledException);
                return Json(null);
            }
            finally
            {
                _telemetryClient.TrackTrace($"{nameof(GetSongs)} ends");
            }
        }

        /// <summary>
        /// Get a list of songs created by the given artist
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns>List of song or null if an error happened</returns>
        [HttpGet("SongsByArtist")]
        [ProducesResponseType(typeof(List<Song>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public JsonResult GetSongsByArtist(string artistName)
        {
            try
            {
                _telemetryClient.TrackTrace($"{nameof(GetSongsByArtist)} begins");

                if (string.IsNullOrWhiteSpace(artistName))
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    _telemetryClient.TrackException(new ArgumentNullException(nameof(artistName)));
                    return Json(null);
                }

                return Json(_musicLibraryService.GetSongsByArtist(artistName));
            }
            catch (Exception unhandledException)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _telemetryClient.TrackException(unhandledException);
                return Json(null);
            }
            finally
            {
                _telemetryClient.TrackTrace($"{nameof(GetSongsByArtist)} ends");
            }
        }


    }
}