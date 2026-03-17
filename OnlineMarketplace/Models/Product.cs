using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineMarketplace.Models;

namespace OnlineMarketplace.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string? City { get; set; }

        public string? ImagePath { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

        public string? UserId { get; set; }

        // Navigation property
        public Category? Category { get; set; }
    }
}