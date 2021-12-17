using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.Dependencies
{
    public interface IStepService : IService<Step>
    {
        Task<Step> PromoteUser(ApplicationUser user);
    }
}
