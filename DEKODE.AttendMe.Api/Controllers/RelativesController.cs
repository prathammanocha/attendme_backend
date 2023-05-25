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
    [Route("api/Relatives")]
    public class RelativesController : BaseController
    {
        private readonly IRelativesQueries _relativesQueries;
        private readonly IRelativesCommands _relativesCommands;
        private readonly IMapper _mapper;

        public RelativesController(IRelativesQueries relativesQueries, IMapper mapper, IRelativesCommands relativesCommands)
        {
            _relativesQueries = relativesQueries;
            _relativesCommands = relativesCommands;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (OrganisationId is null)
                return BadRequest();

            var response = await _relativesQueries.GetAllRelativesAsync(OrganisationId.Value);

            var returnValue = _mapper.Map<IList<RelativesDTO>>(response);

            return Ok(new { result = returnValue });
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int studentId)
        {
            var response = await _relativesQueries.GetRelativesByStudentIdAsync(studentId);
            var returnValue = _mapper.Map<RelativesDTO>(response);

            return Ok(new { result = returnValue });
        }

        [HttpGet("GetTypes")]
        public async Task<IActionResult> GetTypes()
        {
            var response = await _relativesQueries.GetRelativeTypesAsync();

            return Ok(new { result = response });
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] RelativesDTO relativeDTO)
        {
            if (relativeDTO == null)
                return BadRequest();

            var relative = _mapper.Map<Relatives>(relativeDTO);

            await _relativesCommands.SaveRelative(relative);

            return Ok(new { result = true });
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int relativeId)
        {
            if (relativeId == 0 || OrganisationId is null)
                return BadRequest();

            await _relativesCommands.DeleteRelative(relativeId, OrganisationId.Value);

            return Ok(new { result = true });
        }
    }
}
