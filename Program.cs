using AdminDBHandler.Models.User;
using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.Context;
using DatabaseHandler.Controllers.AboutUser.Works.AboutOfficial;
using DatabaseHandler.Controllers.AboutUser.Works.AboutStudent;
using DatabaseHandler.Controllers.AboutUser.Works.AboutTeacher;
using DatabaseHandler.Models_and_repositories.CommonRepository;
using DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.DeptRepository;
using DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.LevelTermRepository;
using DatabaseHandler.Models_and_repositories.Generated.MessageRepository;
using DatabaseHandler.Models_and_repositories.Role.RoleRepository;
using DatabaseHandler.Models_and_repositories.User.User_Types;
using DatabaseHandler.Models_and_repositories.User.User_Types.User_Type_Generic_Repository;
using DatabaseHandler.Models_and_repositories.User.User_Types.UserTypeRepositories.Official_Repository;
using DatabaseHandler.Models_and_repositories.User.User_Types.UserTypeRepositories.Student_Repository;
using DatabaseHandler.Models_and_repositories.User.User_Types.UserTypeRepositories.Teacher_Repository;
using DatabaseHandler.Models_and_repositories.User.UserRepository;
using DatabaseHandler.Work.AddUser;
using DatabaseHandler.Work.GetToSendGenericUserDetails;
using DatabaseHandler.Work.Initialization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// service region
builder.Services.AddTransient(typeof(ICommonGenericRepository<>), typeof(CommonGenericRepository<>));
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient(typeof(IUserTypeGenericRepository<>),typeof(UserTypeGenericRepository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();


builder.Services.AddTransient<Users>();  /*
builder.Services.AddTransient<ICommonUserType, Officials>();
builder.Services.AddTransient<ICommonUserType, Teachers>();
builder.Services.AddTransient<ICommonUserType, Students>();  */



builder.Services.AddTransient(typeof(IAddUserUnitOfWork<>),typeof(AddUserUnitOfWork<>));
builder.Services.AddTransient<IToSendGenericUserDetails, ToSendGenericUserDetails>();

builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IInitializationWorkFlow, InitializationWorkFlow>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<ILevelTermRepository, LevelTermRepository>();

builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
builder.Services.AddTransient<IGetInfoAboutTeacherWork, GetInfoAboutTeacherWork>();

builder.Services.AddTransient<IOfficialRepository, OfficialRepository>();
builder.Services.AddTransient<IGetInfoAboutOfficialWork, GetInfoAboutOfficialWork>();

builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IGetInfoAboutStudentWork, GetInfoAboutStudentWork>();
// service region ends



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
