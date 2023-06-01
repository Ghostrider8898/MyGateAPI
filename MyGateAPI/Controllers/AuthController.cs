using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyGateAPI.Services.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using MyGateAPI.Models;
using MyGateAPI.ViewModels;

namespace MyGateAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        MyGateApidbContext _context = new MyGateApidbContext();

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var userName = _userService.GetMyName();
            return Ok(userName);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserDto request)
        {
            CreatePasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);
            UserProfile newUser = new UserProfile();
            newUser.Username = request.username;
            newUser.Password = request.password;
            newUser.Email = request.email;
            newUser.FirstName = request.firstName;
            newUser.LastName = request.lastName;
            newUser.Contact = request.phoneNumber;
            newUser.AadharCardNo = request.aadharCardNo;
            newUser.Gender = request.gender;
            newUser.RoleId = request.userType;

            _context.UserProfiles.Add(newUser);
            _context.SaveChanges();

            if (request.userType == 2)
            {
                FlatOwner flatOwner = new FlatOwner();
                flatOwner.FlatNo = Convert.ToInt32(request.flatNumber);
                flatOwner.NoOfSeniorCitizen = Convert.ToInt32(request.SCitizens);
                flatOwner.NoOfPets = int.Parse(request.pets);
                flatOwner.UserId = newUser.UserId;
                _context.FlatOwners.Add(flatOwner);
            }
            else if (request.userType == 3)
            {
                Staff staff = new Staff();
                staff.Shift = request.shift;
                staff.FlatNo = int.Parse(request.flatNumberforStaff);
                staff.UserId = newUser.UserId;
                _context.Staff.Add(staff);
            }
            else if(request.userType == 4)
            {
                Visitor visitor = new Visitor();
                visitor.InTime=DateTimeOffset.Parse(request.inTime);
                visitor.OutTime= DateTimeOffset.Parse(request.outTime);
                visitor.FlatNo = int.Parse(request.flatNumber);
                visitor.PurposeOfVisit=request.visitingPurpose;
                visitor.UserId=newUser.UserId;
                visitor.VehicleNo=request.vehicleNo;
                _context.Visitors.Add(visitor);
            }
            else if( request.userType == 7)
            {
                SecurityGuard guard = new SecurityGuard();
                guard.Shift= request.shift;
                guard.UserId= newUser.UserId;
                _context.SecurityGuards.Add(guard);
            }
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] Login request)
        {
            var loginUser = _context.UserProfiles.Where(user => user.Username == request.userName);
            if(loginUser==null)
            {
                return BadRequest("User not found.");
            }

            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);

            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);

            return Ok(token);
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
