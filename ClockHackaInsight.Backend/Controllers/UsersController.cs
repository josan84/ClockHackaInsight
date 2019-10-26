using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClockHackaInsight.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
       

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await userService.GetUserById(id));
        }

        // GET: api/User/5
        [HttpGet("name/{name}", Name = "GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await userService.GetUserByName(name));
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var newUser = await userService.CreateUser(user);
            return Ok(newUser);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] User value)
        {
            var updatedUser = await userService.SaveUser(id, value);
            return Ok(updatedUser);
        }

    }
}
