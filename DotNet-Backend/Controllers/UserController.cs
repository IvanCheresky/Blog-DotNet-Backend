using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Backend.Data;
using DotNet_Backend.Services.Interfaces;
using DotNet_Backend.Data.Contracts.Requests;

namespace DotNet_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUser(id);
            return Ok(user);
        }

        [HttpPost()]
        public IActionResult RegisterUser(UserRequest u)
        {
            var user = _userService.RegisterUser(u);
            return Ok(user);
        }

        [HttpPut()]
        public IActionResult UpdateUser(UserRequest u)
        {
            var user = _userService.UpdateUser(u);
            return Ok(user);
        }

        [HttpDelete()]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
