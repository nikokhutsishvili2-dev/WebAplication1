using FluentValidation;
using WebApplication1.Data;
using WebApplication1.helpers;
using WebApplication1.Services;
using WebApplication1.Services.UserService;
using WebApplication1.validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IUserService, UsersService>();
builder.Services.AddAutoMapper(cnf => { }, typeof(UserMapper));
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<IEmailService, EmailService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.MapSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
