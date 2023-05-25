using AutoMapper;
using DEKODE.AttendMe.Api.Commands;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Api.Queries;
using DEKODE.AttendMe.Data.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : BaseController
    {
        private readonly IStaffQueries _staffQueries;
        private readonly IStaffCommands _staffCommands;
        private readonly IMapper _mapper;
        private ValidationProblemDetails _validationProblem;

        //TODO ~ Inject school guid from request - startup.cs
        public StaffController(IStaffQueries staffQueries, IMapper mapper, IStaffCommands staffCommands)
        {
            _staffQueries = staffQueries;
            _staffCommands = staffCommands;
            _mapper = mapper;
            _validationProblem = new ValidationProblemDetails();
        }

        [HttpGet()] // GET /api/staff
        public async Task<IActionResult> Get()

        {
            // WARNING: DO NOT USE .Result or .Wait() on async method. It willl run the operation synchronously
            // and may dead lock the entire application.
            // var r = _accountQueries.GetAllAsync().Result;

            if (OrganisationId is null)
                return BadRequest();

            var result = await _staffQueries.GetAllAsync(OrganisationId.Value);

            var returnValue = _mapper.Map<IList<StaffDTO>>(result);

            return Ok(returnValue);
        }

        [HttpGet("GetById")] // GET /api/staff
        public async Task<IActionResult> GetById(int staffId)
        {
            //var staffId = await _staffQueries.GetStaffId(staffGuid);

            var response = await _staffQueries.GetByIdAsync(staffId);

            var returnValue = _mapper.Map<StaffDTO>(response);

            return Ok(returnValue);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] StaffDTO staff)
        {
            if (staff == null)
                return BadRequest();

            var staffMember = _mapper.Map<Staff>(staff);

            await _staffCommands.SaveStaff(staffMember);

            return Ok();
        }

        //[HttpPost("Delete")]
        //public async Task<IActionResult> Delete([FromBody] int staffId)
        //{
        //    await _staffCommands.DeleteStaffAsync(staffId);

        //    return Ok();
        //}
    }
}