using AutoMapper;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Api.Repositories;
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
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StudentController : BaseController
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IStudentLogRepository _studentLogRepository;

        public StudentController(IStudentRepository studentRepository, IMapper mapper, IStudentLogRepository studentLogRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _studentLogRepository = studentLogRepository;
        }

        [HttpGet()] // GET /api/student
        public async Task<IActionResult> Get()
        {
            if (OrganisationId is null)
                return BadRequest();

            var response = await _studentRepository.GetAllAsync(OrganisationId.Value);

            var returnValue = _mapper.Map<IList<StudentDTO>>(response);

            return Ok(new { result = returnValue });
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int studentId)
        {
            var response = await _studentRepository.GetByIdAsync(studentId);
            var returnValue = _mapper.Map<StudentDTO>(response);

            return Ok(returnValue);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] StudentDTO studentDTO)
        {
            if (studentDTO == null)
                return BadRequest();

            var student = _mapper.Map<Student>(studentDTO);

            await _studentRepository.SaveStudent(student);

            return Ok(new { result = true });
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int studentId)
        {
            if (studentId == 0 || OrganisationId is null)
                return BadRequest();

            await _studentRepository.DeleteStudent(studentId, OrganisationId.Value);

            return Ok(new { result = true });
        }

        [HttpGet("GetLogs")]
        public async Task<IActionResult> GetLogs(DateTime? fromDateTime, DateTime? toDateTime)
        {
            if (OrganisationId is null)
                return BadRequest();

            var logs = await _studentLogRepository.GetStudentLogsAsync(OrganisationId.Value, fromDateTime ?? DateTime.MinValue, toDateTime ?? DateTime.MaxValue);
            var returnValue = _mapper.Map<IList<StudentLogDTO>>(logs);

            return Ok(new { result = returnValue });
        }
    }
}
