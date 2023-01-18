namespace WebApplication1.ViewModels
{
    public class DetailViewModel
    {
        public int Id { get; set; }
        public bool? CanBeRedacted { get; set; }
        public string? FreelancerID { get; set; }
        public string QueryStatus { get; set; }
    }
}
