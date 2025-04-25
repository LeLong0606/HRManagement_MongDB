using System.Drawing;
using System.Runtime.InteropServices;

namespace HRManagement.Data
{
    public class HRMSetting
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public Collections CollectionName { get; set; } = null!;
    }

    public class Collections
    {
        public string Employees { get; set; } = null!;
        public string Departments { get; set; } = null!;
        public string Attendance { get; set; } = null!;
        public string LeaveRecords { get; set; } = null!;
        public string PerformanceReviews { get; set; } = null!;
        public string Notifications { get; set; } = null!;
        public string Projects { get; set; } = null!;
        public string EmployeeAccounts { get; set; } = null!;
        public string Contracts { get; set; } = null!;
        public string Salaries { get; set; } = null!;
    }
}
