using System;

namespace ExactOnline.Client.Models.Payroll
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class EmploymentOrganization
    {
        /// <summary>Cost center code</summary>
        public string CostCenter { get; set; }
        /// <summary>Description of cost center</summary>
        public string CostCenterDescription { get; set; }
        /// <summary>Cost unit code</summary>
        public string CostUnit { get; set; }
        /// <summary>Description of cost unit</summary>
        public string CostUnitDescription { get; set; }
        /// <summary>Creation date</summary>
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        public string CreatorFullName { get; set; }
        /// <summary>ID of department</summary>
        public Guid? Department { get; set; }
        /// <summary>Department code</summary>
        public string DepartmentCode { get; set; }
        /// <summary>Department description for organization</summary>
        public string DepartmentDescription { get; set; }
        /// <summary>Division code</summary>
        public int? Division { get; set; }
        /// <summary>ID of employee</summary>
        public Guid? Employee { get; set; }
        /// <summary>Name of employee</summary>
        public string EmployeeFullName { get; set; }
        /// <summary>Numeric ID of the employee</summary>
        public int? EmployeeHID { get; set; }
        /// <summary>Employement ID</summary>
        public Guid? Employment { get; set; }
        /// <summary>Numeric ID of the employment</summary>
        public int? EmploymentHID { get; set; }
        /// <summary>Organization end date</summary>
        public DateTime? EndDate { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>ID of job title</summary>
        public Guid? JobTitle { get; set; }
        /// <summary>Job title code</summary>
        public string JobTitleCode { get; set; }
        /// <summary>Job title description</summary>
        public string JobTitleDescription { get; set; }
        /// <summary>Last modified date</summary>
        public DateTime? Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        public Guid? Modifier { get; set; }
        /// <summary>Name of modifier</summary>
        public string ModifierFullName { get; set; }
        /// <summary>Explanation or extra information can be stored in the notes</summary>
        public string Notes { get; set; }
        /// <summary>Organization start date</summary>
        public DateTime? StartDate { get; set; }
    }
}
