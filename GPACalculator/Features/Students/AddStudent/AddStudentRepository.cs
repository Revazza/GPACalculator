using GPACalculator.Db;
using GPACalculator.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;

namespace GPACalculator.Features.Students.AddStudent
{

    public interface IAddStudentRepository
    {
        Task AddStudentAsync(AddStudentRequest request);

        Task SaveChangesAsync();
    }

    public class AddStudentRepository : IAddStudentRepository
    {
        private readonly GPACalculatorDbContext _context;

        public AddStudentRepository(GPACalculatorDbContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(AddStudentRequest request)
        {

            var newStudent = new StudentEntity()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PersonalNumber = request.PersonalNumber,
            };


            await _context.Students.AddAsync(newStudent);

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
