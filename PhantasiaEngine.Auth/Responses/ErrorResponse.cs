using System.Collections.Generic;

namespace PhantasiaEngine.Auth.Responses
{
    public class ErrorResponse
    {
        // ReSharper disable once CollectionNeverQueried.Global
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}