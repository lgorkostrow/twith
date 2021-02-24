using System.Collections.Generic;

namespace Twith.API.Responses
{
    public record ListResponse<T>
    {
        public List<T> Data { get; }

        public ListResponse(List<T> data)
        {
            Data = data;
        }
    }
}