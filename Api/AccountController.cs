//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using apiforapp.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace apiforapp.Api
//{
//    [Route("api/[controller]")]
//    public class AccountController : Controller
//    {
//        private readonly ApplicationDbcontext _db;
//        private readonly ILogger<AccountController> _logger;

//        public AccountController(ILogger<AccountController> logger, ApplicationDbcontext db)
//        {
//            _logger = logger;
//            _db = db;
//        }

//        [HttpGet]
//        public IActionResult GetAllUsers()
//        {
//            var users = _db.Users.ToList();
//            return Ok(users);
//        }

//        [HttpPost]
//        public IActionResult CreateUser([FromBody] User user)
//        {
//            if (user == null)
//            {
//                return BadRequest();
//            }

//            _db.Users.Add(user);
//            _db.SaveChanges();

//            return CreatedAtRoute("GetUserById", new { id = user.idUser }, user);
//        }

//        [HttpGet("{id}", Name = "GetUserById")]
//        public IActionResult GetUserById(int id)
//        {
//            var user = _db.Users.FirstOrDefault(u => u.idUser == id);

//            if (user == null)
//            {
//                return NotFound();
//            }

//            return Ok(user);
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
//        {
//            if (updatedUser == null || updatedUser.idUser != id)
//            {
//                return BadRequest();
//            }

//            var existingUser = _db.Users.FirstOrDefault(u => u.idUser == id);

//            if (existingUser == null)
//            {
//                return NotFound();
//            }

//            existingUser.emailAddress = updatedUser.emailAddress;
//            existingUser.password = updatedUser.password;
//            existingUser.weigh = updatedUser.weigh;
//            existingUser.heigh = updatedUser.heigh;
//            existingUser.gender = updatedUser.gender;
//            existingUser.age = updatedUser.age;
//            existingUser.avatar = updatedUser.avatar;
//            //existingUser.idStatebody = updatedUser.idStatebody; 
//            existingUser.name = updatedUser.name;

//            _db.SaveChanges();

//            return NoContent();
//        }


//        [HttpDelete("{id}")]
//        public IActionResult DeleteUser(int id)
//        {
//            var user = _db.Users.FirstOrDefault(u => u.idUser == id);

//            if (user == null)
//            {
//                return NotFound();
//            }

//            _db.Users.Remove(user);
//            _db.SaveChanges();

//            return NoContent();
//        }
//    }
//}