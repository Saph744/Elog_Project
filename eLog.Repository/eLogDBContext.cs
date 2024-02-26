using eLog.Repository.Mappping;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace eLog.Domain.Data
{
    public class eLogDBContext:DbContext 
    {
        private DbConnection dbConnection;
        private bool v;
        public eLogDBContext(DbContextOptions<eLogDBContext> options) : base(options)
        {

        }
        public eLogDBContext(DbConnection dbConnection, bool v)
        {
            this.dbConnection = dbConnection;
            this.v = v;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LeaveApprovalMap());
            builder.ApplyConfiguration(new CompanyMap());
            builder.ApplyConfiguration(new ProjectMap());
            builder.ApplyConfiguration(new HolidayDetailMap());
            builder.ApplyConfiguration(new HolidayCalendarMap());
            builder.ApplyConfiguration(new ContactMap());
            builder.ApplyConfiguration(new EmployeeMap());
            builder.ApplyConfiguration(new LocationMap());
            builder.ApplyConfiguration(new LeavePolicySettingMap());
            builder.ApplyConfiguration(new LeavePolicyMap());
            builder.ApplyConfiguration(new DepartmentMap());
            builder.ApplyConfiguration(new LeaveTypeMap());
            builder.ApplyConfiguration(new UserLeaveDetailMap());
            builder.ApplyConfiguration(new WorkingDayMap());
            builder.ApplyConfiguration(new CodeTableMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new EmployeeTypeMap());
            builder.ApplyConfiguration(new RoleMap());
            base.OnModelCreating(builder);
        }
    }
}