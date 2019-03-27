﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EfCoreModeling.Model
{
    public class Message
    {
        [Key]
        [Required]
        [InverseProperty(nameof(User))]
        public long MessageId { get; set; }
        [Required]
        public string Description { get; set; }
        public User User { get; set; }
    }
}