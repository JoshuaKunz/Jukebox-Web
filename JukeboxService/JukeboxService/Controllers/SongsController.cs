﻿using Jukebox.Models;
using JukeboxService.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JukeboxService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly IJukeboxService _service;

        public SongsController(IJukeboxService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IEnumerable<SongModel>> Get() => await _service.GetAllSongs();
    }
}
