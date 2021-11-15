using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDos.Api.viewModels
{
    public class ToDoViewModel
    {
        [Required]
        [StringLength(20, MinimumLength=7, ErrorMessage="Vesk teisingai")]
        [DataType(DataType.Text)]
        public string ToDo { get; set; }
        public string Priority { get; set; }

        //[EmailAddress]
        //public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
