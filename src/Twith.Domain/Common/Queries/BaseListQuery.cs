using MediatR;

namespace Twith.Domain.Common.Queries
{
    public abstract record BaseListQuery<TResponse> : IRequest<TResponse>
    {
        public int Limit { get; }
        
        public int Offset { get; }

        protected BaseListQuery(int limit, int offset)
        {
            Limit = limit;
            Offset = offset;
        }
    }
}