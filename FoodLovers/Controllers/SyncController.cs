using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLovers.Elastic.Sync.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodLovers.Api.Controllers
{
    [Route("api/[controller]")]
    public class SyncController : ControllerBase
    {
        private readonly ISyncService _syncService;

        public SyncController(ISyncService syncService)
        {
            _syncService = syncService;
        }

        [HttpPost]
        public async Task<ActionResult> SyncData()
        {
            await  _syncService.SyncData();

            return Ok();
        }
    }
}
