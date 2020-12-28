using System;

namespace ExactOnline.Client.Models.Payroll
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class EmploymentSalary
    {
        /// <summary>The average number of contract days that an employee works per week</summary>
        public double? AverageDaysPerWeek { get; set; }
        /// <summary>The average number of contract hours that an employee works per week</summary>
        public double? AverageHoursPerWeek { get; set; }
        /// <summary>Creation date</summary>
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        public string CreatorFullName { get; set; }
        /// <summary>Division code</summary>
        public int? Division { get; set; }
        /// <summary>Employee ID</summary>
        public Guid? Employee { get; set; }
        /// <summary>Name of employee</summary>
        public string EmployeeFullName { get; set; }
        /// <summary>Employee number</summary>
        public int? EmployeeHID { get; set; }
        /// <summary>Employment</summary>
        public Guid? Employment { get; set; }
        /// <summary>Employment number</summary>
        public int? EmploymentHID { get; set; }
        /// <summary>Salary type of employment. 1 - Periodical (fixed), 2 - Per hour (variable)</summary>
        public int? EmploymentSalaryType { get; set; }
        /// <summary>Salary type description</summary>
        public string EmploymentSalaryTypeDescription { get; set; }
        /// <summary>Salary record end date</summary>
        public DateTime? EndDate { get; set; }
        /// <summary>Salary when working fulltime</summary>
        public double? FulltimeAmount { get; set; }
        /// <summary>Hourly wage</summary>
        public double? HourlyWage { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Internal rate for time &amp; billing or professional service user</summary>
        public double? InternalRate { get; set; }
        /// <summary>Employee job level in context of a wage scale</summary>
        public int? JobLevel { get; set; }
        /// <summary>Last modified date</summary>
        public DateTime? Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        public Guid? Modifier { get; set; }
        /// <summary>Name of modifier</summary>
        public string ModifierFullName { get; set; }
        /// <summary>Salary when working parttime</summary>
        public double? ParttimeAmount { get; set; }
        /// <summary>Contract hours / Fulltime contract hours</summary>
        public double? ParttimeFactor { get; set; }
        /// <summary>Employee wage scale</summary>
        public string Scale { get; set; }
        /// <summary>Employment schedule</summary>
        public Guid? Schedule { get; set; }
        /// <summary>Employment schedule code</summary>
        public string ScheduleCode { get; set; }
        /// <summary>Description of employment schedule</summary>
        public string ScheduleDescription { get; set; }
        /// <summary>Salary record start date</summary>
        public DateTime? StartDate { get; set; }
    }
}
