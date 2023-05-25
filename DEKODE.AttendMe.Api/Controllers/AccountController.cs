namespace DEKODE.AttendMe.Api.Controllers
{
    // REST APIs should use attribute routing to model the app's functionality as a set of resources where operations are represented by HTTP verbs.

    //[ApiController]
    //[Route("api/[controller]")]
    //public class AccountController : Controller
    //{
    //    private readonly IAccountQueries _accountQueries;
    //    private readonly IAccountCommands _accountCommands;
    //    private readonly IMapper _mapper;

    //    public AccountController(IAccountQueries accountQueries, IAccountCommands accountCommands, IMapper mapper)
    //    {
    //        _accountQueries = accountQueries;
    //        _accountCommands = accountCommands;
    //        _mapper = mapper;
    //    }

    //    [HttpGet()] // GET /api/Account
    //    public async Task<IActionResult> Get()

    //    {
    //        // WARNING: DO NOT USE .Result or .Wait() on async method. It will run the operation synchronously
    //        // and may dead lock the entire application.
    //        // var r = _accountQueries.GetAllAsync().Result;

    //        var response = await _accountQueries.GetAllAsync();
    //        var returnValue = _mapper.Map<IList<AccountDTO>>(response);

    //        return Ok(returnValue);
    //    }

    //    // [HttpGet("int2/{id}")]  // GET /api/Account/int2/3
    //    // [HttpGet("int/{id:int}")] // GET /api/Account/int/3
    //    [HttpGet("GetById/{accountId}")] // GET /api/Account/xyz
    //    public async Task<IActionResult> GetById(Guid accountId)
    //    {
    //        // A187E031-DA80-4B48-978F-84D71978B632
    //        // AE5F34FC-C750-4F64-9A1C-8D72443F925C
    //        // id = Guid.Parse("{A187E031-DA80-4B48-978F-84D71978B632}");

    //        //var response = await _accountQueries.GetByIdAsync(id);

    //        //if (response == null)
    //        //    return NotFound("Account cannot be found");

    //        //var returnValue = _mapper.Map<AccountDTO>(response);

    //        //return Ok(returnValue);

    //        var validationError = new ValidationProblemDetails();

    //        var accId = await _accountQueries.GetAccountIdAsync(accountId);

    //        if (accId == null)
    //        {
    //            //validationError.Errors.Add("accountId", new string[] { "Invalid account id" });
    //            //return ValidationProblem(validationError);

    //            return NotFound();
    //        }

    //        var response = await _accountQueries.GetByIdAsync(accId.Value);
    //        var returnValue = _mapper.Map<AccountDTO>(response);

    //        return Ok(returnValue);
    //    }

    //    [HttpPost("Create")]
    //    public async Task<IActionResult> Create([FromBody] AccountDTO account)
    //    {
    //        // *************** DONT REMOVE THE COMMENTED CODE BELOW *****************************************
    //        // AccountDTO is validated DataAnnotations - [Required]
    //        // Following commented are various options for custom validation

    //        // 1.
    //        //if (account == null)
    //        //    return BadRequest("Account cannot be null");

    //        // 2a.
    //        // Custom bad request model validation
    //        //if (string.IsNullOrEmpty(account.ABN))
    //        //    return Problem("ABN Cannot be null", statusCode: 400);

    //        // 2b.
    //        //if (string.IsNullOrEmpty(account.ABN))
    //        //{
    //        //    var validationError = new ValidationProblemDetails();
    //        //    string[] values = { "The ABN field is required." };

    //        //    validationError.Errors.Add("ABN", values);
    //        //    return ValidationProblem(validationError);
    //        //}

    //        // 2b output
    //        //{
    //        //    "title": "One or more validation errors occurred.",
    //        //    "status": 400,
    //        //    "errors": {
    //        //        "ABN": [
    //        //        "The ABN field is required."
    //        //        ]
    //        //    }
    //        //}

    //        // 3.
    //        //try
    //        //{
    //        //    var accEntity = _mapper.Map<Account>(account);

    //        //    await _accountCommands.SaveAccountAsync(accEntity);

    //        //    return Ok();
    //        //}
    //        //catch (Exception ex)
    //        //{
    //        //    // 500 Internal Server Error
    //        //    // Log....
    //        //    return Problem(detail:ex.Message);
    //        //}
    //        // ********************************************************************************************************

    //        if (account == null)
    //            return BadRequest();

    //        var accEntity = _mapper.Map<Account>(account);

    //        await _accountCommands.SaveAccountAsync(accEntity);

    //        return Ok();
    //        // return Created(Request.Path.ToUriComponent, createdAccount.Id)
    //    }
    //}
}