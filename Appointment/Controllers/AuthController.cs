﻿using Appointment.Interfaces;
using Appointment.Models;
using Appointment.RequestModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        // POST api/<AuthController>
        [HttpPost]
        public string Login([FromBody] LoginRequest loginModel)
        {
            var result = _authService.Login(loginModel);
            return result;
        }

        // PUT api/<AuthController>/5
        [HttpPost("/addUser")]
       public User AddUser([FromBody] User user)
        {
            var result = _authService.addUser(user);
            return result;
        }
    }
}
