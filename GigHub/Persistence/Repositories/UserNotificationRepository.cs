using System.Collections.Generic;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Linq;

namespace GigHub.Persistence.Repositories
{
    public class UserNotificationRepository : IUserNotificationRepository
    {

        private readonly ApplicationDbContext _context;

        public UserNotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<UserNotification> GetUserNotificationsFor(string userId)
        {
            return _context.UserNotification
              .Where(un => un.UserId == userId && !un.isRead)
              .ToList();
        }
    }
}