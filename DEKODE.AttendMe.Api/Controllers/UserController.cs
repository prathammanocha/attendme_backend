using AutoMapper;
using DEKODE.AttendMe.Api.Commands;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Api.Queries;
using DEKODE.AttendMe.Api.Services;
using DEKODE.AttendMe.Data.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace DEKODE.AttendMe.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : BaseController
    {
        private readonly IUserQueries _organisationQueries;
        private readonly IUserCommands _organisationCommands;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private ValidationProblemDetails _validationProblemDetails;
        private readonly IMapper _mapper;

        private ValidationProblemDetails ValidationProblemDetails
        {
            get
            {
                if (_validationProblemDetails == null)
                    _validationProblemDetails = new ValidationProblemDetails();

                return _validationProblemDetails;
            }
        }

        public UserController(IUserQueries organisationQueries, IUserCommands organisationCommands,
                              ITokenService tokenService, IMapper mapper, IEmailService emailService)
        {
            _organisationQueries = organisationQueries;
            _organisationCommands = organisationCommands;
            _emailService = emailService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpGet()] // GET /api/User
        public async Task<IActionResult> Get()

        {
            if (OrganisationId is null)
                return BadRequest();

            var response = await _organisationQueries.GetAllAsync(OrganisationId.Value);

            var returnValue = _mapper.Map<IList<OrganisationUserDTO>>(response);

            return Ok(new { result = returnValue });
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int userId)
        {
            var response = await _organisationQueries.GetByIdAsync(userId);
            var returnValue = _mapper.Map<OrganisationUserDTO>(response);

            // return Ok(returnValue);
            return Ok(new { result = returnValue });
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] OrganisationUserDTO user)
        {
            if (user == null)
                return BadRequest();

            var orgUser = _mapper.Map<OrganisationUser>(user);

            await _organisationCommands.SaveUser(orgUser);

            return Ok(new { result = true });
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateDTO user)
        {
            //// TODO: Use FluentValidation.
            //// Validate.
            //if (string.IsNullOrEmpty(user.UserName))
            //    _validationProblem.Errors.Add("UserName", new[] { "The UserName field is required." });

            //if (string.IsNullOrEmpty(user.Password))
            //    _validationProblem.Errors.Add("Password", new[] { "The Password field is required." });

            //if (_validationProblem.Errors.Count > 0)
            //    return ValidationProblem(_validationProblem);

            //var hashPassword = BC.HashPassword(user.Password);

            //TODO ~ Change username to email - change in UI as well
            var response = await _organisationQueries.FindByEmailAsync(user.UserName);

            if (response == null || !BC.Verify(user.Password, response.Password))
                return NotFound();

            // return Ok(_tokenService.GenerateToken(user.UserName, response.OrganisationId.ToString()));
            return Ok(new { result = _tokenService.GenerateToken(user.UserName, response.OrganisationId.ToString(), response.FirstName, response.LastName) });
        }

        /// <summary>
        /// Used for password reset functionality.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True if eamil exist, otherwise false</returns>
        [AllowAnonymous]
        [HttpPost("UserExist")]
        public async Task<IActionResult> UserExist(string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest();

            var orgUser = await _organisationQueries.FindByEmailAsync(email);

            if (orgUser is null)
                return NotFound();

            // Generate pasword reset link.
            var passResetLink = _tokenService.GenerateToken(orgUser.Email, orgUser.OrganisationId.ToString(), Encoding.UTF8.GetBytes(orgUser.Password));

            // ~TODO Email password reset link to the user.
            // var message = new Message(new string[] { "pankajbanga@gmail.com" }, "Reset link", $"Click below to reset your password {System.Environment.NewLine} {passResetLink}");
            var message = new Message(orgUser, passResetLink);
            await _emailService.SendEmail(message);

            // return Ok(new ObjectResult(new { Id = "1", Name="Pankaj" } ));
            // return Ok(!string.IsNullOrEmpty(passResetLink));
            // return Ok(new { result = !string.IsNullOrEmpty(passResetLink) });
            // return Ok(new ActionResult<bool>(!string.IsNullOrEmpty(passResetLink)));

            return Ok(new { result = !string.IsNullOrEmpty(passResetLink) });
        }

        [AllowAnonymous]
        [HttpPost("ValidateToken")]
        public async Task<IActionResult> ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return BadRequest();

            // Read user name from and org id from the token
            var jwtToken = GetJwtToken(token);

            var userName = GetUserNameFromToken(jwtToken);
            var orgId = GetOrganisationIdFromToken(jwtToken);

            // Get organisation user
            var orgUser = await _organisationQueries.FindByEmailAsync(userName, orgId);

            if (orgUser is null)
                return BadRequest();

            // Validate token
            var claims = _tokenService.ValidateToken(token, Encoding.UTF8.GetBytes(orgUser.Password));

            if (claims is null || claims.Count() == 0)
                return BadRequest();

            return Ok(new { result = true });
        }

        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string token, string newPassword)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(newPassword))
                return BadRequest();

            // Read user name from and org id from the token
            var jwtToken = GetJwtToken(token);

            var userName = GetUserNameFromToken(jwtToken);
            var orgId = GetOrganisationIdFromToken(jwtToken);

            // Get organisation user
            var orgUser = await _organisationQueries.FindByEmailAsync(userName, orgId);
            if (orgUser is null)
                return BadRequest();

            // Validate token
            var claims = _tokenService.ValidateToken(token, Encoding.UTF8.GetBytes(orgUser.Password));

            if (claims is null || claims.Count() == 0)
                return BadRequest();

            var hashPassword = BC.HashPassword(newPassword);

            // Reset password
            var result = await _organisationCommands.ResetUserPassword(userName, orgId, hashPassword);

            // return Ok(result);
            return Ok(new { result = result });
        }

        private string GetUserNameFromToken(JwtSecurityToken jwtToken)
        {
            return jwtToken.Claims.First(x => x.Type == "username").Value;
        }

        private int GetOrganisationIdFromToken(JwtSecurityToken jwtToken)
        {
            return int.Parse(jwtToken.Claims.First(x => x.Type == "orgid").Value);
        }

        private JwtSecurityToken GetJwtToken(string token)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(token);
        }
    }
}