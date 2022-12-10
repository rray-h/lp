﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
