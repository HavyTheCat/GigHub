using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        void Add(Attendance attendance);
        IEnumerable<Attendance> GetAttendancesByUserId(string userId, int gigId);
        IEnumerable<Attendance> GetFutureAttendancess(string userId);
        Attendance GetAttendance(int gigId, string userId);
        void Remove(Attendance attendance);
    }
}