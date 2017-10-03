using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using GigHub.App_Start;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotification
                .Where(un => un.UserId == userId && !un.isRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();


            var config = MappingProfile.GetMappingProfile();

            IMapper Mapper = config.CreateMapper();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
                
        }
    }
}
