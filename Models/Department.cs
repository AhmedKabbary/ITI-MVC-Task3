using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication4.Models
{
    public class Department
    {
        public required int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [ValidateNever]
        public required ICollection<Student> Students { get; set; }
    }
}