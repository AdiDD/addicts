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
    public class StepsController : Controller
    {
        private readonly IStepService _stepService;

        public StepsController(IStepService stepService)
        {
            _stepService = stepService;
        }

        [HttpGet]
        public async Task<IEnumerable<Step>> GetAllComments()
        {
            return await _stepService.GetAllAsync();
        }

        [HttpGet("{postId}")]
        public async Task<Step> GetComment(int stepId)
        {
            return await _stepService.GetAsync(stepId);
        }

        [HttpPost]
        public async Task<Step> AddComment(Step step)
        {
            return await _stepService.AddAsync(step);
        }

        [HttpPut]
        public async Task<Step> UpdateComment(Step step)
        {
            return await _stepService.UpdateAsync(step);
        }

        [HttpDelete("{stepId}")]
        public async Task<ActionResult> DeleteComment(int step)
        {
            await _stepService.RemoveAsync(step);

            if (_stepService.GetAsync(step) == null)
                return Ok();

            return BadRequest();
        }
    }
}
