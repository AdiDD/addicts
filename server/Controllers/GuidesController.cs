using server.Data;
using server.Models;
using server.Services.Dependencies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuidesController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IGuideService _guideService;

        public GuidesController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [HttpGet]
        public async Task<IEnumerable<Guide>> GetAllGuides()
        {
            return await _guideService.GetAllAsync();
        }

        [HttpGet("{postId}")]
        public async Task<Guide> GetGuide(int guideId)
        {
            return await _guideService.GetAsync(guideId);
        }

        [HttpPost]
        public async Task<Guide> AddGuide(Guide guide)
        {
            return await _guideService.AddAsync(guide);
        }

        [HttpPut]
        public async Task<Guide> UpdateGuide(Guide guide)
        {
            return await _guideService.UpdateAsync(guide);
        }

        [HttpDelete("{guideId}")]
        public async Task<ActionResult> DeleteGuide(int guideId)
        {
            await _guideService.RemoveAsync(guideId);

            if (_guideService.GetAsync(guideId) == null)
                return Ok();

            return BadRequest();
        }
    }
}
