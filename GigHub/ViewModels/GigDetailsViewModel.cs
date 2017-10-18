

using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigDetailsViewModel
    {
        public Gig Gig { get; set; }
        public bool AttendeeStatus { get; set; }
        public bool isFolowing { get; set; }
    }
}