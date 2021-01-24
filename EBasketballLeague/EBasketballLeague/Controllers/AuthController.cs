using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using DataStructure;
using System.Security.Cryptography;
using DataAccess;
using System.Linq;

namespace EHouse.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private ApplicationDbContext applicationDbContext;
        public AuthController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public LoginModel CreateUser(LoginModel loginModel)
        {
            applicationDbContext.LoginModels.Add(loginModel);
            applicationDbContext.SaveChanges();
            return loginModel;
        }

        public LoginModel GetByName(string name)
        {
            LoginModel loginModel = new LoginModel();
            loginModel = applicationDbContext.LoginModels.Where(x => x.Username == name).FirstOrDefault();
            return loginModel;
        }

        [HttpPost, Route("register")]
        public IActionResult Register(LoginModel loginModel)
        {
            byte[] bytes = new UTF8Encoding().GetBytes(loginModel.Password);
            byte[] hashedBytes;
            using (SHA256Managed hashingAlgorithm = new SHA256Managed())
            {
                hashedBytes = hashingAlgorithm.ComputeHash(bytes);
            }
            Convert.ToBase64String(hashedBytes);
            LoginModel registeredLoginModel = CreateUser(loginModel);
            return Ok(registeredLoginModel);
        }
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            LoginModel loginModel = GetByName(user.Username);

            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            byte[] bytes = new UTF8Encoding().GetBytes(user.Password);
            byte[] hashedBytes;
            using (SHA256Managed hashingAlgorithm = new SHA256Managed())
            {
                hashedBytes = hashingAlgorithm.ComputeHash(bytes);
            }
            string hashedPassword = Convert.ToBase64String(hashedBytes);
            byte[] bytesForLoginModel = new UTF8Encoding().GetBytes(loginModel.Password);
            byte[] hashedBytesForLoginModel;
            using (SHA256Managed hashingAlgorithmForLoginModel = new SHA256Managed())

            {
                hashedBytesForLoginModel = hashingAlgorithmForLoginModel.ComputeHash(bytesForLoginModel);
            }

            string hashedPasswordForLoginModel = Convert.ToBase64String(hashedBytesForLoginModel);
            if (user.Username == loginModel.Username && hashedPasswordForLoginModel == hashedPassword)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKey99/Basketball"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000/",
                    audience: "http://localhost:5000/",
claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }



}
