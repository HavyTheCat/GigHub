using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using GigHub.App_Start;
using GigHub.Persistence;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Core;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult NotificationShown(int Id)
        {
            var userId = User.Identity.GetUserId();
            var notification = _unitOfWork
                .UserNotification
                .GetUserNotificationsFor(userId).ToList();




            notification.ForEach(n => n.Read());
            _unitOfWork.Complite();

                


            return Ok();

        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _unitOfWork
                .Notification.GetNewNotificationsFor(userId);


            var config = MappingProfile.GetMappingProfile();

            IMapper Mapper = config.CreateMapper();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
                
        }
    }
}
