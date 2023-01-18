
namespace WebApplication1.ViewModels
{
    public class EditTaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string PhoneNumber { get; set; }
        public string QueryStatus { get; set; }
        public bool? CanBeRedacted { get; set; }
        public string? FreelancerID { get; set; }
        public string? AppUserId { get; set; }
        public string Problem { get; set; }
        public bool IsItQuick { get; set; }
    }
}
