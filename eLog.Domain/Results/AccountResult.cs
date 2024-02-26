namespace eLog.Domain.Results
{
    public class AccountResult
    {
        public AccountResult() : base()
        {
            Errors = new List<string>();
        }

        public IEnumerable<string> Errors { get; set; }

        public AccountResult(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public AccountResult(params string[] errors)
        {
            Errors = errors;
        }

        public AccountResult Failed(IEnumerable<string> errors)
        {
            Errors = errors;
            return this;
        }

        public AccountResult Failed(params string[] errors)
        {
            Errors = errors;
            return this;
        }

        public bool Success
        {
            get { return !Errors.Any(); }
        }

    }
}
