using Konecta.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Konecta.Models
{
    public class Employee
    {
        [Key]
        [Required]
        [DisplayName("Id empleado")]
        public int EmployeeId { get; set; }
        [Required]
        [DisplayName("Fecha de ingreso")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime AdmissionDate { get; set; }
        [Required]
        [DisplayName("Nombre")]
        [StringLength(50)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Salario")]
        [DisplayFormat(DataFormatString = "{0:#.####}", ApplyFormatInEditMode = true)]
        public decimal Salary { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}