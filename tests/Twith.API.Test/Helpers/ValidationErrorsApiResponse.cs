using System.Collections.Generic;

namespace Twith.API.Test.Helpers
{
    public class ValidationErrorsApiResponse
    {
        public string Type { get; set; }
        
        public string Title { get; set; }
        
        public int Status { get; set; }
        
        public IDictionary<string, IList<string>> Errors { get; set; }
    }
}