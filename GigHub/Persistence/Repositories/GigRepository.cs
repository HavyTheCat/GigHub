﻿using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace GigHub.Persistence.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _context;
        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Gig> GetUserGigs(string userId)
        {
            return _context.Gigs
                .Where(g =>
                g.ArtistId == userId &&
                g.DateTime > DateTime.Now &&
                !g.IsCanceled)
                .Include(g => g.Genre)
                .ToList();
        }

        public Gig GetGig(int gigId)
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .SingleOrDefault(g => g.Id == gigId);
        }

        public Gig GetGigWithDetails(int gigId)
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Attendances)
                .Include(g => g.Genre)
                .Single(g => g.Id == gigId);

        }

        public Gig GetGigWithAttendees(int gigId)
        {
            return _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.Id == gigId);
        }


     public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }


        public void Add(Gig gig)
        {
            _context.Gigs.Add(gig);
        }

        public IEnumerable<Gig> GetUpcomingGigs(string searchTerm = null)
        {
            var upcomingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);

            if (!String.IsNullOrWhiteSpace(searchTerm))
            {
                upcomingGigs = upcomingGigs
                    .Where(g =>
                            g.Artist.Name.Contains(searchTerm) ||
                            g.Genre.Name.Contains(searchTerm) ||
                            g.Venue.Contains(searchTerm));
            }

            return upcomingGigs.ToList();
        }
    }
}