﻿using BookMyShowBussiness.services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _userService.GetUsers();
        }
        [HttpGet("GetUserById")]
        public User GetUserById(int userId)
        {
            return _userService.GetUserByid(userId);
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            _userService.AddUser(user);
            return Ok("User created successfully!!");
        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
            return Ok("User deleted successfully!!");
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            _userService.UpdateUser(user);
            return Ok("User updated successfully!!");
        }
    }
}
