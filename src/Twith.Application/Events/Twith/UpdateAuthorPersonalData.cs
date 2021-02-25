using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.User.Events;
using Twith.Infrastructure.Data;

namespace Twith.Application.Events.Twith
{
    public class UpdateAuthorPersonalData : INotificationHandler<UserPersonalDataChangedEvent>
    {
        private readonly ApplicationDbContext _context;

        public UpdateAuthorPersonalData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UserPersonalDataChangedEvent notification, CancellationToken cancellationToken)
        {
            await _context.Database.ExecuteSqlRawAsync(@"
                UPDATE twiths
                SET author_first_name = {0}, author_last_name = {1}  
                WHERE author_id = {2}", 
                notification.FirstName.Value,
                notification.LastName.Value,
                notification.UserId);
            
            await _context.Database.ExecuteSqlRawAsync(@"
                UPDATE likes
                SET author_first_name = {0}, author_last_name = {1}  
                WHERE author_id = {2}", 
                notification.FirstName.Value,
                notification.LastName.Value,
                notification.UserId);
        }
    }
}