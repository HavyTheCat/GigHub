using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Collections.Generic;
using System.Linq;


namespace GigHub.Persistence.Repositories
{
    public class GenresRepositories : IGenresRepositories
    {
        private readonly ApplicationDbContext _context;

        public GenresRepositories(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

    }
}