using System.Collections.Generic;

namespace PhantasiaEngine.Auth.Responses
{
    /// <summary>
    /// <c>ErrorResponse</c> class contains a list of all errors <see cref="ErrorModel"/>
    /// found during validation.
    /// </summary>
    public class ErrorResponse
    {
        // ReSharper disable once CollectionNeverQueried.Global
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}