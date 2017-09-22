using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Dtos;

namespace GigHub.Controllers.Api
{

  

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {

            var userid = User.Identity.GetUserId();
            

            if (_context.Attendances.Any(a => a.AttendeeId == userid && a.GigId == dto.GigId))
            {
                return BadRequest("attendance is already exist");
            }

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userid
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
