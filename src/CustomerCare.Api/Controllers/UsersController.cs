using System.Net;
using CustomerCare.Application.Interfaces;
using CustomerCare.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCare.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            return Ok(await service.Create(request));
        }
    }
}