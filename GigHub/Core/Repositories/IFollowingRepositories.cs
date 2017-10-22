using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IFollowingRepositories
    {
        IEnumerable<Following> GetFollowings(string followeeId, string followerId);
        Following GetFollowing(string followeeId, string followerId);
        void Remove(Following following);
        void Add(Following following);
    }
}