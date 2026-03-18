using Dotnet_API_26_Minimal_API.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<StudentDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Con")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

//========================================
//Minimal API
//========================================

//GetAll Students

app.MapGet("/students", async (StudentDbContext db) =>
{
    var students = await db.Students.ToListAsync();
    return students is null || students.Count == 0 ?  Results.BadRequest("No students Found"): Results.Ok(students);

});

//GetStudentById

app.MapGet("/student/{id:int}", async (int id, StudentDbContext db) =>
{
    var student = await db.Students.FirstOrDefaultAsync(x => x.Id == id);

    return student is null ? Results.NotFound(): Results.Ok(student);
}
);

//CreateStudent




app.Run();
