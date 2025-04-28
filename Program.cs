using HRManagement.Data;
using HRManagement.Services.HR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ApplicationMongoDB>(
    builder.Configuration.GetSection("HRManagementDatabase")
);

builder.Services.AddSingleton<EmployeeService>();
builder.Services.AddSingleton<EmployeeAccountService>();
builder.Services.AddSingleton<DepartmentService>();
builder.Services.AddSingleton<SalaryService>();
builder.Services.AddSingleton<ContractService>();
builder.Services.AddSingleton<LeaveRecordService>();
builder.Services.AddSingleton<AttendanceService>();
builder.Services.AddSingleton<PRService>();
builder.Services.AddSingleton<ProjectService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
