﻿using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GigHub.Core.Models
{
    public class UserNotification
    {
      
        public string UserId { get; private set; }

        public int NotificationId { get; private set; }

        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }

        public bool isRead { get; private set; }

        


        protected UserNotification()
        {

        }


        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (notification == null)
                throw new ArgumentNullException("notification");


            Notification = notification;
            User = user;

        }
        public void Read()
        {
            isRead = true;
        }
    }
}