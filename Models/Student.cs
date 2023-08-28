using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Models
{
    public class Student
    {
        public required int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        // [Range(13, 80)]
        [Remote("IsAgeValid", "Validations")]
        public required int Age { get; set; }

        [Required]
        public required int DeptNo { get; set; }

        [ForeignKey(nameof(DeptNo))]
        public Department? Department { get; set; }
    }
}