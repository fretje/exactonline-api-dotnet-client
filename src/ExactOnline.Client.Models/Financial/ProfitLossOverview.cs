namespace ExactOnline.Client.Models.Financial
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("CurrentYear")]
    public class ProfitLossOverview
    {
        /// <summary>Costs in current period</summary>
        public double CostsCurrentPeriod { get; set; }
        /// <summary>Costs in current year</summary>
        public double CostsCurrentYear { get; set; }
        /// <summary>Costs in previous year</summary>
        public double CostsPreviousYear { get; set; }
        /// <summary>Costs in period of previous year</summary>
        public double CostsPreviousYearPeriod { get; set; }
        /// <summary>Currency code</summary>
        public string CurrencyCode { get; set; }
        /// <summary>Current period</summary>
        public int CurrentPeriod { get; set; }
        /// <summary>Primary key, Current year</summary>
        public int CurrentYear { get; set; }
        /// <summary>Previous year</summary>
        public int PreviousYear { get; set; }
        /// <summary>Period in previous year</summary>
        public int PreviousYearPeriod { get; set; }
        /// <summary>Results of current period</summary>
        public double ResultCurrentPeriod { get; set; }
        public double ResultCurrentYear { get; set; }
        public double ResultPreviousYear { get; set; }
        /// <summary>Results of period in previous year</summary>
        public double ResultPreviousYearPeriod { get; set; }
        /// <summary>Revenue in current period</summary>
        public double RevenueCurrentPeriod { get; set; }
        /// <summary>Revenue in current year</summary>
        public double RevenueCurrentYear { get; set; }
        /// <summary>Revenue in previous year</summary>
        public double RevenuePreviousYear { get; set; }
        /// <summary>Revenue in period of previous year</summary>
        public double RevenuePreviousYearPeriod { get; set; }
    }
}
