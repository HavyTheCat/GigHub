using GigHub.Core.Models;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Linq;
using GigHub.Persistence;
using GigHub.Core.Dtos;
using GigHub.Core;

namespace GigHub.Controllers.Api
{
    public class FollowingsController : ApiController
    {
  

        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult UnFollow(string id)
        {
            var userId = User.Identity.GetUserId();

            var following = _unitOfWork.Following.GetFollowing(id, userId);

            if (following == null)
                return NotFound();

            _unitOfWork.Following.Remove(following);
            _unitOfWork.Complite();

            return Ok(id);

        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            

            if (_unitOfWork.Following.GetFollowing(dto.FolloweeId, userId) != null)
                return BadRequest("Following already exist");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _unitOfWork.Following.Add(following);
            _unitOfWork.Complite();
            return Ok();
        }
    }
}
