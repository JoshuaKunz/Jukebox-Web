using Jukebox.Models;
using JukeboxService.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JukeboxService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IJukeboxService _service;

        public AlbumsController(IJukeboxService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IEnumerable<AlbumModel>> GetAllAlbums() => await _service.GetAllAlbums();
    }
}
