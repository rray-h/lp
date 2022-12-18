﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Data.Enum;

namespace WebApplication1.Models
{
    public class Query
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Problem { get; set; }
        [Required]
        public bool IsItQuick { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public bool? CanBeRedacted { get; set; }
        public bool? hasTaken { get; set; }
        [ForeignKey("User")]
        public int? UserID { get; set; }
        public User? User { get; set; }  

    }
}
