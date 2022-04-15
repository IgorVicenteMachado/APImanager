using Manager.API.ViewModels;
using System.Collections.Generic;

namespace Manager.API.Utilities
{
    public class Responses
    {
        public static ResultViewModel ApplicationErrorMassage()
        {
            return new ResultViewModel
            {
                Message = "an internal error has occurred, please try again later.",
                Success = false,
                Data = null,
            };
        }

        public static ResultViewModel DomainErrorMessage(string message)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = null,
            };
        }

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = errors,
            };
        }

        public static ResultViewModel UnauthorizedErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Username or password is incorrect.",
                Success = false,
                Data = null,
            };
        }
    }
}
