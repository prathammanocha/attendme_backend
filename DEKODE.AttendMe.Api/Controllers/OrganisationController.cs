namespace DEKODE.AttendMe.Api.Controllers
{
    //[Authorize]
    //[ApiController]
    //[Route("api/[controller]")]
    //public class OrganisationController : Controller
    //{
    //    private readonly IOrganisationQueries _organisationQueries;
    //    private readonly IMapper _mapper;

    //    public OrganisationController(IOrganisationQueries organisationQueries, IMapper mapper)
    //    {
    //        _organisationQueries = organisationQueries;
    //        _mapper = mapper;
    //        //_tokenService = tokenService;
    //    }

    //    //[HttpGet("Employees/{organisationId}")]
    //    //public async Task<IActionResult> GetEmployeesAsync(Guid organisationId)
    //    //{
    //    //    var validationError = new ValidationProblemDetails();

    //    //    var orgId = await _organisationQueries.GetOrganisationIdAsync(organisationId);

    //    //    if (orgId == null)
    //    //    {
    //    //        validationError.Errors.Add("organisationId", new string[] { "Invalid organisation id" });
    //    //        return ValidationProblem(validationError);
    //    //    }

    //    //    var response = await _organisationQueries.GetEmployeesAsync(orgId.Value);
    //    //    var returnValue = _mapper.Map<IList<EmployeeDTO>>(response);

    //    //    return Ok(returnValue);
    //    //}
    //}
}