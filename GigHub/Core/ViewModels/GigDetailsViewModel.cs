

using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
    public class GigDetailsViewModel
    {
        public Gig Gig { get; set; }
        public bool AttendeeStatus { get; set; }
        public bool isFolowing { get; set; }
    }
}