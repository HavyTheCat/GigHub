using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using GigHub.Persistence;
using GigHub.Core.Dtos;
using GigHub.Core;

namespace GigHub.Controllers.Api
{

  

    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      
     

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {

            var userid = User.Identity.GetUserId();

            
            if (_unitOfWork.Attendance.GetAttendance(dto.GigId, userid) != null)
               return BadRequest("attendance is already exist");
            

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userid
            };

            _unitOfWork.Attendance.Add(attendance);
            _unitOfWork.Complite();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userid = User.Identity.GetUserId();
            var attendance = _unitOfWork
                .Attendance.GetAttendance(id, userid);
             
        
            if (attendance == null)
            {
                return NotFound();
            }


            _unitOfWork.Attendance
                .Remove(attendance);

            _unitOfWork.Complite();

            return Ok(id);


        }
    }
}
