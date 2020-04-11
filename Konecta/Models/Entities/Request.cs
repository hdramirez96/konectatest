using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Konecta.Models.Entities
{
    public class Request
    {
        [Key]
        [Required]
        [DisplayName("Id Solicitud")]
        public int RequestId { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(50)]
        [DisplayName("Código")]
        public string Code { get; set; }

        [StringLength(50)]
        [MaxLength(50)]
        [DisplayName("Descripción")]
        public string Description { get; set; }

        [StringLength(50)]
        [MaxLength(50)]
        [DisplayName("Resumen")]
        public string Summary { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}