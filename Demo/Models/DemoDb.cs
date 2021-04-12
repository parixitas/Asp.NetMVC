using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    [Table("Emp")]
    public class Emp
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        [Required ] 
        [Range(1, 100, ErrorMessage = "age must be between 1 and 100")]
        public int? Age { get; set; }
        [Required]
       
        public string Address { get; set; }
    }

    public class EmpContext : DbContext
    {
        public virtual DbSet<Emp> Employees { get; set; }
    }
}