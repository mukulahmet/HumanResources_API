using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project.BLL.Mapper;
using Project.BLL.Services;
using Project.BLL.Services.Abstracts;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstract;
using Project.DAL.Repositories.Concrete;
using Project.Models.Concrete;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

        };
    });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDBContext>(x=>x.UseSqlServer());

builder.Services
    .AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDBContext>()
    .AddRoles<AppRole>()
    .AddDefaultTokenProviders();

//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//        options.JsonSerializerOptions.WriteIndented = true;
//    });

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(x => x.AddProfile(typeof(ProjectMapper)));

builder.Services.AddTransient<IAppUserService, AppUserService>();
builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();

builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<ICompanyDepartmentRepository,DepartmentCompanyRepository>();

builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddTransient<IJobService, JobService>();
builder.Services.AddTransient<IJobRepository, JobRepository>();

builder.Services.AddTransient<ILeaveService, LeaveService>();   
builder.Services.AddTransient<ILeaveRepository,LeaveRepository>();

builder.Services.AddTransient<IExpenseService,ExpenseService>();
builder.Services.AddTransient<IExpenseRepository, ExpenseRepository>();

builder.Services.AddTransient<IAdvanceService, AdvanceService>();
builder.Services.AddTransient<IAdvanceRepository, AdvanceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
