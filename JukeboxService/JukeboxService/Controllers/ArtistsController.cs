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
    public class ArtistsController : ControllerBase
    {
        private readonly IJukeboxService _service;

        public ArtistsController(IJukeboxService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IEnumerable<ArtistModel>> GetAllArtists() => await _service.GetAllArtists();
    }
}
