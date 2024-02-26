namespace eLog.Domain.Results
{
    public class ServiceResult : AccountResult
    {
        public ServiceResult() : base()
        {
            SuccessMessage = new List<string>();
            WarningMessage = new List<string>();
        }
        public IEnumerable<string> SuccessMessage { get; set; }
        public IEnumerable<string> WarningMessage { get; set; }

        /// <summary>
        /// For Warning Message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ServiceResult Warn(params string[] message)
        {
            WarningMessage = message;
            return this;
        }

        /// <summary>
        /// For Success Message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ServiceResult Notify(params string[] message)
        {
            SuccessMessage = message;
            return this;
        }
        public bool Warning { get { return WarningMessage.Any(); } }

    }
}
