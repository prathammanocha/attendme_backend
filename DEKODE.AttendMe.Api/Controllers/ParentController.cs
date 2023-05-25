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
    [Route("api/Parents")]
    public class ParentController : BaseController
    {
        private readonly IParentQueries _parentQueries;
        private readonly IParentsCommands _parentCommands;
        private readonly IMapper _mapper;

        public ParentController(IParentQueries parentQueries, IMapper mapper, IParentsCommands parentCommands)
        {
            _parentQueries = parentQueries;
            _parentCommands = parentCommands;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (OrganisationId is null)
                return BadRequest();

            var response = await _parentQueries.GetAllParentsAsync(OrganisationId.Value);
            var returnValue = _mapper.Map<IList<ParentsDTO>>(response);

            return Ok(new { result = returnValue });
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int studentId)
        {
            var response = await _parentQueries.GetParentsByStudentIdAsync(studentId);
            var returnValue = _mapper.Map<ParentsDTO>(response);

            return Ok(new { result = returnValue });
        }

        [HttpGet("GetTypes")]
        public async Task<IActionResult> GetTypes()
        {
            var response = await _parentQueries.GetParentTypesAsync();

            return Ok(new { result = response });
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] ParentsDTO parentDTO)
        {
            if (parentDTO == null)
                return BadRequest();

            var parent = _mapper.Map<Parents>(parentDTO);

            await _parentCommands.SaveParent(parent);

            return Ok(new { result = true });
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int parentId)
        {
            if (parentId == 0 || OrganisationId is null)
                return BadRequest();

            await _parentCommands.DeleteParent(parentId, OrganisationId.Value);

            return Ok(new { result = true });
        }
    }
}

