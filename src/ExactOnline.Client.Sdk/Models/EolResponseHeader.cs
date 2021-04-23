namespace ExactOnline.Client.Sdk.Models
{
    public class EolResponseHeader
    {
        public EolResponseHeader(RateLimit rateLimit)
        {
            RateLimit = rateLimit;
        }

        /// <summary>
        /// HTTP response header to indicate the shaping / throttling rate limit
        /// more info: https://support.exactonline.com/community/s/knowledge-base#All-All-DNO-Simulation-gen-apilimits
        /// </summary>
        public RateLimit RateLimit { get; set; }
    }
}
