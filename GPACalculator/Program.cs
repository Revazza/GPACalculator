using GPACalculator.Db;
using GPACalculator.Features.Courses.AddCourse;
using GPACalculator.Features.Courses.AddStudentToCourse;
using GPACalculator.Features.Students.AddGrade;
using GPACalculator.Features.Students.AddStudent;
using GPACalculator.Features.Students.CalculateGPA;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GPACalculatorDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GPACalculatorConnectionString"));
});

builder.Services.AddTransient<IAddStudentRepository, AddStudentRepository>();
builder.Services.AddTransient<IAddCourseRepository, AddCourseRepository>();
builder.Services.AddTransient<IAddGradeRepository, AddGradeRepository>();
builder.Services.AddTransient<ICalculateGPAService, CalculateGPAService>();
builder.Services.AddTransient<IAddStudentToCourseRepository, AddStudentToCourseRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
