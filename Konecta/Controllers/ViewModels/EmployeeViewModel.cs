using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Konecta.Controllers.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime AdmissionDate { get; set; }
        public decimal Salary { get; set; }
    }
}