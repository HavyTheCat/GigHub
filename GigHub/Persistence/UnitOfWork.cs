using GigHub.Core;
using GigHub.Core.Repositories;
using GigHub.Persistence.Repositories;

namespace GigHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGigRepository Gigs { get; private set; }
        public IAttendanceRepository Attendance { get; private set; }
        public IGenresRepositories Genres { get; private set; }
        public IFollowingRepositories Following { get; private set; }
        public IApplicationUserRepository Users { get; private set; }
        public INotificationRepository Notification { get; private set; }
        public IUserNotificationRepository UserNotification { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendance = new AttendanceRepository(context);
            Genres = new GenresRepositories(context);
            Following = new FollowingRepositories(context);
            Users = new ApplicationUserRepository(context);
            Notification = new NotificationRepository(context);
            UserNotification = new UserNotificationRepository(context);
        }

        public void Complite()
        {
            _context.SaveChanges();
        }
    }
}