using System.Collections;

namespace MISA.WEB07.TNANH.MultiLayer.BL.Exceptions
{
    public class ValidateException : Exception
    {
        IDictionary ErrorMessage;
        private Dictionary<string, string> errors;
        private ValidateError errors1;

        public ValidateException(List<string> message)
        {
            ErrorMessage = new Dictionary<string, List<string>>();
            ErrorMessage.Add("error", message);
        }

        public ValidateException(Dictionary<string, string> errors)
        {
            this.errors = errors;
        }

        public ValidateException(ValidateError errors1)
        {
            this.errors1 = errors1;
        }

        public override IDictionary Data => this.ErrorMessage;
    }
}
