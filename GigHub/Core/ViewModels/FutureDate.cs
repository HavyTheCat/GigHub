﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GigHub.Core.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
           var isValid = DateTime.TryParseExact(Convert.ToString(value), 
                "d MMM yyyy", 
                new CultureInfo("en-US"),
                DateTimeStyles.None,
                out dateTime);

            return (isValid && dateTime > DateTime.Now);
         
        }
    }

}