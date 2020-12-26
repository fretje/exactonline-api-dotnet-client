using System;

namespace ExactOnline.Client.Models.Payroll
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class EmploymentContract
    {
        /// <summary>Flexible employment contract phase</summary>
        public int? ContractFlexPhase { get; set; }
        /// <summary>Flexible employment contract phase description.</summary>
        public string ContractFlexPhaseDescription { get; set; }
        /// <summary>Creation date</summary>
        public DateTime? Created { get; set; }
        /// <summary>User ID of creator</summary>
        public Guid? Creator { get; set; }
        /// <summary>Name of creator</summary>
        public string CreatorFullName { get; set; }
        /// <summary>Division code</summary>
        public int? Division { get; set; }
        /// <summary>Document ID of the employment contract</summary>
        public Guid? Document { get; set; }
        /// <summary>ID of employee</summary>
        public Guid? Employee { get; set; }
        /// <summary>Name of employee</summary>
        public string EmployeeFullName { get; set; }
        /// <summary>Numeric ID of the employee</summary>
        public int? EmployeeHID { get; set; }
        /// <summary>Type of employee. 1 - Employee, 2 - Contractor, 3 - Temporary, 4 - Student, 5 - Flexworker</summary>
        public int? EmployeeType { get; set; }
        /// <summary>Employee type description</summary>
        public string EmployeeTypeDescription { get; set; }
        /// <summary>Employment ID</summary>
        public Guid? Employment { get; set; }
        /// <summary>Numeric ID of the employment</summary>
        public int? EmploymentHID { get; set; }
        /// <summary>End date of employment contract</summary>
        public DateTime? EndDate { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Last modified date</summary>
        public DateTime? Modified { get; set; }
        /// <summary>User ID of modifier</summary>
        public Guid? Modifier { get; set; }
        /// <summary>Name of modifier</summary>
        public string ModifierFullName { get; set; }
        /// <summary>Notes of employment contract</summary>
        public string Notes { get; set; }
        /// <summary>Employment probation end date</summary>
        public DateTime? ProbationEndDate { get; set; }
        /// <summary>Employment probation period</summary>
        public int? ProbationPeriod { get; set; }
        /// <summary>Employment contract reason code. 1 - New employment, 2 - Employment change, 3 - New legal employer, 4 - Acquisition 5 - Previous contract expired, 6 - Other</summary>
        public int? ReasonContract { get; set; }
        /// <summary>Employment contract reason description</summary>
        public string ReasonContractDescription { get; set; }
        /// <summary>Sequence number</summary>
        public int? Sequence { get; set; }
        /// <summary>Start date of employment contract</summary>
        public DateTime? StartDate { get; set; }
        /// <summary>Type of employment contract. 1 - Definite, 2 - Indefinite, 3 - External</summary>
        public int? Type { get; set; }
        /// <summary>Description of employment contract type</summary>
        public string TypeDescription { get; set; }
    }
}
