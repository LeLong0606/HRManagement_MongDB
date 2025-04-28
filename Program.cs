using HRManagement.Data;
using HRManagement.Services.HR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<HRMSetting>(
    builder.Configuration.GetSection("HRManagementDatabase")
);

builder.Services.AddSingleton<HREmployeeService>();
builder.Services.AddSingleton<HREAccountService>();
builder.Services.AddSingleton<HRDepartmentService>();
builder.Services.AddSingleton<HRSalaryService>();
builder.Services.AddSingleton<ContractService>();
builder.Services.AddSingleton<HRLeaveRecordService>();

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
