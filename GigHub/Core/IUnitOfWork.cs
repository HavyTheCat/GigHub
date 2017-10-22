using GigHub.Core.Repositories;

namespace GigHub.Core
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendance { get; }
        IFollowingRepositories Following { get; }
        IGenresRepositories Genres { get; }
        IGigRepository Gigs { get; }
        IApplicationUserRepository Users { get; }
        IUserNotificationRepository UserNotification { get; }
        INotificationRepository Notification { get; }


        void Complite();
    }
}