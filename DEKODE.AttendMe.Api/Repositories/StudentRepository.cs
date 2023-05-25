using DEKODE.AttendMe.Api.Model;
using DEKODE.AttendMe.Api.Model.Entities;
using DEKODE.AttendMe.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AttendMeDbContext _dbContext;

        public StudentRepository(AttendMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SaveStudent(Student student)
        {
            if (student.Id == 0)
            {
                student.Guid = Guid.NewGuid();

                await _dbContext.Students.AddAsync(student);
            }
            else
            {
                // End (update EffectiveEndDate) existing record.
                var endDate = DateTime.Now;
                var patron = _dbContext.Students.FirstOrDefault(x => x.Id == student.Id);
                patron.EffectiveEndDate = endDate;

                // Start (Insert) new record.
                var newStudent = new Student()
                {
                    FirstName = student.FirstName,
                    EffectiveEndDate = DateTimeHelper.NewEndDateTime(),
                    EffectiveStartDate = endDate,
                    Email = student.Email,
                    Grade = student.Grade,
                    Guid = student.Guid,
                    IsDeleted = student.IsDeleted,
                    LastName = student.LastName,
                    OrganisationId = student.OrganisationId,
                    Phone = student.Phone
                };

                await _dbContext.Students.AddAsync(newStudent);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IList<Student>> GetAllAsync(int organisationId)
        {
            var query = _dbContext.Students.Where(p => p.OrganisationId == organisationId &&
                                                       p.IsDeleted == false &&
                                                       p.EffectiveEndDate == DateTimeHelper.NewEndDateTime());

            return await query.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int studentId)
        {
            return await _dbContext.Students.FindAsync(studentId);
        }

        public async Task<bool> DeleteStudent(int studentId, int organisationId)
        {
            var endDate = DateTime.Now;
            var student = _dbContext.Students.FirstOrDefault(x => x.Id == studentId && x.OrganisationId == organisationId);
            student.EffectiveEndDate = endDate;
            student.IsDeleted = true;

            /* If the entry is being tracked (retrieved by key), then invoking Update API is not needed.
                The API only needs to be invoked if the entry was not tracked.
                https://www.learnentityframeworkcore.com/dbcontext/modifying-data */
            //_dbContext.Patrons.Update(patron);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}