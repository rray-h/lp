using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class CreateTaskViewModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Problem { get; set; }
        public bool IsItQuick { get; set; }
        public string PhoneNumber { get; set; }
        public bool CanBeRedacted { get; set; }
        public string AppUserId { get; set; }
    }
}
