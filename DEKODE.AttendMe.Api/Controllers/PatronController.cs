using AutoMapper;
using DEKODE.AttendMe.Api.Commands;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Api.Queries;
using DEKODE.AttendMe.Data.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Controllers
{
    [Authorize]
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/Visitor")]
    public class PatronController : BaseController
    {
        private readonly IPatronQueries _patronQueries;
        private readonly IPatronCommands _patronCommands;
        private readonly IMapper _mapper;

        public PatronController(IPatronQueries patronQueries, IMapper mapper, IPatronCommands patronCommands)
        {
            _patronQueries = patronQueries;
            _patronCommands = patronCommands;
            _mapper = mapper;
        }

        /// <summary>
        /// Used to get Visitor List.
        /// </summary>
        /// <returns></returns>
        // [HttpGet("GetById/{accountId}")] // GET /api/Account/xyz
        // https://localhost:44302/api/patron?organisationId=1
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            // WARNING: DO NOT USE .Result or .Wait() on async method. It will run the operation synchronously
            // and may dead lock the entire application.
            // var r = _accountQueries.GetAllAsync().Result;

            //if (orgId is null)
            //    return NotFound();

            if (OrganisationId is null)
                return BadRequest();

            var response = await _patronQueries.GetAllAsync(OrganisationId.Value);

            var returnValue = _mapper.Map<IList<PatronDTO>>(response);

            return Ok(new { result = returnValue });
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int visitorId)
        {
            var response = await _patronQueries.GetByIdAsync(visitorId);
            var returnValue = _mapper.Map<PatronDTO>(response);

            return Ok(new { result = returnValue });
        }

        [HttpGet("GetLogs")]
        public async Task<IActionResult> GetLogs(DateTime? fromDateTime, DateTime? toDateTime)
        {
            if (OrganisationId is null)
                return BadRequest();

            var response = await _patronQueries.GetVistorLogs(fromDateTime, toDateTime, OrganisationId.Value);

            var returnValue = _mapper.Map<IList<VisitorLogDTO>>(response);

            return Ok(new { result = returnValue });
        }

        [HttpGet("GetTypes")]
        public async Task<IActionResult> GetTypes()
        {
            if (OrganisationId is null)
                return BadRequest();

            var response = await _patronQueries.GetPatronTypesAsync();

            return Ok(new { result = response });
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] PatronDTO visitorDTO)
        {
            if (visitorDTO == null)
                return BadRequest();

            var visitor = _mapper.Map<Patron>(visitorDTO);

            await _patronCommands.SaveVisitor(visitor);

            return Ok(new { result = true });
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int visitorId)
        {
            if (visitorId == 0 || OrganisationId is null)
                return BadRequest();

            await _patronCommands.DeleteVisitor(visitorId, OrganisationId.Value);

            return Ok(new { result = true });
        }
    }
}