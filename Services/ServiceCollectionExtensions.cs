using HRManagement.Services.HR;

namespace HRManagement.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHRManagementServices(this IServiceCollection services)
        {
            var serviceTypes = new[]
            {
                //Services for role HR
                typeof(EmployeeService),
                typeof(EmployeeAccountService),
                typeof(DepartmentService),
                typeof(SalaryService),
                typeof(ContractService),
                typeof(LeaveRecordService),
                typeof(AttendanceService),
                typeof(PRService),
                typeof(ProjectService),
                typeof(NotificationService)
            };

            foreach (var serviceType in serviceTypes)
            {
                services.AddSingleton(serviceType);
            }

            return services;
        }
    }
}
