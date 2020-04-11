using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Konecta.Controllers.ViewModels
{
    public class RequestViewModel
    {
        public int RequestId { get; set; }

        [DisplayName("Código")]
        public string Code { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }

        [DisplayName("Resumen")]
        public string Summary { get; set; }

        [DisplayName("Nombre del empleado")]
        public string EmployeeName { get; set; }
    }
}