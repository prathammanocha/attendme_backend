namespace DEKODE.AttendMe.Api.Controllers
{
    //[Authorize]
    //[ApiController]
    //[Route("api/[controller]")]
    //public class AccountUserController : Controller
    //{
    //    private readonly IAccountUserQueries _accountUserQueries;
    //    private readonly IAccountUserCommands _accountUserCommands;
    //    private readonly IAccountQueries _accountQueries;
    //    private readonly IMapper _mapper;
    //    private readonly ITokenService _tokenService;
    //    private ValidationProblemDetails _validationProblem;

    //    public AccountUserController(IAccountUserQueries accountUserQueries, IMapper mapper, IAccountUserCommands accountUserCommands,
    //        IAccountQueries accountQueries, ITokenService tokenService)
    //    {
    //        _accountUserQueries = accountUserQueries;
    //        _mapper = mapper;
    //        _accountUserCommands = accountUserCommands;
    //        _accountQueries = accountQueries;
    //        _tokenService = tokenService;
    //        _validationProblem = new ValidationProblemDetails();
    //    }

    //    [AllowAnonymous]
    //    [HttpPost("Authenticate")]
    //    public async Task<IActionResult> Authenticate([FromBody] AuthenticateDTO user)
    //    {
    //        //// TODO: Use FluentValidation.
    //        //// Validate.
    //        //if (string.IsNullOrEmpty(user.UserName))
    //        //    _validationProblem.Errors.Add("UserName", new[] { "The UserName field is required." });

    //        //if (string.IsNullOrEmpty(user.Password))
    //        //    _validationProblem.Errors.Add("Password", new[] { "The Password field is required." });

    //        //if (_validationProblem.Errors.Count > 0)
    //        //    return ValidationProblem(_validationProblem);

    //        // var hashPassword = BC.HashPassword(user.Password);

    //        //TODO ~ Change username to email - change in UI as well
    //        // var response = await _accountUserQueries.FindAsync(user.UserName, user.Password);
    //        var response = await _accountUserQueries.FindByEmailAsync(user.UserName);

    //        if (response == null || !BC.Verify(user.Password, response.Password))
    //            return NotFound();

    //        return Ok(_tokenService.GenerateToken(user.UserName, response.Account.Organisations[0].Id.ToString()));
    //    }

    //    [HttpPost("Create")]
    //    public async Task<IActionResult> Create([FromBody] AccountUserDTO accountUser)
    //    {
    //        if (accountUser == null)
    //            return BadRequest();

    //        // Find account id by account guid.
    //        var accountId = await _accountQueries.GetAccountIdAsync(accountUser.AccountGuid);
    //        if (accountId == null)
    //            return BadRequest();

    //        var accountUserEntity = _mapper.Map<AccountUser>(accountUser);

    //        // Hash password before saving.
    //        accountUserEntity.Password = BC.HashPassword(accountUser.Password);
    //        accountUserEntity.Guid = System.Guid.NewGuid();
    //        accountUserEntity.AccountId = accountId.Value;

    //        await _accountUserCommands.SaveAccountUserAsync(accountUserEntity);

    //        return Ok();
    //    }

    //    [HttpGet("UserExist")]
    //    public async Task<IActionResult> UserExist(string email)
    //    {
    //        if (string.IsNullOrEmpty(email))
    //            return BadRequest();

    //        var response = await _accountUserQueries.FindByEmailAsync(email);

    //        // var returnValue = _mapper.Map<IList<PatronDTO>>(response);

    //        return Ok(response != null ? true : false);
    //    }
    //}
}