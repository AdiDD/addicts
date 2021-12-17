using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IStepService _stepService;
        private readonly IUserService _userService;

        public UserController(IStepService stepService, IUserService userService)
        {
            _stepService = stepService;
            _userService = userService;
        }

        [HttpPut("/api/users/{userId}/promote")]
        public async Task<Step> PromoteUser(string id)
        {
            var user = await _userService.GetAsync(id);
            return await _stepService.PromoteUser(user);
        }
    }
}
