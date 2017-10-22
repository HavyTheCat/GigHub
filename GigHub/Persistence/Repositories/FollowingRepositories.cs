using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Persistence.Repositories
{
    public class FollowingRepositories : IFollowingRepositories
    {
        private readonly ApplicationDbContext _context;


        public FollowingRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public Following GetFollowing(string followeeId, string followerId)
        {
            return _context.Followings.SingleOrDefault(f => f.FollowerId == followerId && f.FolloweeId == followeeId);
        }

        public IEnumerable<Following> GetFollowings(string followeeId, string followerId)
        {
            return _context.Followings.Where(f => f.FolloweeId == followeeId && f.FollowerId == followerId);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}